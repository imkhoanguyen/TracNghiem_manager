using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TracNghiemManager.BUS;
using TracNghiemManager.DTO;
using Word = Microsoft.Office.Interop.Word;

namespace TracNghiemManager.GUI.CauHoi
{
	public partial class fThemCauHoi : Form
	{
		private CauHoiUserControl cauHoiUserControl;
		private CauHoiBUS chBus;
		private MonHocBUS mhBus;
		private CauTraLoiBUS ctlBus;
		private string hanhDong;
		private MonHocDTO selectedMonHoc;
		private string selectedDoKho;
		private int selectedSoDapAn;
		private CauHoiDTO cauHoiObj;
		private List<CauTraLoiDTO> listctl;
		private bool allowTabControl2 = true;
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
			loadcbMonHoc();
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
				this.Text = "Cập nhật câu hỏi";
				this.tabPage1.Text = "Cập nhật câu hỏi";
				if (listctl.Count == 2)
				{
					rb3.Visible = false;

					txtInputDA3.Visible = false;
					rb4.Visible = false;
					txtInputDA4.Visible = false;
					cbSoDapAn.SelectedIndex = 0;

				}
				tabPage2.Text = "";
			}
			if (hanhDong.Equals("view"))
			{
				this.tabPage1.Text = "Chi tiết câu hỏi";
				this.Text = "Chi tiết câu hỏi";
				btnLuu.Visible = false;
				comboBoxDoKho.Enabled = false;
				comboBoxMonHoc.Enabled = false;
				cbSoDapAn.Enabled = false;
				txtNoiDung.Enabled = false;
				if (listctl.Count == 2)
				{
					rb3.Visible = false;
					txtInputDA3.Visible = false;
					rb4.Visible = false;
					txtInputDA4.Visible = false;
					cbSoDapAn.SelectedIndex = 0;
				}
				tabPage2.Text = "";

			}

