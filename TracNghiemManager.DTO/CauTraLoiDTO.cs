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
        public string DoKho { get; set; }
        public int TrangThai { get; set; }
        public CauTraLoiDTO()
        {

        }
        public CauTraLoiDTO(int maCauTraLoi, int maCauHoi, string noiDung, bool dapAn, string doKho, int trangThai)
        {
            MaCauTraLoi = maCauTraLoi;
            MaCauHoi = maCauHoi;
            NoiDung = noiDung;
            DapAn = dapAn;
            DoKho = doKho;
            TrangThai = trangThai;
        }
    }
}
