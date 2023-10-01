using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiemManager.DTO
{
    public class CauHoiDTO
    {
        public int MaCauHoi { get; set; }
        public string NoiDung { get; set; }
        public int MaMonHoc { get; set; }
        public int MaNguoiTao { get; set; }
        public string DoKho {  get; set; }
        public int TrangThai { get; set; }
        public CauHoiDTO()
        {

        }
        public CauHoiDTO(int maCauHoi, string noiDung, string doKho, int maMonHoc, int maNguoiTao, int trangThai)
        {
            MaCauHoi = maCauHoi;
            NoiDung = noiDung;
            DoKho = doKho;
            MaMonHoc = maMonHoc;
            MaNguoiTao = maNguoiTao;
            TrangThai = trangThai;
        }
    }
}
