using QLPhongKham.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongKham
{
    public partial class FormHoaDonDV : Form
    {
        DB.QLPhongKhamDBContext db;
        public FormHoaDonDV()
        {
            InitializeComponent();
            db = new DB.QLPhongKhamDBContext();
        }


        //code
        bool them, sua;
        void hide(bool tt)
        {
            btnThem.Enabled = tt;
            btnSua.Enabled = tt;
            btnLuu.Enabled = !tt;
            btnXoa.Enabled = tt;

        }

        void load()
        {
            var data = db.tbl_HoaDonDV.ToList();
            int i = 0;
            if (data != null && data.Count() > 0)
            {

                var n = data.Count();

                dgvLoad.Rows.Add(n);
                foreach (var a in data.ToList())
                {
                    dgvLoad.Rows[i].Cells[0].Value = a.MaHDDV;
                    var khachhang = db.tbl_KhachHang.Find(a.MaKH);
                    dgvLoad.Rows[i].Cells[1].Value = khachhang.TenKH;
                    dgvLoad.Rows[i].Cells[2].Value = a.TongTien;
                    dgvLoad.Rows[i].Cells[3].Value = a.NgayLap;
                    i++;
                }
            }
        }

        bool KTDL()
        {
            if (txbTongTien.Text == "")
            {
                MessageBox.Show("Tong Tien Không Được Để Trống!");
                txbTongTien.Focus();
                return false;
            }

            return true;
        }


        //load combobox

    void loadKhachHang()
        {
            var data = db.tbl_KhachHang.ToList();
            if (data != null && data.Count() > 0)
            {
                cbbMaKH.DataSource = data;
                cbbMaKH.DisplayMember = "TenKH";
                cbbMaKH.ValueMember = "MaKH";
                cbbMaKH.SelectedValue = 0;
            }
        }

        private void FormHoaDonDV_Load(object sender, EventArgs e)
        {
            loadKhachHang();
            load();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            sua = false;
            hide(false);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            sua = true;
            hide(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txbMaHDDV.Text != "")
            {
                long maHdDv = Convert.ToInt64(txbMaHDDV.Text);//
                var dm = db.tbl_HoaDonDV.Find(maHdDv);//
                db.tbl_HoaDonDV.Remove(dm);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");

                dgvLoad.Rows.Clear();
                load();

            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin để xóa");
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                if (KTDL())
                {
                    try
                    {
                        tbl_HoaDonDV dm = new tbl_HoaDonDV();
                        dm.TongTien = float.Parse(txbTongTien.Text);
                        dm.MaKH = Convert.ToInt64(cbbMaKH.SelectedValue.ToString());
                        dm.NgayLap = dtpNgayLHD.Value;
                        db.tbl_HoaDonDV.Add(dm);
                        db.SaveChanges();
                        MessageBox.Show("Thêm mới thành công");

                        dgvLoad.Refresh();
                        load();

                    }
                    catch
                    {
                        MessageBox.Show("Thêm mới không thành công");
                    }
                }

            }

            if (sua)
            {
                if (txbMaHDDV.Text != "")
                {
                    long maHdDv = Convert.ToInt64(txbMaHDDV.Text);
                    var dm = db.tbl_HoaDonDV.Find(maHdDv);
                    dm.TongTien = float.Parse(txbTongTien.Text);
                    dm.MaKH = Convert.ToInt64(cbbMaKH.SelectedValue.ToString());
                    dm.NgayLap = dtpNgayLHD.Value;
                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công");

                    dgvLoad.Rows.Clear();
                    load();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thông tin để sửa");
                }

            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txbMaHDDV.Text = "";
            txbTongTien.Text = "";

        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormChiTietHDDV chiTiet = new FormChiTietHDDV();
            chiTiet.id = txbMaHDDV.Text;
            chiTiet.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaHDDV.Text = dgvLoad[0, e.RowIndex].Value.ToString();
            cbbMaKH.Text = dgvLoad[1, e.RowIndex].Value.ToString();
            txbTongTien.Text = dgvLoad[2, e.RowIndex].Value.ToString();
            dtpNgayLHD.Text = dgvLoad[3, e.RowIndex].Value.ToString();
        }
    }
}
