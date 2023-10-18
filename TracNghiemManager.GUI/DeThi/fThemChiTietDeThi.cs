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
		ChiTietDeThiBUS ctdtBus;
		List<CauHoiDTO> lLeft, lRight;
		DeThiDTO dt;
		public fThemChiTietDeThi(DeThiDTO d)
		{
			InitializeComponent();
			chBus = new CauHoiBUS();
			ctdtBus = new ChiTietDeThiBUS();
			dt = d;
			lbCauHoi.SelectionMode = SelectionMode.MultiSimple;
			lbDeThi.SelectionMode = SelectionMode.MultiSimple;


			load();
			lbCauHoi.DisplayMember = "CauHoiDTOToString";
			lbDeThi.DisplayMember = "CauHoiDTOToString";
		}

		void load()
		{
			List<CauHoiDTO> lch = chBus.getAll();
			lLeft = new List<CauHoiDTO>(lch); // Sao chép danh sách câu hỏi ban đầu
			lRight = ctdtBus.GetAllCauHoiOfDeThi(dt.MaDeThi);

			// Loại bỏ các câu hỏi đã có trong lRight khỏi danh sách lLeft bằng vòng lặp for
			for (int i = 0; i < lRight.Count; i++)
			{
				CauHoiDTO item = lRight[i];
				lLeft.RemoveAll(ch => ch.MaCauHoi == item.MaCauHoi);
			}

			foreach (var item in lRight)
			{
				lbDeThi.Items.Add(item);
			}

			// Sau khi loại bỏ các câu hỏi đã có, bạn có thể thêm các câu hỏi còn lại vào lbCauHoi
			foreach (var item in lLeft)
			{
				lbCauHoi.Items.Add(item);
			}


		}

		private void lbCauHoi_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void btnRightToLeft_Click(object sender, EventArgs e)
		{
			if(lbDeThi.Items.Count > 0)
			{
				ListBox.SelectedObjectCollection ds = lbDeThi.SelectedItems;
				ListBox.SelectedIndexCollection ds2 = lbDeThi.SelectedIndices;
				List<int> lCauHoiDuocChon = new List<int>();
				foreach (CauHoiDTO item in ds)
				{
					lbCauHoi.Items.Add(item);
					lCauHoiDuocChon.Add(item.MaCauHoi);
				}
				for (int i = ds2.Count - 1; i >= 0; i--)
				{
					lbDeThi.Items.RemoveAt(ds2[i]);

					for (int j = 0; j < lCauHoiDuocChon.Count; j++)
					{
						// Xóa mục ChiTietDeThi tương ứng từ cơ sở dữ liệu
						ctdtBus.Delete(dt.MaDeThi, lCauHoiDuocChon[i]);
					}

				}
			} else
			{
				MessageBox.Show("Danh sách câu hỏi đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

		}

		private void btnLeftToRightAll_Click(object sender, EventArgs e)
		{
			if(lbCauHoi.Items.Count > 0)
			{
				foreach (CauHoiDTO item in lbCauHoi.Items)
				{
					lbDeThi.Items.Add(item);
					ChiTietDeThiDTO obj = new ChiTietDeThiDTO(dt.MaDeThi, item.MaCauHoi);
					ctdtBus.Add(obj);
				}

				// Xóa tất cả các mục từ lbCauHoi
				lbCauHoi.Items.Clear();
			} else
			{
				MessageBox.Show("Danh sách câu hỏi đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			}

		}

		private void btnRightToLeftAll_Click(object sender, EventArgs e)
		{
			if(lbDeThi.Items.Count > 0)
			{
				foreach (CauHoiDTO item in lbDeThi.Items)
				{
					lbCauHoi.Items.Add(item);
				}
				lbDeThi.Items.Clear();
				ctdtBus.Delete(dt.MaDeThi);
			} else
			{
				MessageBox.Show("Danh sách câu hỏi đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			}

		}

		private void btnLeftToRight_Click(object sender, EventArgs e)
		{
			if(lbCauHoi.Items.Count  > 0)
			{
				ListBox.SelectedObjectCollection ds = lbCauHoi.SelectedItems;
				ListBox.SelectedIndexCollection ds2 = lbCauHoi.SelectedIndices;
				foreach (CauHoiDTO item in ds)
				{
					lbDeThi.Items.Add(item);
					ChiTietDeThiDTO obj = new ChiTietDeThiDTO(dt.MaDeThi, item.MaCauHoi);
					ctdtBus.Add(obj);
				}
				for (int i = ds2.Count - 1; i >= 0; i--)
				{
					lbCauHoi.Items.RemoveAt(ds2[i]);
				}
			} else
			{
				MessageBox.Show("Danh sách câu hỏi đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

		}
	}
}
