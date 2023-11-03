namespace TracNghiemManager.GUI
{
    partial class fMatKhauMoi
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
			this.txtNhapMK = new System.Windows.Forms.TextBox();
			this.txtXacNhan = new System.Windows.Forms.TextBox();
			this.btnLuu = new System.Windows.Forms.Button();
			this.lbltext = new System.Windows.Forms.Label();
			this.lblEmail = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(37, 107);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(189, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nhập mật khẩu mới:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(37, 153);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(181, 28);
			this.label2.TabIndex = 0;
			this.label2.Text = "Xác nhận mật khẩu:";
			// 
			// txtNhapMK
			// 
			this.txtNhapMK.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNhapMK.Location = new System.Drawing.Point(249, 107);
			this.txtNhapMK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtNhapMK.Name = "txtNhapMK";
			this.txtNhapMK.Size = new System.Drawing.Size(316, 34);
			this.txtNhapMK.TabIndex = 1;
			// 
			// txtXacNhan
			// 
			this.txtXacNhan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtXacNhan.Location = new System.Drawing.Point(249, 153);
			this.txtXacNhan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtXacNhan.Name = "txtXacNhan";
			this.txtXacNhan.Size = new System.Drawing.Size(316, 34);
			this.txtXacNhan.TabIndex = 1;
			// 
			// btnLuu
			// 
			this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLuu.Location = new System.Drawing.Point(465, 215);
			this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnLuu.Name = "btnLuu";
			this.btnLuu.Size = new System.Drawing.Size(100, 44);
			this.btnLuu.TabIndex = 2;
			this.btnLuu.Text = "Lưu";
			this.btnLuu.UseVisualStyleBackColor = true;
			this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
			// 
			// lbltext
			// 
			this.lbltext.AutoSize = true;
			this.lbltext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbltext.Location = new System.Drawing.Point(37, 62);
			this.lbltext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbltext.Name = "lbltext";
			this.lbltext.Size = new System.Drawing.Size(63, 28);
			this.lbltext.TabIndex = 3;
			this.lbltext.Text = "Email:";
			// 
			// lblEmail
			// 
			this.lblEmail.AutoSize = true;
			this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEmail.Location = new System.Drawing.Point(244, 62);
			this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(65, 28);
			this.lblEmail.TabIndex = 4;
			this.lblEmail.Text = "label3";
			// 
			// fMatKhauMoi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(596, 272);
			this.Controls.Add(this.lblEmail);
			this.Controls.Add(this.lbltext);
			this.Controls.Add(this.btnLuu);
			this.Controls.Add(this.txtXacNhan);
			this.Controls.Add(this.txtNhapMK);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximumSize = new System.Drawing.Size(614, 319);
			this.MinimumSize = new System.Drawing.Size(614, 319);
			this.Name = "fMatKhauMoi";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "fMatKhauMoi";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNhapMK;
        private System.Windows.Forms.TextBox txtXacNhan;
        private System.Windows.Forms.Button btnLuu;
        public System.Windows.Forms.Label lbltext;
        public System.Windows.Forms.Label lblEmail;
    }
}