using QLSpa.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSpa
{
    public partial class FormHoaDonBanHang : Form
    {
        DB.QLSPADBContext db;
        public FormHoaDonBanHang()
        {
            InitializeComponent();
            db = new DB.QLSPADBContext();
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
            dgvLoad.DataSource = null;

            var data = db.tbl_HoaDonBanHang.ToList();
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
            if (txbMaHDBH.Text != "")
            {
                long maHdBh = Convert.ToInt64(txbMaHDBH.Text);
                var dm = db.tbl_HoaDonBanHang.Find(maHdBh);
                db.tbl_HoaDonBanHang.Remove(dm);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");

                 dgvLoad.Refresh();
                load();

            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin để xóa");
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txbMaHDBH.Text = "";
            txbTongTien.Text = "";
            hide(true);


        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                if (KTDL())
                {
                    try
                    {
                        tbl_HoaDonBanHang dm = new tbl_HoaDonBanHang();
                        dm.TongTien = float.Parse(txbTongTien.Text);
                        dm.NgayLap = dtpNgayLap.Value;
                        db.tbl_HoaDonBanHang.Add(dm);
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
                if (txbMaHDBH.Text != "")
                {
                    long maHdBh = Convert.ToInt64(txbMaHDBH.Text);
                    var dm = db.tbl_HoaDonBanHang.Find(maHdBh);
                    dm.TongTien = float.Parse(txbTongTien.Text);
                    dm.NgayLap = dtpNgayLap.Value;
                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công");

                     dgvLoad.Refresh();
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
            frmInHoaDonBanHang inhd = new frmInHoaDonBanHang();
            inhd.id = Convert.ToInt64(txbMaHDBH.Text);
            inhd.Show();
        }
        private void FormQLHoaDonBanHang_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormChiTietHDBH chitiet = new FormChiTietHDBH();
            chitiet.id = txbMaHDBH.Text;
            chitiet.Show();
        }

        private void dgvLoad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaHDBH.Text = dgvLoad[0, e.RowIndex].Value.ToString();
            dtpNgayLap.Text = dgvLoad[1, e.RowIndex].Value.ToString();
            txbTongTien.Text = dgvLoad[2, e.RowIndex].Value.ToString();
        }
    }
}
