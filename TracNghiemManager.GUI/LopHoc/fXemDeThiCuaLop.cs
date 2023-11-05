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

namespace TracNghiemManager.GUI.LopHoc
{
    public partial class fXemDeThiCuaLop : Form
    {
        ChiTietDeThiDTO ctdt;
        ChiTietDeThiBUS ctdtBus;
        CauHoiBUS chBus;
        List<CauHoiDTO> listch;
        MonHocBUS mhBus;
        DeThiDTO deThi;
        DeThiCuaLopBUS dtclBus;
        fChiTietLop fctl;
        fDanhSachDeThi fdsdt;
        MonHocDTO mh;
        DataTable dt;

        public fXemDeThiCuaLop(fDanhSachDeThi ds,DeThiDTO obj )
        {
            InitializeComponent();
            ctdtBus = new ChiTietDeThiBUS();
            dt = new DataTable();
            mhBus=new MonHocBUS();
            chBus=new CauHoiBUS();
            mh=new MonHocDTO();
            deThi = obj;
            mh=new MonHocDTO();
            
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            listch = ctdtBus.GetAllCauHoiOfDeThi(deThi.MaDeThi);
            //listch = chBus.getAll();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nội dung câu hỏi", typeof(string)); 
            dt.Columns.Add("Môn học", typeof(string));
            dt.Columns.Add("Độ khó", typeof(string));
            loadDataTable(listch);
            loadCHDT();
        }
        public void loadCHDT()
        {
            lblTenDeThi1.Text = deThi.TenDeThi;
            lblTenMonHoc.Text = mhBus.getById(deThi.MaMonHoc).TenMonHoc;
            lblThoiGianLamBai.Text = deThi.ThoiGianLamBai + " phút";
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
            dataGridView1.DataSource = dt;
            // Thêm sự kiện DataBindingComplete vào DataGridView
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
        }

        public void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

    }
}
