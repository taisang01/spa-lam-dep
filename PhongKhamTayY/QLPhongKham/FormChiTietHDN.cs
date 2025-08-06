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
    public partial class FormChiTietHDN : Form
    {
        DB.QLPhongKhamDBContext db;
        public FormChiTietHDN()
        {
            InitializeComponent();
            db = new DB.QLPhongKhamDBContext();
        }


        //code
        public string id;
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
            if (txbSoLuong.Text == "")
            {
                MessageBox.Show("Số Lượng Không Được Để Trống!");
                txbSoLuong.Focus();
                return false;
            }
            else if (txbGiaNhap.Text == "")
            {
                MessageBox.Show("Giá Nhập Không Được Để Trống!");
                txbGiaNhap.Focus();
                return false;
            }
            else if (txbSoHieuNhap.Text == "")
            {
                MessageBox.Show("Số Hiệu Nhập Không Được Để Trống!");
                txbSoHieuNhap.Focus();
                return false;
            }
            else if (txbTongTien.Text == "")
            {
                MessageBox.Show("Tổng Tiền Không Được Để Trống!");
                txbTongTien.Focus();
                return false;
            }
            return true;
        }

        //load combobox
        void loadSanPham()
        {
            var data = db.tbl_SanPham.ToList();
            if (data != null && data.Count() > 0)
            {
                cbbMaSP.DataSource = data;
                cbbMaSP.DisplayMember = "TenSP";
                cbbMaSP.ValueMember = "MaSP";
                cbbMaSP.SelectedValue = 0;
            }
        }

        void load()
        {
            var data = db.tbl_ChiTietHDN.ToList();
            int i = 0;
            if (data != null && data.Count() > 0)
            {

                var n = data.Count();

                dgvLoad.Rows.Add(n);
                foreach (var a in data.ToList())
                {
                    dgvLoad.Rows[i].Cells[0].Value = a.MaHDN;
                    var sanpham = db.tbl_SanPham.Find(a.MaSP);
                    dgvLoad.Rows[i].Cells[1].Value = sanpham.TenSP;
                    dgvLoad.Rows[i].Cells[2].Value = a.SoLuong;
                    dgvLoad.Rows[i].Cells[3].Value = a.GiaNhap;
                    dgvLoad.Rows[i].Cells[4].Value = a.HanSD;
                    dgvLoad.Rows[i].Cells[5].Value = a.TongTien;
                    dgvLoad.Rows[i].Cells[6].Value = a.SoHieuNhap;
                    i++;
                }
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            them = true;
            sua = false;
            hide(false);

        }

        private void btnNhapLai_Click_1(object sender, EventArgs e)
        {
            txbMaHDN.Text = "";
            txbGiaNhap.Text = "";
            txbSoHieuNhap.Text = "";
            txbSoLuong.Text = "";
            txbTongTien.Text = "";

        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (them)
            {
                if (KTDL())
                {
                    try
                    {
                        tbl_ChiTietHDN dm = new tbl_ChiTietHDN();
                        dm.MaHDN = Convert.ToInt64(txbMaHDN.Text);
                        dm.MaSP = Convert.ToInt64(cbbMaSP.SelectedValue.ToString());
                        dm.SoLuong = int.Parse(txbSoLuong.Text);
                        dm.HanSD = dtpHSD.Value;
                        dm.TongTien = float.Parse(txbTongTien.Text);
                        dm.SoHieuNhap = int.Parse(txbSoHieuNhap.Text);
                        db.tbl_ChiTietHDN.Add(dm);
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
                    long maHdN = Convert.ToInt64(txbMaHDN.Text);
                    var dm = db.tbl_ChiTietHDN.Find(maHdN);
                    dm.MaSP = Convert.ToInt64(cbbMaSP.SelectedValue.ToString());
                    dm.SoLuong = int.Parse(txbSoLuong.Text);
                    dm.HanSD = dtpHSD.Value;
                    dm.TongTien = float.Parse(txbTongTien.Text);
                    dm.SoHieuNhap = int.Parse(txbSoHieuNhap.Text);
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

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            them = false;
            sua = true;
            hide(false);

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
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

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void dgvLoad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaHDN.Text = dgvLoad[0, e.RowIndex].Value.ToString();
            cbbMaSP.Text = dgvLoad[1, e.RowIndex].Value.ToString();
            txbSoLuong.Text = dgvLoad[2, e.RowIndex].Value.ToString();
            txbGiaNhap.Text = dgvLoad[3, e.RowIndex].Value.ToString();
            dtpHSD.Text = dgvLoad[4, e.RowIndex].Value.ToString();
            txbTongTien.Text = dgvLoad[5, e.RowIndex].Value.ToString();
            txbSoHieuNhap.Text = dgvLoad[6, e.RowIndex].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(cbbMaSP.SelectedValue.ToString());
            var data = db.tbl_SanPham.Find(id);
            txbTongTien.Text = (Convert.ToInt32(txbSoLuong.Text) * data.GiaBan).ToString();
        }

        private void FormHDNhap_Load(object sender, EventArgs e)
        {
            loadSanPham();
            load();
            txbMaHDN.Text = id;
        }
    }
}
