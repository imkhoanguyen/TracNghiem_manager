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
        public MonHocDAO monHocDAO = MonHocDAO.getInstance();
        public List<MonHocDTO> listMonHoc = MonHocDAO.getInstance().GetAll();
        public MonHocBUS() { }
        public List<MonHocDTO> getAll()
        {
            return listMonHoc;
        }
        public string Add(MonHocDTO t)
        {
            if(monHocDAO.Add(t))
            {
                return "Thêm môn học thành công!";
            }
            return "Thêm môn học thất bại";
        }
        public string Update(MonHocDTO t)
        {
            if(monHocDAO.Update(t))
            {
                return "Cập nhật câu hỏi thành công!";
            }
            return "Cập nhật câu hỏi thất bại";
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
