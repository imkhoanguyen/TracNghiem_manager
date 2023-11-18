using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracNghiemManager.BUS;
using TracNghiemManager.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TracNghiemManager.GUI.Users
{
	public partial class UserInfo : Form
	{
		UserBUS userBUS = new UserBUS();
		int user_id = Form1.USER_ID;
		UserDTO user;
		private DateTime timePick;
		private UserForm userForm;
		private int userIdUpdate;
		private ManageUser manageUser;
		private string flagAdminUpdate;
		public UserInfo()
		{
			InitializeComponent();
			user = userBUS.getById(user_id);
			RenderUser(user);
		}
		public UserInfo(UserForm f)
		{
			InitializeComponent();
			userForm = f;
			user = userBUS.getById(user_id);
			RenderUser(user);

		}
		public UserInfo(ManageUser u, int userId, string flag)
		{
			InitializeComponent();
			manageUser = u;
			userIdUpdate = userId;
			flagAdminUpdate = flag;
			user = userBUS.getById(userIdUpdate);
			RenderUser(user);

		}

		private void label5_Click(object sender, EventArgs e)
		{

		}

		private bool checkHoten(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				MessageBox.Show("Không được để trống họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (!Regex.IsMatch(name, @"^[\p{L}\s]+$"))
			{
				MessageBox.Show("Vui lòng nhập đúng họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}
		private bool checkEmail(string email)
		{
			if (string.IsNullOrEmpty(email))
			{
				MessageBox.Show("Không được để trống Email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (!Regex.IsMatch(email, "^([a-zA-Z0-9_.]+)@gmail.com$"))
			{
				MessageBox.Show("Email không đúng định dạng __@gmail.com", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}
		private bool checkDate(string date)
		{
			DateTime dateNow = DateTime.Now;
			DateTime dateOfBirth = dateTimePicker1.Value;
			DateTime minDateTime = new DateTime(1900, 1, 1);
			int age = dateNow.Year - dateOfBirth.Year;
			if (age < 11)
			{
				MessageBox.Show("Ngày sinh phải đủ 11 tuổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (dateOfBirth.Year < minDateTime.Year)
			{
				MessageBox.Show("Năm sinh không được nhỏ hơn 1990.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return true;

		}

		private void RenderUser(UserDTO user)
		{
			pictureBox1.ImageLocation = @"" + user.avatar;
			textBox1.Text = user.avatar;
			
			textBoxName.Text = user.HoVaTen;

			textBoxEmail.Text = user.Email;

			txtPass.Text = user.Password;

			dateTimePicker1.Value = user.ngaySinh;

			if (user.gioiTinh == 1)
			{
				rbNam.Checked = true;
			}
			if (user.gioiTinh == 0)
			{
				RbNu.Checked = true;
			}
		}
		private bool validate_form()
		{
			if (!checkHoten(textBoxName.Text))
			{
				return false;
			}
			if (!checkEmail(textBoxEmail.Text))
			{
				return false;
			}
			if (!checkDate(dateTimePicker1.Text))
			{
				return false;
			}
			return true;
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			button1.Visible = true;
			buttonUpImg.Visible = true;

			panel1.Enabled = true;
			textBoxName.Enabled = true;
			textBoxEmail.Enabled = true;
			dateTimePicker1.Enabled = true;
			txtPass.Enabled = true;
			if (Form1.flag != 1)
			{
				textBoxName.Enabled = false;
			}
			if (flagAdminUpdate != null)
			{
				if (flagAdminUpdate.Equals("adminUpdate"))
				{
					textBoxName.Enabled = true;
				}
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{

			if (validate_form())
			{
				// admin update tai khoan nguoi dung (admin click chi tiet)
				if (flagAdminUpdate != null)
				{
					user = userBUS.getById(userIdUpdate);
				}
				else
				{
					user = userBUS.getById(user_id);
				}
				string gender = "";
				if (rbNam.Checked) gender = rbNam.Tag.ToString();
				if (RbNu.Checked) gender = RbNu.Tag.ToString();

				int gioi_tinh = Convert.ToInt32(gender);
				// Kiểm tra cập nhật email nếu người dùng nhập khác email hiện tại thì mới check trùng email
				// neu nguoi dung nhap khac email hien tai cua minh
				if(user.Email != textBoxEmail.Text)
				{
					int check = userBUS.CheckEmail(textBoxEmail.Text);
					if(check==1)
					{
						MessageBox.Show("Email đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				user.Email = textBoxEmail.Text;
				
				user.HoVaTen = textBoxName.Text;
				user.ngaySinh = timePick;
				user.avatar = textBox1.Text; // Trong trường hợp nếu ko cập nhật lại hình ảnh thì ở đây avartar sẽ là rỗng
				user.gioiTinh = gioi_tinh;
				user.Password = txtPass.Text;

				if (userBUS.Update(user).Equals("Cập nhật thành công!"))
				{
					MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					// chưa điền đầy đủ thông tin (tai khoan dang nhap lan dau)
					if (Form1.flag == 1)
					{
						UserForm f = new UserForm();
						f.ShowDialog();
						// update avatar trên giao diện userForm (menu chính)
						if (user.avatar != null)
						{
							f.updateAvatar(user.avatar);
						}
						this.Close();
						Form1.flag = -1; // cap nhat ve trang thai ban dau
						Form1 f1 = new Form1();
						f1.SaveLoginHistory(Form1.USER_ID + "_" + Form1.LoginTime.ToString());

					}
					else //Tai khoan da co day du thong tin
					{
						// cap nhat hinh anh tren userForm (thanh ben trai)
						if (user.avatar != null && userForm != null)
						{
							userForm.updateAvatar(user.avatar);
						}
					}
					// cap nhat lai giao dien cua manageuser chinh sua user (admin nhan nut chi tiet)
					if (manageUser != null)
					{
						manageUser.reLoad(userBUS.GetAll());
					}

				}


				button1.Visible = false;
				buttonUpImg.Visible = false;
				panel1.Enabled = false;
				textBoxName.Enabled = false;
				textBoxEmail.Enabled = false;
				dateTimePicker1.Enabled = false;
			}
		}

		private void buttonUpImg_Click_1(object sender, EventArgs e)
		{
			OpenFileDialog ofdImages = new OpenFileDialog();
			ofdImages.Filter = "Ảnh (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
			if (ofdImages.ShowDialog() == DialogResult.OK)
			{
				string filepath = ofdImages.FileName;

				pictureBox1.Image = Image.FromFile(filepath);
				pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

				textBox1.Text = filepath;
			}
		}

		private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
		{
			timePick = dateTimePicker1.Value;
		}
	}
}
