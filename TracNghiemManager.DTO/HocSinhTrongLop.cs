﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiemManager.DTO
{
	public class HocSinhTrongLop
	{
		public int MaHocSinh { get; set; }
		public string HoTen { get; set; }
		public string Email { get; set; }
		public double Diem { get; set; }
		public HocSinhTrongLop()
		{

		}
		public HocSinhTrongLop(int maHocSinh, string hoTen, string email)
		{
			MaHocSinh = maHocSinh;
			HoTen = hoTen;
			Email = email;
		}
		public HocSinhTrongLop(int maHocSinh, string hoTen, string email, double diem)
		{
			MaHocSinh = maHocSinh;
			HoTen = hoTen;
			Email = email;
			Diem = diem;
		}
	}
}
