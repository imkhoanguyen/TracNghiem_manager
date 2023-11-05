using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiemManager.DTO
{
	public class ChiTietLopDTO
	{
		public int MaLop { get; set; }
		public int UserId { get; set; }
		public int TrangThai { get; set; }
		public ChiTietLopDTO(int maLop, int userId, int trangThai)
		{
			MaLop = maLop;
			UserId = userId;
			TrangThai = trangThai;
		}
	}
}
