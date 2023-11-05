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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TracNghiemManager.GUI.LopHoc
{
    public partial class fThemLop : Form
    {
        private LopHocUserControl lopHocUserControl;
        private string hanhDong;
        LopDTO objUpdate;
        private string maMoi;
        LopBUS lBus;
        private ChiTietLopBUS chiTietLopBUS;
        public fThemLop(LopHocUserControl lh, string hd, string mm = null, LopDTO lop = null)
        {
            InitializeComponent();
            lBus = new LopBUS();
            chiTietLopBUS = new ChiTietLopBUS();
            lopHocUserControl = lh;
            hanhDong = hd;
            maMoi = mm;
            if (hanhDong.Equals("edit"))
            {
                objUpdate = lop;
                txtTenlop.Text = objUpdate.TenLop;
                this.Text = "Cập nhật lớp học";
                label2.Text = "Cập nhật lớp học";
            }
            if(hanhDong.Equals("join"))
            {
                this.Text = "Mã mời";
                label2.Text = "Nhập mã mời để vào lớp";
                label2.Location = new Point(50, 15);
                label1.Text = "Nhập mã mời";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hanhDong.Equals("add"))
            {
                try
                {
                    if (checkValidInput())
                    {
                        LopDTO l = new LopDTO(lBus.GetAutoIncrement(), Form1.USER_ID, txtTenlop.Text, maMoi, 1);
                        lopHocUserControl.AddLop(l);
                        ChiTietLopDTO ctl = new ChiTietLopDTO(l.MaLop,Form1.USER_ID,1);
                        chiTietLopBUS.Add(ctl);
                        this.Close();
                        this.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (hanhDong.Equals("edit"))
            {
                if (checkValidInput())
                {
                    try
                    {
                        LopDTO l = new LopDTO(objUpdate.MaLop, Form1.USER_ID, txtTenlop.Text, maMoi, 1);
                        lopHocUserControl.UpdateLop(l);
                        this.Close();
                        MessageBox.Show("Cập nhật tên lớp thành công!");
                        this.Dispose();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            } else if(hanhDong.Equals("join"))
            {
                if(checkValidInputMaMoi())
                {
                    if(lBus.checkMaMoi(txtTenlop.Text))
                    {
						MessageBox.Show("Tham gia lớp học thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int ml = lBus.GetMaLopByMaMoi(txtTenlop.Text);
                        ChiTietLopDTO obj = new ChiTietLopDTO(ml, Form1.USER_ID, 1);
                        chiTietLopBUS.Add(obj);
                        List<LopDTO> newList = lBus.GetAll(Form1.USER_ID);
                        lopHocUserControl.loadLop(newList);
                        this.Dispose();
                        this.Close();
					} else
                    {
						MessageBox.Show("Bạn đã nhập sai mã mời", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
            }
        }
        private bool checkValidInput()
        {
            if (string.IsNullOrEmpty(txtTenlop.Text))
            {
                MessageBox.Show("Không được để trống tên lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool checkValidInputMaMoi()
        {
			if (string.IsNullOrEmpty(txtTenlop.Text))
			{
				MessageBox.Show("Mã mời không được rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
            if (txtTenlop.Text.Length != 10)
            {
                MessageBox.Show("Mã mời phải có đủ 10 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true;
		}
    }
}
