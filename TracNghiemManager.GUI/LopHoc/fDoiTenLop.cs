using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TracNghiemManager.GUI.LopHoc
{
    public partial class fDoiTenLop : Form
    {
        public fDoiTenLop()
        {
            InitializeComponent();
        }
        public string EnteredText { get; private set; } 
        private void btnDoiTen_Click(object sender, EventArgs e)
        {
            
            EnteredText = txtTenlop.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
