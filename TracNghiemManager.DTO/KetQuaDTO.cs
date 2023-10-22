using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiemManager.DTO
{
    public class KetQuaDTO
    {
        public int MaBaiThi { get; set; }
        public int MaThiSinh { get; set; }
        public int SoCauDung {  get; set; }
        public int SoCauSai { get; set; }
        public int SoCauChuaChon { get; set; }
        public double Diem { get; set; }

        public KetQuaDTO()
        {

        }

        public KetQuaDTO(int maBaiThi, int maThiSinh, int soCauDung, int soCauSai, int soCauChuaChon, double diem )
        {
            MaBaiThi = maBaiThi;
            MaThiSinh = maThiSinh;
            SoCauDung = soCauDung;
            SoCauSai = soCauSai;
            SoCauChuaChon = soCauChuaChon;
            Diem = diem;
        }
    }
}
