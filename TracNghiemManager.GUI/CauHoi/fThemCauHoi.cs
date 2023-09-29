using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracNghiemManager.BUS;
using TracNghiemManager.DTO;

namespace TracNghiemManager.GUI.CauHoi
{
    public partial class fThemCauHoi : Form
    {
        public List<CauHoiDTO> listch = CauHoiBUS.getAll();
        public fThemCauHoi()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CauHoiDTO c = new CauHoiDTO(txtNoiDung.Text, "Easy", 1, 1, 1);
            listch.Add(c);
            CauHoiBUS.Add(c);
            this.Close();

        }
    }
}
