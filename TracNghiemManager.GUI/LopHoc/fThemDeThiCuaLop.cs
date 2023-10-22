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

namespace TracNghiemManager.GUI.LopHoc
{
	public partial class fThemDeThiCuaLop : Form
	{
		DeThiDTO deThiDTO;
		LopDTO lopDTO;
		string hanhDong;
		DeThiCuaLopBUS dtclBus;
		fChiTietLop fctl;
		fDanhSachDeThi fdsdt;
		public fThemDeThiCuaLop(DeThiDTO dt, LopDTO l, fChiTietLop f, fDanhSachDeThi f1,string hd = null)
		{
			InitializeComponent();
			deThiDTO = dt;
			lopDTO = l;
			fdsdt = f1;
			hanhDong = hd;
			fctl = f;
			dtclBus = new DeThiCuaLopBUS();
			dtpThoiGianBatDau.Format = DateTimePickerFormat.Custom;
			dtpThoiGianBatDau.CustomFormat = "dd/MM/yyyy HH:mm";
			dtpThoiGianKetThuc.Format = DateTimePickerFormat.Custom;
			dtpThoiGianKetThuc.CustomFormat = "dd/MM/yyyy HH:mm";
		}

		private void btnLuu_Click(object sender, EventArgs e)
		{
			if (hanhDong.Equals("add"))
			{
				if (checkValidate())
				{
					try
					{
						DeThiCuaLopDTO obj = new DeThiCuaLopDTO(dtclBus.GetAutoIncrement(), deThiDTO.MaDeThi, lopDTO.MaLop, dtpThoiGianBatDau.Value, dtpThoiGianKetThuc.Value, 1); ;
						dtclBus.Add(obj);
						MessageBox.Show("Thêm đề thi vào lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						fctl.loadDeThi();
						this.Dispose();
						this.Close();
						fdsdt.Dispose();
						fdsdt.Close();
					}catch(Exception ex)
					{
						Console.WriteLine(ex);
						MessageBox.Show("Thêm đề thi vào lớp thất bại","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					
				}
			}
		}

		bool checkValidate()
		{
			if (dtpThoiGianBatDau.Value == null)
			{
				MessageBox.Show("Bạn chưa chọn thời gian bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (dtpThoiGianKetThuc.Value == null)
			{
				MessageBox.Show("Bạn chưa chọn thời gian kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			// Kiểm tra xem dtpThoiGianKetThuc phải lớn hơn dtpThoiGianBatDau
			if (dtpThoiGianKetThuc.Value.CompareTo(dtpThoiGianBatDau.Value) <= 0)
			{
				MessageBox.Show("Thời gian kết thúc phải lớn hơn thời gian bất đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				// Trả về false nếu dtpThoiGianKetThuc nhỏ hơn hoặc bằng dtpThoiGianBatDau
				return false;
			}

			// Kiểm tra xem dtpThoiGianBatDau phải lớn hơn thời gian hiện tại
			if (dtpThoiGianBatDau.Value.CompareTo(DateTime.Now) <= 0)
			{
				MessageBox.Show("Thời gian bất đầu phải lớn hơn thời gian hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				// Trả về false nếu dtpThoiGianBatDau nhỏ hơn hoặc bằng thời gian hiện tại
				return false;
			}
			if(dtclBus.checkDeThiCoTrongLop(deThiDTO.MaDeThi))
			{
				MessageBox.Show("Đề thi đã có trong lớp rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			return true;
		}
	}
}
