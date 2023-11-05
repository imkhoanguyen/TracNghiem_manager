using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Drawing2D;
using TracNghiemManager.DTO;
using TracNghiemManager.GUI.Users;
using TracNghiemManager.BUS;
using Newtonsoft.Json;
using System.IO;

namespace TracNghiemManager.GUI
{
	public partial class UserForm : Form
	{
		private Rectangle recLab1;
		private ChiTietQuyenBUS chiTietQuyenBUS;
		private UserBUS userBus;
		private string tenQuyen;
		private List<ChiTietQuyenDTO> userRoles;
		public UserForm()
		{
			chiTietQuyenBUS = new ChiTietQuyenBUS();
			userBus = new UserBUS();
			InitializeComponent();
			AddColorChange(btnHome, hoverColor, hoverColor);
			AddColorChange(btnCauHoi, hoverColor, hoverColor);
			AddColorChange(btnMonHoc, hoverColor, hoverColor);
			AddColorChange(btnLopHoc, hoverColor, hoverColor);
			AddColorChange(btnDeThi, hoverColor, hoverColor);
			AddColorChange(btnThongKe, hoverColor, hoverColor);
			AddColorChange(btnThoat, hoverColor, hoverColor);
			AddColorChange(btnNguoiDung, hoverColor, hoverColor);
			userRoles = chiTietQuyenBUS.GetRoleByUserId(Form1.USER_ID);
			for (int i = 0; i < userRoles.Count; i++)
			{
				if (userRoles.Count > 1)
				{
					tenQuyen += userRoles[i].ten_quyen;
					if (i < userRoles.Count - 1)
					{
						tenQuyen += ", ";
					}
				}
				else
				{
					tenQuyen += userRoles[i].ten_quyen;
				}
			}
			loadInfo();
			infoPanelBox.Paint += (sender, e) =>
			{
				Control control = (Control)sender;
				int borderWidth = 2; // Độ rộng của đường viền

				using (Pen borderPen = new Pen(borderColor, borderWidth))
				{
					// Vẽ đường viền bên dưới của TableLayoutPanel
					e.Graphics.DrawLine(borderPen, 0, control.Height - borderWidth, control.Width, control.Height - borderWidth);
				}
			};
			containerBtnPanel.Paint += (sender, e) =>
			{
				Control control = (Control)sender;
				int borderWidth = 2; // Độ rộng của đường viền

				using (Pen borderPen = new Pen(borderColor, borderWidth))
				{
					// Vẽ đường viền bên phải của TableLayoutPanel
					e.Graphics.DrawLine(borderPen, control.Width - borderWidth, 0, control.Width - borderWidth, control.Height);
				}
			};
			HideAllUserControls();
			homePanel.Visible = true;
			

		}

		private void HideAllUserControls()
		{
			homePanel.Visible = false;
			lopHocPanel.Visible = false;
			monHocPanel.Visible = false;
			cauHoiPanel.Visible = false;
			deThiPanel.Visible = false;
			thongKePanel.Visible = false;
			userPanel.Visible = false;

		}


		private void ShowUserControl(UserControl controlToShow)
		{
			HideAllUserControls();
			controlToShow.Visible = true;
		}

		private void AddColorChange(System.Windows.Forms.Button button, Color hoverColor, Color clickColor)
		{
			Color defaultBackColor = button.BackColor;
			Color defaultForeColor = button.ForeColor;

			button.MouseEnter += (sender, e) =>
			{
				button.BackColor = hoverColor;
				button.ForeColor = Color.Black;
			};

			button.MouseHover += (sender, e) =>
			{
				button.BackColor = hoverColor;
				button.ForeColor = Color.Black;
			};

			button.MouseLeave += (sender, e) =>
			{
				button.BackColor = defaultBackColor;
				button.ForeColor = defaultForeColor;
			};

			button.Click += (sender, e) =>
			{
				button.BackColor = clickColor;
				button.ForeColor = Color.Black;
			};
		}

		private void btnHome_Click(object sender, EventArgs e)
		{
			ShowUserControl(homePanel);
		}

		private void btnLopHoc_Click(object sender, EventArgs e)
		{
			ShowUserControl(lopHocPanel);
		}

		private void btnMonHoc_Click(object sender, EventArgs e)
		{
			ShowUserControl(monHocPanel);
		}

		private void btnCauHoi_Click(object sender, EventArgs e)
		{
			ShowUserControl(cauHoiPanel);
			cauHoiPanel.load();
		}

