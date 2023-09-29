using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;

namespace TracNghiemManager.BUS
{
    public class CauHoiBUS
    {
        public static CauHoiDAO cauHoiDAO = CauHoiDAO.getInstance();
        public static List<CauHoiDTO> listCauHoi = CauHoiDAO.getInstance().GetAll();

        public CauHoiBUS()
        {
           
        }

        public static List<CauHoiDTO> getAll()
        {
            
            return listCauHoi;
        }

        public static string Add(CauHoiDTO t)
        {
            int x = 0;
            if (cauHoiDAO.Add(t))
            {
                x = 1;
            return "1";
            }
            Console.WriteLine(x);
    
            return "0";

        }
    }
}
