using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracNghiemManager.BUS;
using TracNghiemManager.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TracNghiemManager.GUI.LopHoc
{
    public partial class LopHocUserControl : UserControl
    {
        private int counter = 1;
        private int index = 0; // vi tri cua mang
        LopBUS lBus;
        private List<LopDTO> listl;
        public LopHocUserControl()
        {
            InitializeComponent();
            lBus = new LopBUS();
            listl = lBus.GetAll();
            loadLop();
        }

        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void loadLop()
        {
            foreach(var l in listl)
            {
                CreatePanel(l);
            }
        }

        public void AddLop(LopDTO obj)
        {
            lBus.Add(obj);
            listl.Add(obj);
            CreatePanel(obj);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (fThemLop themLop = new fThemLop(this, "add", GenerateRandomCode(10)))
            {
                themLop.ShowDialog();
                //if (themLop.DialogResult == DialogResult.OK && !string.IsNullOrEmpty(themLop.EnteredText))
                //{
                //    CreatePanel();
                //}
            }
        }
        private string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghiklmnopqrstuvwxyz0123456789"; // Các ký tự và số có thể sử dụng
            Random random = new Random();
            StringBuilder code = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                // sinh số ngẫu nhiên dựa theo độ dài của mảng ký tự
                int index = random.Next(chars.Length);
                code.Append(chars[index]);
            }

            return code.ToString();
        }

        private void CreatePanel(LopDTO obj)
        {
            Panel panelContain = new Panel
            {
                Location = new Point(3, 3),
                Name = "panelContain" + counter.ToString(),
                Size = new Size(250,300),
                TabIndex = 0,
                BorderStyle = BorderStyle.FixedSingle
            };

            Panel panelHead = new Panel
            {
                Location = new Point(3, 3),
                Name = "panelHead",
                Size = new Size(250,200),
                TabIndex = 1,
                BackColor = GetRandomColor()
            };

            Label labelMonhoc = new Label
            {
                AutoSize = true, // Đặt AutoSize thành true
                Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(10, 9),
                Name = "labelMonhoc" + counter.ToString(),
                MaximumSize = new Size(170, 0), // Đặt MaximumSize nếu bạn muốn giới hạn kích thước theo chiều ngang
                TabIndex = 0,
                Text = obj.TenLop.ToString(),
            };
            labelMonhoc.Click += (s, ev) => { labelMonhoc_Click(s, ev, labelMonhoc); };

            Label labelHocsinh = new Label
            {
                AutoSize = true,
                Location = new Point(20, 140),
                Name = "labelHocsinh" + counter,
                Size = new Size(98, 13),
                TabIndex = 1,
                Text = "Học sinh tham gia: "
            };

            Label labelGiangvien = new Label
            {
                AutoSize = true,
                Location = new Point(20,120),
                Name = "labelGiangvien" + counter,
                Size = new Size(124, 13),
                TabIndex = 2,
                Text = "Nguyễn Thanh Thiên Tứ"
            };

            System.Windows.Forms.Button buttonThem = new System.Windows.Forms.Button
            {
                Location = new Point(15, 250),
                Name = "button2" + counter,
                Size = new Size(100,40),
                TabIndex = 2,
                Text = "Tham gia",
                UseVisualStyleBackColor = true
            };

            System.Windows.Forms.Button buttonXoa = new System.Windows.Forms.Button
            {
                Location = new Point(130, 250),
                Name = "button3" + counter,
                Size = new Size(100,40),
                TabIndex = 3,
                Text = "Xóa",
                UseVisualStyleBackColor = true
            };
            buttonXoa.Click += new EventHandler(buttonXoa_Click);
            buttonThem.Click += new EventHandler(buttonThem_Click);
            panelHead.Controls.AddRange(new Control[] { labelGiangvien, labelHocsinh, labelMonhoc });
            panelContain.Controls.AddRange(new Control[] { buttonThem, buttonXoa, panelHead });

            panelContain.Location = new Point(20, flowLayoutPanel1.Controls.Count * 150);
            flowLayoutPanel1.Controls.Add(panelContain);

            flowLayoutPanel1.AutoScroll = true;

            counter++;
        }

        private Color GetRandomColor()
        {
            Random random = new Random();
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        private void labelMonhoc_Click(object sender, EventArgs e, Label clickedLabel)
        {
            using (fDoiTenLop doiTenLop = new fDoiTenLop())
            {
                doiTenLop.ShowDialog();

                if (doiTenLop.DialogResult == DialogResult.OK && !string.IsNullOrEmpty(doiTenLop.EnteredText))
                {
                    clickedLabel.Text = doiTenLop.EnteredText;
                }
            }
        }
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;
            Panel panelContain = (Panel)clickedButton.Parent;

            DialogResult result = MessageBox.Show("Xác nhận xóa lớp học?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                flowLayoutPanel1.Controls.Remove(panelContain);
            }
            
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            fDeThi fDeThi = new fDeThi();
            fDeThi.Visible = true;
        }
    }
}