		private void btnDeThi_Click(object sender, EventArgs e)
		{
			ShowUserControl(deThiPanel);
		}

		private void btnThongKe_Click(object sender, EventArgs e)
		{
			ShowUserControl(thongKePanel);
			thongKePanel.load();
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				Form1 form1 = new Form1();
				form1.Show();
				this.Close();
			}
		}

		private void btnNguoiDung_Click(object sender, EventArgs e)
		{
			ShowUserControl(userPanel);
			userPanel.reLoad(userBus.GetAll());
		}

		private void btnPhanQuyen_Click(object sender, EventArgs e)
		{
			//ShowUserControl(PermissionUser);
		}

		private void lblSetting_Click(object sender, EventArgs e)
		{
			UserInfo info = new UserInfo();
			info.Visible = true;
		}

		private void btnSetting_Click(object sender, EventArgs e)
		{
			UserInfo f = new UserInfo(this);
			f.Visible = true;
		}

		private void UserForm_Load_1(object sender, EventArgs e)
		{
			List<ChiTietQuyenDTO> list = chiTietQuyenBUS.GetRoleByUserId(Form1.USER_ID);

			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].ten_quyen.Contains("Admin") || list[i].ten_quyen.Contains("Full"))
				{
					containerBtnPanel.Controls.Add(btnNguoiDung, 0, 7);
					containerBtnPanel.RowStyles.Add(new RowStyle());
					containerBtnPanel.Controls.Add(btnThongKe, 0, 8);
					containerBtnPanel.RowStyles.Add(new RowStyle());
				}

				if (list[i].ten_quyen.Contains("Giáo viên") || list[i].ten_quyen.Contains("Học sinh") || list[i].ten_quyen.Contains("Full"))
				{
					containerBtnPanel.Controls.Add(btnLopHoc, 0, 2);
					containerBtnPanel.RowStyles.Add(new RowStyle());
				}

				if (list[i].ten_quyen.Contains("Giáo viên") || list[i].ten_quyen.Contains("Full"))
				{
					containerBtnPanel.Controls.Add(btnCauHoi, 0, 4);
					containerBtnPanel.RowStyles.Add(new RowStyle());
				}

				if (list[i].ten_quyen.Contains("Giáo viên") || list[i].ten_quyen.Contains("Full"))
				{
					containerBtnPanel.Controls.Add(btnDeThi, 0, 5);
					containerBtnPanel.RowStyles.Add(new RowStyle());
				}

				if (list[i].ten_quyen.Contains("Admin") || list[i].ten_quyen.Contains("Full"))
				{
					containerBtnPanel.Controls.Add(btnMonHoc, 0, 3);
					containerBtnPanel.RowStyles.Add(new RowStyle());
				}

			}
			containerBtnPanel.Controls.Add(btnThoat, 0, 9);
			containerBtnPanel.RowStyles.Add(new RowStyle());

		}
		public void loadInfo()
		{
		
			UserDTO u = userBus.getById(Form1.USER_ID);
			lblOwnerName.Text = u.HoVaTen;
			lblOwnerRule.Text = tenQuyen;
			if (!string.IsNullOrWhiteSpace(u.avatar) && System.IO.File.Exists(u.avatar))
			{
				pictureOwner.ImageLocation = u.avatar;
			}
		}

		public void updateAvatar(string ava)
		{
			if (!string.IsNullOrWhiteSpace(ava) && System.IO.File.Exists(ava))
			{
				pictureOwner.ImageLocation = ava;
			}
		}

		private void UserForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			UpdateLogoutTime(Form1.USER_ID.ToString() + "_" + Form1.LoginTime.ToString());
		}
		private void UpdateLogoutTime(string loginId)
		{
			List<UserDTO> loginHistories = new List<UserDTO>();

			// Đọc dữ liệu từ tệp JSON nếu nó đã tồn tại
			if (File.Exists("loginHistory.json"))
			{
				string json = File.ReadAllText("loginHistory.json");
				loginHistories = JsonConvert.DeserializeObject<List<UserDTO>>(json);
			}

			// Tìm thông tin đăng nhập của người dùng và cập nhật thời gian đăng xuất
			UserDTO userHistory = loginHistories.FirstOrDefault(history => history.IdLogin == loginId);
			if (userHistory != null)
			{
				userHistory.TimeOut = DateTime.Now;
			}

			// Ghi lại danh sách vào tệp JSON
			string updatedJson = JsonConvert.SerializeObject(loginHistories, Formatting.Indented);
			File.WriteAllText("loginHistory.json", updatedJson);
		}
	}
}
