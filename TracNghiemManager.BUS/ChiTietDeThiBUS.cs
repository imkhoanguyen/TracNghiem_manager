using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;

namespace TracNghiemManager.BUS
{
	public class ChiTietDeThiBUS
	{
		public ChiTietDeThiDAO chiTietDeThiDAO;
		public ChiTietDeThiBUS()
		{
			chiTietDeThiDAO = ChiTietDeThiDAO.getInstance();
		}
		public string Add(ChiTietDeThiDTO obj)
		{
			if (chiTietDeThiDAO.Add(obj))
			{
				return "thanh cong";
			}
			return "that bai";
		}
		public string Update(ChiTietDeThiDTO obj)
		{
			if(chiTietDeThiDAO.Update(obj))
			{
				return "thanh cong";
			}
			return "that bai";
		}
		public string Delete(int maDeThi, int maCauHoi)
		{
			if(chiTietDeThiDAO.Delete(maDeThi,maCauHoi))
			{
				return "thanh cong";
			}
			return "that bai";
		}
		public string Delete(int id)
		{
			if(chiTietDeThiDAO.Delete(id))
			{
				return "thanh cong";
			}
			return "that bai";
		}
		public List<ChiTietDeThiDTO> GetAll()
		{
			return chiTietDeThiDAO.GetAll();
		}
		public List<CauHoiDTO> GetAllCauHoiOfDeThi(int maDeThi)
		{
			return chiTietDeThiDAO.GetAllCauHoiOfDeThi(maDeThi);
		}
	}
}
