﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        CauTraLoiBUS ctlBus;
        string hanhDong;
        private MonHocDTO selectedMonHoc;
        private string selectedDoKho;
        private int selectedSoDapAn;
        private CauHoiDTO cauHoiObj;
        private List<CauTraLoiDTO> listctl;
        public fThemCauHoi(CauHoiUserControl ch, string hanhDong, CauHoiDTO obj = null, List<CauTraLoiDTO> list = null)
        {
            InitializeComponent();
            cauHoiUserControl = ch;
            chBus = new CauHoiBUS();
            mhBus = new MonHocBUS();
            ctlBus = new CauTraLoiBUS();
            listctl = list;
            loadComboBoxDoKho();
            loadComboBoxMonHoc();
            loadComboBoxSoDapAn();
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
            if (hanhDong.Equals("add"))
            {
                this.tabPage1.Text = "Thêm thủ công";
            }
            if (hanhDong.Equals("edit"))
            {
                this.tabPage1.Text = "Cập nhật câu hỏi";
                if (listctl.Count == 2)
                {
                    checkDA3.Visible = false;
                    txtInputDA3.Visible = false;
                    checkDA4.Visible = false;
                    txtInputDA4.Visible = false;
                    cbSoDapAn.SelectedIndex = 0;
                }
            }
            if (hanhDong.Equals("view"))
            {
                this.Text = "Chi tiết câu hỏi";
                btnLuu.Visible = false;
                comboBoxDoKho.Enabled = false;
                comboBoxMonHoc.Enabled = false;
                cbSoDapAn.Enabled = false;
                txtNoiDung.Enabled = false;
                if(listctl.Count == 2)
                {
                    checkDA3.Visible = false;
                    txtInputDA3.Visible = false;
                    checkDA4.Visible = false;
                    txtInputDA4.Visible = false;
                }
            }

            if (listctl != null)
            {
                CheckBox[] checkboxes = { checkDA1, checkDA2, checkDA3, checkDA4 };
                if (listctl.Count == 2 || listctl.Count == 4) // Kiểm tra số lượng phần tử trong listctl
                {
                    for (int i = 0; i < listctl.Count; i++) // Bắt đầu từ 0
                    {
                        TextBox textBox = this.Controls.Find("txtInputDA" + (i + 1), true).FirstOrDefault() as TextBox;
                        if (textBox != null)
                        {
                            textBox.Text = listctl[i].NoiDung;
                        }
                        if (listctl[i].DapAn)
                        {
                            checkboxes[i].Checked = true;
                        }
                        if (hanhDong.Equals("view"))
                        {
                            textBox.Enabled = false;
                            checkboxes[i].Enabled = false;
                        }
                    }
                }
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
                        int mch = chBus.GetAutoIncrement();
                        CauHoiDTO c = new CauHoiDTO(mch, txtNoiDung.Text, selectedDoKho, selectedMonHoc.MaMonHoc, 1, 1);
                        cauHoiUserControl.AddCauHoi(c);
                        this.AddCauTraLoi(selectedSoDapAn, mch);
                        this.Close();
                        MessageBox.Show("Thêm câu hỏi thành công!");
                        this.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else if (hanhDong.Equals("edit"))
            {
                if (selectedSoDapAn == 2 && listctl.Count == 4)
                {

                    if (listctl[2].DapAn == true || listctl[3].DapAn == true)
                    {
                        checkDA3.Checked = false;
                        checkDA4.Checked = false;
                    }
                    DeleteCauTraLoi(listctl[2].MaCauTraLoi);
                    DeleteCauTraLoi(listctl[3].MaCauTraLoi);
                    listctl.RemoveAt(2);
                    int count = listctl.Count;
                    listctl.RemoveAt(count - 1);
                }
                if (checkValidInput())
                {
                    try
                    {
                        CauHoiDTO c = new CauHoiDTO(cauHoiObj.MaCauHoi, txtNoiDung.Text, selectedDoKho, selectedMonHoc.MaMonHoc, 1, 1);
                        cauHoiUserControl.UpdateCauHoi(c);

                        UpdateCauTraLoi(listctl);
                        this.Close();
                        MessageBox.Show("Cập nhật câu hỏi thành công!");
                        this.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        public void AddCauTraLoi(int soCauTraLoi, int maCauHoi)
        {
            for (int i = 1; i <= soCauTraLoi; i++)
            {
                CheckBox currentCheckBox = this.Controls.Find("checkDA" + i, true).FirstOrDefault() as CheckBox;
                TextBox currentTextBox = this.Controls.Find("txtInputDA" + i, true).FirstOrDefault() as TextBox;

                if (currentCheckBox != null && currentTextBox != null)
                {
                    bool dapAn = currentCheckBox.Checked;
                    string noiDung = currentTextBox.Text;

                    CauTraLoiDTO cauTraLoi = new CauTraLoiDTO(ctlBus.GetAutoIncrement(), maCauHoi, noiDung, dapAn, 1);
                    ctlBus.Add(cauTraLoi);
                }
            }
        }

        public void UpdateCauTraLoi(List<CauTraLoiDTO> l)
        {
            int count = l.Count;
            int t = -1;
            if (selectedSoDapAn == 4 && count == 2)
            {
                count = selectedSoDapAn;
                t = 1;
            }

            for (int i = 0; i < count; i++)
            {
                bool dapAn = (i == 0) ? checkDA1.Checked :
                             (i == 1) ? checkDA2.Checked :
                             (i == 2) ? checkDA3.Checked :
                                        checkDA4.Checked;

                string noiDung = (i == 0) ? txtInputDA1.Text :
                                 (i == 1) ? txtInputDA2.Text :
                                 (i == 2) ? txtInputDA3.Text :
                                            txtInputDA4.Text;
                
                if ((i == 2 || i == 3) && t != -1)
                {
                    CauTraLoiDTO cauTraLoiUP = new CauTraLoiDTO(ctlBus.GetAutoIncrement(), l[0].MaCauHoi, noiDung, dapAn, 1);
                    ctlBus.Add(cauTraLoiUP);
                }
                else
                {
                    CauTraLoiDTO cauTraLoi = new CauTraLoiDTO(l[i].MaCauTraLoi, l[i].MaCauHoi, noiDung, dapAn, 1);
                    ctlBus.Update(cauTraLoi);
                }
            }
        }

        public void DeleteCauTraLoi(int id)
        {
            ctlBus.Delete(id);
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

        private void loadComboBoxSoDapAn()
        {
            List<int> listsda = new List<int> { 2, 4 };
            cbSoDapAn.DataSource = listsda;
            cbSoDapAn.SelectedIndex = 1;
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

        private void cbSoDapAn_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                selectedSoDapAn = Convert.ToInt32(cb.SelectedValue);
                if (selectedSoDapAn == 2)
                {
                    checkDA3.Visible = false;
                    txtInputDA3.Visible = false;
                    checkDA4.Visible = false;
                    txtInputDA4.Visible = false;
                }
                if (selectedSoDapAn == 4)
                {
                    checkDA3.Visible = true;
                    txtInputDA3.Visible = true;
                    checkDA4.Visible = true;
                    txtInputDA4.Visible = true;
                }
            }
        }

        private bool checkValidInput()
        {
            // check chi chon 1 cau tra loi
            int selectedCount = 0;

            if (checkDA3.Checked)
            {
                selectedCount++;
            }

            if (checkDA4.Checked)
            {
                selectedCount++;
            }

            if(selectedSoDapAn == 2)
            {
                selectedCount = 0;
            }

            if (checkDA1.Checked)
            {
                selectedCount++;
            }

            if (checkDA2.Checked)
            {
                selectedCount++;
            }



            // check nhung cai khac
            if (selectedCount != 1)
            {
                MessageBox.Show("Hãy chọn 1 một câu đúng và không được chọn nhiều hơn!");
                return false;
            }
            else if (string.IsNullOrEmpty(txtNoiDung.Text))
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
            else if (selectedSoDapAn == 2)
            {
                if (string.IsNullOrEmpty(txtInputDA1.Text))
                {
                    MessageBox.Show("Không được để trống câu trả lời!");
                    return false;
                }
                if (string.IsNullOrEmpty(txtInputDA2.Text))
                {
                    MessageBox.Show("Không được để trống câu trả lời!");
                    return false;
                }
                if (!checkDA1.Checked && !checkDA2.Checked)
                {
                    MessageBox.Show("Hãy click vào checkBox trước để chọn câu đúng!");
                    return false;
                }
            }
            else if (selectedSoDapAn == 4)
            {
                if (string.IsNullOrEmpty(txtInputDA1.Text))
                {
                    MessageBox.Show("Không được để trống câu trả lời!");
                    return false;
                }
                if (string.IsNullOrEmpty(txtInputDA2.Text))
                {
                    MessageBox.Show("Không được để trống câu trả lời!");
                    return false;
                }
                if (string.IsNullOrEmpty(txtInputDA3.Text))
                {
                    MessageBox.Show("Không được để trống câu trả lời!");
                    return false;
                }
                if (string.IsNullOrEmpty(txtInputDA4.Text))
                {
                    MessageBox.Show("Không được để trống câu trả lời!");
                    return false;
                }
                if (!checkDA1.Checked && !checkDA2.Checked && !checkDA3.Checked && !checkDA4.Checked)
                {
                    MessageBox.Show("Hãy click vào checkBox trước để chọn câu đúng!");
                    return false;
                }
            }
            return true;
        }

		private void btnThem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Chọn File";
			openFileDialog.Filter = "Word Document|*.docx";

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string selectedFilePath = openFileDialog.FileName;
				MessageBox.Show("File được chọn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

				string content = chBus.ImportFromWord(selectedFilePath);

				if (!string.IsNullOrEmpty(content))
				{
					Regex monHoc = new Regex(@"Môn học: (.+?)(?=Câu \d+: |$)", RegexOptions.Singleline);
					Regex cauHoiRegex = new Regex(@"Câu \d+: (.*?)(?=Câu \d+:|$)", RegexOptions.Singleline);
					Regex cauTraLoiRegex = new Regex(@"[A-D]\. (.+?)(?=[A-D]|\n|$|Câu \d+:|$)", RegexOptions.Singleline);
					List<string> underlinedSentences = chBus.ExtractUnderlinedSentences(selectedFilePath);
					string underlineText = string.Join("\n", underlinedSentences);

					bool foundSubject = false;
					MatchCollection monHocMatches = monHoc.Matches(content);
					foreach (Match monHocMatch in monHocMatches)
					{
						foundSubject = true;
						string subject = monHocMatch.Groups[1].Value;
						MonHocDTO t = mhBus.getAll().FirstOrDefault(mh => mh.TenMonHoc.ToLower().Equals(subject.ToLower()));
						if (t == null)
						{
							MonHocDTO obj = new MonHocDTO(mhBus.GetAutoIncrement(), subject, 1);
							mhBus.Add(obj);
							t = obj;
						}
						StringBuilder combinedText = new StringBuilder();
						for (char currentAnswerKey = 'A'; currentAnswerKey <= 'D'; currentAnswerKey++)
						{
							foreach (string sentence in underlinedSentences)
							{
								if (sentence.Length > 2 && sentence[1] == '.')
								{
									currentAnswerKey = sentence[0];
									combinedText.AppendLine(sentence);
								}
								else
								{
									combinedText.AppendLine(currentAnswerKey + ". " + sentence);
								}
							}
						}
						string result = combinedText.ToString();
						MatchCollection cauHoiMatches = cauHoiRegex.Matches(content);

						foreach (Match cauHoiMatch in cauHoiMatches)
						{
							string question = cauHoiMatch.Groups[1].Value.Trim();
							List<string> answers = new List<string>();

							MatchCollection cauTraLoiMatches = cauTraLoiRegex.Matches(cauHoiMatch.Value);
							foreach (Match cauTraLoiMatch in cauTraLoiMatches)
							{
								string answer = cauTraLoiMatch.Value.Trim();
								answer = Regex.Replace(answer, @"^[A-D]\.\s*", "");
								answers.Add(answer);
							}
							Match matchdoKho = Regex.Match(question, @"(\*\*|\*)\s*");
							string doKho = matchdoKho.Success ? (matchdoKho.Groups[1].Value == "**" ? "Khó" : "Bình thường") : "Dễ";
							//
							Regex regex = new Regex(@"^(.*?)A\.");
							Match match = regex.Match(question);
							Regex regex1 = new Regex(@"[A-D]\. (.+)");
							if (match.Success)
							{
								string questiondtb = match.Groups[1].Value.Trim();

								// Thêm câu hỏi vào database
								int mch = chBus.GetAutoIncrement();
								CauHoiDTO ch = new CauHoiDTO(mch, questiondtb, doKho, t.MaMonHoc, 1, 1);
								chBus.Add(ch);

								// Thêm các câu trả lời vào database
								for (int i = 0; i < answers.Count; i++)
								{
									bool isCorrect = result.Contains(answers[i]);
									CauTraLoiDTO ctl = new CauTraLoiDTO(ctlBus.GetAutoIncrement(), mch, answers[i], isCorrect, 1);
									ctlBus.Add(ctl);
								}
							}
						}

					}
					if (!foundSubject)
					{
						MessageBox.Show("File Word không chứa thông tin môn học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					MessageBox.Show("Thêm dữ liệu từ file thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Dispose();
				}
				else
				{
					MessageBox.Show("File Word không chứa nội dung", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