			if (listctl != null)
			{
				RadioButton[] checkboxes = { rb1, rb2, rb3, rb4 };
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

		public fThemCauHoi(string hanhDong, CauHoiDTO obj = null, List<CauTraLoiDTO> list = null)
		{
			InitializeComponent();
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
			if (hanhDong.Equals("view"))
			{
				this.tabPage1.Text = "Chi tiết câu hỏi";
				this.Text = "Chi tiết câu hỏi";
				btnLuu.Visible = false;
				comboBoxDoKho.Enabled = false;
				comboBoxMonHoc.Enabled = false;
				cbSoDapAn.Enabled = false;
				txtNoiDung.Enabled = false;
				if (listctl.Count == 2)
				{
					rb3.Visible = false;
					txtInputDA3.Visible = false;
					rb4.Visible = false;
					txtInputDA4.Visible = false;
					cbSoDapAn.SelectedIndex = 0;
				}
				tabPage2.Text = "";

			}

			if (listctl != null)
			{
				RadioButton[] checkboxes = { rb1, rb2, rb3, rb4 };
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
						CauHoiDTO c = new CauHoiDTO(mch, txtNoiDung.Text, selectedDoKho, selectedMonHoc.MaMonHoc, Form1.USER_ID, 1);
						cauHoiUserControl.AddCauHoi(c);
						this.AddCauTraLoi(selectedSoDapAn, mch);
						this.Close();
						MessageBox.Show("Thêm câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
				if (checkValidInput())
				{
					// Check truong hop cap nhat 4 cau tra loi thanh 2 cau tra loi
					if (selectedSoDapAn == 2 && listctl.Count == 4)
					{

						if (listctl[2].DapAn == true || listctl[3].DapAn == true)
						{
							rb3.Checked = false;
							rb4.Checked = false;
						}
						DeleteCauTraLoi(listctl[2].MaCauTraLoi);
						DeleteCauTraLoi(listctl[3].MaCauTraLoi);
						listctl.RemoveAt(2);
						int count = listctl.Count;
						listctl.RemoveAt(count - 1);
					}
					try
					{
						CauHoiDTO c = new CauHoiDTO(cauHoiObj.MaCauHoi, txtNoiDung.Text, selectedDoKho, selectedMonHoc.MaMonHoc, Form1.USER_ID, 1);
						cauHoiUserControl.UpdateCauHoi(c);

						UpdateCauTraLoi(listctl);
						this.Close();
						MessageBox.Show("Cập nhật câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.Dispose();
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex);
					}
				}
			}
		}

		public void AddCauTraLoi(int soCauTraLoi, int maCauHoi)
		{
			for (int i = 1; i <= soCauTraLoi; i++)
			{
				RadioButton currentCheckBox = this.Controls.Find("rb" + i, true).FirstOrDefault() as RadioButton;
				TextBox currentTextBox = this.Controls.Find("txtInputDA" + i, true).FirstOrDefault() as TextBox;

				if (currentCheckBox != null && currentTextBox != null)
				{
					bool dapAn = currentCheckBox.Checked;
					string noiDung = currentTextBox.Text;
					CauTraLoiDTO cauTraLoi = new CauTraLoiDTO(ctlBus.GetAutoIncrement(), maCauHoi, noiDung, dapAn);
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
				bool dapAn = (i == 0) ? rb1.Checked :
							 (i == 1) ? rb2.Checked :
							 (i == 2) ? rb3.Checked :
										rb4.Checked;

				string noiDung = (i == 0) ? txtInputDA1.Text :
								 (i == 1) ? txtInputDA2.Text :
								 (i == 2) ? txtInputDA3.Text :
											txtInputDA4.Text;
				// check cap nhat cau tra loi tu 2 -> 4
				if ((i == 2 || i == 3) && t != -1)
				{
					CauTraLoiDTO cauTraLoiUP = new CauTraLoiDTO(ctlBus.GetAutoIncrement(), l[0].MaCauHoi, noiDung, dapAn);
					ctlBus.Add(cauTraLoiUP);
				}
				else
				{
					CauTraLoiDTO cauTraLoi = new CauTraLoiDTO(l[i].MaCauTraLoi, l[i].MaCauHoi, noiDung, dapAn);
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
					rb3.Visible = false;
					rb3.Checked = false;
					txtInputDA3.Visible = false;
					rb4.Visible = false;
					rb4.Checked = false;
					txtInputDA4.Visible = false;
				}
				if (selectedSoDapAn == 4)
				{
					rb3.Visible = true;
					txtInputDA3.Visible = true;
					rb4.Visible = true;
					txtInputDA4.Visible = true;
				}
			}
		}

		private bool checkValidInput()
		{

			if (string.IsNullOrEmpty(txtNoiDung.Text))
			{
				MessageBox.Show("Không được để trống nội dung câu hỏi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			else if (selectedMonHoc == null)
			{
				MessageBox.Show("Hãy chọn nội dung chọn môn học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			else if (selectedDoKho == null)
			{
				MessageBox.Show("Hãy chọn độ khó của câu hỏi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			else if (string.IsNullOrEmpty(txtInputDA1.Text))
			{
				MessageBox.Show("Không được để trống câu trả lời!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			else if (string.IsNullOrEmpty(txtInputDA2.Text))
			{
				MessageBox.Show("Không được để trống câu trả lời!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			else if (!rb1.Checked && !rb2.Checked && !rb3.Checked && !rb4.Checked)
			{
				MessageBox.Show("Chưa chọn đáp án đúng cho câu trả lời!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			else if (selectedSoDapAn == 4)
			{

				if (string.IsNullOrEmpty(txtInputDA3.Text))
				{
					MessageBox.Show("Không được để trống câu trả lời!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return false;
				}
				if (string.IsNullOrEmpty(txtInputDA4.Text))
				{
					MessageBox.Show("Không được để trống câu trả lời!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return false;
				}
			}


			return true;
		}

		private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
		{
			if (tabControl1.SelectedTab == tabPage2 && (hanhDong.Equals("edit") || hanhDong.Equals("view")))
			{
				tabControl1.SelectedTab = tabPage1;
				tabPage2.Text = "";
			}
		}

		private void loadcbMonHoc()
		{
			cbMonhoc.ValueMember = "MaMonHoc";
			cbMonhoc.DisplayMember = "TenMonHoc";
			List<MonHocDTO> listmh = mhBus.getAll();
			cbMonhoc.DataSource = listmh;
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


				ProcessQA(selectedFilePath);
				MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Dispose();
			}
		}

		public void ProcessQA(string filePath)
		{
			Word.Application wordApp = new Word.Application();
			Word.Document wordDoc = null;

			try
			{
				wordDoc = wordApp.Documents.Open(filePath, ReadOnly: true);
				string content = wordDoc.Content.Text;

				int currentQuestionNumber = 1;

				string doKho = "Dễ";
				while (true)
				{
					// Tìm vị trí của câu hỏi bắt đầu
					int startCauHoi = content.IndexOf($"Câu {currentQuestionNumber}:");

					if (startCauHoi == -1)
					{
						break;
					}
					// Tìm vị trí của câu hỏi kết thúc
					int endCauHoi = content.IndexOf("Câu", startCauHoi + 1);

					if (endCauHoi == -1)
					{
						endCauHoi = content.Length;
					}
					string question = content.Substring(startCauHoi + $"Câu {currentQuestionNumber}:".Length, endCauHoi - startCauHoi - $"Câu {currentQuestionNumber}:".Length).Trim();
                    Match matchDoKho = question.Contains("**") ? Regex.Match(question, @"\*\*\s*") : Regex.Match(question, @"\*\s*");
					doKho = matchDoKho.Success ? (matchDoKho.Value == "**" ? "Khó" : "Bình thường") : "Dễ";

					// Xử lý câu hỏi
					string questionDTB = question.Split('A')[0].Trim();
					//MessageBox.Show($"Câu hỏi: {questionDTB}");
					int mch = chBus.GetAutoIncrement();
					CauHoiDTO ch = new CauHoiDTO(mch, questionDTB, doKho, selectedMonHoc.MaMonHoc, Form1.USER_ID, 1); //12 là mã môn học
					chBus.Add(ch);

					string[] answerOptions = question.Split(new[] { "A.", "B.", "C.", "D." }, StringSplitOptions.RemoveEmptyEntries);

					for (int i = 1; i < answerOptions.Length; i++)
					{
						string answer = answerOptions[i].Trim();
						bool isAnswer = IsUnderlined(answer, content, questionDTB, startCauHoi, endCauHoi, wordApp, wordDoc);

						//MessageBox.Show($"Câu tl: {answer} : là đáp án {isAnswer}");
						CauTraLoiDTO ctl = new CauTraLoiDTO();
						ctl.MaCauHoi = mch;
						ctl.MaCauTraLoi = ctlBus.GetAutoIncrement();
						ctl.NoiDung = answer;
						ctl.DapAn = isAnswer;
						ctlBus.Add(ctl);
					}

					// Tăng số thứ tự câu hỏi
					currentQuestionNumber++;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				// Đóng file Word
				wordDoc?.Close(SaveChanges: false);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(wordDoc);

				wordApp?.Quit();
				System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
			}
		}
		private bool IsUnderlined(string answer, string content, string question, int startCauHoi, int endCauHoi, Word.Application wordApp, Word.Document wordDoc)
		{
			int startCauTraLoi = content.IndexOf(answer, startCauHoi + question.Length, endCauHoi - (startCauHoi + question.Length));
			if (startCauTraLoi != -1)
			{
				Word.Range wordRange = wordApp.ActiveDocument.Range(startCauTraLoi, startCauTraLoi + answer.Length);
				if (wordRange.Font.Underline != 0)
				{
					return true;
				}
			}
			return false;
		}

		private void cbMonhoc_SelectedValueChanged(object sender, EventArgs e)
		{
			ComboBox cb = sender as ComboBox;
			if (cb.SelectedValue != null)
			{
				selectedMonHoc = mhBus.getById(Convert.ToInt32(cb.SelectedValue));
			}
		}
	}

}
