using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracNghiemManager.BUS;
using TracNghiemManager.DTO;

namespace TracNghiemManager.GUI.CauHoi
{
	public partial class CauHoiUserControl : UserControl
	{
		private CauHoiBUS chBus;
		private MonHocBUS mhBus;
		private CauTraLoiBUS ctlBus;
		private List<CauHoiDTO> listch;
		private DataTable dt;
		private int idSelected; // id của row được select
		private int index; // row được select
		private MonHocDTO indexSreachMonHoc; // search
		private string indexSearchDoKho; // search
		private List<MonHocDTO> listmh;
		public CauHoiUserControl()
		{

			InitializeComponent();
			System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
			dt = new DataTable();
			chBus = new CauHoiBUS();
			mhBus = new MonHocBUS();
			ctlBus = new CauTraLoiBUS();
			listch = chBus.GetAllByMaNguoiTao(Form1.USER_ID);
			listmh = mhBus.getAll();
			loadComboBoxMonHoc(listmh);
			loadComboBoxDoKho();
			dt.Columns.Add("ID", typeof(int));
			dt.Columns.Add("Nội dung câu hỏi", typeof(string));
			dt.Columns.Add("Môn học", typeof(string));
			dt.Columns.Add("Độ khó", typeof(string));

			loadDataTable(listch);
			dataGridView1.Columns["ID"].Width = 60;
			dataGridView1.Columns["Môn học"].Width = 300;
		}

		public void load()
		{
			MonHocBUS newmhbus = new MonHocBUS();
			listmh = newmhbus.getAll();
			listch = chBus.GetAllByMaNguoiTao(Form1.USER_ID);
			loadDataTable(listch);
			loadComboBoxMonHoc(listmh);
			textBoxTimKiem.Text = "";
			comboBoxDoKho.SelectedIndex = 0;
			loadComboBoxDoKho();
		}

		public void loadDataTable(List<CauHoiDTO> list)
		{
			listch = list;
			dt.Clear();

			foreach (var cauHoi in listch)
			{
				DataRow row = dt.NewRow();
				row["ID"] = cauHoi.MaCauHoi;
				row["Nội dung câu hỏi"] = cauHoi.NoiDung;
				row["Môn học"] = mhBus.getById(cauHoi.MaMonHoc).TenMonHoc;
				row["Độ khó"] = cauHoi.DoKho;
				dt.Rows.Add(row);
			}
			dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
			dataGridView1.EnableHeadersVisualStyles = false;
			dataGridView1.DataSource = dt;

			// setChieuCaoCuaTatCaCacDong
			for (int i = 0; i < listch.Count; i++)
			{
				dataGridView1.Rows[i].Height = 40;
				dataGridView1.Rows[i].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

			}
			// Thêm sự kiện DataBindingComplete vào DataGridView
			dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
		}

		public void AddCauHoi(CauHoiDTO cauHoi)
		{
			// Thêm câu hỏi vào danh sách
			listch.Add(cauHoi);

			// Thêm câu hỏi vào dtb
			chBus.Add(cauHoi);

			// Thêm câu hỏi vào DataTable
			DataRow row = dt.NewRow();
			row["ID"] = cauHoi.MaCauHoi;
			row["Nội dung câu hỏi"] = cauHoi.NoiDung;
			row["Môn học"] = mhBus.getById(cauHoi.MaMonHoc).TenMonHoc;
			row["Độ khó"] = cauHoi.DoKho;
			dt.Rows.Add(row);
		}

		public void UpdateCauHoi(CauHoiDTO cauHoi)
		{
			// Cập nhật trên dtb
			chBus.Update(cauHoi);
			// Cập nhật trên list
			listch.RemoveAt(index); // Xóa tại vị trí index
			listch.Insert(index, cauHoi); // Thêm tại vị trí index
			loadDataTable(listch);
		}

		public void DeleteCauHoi(int id)
		{
			// Xõa trên dtb
			DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa câu hỏi không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				chBus.Delete(id);
				listch.RemoveAt(index);
				loadDataTable(listch);
			}
		}

