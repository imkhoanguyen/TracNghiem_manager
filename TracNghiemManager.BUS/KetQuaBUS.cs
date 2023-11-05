using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;

namespace TracNghiemManager.BUS
{
	public class KetQuaBUS
	{
		KetQuaDAO ketQuaDAO;
		public KetQuaBUS()
		{
			ketQuaDAO = new KetQuaDAO();
		}
		
		public string Add(KetQuaDTO t)
		{
			if(ketQuaDAO.Add(t))
			{
				return "thanh cong";
			}
			return "that bai";
		}

		public KetQuaDTO Get(int maBaiThi, int userId)
		{
			return ketQuaDAO.Get(maBaiThi, userId);
		}
		public string Update(KetQuaDTO t)
		{
			if (ketQuaDAO.Update(t))
			{
				return "thanh cong";
			}
			return "that bai";
		}
	}
}
