using System.Windows.Forms;

namespace TracNghiem_manager
{
    partial class PermissionUserControl
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

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            tabPage2 = new TabPage();
            dataGridView2 = new DataGridView();
            tabPage3 = new TabPage();
            dataGridView3 = new DataGridView();
            tabPage4 = new TabPage();
            dataGridView4 = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            button4 = new Button();
            button2 = new Button();
            listBox1 = new ListBox();
            button3 = new Button();
            label3 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            listBox2 = new ListBox();
            button1 = new Button();
            button5 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            dataGridView3 = new DataGridView();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();

            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);

            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(39, 38);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(490, 658);

            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(427, 682);

            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);

            tabPage1.Size = new Size(482, 630);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Full";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(470, 548);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellDoubleClick += AdminCellDoubleClick;
            // 

            tabPage1.Size = new Size(419, 654);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Admin";
            tabPage1.UseVisualStyleBackColor = true;
            // 

            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);

            tabPage2.Size = new Size(482, 630);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Edit";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(6, 6);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(470, 532);
            dataGridView2.TabIndex = 0;
            // 

            tabPage2.Size = new Size(419, 654);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Teacher";
            tabPage2.UseVisualStyleBackColor = true;
            // 

            // tabPage3
            // 
            tabPage3.Controls.Add(dataGridView3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);

            tabPage3.Size = new Size(482, 630);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Create";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(6, 6);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.ReadOnly = true;
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(470, 515);
            dataGridView3.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(dataGridView4);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(482, 630);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "readOnly";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Location = new Point(6, 8);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.ReadOnly = true;
            dataGridView4.RowTemplate.Height = 25;
            dataGridView4.Size = new Size(470, 515);
            dataGridView4.TabIndex = 1;
            dataGridView4.CellContentClick += dataGridView4_CellContentClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 464F));
            tableLayoutPanel1.Controls.Add(panel2, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Location = new Point(563, 38);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 39.6521721F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60.34783F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(580, 658);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(listBox1);
            panel2.Controls.Add(button3);
            panel2.Location = new Point(124, 320);
            panel2.Name = "panel2";
            panel2.Size = new Size(445, 278);
            panel2.TabIndex = 5;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ActiveCaption;
            button4.Location = new Point(184, 199);
            button4.Name = "button4";
            button4.Size = new Size(75, 58);
            button4.TabIndex = 3;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(50, 199);
            button2.Name = "button2";
            button2.Size = new Size(75, 58);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = false;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.None;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(50, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(340, 184);
            listBox1.TabIndex = 0;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaption;
            button3.Location = new Point(315, 199);
            button3.Name = "button3";
            button3.Size = new Size(75, 58);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(27, 431);
            label3.Name = "label3";
            label3.Size = new Size(61, 56);
            label3.TabIndex = 2;
            label3.Text = "Chức Năng";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(23, 116);
            label2.Name = "label2";
            label2.Size = new Size(69, 28);
            label2.TabIndex = 1;
            label2.Text = "Quyền";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(button5);
            panel1.Controls.Add(listBox2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(124, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(446, 205);
            panel1.TabIndex = 4;
            // 
            // listBox2
            // 
            listBox2.Anchor = AnchorStyles.None;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(148, 22);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(149, 94);
            listBox2.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(50, 132);
            button1.Name = "button1";
            button1.Size = new Size(149, 33);
            button1.TabIndex = 0;
            button1.Text = "Thay Đổi Quyền";
            button1.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ActiveCaption;
            button5.Location = new Point(241, 132);
            button5.Name = "button5";
            button5.Size = new Size(149, 33);
            button5.TabIndex = 2;
            button5.Text = "Thêm Quyền";
            button5.UseVisualStyleBackColor = false;
            // 

            tabPage3.Size = new Size(419, 654);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Student";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(407, 571);
            dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(6, 6);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(407, 571);
            dataGridView2.TabIndex = 0;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(6, 6);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(407, 571);
            dataGridView3.TabIndex = 0;
            // 
            // PermissionUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PermissionUserControl";
            Size = new Size(1181, 727);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PermissionUserControl";
            Size = new Size(434, 689);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private TabPage tabPage4;
        private DataGridView dataGridView4;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Button button4;
        private Button button2;
        private ListBox listBox1;
        private Button button3;
        private Label label3;
        private Label label2;
        private Panel panel1;
        private ListBox listBox2;
        private Button button1;
        private Button button5;
    }
}
