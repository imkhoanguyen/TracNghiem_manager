using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiemManager.DTO
{
    public class PhanQuyenDTO
    {
        public int ma_quyen {  get; set; }
        public string ten_quyen { get; set; }
        public int trang_thai { get; set; }

        public PhanQuyenDTO()
        {
            
        }

        public PhanQuyenDTO(int maQuyen, string tenQuyen, int trangThai)
        {
            ma_quyen = maQuyen;
            ten_quyen = tenQuyen;
            trang_thai = trangThai;
        }
    }
}
