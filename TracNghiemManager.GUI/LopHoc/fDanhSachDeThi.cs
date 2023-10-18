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
using TracNghiemManager.GUI.DeThi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TracNghiemManager.GUI.LopHoc
{
	public partial class fDanhSachDeThi : Form
	{
		private int counter = 1;
		System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
		DeThiBUS dtBus;
		private List<DeThiDTO> listdt;
		MonHocBUS mhBus;
		MonHocDTO selectedMonHoc;
		LopDTO lopDTO;
		DeThiCuaLopBUS dtclBus;
		public fDanhSachDeThi(LopDTO l)
		{
			InitializeComponent();
			dtBus = new DeThiBUS();
			mhBus = new MonHocBUS();
			dtclBus = new DeThiCuaLopBUS();
			lopDTO = l;
			loadTextBox();
			listdt = dtBus.GetAll();
			loadDeThi(listdt);
			loadCbMonHoc();
		}
		void loadTextBox()
		{
			txtDeThi.Text = "Nhập tên đề thi cần tìm kiếm tại đây...";
			txtDeThi.ForeColor = Color.Gray;
		}

		private void txtDeThi_Click(object sender, EventArgs e)
		{
			if (txtDeThi.Text.Equals("Nhập tên đề thi cần tìm kiếm tại đây..."))
			{
				txtDeThi.Text = "";
			}
			txtDeThi.ForeColor = Color.Black;
		}

		private void txtDeThi_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtDeThi.Text))
			{
				loadTextBox();
			}
		}

		void loadDeThi(List<DeThiDTO> list)
		{
			listdt = list;
			// Xóa tất cả các panel được tạo trước đó
			flowLayoutPanel1.Controls.Clear();
			foreach (var l in listdt)
			{
				CreatePanel(l);
			}
		}

		// Ramdom mau nhat
		private Color GetRandomColor()
		{
			Random random = new Random();
			int r = random.Next(256);
			int g = random.Next(256);
			int b = random.Next(256);

			// Làm cho màu sắc nhạt hơn bằng cách thêm 128 vào mỗi thành phần màu
			r += 128;
			g += 128;
			b += 128;

			// Đảm bảo rằng các thành phần màu không vượt quá 255
			r = r > 255 ? 255 : r;
			g = g > 255 ? 255 : g;
			b = b > 255 ? 255 : b;

			return Color.FromArgb(r, g, b);
		}

		private void CreatePanel(DeThiDTO obj)
		{
			Panel panelContain = new Panel
			{
				Location = new Point(3, 3),
				Name = "panelContain" + counter.ToString(),
				Size = new Size(390, 350),
				TabIndex = 0,
				BorderStyle = BorderStyle.FixedSingle,
				Margin = new Padding(10, 10, 10, 10),
			};

			Panel panelHead = new Panel
			{
				Location = new Point(0, 0),
				Name = "panelHead",
				Size = new Size(390, 290),
				TabIndex = 1,
				BackColor = GetRandomColor()
			};

			Label lblTenDeThi = new Label
			{
				AutoSize = false,
				Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
				Location = new Point(10, 9),
				Name = "lblTenDeThi" + counter.ToString(),
				Size = new Size(300, 200),
				TabIndex = 0,
				Text = obj.TenDeThi,
				AutoEllipsis = true
			};
			toolTip.SetToolTip(lblTenDeThi, lblTenDeThi.Text);
			lblTenDeThi.Click += (s, ev) => { lblTenDeThi_Click(s, ev, obj); };



			Label lblMonHoc = new Label
			{
				AutoSize = true,
				Location = new Point(20, 190),
				Name = "lblMonHoc1" + counter,
				Size = new Size(110, 13),
				TabIndex = 1,
				Text = "Môn học: " + mhBus.getById(obj.MaMonHoc).TenMonHoc,
				Font = new Font("Segoe UI", 10, FontStyle.Regular)

			};

			Label lblThoiGianLamBai = new Label
			{
				AutoSize = true,
				Location = new Point(20, 220),
				Name = "lblThoiGianLamBai" + counter,
				Size = new Size(140, 13),
				TabIndex = 2,
				Text = "Thời gian làm bài: " + obj.ThoiGianLamBai,
				Font = new Font("Segoe UI", 10, FontStyle.Regular)

			};

			Label lblTrangThai = new Label
			{
				AutoSize = true,
				Location = new Point(20, 250),
				Name = "lblMonHoc1" + counter,
				Size = new Size(110, 13),
				TabIndex = 1,
				Text = obj.TrangThai == 1 ? "Trạng thái: Đang mở" : "Trạng thái: Đang đóng",
				Font = new Font("Segoe UI", 10, FontStyle.Regular)

			};

			System.Windows.Forms.Button btnThem = new System.Windows.Forms.Button
			{
				Location = new Point(10, 300),
				Name = "button2" + counter,
				Size = new Size(200, 41),
				TabIndex = 2,
				Text = "Thêm đề thi vào lớp học",
				UseVisualStyleBackColor = true,
				Cursor = System.Windows.Forms.Cursors.Hand,
				Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
				TextAlign = ContentAlignment.MiddleCenter // Đặt văn bản ở giữa theo cả hai chiều
			};

			System.Windows.Forms.Button btnXem = new System.Windows.Forms.Button
			{
				Location = new Point(250, 300),
				Name = "button2" + counter,
				Size = new Size(100, 41),
				TabIndex = 2,
				Text = "Xem",
				UseVisualStyleBackColor = true,
				Cursor = System.Windows.Forms.Cursors.Hand,
				Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
				TextAlign = ContentAlignment.MiddleCenter // Đặt văn bản ở giữa theo cả hai chiều
			};

			btnThem.Click += (s, ev) =>
				{
					btnThem_Click(s, ev, obj);
				};
			panelHead.Controls.AddRange(new Control[] { lblThoiGianLamBai, lblMonHoc, lblTenDeThi, lblTrangThai
});

			panelContain.Location = new Point(20, flowLayoutPanel1.Controls.Count * 150);
			flowLayoutPanel1.Controls.Add(panelContain);
			panelContain.Controls.AddRange(new Control[] { btnThem, panelHead, btnXem });

			flowLayoutPanel1.AutoScroll = true;

			counter++;
		}

		private void btnThem_Click(object s, EventArgs ev, DeThiDTO obj)
		{
			fThemDeThiCuaLop f = new fThemDeThiCuaLop(obj, lopDTO, "add");
			f.Visible = true;
		}

		private void lblTenDeThi_Click(object s, EventArgs ev, DeThiDTO obj)
		{
			throw new NotImplementedException();
		}

		private void cbMonHoc_SelectedValueChanged(object sender, EventArgs e)
		{
            System.Windows.Forms.ComboBox cb = sender as System.Windows.Forms.ComboBox;
			if(cb.SelectedValue!= null)
			{
				selectedMonHoc = mhBus.getById(Convert.ToInt32(cb.SelectedValue));
			}
		}
		void loadCbMonHoc()
		{
			cbMonHoc.ValueMember = "MaMonHoc";
			cbMonHoc.DisplayMember = "TenMonHoc";
			List<MonHocDTO> listmh = mhBus.getAll();
			cbMonHoc.DataSource = listmh;
		}

		void Search()
		{
			try
			{
				string noiDungTimKiem = txtDeThi.Text;
				List<DeThiDTO> list = listdt.Where(ch => ch.TenDeThi.Contains(noiDungTimKiem)).ToList();
				foreach (DeThiDTO deThi in list)
				{
					MessageBox.Show(deThi.TenDeThi);

				}
				if (selectedMonHoc!=null)
				{
					list = list.Where(ch => ch.MaMonHoc == selectedMonHoc.MaMonHoc).ToList();
				}
				
				loadDeThi(list);
			} catch(Exception ex)
			{
				ex.ToString();
			}
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			Search();

		}

		private void button1_Click(object sender, EventArgs e)
		{
			fThemDeThi fThemDeThi = new fThemDeThi();
			fThemDeThi.ShowDialog();
		}
	}
}
