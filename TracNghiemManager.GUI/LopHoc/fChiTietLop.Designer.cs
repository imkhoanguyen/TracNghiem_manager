namespace TracNghiemManager.GUI.LopHoc
{
    partial class fChiTietLop
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
            this.headingPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.containerlbl = new System.Windows.Forms.TableLayoutPanel();
            this.lblGV = new System.Windows.Forms.Label();
            this.lblMM = new System.Windows.Forms.Label();
            this.lblTenGV = new System.Windows.Forms.Label();
            this.lblMaMoi = new System.Windows.Forms.Label();
            this.containerBtn = new System.Windows.Forms.TableLayoutPanel();
            this.btnXemDSSV = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblDt = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.headingPanel.SuspendLayout();
            this.containerlbl.SuspendLayout();
            this.containerBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 1;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainPanel.Controls.Add(this.headingPanel, 0, 0);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 2;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.26829F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.7317F));
            this.mainPanel.Size = new System.Drawing.Size(1555, 779);
            this.mainPanel.TabIndex = 0;
            // 
            // headingPanel
            // 
            this.headingPanel.ColumnCount = 2;
            this.headingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.0033F));
            this.headingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.9967F));
            this.headingPanel.Controls.Add(this.lblTenLop, 0, 0);
            this.headingPanel.Controls.Add(this.containerlbl, 1, 0);
            this.headingPanel.Controls.Add(this.containerBtn, 1, 1);
            this.headingPanel.Controls.Add(this.lblDt, 0, 1);
            this.headingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headingPanel.Location = new System.Drawing.Point(20, 5);
            this.headingPanel.Margin = new System.Windows.Forms.Padding(20, 5, 20, 3);
            this.headingPanel.Name = "headingPanel";
            this.headingPanel.RowCount = 2;
            this.headingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.10811F));
            this.headingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.89189F));
            this.headingPanel.Size = new System.Drawing.Size(1515, 220);
            this.headingPanel.TabIndex = 0;
            // 
            // lblTenLop
            // 
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Font = new System.Drawing.Font("Bahnschrift Condensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLop.Location = new System.Drawing.Point(3, 0);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Size = new System.Drawing.Size(378, 72);
            this.lblTenLop.TabIndex = 0;
            this.lblTenLop.Text = "Kỹ thuật lập trình";
            // 
            // containerlbl
            // 
            this.containerlbl.ColumnCount = 2;
            this.containerlbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.12748F));
            this.containerlbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.87252F));
            this.containerlbl.Controls.Add(this.lblGV, 0, 0);
            this.containerlbl.Controls.Add(this.lblMM, 0, 1);
            this.containerlbl.Controls.Add(this.lblTenGV, 1, 0);
            this.containerlbl.Controls.Add(this.lblMaMoi, 1, 1);
            this.containerlbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerlbl.Location = new System.Drawing.Point(806, 3);
            this.containerlbl.Name = "containerlbl";
            this.containerlbl.RowCount = 2;
            this.containerlbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.containerlbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.containerlbl.Size = new System.Drawing.Size(706, 121);
            this.containerlbl.TabIndex = 1;
            // 
            // lblGV
            // 
            this.lblGV.AutoSize = true;
            this.lblGV.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGV.Location = new System.Drawing.Point(3, 0);
            this.lblGV.Name = "lblGV";
            this.lblGV.Size = new System.Drawing.Size(207, 54);
            this.lblGV.TabIndex = 0;
            this.lblGV.Text = "Giáo viên: ";
            // 
            // lblMM
            // 
            this.lblMM.AutoSize = true;
            this.lblMM.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMM.Location = new System.Drawing.Point(3, 60);
            this.lblMM.Name = "lblMM";
            this.lblMM.Size = new System.Drawing.Size(178, 54);
            this.lblMM.TabIndex = 1;
            this.lblMM.Text = "Mã mời: ";
            // 
            // lblTenGV
            // 
            this.lblTenGV.AutoSize = true;
            this.lblTenGV.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenGV.Location = new System.Drawing.Point(251, 0);
            this.lblTenGV.Name = "lblTenGV";
            this.lblTenGV.Size = new System.Drawing.Size(130, 54);
            this.lblTenGV.TabIndex = 2;
            this.lblTenGV.Text = "label1";
            // 
            // lblMaMoi
            // 
            this.lblMaMoi.AutoSize = true;
            this.lblMaMoi.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaMoi.Location = new System.Drawing.Point(251, 60);
            this.lblMaMoi.Name = "lblMaMoi";
            this.lblMaMoi.Size = new System.Drawing.Size(130, 54);
            this.lblMaMoi.TabIndex = 3;
            this.lblMaMoi.Text = "label1";
            // 
            // containerBtn
            // 
            this.containerBtn.ColumnCount = 2;
            this.containerBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.containerBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.containerBtn.Controls.Add(this.btnXemDSSV, 1, 0);
            this.containerBtn.Controls.Add(this.btnThem, 0, 0);
            this.containerBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerBtn.Location = new System.Drawing.Point(806, 130);
            this.containerBtn.Name = "containerBtn";
            this.containerBtn.RowCount = 1;
            this.containerBtn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.containerBtn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.containerBtn.Size = new System.Drawing.Size(706, 87);
            this.containerBtn.TabIndex = 2;
            // 
            // btnXemDSSV
            // 
            this.btnXemDSSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemDSSV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemDSSV.Location = new System.Drawing.Point(356, 3);
            this.btnXemDSSV.Name = "btnXemDSSV";
            this.btnXemDSSV.Size = new System.Drawing.Size(155, 54);
            this.btnXemDSSV.TabIndex = 0;
            this.btnXemDSSV.Text = "Xem DSSV";
            this.btnXemDSSV.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(3, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(155, 54);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Tạo đề thi";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // lblDt
            // 
            this.lblDt.AutoSize = true;
            this.lblDt.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDt.Location = new System.Drawing.Point(3, 127);
            this.lblDt.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblDt.Name = "lblDt";
            this.lblDt.Size = new System.Drawing.Size(394, 60);
            this.lblDt.TabIndex = 3;
            this.lblDt.Text = "Đề thi có trong lớp";
            // 
            // fChiTietLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 779);
            this.Controls.Add(this.mainPanel);
            this.Name = "fChiTietLop";
            this.Text = "fChiTietLop";
            this.mainPanel.ResumeLayout(false);
            this.headingPanel.ResumeLayout(false);
            this.headingPanel.PerformLayout();
            this.containerlbl.ResumeLayout(false);
            this.containerlbl.PerformLayout();
            this.containerBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.TableLayoutPanel headingPanel;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.TableLayoutPanel containerlbl;
        private System.Windows.Forms.Label lblGV;
        private System.Windows.Forms.Label lblMM;
        private System.Windows.Forms.Label lblTenGV;
        private System.Windows.Forms.Label lblMaMoi;
        private System.Windows.Forms.TableLayoutPanel containerBtn;
        private System.Windows.Forms.Button btnXemDSSV;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblDt;
    }
}