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
	}
}
