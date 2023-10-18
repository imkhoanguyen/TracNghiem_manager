﻿using System;
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
		public fThemDeThiCuaLop(DeThiDTO dt, LopDTO l, string hd = null)
		{
			InitializeComponent();
			deThiDTO = dt;
			lopDTO = l;
			hanhDong = hd;
			dtclBus = new DeThiCuaLopBUS();
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
						this.Dispose();
						this.Close();
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

			return true;
		}
	}
}
