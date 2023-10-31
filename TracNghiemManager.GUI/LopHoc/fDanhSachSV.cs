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

namespace TracNghiemManager.GUI.LopHoc
{
	public partial class fDanhSachSV : Form
	{
		private ChiTietLopBUS ctlBus;
		private List<HocSinhTrongLop> lHocSinhTrongLop;
		private LopDTO lopDTO;
		private DataTable dt;
		public fDanhSachSV(LopDTO l)
		{
			InitializeComponent();
			ctlBus = new ChiTietLopBUS();
			lopDTO = l;
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
				new LineSeries
				{
					Title = "Series 1",
					Values = new ChartValues<double> {4, 6, 5, 2, 7}
				},
				new LineSeries
				{
					Title = "Series 2",
					Values = new ChartValues<double> {6, 7, 3, 4, 6},
					PointGeometry = null
				},
				new LineSeries
				{
					Title = "Series 2",
					Values = new ChartValues<double> {5, 2, 8, 3},
					PointGeometry = DefaultGeometries.Square,
					PointGeometrySize = 15
				}
			};

			cartesianChart1.AxisX.Add(new Axis
			{
				Title = "Month",
				Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
			});

			cartesianChart1.AxisY.Add(new Axis
			{
				Title = "Sales",
				LabelFormatter = value => value.ToString("C")
			});

			cartesianChart1.LegendLocation = LegendLocation.Right;

			//modifying the series collection will animate and update the chart
			cartesianChart1.Series.Add(new LineSeries
			{
				Values = new ChartValues<double> { 5, 3, 2, 4, 5 },
				LineSmoothness = 0, //straight lines, 1 really smooth lines
				PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
				PointGeometrySize = 50,
				PointForeground = System.Windows.Media.Brushes.Gray
			});

			//modifying any series values will also animate and update the chart
			cartesianChart1.Series[2].Values.Add(5d);

		}
	}
}
