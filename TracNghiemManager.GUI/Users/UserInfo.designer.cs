using System.Drawing;
using System.Windows.Forms;

namespace TracNghiemManager.GUI.Users
{
	partial class UserInfo
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			tableLayoutPanel1 = new TableLayoutPanel();
			tableLayoutPanel2 = new TableLayoutPanel();
			pictureBox1 = new PictureBox();
			buttonUpImg = new Button();
			textBox1 = new TextBox();
			tableLayoutPanel3 = new TableLayoutPanel();
			tableLayoutPanel4 = new TableLayoutPanel();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			tableLayoutPanel5 = new TableLayoutPanel();
			textBoxName = new TextBox();
			label5 = new Label();
			textBoxEmail = new TextBox();
			panel1 = new Panel();
			RbNu = new RadioButton();
			rbNam = new RadioButton();
			dateTimePicker1 = new DateTimePicker();
			tableLayoutPanel6 = new TableLayoutPanel();
			button1 = new Button();
			button2 = new Button();
			textBox2 = new TextBox();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			tableLayoutPanel3.SuspendLayout();
			tableLayoutPanel4.SuspendLayout();
			tableLayoutPanel5.SuspendLayout();
			panel1.SuspendLayout();
			tableLayoutPanel6.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.Anchor = AnchorStyles.None;
			tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.88889F));
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 1);
			tableLayoutPanel1.Location = new Point(56, 12);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 467F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Size = new Size(543, 580);
			tableLayoutPanel1.TabIndex = 1;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 3;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.2909279F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.4157772F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.2932968F));
			tableLayoutPanel2.Controls.Add(pictureBox1, 1, 0);
			tableLayoutPanel2.Controls.Add(buttonUpImg, 2, 0);
			tableLayoutPanel2.Controls.Add(textBox1, 0, 0);
			tableLayoutPanel2.Location = new Point(4, 4);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel2.Size = new Size(535, 104);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// pictureBox1
			// 
			pictureBox1.BorderStyle = BorderStyle.FixedSingle;
			pictureBox1.Dock = DockStyle.Fill;
			pictureBox1.Location = new Point(213, 3);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(108, 98);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			// 
			// buttonUpImg
			// 
			buttonUpImg.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			buttonUpImg.Location = new Point(327, 78);
			buttonUpImg.Name = "buttonUpImg";
			buttonUpImg.Size = new Size(75, 23);
			buttonUpImg.TabIndex = 1;
			buttonUpImg.Text = "Up ảnh";
			buttonUpImg.UseVisualStyleBackColor = true;
			buttonUpImg.Visible = false;
			buttonUpImg.Click += buttonUpImg_Click;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(3, 3);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(100, 23);
			textBox1.TabIndex = 2;
			textBox1.Visible = false;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 2;
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.3668537F));
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.63315F));
			tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 0);
			tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 1, 0);
			tableLayoutPanel3.Location = new Point(4, 115);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 1;
			tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel3.Size = new Size(535, 461);
			tableLayoutPanel3.TabIndex = 1;
			// 
			// tableLayoutPanel4
			// 
			tableLayoutPanel4.ColumnCount = 1;
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel4.Controls.Add(label1, 0, 0);
			tableLayoutPanel4.Controls.Add(label2, 0, 1);
			tableLayoutPanel4.Controls.Add(label3, 0, 2);
			tableLayoutPanel4.Controls.Add(label4, 0, 3);
			tableLayoutPanel4.Controls.Add(textBox2, 0, 4);
			tableLayoutPanel4.Location = new Point(3, 3);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 7;
			tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
			tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
			tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
			tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
			tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
			tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
			tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
			tableLayoutPanel4.Size = new Size(97, 455);
			tableLayoutPanel4.TabIndex = 0;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.None;
			label1.AutoSize = true;
			label1.Location = new Point(19, 25);
			label1.Name = "label1";
			label1.Size = new Size(59, 15);
			label1.TabIndex = 0;
			label1.Text = "Họ Và Tên";
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.None;
			label2.AutoSize = true;
			label2.Location = new Point(30, 90);
			label2.Name = "label2";
			label2.Size = new Size(36, 15);
			label2.TabIndex = 1;
			label2.Text = "email";
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.None;
			label3.AutoSize = true;
			label3.Location = new Point(19, 155);
			label3.Name = "label3";
			label3.Size = new Size(58, 15);
			label3.TabIndex = 2;
			label3.Text = "ngày sinh";
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.None;
			label4.AutoSize = true;
			label4.Location = new Point(23, 220);
			label4.Name = "label4";
			label4.Size = new Size(51, 15);
			label4.TabIndex = 3;
			label4.Text = "giới tính";
			// 
			// tableLayoutPanel5
			// 
			tableLayoutPanel5.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel5.ColumnCount = 1;
			tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel5.Controls.Add(textBoxName, 0, 0);
			tableLayoutPanel5.Controls.Add(label5, 0, 6);
			tableLayoutPanel5.Controls.Add(textBoxEmail, 0, 1);
			tableLayoutPanel5.Controls.Add(panel1, 0, 3);
			tableLayoutPanel5.Controls.Add(dateTimePicker1, 0, 2);
			tableLayoutPanel5.Controls.Add(tableLayoutPanel6, 0, 4);
			tableLayoutPanel5.Location = new Point(106, 3);
			tableLayoutPanel5.Name = "tableLayoutPanel5";
			tableLayoutPanel5.RowCount = 7;
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 14.5374451F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 14.0969162F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 14.3171806F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 14.3171806F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 14.7577095F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 14.0969162F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 13.6563873F));
			tableLayoutPanel5.Size = new Size(426, 455);
			tableLayoutPanel5.TabIndex = 1;
			// 
			// textBoxName
			// 
			textBoxName.Anchor = AnchorStyles.None;
			textBoxName.Enabled = false;
			textBoxName.Location = new Point(64, 22);
			textBoxName.Name = "textBoxName";
			textBoxName.Size = new Size(297, 23);
			textBoxName.TabIndex = 0;
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.None;
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label5.Location = new Point(158, 412);
			label5.Name = "label5";
			label5.Size = new Size(110, 21);
			label5.TabIndex = 4;
			label5.Text = "Đổi mật khẩu?";
			label5.Click += label5_Click;
			// 
			// textBoxEmail
			// 
			textBoxEmail.Anchor = AnchorStyles.None;
			textBoxEmail.Enabled = false;
			textBoxEmail.Location = new Point(66, 87);
			textBoxEmail.Name = "textBoxEmail";
			textBoxEmail.Size = new Size(294, 23);
			textBoxEmail.TabIndex = 1;
			// 
			// panel1
			// 
			panel1.Anchor = AnchorStyles.None;
			panel1.Controls.Add(RbNu);
			panel1.Controls.Add(rbNam);
			panel1.Enabled = false;
			panel1.Location = new Point(129, 209);
			panel1.Name = "panel1";
			panel1.Size = new Size(167, 37);
			panel1.TabIndex = 3;
			// 
			// RbNu
			// 
			RbNu.AutoSize = true;
			RbNu.Location = new Point(100, 9);
			RbNu.Name = "RbNu";
			RbNu.Size = new Size(41, 19);
			RbNu.TabIndex = 1;
			RbNu.TabStop = true;
			RbNu.Tag = "0";
			RbNu.Text = "Nữ";
			RbNu.UseVisualStyleBackColor = true;
			// 
			// rbNam
			// 
			rbNam.AutoSize = true;
			rbNam.Location = new Point(3, 9);
			rbNam.Name = "rbNam";
			rbNam.Size = new Size(51, 19);
			rbNam.TabIndex = 0;
			rbNam.TabStop = true;
			rbNam.Tag = "1";
			rbNam.Text = "Nam";
			rbNam.UseVisualStyleBackColor = true;
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.Anchor = AnchorStyles.None;
			dateTimePicker1.Enabled = false;
			dateTimePicker1.Location = new Point(101, 151);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(223, 23);
			dateTimePicker1.TabIndex = 2;
			dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
			// 
			// tableLayoutPanel6
			// 
			tableLayoutPanel6.Anchor = AnchorStyles.None;
			tableLayoutPanel6.ColumnCount = 2;
			tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel6.Controls.Add(button1, 0, 0);
			tableLayoutPanel6.Controls.Add(button2, 1, 0);
			tableLayoutPanel6.Location = new Point(69, 264);
			tableLayoutPanel6.Name = "tableLayoutPanel6";
			tableLayoutPanel6.RowCount = 1;
			tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel6.Size = new Size(288, 60);
			tableLayoutPanel6.TabIndex = 5;
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.None;
			button1.Location = new Point(34, 18);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 0;
			button1.Text = "Lưu";
			button1.UseVisualStyleBackColor = true;
			button1.Visible = false;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Anchor = AnchorStyles.None;
			button2.Location = new Point(178, 18);
			button2.Name = "button2";
			button2.Size = new Size(75, 23);
			button2.TabIndex = 1;
			button2.Text = "Sửa";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(3, 263);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(91, 23);
			textBox2.TabIndex = 4;
			textBox2.Visible = false;
			// 
			// UserInfo
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(658, 604);
			Controls.Add(tableLayoutPanel1);
			Name = "UserInfo";
			Text = "UserInfo";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel4.ResumeLayout(false);
			tableLayoutPanel4.PerformLayout();
			tableLayoutPanel5.ResumeLayout(false);
			tableLayoutPanel5.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			tableLayoutPanel6.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private TableLayoutPanel tableLayoutPanel2;
		private TableLayoutPanel tableLayoutPanel3;
		private TableLayoutPanel tableLayoutPanel4;
		private TableLayoutPanel tableLayoutPanel5;
		private Label label1;
		private TextBox textBoxName;
		private Label label2;
		private TextBox textBoxEmail;
		private Label label3;
		private Label label4;
		private DateTimePicker dateTimePicker1;
		private Panel panel1;
		private RadioButton RbNu;
		private RadioButton rbNam;
		private Label label5;
		private PictureBox pictureBox1;
		private Button buttonUpImg;
		private Button button1;
		private Button button2;
		private TableLayoutPanel tableLayoutPanel6;
		private TextBox textBox1;
		private TextBox textBox2;
	}

}