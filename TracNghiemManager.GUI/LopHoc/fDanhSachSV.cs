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
		private DeThiBUS dtBus;
		private List<HocSinhTrongLop> lHocSinhTrongLop;
		private LopDTO lopDTO;
		private DataTable dt;
		private ThongKeBUS tkBus;
		private DeThiCuaLopBUS dtclBus;
		private List<DiemTBCuaHS> lDTB;
		private List<string> listHoTenHs;
		private List<double> listDiemTBCuaHs;
		private int soLuongDeThiCoTrongLop;
		private int soLuongHsDaNopBai;
		private List<DeThiCuaLopDTO> listDeThiCuaLop;
		private List<DeThiDTO> listDeThi;
		private int selectedIdDeThi;
		public fDanhSachSV(LopDTO l)
		{
			InitializeComponent();
			ctlBus = new ChiTietLopBUS();
			dtBus = new DeThiBUS();
			lopDTO = l;
			tkBus = new ThongKeBUS();
			dtclBus = new DeThiCuaLopBUS();
			soLuongDeThiCoTrongLop = dtclBus.slDeThiCoTrongLop(lopDTO.MaLop);
			lDTB = tkBus.GetAllDiemTBCuaHS(lopDTO.MaLop);
			listDeThiCuaLop = dtclBus.GetAll(lopDTO.MaLop);
			soLuongHsDaNopBai = tkBus.getSlHSDaNopBai(lopDTO.MaLop, selectedIdDeThi);
			if (listHoTenHs == null)
			{
				listHoTenHs = new List<string>();
			}
			if (listDiemTBCuaHs == null)
			{
				listDiemTBCuaHs = new List<double>();
			}
			if(listDeThi == null)
			{
				listDeThi = new List<DeThiDTO>();
			}
			foreach(DeThiCuaLopDTO item in listDeThiCuaLop)
			{
				listDeThi.Add(dtBus.GetById(item.MaDeThi));
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
			loadCbDeThi();
			loadChartTongQuan();
			loadPieChart();
		}

		private void loadCbDeThi()
		{
			cbDeThi.ValueMember = "MaDeThi";
			cbDeThi.DisplayMember = "TenDeThi";
			cbDeThi.DataSource = listDeThi;
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

		private void loadPieChart()
		{
			Func<ChartPoint, string> labelPoint = chartPoint =>
		string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

			pieChart1.Series = new SeriesCollection
			{
				new PieSeries
				{
					Title = "Đã nộp bài",
					Values = new ChartValues<int> {soLuongHsDaNopBai},
					DataLabels = true,
					LabelPoint = labelPoint
				},
				new PieSeries
				{
					Title = "Chưa nộp bài",
					Values = new ChartValues<int> {lHocSinhTrongLop.Count - soLuongHsDaNopBai},
					DataLabels = true,
					LabelPoint = labelPoint
				}
			};

			pieChart1.LegendLocation = LegendLocation.Bottom;
		}

		private void cbDeThi_SelectedValueChanged(object sender, EventArgs e)
		{
			ComboBox cb = sender as ComboBox;
			if(cb.SelectedValue != null)
			{
				selectedIdDeThi = Convert.ToInt32(cb.SelectedValue);
				soLuongHsDaNopBai = tkBus.getSlHSDaNopBai(lopDTO.MaLop, selectedIdDeThi);
				loadPieChart();
			}

		}
	}
}
