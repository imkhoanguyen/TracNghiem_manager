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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TracNghiemManager.GUI.Users
{
    public partial class UserInfo : Form
    {
		UserBUS userBUS = new UserBUS();
		int user_id = Form1.USER_ID;
		UserDTO user;
		public UserInfo()
		{
			InitializeComponent();
			user = userBUS.getById(user_id);
			RenderUser(user);
		}

		private void buttonUpImg_Click(object sender, EventArgs e)
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

		private void button1_Click(object sender, EventArgs e)
		{
			if (validate_form())
			{
				user = userBUS.getById(user_id);
				DateTime date = dateTimePicker1.Value;
				string gender = "";
				if (rbNam.Checked) gender = rbNam.Tag.ToString();
				if (RbNu.Checked) gender = RbNu.Tag.ToString();

				int gioi_tinh = Convert.ToInt32(gender);
				user.Email = textBoxEmail.Text.Trim();
				user.HoVaTen = textBoxName.Text.Trim();
				user.ngaySinh = Convert.ToDateTime(textBox2.Text.Trim());
				user.avatar = textBox1.Text.Trim();
				user.gioiTinh = gioi_tinh;

				MessageBox.Show(userBUS.Update(user));

				button1.Visible = false;
				buttonUpImg.Visible = false;
				panel1.Enabled = false;
				textBoxName.Enabled = false;
				textBoxEmail.Enabled = false;
				dateTimePicker1.Enabled = false;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			button1.Visible = true;
			buttonUpImg.Visible = true;

			panel1.Enabled = true;
			textBoxName.Enabled = true;
			textBoxEmail.Enabled = true;
			dateTimePicker1.Enabled = true;
		}

		private void label5_Click(object sender, EventArgs e)
		{

		}

		private void RenderUser(UserDTO user)
		{
			pictureBox1.ImageLocation = @"" + user.avatar;

			textBoxName.Text = user.HoVaTen;

			textBoxEmail.Text = user.Email;

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
			return true;
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			textBox2.Text = dateTimePicker1.Value.ToString();
		}
	}
}
