using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DAO;

namespace TracNghiemManager.BUS
{
	public class ThongKeBUS
	{
		public ThongKeDAO thongKeDAO;
		public ThongKeBUS()
		{
			thongKeDAO = new ThongKeDAO();
		}
		public int GetCountHs()
		{
			return thongKeDAO.getCountHs();
		}

		public int getCountGv()
		{
			return thongKeDAO.getCountGv();
		}

		public int getCountCauHoi()
		{
			return thongKeDAO.getCountCauHoi();
		}
	}
}
