using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;

namespace TracNghiemManager.BUS
{
    public class MonHocBUS
    {
        public MonHocDAO monHocDAO;
        public MonHocBUS()
        {
            monHocDAO = MonHocDAO.getInstance();
        }
        public List<MonHocDTO> getAll()
        {
            return monHocDAO.GetAll();
        }
        public string Add(MonHocDTO t)
        {
            if (monHocDAO.Add(t))
            {
                return "Thêm môn học thành công!";
            }
            return "Thêm môn học thất bại";
        }
        public string Update(MonHocDTO t)
        {
            if (monHocDAO.Update(t))
            {
                return "Cập nhật môn học thành công!";
            }
            return "Cập nhật môn học thất bại";
        }
        public string Delete(int id)
        {
            if (monHocDAO.Delete(id))
            {
                return "Xóa môn học thành công!";
            }
            return "Xóa môn học thất bại";
        }
        public int GetAutoIncrement()
        {
            return monHocDAO.GetAutoIncrement();
        }
        public MonHocDTO getById(int id)
        {
            return monHocDAO.GetById(id);
        }
    }
}
