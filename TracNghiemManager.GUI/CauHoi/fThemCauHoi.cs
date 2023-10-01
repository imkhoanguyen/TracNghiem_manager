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

namespace TracNghiemManager.GUI.CauHoi
{
    public partial class fThemCauHoi : Form
    {
        CauHoiUserControl cauHoiUserControl;
        CauHoiBUS chBus;
        MonHocBUS mhBus;
        string hanhDong;
        private MonHocDTO selectedMonHoc;
        private string selectedDoKho;
        private CauHoiDTO cauHoiObj;
        public fThemCauHoi(CauHoiUserControl ch, string hanhDong, CauHoiDTO obj = null)
        {
            InitializeComponent();
            cauHoiUserControl = ch;
            chBus = new CauHoiBUS();
            mhBus = new MonHocBUS();
            loadComboBoxDoKho();
            loadComboBoxMonHoc();
            this.hanhDong = hanhDong;
            cauHoiObj = obj;
            if (cauHoiObj != null)
            {
                txtNoiDung.Text = cauHoiObj.NoiDung;

                // Thiết lập giá trị cho comboBoxMonHoc
                comboBoxMonHoc.SelectedValue = cauHoiObj.MaMonHoc;
                // Thiết lập giá trị được hiển thị trong comboBox
                comboBoxMonHoc.DisplayMember = "TenMonHoc";

                // Thiết lập giá trị cho comboBoxDoKho
                comboBoxDoKho.SelectedItem = cauHoiObj.DoKho;
            }
            if(hanhDong.Equals("add"))
            {
                this.tabPage1.Text = "Thêm thủ công";
            }
            if (hanhDong.Equals("edit"))
            {
                this.tabPage1.Text = "Cập nhật câu hỏi";
            }
            if (hanhDong.Equals("view"))
            {
                this.Text = "Chi tiết câu hỏi";
                btnLuu.Visible = false;
                comboBoxDoKho.Enabled = false;
                comboBoxMonHoc.Enabled = false;
                txtNoiDung.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Add câu hỏi
            if (hanhDong.Equals("add"))
            {
                if (checkValidInput())
                {
                    try
                    {
                        CauHoiDTO c = new CauHoiDTO(chBus.GetAutoIncrement(), txtNoiDung.Text, selectedDoKho, selectedMonHoc.MaMonHoc, 1, 1);
                        cauHoiUserControl.AddCauHoi(c);
                        this.Close();
                        MessageBox.Show("Thêm câu hỏi thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else if (hanhDong.Equals("edit"))
            {
                if (checkValidInput())
                {
                    try
                    {
                        CauHoiDTO c = new CauHoiDTO(cauHoiObj.MaCauHoi, txtNoiDung.Text, selectedDoKho, selectedMonHoc.MaMonHoc, 1, 1);
                        cauHoiUserControl.UpdateCauHoi(c);
                        this.Close();
                        MessageBox.Show("Cập nhật câu hỏi thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }


        }

        private void loadComboBoxMonHoc()
        {
            comboBoxMonHoc.ValueMember = "MaMonHoc";
            comboBoxMonHoc.DisplayMember = "TenMonHoc";
            List<MonHocDTO> listmh = mhBus.getAll();
            comboBoxMonHoc.DataSource = listmh;

        }
        private void loadComboBoxDoKho()
        {
            List<string> listdk = new List<string> { "Dễ", "Bình thường", "Khó" };
            comboBoxDoKho.DataSource = listdk;
        }

        private void comboBoxMonHoc_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                selectedMonHoc = mhBus.getById(Convert.ToInt32(cb.SelectedValue));
            }
        }

        private void comboBoxDoKho_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                selectedDoKho = cb.SelectedValue.ToString();
            }
        }
        private bool checkValidInput()
        {
            if (string.IsNullOrEmpty(txtNoiDung.Text))
            {
                MessageBox.Show("Không được để trống nội dung câu hỏi!");
                return false;
            }
            else if (selectedMonHoc == null)
            {
                MessageBox.Show("Hãy chọn nội dung chọn môn học");
                return false;
            }
            else if (selectedDoKho == null)
            {
                MessageBox.Show("Hãy chọn độ khó của câu hỏi!");
                return false;
            }
            return true;
        }


    }
}
