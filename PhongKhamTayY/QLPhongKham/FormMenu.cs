using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongKham
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormKhachHang khachHang = new FormKhachHang();
            khachHang.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDichVu dichVu = new FormDichVu();
            dichVu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormNhanVien nhanVien = new FormNhanVien();
            nhanVien.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormHoaDonDV donDV = new FormHoaDonDV();
            donDV.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormLichTL formLichTL = new FormLichTL();
            formLichTL.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormLieuTrinh lieuTrinh = new FormLieuTrinh();
            lieuTrinh.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormSanPham sanpham = new FormSanPham();
            sanpham.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormHoaDonBanHang banhang = new FormHoaDonBanHang();
            banhang.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormHoaDonNhap hDNhap = new FormHoaDonNhap();
            hDNhap.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormDanhGiaDV danhGiaDV = new FormDanhGiaDV();
            danhGiaDV.Show();
        }
    }
}
