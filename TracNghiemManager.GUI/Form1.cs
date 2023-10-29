using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TracNghiemManager.BUS;
using TracNghiemManager.DTO;
using TracNghiemManager.GUI.Users;
using Formatting = Newtonsoft.Json.Formatting;

namespace TracNghiemManager.GUI
{
	public partial class Form1 : Form
	{

		private Size formOriginalSize;
		private Rectangle recLab1;
		private Rectangle recLab2;
		private Rectangle recLab3;
		private Rectangle recLab4;
		private Rectangle recBut1;
		private Rectangle recTxt1;
		private Rectangle recTxt2;
		private Rectangle recCBox1;
		public static int USER_ID;
		public static DateTime LoginTime = DateTime.Now;
		public static int flag = -1; // check tk da dien full tt chua

		public Form1()
		{
			InitializeComponent();
			this.Resize += Form1_Resiz;
			formOriginalSize = this.Size;
			recLab1 = new Rectangle(label1.Location, label1.Size);
			recLab2 = new Rectangle(label2.Location, label2.Size);
			recLab3 = new Rectangle(label3.Location, label3.Size);
			recLab4 = new Rectangle(label4.Location, label4.Size);
			recBut1 = new Rectangle(button1.Location, button1.Size);
			recTxt1 = new Rectangle(textBox1.Location, textBox1.Size);
			recTxt2 = new Rectangle(textBox2.Location, textBox2.Size);
			recCBox1 = new Rectangle(checkBox1.Location, checkBox1.Size);
			textBox1.Multiline = true;
			textBox2.Multiline = true;

		}

		private void Form1_Resiz(object sender, EventArgs e)
		{
			resize_Control(button1, recBut1);
			resize_Control(textBox1, recTxt1);
			resize_Control(textBox2, recTxt2);
			resize_Control(label1, recLab1);
			resize_Control(label2, recLab2);
			resize_Control(label3, recLab3);
			resize_Control(label4, recLab4);
			resize_Control(checkBox1, recCBox1);
		}

		private void resize_Control(Control c, Rectangle r)
		{
			float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
			float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
			int newX = (int)(r.X * xRatio);
			int newY = (int)(r.Y * yRatio);
			int newWidth = (int)(r.Width * xRatio);
			int newHeight = (int)(r.Height * yRatio);

			c.Location = new Point(newX, newY);
			c.Size = new Size(newWidth, newHeight);
			float newFontSize = c.Font.Size * Math.Min(xRatio, yRatio);
			if (newFontSize > 20)
			{
				newFontSize = 20; // Keep the maximum font size
			}
			else if (newFontSize < 6)
			{
				newFontSize = 6; // Keep the minimum font size
			}
			c.Font = new Font(c.Font.FontFamily, newFontSize);
		}
		private void button1_Click(object sender, EventArgs e)
		{
			UserBUS userBUS = new UserBUS();
			int id = userBUS.getIdByUsername(textBox1.Text.Trim());
			if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (id == -1)
			{
				MessageBox.Show("Username không tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			UserDTO user = userBUS.getById(id);
			user.Password = user.Password.Trim();
			textBox2.Text = textBox2.Text.Trim();
			if (user.Password != textBox2.Text)
			{
				MessageBox.Show("Mật Khẩu sai!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			USER_ID = id;
			UserDTO uLogin = userBUS.getById(USER_ID);
			if(uLogin.HoVaTen == "")
			{
				DialogResult result = MessageBox.Show("Vui lòng điền thông tin cá nhân trước khi đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				if(result == DialogResult.OK)
				{
					UserInfo userInfo = new UserInfo();
					userInfo.Show();
					flag = 1;
				} 
			} else
			{
				UserForm form = new UserForm();
				form.Show();
				SaveLoginHistory(USER_ID.ToString() + "_" + LoginTime.ToString());
			}
			this.Visible = false;

		}
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				textBox2.PasswordChar = '\0';
			}
			else
			{
				textBox2.PasswordChar = '*';
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				e.Handled = true;
				textBox2.Focus();
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				e.Handled = true;
				button1.PerformClick();
			}
		}

		public void SaveLoginHistory(string idLogin)
		{
			List<UserDTO> loginHistories = new List<UserDTO>();

			// Đọc dữ liệu từ tệp JSON nếu nó đã tồn tại
			if (File.Exists("loginHistory.json"))
			{
				string json = File.ReadAllText("loginHistory.json");
				loginHistories = JsonConvert.DeserializeObject<List<UserDTO>>(json);
			}

			UserBUS userBUS = new UserBUS();
			UserDTO u = userBUS.getById(USER_ID);
			ChiTietQuyenBUS ctqBus = new ChiTietQuyenBUS();
			List<ChiTietQuyenDTO> user_roles = ctqBus.GetRoleByUserId(u.Id);
			string q = "";
			for (int i = 0; i < user_roles.Count; i++)
			{
				q += user_roles[i].ten_quyen;
				if (i < user_roles.Count - 1)
				{
					q += ", ";
				}
			}

			// Check if loginHistories is null
			if (loginHistories == null)
			{
				loginHistories = new List<UserDTO>();
			}
			u.TimeIn = LoginTime;
			u.TenQuyen = q;
			u.IdLogin = idLogin;
			UserDTO userHistory = u;
			
			loginHistories.Add(userHistory);
			// Ghi lại danh sách vào tệp JSON
			string updatedJson = JsonConvert.SerializeObject(loginHistories, Formatting.Indented);
			File.WriteAllText("loginHistory.json", updatedJson);
		}



	}
}