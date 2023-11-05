using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;

namespace TracNghiemManager.BUS
{
    public class QuyenBus
    {
        public QuyenDAO QuyenDAO;
        public QuyenBus()
        {
            QuyenDAO = QuyenDAO.instance;
        }
        public List<QuyenDTO> GetAll()
        {
            return QuyenDAO.GetAll();
        }
    }
}
