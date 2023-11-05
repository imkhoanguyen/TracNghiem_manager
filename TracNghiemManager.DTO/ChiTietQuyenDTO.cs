using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiemManager.DTO
{
    public class ChiTietQuyenDTO
    {
        public int user_id {  get; set; }
        public string ten_quyen { get; set; }
        public string ho_va_ten { get; set; }
        public int trang_thai { get; set; }
        public int ma_quyen { get; set; }

        public ChiTietQuyenDTO()
        {
            
        }

        public ChiTietQuyenDTO(int userId, string tenQuyen, string ho_va_ten)
        {
            user_id = userId;
            ten_quyen = tenQuyen;
            this.ho_va_ten = ho_va_ten;

        }
    }
}
