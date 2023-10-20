using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracNghiemManager.BUS;
using TracNghiemManager.DTO;
using TracNghiemManager.GUI.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TracNghiemManager.GUI.LopHoc
{
	public partial class fChiTietLop : Form
	{
		LopDTO lop;
		LopHocUserControl lopHocUserControl;
		private int counter = 1;
		System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
		DeThiBUS dtBus;
		List<DeThiCuaLopDTO> listdtcl;
		MonHocBUS mhBus;
		DeThiCuaLopBUS dtclBus;
		public fChiTietLop(LopHocUserControl lhuc, LopDTO obj)
		{
			InitializeComponent();
			dtclBus = new DeThiCuaLopBUS();
			dtBus = new DeThiBUS();
			mhBus = new MonHocBUS();
			lop = obj;
			lopHocUserControl = lhuc;
			loadCTLop();
			loadDeThi();
		}

		public void loadDeThi()
		{
			listdtcl = dtclBus.GetAll(lop.MaLop);
			flowLayoutPanel1.Controls.Clear();
			foreach (var item in listdtcl)
			{
				DeThiDTO dt = dtBus.GetById(item.MaDeThi);
				CreatePanel(dt, item);
			}
		}

		public void loadCTLop()
		{
			lblMaMoi.Text = lop.MaMoi;
			lblTenLop.Text = lop.TenLop + "   ";
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			fDanhSachDeThi f = new fDanhSachDeThi(lop, this);
			f.Visible = true;
		}

		private void lblTenLop_Click(object sender, EventArgs e)
		{
			fThemLop f = new fThemLop(lopHocUserControl, "edit", lop.MaMoi, lop);
			f.Visible = true;
		}

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
			
			if (r == 134 && r == 142 && r==150)
			{
				return GetRandomColor();
			}
			return Color.FromArgb(r, g, b);
		}

		private void CreatePanel(DeThiDTO obj, DeThiCuaLopDTO baiThi)
		{
			Panel panelContain = new Panel
			{
				Location = new Point(3, 3),
				Name = "panelContain" + counter.ToString(),
				Size = new Size(390, 350),
				TabIndex = 0,
				BorderStyle = BorderStyle.FixedSingle,
				Margin = new Padding(10, 10, 10, 10),
				Enabled = baiThi.TrangThai == 0 ? false : true,
			};

			Panel panelHead = new Panel
			{
				Location = new Point(0, 0),
				Name = "panelHead",
				Size = new Size(390, 290),
				TabIndex = 1,
				BackColor = baiThi.TrangThai == 1 ? GetRandomColor() : Color.FromArgb(134,142,150)
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
				Text = "Thời gian làm bài: " + obj.ThoiGianLamBai + " phút",
				Font = new Font("Segoe UI", 10, FontStyle.Regular)

			};

			Label lblTrangThai = new Label
			{
				AutoSize = true,
				Location = new Point(20, 250),
				Name = "lblMonHoc1" + counter,
				Size = new Size(110, 13),
				TabIndex = 1,
				Text = baiThi.TrangThai == 1 ? "Trạng thái: Đang mở" : "Trạng thái: Đã đóng",
				Font = new Font("Segoe UI", 10, FontStyle.Regular)

			};

			System.Windows.Forms.Button btnLamBai = new System.Windows.Forms.Button
			{
				Location = new Point(10, 300),
				Name = "button2" + counter,
				Size = new Size(200, 41),
				TabIndex = 2,
				Text = "Làm bài thi",
				UseVisualStyleBackColor = true,
				Cursor = System.Windows.Forms.Cursors.Hand,
				Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
				TextAlign = ContentAlignment.MiddleCenter // Đặt văn bản ở giữa theo cả hai chiều
			};

			System.Windows.Forms.Button btnDong = new System.Windows.Forms.Button
			{
				Location = new Point(250, 300),
				Name = "button2" + counter,
				Size = new Size(100, 41),
				TabIndex = 2,
				Text = "Đóng",
				UseVisualStyleBackColor = true,
				Cursor = System.Windows.Forms.Cursors.Hand,
				Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
				TextAlign = ContentAlignment.MiddleCenter // Đặt văn bản ở giữa theo cả hai chiều
			};
			btnDong.Click += (s, ev) =>
			{
				btnDong_Click(s, ev, obj);
			};
			btnLamBai.Click += (s, ev) =>
			{
				btnLamBai_Click(s, ev, obj);
			};
			panelHead.Controls.AddRange(new Control[] { lblThoiGianLamBai, lblMonHoc, lblTenDeThi, lblTrangThai});

			panelContain.Location = new Point(20, flowLayoutPanel1.Controls.Count * 150);
			flowLayoutPanel1.Controls.Add(panelContain);
			panelContain.Controls.AddRange(new Control[] { btnDong, panelHead, btnLamBai });

			flowLayoutPanel1.AutoScroll = true;

			counter++;
		}

		private void btnLamBai_Click(object s, EventArgs ev, DeThiDTO obj)
		{
			Baithi baithi = new Baithi(obj.MaDeThi);
			baithi.ShowDialog();
		}

		private void btnDong_Click(object s, EventArgs ev, DeThiDTO obj)
		{
			dtclBus.DeleteByMaLopAndMaDeThi(lop.MaLop, obj.MaDeThi);
			loadDeThi();
		}

		private void lblTenLop_Click_1(object sender, EventArgs e)
		{
			fThemLop f = new fThemLop(lopHocUserControl, "edit", null, lop);
			f.Visible = true; 
		}
	}
}
