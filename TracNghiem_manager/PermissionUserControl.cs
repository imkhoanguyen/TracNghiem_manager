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
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;

namespace TracNghiem_manager
{
    public partial class PermissionUserControl : UserControl
    {

        public PermissionUserControl()
        {
            InitializeComponent();
            RenderDataToDatabase();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RenderDataToDatabase()
        {
            List<ChiTietQuyenDTO> list = ChiTietQuyenDAO.Instance.GetAll();
            DataTable dtFull = new DataTable();
            dtFull.Columns.Add("user id");
            dtFull.Columns.Add("họ và tên");
            DataTable dtCreate = new DataTable();
            dtCreate.Columns.Add("user id");
            dtCreate.Columns.Add("họ và tên");
            DataTable dtEdit = new DataTable();
            dtEdit.Columns.Add("user id");
            dtEdit.Columns.Add("họ và tên");

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ten_quyen.Equals("full"))
                {
                    dtFull.Rows.Add(new object[] { list[i].user_id, list[i].ho_va_ten });
                }
                if (list[i].ten_quyen.Equals("create"))
                {
                    dtCreate.Rows.Add(new object[] { list[i].user_id, list[i].ho_va_ten });
                }
                if (list[i].ten_quyen.Equals("edit"))
                {
                    dtEdit.Rows.Add(new object[] { list[i].user_id, list[i].ho_va_ten });
                }
            }
            dataGridView1.DataSource = dtFull;
            dataGridView2.DataSource = dtCreate;
            dataGridView3.DataSource = dtEdit;
        }
        public void AdminCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                int ma_nguoi_dung = Convert.ToInt32(dataGridView1.Rows[row].Cells["user id"].Value);

                List<QuyenDTO> listQuyen = QuyenDAO.instance.GetQuyenByUserId(ma_nguoi_dung);
                List<ChucNangDTO> listChucNang;

                for (int i = 0; i < listQuyen.Count; i++)
                {
                    listBox2.Items.Add(listQuyen[i].ten_quyen);
                    listChucNang = ChucNangDAO.Instance.GetChucNangTuMaQuyen(listQuyen[i].ma_quyen);
                    for (int j = 0; j < listChucNang.Count; j++)
                    {
                        listBox1.Items.Add(listChucNang[j].ten_chuc_nang);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