		public void Search()
		{
			try
			{
				string noiDungTimKiem = textBoxTimKiem.Text;
				if (indexSearchDoKho == "Chọn độ khó")
				{
					indexSearchDoKho = null;
				}

				// Lọc các câu hỏi theo nội dung tìm kiếm
				List<CauHoiDTO> listCauHoiTimKiem = listch.Where(ch => ch.NoiDung.ToLower().Contains(noiDungTimKiem.ToLower())).ToList();

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
					listCauHoiTimKiem = (List<CauHoiDTO>)listch.Where(ch => ch.NoiDung.ToLower().Contains(noiDungTimKiem.ToLower())).ToList();
				}

				// Show nội dung cần thiết
				var listCauHoiTimKiemFilter = listCauHoiTimKiem.Select(ch => new
				{
					ID = ch.MaCauHoi,
					Nộidungcâuhỏi = ch.NoiDung,
					Mônhọc = mhBus.getById(ch.MaMonHoc).TenMonHoc,
					Độkhó = ch.DoKho,
				}).ToList();

				// Đặt nguồn dữ liệu cho DataGridView
				dataGridView1.DataSource = listCauHoiTimKiemFilter;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				dataGridView1.DataSource = listch;
			}

		}

		public void loadComboBoxMonHoc(List<MonHocDTO> l)
		{
			int t = -1;
			// Clear datasouce
			comboBoxMonHoc.DataSource = null;
			comboBoxMonHoc.ValueMember = "MaMonHoc";
			comboBoxMonHoc.DisplayMember = "TenMonHoc";
			List<MonHocDTO> list = l;
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
			comboBoxMonHoc.DataSource = list;
			comboBoxMonHoc.SelectedIndex = 0;
		}
		public void loadComboBoxDoKho()
		{
			List<string> listdk = new List<string> { "Chọn độ khó", "Dễ", "Bình thường", "Khó" };
			comboBoxDoKho.DataSource = listdk;
			comboBoxDoKho.SelectedIndex = 0;
		}

		// load lại từ dtb không phải listch
		private void btnLamMoi_Click(object sender, EventArgs e)
		{
			load();
		}


		private void btnXuatFile_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Chọn File";
			saveFileDialog.Filter = "Word Document|*.docx";
			saveFileDialog.FilterIndex = 2;
			saveFileDialog.RestoreDirectory = true;

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				string filePath = saveFileDialog.FileName;
				try
				{
					chBus.ExportToWord(filePath, Form1.USER_ID);
					MessageBox.Show("Xuất file thành công!");
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: " + ex.Message);
				}
			}
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			fThemCauHoi fThem = new fThemCauHoi(this, "add");
			fThem.ShowDialog();
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			CauHoiDTO selectedCauHoi = chBus.getById(idSelected);
			List<CauTraLoiDTO> l = ctlBus.getByMaCauHoi(idSelected);
			if (selectedCauHoi == null)
			{
				MessageBox.Show("Chưa chọn hàng cần chỉnh sửa!");
			}
			else
			{
				fThemCauHoi fThem = new fThemCauHoi(this, "edit", selectedCauHoi, l);
				fThem.ShowDialog();
			}

		}

		private void btnChiTiet_Click(object sender, EventArgs e)
		{
			CauHoiDTO selectedCauHoi = chBus.getById(idSelected);
			List<CauTraLoiDTO> l = ctlBus.getByMaCauHoi(idSelected);
			if (selectedCauHoi == null)
			{
				MessageBox.Show("Chưa chọn hàng cần xem!");
			}
			else
			{
				fThemCauHoi fThem = new fThemCauHoi(this, "view", selectedCauHoi, l);
				fThem.ShowDialog();
			}

		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			DeleteCauHoi(idSelected);
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			Search();
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
				idSelected = Convert.ToInt32(row.Cells[0].Value);
				index = e.RowIndex;
			}
		}

		private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			if (dataGridView1.Columns.Contains("Nộidungcâuhỏi"))
			{
				dataGridView1.Columns["Nộidungcâuhỏi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			}
			if (dataGridView1.Columns.Contains("Nộidungcâuhỏi")
				|| dataGridView1.Columns.Contains("MônHọc")
				|| dataGridView1.Columns.Contains("Độkhó"))
			{
				dataGridView1.Columns["Nộidungcâuhỏi"].HeaderText = "Nội dung câu hỏi";
				dataGridView1.Columns["MônHọc"].HeaderText = "Môn học";
				dataGridView1.Columns["Độkhó"].HeaderText = "Độ khó";
			}

			if (dataGridView1.Columns.Contains("Nội dung câu hỏi"))
			{
				dataGridView1.Columns["Nội dung câu hỏi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			}
		}

		private void comboBoxMonHoc_SelectedValueChanged(object sender, EventArgs e)
		{
			ComboBox cb = sender as ComboBox;
			//search
			if (cb.SelectedValue != null)
			{
				indexSreachMonHoc = mhBus.getById(Convert.ToInt32(cb.SelectedValue));
			}
		}

		private void comboBoxDoKho_SelectedValueChanged(object sender, EventArgs e)
		{
			ComboBox cb = sender as ComboBox;
			//search
			if (cb.SelectedValue != null)
			{
				indexSearchDoKho = cb.SelectedValue.ToString();
			}
		}

		private void textBoxTimKiem_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)Keys.Enter)
			{
				Search();
			}
		}
	}
}
