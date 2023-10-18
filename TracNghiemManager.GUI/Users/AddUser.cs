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
    public partial class AddUser : Form
    {
        private List<QuyenDTO> getItemsClicked;
        UserBUS userBUS = new UserBUS();
        QuyenBus qBus;
        ChiTietQuyenBUS chiTietQuyenBUS = new ChiTietQuyenBUS();
        public AddUser()
        {
            InitializeComponent();
            qBus = new QuyenBus();

            //render checkedlistbox
            List<QuyenDTO> listQuyen = qBus.GetAll();
            for(int i = 0; i < listQuyen.Count; i++)
            {
                checkedListBox1.Items.Add(listQuyen[i].ma_quyen + "_" + listQuyen[i].ten_quyen);
            }
        }

        private bool validateForm()
        {
            if(txtUsername.Text.Trim().Length <= 0)
            {
                MessageBox.Show("username!");
                return false;
            }
            else if (!userBUS.isExistUsername(txtUsername.Text.Trim()))
            {
                MessageBox.Show("username was exist!");
                return false;
            }
            else if (txtPassword.Text.Trim().Length <= 0)
            {
                MessageBox.Show("password!");
                return false;
            }
            else if (checkedListBox1.CheckedItems.Count <= 0) 
            {
                MessageBox.Show("chua chon quyen!");
                return false;
            }
            return true;
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                DateTime ngayTao = DateTime.Now;

                UserDTO user = new UserDTO();
                user.UserName = username;
                user.Password = password;
                user.ngayTao = ngayTao;

                string s = userBUS.Add(user);
                int user_id = userBUS.getNewId();
                MessageBox.Show(s);

                //them quyen 
                foreach (string item in checkedListBox1.CheckedItems)
                {
                    string ma_quyen = item.Substring(0, item.IndexOf("_"));
                    ChiTietQuyenDTO chiTietQuyen = new ChiTietQuyenDTO();
                    chiTietQuyen.ma_quyen = Convert.ToInt32(ma_quyen);
                    chiTietQuyen.user_id = user_id;

                    chiTietQuyenBUS.Add(chiTietQuyen);
                }
                clear();
            }
        }

        private void clear()
        {
            this.Dispose();   
        }
    }
}
