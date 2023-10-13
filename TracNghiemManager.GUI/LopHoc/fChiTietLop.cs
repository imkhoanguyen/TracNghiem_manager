using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracNghiemManager.DTO;

namespace TracNghiemManager.GUI.LopHoc
{
    public partial class fChiTietLop : Form
    {
        LopDTO lop;
        public fChiTietLop(LopDTO obj)
        {
            InitializeComponent();
            lop = obj;
            loadCTLop();
        }

        public void loadCTLop()
        {
            lblMaMoi.Text = lop.MaMoi;
            lblTenLop.Text = lop.TenLop;
        }
    }
}
