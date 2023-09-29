namespace TracNghiem_manager
{
    partial class Exam
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
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            label5 = new Label();
            label3 = new Label();
            textBox6 = new TextBox();
            Column8 = new DataGridViewTextBoxColumn();
            label6 = new Label();
            tableLayoutPanel7 = new TableLayoutPanel();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            button6 = new Button();
            button5 = new Button();
            button3 = new Button();
            button4 = new Button();
            button1 = new Button();
            button2 = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            textBox5 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            textBox4 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label7 = new Label();
            textBox3 = new TextBox();
            label8 = new Label();
            textBox7 = new TextBox();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 27);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 11;
            label1.Text = "Mã ca thi:  ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(311, 27);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 11;
            label4.Text = "Số câu dễ: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 77);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 11;
            label2.Text = "Tên ca thi: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(311, 77);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 11;
            label5.Text = "Số câu khó: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 127);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 11;
            label3.Text = "Tên kì thi:";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(407, 130);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(179, 23);
            textBox6.TabIndex = 12;
            // 
            // Column8
            // 
            Column8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column8.HeaderText = "Thời Gian Kết Thúc";
            Column8.Name = "Column8";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(311, 127);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 11;
            label6.Text = "TG bắt đầu: ";
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Controls.Add(dataGridView1, 0, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 3);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(1074, 354);
            tableLayoutPanel7.TabIndex = 14;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column6, Column7, Column5, Column8 });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1074, 354);
            dataGridView1.TabIndex = 12;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "Mã Ca Thi";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "Tên Ca Thi";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.HeaderText = "Tên Kì Thi";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.HeaderText = "Mã Môn";
            Column4.Name = "Column4";
            // 
            // Column6
            // 
            Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column6.HeaderText = "Số Câu Dễ";
            Column6.Name = "Column6";
            // 
            // Column7
            // 
            Column7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column7.HeaderText = "Số Câu khó";
            Column7.Name = "Column7";
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column5.HeaderText = "Thời Gian Bắt Đầu";
            Column5.Name = "Column5";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel7, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.Size = new Size(1080, 600);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.5066147F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.4933853F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 363);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1074, 234);
            tableLayoutPanel2.TabIndex = 12;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(button6, 1, 3);
            tableLayoutPanel4.Controls.Add(button5, 0, 3);
            tableLayoutPanel4.Controls.Add(button3, 0, 2);
            tableLayoutPanel4.Controls.Add(button4, 1, 2);
            tableLayoutPanel4.Controls.Add(button1, 0, 1);
            tableLayoutPanel4.Controls.Add(button2, 1, 1);
            tableLayoutPanel4.Location = new Point(631, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 5;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10.8490562F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 24.5283012F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 24.0566044F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 15.5660381F));
            tableLayoutPanel4.Size = new Size(440, 228);
            tableLayoutPanel4.TabIndex = 14;
            // 
            // button6
            // 
            button6.BackColor = Color.DodgerBlue;
            button6.Dock = DockStyle.Left;
            button6.Location = new Point(223, 136);
            button6.Name = "button6";
            button6.Size = new Size(120, 51);
            button6.TabIndex = 5;
            button6.Text = "Xuất Excel";
            button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.DodgerBlue;
            button5.Dock = DockStyle.Right;
            button5.Location = new Point(97, 136);
            button5.Name = "button5";
            button5.Size = new Size(120, 51);
            button5.TabIndex = 5;
            button5.Text = "Nhập Excel";
            button5.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.DodgerBlue;
            button3.Dock = DockStyle.Right;
            button3.Location = new Point(97, 82);
            button3.Name = "button3";
            button3.Size = new Size(120, 48);
            button3.TabIndex = 5;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.DodgerBlue;
            button4.Dock = DockStyle.Left;
            button4.Location = new Point(223, 82);
            button4.Name = "button4";
            button4.Size = new Size(120, 48);
            button4.TabIndex = 5;
            button4.Text = "Clear";
            button4.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.Dock = DockStyle.Right;
            button1.Location = new Point(97, 27);
            button1.Name = "button1";
            button1.Size = new Size(120, 49);
            button1.TabIndex = 5;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.DodgerBlue;
            button2.Dock = DockStyle.Left;
            button2.Location = new Point(223, 27);
            button2.Name = "button2";
            button2.Size = new Size(120, 49);
            button2.TabIndex = 5;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.0081568F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.5840149F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.447154F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.79675F));
            tableLayoutPanel3.Controls.Add(label1, 0, 1);
            tableLayoutPanel3.Controls.Add(label4, 2, 1);
            tableLayoutPanel3.Controls.Add(label2, 0, 2);
            tableLayoutPanel3.Controls.Add(label5, 2, 2);
            tableLayoutPanel3.Controls.Add(label3, 0, 3);
            tableLayoutPanel3.Controls.Add(label6, 2, 3);
            tableLayoutPanel3.Controls.Add(textBox6, 3, 3);
            tableLayoutPanel3.Controls.Add(textBox5, 3, 2);
            tableLayoutPanel3.Controls.Add(textBox2, 1, 2);
            tableLayoutPanel3.Controls.Add(textBox1, 1, 1);
            tableLayoutPanel3.Controls.Add(textBox4, 3, 1);
            tableLayoutPanel3.Controls.Add(dateTimePicker1, 1, 3);
            tableLayoutPanel3.Controls.Add(label7, 2, 4);
            tableLayoutPanel3.Controls.Add(textBox3, 3, 4);
            tableLayoutPanel3.Controls.Add(label8, 0, 4);
            tableLayoutPanel3.Controls.Add(textBox7, 1, 4);
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 5;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 11.95652F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 22.01087F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 22.01087F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 22.01087F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 22.01087F));
            tableLayoutPanel3.Size = new Size(622, 228);
            tableLayoutPanel3.TabIndex = 13;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(407, 80);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(179, 23);
            textBox5.TabIndex = 12;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(96, 80);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(159, 23);
            textBox2.TabIndex = 12;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(96, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(159, 23);
            textBox1.TabIndex = 12;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(407, 30);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(179, 23);
            textBox4.TabIndex = 12;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(96, 130);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(159, 23);
            dateTimePicker1.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Left;
            label7.Location = new Point(311, 177);
            label7.Name = "label7";
            label7.Size = new Size(72, 51);
            label7.TabIndex = 11;
            label7.Text = "TG kết thúc: ";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(407, 180);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(179, 23);
            textBox3.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 177);
            label8.Name = "label8";
            label8.Size = new Size(61, 15);
            label8.TabIndex = 11;
            label8.Text = "Mã môn:  ";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(96, 180);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(159, 23);
            textBox7.TabIndex = 12;
            // 
            // Exam
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "Exam";
            Size = new Size(1080, 600);
            tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label4;
        private Label label2;
        private Label label5;
        private Label label3;
        private TextBox textBox6;
        private DataGridViewTextBoxColumn Column8;
        private Label label6;
        private TableLayoutPanel tableLayoutPanel7;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column5;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel4;
        private Button button6;
        private Button button5;
        private Button button3;
        private Button button4;
        private Button button1;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox textBox5;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox textBox4;
        private DateTimePicker dateTimePicker1;
        private Label label7;
        private TextBox textBox3;
        private Label label8;
        private TextBox textBox7;
    }
}
