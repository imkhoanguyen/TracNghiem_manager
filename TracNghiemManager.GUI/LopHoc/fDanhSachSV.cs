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

namespace TracNghiemManager.GUI.LopHoc
{
    public partial class fDanhSachSV : Form
    {
        internal List<string> monThiList;
        LopDTO lopDTO;
        private UserBUS userBus;
        public fDanhSachSV(LopDTO l)
        {
            InitializeComponent();
            userBus = new UserBUS();
            lopDTO = l;
            InitDataGridView(lopDTO);

        }
        private void InitDataGridView(LopDTO l)
        {
            tableSV.Columns.Add("id", "ID");
            tableSV.Columns.Add("hovaten", "Họ Tên");

            Dictionary<int, List<Tuple<string, string, float>>> dict = userBus.GetName(l.MaLop);

             monThiList = new List<string>();

            // Tạo danh sách các môn thi từ Dictionary
            foreach (var entry in dict)
            {
                foreach (Tuple<string, string, float> info in entry.Value)
                {
                    string monThi = info.Item2;
                    if (!monThiList.Contains(monThi))
                    {
                        monThiList.Add(monThi);
                    }
                }
            }

            //Thêm cột header cho mỗi môn thi
            foreach (string monThi in monThiList)
            {
                tableSV.Columns.Add(monThi, monThi);
            }

			tableSV.Columns["hovaten"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			foreach (var entry in dict)
            {
                int id = entry.Key;
                List<Tuple<string, string, float>> infoList = entry.Value;

                // Thêm dữ liệu vào DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Đặt giá trị cho các ô của hàng
                row.CreateCells(tableSV);
                row.Cells[0].Value = id;
                row.Cells[1].Value = infoList[0].Item1;

                for (int i = 0; i < monThiList.Count; i++)
                {
                    Tuple<string, string, float> info = infoList.FirstOrDefault(x => x.Item2 == monThiList[i]);
                    if (info != null)
                    {
                        row.Cells[i + 2].Value = info.Item3.ToString("F2");
                        row.Cells[i + 2].Style.Format = "F2";
                    }
                    else
                    {
                        row.Cells[i + 2].Value = " ";
                    }
                }

                // Thêm hàng vào bảng
                tableSV.Rows.Add(row);
            }


        }

		private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
		{

		}

		
	}
}
