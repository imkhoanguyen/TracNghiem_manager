using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiemManager.DTO
{
	public class DeThiDTO
	{
		public int MaDeThi { get; set; }
		public int MaMonHoc { get; set; }
		public string TenDeThi { get; set; }
		public int MaNguoiTao { get; set; }
		public int ThoiGianLamBai { get; set; }
		public int TrangThai { get; set; }
		public DeThiDTO()
		{

		}
		public DeThiDTO(int maDeThi, string tenDeThi, int maMonHoc, int maNuoiTao, int thoiGianLamBai, int trangThai)
		{
			MaDeThi = maDeThi;
			MaMonHoc = maMonHoc;
			TenDeThi = tenDeThi;
			MaNguoiTao = maNuoiTao;
			ThoiGianLamBai = thoiGianLamBai;
			TrangThai = trangThai;
		}
	}
}
