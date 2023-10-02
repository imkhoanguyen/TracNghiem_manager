using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;

namespace TracNghiemManager.BUS
{
    public class CauHoiBUS
    {
        public CauHoiDAO cauHoiDAO;
        public CauHoiBUS()
        {
            cauHoiDAO = CauHoiDAO.getInstance();
        }
        public List<CauHoiDTO> getAll()
        {

            return cauHoiDAO.GetAll();
        }

        public string Add(CauHoiDTO t)
        {
            if (cauHoiDAO.Add(t))
            {
                return "Thêm câu hỏi thành công!";
            }
            return "Thêm câu hỏi thất bại!";
        }

        public string Update(CauHoiDTO t)
        {
            if (cauHoiDAO.Update(t)) { return "Cập nhật câu hỏi thành công!"; }
            return "Cập nhật câu hỏi thất bại!";
        }
        public string Delete(int id)
        {
            if (cauHoiDAO.Delete(id))
            {
                return "Xõa câu hỏi thành công";
            }
            return "Xóa câu hỏi thất bại";
        }
        public int GetAutoIncrement()
        {
            return cauHoiDAO.GetAutoIncrement();
        }
        public CauHoiDTO getById(int id)
        {
            return cauHoiDAO.GetById(id);
        }
    }
}
