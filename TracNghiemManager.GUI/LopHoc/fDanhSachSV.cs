using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using TracNghiemManager.BUS;
using TracNghiemManager.DTO;
using TracNghiemManager.DTO.ViewModel;
using LiveCharts.Helpers;

namespace TracNghiemManager.GUI.LopHoc
{
	public partial class fDanhSachSV : Form
	{
		private ChiTietLopBUS ctlBus;
		private List<HocSinhTrongLop> lHocSinhTrongLop;
		private LopDTO lopDTO;
		private DataTable dt;
		private ThongKeBUS tkBus;
		private DeThiCuaLopBUS dtclBus;
		private List<DiemTBCuaHS> lDTB;
		private List<string> listHoTenHs;
		private List<double> listDiemTBCuaHs;
		private int soLuongDeThiCoTrongLop;
		public fDanhSachSV(LopDTO l)
		{
			InitializeComponent();
			ctlBus = new ChiTietLopBUS();
			lopDTO = l;
			tkBus = new ThongKeBUS();
			dtclBus = new DeThiCuaLopBUS();
			soLuongDeThiCoTrongLop = dtclBus.slDeThiCoTrongLop(lopDTO.MaLop);
			lDTB = tkBus.GetAllDiemTBCuaHS(lopDTO.MaLop);
			if (listHoTenHs == null)
			{
				listHoTenHs = new List<string>();
			}
			if (listDiemTBCuaHs == null)
			{
				listDiemTBCuaHs = new List<double>();
			}
			foreach (DiemTBCuaHS item in lDTB)
			{
				listHoTenHs.Add(item.HoTen);
				listDiemTBCuaHs.Add(item.Diem / soLuongDeThiCoTrongLop);
			}
			dt = new DataTable();
			dt.Columns.Add("STT", typeof(int));
			dt.Columns.Add("Mã học sinh", typeof(int));
			dt.Columns.Add("Họ và tên", typeof(string));
			dt.Columns.Add("Email", typeof(string));
			load();
			loadChartTongQuan();
		}

		private void load()
		{
			loadDataGridView();
			StyleDataGridView();
		}
		private void loadDataGridView()
		{
			lHocSinhTrongLop = ctlBus.GetAllHSTrongLop(lopDTO.MaLop);
			dt.Clear();
			int stt = 1;
			foreach (HocSinhTrongLop hs in lHocSinhTrongLop)
			{
				DataRow row = dt.NewRow();
				row["STT"] = stt;
				row["Mã học sinh"] = hs.MaHocSinh;
				row["Họ và tên"] = hs.HoTen;
				row["Email"] = hs.Email;
				dt.Rows.Add(row);
				stt++;
			}
			dataGridView1.DataSource = dt;
		}
		private void StyleDataGridView()
		{
			dataGridView1.Columns["STT"].Width = 50;
			dataGridView1.Columns["Mã học sinh"].Width = 150;
			dataGridView1.Columns["Họ và tên"].Width = 300;
			dataGridView1.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

		private void loadTongQuan()
		{


		}
		private void loadChartTongQuan()
		{
			cartesianChart1.Series = new SeriesCollection
			{
				new ColumnSeries
				{
					Title = "Điểm trung bình",
					Values = listDiemTBCuaHs.Select(value => (double)value).AsChartValues(),
				}
			};


			cartesianChart1.AxisX.Add(new Axis
			{
				Title = "Họ tên học sinh",
				Labels = listHoTenHs.ToArray(),
			});

			cartesianChart1.AxisY.Add(new Axis
			{
				Title = "Điểm trung bình",
				LabelFormatter = value => value.ToString("N2")
			});

		}
	}
}
