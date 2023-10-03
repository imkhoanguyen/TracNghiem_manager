using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracNghiemManager.BUS;
using TracNghiemManager.DTO;
using TracNghiemManager.GUI.CauHoi;

namespace TracNghiemManager.GUI.MonHoc
{
    public partial class fThemMonHoc : Form
    {
        private string hanhDong;
        MonHocBUS mhBus;
        MonHocUserControl monHocUserControl;
        MonHocDTO mhUpdate;
        public fThemMonHoc(MonHocUserControl mh, string hanhDong, MonHocDTO obj = null)
        {
            InitializeComponent();
            mhBus = new MonHocBUS();
            monHocUserControl = mh;
            mhUpdate = obj;
            this.hanhDong = hanhDong;
            if(hanhDong.Equals("add"))
            {
                this.Text = "Thêm môn học";
            }
            if(hanhDong.Equals("edit"))
            {
                this.Text = "Cập nhật môn học";
                txtTenMonHoc.Text = mhUpdate.TenMonHoc;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(hanhDong.Equals("add"))
            {
                if(checkValidInput())
                {
                    try
                    {
                        MonHocDTO obj = new MonHocDTO(mhBus.GetAutoIncrement(), txtTenMonHoc.Text, 1);
                        monHocUserControl.AddMonHoc(obj);
                        this.Close();
                        MessageBox.Show("Thêm môn học thành công!");
                        this.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            } else if(hanhDong.Equals("edit"))
            {
                if(checkValidInput())
                {
                    try
                    {
                        MonHocDTO obj = new MonHocDTO(mhUpdate.MaMonHoc, txtTenMonHoc.Text, 1);
                        monHocUserControl.UpdateMonHoc(obj);
                        this.Close();
                        MessageBox.Show("Cập nhật môn học thành công!");
                        this.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        private bool checkValidInput()
        {
            if(string.IsNullOrEmpty(txtTenMonHoc.Text))
            {
                MessageBox.Show("Không được để trống tên môn học");
                return false;
            }
            return true;
        }
    }
}
