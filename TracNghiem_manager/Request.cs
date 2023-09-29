using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TracNghiem_manager
{
    public partial class Request : Form
    {
        public Request()
        {
            InitializeComponent();
        }

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_CLOSE = 0xF060;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt32() & 0xFFF0) == SC_CLOSE)
            {
                // Nếu nút close bị nhấn, không làm gì cả (vô hiệu hóa)
                return;
            }

            base.WndProc(ref m);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
