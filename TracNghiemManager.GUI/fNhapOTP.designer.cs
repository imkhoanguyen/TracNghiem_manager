namespace TracNghiemManager.GUI
{
    partial class fNhapOTP
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
			this.components = new System.ComponentModel.Container();
			this.txtNhapMa = new System.Windows.Forms.TextBox();
			this.btnXacNhan = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.lblEmail = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtNhapMa
			// 
			this.txtNhapMa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNhapMa.Location = new System.Drawing.Point(21, 65);
			this.txtNhapMa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtNhapMa.Name = "txtNhapMa";
			this.txtNhapMa.Size = new System.Drawing.Size(271, 34);
			this.txtNhapMa.TabIndex = 0;
			// 
			// btnXacNhan
			// 
			this.btnXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXacNhan.Location = new System.Drawing.Point(344, 59);
			this.btnXacNhan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnXacNhan.Name = "btnXacNhan";
			this.btnXacNhan.Size = new System.Drawing.Size(163, 46);
			this.btnXacNhan.TabIndex = 2;
			this.btnXacNhan.Text = "Xác Nhận";
			this.btnXacNhan.UseVisualStyleBackColor = true;
			this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
			// 
			// lblEmail
			// 
			this.lblEmail.AutoSize = true;
			this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEmail.Location = new System.Drawing.Point(16, 32);
			this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(65, 28);
			this.lblEmail.TabIndex = 3;
			this.lblEmail.Text = "label1";
			// 
			// fNhapOTP
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(564, 219);
			this.Controls.Add(this.lblEmail);
			this.Controls.Add(this.btnXacNhan);
			this.Controls.Add(this.txtNhapMa);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximumSize = new System.Drawing.Size(582, 266);
			this.MinimumSize = new System.Drawing.Size(582, 266);
			this.Name = "fNhapOTP";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "fNhapMa";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNhapMa;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label lblEmail;
    }
}