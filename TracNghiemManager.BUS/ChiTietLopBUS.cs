using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;
using TracNghiemManager.DTO;

namespace TracNghiemManager.BUS
{
	public class ChiTietLopBUS
	{
		public ChiTietLopDAO chiTietLopDAO;
		public ChiTietLopBUS()
		{
			chiTietLopDAO = new ChiTietLopDAO();
		}
		public string Add(ChiTietLopDTO t)
		{
			if(chiTietLopDAO.Add(t))
			{
				return "thanh cong";

			}
			return "that bai";
		}
		public List<HocSinhTrongLop> GetAllHSTrongLop(int maLop)
		{
			return chiTietLopDAO.GetAllHSTrongLop(maLop);
		}
	}
}
