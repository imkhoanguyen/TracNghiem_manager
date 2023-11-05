using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;

namespace TracNghiemManager.BUS
{
    public class LopBUS
    {
        public LopDAO lopDAO;
        public LopBUS()
        {
            lopDAO = LopDAO.getInstance();
        }
        public string Add(LopDTO t)
        {
            if (lopDAO.Add(t)) return "Thêm lớp học thành công!";
            return "Thêm lớp học thất bại!";
        }
        public string Update(LopDTO t)
        {
            if (lopDAO.Update(t)) return "Cập nhật lớp học thành công!";
            return "Cập nhật lớp học thất bại";
        }
        public string Delete(int id)
        {
            if (lopDAO.Delete(id)) return "Xóa lớp học thành công!";
            return "Xóa lớp học thất bại";
        }
        public List<LopDTO> GetAll(int userId)
        {
            return lopDAO.GetAll(userId);
        }

        public int GetAutoIncrement()
        {
            return lopDAO.GetAutoIncrement();
        }

        public LopDTO getById(int id)
        {
            return lopDAO.GetById(id);
        }

        public bool checkMaMoi(string maMoi)
        {
            List<LopDTO> l = lopDAO.GetAll();
            for(int i= 0; i < l.Count; i++)
            {
                if (l[i].MaMoi.Equals(maMoi)) return true;
                
            }
            return false;
        }

        public int GetMaLopByMaMoi(string maMoi)
        {
            return lopDAO.GetMaLopByMaMoi(maMoi);
        }
    }
}
