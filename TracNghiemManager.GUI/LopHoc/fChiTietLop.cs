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
		KetQuaBUS ketQuaBus;
		UserBUS userBUS;
		private ChiTietQuyenBUS chiTietQuyenBus;
		private List<ChiTietQuyenDTO> userRoles;
		private ChiTietDeThiBUS chiTietDeThiBus;
		private string tenQuyen;
		public fChiTietLop(LopHocUserControl lhuc, LopDTO obj)
		{
			InitializeComponent();
			dtclBus = new DeThiCuaLopBUS();
			dtBus = new DeThiBUS();
			mhBus = new MonHocBUS();
			ketQuaBus = new KetQuaBUS();
			userBUS = new UserBUS();
			chiTietQuyenBus = new ChiTietQuyenBUS();
			chiTietDeThiBus = new ChiTietDeThiBUS();
			lop = obj;
			lopHocUserControl = lhuc;
			userRoles = chiTietQuyenBus.GetRoleByUserId(Form1.USER_ID);
			for (int i = 0; i < userRoles.Count; i++)
			{
				tenQuyen += userRoles[i].ten_quyen;
			}
			if (tenQuyen.Equals("Học sinh"))
			{
				btnThem.Visible = false;
				lblTenLop.Image = null;
			}
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
			lblTenGV.Text = userBUS.getById(lop.MaGiaoVien).HoVaTen;
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			fDanhSachDeThi f = new fDanhSachDeThi(lop, this);
			f.ShowDialog();
		}

		private void lblTenLop_Click(object sender, EventArgs e)
		{
			fThemLop f = new fThemLop(lopHocUserControl, "edit", lop.MaMoi, lop);
			f.ShowDialog();
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

			if (r == 134 && r == 142 && r == 150)
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

			};

			Panel panelHead = new Panel
			{
				Location = new Point(0, 0),
				Name = "panelHead",
				Size = new Size(390, 290),
				TabIndex = 1,

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
				Font = new Font("Segoe UI", 10, FontStyle.Regular)

			};

			TimeSpan khoangThoiGian = baiThi.ThoiGianKetThuc - DateTime.Now;
			string thoiGianText = "";

			if (khoangThoiGian.Days > 0)
			{
				thoiGianText = $"Còn {khoangThoiGian.Days} ngày";
			}
			else if (khoangThoiGian.Hours > 0)
			{
				thoiGianText = $"Còn {khoangThoiGian.Hours} giờ {khoangThoiGian.Minutes} phút";
			}
			else if (khoangThoiGian.Minutes > 0)
			{
				thoiGianText = $"Còn {khoangThoiGian.Minutes} phút";
			}
			else
			{
				thoiGianText = "Hết hạn";
				baiThi.TrangThai = 0;
			}
			lblTrangThai.Text = baiThi.TrangThai == 1 ? $"Trạng thái: Đang mở ({thoiGianText})" : "Trạng thái: Đã đóng";
			KetQuaDTO kq = ketQuaBus.Get(baiThi.MaBaiThi, Form1.USER_ID);

			System.Windows.Forms.Button btnLamBai = new System.Windows.Forms.Button
			{
				Location = new Point(10, 300),
				Name = "button2" + counter,
				Size = new Size(120, 41),
				TabIndex = 2,
				Text = "Làm bài thi",
				UseVisualStyleBackColor = true,
				Cursor = System.Windows.Forms.Cursors.Hand,
				Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
				TextAlign = ContentAlignment.MiddleCenter, // Đặt văn bản ở giữa theo cả hai chiều
				Enabled = baiThi.TrangThai == 0 ? false : true,
			};

			List<ChiTietQuyenDTO> userRoles = chiTietQuyenBus.GetRoleByUserId(Form1.USER_ID);
			string tenQuyen = "";
			for (int i = 0; i < userRoles.Count; i++)
			{
				tenQuyen += userRoles[i].ten_quyen;
			}

			System.Windows.Forms.Button btnXemKq = new System.Windows.Forms.Button
			{
				Location = new Point(145, 300),
				Name = "button2" + counter,
				Size = new Size(120, 41),
				TabIndex = 2,
				Text = "Kết quả",
				UseVisualStyleBackColor = true,
				Cursor = System.Windows.Forms.Cursors.Hand,
				Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
				TextAlign = ContentAlignment.MiddleCenter, // Đặt văn bản ở giữa theo cả hai chiều
				Visible = tenQuyen.Contains("Học sinh") || tenQuyen.Contains("Full") || tenQuyen.Contains("Giáo viên") ? true : false,
			};

			System.Windows.Forms.Button btnDong = new System.Windows.Forms.Button
			{
				Location = new Point(280, 300),
				Name = "button2" + counter,
				Size = new Size(100, 41),
				TabIndex = 2,
				Text = "Đóng",
				UseVisualStyleBackColor = true,
				Cursor = System.Windows.Forms.Cursors.Hand,
				Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
				TextAlign = ContentAlignment.MiddleCenter // Đặt văn bản ở giữa theo cả hai chiều
			};
			btnXemKq.Click += (s, ev) =>
			{
				btnXemKq_Click(s, ev, obj, baiThi);
			};
			btnDong.Click += (s, ev) =>
			{
				btnDong_Click(s, ev, obj, baiThi);
			};
			btnLamBai.Click += (s, ev) =>
			{
				btnLamBai_Click(s, ev, obj, baiThi, lop);
			};
			panelHead.Controls.AddRange(new Control[] { lblThoiGianLamBai, lblMonHoc, lblTenDeThi, lblTrangThai });

			panelContain.Location = new Point(20, flowLayoutPanel1.Controls.Count * 150);
			flowLayoutPanel1.Controls.Add(panelContain);
			panelContain.Controls.AddRange(new Control[] { btnDong, panelHead, btnLamBai, btnXemKq });

			flowLayoutPanel1.AutoScroll = true;

			counter++;
			if (tenQuyen.Equals("Học sinh"))
			{
				btnDong.Visible = false;
				btnXemKq.Location = new Point(260, 300);
			}
			if (kq != null && tenQuyen.Equals("Học sinh"))
			{
				btnLamBai.Enabled = false;
			}
			if (baiThi.TrangThai == 0 && !tenQuyen.Equals("Học sinh"))
			{
				btnLamBai.Text = "Mở để thi";
				btnLamBai.Enabled = true;
				btnDong.Enabled = false;
			}
			panelHead.BackColor = baiThi.TrangThai == 1 ? GetRandomColor() : Color.FromArgb(134, 142, 150);
			panelHead.Enabled = baiThi.TrangThai == 0 ? false : true;
		}

		private void btnXemKq_Click(object s, EventArgs ev, DeThiDTO obj, DeThiCuaLopDTO bt)
		{
			//xemkq
			KetQuaDTO kq = ketQuaBus.Get(bt.MaBaiThi, Form1.USER_ID);
			if (kq != null)
			{
				fKetQua f = new fKetQua(obj, lop, kq);
				f.ShowDialog();
			}
			else
			{
				MessageBox.Show("Bạn chưa làm bài thi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void btnLamBai_Click(object s, EventArgs ev, DeThiDTO obj, DeThiCuaLopDTO baiThi, LopDTO lop)
		{
			// thực hiện chức năng mở đề thi khi de thi dang dong
			if (baiThi.TrangThai == 0)
			{
				fThemDeThiCuaLop f = new fThemDeThiCuaLop(obj, lop, this, baiThi, "edit");
				f.ShowDialog();
			}
			else // thực hiện chức năng làm bài
			{
				List<CauHoiDTO> l = chiTietDeThiBus.GetAllCauHoiOfDeThi(baiThi.MaDeThi);
				// check xem trong đề thi có câu hỏi không
				if (l.Count > 0)
				{
					TimeSpan khoangThoiGian = baiThi.ThoiGianKetThuc - DateTime.Now;

					// check xem đề thi có đang trong thời gian làm bài không
					if (khoangThoiGian <= TimeSpan.Zero)
					{
						dtclBus.DeleteByMaLopAndMaDeThi(lop.MaLop, obj.MaDeThi);
						MessageBox.Show("Đã quá hạn làm bài thi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						loadDeThi();
					}
					else
					{
						KetQuaDTO kq = ketQuaBus.Get(baiThi.MaBaiThi, Form1.USER_ID);
						// Check xem người dùng đã làm bài thi này chưa (chỉ check trong trường hợp người dùng là học sinh)
						if (kq != null && tenQuyen.Equals("Học sinh"))
						{
							MessageBox.Show("Bạn đã làm bài thi này rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							Baithi baithi = new Baithi(obj, baiThi, lop, this);
							baithi.ShowDialog();
						}

					}
				}
				else
				{
					MessageBox.Show("Không thể làm bài (Giáo viên chưa thêm câu hỏi vào đề)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void btnDong_Click(object s, EventArgs ev, DeThiDTO obj, DeThiCuaLopDTO bt)
		{
			//donng
			dtclBus.DeleteByMaLopAndMaDeThi(lop.MaLop, obj.MaDeThi);
			loadDeThi();
		}

		private void lblTenLop_Click_1(object sender, EventArgs e)
		{
			if (!tenQuyen.Equals("Học sinh"))
			{
				fThemLop f = new fThemLop(lopHocUserControl, "edit", null, lop);
				f.ShowDialog();
			}

		}

		private void btnXemDSSV_Click(object sender, EventArgs e)
		{
			fDanhSachSV fdsv = new fDanhSachSV(lop);
			fdsv.ShowDialog();
		}

		private void lblMaMoi_Click(object sender, EventArgs e)
		{
			Label clickedLabel = (Label)sender;
			string labelText = clickedLabel.Text;

			// Sao chép nội dung của Label vào Clipboard
			Clipboard.SetText(labelText);
			MessageBox.Show("Đã sao chép: " + labelText);
		}
	}
}
