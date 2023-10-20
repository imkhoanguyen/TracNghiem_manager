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
using TracNghiemManager.DTO;
using TracNghiemManager.BUS;

namespace TracNghiemManager.GUI
{
	public partial class Baithi : Form
	{
		private GroupBox[] groupBox;
		private int currentIndex = 0;
		private Panel[] slide;
		private ChiTietDeThiBUS chiTietDeThi = new ChiTietDeThiBUS();
		private CauTraLoiBUS cauTraLoi = new CauTraLoiBUS();
		private CauHoiBUS cauHoi = new CauHoiBUS();
		private int so_cau_hoi;
		public Baithi(int maDeThi)
		{
			List<CauHoiDTO> dsCauHoi = chiTietDeThi.GetAllCauHoiOfDeThi(maDeThi);
			so_cau_hoi = dsCauHoi.Count;
			InitializeComponent();
			TaoCauHoi(so_cau_hoi);
			tao_slide(so_cau_hoi);
		}

		private bool GetTagValue(GroupBox grp)
		{
			bool isAnswer = false;
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
								if (rbtn.Tag.ToString() == "true")
								{
									isAnswer = true;
									break;
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					throw;
				}
			}
			else
			{
				isAnswer = false;
			}
			return isAnswer;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			int d = 0;
			for (int i = 0; i < so_cau_hoi; i++)
			{
				if (GetTagValue(groupBox[i]))
				{
					d++;
				}

			}
			MessageBox.Show("Bạn có muốn tiếp tục không?", "Xác nhận", MessageBoxButtons.OKCancel);
			label14.Text = "" + d;

		}

		private void TaoDapAn(GroupBox g, int ma_cau_hoi)
		{
			List<CauTraLoiDTO> cauTraLoiList = cauTraLoi.getByMaCauHoi(ma_cau_hoi);
			int so_dap_an = cauTraLoiList.Count;
			RadioButton[] rd = new RadioButton[so_dap_an];
			for (int i = 1; i <= so_dap_an; i++)
			{
				rd[i - 1] = new RadioButton();
				rd[i - 1].AutoSize = true;
				rd[i - 1].Name = "radioButton_" + i + g.Text;
				switch (i)
				{
					case 1: rd[i - 1].Location = new Point(9, 50); if (cauTraLoiList[i - 1].DapAn == true) { rd[i - 1].Tag = "true"; } else { rd[i - 1].Tag = "false"; } break;
					case 2: rd[i - 1].Location = new Point(9, 96); if (cauTraLoiList[i - 1].DapAn == true) { rd[i - 1].Tag = "true"; } else { rd[i - 1].Tag = "false"; } break;
					case 3: rd[i - 1].Location = new Point(9, 96 + 46); if (cauTraLoiList[i - 1].DapAn == true) { rd[i - 1].Tag = "true"; } else { rd[i - 1].Tag = "false"; } break;
					case 4: rd[i - 1].Location = new Point(9, 96 + 46 + 46); if (cauTraLoiList[i - 1].DapAn == true) { rd[i - 1].Tag = "true"; } else { rd[i - 1].Tag = "false"; } break;

				}
				rd[i - 1].Size = new Size(14, 13);
				rd[i - 1].TabIndex = 1;
				rd[i - 1].TabStop = false;
				rd[i - 1].UseVisualStyleBackColor = true;

				g.Controls.Add(rd[i - 1]);
			}
		}
		private void TaoCauHoi(int n)
		{
			List<CauHoiDTO> cauHoiList = cauHoi.getAll();
			groupBox = new GroupBox[n];
			for (int i = 1; i <= n; i++)
			{
				List<CauTraLoiDTO> cauTraLoiList = cauTraLoi.getByMaCauHoi(cauHoiList[i - 1].MaCauHoi);
				groupBox[i - 1] = new GroupBox();
				groupBox[i - 1].Name = "groupBox" + i;
				groupBox[i - 1].Location = new Point(5, 5);
				groupBox[i - 1].Margin = new Padding(0, 0, 5, 0);
				groupBox[i - 1].Size = new Size(34, 219);
				groupBox[i - 1].TabIndex = 0;
				groupBox[i - 1].TabStop = false;
				groupBox[i - 1].Text = "" + i;
				groupBox[i - 1].MouseUp += GroupBox_MouseUp;

				TaoDapAn(groupBox[i - 1], cauHoiList[i - 1].MaCauHoi);

				flowLayoutPanel1.Controls.Add(groupBox[i - 1]);
			}
		}


		private void tao_slide(int n)
		{
			List<CauHoiDTO> cauHoiList = cauHoi.getAll();
			slide = new Panel[n];
			for (int i = 1; i <= n; i++)
			{
				List<CauTraLoiDTO> cauTraLoiList = cauTraLoi.getByMaCauHoi(cauHoiList[i - 1].MaCauHoi);
				slide[i - 1] = new Panel();
				slide[i - 1].Name = "slide" + i;
				slide[i - 1].Size = panel1.Size;
				slide[i - 1].BackColor = Color.BurlyWood;
				string cauhoi = "" + cauHoiList[i - 1].NoiDung;
				string cautraloi = "";

				RichTextBox richTextBox1 = new RichTextBox();

				richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
				richTextBox1.Location = new System.Drawing.Point(0, 0);
				richTextBox1.Name = "richTextBox" + i;
				richTextBox1.Size = new System.Drawing.Size(725, 273);
				richTextBox1.TabIndex = 0;

				for (int j = 0; j < cauTraLoiList.Count; j++)
				{
					cautraloi += (j + 1) + "." + cauTraLoiList[j].NoiDung + "\n";
				}

				richTextBox1.Enabled = false;
				richTextBox1.Text = cauhoi + "\n" + cautraloi;

				slide[i - 1].Controls.Add(richTextBox1);
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
