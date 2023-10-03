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
        System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private int counter = 1;
        LopBUS lBus;
        private List<LopDTO> listl;
        public LopHocUserControl()
        {
            InitializeComponent();
            lBus = new LopBUS();
            listl = lBus.GetAll();
            loadLop(listl);
        }

        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void loadLop(List<LopDTO> list)
        {
            listl = list;
            // Xóa tất cả các panel được tạo trước đó
            flowLayoutPanel1.Controls.Clear();
            foreach (var l in listl)
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
        public void UpdateLop(LopDTO obj)
        {
            lBus.Update(obj);
            LopBUS lnew = new LopBUS();
            List<LopDTO> newlist = lnew.GetAll();
            loadLop(newlist);
        }

        public void DeleteLop(int id)
        {
            lBus.Delete(id);
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
                Size = new Size(360, 350),
                TabIndex = 0,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10, 10, 10, 10),
            };

            Panel panelHead = new Panel
            {
                Location = new Point(3, 3),
                Name = "panelHead",
                Size = new Size(360, 290),
                TabIndex = 1,
                BackColor = GetRandomColor()
            };

            Label labelMonhoc = new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(10, 9),
                Name = "labelMonhoc" + counter.ToString(),
                Size = new Size(300, 200),
                TabIndex = 0,

                Text = obj.TenLop,
                AutoEllipsis = true
            };
            toolTip.SetToolTip(labelMonhoc, labelMonhoc.Text);
            labelMonhoc.Click += (s, ev) => { labelMonhoc_Click(s, ev, obj); };

            Label labelHocsinh = new Label
            {
                AutoSize = true,
                Location = new Point(20, 250),
                Name = "labelHocsinh1" + counter,
                Size = new Size(110, 13),
                TabIndex = 1,
                Text = "Học sinh tham gia: ",

            };

            Label labelGiangvien = new Label
            {
                AutoSize = true,
                Location = new Point(20, 220),
                Name = "labelGiangvien" + counter,
                Size = new Size(140, 13),
                TabIndex = 2,
                Text = "Nguyễn Thanh Thiên Tứ"
            };

            System.Windows.Forms.Button buttonThamGia = new System.Windows.Forms.Button
            {
                Location = new Point(60, 300),
                Name = "button2" + counter,
                Size = new Size(100, 40),
                TabIndex = 2,
                Text = "Tham gia",
                UseVisualStyleBackColor = true,
                Cursor = System.Windows.Forms.Cursors.Hand,
            };

            System.Windows.Forms.Button buttonXoa = new System.Windows.Forms.Button
            {
                Location = new Point(200, 300),
                Name = "button3" + counter,
                Size = new Size(100, 40),
                TabIndex = 3,
                Text = "Xóa",
                UseVisualStyleBackColor = true,
                Cursor = System.Windows.Forms.Cursors.Hand,
            };
            buttonXoa.Click += (s, ev) =>
            {
                buttonXoa_Click(s, ev, obj);
            };
            buttonThamGia.Click += (s, ev) =>
            {
                buttonThamGia_Click(s, ev, obj);
            };
            panelHead.Controls.AddRange(new Control[] { labelGiangvien, labelHocsinh, labelMonhoc });
            panelContain.Controls.AddRange(new Control[] { buttonThamGia, buttonXoa, panelHead });

            panelContain.Location = new Point(20, flowLayoutPanel1.Controls.Count * 150);
            flowLayoutPanel1.Controls.Add(panelContain);

            flowLayoutPanel1.AutoScroll = true;

            counter++;
        }

        // Ramdom mau nhat
        private Color GetRandomColor()
        {
            Random random = new Random();
            int r = random.Next(256);
            int g = random.Next(256);
            int b = random.Next(256);

            // Làm cho màu sắc nhạt hơn bằng cách thêm 128 vào mỗi thành phần màu
            r += 128;
            g += 128;
            b += 128;

            // Đảm bảo rằng các thành phần màu không vượt quá 255
            r = r > 255 ? 255 : r;
            g = g > 255 ? 255 : g;
            b = b > 255 ? 255 : b;

            return Color.FromArgb(r, g, b);
        }

        private void labelMonhoc_Click(object sender, EventArgs e, LopDTO obj)
        {
            fThemLop themLop = new fThemLop(this, "edit", GenerateRandomCode(10), obj);
            themLop.Visible = true;
        }
        private void buttonXoa_Click(object sender, EventArgs e, LopDTO obj)
        {
            DeleteLop(obj.MaLop);
            System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;
            Panel panelContain = (Panel)clickedButton.Parent;

            DialogResult result = MessageBox.Show("Xác nhận xóa lớp học?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                flowLayoutPanel1.Controls.Remove(panelContain);
            }

        }
        private void buttonThamGia_Click(object sender, EventArgs e, LopDTO obj)
        {
            //fThemLop themLop = new fThemLop(this, "edit", GenerateRandomCode(10), obj);

            //themLop.Visible = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            fThemLop themLop = new fThemLop(this, "add", GenerateRandomCode(10));

            themLop.Visible = true;

        }
    }
}
