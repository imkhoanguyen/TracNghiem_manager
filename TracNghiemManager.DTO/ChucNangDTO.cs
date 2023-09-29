using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiemManager.DTO
{
    public class ChucNangDTO
    {
        public int ma_chuc_nang { set; get; }
        public int ma_quyen { set; get; }
        public string ten_chuc_nang { set; get; }
        public int trang_thai { set; get; }

        public ChucNangDTO()
        {
            
        }

        public ChucNangDTO(int maChucNang, int maQuyen, string chucNang, int trangThai)
        {
            ma_chuc_nang = maChucNang;
            ma_quyen = maQuyen;
            ten_chuc_nang = chucNang;
            trang_thai = trangThai;
        }
    }
}
