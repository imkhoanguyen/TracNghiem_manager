using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;

namespace TracNghiemManager.BUS
{
	public class DeThiCuaLopBUS
	{
		DeThiCuaLopDAO deThiCuaLopDAO;
		public DeThiCuaLopBUS()
		{
			deThiCuaLopDAO = DeThiCuaLopDAO.GetInstance();
		}
		public string Add(DeThiCuaLopDTO t)
		{
			if (deThiCuaLopDAO.Add(t))
			{
				return "thanh cong!";
			}
			return "that bai";
		}
		public string Update(DeThiCuaLopDTO t)
		{
			if (deThiCuaLopDAO.Update(t))
			{
				return "thanh cong!";
			}
			return "that bai";
		}
		public string Delete(int id)
		{
			if (deThiCuaLopDAO.Delete(id))
			{
				return "thanh cong!";
			}
			return "that bai!";
		}
		public List<DeThiCuaLopDTO> GetAll(int maLop)
		{
			return deThiCuaLopDAO.GetAll(maLop);
		}
		public int GetAutoIncrement()
		{
			return deThiCuaLopDAO.GetAutoIncrement();
		}

		public bool checkDeThiCoTrongLop(int ma_de_thi, int ma_lop)
		{
			if(deThiCuaLopDAO.CheckDeThiCoTrongLop(ma_de_thi, ma_lop) >= 1)
			{
				return true;
			}
			return false;
		}

		public string DeleteByMaLopAndMaDeThi(int maLop, int maDeThi)
		{
			if(deThiCuaLopDAO.DeleteByMaLopAndMaDeThi(maLop, maDeThi))
			{
				return "thanh cong";
			}
			return "that bai";
		}
		public int slDeThiCoTrongLop(int maLop)
		{
			return deThiCuaLopDAO.slDeThiCoTrongLop(maLop);
		}
	}
}
