using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiemManager.DTO
{
    public class CauTraLoiDTO
    {
        public int MaCauTraLoi { get; set; }
        public int MaCauHoi { get; set; }
        public string NoiDung { get; set; }
        public bool DapAn { get; set; }
        public int TrangThai { get; set; }
        public CauTraLoiDTO()
        {

        }
        public CauTraLoiDTO(int maCauTraLoi, int maCauHoi, string noiDung, bool dapAn, int trangThai)
        {
            MaCauTraLoi = maCauTraLoi;
            MaCauHoi = maCauHoi;
            NoiDung = noiDung;
            DapAn = dapAn;
            TrangThai = trangThai;
        }
    }
}
