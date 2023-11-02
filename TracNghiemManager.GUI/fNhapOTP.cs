using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TracNghiemManager.GUI
{
    public partial class fNhapOTP : Form
    {
        public string SentOTP { get; set; }
        public DateTime OTPCreationTime { get; set; }
        private System.Windows.Forms.Timer countdownTimer;
        private int remainingTimeInSeconds = 60; // Số giây còn lại

        public fNhapOTP()
        {
            InitializeComponent();
        }
        private void btnGuiMa_Click(object sender, EventArgs e)
        {
            // Thêm code để gửi lại mã OTP
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string enteredOTP = txtNhapMa.Text;

            if (string.IsNullOrEmpty(enteredOTP))
            {
                MessageBox.Show("Vui lòng nhập mã OTP", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (SentOTP != null && enteredOTP == SentOTP)
            {
                MessageBox.Show("Xác thực thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fMatKhauMoi f = new fMatKhauMoi();
                f.lblEmail.Text = lblEmail.Text;
                f.Show();
                this.Close();
                return;
            }
            MessageBox.Show("Mã OTP không hợp lệ hoặc đã hết hạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
