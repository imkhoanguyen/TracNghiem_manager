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
        public List<LopDTO> GetAll()
        {
            return lopDAO.GetAll();
        }
        public int GetAutoIncrement()
        {
            return lopDAO.GetAutoIncrement();
        }

        public LopDTO getById(int id)
        {
            return lopDAO.GetById(id);
        }
    }
}
