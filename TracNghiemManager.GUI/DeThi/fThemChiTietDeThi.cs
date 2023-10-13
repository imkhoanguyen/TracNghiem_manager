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
using TracNghiemManager.GUI.CauHoi;

namespace TracNghiemManager.GUI.DeThi
{
	public partial class fThemChiTietDeThi : Form
	{
		CauHoiBUS chBus;
		public fThemChiTietDeThi()
		{
			InitializeComponent();
			chBus = new CauHoiBUS();
			load();
		}

		void load()
		{
			List<CauHoiDTO> lch = chBus.getAll();
			List<CauHoiDTO> lcurentCH = lch;
			foreach(var item in lcurentCH)
			{
				lbCauHoi.Items.Add(item.NoiDung);
			}
		}

		private void lbCauHoi_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
