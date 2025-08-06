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
    public partial class FormKhachHang : Form
    {
        DB.QLPhongKhamDBContext db;
        public FormKhachHang()
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
            if (txbLoai.Text == "")
            {
                MessageBox.Show("Loại Khách Hàng Không Được Để Trống!");
                txbLoai.Focus();
                return false;
            }
            else if (txbTenKH.Text == "")
            {
                MessageBox.Show("Tên Của Khách Hàng Không Được Để Trống!");
                txbTenKH.Focus();
                return false;
            }

            return true;
        }

        //load 
        void load()
        {
            var data = db.tbl_KhachHang.ToList();
            if (data.Count() > 0 && data != null)
            {
                dgvLoad.DataSource = data;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txbMaKH.Text != "")
            {
                long maKh = Convert.ToInt64(txbMaKH.Text);
                var dm = db.tbl_KhachHang.Find(maKh);
                dm.GioiTinh = cbbGioiTinh.Text;
                dm.Loai = txbLoai.Text;
                dm.TenKH = txbTenKH.Text;
                db.tbl_KhachHang.Remove(dm);
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
            txbMaKH.Text = "";
            txbTenKH.Text = "";
            txbLoai.Text = "";

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
                        tbl_KhachHang dm = new tbl_KhachHang();
                        dm.GioiTinh = cbbGioiTinh.Text;
                        dm.Loai = txbLoai.Text;
                        dm.TenKH = txbTenKH.Text;
                        db.tbl_KhachHang.Add(dm);
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
                if (txbMaKH.Text != "")
                {
                    long maKh = Convert.ToInt64(txbMaKH.Text);
                    var dm = db.tbl_KhachHang.Find(maKh);
                    dm.GioiTinh = cbbGioiTinh.Text;
                    dm.TenKH = txbTenKH.Text;
                    dm.Loai = txbLoai.Text;
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

        private void dgvLoad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaKH.Text = dgvLoad[0, e.RowIndex].Value.ToString();
            txbTenKH.Text = dgvLoad[1, e.RowIndex].Value.ToString();
            cbbGioiTinh.Text = dgvLoad[2, e.RowIndex].Value.ToString();
            txbLoai.Text = dgvLoad[3, e.RowIndex].Value.ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
