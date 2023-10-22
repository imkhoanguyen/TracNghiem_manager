using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;
using System.Linq;
using GroupBox = System.Windows.Forms.GroupBox;
using System.Drawing.Printing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;

namespace TracNghiem_manager
{
    public partial class Baithi : Form
    {
        private GroupBox[] groupBox;
        private int so_cau_hoi = 50;
        private int currentIndex = 0;
        private Panel[] slide;
        public Baithi()
        {
            InitializeComponent();
            TaoCauHoi(so_cau_hoi);
            tao_slide(so_cau_hoi);
        }

        private string GetTagValue(GroupBox grp)
        {
            string tagValue = string.Empty;
            if (grp != null)
            {
                try
                {
                    foreach (Control ctl in grp.Controls) // Duyệt qua tất cả các control trong groupbox
                    {
                        if (ctl is RadioButton)
                        {
                            RadioButton rbtn = (RadioButton)ctl; // Ép kiểu control thành radiobutton
                            if (rbtn.Checked)
                            {
                                tagValue = rbtn.Tag.ToString();
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                tagValue = "";
            }
            return tagValue;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string dap_an = "C";
            int d = 0;
            for (int i = 0; i < so_cau_hoi; i++)
            {
                if (dap_an.Equals(GetTagValue(groupBox[i])))
                {
                    d++;
                }

            }
            MessageBox.Show("Bạn có muốn tiếp tục không?", "Xác nhận", MessageBoxButtons.OKCancel);
            label14.Text = "" + d;

        }

        private void TaoDapAn(int so_dap_an, GroupBox g)
        {
            RadioButton[] rd = new RadioButton[so_dap_an];
            for (int i = 1; i <= so_dap_an; i++)
            {
                rd[i - 1] = new RadioButton();
                rd[i - 1].AutoSize = true;
                rd[i - 1].Name = "radioButton_" + i + g.Text;
                switch (i)
                {
                    case 1: rd[i - 1].Location = new Point(9, 50); rd[i - 1].Tag = "A"; break;
                    case 2: rd[i - 1].Location = new Point(9, 96); rd[i - 1].Tag = "B"; break;
                    case 3: rd[i - 1].Location = new Point(9, 96 + 46); rd[i - 1].Tag = "C"; break;
                    case 4: rd[i - 1].Location = new Point(9, 96 + 46 + 46); rd[i - 1].Tag = "D"; break;

                }
                rd[i - 1].Size = new Size(14, 13);
                rd[i - 1].TabIndex = 1;
                rd[i - 1].TabStop = false; //khong tu nhay
                rd[i - 1].UseVisualStyleBackColor = true;

                g.Controls.Add(rd[i - 1]);
            }
        }
        private void TaoCauHoi(int n)
        {
            groupBox = new GroupBox[n];
            for (int i = 1; i <= n; i++)
            {
                groupBox[i - 1] = new GroupBox();
                groupBox[i - 1].Name = "groupBox" + i;
                groupBox[i - 1].Location = new Point(5, 5);
                groupBox[i - 1].Margin = new Padding(0, 0, 5, 0);
                groupBox[i - 1].Size = new Size(34, 219);
                groupBox[i - 1].TabIndex = 0;
                groupBox[i - 1].TabStop = false;
                groupBox[i - 1].Text = "" + i;
                groupBox[i - 1].MouseUp += GroupBox_MouseUp;

                if (i % 2 == 0)
                {
                    TaoDapAn(3, groupBox[i - 1]);
                }
                else
                {
                    TaoDapAn(4, groupBox[i - 1]);
                }

                flowLayoutPanel1.Controls.Add(groupBox[i - 1]);
            }
        }


        private void tao_slide(int n)
        {
            slide = new Panel[n];
            for (int i = 1; i <= n; i++)
            {
                slide[i - 1] = new Panel();
                slide[i - 1].Name = "slide" + i;
                slide[i - 1].Size = panel1.Size;
                slide[i - 1].BackColor = Color.BurlyWood;
                Label label = new Label();
                label.Name = "lable_slide" + i;
                label.Text = "Slide" + i;
                label.Font = new Font("Arial", 20);
                label.AutoSize = true;
                label.Location = new Point(100, 100);
                slide[i - 1].Controls.Add(label);
                panel1.Controls.Add(slide[i - 1]);
            }

        }

        private void GroupBox_MouseUp(object sender, MouseEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            string text = groupBox.Text;
            int index = Convert.ToInt32(text);

            currentIndex = index - 1;
            panel1.Controls.Clear();
            panel1.Controls.Add(slide[currentIndex]);
        }

        private void next_slide(int n)
        {
            panel1.Controls.Clear();
            currentIndex++;
            if (currentIndex >= n)
            {
                currentIndex = 0;
            }
            panel1.Controls.Add(slide[currentIndex]);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            next_slide(so_cau_hoi);
        }
        private void prev_slide(int n)
        {
            panel1.Controls.Clear();
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = n - 1;
            }
            panel1.Controls.Add(slide[currentIndex]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            prev_slide(so_cau_hoi);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                prev_slide(so_cau_hoi);
                return true; // Indicate that the key press is handled
            }
            else if (keyData == Keys.Right)
            {
                next_slide(so_cau_hoi);
                return true; // Indicate that the key press is handled
            }
            // Call the base method for other keys
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
