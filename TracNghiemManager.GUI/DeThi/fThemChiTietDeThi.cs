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
		MonHocBUS mhBus;
		private MonHocDTO indexSreachMonHoc; // search
		private string indexSearchDoKho; // search
		CauTraLoiBUS ctlBus;
		public fThemChiTietDeThi(DeThiDTO d)
		{
			InitializeComponent();
			chBus = new CauHoiBUS();
			ctdtBus = new ChiTietDeThiBUS();
			mhBus = new MonHocBUS();
			ctlBus = new CauTraLoiBUS();
			dt = d;
			lbCauHoi.SelectionMode = SelectionMode.MultiSimple;
			lbDeThi.SelectionMode = SelectionMode.MultiSimple;
			lbCauHoi.HorizontalScrollbar = true;
			lbDeThi.HorizontalScrollbar = true;
			load();
			lbCauHoi.DisplayMember = "CauHoiDTOToString";
			lbDeThi.DisplayMember = "CauHoiDTOToString";
		}

		void load()
		{
			lbCauHoi.Items.Clear();
			lbDeThi.Items.Clear();
			List<CauHoiDTO> lch = chBus.GetAllByMaNguoiTao(Form1.USER_ID);
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

			// load comboBox
			loadComboBoxDoKho();
			loadComboBoxMonHoc();
			txt.Text = "";
		}

		private void lbCauHoi_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			// Lấy chỉ mục của mục được double click
			int index = lbCauHoi.IndexFromPoint(e.Location);

			// Đảm bảo chỉ thực hiện khi double click vào một mục cụ thể
			if (index != ListBox.NoMatches)
			{
				// Lấy đối tượng được double click
				CauHoiDTO selectedItem = (CauHoiDTO)lbCauHoi.Items[index];
				MessageBox.Show(selectedItem.NoiDung);
			}
		}

		private void btnRightToLeft_Click_1(object sender, EventArgs e)
		{
			if (lbDeThi.Items.Count > 0)
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
			}
			else
			{
				MessageBox.Show("Danh sách câu hỏi đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void btnLeftToRightAll_Click_1(object sender, EventArgs e)
		{
			if (lbCauHoi.Items.Count > 0)
			{
				foreach (CauHoiDTO item in lbCauHoi.Items)
				{
					lbDeThi.Items.Add(item);
					ChiTietDeThiDTO obj = new ChiTietDeThiDTO(dt.MaDeThi, item.MaCauHoi);
					ctdtBus.Add(obj);
				}

				// Xóa tất cả các mục từ lbCauHoi
				lbCauHoi.Items.Clear();
			}
			else
			{
				MessageBox.Show("Danh sách câu hỏi đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void btnRightToLeftAll_Click_1(object sender, EventArgs e)
		{
			if (lbDeThi.Items.Count > 0)
			{
				foreach (CauHoiDTO item in lbDeThi.Items)
				{
					lbCauHoi.Items.Add(item);
				}
				lbDeThi.Items.Clear();
				ctdtBus.Delete(dt.MaDeThi);
			}
			else
			{
				MessageBox.Show("Danh sách câu hỏi đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			}
		}

		private void btnLeftToRight_Click_1(object sender, EventArgs e)
		{
			if (lbCauHoi.Items.Count > 0)
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
			}
			else
			{
				MessageBox.Show("Danh sách câu hỏi đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		public void loadComboBoxDoKho()
		{
			List<string> listdk = new List<string> { "Chọn độ khó", "Dễ", "Bình thường", "Khó" };
			cbDoKho.DataSource = listdk;
			cbDoKho.SelectedIndex = 0;
		}

		private void btnLamMoi_Click(object sender, EventArgs e)
		{
			load();
		}

		public void loadComboBoxMonHoc()
		{
			int t = -1;
			// Clear datasouce
			cbMonHoc.DataSource = null;
			cbMonHoc.ValueMember = "MaMonHoc";
			cbMonHoc.DisplayMember = "TenMonHoc";
			List<MonHocDTO> list = mhBus.getAll();
			MonHocDTO chonMonHocItem = new MonHocDTO
			{
				TenMonHoc = "Chọn môn học",
				MaMonHoc = -1,
			};
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].MaMonHoc == -1) t = 1;
			}
			if (t != 1)
			{
				list.Insert(0, chonMonHocItem);
			}
			cbMonHoc.DataSource = list;
			cbMonHoc.SelectedIndex = 0;
		}

		private void cbDoKho_SelectedValueChanged(object sender, EventArgs e)
		{
			ComboBox cb = sender as ComboBox;
			//search
			if (cb.SelectedValue != null)
			{
				indexSearchDoKho = cb.SelectedValue.ToString();
			}
		}

		private void cbMonHoc_SelectedValueChanged(object sender, EventArgs e)
		{
			ComboBox cb = sender as ComboBox;
			//search
			if (cb.SelectedValue != null)
			{
				indexSreachMonHoc = mhBus.getById(Convert.ToInt32(cb.SelectedValue));
			}
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			Search();
		}

		private void lbCauHoi_DoubleClick(object sender, EventArgs e)
		{
			ListBox.SelectedObjectCollection ds = lbCauHoi.SelectedItems;
			if(ds.Count == 1 )
			{
				foreach(CauHoiDTO item in ds)
				{
					List<CauTraLoiDTO> l = ctlBus.getByMaCauHoi(item.MaCauHoi);
					fThemCauHoi fThem = new fThemCauHoi("view", item, l);
					fThem.Visible = true;
				}
			} else
			{
				MessageBox.Show("Vui lòng chọn 1 hàng để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void lbDeThi_DoubleClick(object sender, EventArgs e)
		{
			ListBox.SelectedObjectCollection ds = lbDeThi.SelectedItems;
			if (ds.Count == 1)
			{
				foreach (CauHoiDTO item in ds)
				{
					List<CauTraLoiDTO> l = ctlBus.getByMaCauHoi(item.MaCauHoi);
					fThemCauHoi fThem = new fThemCauHoi("view", item, l);
					fThem.Visible = true;
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn 1 hàng để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		public void Search()
		{
			try
			{
				string noiDungTimKiem = txt.Text;
				if (indexSearchDoKho == "Chọn độ khó")
				{
					indexSearchDoKho = null;
				}

				// Lọc các câu hỏi theo nội dung tìm kiếm
				List<CauHoiDTO> listCauHoiTimKiem = lLeft.Where(ch => ch.NoiDung.ToLower().Contains(noiDungTimKiem.ToLower())).ToList();

				// Nếu có chọn môn học thì lọc các câu hỏi theo môn học
				if (indexSreachMonHoc != null)
				{
					listCauHoiTimKiem = (List<CauHoiDTO>)listCauHoiTimKiem.Where(ch => ch.MaMonHoc == indexSreachMonHoc.MaMonHoc).ToList();
				}

				// Nếu có chọn độ khó thì lọc các câu hỏi theo độ khó
				if (!string.IsNullOrEmpty(indexSearchDoKho))
				{
					listCauHoiTimKiem = (List<CauHoiDTO>)listCauHoiTimKiem.Where(ch => ch.DoKho == indexSearchDoKho).ToList();
				}

				// Nếu không chọn môn học và độ khó thì tìm kiếm theo nội dung tìm kiếm
				if (indexSreachMonHoc == null && indexSearchDoKho == null)
				{
					listCauHoiTimKiem = (List<CauHoiDTO>)lLeft.Where(ch => ch.NoiDung.ToLower().Contains(noiDungTimKiem.ToLower())).ToList();
				}
				lbCauHoi.Items.Clear();
				foreach(var item in listCauHoiTimKiem)
				{
					lbCauHoi.Items.Add(item);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

		}
	}
}
