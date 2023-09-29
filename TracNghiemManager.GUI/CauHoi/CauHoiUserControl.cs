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
    public partial class CauHoiUserControl : UserControl
    {
        public List<CauHoiDTO> listch = CauHoiBUS.getAll();
        private BindingSource _bindingSource; // Use a private field to store the binding source

        public BindingSource bindingSource
        {
            get { return _bindingSource; }
            set { _bindingSource = value; }
        }
        public List<CauHoiDTO> getList()
        {
            return listch;
        }


        public CauHoiUserControl()
        {

            InitializeComponent();
            loadDataTable(listch);

        }
        public void loadDataTable(List<CauHoiDTO> list)
        {
            this.listch = list;
            dataGridView1.AutoGenerateColumns = false;
            bindingSource = new BindingSource();
            bindingSource.DataSource = listch;
            dataGridView1.DataSource = bindingSource;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

            loadDataTable(listch);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemCauHoi fThem = new fThemCauHoi();
            fThem.Visible = true;
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
           
        }

    }
}
