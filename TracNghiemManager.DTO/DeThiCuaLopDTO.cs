using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiemManager.DTO
{
	public class DeThiCuaLopDTO
	{
		public int MaBaiThi { get; set; }
		public int MaDeThi { get; set; }
		public int MaLop { get; set; }
		public DateTime ThoiGianBatDau { get; set; }
		public DateTime ThoiGianKetThuc { get; set; }
		public int TrangThai { get; set; }
		public DeThiCuaLopDTO()
		{

		}
		public DeThiCuaLopDTO(int maBaiThi, int maDeThi, int maLop, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, int trangThai)
		{
			MaBaiThi = maBaiThi;
			MaDeThi = maDeThi;
			MaLop = maLop;
			ThoiGianBatDau = thoiGianBatDau;
			ThoiGianKetThuc = thoiGianKetThuc;
			TrangThai = trangThai;
		}
	}
}
