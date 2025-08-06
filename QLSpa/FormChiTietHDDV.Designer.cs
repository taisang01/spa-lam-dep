
namespace QLSpa
{
    partial class FormChiTietHDDV
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
            this.btnThem = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnNhapLai = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbMaHDDV = new System.Windows.Forms.TextBox();
            this.cbbMaDV = new System.Windows.Forms.ComboBox();
            this.txbTongTien = new System.Windows.Forms.TextBox();
            this.txbSoLuong = new System.Windows.Forms.TextBox();
            this.dgvLoad = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MaHDDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(81, 288);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(91, 50);
            this.btnThem.TabIndex = 20;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnIn
            // 
            this.btnIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(1036, 288);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(114, 50);
            this.btnIn.TabIndex = 58;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(433, 288);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(91, 50);
            this.btnXoa.TabIndex = 57;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(253, 288);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(91, 50);
            this.btnSua.TabIndex = 56;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(865, 288);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(91, 50);
            this.btnLuu.TabIndex = 55;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnNhapLai
            // 
            this.btnNhapLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhapLai.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapLai.Location = new System.Drawing.Point(679, 288);
            this.btnNhapLai.Name = "btnNhapLai";
            this.btnNhapLai.Size = new System.Drawing.Size(120, 50);
            this.btnNhapLai.TabIndex = 54;
            this.btnNhapLai.Text = "Nhập lại";
            this.btnNhapLai.UseVisualStyleBackColor = true;
            this.btnNhapLai.Click += new System.EventHandler(this.btnNhapLai_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 23);
            this.label1.TabIndex = 59;
            this.label1.Text = "Mã hóa đơn dịch vụ :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 23);
            this.label3.TabIndex = 63;
            this.label3.Text = "Số lượng dịch vụ :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(668, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 23);
            this.label4.TabIndex = 64;
            this.label4.Text = "Mã dịch vụ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(675, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 23);
            this.label5.TabIndex = 65;
            this.label5.Text = "Tổng tiền :";
            // 
            // txbMaHDDV
            // 
            this.txbMaHDDV.Location = new System.Drawing.Point(293, 107);
            this.txbMaHDDV.Name = "txbMaHDDV";
            this.txbMaHDDV.Size = new System.Drawing.Size(315, 22);
            this.txbMaHDDV.TabIndex = 66;
            // 
            // cbbMaDV
            // 
            this.cbbMaDV.FormattingEnabled = true;
            this.cbbMaDV.Location = new System.Drawing.Point(813, 103);
            this.cbbMaDV.Name = "cbbMaDV";
            this.cbbMaDV.Size = new System.Drawing.Size(315, 24);
            this.cbbMaDV.TabIndex = 67;
            this.cbbMaDV.SelectedIndexChanged += new System.EventHandler(this.cbbMaDV_SelectedIndexChanged);
            // 
            // txbTongTien
            // 
            this.txbTongTien.Location = new System.Drawing.Point(813, 209);
            this.txbTongTien.Name = "txbTongTien";
            this.txbTongTien.Size = new System.Drawing.Size(240, 22);
            this.txbTongTien.TabIndex = 68;
            // 
            // txbSoLuong
            // 
            this.txbSoLuong.Location = new System.Drawing.Point(303, 206);
            this.txbSoLuong.Name = "txbSoLuong";
            this.txbSoLuong.Size = new System.Drawing.Size(315, 22);
            this.txbSoLuong.TabIndex = 69;
            // 
            // dgvLoad
            // 
            this.dgvLoad.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvLoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoad.Location = new System.Drawing.Point(-14, 358);
            this.dgvLoad.Name = "dgvLoad";
            this.dgvLoad.RowHeadersWidth = 51;
            this.dgvLoad.RowTemplate.Height = 24;
            this.dgvLoad.Size = new System.Drawing.Size(1221, 432);
            this.dgvLoad.TabIndex = 70;
            this.dgvLoad.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoad_CellContentClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHDDV,
            this.MaDV,
            this.TongTien,
            this.NgayLap});
            this.dataGridView1.Location = new System.Drawing.Point(-2, 358);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1190, 400);
            this.dataGridView1.TabIndex = 71;
            // 
            // MaHDDV
            // 
            this.MaHDDV.DataPropertyName = "MaHDDV";
            this.MaHDDV.HeaderText = "Mã Hóa Đơn Dịch Vụ";
            this.MaHDDV.MinimumWidth = 6;
            this.MaHDDV.Name = "MaHDDV";
            // 
            // MaDV
            // 
            this.MaDV.DataPropertyName = "MaDV";
            this.MaDV.HeaderText = "Mã Dịch Vụ";
            this.MaDV.MinimumWidth = 6;
            this.MaDV.Name = "MaDV";
            // 
            // TongTien
            // 
            this.TongTien.DataPropertyName = "SoLuong";
            this.TongTien.HeaderText = "Số Lượng Dịch Vụ";
            this.TongTien.MinimumWidth = 6;
            this.TongTien.Name = "TongTien";
            // 
            // NgayLap
            // 
            this.NgayLap.DataPropertyName = "TongTien";
            this.NgayLap.HeaderText = "Tổng Tiền";
            this.NgayLap.MinimumWidth = 6;
            this.NgayLap.Name = "NgayLap";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(412, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 29);
            this.label2.TabIndex = 74;
            this.label2.Text = "Chi tiết hóa đơn dịch vụ";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1068, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 32);
            this.button1.TabIndex = 54;
            this.button1.Text = "Tính";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormChiTietHDDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1200, 770);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dgvLoad);
            this.Controls.Add(this.txbSoLuong);
            this.Controls.Add(this.txbTongTien);
            this.Controls.Add(this.cbbMaDV);
            this.Controls.Add(this.txbMaHDDV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNhapLai);
            this.Controls.Add(this.btnThem);
            this.Name = "FormChiTietHDDV";
            this.Text = "Chi Tiết Hóa Đơn Dịch Vụ";
            this.Load += new System.EventHandler(this.ChiTietHDDV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnNhapLai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbMaHDDV;
        private System.Windows.Forms.ComboBox cbbMaDV;
        private System.Windows.Forms.TextBox txbTongTien;
        private System.Windows.Forms.TextBox txbSoLuong;
        private System.Windows.Forms.DataGridView dgvLoad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHDDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}