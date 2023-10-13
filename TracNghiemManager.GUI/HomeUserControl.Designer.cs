using Microsoft.VisualBasic;
using System.Drawing;
using System.Windows.Forms;

namespace TracNghiemManager.GUI
{
    partial class HomeUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeUserControl));
            mainPanel = new TableLayoutPanel();
            informationContainerPanel = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            label5 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            infoPanel1 = new TableLayoutPanel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lblSecondHeading = new Label();
            descPanel = new TableLayoutPanel();
            TitlePanel = new TableLayoutPanel();
            lblHeading = new Label();
            pictureBox4 = new PictureBox();
            label6 = new Label();
            mainPanel.SuspendLayout();
            informationContainerPanel.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            infoPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            descPanel.SuspendLayout();
            TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(240, 247, 250);
            mainPanel.ColumnCount = 1;
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainPanel.Controls.Add(informationContainerPanel, 0, 1);
            mainPanel.Controls.Add(descPanel, 0, 0);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.RowCount = 2;
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30.32258F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 69.67742F));
            mainPanel.Size = new Size(1573, 1033);
            mainPanel.TabIndex = 0;
            // 
            // informationContainerPanel
            // 
            informationContainerPanel.ColumnCount = 3;
            informationContainerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333333333333F));
            informationContainerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333333333333F));
            informationContainerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333333333333F));
            informationContainerPanel.Controls.Add(tableLayoutPanel2, 0, 0);
            informationContainerPanel.Controls.Add(tableLayoutPanel1, 0, 0);
            informationContainerPanel.Controls.Add(infoPanel1, 0, 0);
            informationContainerPanel.Dock = DockStyle.Fill;
            informationContainerPanel.Location = new Point(3, 316);
            informationContainerPanel.Name = "informationContainerPanel";
            informationContainerPanel.RowCount = 1;
            informationContainerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            informationContainerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            informationContainerPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 715F));
            informationContainerPanel.Size = new Size(1567, 714);
            informationContainerPanel.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.White;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(label4, 0, 2);
            tableLayoutPanel2.Controls.Add(pictureBox3, 0, 0);
            tableLayoutPanel2.Controls.Add(label5, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(1115, 29);
            tableLayoutPanel2.Margin = new Padding(21, 29, 21, 29);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(21, 40, 21, 11);
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 86.68639F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.3136091F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 153F));
            tableLayoutPanel2.Size = new Size(431, 656);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(24, 491);
            label4.Name = "label4";
            label4.Size = new Size(383, 154);
            label4.TabIndex = 2;
            label4.Text = "Nếu bạn cần hỗ trợ hoặc có bất kỳ câu hỏi nào về ứng dụng của chúng tôi, xin vui lòng liên hệ với chúng tôi qua địa chỉ email support@yourapp.com hoặc số điện thoại 123-456-789.";
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top;
            pictureBox3.BackColor = Color.FromArgb(240, 247, 250);
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(24, 43);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Padding = new Padding(10, 11, 10, 11);
            pictureBox3.Size = new Size(383, 360);
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.SteelBlue;
            label5.Location = new Point(24, 431);
            label5.Name = "label5";
            label5.Size = new Size(383, 60);
            label5.TabIndex = 1;
            label5.Text = "Liên hệ\r\n";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(pictureBox2, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(575, 29);
            tableLayoutPanel1.Margin = new Padding(21, 29, 21, 29);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(21, 40, 21, 11);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 86.68639F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.3136091F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 153F));
            tableLayoutPanel1.Size = new Size(498, 656);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(24, 491);
            label2.Name = "label2";
            label2.Size = new Size(450, 154);
            label2.TabIndex = 2;
            label2.Text = "Cung cấp ví dụ cụ thể về cách ứng dụng của bạn có thể giúp họ tiết kiệm thời gian, nâng cao hiệu suất, hoặc giải quyết các vấn đề liên quan đến việc tổ chức kỳ thi trắc nghiệm.";
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top;
            pictureBox2.BackColor = Color.FromArgb(240, 247, 250);
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(50, 43);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Padding = new Padding(10, 11, 10, 11);
            pictureBox2.Size = new Size(398, 360);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.SteelBlue;
            label3.Location = new Point(24, 431);
            label3.Name = "label3";
            label3.Size = new Size(450, 60);
            label3.TabIndex = 1;
            label3.Text = "Tính hiệu quả\r\n";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // infoPanel1
            // 
            infoPanel1.BackColor = Color.White;
            infoPanel1.ColumnCount = 1;
            infoPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            infoPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            infoPanel1.Controls.Add(label1, 0, 2);
            infoPanel1.Controls.Add(pictureBox1, 0, 0);
            infoPanel1.Controls.Add(lblSecondHeading, 0, 1);
            infoPanel1.Dock = DockStyle.Fill;
            infoPanel1.Location = new Point(21, 29);
            infoPanel1.Margin = new Padding(21, 29, 21, 29);
            infoPanel1.Name = "infoPanel1";
            infoPanel1.Padding = new Padding(21, 40, 21, 11);
            infoPanel1.RowCount = 3;
            infoPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 86.68639F));
            infoPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.3136091F));
            infoPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 153F));
            infoPanel1.Size = new Size(512, 656);
            infoPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(24, 491);
            label1.Name = "label1";
            label1.Size = new Size(464, 154);
            label1.TabIndex = 2;
            label1.Text = "Chúng tôi đã thiết kế ứng dụng với sự tập trung vào việc sử dụng dễ dàng, cho dù bạn là người mới sử dụng hay đã có kinh nghiệm trong việc tổ chức kỳ thi trắc nghiệm.\r\n";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.BackColor = Color.FromArgb(240, 247, 250);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(57, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(10, 11, 10, 11);
            pictureBox1.Size = new Size(398, 360);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblSecondHeading
            // 
            lblSecondHeading.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSecondHeading.AutoSize = true;
            lblSecondHeading.BackColor = Color.White;
            lblSecondHeading.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSecondHeading.ForeColor = Color.SteelBlue;
            lblSecondHeading.Location = new Point(24, 431);
            lblSecondHeading.Name = "lblSecondHeading";
            lblSecondHeading.Size = new Size(464, 60);
            lblSecondHeading.TabIndex = 1;
            lblSecondHeading.Text = "Tính đơn giản\r\n";
            lblSecondHeading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // descPanel
            // 
            descPanel.BackColor = Color.White;
            descPanel.ColumnCount = 1;
            descPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            descPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            descPanel.Controls.Add(TitlePanel, 0, 0);
            descPanel.Controls.Add(label6, 0, 1);
            descPanel.Dock = DockStyle.Fill;
            descPanel.Location = new Point(3, 3);
            descPanel.Name = "descPanel";
            descPanel.RowCount = 2;
            descPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 64.06927F));
            descPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 35.9307365F));
            descPanel.Size = new Size(1567, 307);
            descPanel.TabIndex = 1;
            // 
            // TitlePanel
            // 
            TitlePanel.ColumnCount = 2;
            TitlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.5256424F));
            TitlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.4743576F));
            TitlePanel.Controls.Add(lblHeading, 0, 0);
            TitlePanel.Controls.Add(pictureBox4, 1, 0);
            TitlePanel.Dock = DockStyle.Fill;
            TitlePanel.Location = new Point(3, 3);
            TitlePanel.Name = "TitlePanel";
            TitlePanel.RowCount = 1;
            TitlePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TitlePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TitlePanel.Size = new Size(1561, 190);
            TitlePanel.TabIndex = 2;
            // 
            // lblHeading
            // 
            lblHeading.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Bahnschrift", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeading.ForeColor = Color.SteelBlue;
            lblHeading.Location = new Point(558, 0);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(274, 190);
            lblHeading.TabIndex = 1;
            lblHeading.Text = "Lập trình";
            lblHeading.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(838, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Padding = new Padding(0, 11, 0, 11);
            pictureBox4.Size = new Size(138, 184);
            pictureBox4.TabIndex = 2;
            pictureBox4.TabStop = false;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label6.AutoSize = true;
            label6.Font = new Font("Bahnschrift", 30F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.SteelBlue;
            label6.Location = new Point(388, 196);
            label6.Name = "label6";
            label6.Padding = new Padding(0, 0, 0, 5);
            label6.Size = new Size(790, 111);
            label6.TabIndex = 3;
            label6.Text = "Phần mềm quản lý thi trắc nghiệm";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // HomeUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Name = "HomeUserControl";
            Size = new Size(1573, 1033);
            mainPanel.ResumeLayout(false);
            informationContainerPanel.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            infoPanel1.ResumeLayout(false);
            infoPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            descPanel.ResumeLayout(false);
            descPanel.PerformLayout();
            TitlePanel.ResumeLayout(false);
            TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainPanel;
        private TableLayoutPanel informationContainerPanel;
        private TableLayoutPanel infoPanel1;
        private PictureBox pictureBox1;
        private Color pictureBoxColor;
        private Label lblSecondHeading;
        private Label label1;
        private TableLayoutPanel descPanel;
        private Label lblHeading;
        private TableLayoutPanel TitlePanel;
        private PictureBox pictureBox4;
        private Label label6;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label4;
        private PictureBox pictureBox3;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private PictureBox pictureBox2;
        private Label label3;
    }
}
