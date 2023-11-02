namespace TracNghiemManager.GUI
{
    partial class fNhapInfo
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
            this.lblQuenMK = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmailorUsername = new System.Windows.Forms.TextBox();
            this.btnGui = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblQuenMK
            // 
            this.lblQuenMK.AutoSize = true;
            this.lblQuenMK.Location = new System.Drawing.Point(214, 19);
            this.lblQuenMK.Name = "lblQuenMK";
            this.lblQuenMK.Size = new System.Drawing.Size(82, 13);
            this.lblQuenMK.TabIndex = 0;
            this.lblQuenMK.Text = "Quên Mật Khẩu";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 77);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(142, 13);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Nhập Tài khoản hoặc Email:";
            // 
            // txtEmailorUsername
            // 
            this.txtEmailorUsername.Location = new System.Drawing.Point(160, 74);
            this.txtEmailorUsername.Multiline = true;
            this.txtEmailorUsername.Name = "txtEmailorUsername";
            this.txtEmailorUsername.Size = new System.Drawing.Size(286, 27);
            this.txtEmailorUsername.TabIndex = 2;
            // 
            // btnGui
            // 
            this.btnGui.Location = new System.Drawing.Point(304, 128);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(143, 35);
            this.btnGui.TabIndex = 3;
            this.btnGui.Text = "Gửi";
            this.btnGui.UseVisualStyleBackColor = true;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // fNhapInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 214);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.txtEmailorUsername);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblQuenMK);
            this.Name = "fNhapInfo";
            this.Text = "fQuenMatKhau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuenMK;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmailorUsername;
        private System.Windows.Forms.Button btnGui;
    }
}