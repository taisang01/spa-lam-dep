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
    public partial class FormHoaDonNhap : Form
    {
        DB.QLPhongKhamDBContext db;
        public FormHoaDonNhap()
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

        bool KTDL()
        {
            if (txbTongTien.Text == "")
            {
                MessageBox.Show("Tên Nhân Viên Không Được Để Trống!");
                txbTongTien.Focus();
                return false;
            }

            return true;
        }
        void load()
        {
            var data = db.tbl_HoaDonNhap.ToList();
            if (data.Count() > 0 && data != null)
            {
                dgvLoad.DataSource = data;
            }
        }
        private void FormHoaDonNhap_Load(object sender, EventArgs e)
        {
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
            if (txbMaHDN.Text != "")
            {
                long maHdN = Convert.ToInt64(txbMaHDN.Text);//
                var dm = db.tbl_HoaDonNhap.Find(maHdN);//
                db.tbl_HoaDonNhap.Remove(dm);
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

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txbMaHDN.Text = "";
            txbTongTien.Text = "";

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                if (KTDL())
                {
                    try
                    {
                        tbl_HoaDonNhap dm = new tbl_HoaDonNhap();
                        dm.TongTien = float.Parse(txbTongTien.Text);
                        dm.NgayNhap = dtpNgayNhap.Value;
                        db.tbl_HoaDonNhap.Add(dm);
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
                if (txbMaHDN.Text != "")
                {
                    long maHdn = Convert.ToInt64(txbMaHDN.Text);
                    var dm = db.tbl_HoaDonNhap.Find(maHdn);
                    dm.TongTien = float.Parse(txbTongTien.Text);
                    dm.NgayNhap = dtpNgayNhap.Value;
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

        private void btnIn_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            FormChiTietHDN chitiet = new FormChiTietHDN();
            chitiet.id = txbMaHDN.Text;
            chitiet.Show();
        }

        private void dgvLoad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaHDN.Text = dgvLoad[0, e.RowIndex].Value.ToString();
            dtpNgayNhap.Text = dgvLoad[1, e.RowIndex].Value.ToString();
            txbTongTien.Text = dgvLoad[2, e.RowIndex].Value.ToString();

        }
    }
}
