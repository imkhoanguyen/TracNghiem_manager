﻿using LiveCharts.Wpf;
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
		private List<DiemCuaHS> lDTB;
		private List<string> listHoTenHs;
		private List<double> listDiemTBCuaHs;
		private int soLuongDeThiCoTrongLop;
		private int soLuongHsDaNopBai;
		private List<DeThiCuaLopDTO> listDeThiCuaLop;
		private List<DeThiDTO> listDeThi;
		private int selectedIdDeThi;
		private List<DiemCuaHS> listTop5HsCoDiemCaoNhat;
		private List<string> listTrangThai;
		private string selectedTrangThai;
		private DataTable dt1;
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
			if (listDeThi == null)
			{
				listDeThi = new List<DeThiDTO>();
			}
			if (listTop5HsCoDiemCaoNhat == null)
			{
				listTop5HsCoDiemCaoNhat = new List<DiemCuaHS>();
			}
			if (listTrangThai == null)
			{
				listTrangThai = new List<string> { "Tất cả", "Đã nộp", "Chưa nộp" };
			}
			foreach (DeThiCuaLopDTO item in listDeThiCuaLop)
			{
				listDeThi.Add(dtBus.GetById(item.MaDeThi));
			}
			foreach (DiemCuaHS item in lDTB)
			{
				listHoTenHs.Add(item.HoTen);
				listDiemTBCuaHs.Add(item.Diem / soLuongDeThiCoTrongLop);
			}
			dt = new DataTable();
			dt.Columns.Add("STT", typeof(int));
			dt.Columns.Add("Mã học sinh", typeof(int));
			dt.Columns.Add("Họ và tên", typeof(string));
			dt.Columns.Add("Email", typeof(string));
			//dt2
			dt1 = new DataTable();
			dt1.Columns.Add("STT", typeof(int));
			dt1.Columns.Add("Mã học sinh", typeof(int));
			dt1.Columns.Add("Họ và tên", typeof(string));
			dt1.Columns.Add("Email", typeof(string));
			dt1.Columns.Add("Điểm", typeof (double));
			load();
			loadDataGridView();
			loadCbTrangThai();
			loadCbDeThi();
			loadChartTongQuan();
			loadPieChart(soLuongHsDaNopBai);
			loadChartTop5HsDiemCao();
			StyleDataGridView();

			// Khởi cột giá trị cho biểu đồ thống kê top 5 hs có điểm cao nhất theo đề thi
			SeriesCollection columnSeriesCollection = new SeriesCollection
			{
				new ColumnSeries
				{
					Title = "Điểm",
					Values = new ChartValues<double>(),
				}
			};
			cartesianChart2.Series = columnSeriesCollection;
		}

		private void load()
		{
			lblCountSLDeThi.Text = soLuongDeThiCoTrongLop.ToString();
		}

		private void loadCbDeThi()
		{
			cbDeThi.ValueMember = "MaDeThi";
			cbDeThi.DisplayMember = "TenDeThi";
			cbDeThi.DataSource = listDeThi;
			cbDeThi.SelectedIndex = 0;
		}

		private void loadCbTrangThai()
		{
			cbTrangThai.DataSource = listTrangThai;
			cbTrangThai.SelectedIndex = 0;
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
		private void loadDataGridView2()
		{
			dt1.Clear();
			int stt = 1;
			foreach (HocSinhTrongLop hs in lHocSinhTrongLop)
			{
				double diem = tkBus.getDiemCuaDeThiByUserId(lopDTO.MaLop, selectedIdDeThi, hs.MaHocSinh);
				if(selectedTrangThai.Equals("Tất cả"))
				{
					DataRow row = dt1.NewRow();
					row["STT"] = stt;
					row["Mã học sinh"] = hs.MaHocSinh;
					row["Họ và tên"] = hs.HoTen;
					row["Email"] = hs.Email;
					row["Điểm"] = diem;
					dt1.Rows.Add(row);
					stt++;
				} else if(selectedTrangThai.Equals("Đã nộp"))
				{
					if(diem != -1)
					{
						DataRow row = dt1.NewRow();
						row["STT"] = stt;
						row["Mã học sinh"] = hs.MaHocSinh;
						row["Họ và tên"] = hs.HoTen;
						row["Email"] = hs.Email;
						row["Điểm"] = diem;
						dt1.Rows.Add(row);
					}
				} else if(selectedTrangThai.Equals("Chưa nộp"))
				{
					if(diem == -1)
					{
						DataRow row = dt1.NewRow();
						row["STT"] = stt;
						row["Mã học sinh"] = hs.MaHocSinh;
						row["Họ và tên"] = hs.HoTen;
						row["Email"] = hs.Email;
						row["Điểm"] = diem;
						dt1.Rows.Add(row);
					}
				}
				
			}
			dataGridView2.DataSource = dt1;
		}
		private void StyleDataGridView()
		{
			dataGridView1.RowTemplate.Height = 30;
			dataGridView1.Columns["STT"].Width = 50;
			dataGridView1.Columns["Mã học sinh"].Width = 150;
			dataGridView1.Columns["Họ và tên"].Width = 300;
			dataGridView1.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			// 
			dataGridView2.RowTemplate.Height = 30;
			dataGridView2.Columns["STT"].Width = 50;
			dataGridView2.Columns["Mã học sinh"].Width = 150;
			dataGridView2.Columns["Họ và tên"].Width = 300;
			dataGridView2.Columns["Điểm"].Width = 100;
			dataGridView2.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

		private void loadPieChart(int slhsdn)
		{
			slhsdn = soLuongHsDaNopBai;
			Func<ChartPoint, string> labelPoint = chartPoint =>
		string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

			pieChart1.Series = new SeriesCollection
			{
				new PieSeries
				{
					Title = "Đã nộp bài",
					Values = new ChartValues<int> {slhsdn},
					DataLabels = true,
					LabelPoint = labelPoint
				},
				new PieSeries
				{
					Title = "Chưa nộp bài",
					Values = new ChartValues<int> {lHocSinhTrongLop.Count - slhsdn},
					DataLabels = true,
					LabelPoint = labelPoint
				}
			};

			pieChart1.LegendLocation = LegendLocation.Bottom;
		}

		private void cbDeThi_SelectedValueChanged(object sender, EventArgs e)
		{
			ComboBox cb = sender as ComboBox;
			if (cb.SelectedValue != null)
			{
				selectedIdDeThi = Convert.ToInt32(cb.SelectedValue);
				soLuongHsDaNopBai = tkBus.getSlHSDaNopBai(lopDTO.MaLop, selectedIdDeThi);
				loadPieChart(soLuongHsDaNopBai);
				loadChartTop5HsDiemCao();
				loadDataGridView2();
			}
		}

		private void loadChartTop5HsDiemCao()
		{
			if (cartesianChart2.Series.Any())
			{
				var columnSeries = cartesianChart2.Series[0] as ColumnSeries;
				if (columnSeries == null)
				{
					return; // Đảm bảo rằng Series tồn tại
				}

				listTop5HsCoDiemCaoNhat = tkBus.getTop5HsCoDiemCaoNhatTheoDeThi(lopDTO.MaLop, selectedIdDeThi);
				List<double> lDiem = new List<double>();
				List<string> lname = new List<string>();
				foreach (DiemCuaHS item in listTop5HsCoDiemCaoNhat)
				{
					lDiem.Add(item.Diem);
					lname.Add(item.HoTen);
				}

				// Cập nhật giá trị của Series hiện có
				columnSeries.Values = lDiem.Select(value => (double)value).AsChartValues();

				// Kiểm tra xem AxisX đã tồn tại
				if (cartesianChart2.AxisX.Count > 0)
				{
					// Nếu tồn tại, xóa nó đi
					cartesianChart2.AxisX.Clear();
				}

				// Tạo một Axis mới cho cột X
				cartesianChart2.AxisX.Add(new Axis
				{
					Title = "Họ tên học sinh",
					Labels = lname
				});
			}
		}

		private void cbTrangThai_SelectedValueChanged(object sender, EventArgs e)
		{
			ComboBox cb = sender as ComboBox;
			if (cb.SelectedValue != null)
			{
				selectedTrangThai = cb.SelectedValue.ToString();
				loadDataGridView2();
			}
		}
	}
}
