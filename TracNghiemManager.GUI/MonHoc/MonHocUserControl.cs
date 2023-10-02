using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracNghiemManager.BUS;
using TracNghiemManager.DTO;

namespace TracNghiemManager.GUI.MonHoc
{
    public partial class MonHocUserControl : UserControl
    {
        DataTable dt;
        MonHocBUS mhBus;
        private List<MonHocDTO> listmh;
        private int idSelected; // id của row được select
        private int index; // row được select
        public MonHocUserControl()
        {
            InitializeComponent();
            dt = new DataTable();
            mhBus = new MonHocBUS();
            listmh = mhBus.getAll();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Tên môn học", typeof(string));
            loadDataTable(listmh);
        }

        public void loadDataTable(List<MonHocDTO> list)
        {
            listmh = list;
            dt.Clear();
            foreach (MonHocDTO obj in listmh)
            {
                DataRow row = dt.NewRow();
                row["ID"] = obj.MaMonHoc;
                row["Tên môn học"] = obj.TenMonHoc;
                dt.Rows.Add(row);
            }
            dataGridView1.DataSource = dt;
            // Thêm sự kiện DataBindingComplete vào DataGridView
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
        }

        public void AddMonHoc(MonHocDTO obj)
        {
            mhBus.Add(obj);
            listmh.Add(obj);
            DataRow row = dt.NewRow();
            row["ID"] = obj.MaMonHoc;
            row["Tên môn học"] = obj.TenMonHoc;
            dt.Rows.Add(row);
        }

        public void UpdateMonHoc(MonHocDTO obj)
        {
            // Cập nhật trên dtb
            mhBus.Update(obj);
            // Cập nhật trên list
            listmh.RemoveAt(index); // Xóa tại vị trí index
            listmh.Insert(index, obj); // Thêm tại vị trí index
            loadDataTable(listmh);
        }

        public void DeleteMonHoc(int id)
        {
            // Xõa trên dtb
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa môn học không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                mhBus.Delete(id);
                listmh.RemoveAt(index);
                loadDataTable(listmh);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemMonHoc fthem = new fThemMonHoc(this, "add");
            fthem.Visible = true;
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            MonHocDTO mh = mhBus.getById(idSelected);
            if(mh == null)
            {
                MessageBox.Show("Chưa chọn hàng cần chỉnh sửa!");
            } else
            {
                fThemMonHoc fthem = new fThemMonHoc(this, "edit", mh);
                fthem.Visible = true;
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DeleteMonHoc(idSelected);
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            listmh = mhBus.getAll();
            loadDataTable(listmh);
            textBoxTimKiem.Text = "";
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.Columns.Contains("Tênmônhọc"))
            {
                dataGridView1.Columns["Tênmônhọc"].HeaderText = "Tên môn học";
                dataGridView1.Columns["Tênmônhọc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }

            if (dataGridView1.Columns.Contains("Tên môn học"))
            {
                dataGridView1.Columns["Tên môn học"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        public void Search()
        {
            try
            {
                List<MonHocDTO> listMonHocTimKiem = listmh.Where(mh => mh.TenMonHoc.Contains(textBoxTimKiem.Text)).ToList();
                var listMonHocTimKiemFilter = listMonHocTimKiem.Select(mh => new
                {
                    ID = mh.MaMonHoc,
                    Tênmônhọc = mh.TenMonHoc,
                }).ToList();

                // Đặt nguồn dữ liệu cho DataGridView
                dataGridView1.DataSource = listMonHocTimKiemFilter;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                dataGridView1.DataSource = listmh.ToList();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}
