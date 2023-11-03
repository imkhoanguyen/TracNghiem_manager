namespace TracNghiemManager.GUI.LopHoc
{
	partial class fThemDeThiCuaLop
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnLuu = new System.Windows.Forms.Button();
			this.dtpThoiGianBatDau = new System.Windows.Forms.DateTimePicker();
			this.dtpThoiGianKetThuc = new System.Windows.Forms.DateTimePicker();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(110, 34);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(320, 45);
			this.label1.TabIndex = 0;
			this.label1.Text = "Thêm đề thi vào lớp";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(35, 134);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(138, 21);
			this.label2.TabIndex = 1;
			this.label2.Text = "Thời gian bắt đầu: ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(35, 193);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(141, 21);
			this.label3.TabIndex = 2;
			this.label3.Text = "Thời gian kết thúc: ";
			// 
			// btnLuu
			// 
			this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLuu.Location = new System.Drawing.Point(340, 260);
			this.btnLuu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnLuu.Name = "btnLuu";
			this.btnLuu.Size = new System.Drawing.Size(102, 40);
			this.btnLuu.TabIndex = 3;
			this.btnLuu.Text = "Lưu";
			this.btnLuu.UseVisualStyleBackColor = true;
			this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
			// 
			// dtpThoiGianBatDau
			// 
			this.dtpThoiGianBatDau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpThoiGianBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpThoiGianBatDau.Location = new System.Drawing.Point(182, 134);
			this.dtpThoiGianBatDau.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dtpThoiGianBatDau.Name = "dtpThoiGianBatDau";
			this.dtpThoiGianBatDau.ShowUpDown = true;
			this.dtpThoiGianBatDau.Size = new System.Drawing.Size(261, 29);
			this.dtpThoiGianBatDau.TabIndex = 4;
			// 
			// dtpThoiGianKetThuc
			// 
			this.dtpThoiGianKetThuc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpThoiGianKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpThoiGianKetThuc.Location = new System.Drawing.Point(182, 193);
			this.dtpThoiGianKetThuc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dtpThoiGianKetThuc.Name = "dtpThoiGianKetThuc";
			this.dtpThoiGianKetThuc.ShowUpDown = true;
			this.dtpThoiGianKetThuc.Size = new System.Drawing.Size(261, 29);
			this.dtpThoiGianKetThuc.TabIndex = 5;
			// 
			// fThemDeThiCuaLop
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(518, 330);
			this.Controls.Add(this.dtpThoiGianKetThuc);
			this.Controls.Add(this.dtpThoiGianBatDau);
			this.Controls.Add(this.btnLuu);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "fThemDeThiCuaLop";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thềm đề thi vào lớp";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnLuu;
		private System.Windows.Forms.DateTimePicker dtpThoiGianBatDau;
		private System.Windows.Forms.DateTimePicker dtpThoiGianKetThuc;
	}
}