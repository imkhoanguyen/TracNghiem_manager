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
		private MonHocDTO selectedMonHoc;
		MonHocBUS mhBus;
		public fThemDeThi(DeThiUserControl dt, string hd, DeThiDTO dtDTO = null)
		{
			InitializeComponent();
			dtBus = new DeThiBUS();
			mhBus = new MonHocBUS();
			deThiUserControl = dt;
			hanhDong = hd;
			if (hanhDong.Equals("edit"))
			{
				objUpdate = dtDTO;
				txtTenlop.Text = objUpdate.TenDeThi;
				this.Text = "Cập nhật đề thi";
				nud.Value = objUpdate.ThoiGianLamBai;
				label2.Text = "Cập nhật đề thi";
			}
			loadCbMonHoc();
		}

		public fThemDeThi(string hd = null)
		{
			InitializeComponent();
			dtBus = new DeThiBUS();
			mhBus = new MonHocBUS();
			hanhDong = hd;
			loadCbMonHoc();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (hanhDong.Equals("add"))
			{
				try
				{
					if (checkValidInput())
					{
						//public DeThiDTO(int maDeThi, string tenDeThi, int maMonHoc, int maNuoiTao, int thoiGianLamBai, int trangThai)
						int time = (int)nud.Value;
						DeThiDTO dt = new DeThiDTO(dtBus.GetAutoIncrement(), txtTenlop.Text, selectedMonHoc.MaMonHoc, time, 1);
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
						DeThiDTO dt = new DeThiDTO(objUpdate.MaDeThi, txtTenlop.Text, selectedMonHoc.MaMonHoc, time, 1);
						deThiUserControl.UpdateDeThi(dt);
						this.Close();
						MessageBox.Show("Cập nhật đề thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			if (string.IsNullOrEmpty(txtTenlop.Text))
			{
				MessageBox.Show("Không được để trống tên đề thi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if ((int)nud.Value < 15)
			{
				MessageBox.Show("Thời gian làm bài phải >= 15p", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}

		private void loadCbMonHoc()
		{
			cbMonHoc.ValueMember = "MaMonHoc";
			cbMonHoc.DisplayMember = "TenMonHoc";
			List<MonHocDTO> listmh = mhBus.getAll();
			cbMonHoc.DataSource = listmh;
			cbMonHoc.SelectedIndex = 0;
		}

		private void cbMonHoc_SelectedValueChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.ComboBox cb = sender as System.Windows.Forms.ComboBox;
			if (cb.SelectedValue != null)
			{
				selectedMonHoc = mhBus.getById(Convert.ToInt32(cb.SelectedValue));
			}
		}
	}
}
