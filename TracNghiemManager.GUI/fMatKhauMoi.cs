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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TracNghiemManager.GUI
{
    public partial class fMatKhauMoi : Form
    {

        public fMatKhauMoi()
        {
            InitializeComponent();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            UserBUS userBUS = new UserBUS();

            string newPassword = txtNhapMK.Text;
            if (string.IsNullOrEmpty(newPassword) && string.IsNullOrEmpty(txtXacNhan.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            else
            {
                if (newPassword != txtXacNhan.Text)
                {
                    MessageBox.Show("Mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }
                userBUS.UpdatePassword(lblEmail.Text, newPassword);
            }


            MessageBox.Show("Mật khẩu đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
