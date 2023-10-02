using System.Windows.Forms;
using TracNghiemManager.GUI.CauHoi;

namespace TracNghiem_manager
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            containerBtnPanel = new TableLayoutPanel();
            infoPanelBox = new TableLayoutPanel();
            infoOwnerPanel = new TableLayoutPanel();
            lblOwnerName = new Label();
            lblOwnerRule = new Label();
            pictureOwner = new PictureBox();
            btnHome = new Button();
            btnMonHoc = new Button();
            btnThongKe = new Button();
            btnCauHoi = new Button();
            btnLopHoc = new Button();
            btnThoat = new Button();
            btnDeThi = new Button();
            btnNguoiDung = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            containerPanel = new Panel();
            homePanel = new HomeUserControl();
            lopHocPanel = new LopHocUserControl();
            monHocPanel = new MonHocUserControl();
            cauHoiPanel = new CauHoiUserControl();
            deThiPanel = new DeThiUserControl();
            thongKePanel = new ThongKeUserControl();
            userPanel = new Manager();
            containerBtnPanel.SuspendLayout();
            infoPanelBox.SuspendLayout();
            infoOwnerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureOwner).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            containerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // containerBtnPanel
            // 
            containerBtnPanel.ColumnCount = 1;
            containerBtnPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            containerBtnPanel.Controls.Add(infoPanelBox, 0, 0);
            containerBtnPanel.Controls.Add(btnHome, 0, 1);

            containerBtnPanel.Controls.Add(btnNguoiDung);
            containerBtnPanel.RowStyles.Add(new RowStyle());

            containerBtnPanel.Dock = DockStyle.Left;
            containerBtnPanel.Location = new Point(0, 0);
            containerBtnPanel.Margin = new Padding(10);
            containerBtnPanel.Name = "containerBtnPanel";
            containerBtnPanel.RowStyles.Add(new RowStyle());
            containerBtnPanel.RowStyles.Add(new RowStyle());
            containerBtnPanel.Size = new Size(330, 845);
            containerBtnPanel.TabIndex = 0;
            // 
            // infoPanelBox
            // 
            infoPanelBox.ColumnCount = 2;
            infoPanelBox.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.4740067F));
            infoPanelBox.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.52599F));
            infoPanelBox.Controls.Add(infoOwnerPanel, 1, 0);
            infoPanelBox.Controls.Add(pictureOwner, 0, 0);
            infoPanelBox.Enabled = false;
            infoPanelBox.Location = new Point(0, 10);
            infoPanelBox.Margin = new Padding(0, 10, 0, 0);
            infoPanelBox.Name = "infoPanelBox";
            infoPanelBox.Padding = new Padding(0, 0, 0, 10);
            infoPanelBox.RowCount = 1;
            infoPanelBox.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            infoPanelBox.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            infoPanelBox.Size = new Size(327, 90);
            infoPanelBox.TabIndex = 30;
            // 
            // infoOwnerPanel
            // 
            infoOwnerPanel.ColumnCount = 1;
            infoOwnerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            infoOwnerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            infoOwnerPanel.Controls.Add(lblOwnerName, 0, 0);
            infoOwnerPanel.Controls.Add(lblOwnerRule, 0, 1);
            infoOwnerPanel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            infoOwnerPanel.Location = new Point(121, 5);
            infoOwnerPanel.Margin = new Padding(5);
            infoOwnerPanel.Name = "infoOwnerPanel";
            infoOwnerPanel.RowCount = 2;
            infoOwnerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            infoOwnerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            infoOwnerPanel.Size = new Size(200, 53);
            infoOwnerPanel.TabIndex = 1;
            // 
            // lblOwnerName
            // 
            lblOwnerName.AutoSize = true;
            lblOwnerName.Dock = DockStyle.Fill;
            lblOwnerName.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblOwnerName.Location = new Point(0, 0);
            lblOwnerName.Margin = new Padding(0);
            lblOwnerName.Name = "lblOwnerName";
            lblOwnerName.Size = new Size(200, 26);
            lblOwnerName.TabIndex = 0;
            lblOwnerName.Text = "Nguyễn Anh Khoa";
            lblOwnerName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOwnerRule
            // 
            lblOwnerRule.AutoSize = true;
            lblOwnerRule.Dock = DockStyle.Fill;
            lblOwnerRule.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblOwnerRule.Location = new Point(3, 26);
            lblOwnerRule.Name = "lblOwnerRule";
            lblOwnerRule.Size = new Size(194, 27);
            lblOwnerRule.TabIndex = 1;
            lblOwnerRule.Text = "Admin";
            lblOwnerRule.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureOwner
            // 
            pictureOwner.Image = (Image)resources.GetObject("pictureOwner.Image");
            pictureOwner.InitialImage = null;
            pictureOwner.Location = new Point(2, 2);
            pictureOwner.Margin = new Padding(2);
            pictureOwner.Name = "pictureOwner";
            pictureOwner.Size = new Size(112, 76);
            pictureOwner.SizeMode = PictureBoxSizeMode.Zoom;
            pictureOwner.TabIndex = 0;
            pictureOwner.TabStop = false;
            pictureOwner.WaitOnLoad = true;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.White;
            btnHome.Cursor = Cursors.Hand;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point);
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.Location = new Point(10, 105);
            btnHome.Margin = new Padding(10, 5, 10, 5);
            btnHome.MinimumSize = new Size(117, 46);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(10, 0, 0, 0);
            btnHome.Size = new Size(310, 60);
            btnHome.TabIndex = 25;
            btnHome.Text = "  Trang chủ";
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // btnMonHoc
            // 
            btnMonHoc.BackColor = Color.White;
            btnMonHoc.Cursor = Cursors.Hand;
            btnMonHoc.FlatAppearance.BorderSize = 0;
            btnMonHoc.FlatStyle = FlatStyle.Flat;
            btnMonHoc.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point);
            btnMonHoc.Image = (Image)resources.GetObject("btnMonHoc.Image");
            btnMonHoc.ImageAlign = ContentAlignment.MiddleLeft;
            btnMonHoc.Location = new Point(10, 291);
            btnMonHoc.Margin = new Padding(10, 5, 10, 5);
            btnMonHoc.MinimumSize = new Size(117, 46);
            btnMonHoc.Name = "btnMonHoc";
            btnMonHoc.Padding = new Padding(10, 0, 0, 0);
            btnMonHoc.Size = new Size(310, 60);
            btnMonHoc.TabIndex = 24;
            btnMonHoc.Text = "  Môn học";
            btnMonHoc.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMonHoc.UseVisualStyleBackColor = false;
            btnMonHoc.Click += btnMonHoc_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.BackColor = Color.White;
            btnThongKe.Cursor = Cursors.Hand;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point);
            btnThongKe.Image = (Image)resources.GetObject("btnThongKe.Image");
            btnThongKe.ImageAlign = ContentAlignment.MiddleLeft;
            btnThongKe.Location = new Point(10, 529);
            btnThongKe.Margin = new Padding(10, 5, 10, 5);
            btnThongKe.MinimumSize = new Size(117, 46);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Padding = new Padding(10, 0, 0, 0);
            btnThongKe.Size = new Size(310, 60);
            btnThongKe.TabIndex = 28;
            btnThongKe.Text = "  Thống kê";
            btnThongKe.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // btnCauHoi
            // 
            btnCauHoi.BackColor = Color.White;
            btnCauHoi.BackgroundImageLayout = ImageLayout.None;
            btnCauHoi.Cursor = Cursors.Hand;
            btnCauHoi.FlatAppearance.BorderColor = Color.Black;
            btnCauHoi.FlatAppearance.BorderSize = 0;
            btnCauHoi.FlatStyle = FlatStyle.Flat;
            btnCauHoi.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point);
            btnCauHoi.Image = (Image)resources.GetObject("btnCauHoi.Image");
            btnCauHoi.ImageAlign = ContentAlignment.MiddleLeft;
            btnCauHoi.Location = new Point(10, 371);
            btnCauHoi.Margin = new Padding(10, 5, 10, 5);
            btnCauHoi.MinimumSize = new Size(117, 45);
            btnCauHoi.Name = "btnCauHoi";
            btnCauHoi.Padding = new Padding(10, 0, 0, 0);
            btnCauHoi.Size = new Size(310, 60);
            btnCauHoi.TabIndex = 23;
            btnCauHoi.Text = "  Câu hỏi";
            btnCauHoi.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCauHoi.UseVisualStyleBackColor = false;
            btnCauHoi.Click += btnCauHoi_Click;
            // 
            // btnLopHoc
            // 
            btnLopHoc.BackColor = Color.White;
            btnLopHoc.Cursor = Cursors.Hand;
            btnLopHoc.FlatAppearance.BorderSize = 0;
            btnLopHoc.FlatStyle = FlatStyle.Flat;
            btnLopHoc.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point);
            btnLopHoc.Image = (Image)resources.GetObject("btnLopHoc.Image");
            btnLopHoc.ImageAlign = ContentAlignment.MiddleLeft;
            btnLopHoc.Location = new Point(10, 212);
            btnLopHoc.Margin = new Padding(10, 5, 10, 5);
            btnLopHoc.MinimumSize = new Size(117, 46);
            btnLopHoc.Name = "btnLopHoc";
            btnLopHoc.Padding = new Padding(10, 0, 0, 0);
            btnLopHoc.Size = new Size(310, 60);
            btnLopHoc.TabIndex = 26;
            btnLopHoc.Text = "  Lớp học";
            btnLopHoc.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLopHoc.UseVisualStyleBackColor = false;
            btnLopHoc.Click += btnLopHoc_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.White;
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point);
            btnThoat.ForeColor = SystemColors.ControlText;
            btnThoat.Image = (Image)resources.GetObject("btnThoat.Image");
            btnThoat.ImageAlign = ContentAlignment.MiddleLeft;
            btnThoat.Location = new Point(10, 767);
            btnThoat.Margin = new Padding(10, 5, 10, 5);
            btnThoat.MinimumSize = new Size(117, 46);
            btnThoat.Name = "btnThoat";
            btnThoat.Padding = new Padding(10, 0, 0, 0);
            btnThoat.Size = new Size(310, 60);
            btnThoat.TabIndex = 29;
            btnThoat.Text = "  Đăng xuất";
            btnThoat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnDeThi
            // 
            btnDeThi.BackColor = Color.White;
            btnDeThi.Cursor = Cursors.Hand;
            btnDeThi.FlatAppearance.BorderSize = 0;
            btnDeThi.FlatStyle = FlatStyle.Flat;
            btnDeThi.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeThi.Image = (Image)resources.GetObject("btnDeThi.Image");
            btnDeThi.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeThi.Location = new Point(10, 451);
            btnDeThi.Margin = new Padding(10, 5, 10, 5);
            btnDeThi.MinimumSize = new Size(117, 46);
            btnDeThi.Name = "btnDeThi";
            btnDeThi.Padding = new Padding(10, 0, 0, 0);
            btnDeThi.Size = new Size(310, 60);
            btnDeThi.TabIndex = 27;
            btnDeThi.Text = "  Đề thi";
            btnDeThi.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDeThi.UseVisualStyleBackColor = false;
            btnDeThi.Click += btnDeThi_Click;
            // 
            // btnNguoiDung
            // 
            btnNguoiDung.BackColor = Color.White;
            btnNguoiDung.Cursor = Cursors.Hand;
            btnNguoiDung.FlatAppearance.BorderSize = 0;
            btnNguoiDung.FlatStyle = FlatStyle.Flat;
            btnNguoiDung.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point);
            btnNguoiDung.Image = (Image)resources.GetObject("btnNguoiDung.Image");
            btnNguoiDung.ImageAlign = ContentAlignment.MiddleLeft;
            btnNguoiDung.Location = new Point(10, 607);
            btnNguoiDung.Margin = new Padding(10, 5, 10, 5);
            btnNguoiDung.MinimumSize = new Size(117, 46);
            btnNguoiDung.Name = "btnNguoiDung";
            btnNguoiDung.Padding = new Padding(10, 0, 0, 0);
            btnNguoiDung.Size = new Size(310, 60);
            btnNguoiDung.TabIndex = 33;
            btnNguoiDung.Text = "  Người dùng";
            btnNguoiDung.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNguoiDung.UseVisualStyleBackColor = false;
            btnNguoiDung.Click += btnNguoiDung_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.White;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(containerPanel, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(330, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 38.8189735F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 61.1810265F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(1210, 845);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // containerPanel
            // 
            containerPanel.Controls.Add(homePanel);
            containerPanel.Controls.Add(lopHocPanel);
            containerPanel.Controls.Add(monHocPanel);
            containerPanel.Controls.Add(cauHoiPanel);
            containerPanel.Controls.Add(deThiPanel);
            containerPanel.Controls.Add(thongKePanel);
            containerPanel.Controls.Add(userPanel);
            containerPanel.Dock = DockStyle.Fill;
            containerPanel.Location = new Point(0, 0);
            containerPanel.Margin = new Padding(0);
            containerPanel.Name = "containerPanel";
            containerPanel.Size = new Size(1210, 845);
            containerPanel.TabIndex = 0;
            // 
            // homePanel
            // 
            homePanel.Dock = DockStyle.Fill;
            homePanel.Location = new Point(0, 0);
            homePanel.Margin = new Padding(3, 2, 3, 2);
            homePanel.Name = "homePanel";
            homePanel.Size = new Size(1210, 845);
            homePanel.TabIndex = 0;
            // 
            // lopHocPanel
            // 
            lopHocPanel.Dock = DockStyle.Fill;
            lopHocPanel.Location = new Point(0, 0);
            lopHocPanel.Name = "lopHocPanel";
            lopHocPanel.Size = new Size(1210, 845);
            lopHocPanel.TabIndex = 1;
            // 
            // monHocPanel
            // 
            monHocPanel.Dock = DockStyle.Fill;
            monHocPanel.Location = new Point(0, 0);
            monHocPanel.Name = "monHocPanel";
            monHocPanel.Size = new Size(1210, 845);
            monHocPanel.TabIndex = 2;
            // 
            // cauHoiPanel
            // 
            cauHoiPanel.Dock = DockStyle.Fill;
            cauHoiPanel.Location = new Point(0, 0);
            cauHoiPanel.Margin = new Padding(3, 4, 3, 4);
            cauHoiPanel.Name = "cauHoiPanel";
            cauHoiPanel.Size = new Size(1210, 845);
            cauHoiPanel.TabIndex = 3;
            // 
            // deThiPanel
            // 
            deThiPanel.Dock = DockStyle.Fill;
            deThiPanel.Location = new Point(0, 0);
            deThiPanel.Name = "deThiPanel";
            deThiPanel.Size = new Size(1210, 845);
            deThiPanel.TabIndex = 4;
            // 
            // thongKePanel
            // 
            thongKePanel.Dock = DockStyle.Fill;
            thongKePanel.Location = new Point(0, 0);
            thongKePanel.Name = "thongKePanel";
            thongKePanel.Size = new Size(1210, 845);
            thongKePanel.TabIndex = 5;
            // 
            // userPanel
            // 
            thongKePanel.Dock = DockStyle.Fill;
            thongKePanel.Location = new Point(0, 0);
            thongKePanel.Name = "userPanel";
            thongKePanel.Size = new Size(1210, 845);
            thongKePanel.TabIndex = 6;
            // 
            // UserForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1540, 845);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(containerBtnPanel);
            MaximumSize = new Size(1920, 1080);
            MinimumSize = new Size(700, 550);
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += UserForm_Load;
            containerBtnPanel.ResumeLayout(false);
            infoPanelBox.ResumeLayout(false);
            infoOwnerPanel.ResumeLayout(false);
            infoOwnerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureOwner).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            containerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel containerBtnPanel;
        private Button btnCauHoi;
        private Button btnHome;
        private Button btnDeThi;
        private Button btnThongKe;
        private Button btnLopHoc;
        private Button btnThoat;
        private Button btnMonHoc;


        private Color hoverColor = ColorTranslator.FromHtml("#8eddf9");
        private Color defaultTitleBtnColor = ColorTranslator.FromHtml("#646568");
        private Color borderColor = ColorTranslator.FromHtml("#e9edee");
        private TableLayoutPanel infoPanelBox;
        private PictureBox pictureOwner;
        private TableLayoutPanel infoOwnerPanel;
        private Label lblOwnerName;
        private Label lblOwnerRule;
        private TableLayoutPanel tableLayoutPanel2;
        private HomeUserControl homePanel;
        private LopHocUserControl lopHocPanel;
        private MonHocUserControl monHocPanel;
        private CauHoiUserControl cauHoiPanel;
        private DeThiUserControl deThiPanel;
        private ThongKeUserControl thongKePanel;
        private Panel containerPanel;
        private Button btnNguoiDung;
        private Manager userPanel;
    }
}