using DocumentFormat.OpenXml.Drawing.Charts;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace TracNghiemManager.GUI
{
	public partial class fNhapOTP : Form
	{
		public string SentOTP { get; set; }
		private Timer cdTime;
		private int remainingTime = 60;

		public fNhapOTP()
		{
			InitializeComponent();
			InitializeTimer();
		}
		private void InitializeTimer()
		{
			cdTime = new Timer(1000);
			cdTime.Elapsed += OnTimerElapsed;
			cdTime.Start();
		}
		private void OnTimerElapsed(object sender, ElapsedEventArgs e)
		{
			lblTime.ForeColor = Color.Black;
			if (!cdTime.Enabled)
				return;

			if (lblTime.IsHandleCreated)
			{
				lblTime.BeginInvoke((MethodInvoker)delegate
				{
					lblTime.Text = remainingTime + "S";
				});
			}

			remainingTime--;

			if (remainingTime <= 10)
			{
				if (lblTime.IsHandleCreated)
				{
					lblTime.BeginInvoke((MethodInvoker)delegate
					{
						lblTime.ForeColor = Color.Red;
					});
				}
			}

			if (remainingTime < 0)
			{
				if (lblTime.IsHandleCreated)
				{
					lblTime.BeginInvoke((MethodInvoker)delegate
					{
						lblTime.Text = "0S";
						SentOTP = null;
						btnGuilaiOTP.Visible = true;
					});
				}
				cdTime.Stop();
			}
		}

		private void btnGuilaiOTP_Click(object sender, EventArgs e)
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
				SentOTP = otp;
				message.Body = new TextPart("html")
				{
					Text = $@"
                    <h1 style='color: #000000;'>Đổi mật khẩu</h1>
                    <p style='font-size: 24px; font-weight: bold; color: #000000;'>Đây là mã OTP của bạn:</p>
                    <div style='background-color: #222222; color: #FFFFFF; padding: 10px;max-width: 130px;'>
                    <div style='font-size: 36px; max-width: 130px; word-wrap: break-word;'>{otp}</div>
                    </div>"
				};

				SmtpClient client = 
					new SmtpClient();
				try
				{
					client.Connect("smtp.gmail.com", 465, true);
					client.Authenticate("nguyenthanhthientu18nt@gmail.com", "anla cbfo uldc aswj");
					client.Send(message);
					MessageBox.Show("Mã đã được gửi thành công đến: " + lblEmail.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					remainingTime = 60;
					InitializeTimer();
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
