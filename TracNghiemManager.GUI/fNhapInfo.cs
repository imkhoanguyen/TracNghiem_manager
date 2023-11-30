using System;
using MimeKit;
using MailKit.Net.Smtp;
using System.Windows.Forms;
using System.Collections.Generic;
using TracNghiemManager.BUS;
using TracNghiemManager.DTO;

namespace TracNghiemManager.GUI
{
    public partial class fNhapInfo : Form
    {
        public fNhapInfo()
        {
            InitializeComponent();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            UserBUS userBUS = new UserBUS();

            if (string.IsNullOrEmpty(txtEmailorUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmailorUsername.Text = string.Empty;
            }
            else
            {
                string usernameOrEmail = txtEmailorUsername.Text;

                List<UserDTO> users = userBUS.getEmailandAvatar(usernameOrEmail);

                if (users.Count > 0)
                {

                    fGetOTP fget = new fGetOTP();
                    fget.lblEmail.Text = users[0].Email;
                    fget.lblUser.Text = users[0].HoVaTen;
                    fget.pictureUser.ImageLocation = users[0].avatar;
                    fget.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản sai");
                    txtEmailorUsername.Text = string.Empty;
                }
            }
        }

        private void txtEmailorUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnGui.PerformClick();
            }
        }
    }
}
