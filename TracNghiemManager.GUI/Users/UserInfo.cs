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

namespace TracNghiemManager.GUI.Users
{
    public partial class UserInfo : Form
    {
        UserBUS userBUS;
        public UserInfo()
        {
            InitializeComponent();
            userBUS = new UserBUS();
            RenderUser();
        }

        private void buttonUpImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdImages = new OpenFileDialog();
            ofdImages.Filter = "Ảnh (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
            if (ofdImages.ShowDialog() == DialogResult.OK)
            {
                string filepath = ofdImages.FileName;

                pictureBox1.Image = Image.FromFile(filepath);
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

                string imagePath = filepath;

                MessageBox.Show(imagePath);

                // Resources.Add("ImagePath", filepath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime s = dateTimePicker1.Value;
            string gender = "";
            if (rbNam.Checked) gender = rbNam.Tag.ToString();
            if (RbNu.Checked) gender = RbNu.Tag.ToString();

            MessageBox.Show(s + " " + gender);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void RenderUser()
        {
            UserDTO user = userBUS.GetById(Form1.USER_ID);
            pictureBox1.ImageLocation = @"" + user.avatar;

            textBoxName.Text = user.HoVaTen;

            textBoxEmail.Text = user.Email;

            if(user.ngaySinh == null)
            {
                dateTimePicker1.Value = user.ngaySinh;
            }    

            if(user.gioiTinh != null)
            {
                if (user.gioiTinh == 1)
                {
                    rbNam.Checked = true;
                }
                if (user.gioiTinh == 0)
                {
                    RbNu.Checked = true;
                }
            }    
        }
    }
}
