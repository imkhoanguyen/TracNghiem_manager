
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace TracNghiemManager.GUI
{
    public partial class fGetOTP : Form
    {
        private string sentOTP;
        private DateTime otpCreationTime;
        public fGetOTP()
        {
            InitializeComponent();
        }

		private void btnXacNhan_Click(object sender, EventArgs e)
		{
			MimeMessage message = new MimeMessage();
			message.From.Add(new MailboxAddress("Manager", "nguyenthanhthientu18nt@gmail.com"));
			if (string.IsNullOrEmpty(lblEmail.Text))
			{
				MessageBox.Show("Chưa có Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				message.To.Add(MailboxAddress.Parse(lblEmail.Text));
				message.Subject = "Đổi mật khẩu!";
				string otp = GenerateOTP();
				sentOTP = otp;
				otpCreationTime = DateTime.Now;
				message.Body = new TextPart("html")
				{
					Text = $@"
                    <h1 style='color: #000000;'>Đổi mật khẩu</h1>
                    <p style='font-size: 24px; font-weight: bold; color: #000000;'>Đây là mã OTP của bạn:</p>
                    <div style='background-color: #222222; color: #FFFFFF; padding: 10px;max-width: 130px;'>
                    <div style='font-size: 36px; max-width: 130px; word-wrap: break-word;'>{otp}</div>
                    </div>"
				};

				SmtpClient client = new SmtpClient();
				try
				{
					client.Connect("smtp.gmail.com", 465, true);
					client.Authenticate("nguyenthanhthientu18nt@gmail.com", "anla cbfo uldc aswj");
					client.Send(message);
					MessageBox.Show("Mã đã được gửi thành công đến: " + lblEmail.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					fNhapOTP f = new fNhapOTP();
					f.lblEmail.Text = lblEmail.Text;
					f.SentOTP = sentOTP;
					f.Show();

					this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					client.Disconnect(true);
					client.Dispose();
				}
			}
		}
		private string GenerateOTP()
		{
			Random random = new Random();
			string otp = random.Next(100000, 999999).ToString();
			return otp;
		}

        private void fGetOTP_KeyDown(object sender, KeyEventArgs e)
        {
			if(e.KeyCode == Keys.Enter) {
                btnXacNhan.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;

            }
        }
    }
}
