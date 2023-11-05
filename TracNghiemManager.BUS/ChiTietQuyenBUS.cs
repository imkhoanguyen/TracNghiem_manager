using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;

namespace TracNghiemManager.BUS
{
    public class ChiTietQuyenBUS
    {
        public ChiTietQuyenDAO chiTietQuyen;

        public ChiTietQuyenBUS()
        {
            chiTietQuyen = new ChiTietQuyenDAO();
        }

        public string Add(ChiTietQuyenDTO t)
        {
            if (chiTietQuyen.Add(t))
            {
                return "Thêm thành công!";
            }
            return "Thêm thất bại!";
        }

		public List<ChiTietQuyenDTO> GetRoleByUserId(int id)
        {
            return chiTietQuyen.GetRoleByUserId(id);
        }

	}
}
