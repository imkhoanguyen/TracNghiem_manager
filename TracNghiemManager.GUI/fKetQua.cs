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

namespace TracNghiemManager.GUI
{
	public partial class fKetQua : Form
	{
		private DeThiDTO deThi;
		private LopDTO lop;
		private UserBUS userBUS;
		private MonHocBUS monHocBUS;
		private KetQuaDTO ketQua;
		public fKetQua(DeThiDTO dt, LopDTO l, KetQuaDTO kq)
		{
			InitializeComponent();
			userBUS = new UserBUS();
			monHocBUS = new MonHocBUS();
			deThi = dt;
			lop = l;
			ketQua = kq;
			load();

		}

		void load()
		{
			if (ketQua.SoCauDung >= 10)
			{
				lblDung.Location = new Point(74, 118);
			}
			if (ketQua.SoCauSai >= 10)
			{
				lblSai.Location = new Point(78, 118);
			}
			if (ketQua.SoCauChuaChon >= 10)
			{
				lblBoQua.Location = new Point(78, 118);
			}
			if (ketQua.Diem < 10)
			{
				lblDiem.Location = new Point(68, 120);
			}
			lblTTenBaiThi.Text = deThi.TenDeThi;
			lblTenThiSinh.Text = userBUS.getById(Form1.USER_ID).HoVaTen;
			lblTenLop.Text = lop.TenLop;
			lblTenMonHoc.Text = monHocBUS.getById(deThi.MaMonHoc).TenMonHoc;
			lblBoQua.Text = ketQua.SoCauChuaChon.ToString();
			lblDung.Text = ketQua.SoCauDung.ToString();
			lblSai.Text = ketQua.SoCauSai.ToString();
			lblDiem.Text = ketQua.Diem.ToString();

		}

	}
}
