using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiemManager.DTO
{
	public class ChiTietDeThiDTO
	{
		public int MaDeThi { get; set; }
		public int MaCauHoi { get; set; }

		public ChiTietDeThiDTO()
		{

		}
		public ChiTietDeThiDTO(int maDeThi, int maCauHoi)
		{
			MaDeThi = maDeThi;
			MaCauHoi = maCauHoi;
		}
	}
}
