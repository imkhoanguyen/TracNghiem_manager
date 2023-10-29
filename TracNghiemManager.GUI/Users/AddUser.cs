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

namespace TracNghiemManager.GUI.Users
{
	public partial class AddUser : Form
	{
		private List<QuyenDTO> getItemsClicked;
		UserBUS userBUS = new UserBUS();
		QuyenBus qBus;
		ChiTietQuyenBUS chiTietQuyenBUS = new ChiTietQuyenBUS();
		private ManageUser manageUser;
		private int flag = -1; // check add thanh cong khong
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
				MessageBox.Show("username!");
				return false;
			}
			else if (!userBUS.isExistUsername(txtUsername.Text.Trim()))
			{
				MessageBox.Show("username was exist!");
				return false;
			}
			else if (txtPassword.Text.Trim().Length <= 0)
			{
				MessageBox.Show("password!");
				return false;
			}
			else if (checkedListBox1.CheckedItems.Count <= 0)
			{
				MessageBox.Show("chua chon quyen!");
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
				flag = 1;
				clear();
			}
			if(flag == 1)
			{
				manageUser.reLoad(userBUS.GetAll());
			}
		}

		private void clear()
		{
			this.Dispose();
		}
	}
}
