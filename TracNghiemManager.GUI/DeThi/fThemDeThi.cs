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

namespace TracNghiemManager.GUI.DeThi
{
    public partial class fThemDeThi : Form
    {
        private DeThiUserControl deThiUserControl;
        private string hanhDong;
        DeThiDTO objUpdate;
        DeThiBUS dtBus;
        public fThemDeThi(DeThiUserControl dt, string hd, DeThiDTO dtDTO = null)
        {
            InitializeComponent();
            dtBus = new DeThiBUS();
            deThiUserControl = dt;
            hanhDong = hd;
            if (hanhDong.Equals("edit"))
            {
                objUpdate = dtDTO;
                txtTenlop.Text = objUpdate.TenDeThi;
                this.Text = "Cập nhật đề thi";
                nud.Value = objUpdate.ThoiGianLamBai;
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
                        //DeThiDTO(int maDeThi, string tenDeThi, int maNuoiTao, int thoiGianLamBai, int trangThai)
                        int time = (int)nud.Value;
                        DeThiDTO dt = new DeThiDTO(dtBus.GetAutoIncrement(), txtTenlop.Text, 1, time, 1);
                        deThiUserControl.AddDeThi(dt);
                        this.Close();
                        MessageBox.Show("Thêm đề thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
						int time = (int)nud.Value;
						DeThiDTO dt = new DeThiDTO(objUpdate.MaDeThi, txtTenlop.Text, 1, time, 1);
                        deThiUserControl.UpdateDeThi(dt);
                        this.Close();
						MessageBox.Show("Cập nhật đề thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.Dispose();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        private bool checkValidInput()
        {
            if (string.IsNullOrEmpty(txtTenlop.Text))
            {
                MessageBox.Show("Không được để trống tên đề thi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if((int)nud.Value < 15)
            {
                MessageBox.Show("Thời gian làm bài phải >= 15p", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } 
            return true;
        }
    }
}
