using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;

namespace TracNghiemManager.BUS
{
    public class CauTraLoiBUS
    {
        public CauTraLoiDAO cauTraLoiDAO;
        public CauTraLoiBUS()
        {
            cauTraLoiDAO = CauTraLoiDAO.getInstance();
        }
        public string Add(CauTraLoiDTO t)
        {
            if (cauTraLoiDAO.Add(t))
            {
                return "Thêm câu trả lời thành công!";
            }
            return "Thêm câu trả lời thất bại!";
        }
        public string Update(CauTraLoiDTO t)
        {
            if (cauTraLoiDAO.Update(t))
            {
                return "Cập nhật câu trả lời thành công!";
            }
            return "Cập nhật câu trả lời thất bại!";
        }

        public int GetAutoIncrement()
        {
            return cauTraLoiDAO.GetAutoIncrement();
        }
        public List<CauTraLoiDTO> getByMaCauHoi(int id)
        {
            return cauTraLoiDAO.getByMaCauHoi(id);
        }
        public string Delete(int id)
        {
            if (cauTraLoiDAO.Delete(id))
            {
                return "Xóa câu trả lời thành công!";
            }
            return "Xóa câu trả lời thất bại!";
        }
    }
}
