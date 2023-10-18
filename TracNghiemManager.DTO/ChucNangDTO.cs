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
        public string ten_chuc_nang { set; get; }
        public int trang_thai { set; get; }
        public bool cho_phep { set; get; }

        public ChucNangDTO()
        {
            
        }

        public ChucNangDTO(int maChucNang, int maQuyen, string chucNang, int trangThai)
        {
            ma_chuc_nang = maChucNang;
            ten_chuc_nang = chucNang;
            trang_thai = trangThai;
        }
    }
}
