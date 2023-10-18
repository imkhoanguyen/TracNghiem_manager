using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;

namespace TracNghiemManager.BUS
{
	public class ChucNangBUS
	{
		public ChucNangDAO chucNangDAO;
		public ChucNangBUS()
		{
			chucNangDAO = ChucNangDAO.Instance;
		}
		public List<ChucNangDTO> GetTenChucNangBangUserId(int userID)
		{
			return chucNangDAO.GetTenChucNangBangUserId(userID);
		}
	}
}
