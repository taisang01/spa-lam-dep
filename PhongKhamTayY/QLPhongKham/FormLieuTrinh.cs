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
    public partial class FormLieuTrinh : Form
    {
        DB.QLPhongKhamDBContext db;
        public FormLieuTrinh()
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
            if (txbTenLT.Text == "")
            {
                MessageBox.Show("Tên Liệu Trình Không Được Để Trống!");
                txbTenLT.Focus();
                return false;
            }
            else if (txbDonGia.Text == "")
            {
                MessageBox.Show("Đơn Giá Không Được Để Trống!");
                txbDonGia.Focus();
                return false;
            }
            else if (txbChiTietLT.Text == "")
            {
                MessageBox.Show("Chi Tiết Liệu Trình Không Được Để Trống!");
                txbChiTietLT.Focus();
                return false;
            }

            return true;
        }

        //load 
        void load()
        {
            var data = db.tbl_LieuTrinh.ToList();
            if (data.Count() > 0 && data != null)
            {
                dgvLoad.DataSource = data;
            }
        }


        private void label6_Click(object sender, EventArgs e)
        {

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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                if (KTDL())
                {
                    try
                    {
                        tbl_LieuTrinh dm = new tbl_LieuTrinh();
                        dm.TenLT = txbTenLT.Text;
                        dm.Gia = float.Parse(txbDonGia.Text);
                        dm.ChiTietLT = txbChiTietLT.Text;
                        dm.ThoiGianLT = dtpTGLTfrom.Value.ToString();
                        dm.ThoiGianLT = dtpTGLTto.Value.ToString();
                        db.tbl_LieuTrinh.Add(dm);
                        db.SaveChanges();
                        MessageBox.Show("Thêm mới thành công");

                        dgvLoad.Rows.Clear();
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
                if (txbMaLT.Text != "")
                {
                    long maLt = Convert.ToInt64(txbMaLT.Text);
                    var dm = db.tbl_LieuTrinh.Find(maLt);
                    dm.TenLT = txbTenLT.Text;
                    dm.Gia = float.Parse(txbDonGia.Text);
                    dm.ChiTietLT = txbChiTietLT.Text;
                    dm.ThoiGianLT = dtpTGLTfrom.Value.ToString();
                    dm.ThoiGianLT = dtpTGLTto.Value.ToString();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txbMaLT.Text != "")
            {
                long maLt = Convert.ToInt64(txbMaLT.Text);//
                var dm = db.tbl_LieuTrinh.Find(maLt);//
                db.tbl_LieuTrinh.Remove(dm);
                db.SaveChanges();
                MessageBox.Show("Thêm mới thành công");

                dgvLoad.Rows.Clear();
                load();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin để sửa");
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txbMaLT.Text = "";
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            them = true;
            sua = false;
            hide(false);

        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            them = false;
            sua = true;
            hide(false);
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (txbMaLT.Text != "")
            {
                long maLt = Convert.ToInt64(txbMaLT.Text);//
                var dm = db.tbl_LieuTrinh.Find(maLt);//
                db.tbl_LieuTrinh.Remove(dm);
                db.SaveChanges();
                MessageBox.Show("Thêm mới thành công");

                dgvLoad.Rows.Clear();
                load();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin để sửa");
            }

        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (them)
            {
                if (KTDL())
                {
                    try
                    {
                        tbl_LieuTrinh dm = new tbl_LieuTrinh();
                        dm.TenLT = txbTenLT.Text;
                        dm.Gia = float.Parse(txbDonGia.Text);
                        dm.ChiTietLT = txbChiTietLT.Text;
                        dm.ThoiGianLT = dtpTGLTfrom.Value.ToString();
                        dm.ThoiGianLT = dtpTGLTto.Value.ToString();
                        db.tbl_LieuTrinh.Add(dm);
                        db.SaveChanges();
                        MessageBox.Show("Thêm mới thành công");

                        dgvLoad.Rows.Clear();
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
                if (txbMaLT.Text != "")
                {
                    long maLt = Convert.ToInt64(txbMaLT.Text);
                    var dm = db.tbl_LieuTrinh.Find(maLt);
                    dm.TenLT = txbTenLT.Text;
                    dm.Gia = float.Parse(txbDonGia.Text);
                    dm.ChiTietLT = txbChiTietLT.Text;
                    dm.ThoiGianLT = dtpTGLTfrom.Value.ToString();
                    dm.ThoiGianLT = dtpTGLTto.Value.ToString();
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

        private void btnNhapLai_Click_1(object sender, EventArgs e)
        {
            txbMaLT.Text = "";
            txbTenLT.Text = "";
            txbChiTietLT.Text = "";
            txbDonGia.Text = "";

        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void dgvLoad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormLieuTrinh_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
