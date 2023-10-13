using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;

namespace TracNghiemManager.BUS
{
    public class DeThiBUS
    {
        public DeThiDAO deThiDAO;
        public DeThiBUS()
        {
            deThiDAO = DeThiDAO.getInstance();
        }
        public string Add(DeThiDTO t)
        {
            if (deThiDAO.Add(t)) return "Them de thi thanh cong!";
            return "Them de thi that bai";
        }
        public string Update(DeThiDTO t)
        {
            if (deThiDAO.Update(t)) return "Cap nhat de thi thanh cong!";
            return "Cap nhat de thi that bai";
        }
        public string Delete(int id)
        {
            if (deThiDAO.Delete(id)) return "Xoa de thi thanh cong!";
            return "Xoa de thi that bai!";
        }
        public List<DeThiDTO> GetAll()
        {
            return deThiDAO.GetAll();
        }
        public DeThiDTO Get(int id)
        {
            return deThiDAO.GetById(id);
        }
        public int GetAutoIncrement()
        {
            return deThiDAO.GetAutoIncrement();
        }
    }
}
