using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private bool checkPassword(string input)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(input);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            UserBUS userBUS = new UserBUS();

            string newPassword = txtNhapMK.Text.Trim();
            if (string.IsNullOrEmpty(newPassword) && string.IsNullOrEmpty(txtXacNhan.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (newPassword != txtXacNhan.Text.Trim())
            {
                MessageBox.Show("Mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (checkPassword(newPassword))
            {
                userBUS.UpdatePassword(lblEmail.Text, newPassword);
                MessageBox.Show("Mật khẩu đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Mật khẩu phải tối thiểu 6 ký tự gồm Hoa, thường và kí tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNhapMK_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtXacNhan.Focus();
            }
        }

        private void txtXacNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLuu.PerformClick();
            }
        }
    }
}
