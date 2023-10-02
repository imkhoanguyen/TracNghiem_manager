using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracNghiem_manager.Properties;
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;

namespace TracNghiem_manager
{
    public partial class Manager : UserControl
    {
        private Panel[] panelUser;
        private PictureBox[] avatarImg;
        private Button[] buttonCT;
        private Button[] buttonDELETE;
        private TextBox[] textBoxDate;
        private TextBox[] textBoxRole;
        private TextBox[] textBoxName;

        public Manager()
        {
            InitializeComponent();
            renderUsers();
        }

        private void renderUsers()
        {
            List<UserDTO> users = UserDAO.instance.GetAll();
            panelUser = new Panel[users.Count];
            buttonCT = new Button[users.Count];
            buttonDELETE = new Button[users.Count];
            textBoxDate = new TextBox[users.Count];
            textBoxRole = new TextBox[users.Count];
            textBoxName = new TextBox[users.Count];
            avatarImg = new PictureBox[users.Count];
            for (int i = 0; i < users.Count; i++)
            {
                panelUser[i] = new Panel();
                panelUser[i].Name = "panelUser" + i;
                panelUser[i].Size = new Size(385, 150);
                panelUser[i].BorderStyle = BorderStyle.FixedSingle;
                // 
                // buttonCT
                // 
                buttonCT[i] = new Button();
                buttonCT[i].Location = new Point(202, 105);
                buttonCT[i].Name = "buttonCT" + i;
                buttonCT[i].Size = new Size(75, 23);
                buttonCT[i].Tag = "" + users[i].Id;
                buttonCT[i].Text = "Chi Tiet";
                buttonCT[i].UseVisualStyleBackColor = true;
                buttonCT[i].MouseClick += Detail_MouseClick;
                // 
                // buttonDELETE
                // 
                buttonDELETE[i] = new Button();
                buttonDELETE[i].Location = new Point(283, 105);
                buttonDELETE[i].Name = "buttonDELETE" + i;
                buttonDELETE[i].Size = new Size(75, 23);
                buttonDELETE[i].Text = "DELETE";
                buttonDELETE[i].Tag = "" + users[i].Id;
                buttonDELETE[i].TextImageRelation = TextImageRelation.ImageBeforeText;
                buttonDELETE[i].UseVisualStyleBackColor = true;
                buttonDELETE[i].MouseClick += Delete_MouseClick;
                // 
                // textBoxDate
                // 
                textBoxDate[i] = new TextBox();
                textBoxDate[i].BackColor = SystemColors.Control;
                textBoxDate[i].Location = new Point(149, 76);
                textBoxDate[i].Name = "textBoxDate" + i;
                textBoxDate[i].Size = new Size(209, 23);
                textBoxDate[i].Text = "" + users[i].ngaySinh;
                // 
                // textBoxRole
                // 
                textBoxRole[i] = new TextBox();
                textBoxRole[i].BackColor = SystemColors.Control;
                textBoxRole[i].Location = new Point(149, 47);
                textBoxRole[i].Name = "textBoxRole" + i;
                textBoxRole[i].Size = new Size(209, 23);
                textBoxRole[i].Text = "Student"; // sua lai cho nay
                // 
                // textBoxName
                // 
                textBoxName[i] = new TextBox();
                textBoxName[i].BackColor = SystemColors.Control;
                textBoxName[i].Location = new Point(149, 18);
                textBoxName[i].Name = "textBoxName" + i;
                textBoxName[i].Size = new Size(209, 23);
                textBoxName[i].Text = users[i].HoVaTen;
                // 
                // avatarImg
                // 
                avatarImg[i] = new PictureBox();
                avatarImg[i].ImageLocation = @"D:\hinh_nen.jpg";
                avatarImg[i].Location = new Point(22, 18);
                avatarImg[i].Name = "avatarImg" + i;
                avatarImg[i].Size = new Size(100, 113);
                avatarImg[i].TabStop = false;


                panelUser[i].Controls.Add(buttonCT[i]);
                panelUser[i].Controls.Add(buttonDELETE[i]);
                panelUser[i].Controls.Add(textBoxDate[i]);
                panelUser[i].Controls.Add(textBoxRole[i]);
                panelUser[i].Controls.Add(textBoxName[i]);
                panelUser[i].Controls.Add(avatarImg[i]);
                flowLayoutContainer.Controls.Add(panelUser[i]);
            }


        }

        private void Delete_MouseClick(object? sender, MouseEventArgs e)
        {
            string message = "Do you want to delete this user?";
            string title = "Delete User";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Button bt = sender as Button;
                if (bt != null)
                {
                    int user_id = Convert.ToInt32(bt.Tag);
                    DeleteUser(user_id);

                    flowLayoutContainer.Controls.Clear();
                    renderUsers();
                }

            }
        }

        private void Detail_MouseClick(object? sender, MouseEventArgs e)
        {
            Button bt = sender as Button;

            if (bt != null)
            {
                MessageBox.Show("" + bt.Tag);
            }
        }

        private void DeleteUser(int id)
        {
            UserDAO.instance.Delete(id);
        }
    }
}
