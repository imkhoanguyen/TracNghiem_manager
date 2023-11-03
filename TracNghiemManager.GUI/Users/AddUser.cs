using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracNghiemManager.BUS;
using TracNghiemManager.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TracNghiemManager.GUI.Users
{
	public partial class AddUser : Form
	{
		private List<QuyenDTO> getItemsClicked;
		UserBUS userBUS = new UserBUS();
		QuyenBus qBus;
		ChiTietQuyenBUS chiTietQuyenBUS = new ChiTietQuyenBUS();
		private ManageUser manageUser;
		public AddUser(ManageUser mgu)
		{
			InitializeComponent();
			qBus = new QuyenBus();

			//render checkedlistbox
			List<QuyenDTO> listQuyen = qBus.GetAll();
			foreach (QuyenDTO item in listQuyen)
			{
				if (!(item.ten_quyen.Equals("Admin") || item.ten_quyen.Equals("Full")))
				{
					checkedListBox1.Items.Add(item);
				}
			}
			checkedListBox1.DisplayMember = "ten_quyen";
			this.manageUser = mgu;
		}

		private bool validateForm()
		{
			if (txtUsername.Text.Trim().Length <= 0)
			{
				MessageBox.Show("Tài khoản không được rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			else if (!userBUS.isExistUsername(txtUsername.Text.Trim()))
			{
				MessageBox.Show("Tài khoản không được trùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			else if (txtPassword.Text.Trim().Length <= 0)
			{
				MessageBox.Show("Mật khẩu không được rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

				return false;
			}
			else if (checkedListBox1.CheckedItems.Count <= 0)
			{
				MessageBox.Show("Chưa chọn quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}

		private void ButtonSubmit_Click(object sender, EventArgs e)
		{
			if (validateForm())
			{
				string username = txtUsername.Text.Trim();
				string password = txtPassword.Text.Trim();
				DateTime ngayTao = DateTime.Now;

				UserDTO user = new UserDTO();
				user.UserName = username;
				user.Password = password;
				user.ngayTao = ngayTao;

				string s = userBUS.Add(user);
				int user_id = userBUS.getNewId();
				MessageBox.Show(s);

				//them quyen 
				foreach (QuyenDTO item in checkedListBox1.CheckedItems)
				{
					int ma_quyen = item.ma_quyen;
					ChiTietQuyenDTO chiTietQuyen = new ChiTietQuyenDTO();
					chiTietQuyen.ma_quyen = ma_quyen;
					chiTietQuyen.user_id = user_id;

					chiTietQuyenBUS.Add(chiTietQuyen);
				}
				clear();
			}
			manageUser.reLoad(userBUS.GetAll());
		}

		private void clear()
		{
			this.Dispose();
		}

		private bool validThemSl()
		{
			if (string.IsNullOrEmpty(txtTkSL.Text))
			{
				MessageBox.Show("Tài khoản không được rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			else if (string.IsNullOrEmpty(txtMkSl.Text))
			{
				MessageBox.Show("Mật khẩu không được rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			else if (rbGv.Checked == false && rbHs.Checked == false)
			{
				MessageBox.Show("Chưa chọn quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			else if (numSl.Value < 1)
			{
				MessageBox.Show("Số lượng phải lớn hơn hoặc bằng 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			else if (numSl.Value > 1000)
			{
				MessageBox.Show("Số lượng phải bé hơn hoặc bằng 1000", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}

		private void btnThemSl_Click(object sender, EventArgs e)
		{
			if (validThemSl())
			{
				// check xem qua trinh render tai khoan co trung nhau xong neu co bat cu tai khoan nao bi trungg thi se dung lai
				for (int i = 1; i <= numSl.Value; i++)
				{
					string tk = txtTkSL.Text + i;
					if (!userBUS.isExistUsername(tk))
					{
						MessageBox.Show("Đã tồn tại tài khoản trùng xin vui lòng nhập định dạng tài khoản khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
				}
				// neu khong co tai khoan nao trung tien hanh them tu dong
				for (int i = 1; i <= numSl.Value; i++)
				{
					int userId = userBUS.getNewId();
					string tk = txtTkSL.Text + i;
					string mk = txtMkSl.Text;
					DateTime ngayTao = DateTime.Now;

					UserDTO user = new UserDTO();
					user.UserName = tk;
					user.Password = mk;
					user.ngayTao = ngayTao;
					int mq = 3;
					if (rbGv.Checked == true)
					{
						mq = 2;
					}
					else if (rbHs.Checked == true)
					{
						mq = 3;
					}
					userBUS.Add(user);
					ChiTietQuyenDTO chiTietQuyen = new ChiTietQuyenDTO();
					chiTietQuyen.ma_quyen = mq;
					chiTietQuyen.user_id = userId;
					chiTietQuyenBUS.Add(chiTietQuyen);
				}
				clear();
				manageUser.reLoad(userBUS.GetAll());
			}
		}
	}
}
