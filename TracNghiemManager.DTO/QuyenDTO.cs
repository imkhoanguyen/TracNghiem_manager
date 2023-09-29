using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiemManager.DTO
{
    public class QuyenDTO
    {
        public int ma_quyen { set; get; }
        public string ten_quyen { set; get; }
        public int trang_thai { set; get; }

        public QuyenDTO()
        {
            
        }

        public QuyenDTO(int ma, string ten, int tt)
        {
            ma_quyen = ma;
            ten_quyen = ten;
            trang_thai = tt;
        }
    }
}
