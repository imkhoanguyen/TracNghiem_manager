namespace TracNghiemManager.GUI.DeThi
{
	partial class fThemChiTietDeThi
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
			this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.leftPanel = new System.Windows.Forms.TableLayoutPanel();
			this.lblCauHoi = new System.Windows.Forms.Label();
			this.lbCauHoi = new System.Windows.Forms.ListBox();
			this.rightPanel = new System.Windows.Forms.TableLayoutPanel();
			this.lblCHDT = new System.Windows.Forms.Label();
			this.lbDeThi = new System.Windows.Forms.ListBox();
			this.centerPanel = new System.Windows.Forms.TableLayoutPanel();
			this.btnLeftToRight = new System.Windows.Forms.Button();
			this.btnRightToLeft = new System.Windows.Forms.Button();
			this.btnLeftToRightAll = new System.Windows.Forms.Button();
			this.btnRightToLeftAll = new System.Windows.Forms.Button();
			this.mainPanel.SuspendLayout();
			this.leftPanel.SuspendLayout();
			this.rightPanel.SuspendLayout();
			this.centerPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.ColumnCount = 3;
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
			this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
			this.mainPanel.Controls.Add(this.leftPanel, 0, 0);
			this.mainPanel.Controls.Add(this.rightPanel, 2, 0);
			this.mainPanel.Controls.Add(this.centerPanel, 1, 0);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(0, 0);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.RowCount = 1;
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.mainPanel.Size = new System.Drawing.Size(1192, 649);
			this.mainPanel.TabIndex = 0;
			// 
			// leftPanel
			// 
			this.leftPanel.ColumnCount = 1;
			this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.leftPanel.Controls.Add(this.lblCauHoi, 0, 0);
			this.leftPanel.Controls.Add(this.lbCauHoi, 0, 1);
			this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftPanel.Location = new System.Drawing.Point(3, 2);
			this.leftPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.leftPanel.Name = "leftPanel";
			this.leftPanel.RowCount = 2;
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.826F));
			this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.174F));
			this.leftPanel.Size = new System.Drawing.Size(494, 645);
			this.leftPanel.TabIndex = 0;
			// 
			// lblCauHoi
			// 
			this.lblCauHoi.AutoSize = true;
			this.lblCauHoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCauHoi.Location = new System.Drawing.Point(3, 0);
			this.lblCauHoi.Name = "lblCauHoi";
			this.lblCauHoi.Size = new System.Drawing.Size(78, 28);
			this.lblCauHoi.TabIndex = 0;
			this.lblCauHoi.Text = "Câu hỏi";
			// 
			// lbCauHoi
			// 
			this.lbCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbCauHoi.FormattingEnabled = true;
			this.lbCauHoi.ItemHeight = 16;
			this.lbCauHoi.Location = new System.Drawing.Point(4, 112);
			this.lbCauHoi.Margin = new System.Windows.Forms.Padding(4);
			this.lbCauHoi.Name = "lbCauHoi";
			this.lbCauHoi.Size = new System.Drawing.Size(486, 529);
			this.lbCauHoi.TabIndex = 1;
			this.lbCauHoi.SelectedIndexChanged += new System.EventHandler(this.lbCauHoi_SelectedIndexChanged);
			this.lbCauHoi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbCauHoi_MouseDoubleClick);
			// 
			// rightPanel
			// 
			this.rightPanel.ColumnCount = 1;
			this.rightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.rightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.rightPanel.Controls.Add(this.lblCHDT, 0, 0);
			this.rightPanel.Controls.Add(this.lbDeThi, 0, 1);
			this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rightPanel.Location = new System.Drawing.Point(696, 4);
			this.rightPanel.Margin = new System.Windows.Forms.Padding(4);
			this.rightPanel.Name = "rightPanel";
			this.rightPanel.RowCount = 2;
			this.rightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.69866F));
			this.rightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.30135F));
			this.rightPanel.Size = new System.Drawing.Size(492, 641);
			this.rightPanel.TabIndex = 1;
			// 
			// lblCHDT
			// 
			this.lblCHDT.AutoSize = true;
			this.lblCHDT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCHDT.Location = new System.Drawing.Point(4, 0);
			this.lblCHDT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblCHDT.Name = "lblCHDT";
			this.lblCHDT.Size = new System.Drawing.Size(187, 28);
			this.lblCHDT.TabIndex = 0;
			this.lblCHDT.Text = "Câu hỏi trong đề thi";
			// 
			// lbDeThi
			// 
			this.lbDeThi.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbDeThi.FormattingEnabled = true;
			this.lbDeThi.ItemHeight = 16;
			this.lbDeThi.Location = new System.Drawing.Point(4, 111);
			this.lbDeThi.Margin = new System.Windows.Forms.Padding(4);
			this.lbDeThi.Name = "lbDeThi";
			this.lbDeThi.Size = new System.Drawing.Size(484, 526);
			this.lbDeThi.TabIndex = 1;
			// 
			// centerPanel
			// 
			this.centerPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.centerPanel.ColumnCount = 2;
			this.centerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.centerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.centerPanel.Controls.Add(this.btnLeftToRight, 0, 0);
			this.centerPanel.Controls.Add(this.btnRightToLeft, 1, 0);
			this.centerPanel.Controls.Add(this.btnLeftToRightAll, 0, 1);
			this.centerPanel.Controls.Add(this.btnRightToLeftAll, 1, 1);
			this.centerPanel.Location = new System.Drawing.Point(504, 263);
			this.centerPanel.Margin = new System.Windows.Forms.Padding(4);
			this.centerPanel.Name = "centerPanel";
			this.centerPanel.RowCount = 2;
			this.centerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.centerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.centerPanel.Size = new System.Drawing.Size(184, 123);
			this.centerPanel.TabIndex = 2;
			// 
			// btnLeftToRight
			// 
			this.btnLeftToRight.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnLeftToRight.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnLeftToRight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLeftToRight.Location = new System.Drawing.Point(4, 16);
			this.btnLeftToRight.Margin = new System.Windows.Forms.Padding(4);
			this.btnLeftToRight.Name = "btnLeftToRight";
			this.btnLeftToRight.Size = new System.Drawing.Size(84, 28);
			this.btnLeftToRight.TabIndex = 0;
			this.btnLeftToRight.Text = ">";
			this.btnLeftToRight.UseVisualStyleBackColor = true;
			this.btnLeftToRight.Click += new System.EventHandler(this.btnLeftToRight_Click);
			// 
			// btnRightToLeft
			// 
			this.btnRightToLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnRightToLeft.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRightToLeft.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRightToLeft.Location = new System.Drawing.Point(96, 16);
			this.btnRightToLeft.Margin = new System.Windows.Forms.Padding(4);
			this.btnRightToLeft.Name = "btnRightToLeft";
			this.btnRightToLeft.Size = new System.Drawing.Size(84, 28);
			this.btnRightToLeft.TabIndex = 1;
			this.btnRightToLeft.Text = "<";
			this.btnRightToLeft.UseVisualStyleBackColor = true;
			this.btnRightToLeft.Click += new System.EventHandler(this.btnRightToLeft_Click);
			// 
			// btnLeftToRightAll
			// 
			this.btnLeftToRightAll.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnLeftToRightAll.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnLeftToRightAll.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLeftToRightAll.Location = new System.Drawing.Point(4, 78);
			this.btnLeftToRightAll.Margin = new System.Windows.Forms.Padding(4);
			this.btnLeftToRightAll.Name = "btnLeftToRightAll";
			this.btnLeftToRightAll.Size = new System.Drawing.Size(84, 28);
			this.btnLeftToRightAll.TabIndex = 2;
			this.btnLeftToRightAll.Text = ">>";
			this.btnLeftToRightAll.UseVisualStyleBackColor = true;
			this.btnLeftToRightAll.Click += new System.EventHandler(this.btnLeftToRightAll_Click);
			// 
			// btnRightToLeftAll
			// 
			this.btnRightToLeftAll.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnRightToLeftAll.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRightToLeftAll.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRightToLeftAll.Location = new System.Drawing.Point(96, 78);
			this.btnRightToLeftAll.Margin = new System.Windows.Forms.Padding(4);
			this.btnRightToLeftAll.Name = "btnRightToLeftAll";
			this.btnRightToLeftAll.Size = new System.Drawing.Size(84, 28);
			this.btnRightToLeftAll.TabIndex = 3;
			this.btnRightToLeftAll.Text = "<<";
			this.btnRightToLeftAll.UseVisualStyleBackColor = true;
			this.btnRightToLeftAll.Click += new System.EventHandler(this.btnRightToLeftAll_Click);
			// 
			// fThemChiTietDeThi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1192, 649);
			this.Controls.Add(this.mainPanel);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "fThemChiTietDeThi";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "fThemChiTietDeThi";
			this.mainPanel.ResumeLayout(false);
			this.leftPanel.ResumeLayout(false);
			this.leftPanel.PerformLayout();
			this.rightPanel.ResumeLayout(false);
			this.rightPanel.PerformLayout();
			this.centerPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.TableLayoutPanel leftPanel;
		private System.Windows.Forms.Label lblCauHoi;
		private System.Windows.Forms.TableLayoutPanel rightPanel;
		private System.Windows.Forms.ListBox lbCauHoi;
		private System.Windows.Forms.Label lblCHDT;
		private System.Windows.Forms.ListBox lbDeThi;
		private System.Windows.Forms.TableLayoutPanel centerPanel;
		private System.Windows.Forms.Button btnLeftToRight;
		private System.Windows.Forms.Button btnRightToLeft;
		private System.Windows.Forms.Button btnLeftToRightAll;
		private System.Windows.Forms.Button btnRightToLeftAll;
	}
}