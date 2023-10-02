using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiemManager.DTO
{
    public class LopDTO
    {
        public int MaLop { get; set; }
        public int MaGiaoVien { get; set; }
        public string TenLop { get; set; }
        public string MaMoi { get; set; }
        public int TrangThai { get; set; }
        public LopDTO()
        {

        }
        public LopDTO(int maLop, int maGiaoVien, string tenLop, string maMoi, int trangThai)
        {
            MaLop = maLop;
            MaGiaoVien = maGiaoVien;
            TenLop = tenLop;
            MaMoi = maMoi;
            TrangThai = trangThai;
        }

    }
}
