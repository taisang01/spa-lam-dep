namespace QLPhongKham
{
    partial class FormDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDangNhap));
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.txbMaNV = new System.Windows.Forms.TextBox();
            this.txbMatKhau = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lklblDangKy = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.Red;
            this.btnDangNhap.Location = new System.Drawing.Point(248, 224);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(152, 50);
            this.btnDangNhap.TabIndex = 1;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            // 
            // txbMaNV
            // 
            this.txbMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMaNV.Location = new System.Drawing.Point(248, 94);
            this.txbMaNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbMaNV.Multiline = true;
            this.txbMaNV.Name = "txbMaNV";
            this.txbMaNV.Size = new System.Drawing.Size(304, 36);
            this.txbMaNV.TabIndex = 2;
            this.txbMaNV.TextChanged += new System.EventHandler(this.txbMaNV_TextChanged);
            // 
            // txbMatKhau
            // 
            this.txbMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMatKhau.Location = new System.Drawing.Point(248, 160);
            this.txbMatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbMatKhau.Multiline = true;
            this.txbMatKhau.Name = "txbMatKhau";
            this.txbMatKhau.Size = new System.Drawing.Size(304, 36);
            this.txbMatKhau.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 26);
            this.label1.TabIndex = 23;
            this.label1.Text = "Mã nhân viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 26);
            this.label2.TabIndex = 24;
            this.label2.Text = "Mật khẩu:";
            // 
            // lklblDangKy
            // 
            this.lklblDangKy.AutoSize = true;
            this.lklblDangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lklblDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lklblDangKy.Location = new System.Drawing.Point(411, 239);
            this.lklblDangKy.Name = "lklblDangKy";
            this.lklblDangKy.Size = new System.Drawing.Size(141, 20);
            this.lklblDangKy.TabIndex = 25;
            this.lklblDangKy.TabStop = true;
            this.lklblDangKy.Text = "Đăng ký tài khoản";
            this.lklblDangKy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklblDangKy_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(195, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 27);
            this.label3.TabIndex = 26;
            this.label3.Text = "Đăng nhập hệ thống";
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(625, 306);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lklblDangKy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbMatKhau);
            this.Controls.Add(this.txbMaNV);
            this.Controls.Add(this.btnDangNhap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormDangNhap";
            this.Text = "Đăng Nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.TextBox txbMaNV;
        private System.Windows.Forms.TextBox txbMatKhau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lklblDangKy;
        private System.Windows.Forms.Label label3;
    }
}