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
    public partial class FormLoaiNhanVien : Form
    {
        DB.QLPhongKhamDBContext db;
        public FormLoaiNhanVien()
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
            if (txbTenLoai.Text == "")
            {
                MessageBox.Show("Tên Loai Nhân Viên Không Được Để Trống!");
                txbTenLoai.Focus();
                return false;
            }
            else if (txbHeSo.Text == "")
            {
                MessageBox.Show("Chỉ Số Dịch Vụ Không Được Để Trống!");
                txbHeSo.Focus();
                return false;
            }

            return true;
        }

        void load()
        {
            var data = db.tbl_LoaiNhanVien.ToList();
            if (data.Count() > 0 && data != null)
            {
                dgvLoad.DataSource = data;
            }
        }

        private void FormLoaiNhanVien_Load(object sender, EventArgs e)
        {
            load();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            sua = false;
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
                        tbl_LoaiNhanVien dm = new tbl_LoaiNhanVien();
                        dm.TenLoai = txbTenLoai.Text;
                        dm.HeSo = float.Parse(txbHeSo.Text);
                        db.tbl_LoaiNhanVien.Add(dm);
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
                if (txbMaLoaiNV.Text != "")
                {
                    long maLnV = Convert.ToInt64(txbMaLoaiNV.Text);
                    var dm = db.tbl_LoaiNhanVien.Find(maLnV);
                    dm.TenLoai = txbTenLoai.Text;
                    dm.HeSo = float.Parse(txbHeSo.Text);
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
            txbMaLoaiNV.Text = "";
            txbTenLoai.Text = "";
            txbHeSo.Text = "";

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            sua = true;
            hide(false);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txbMaLoaiNV.Text != "")
            {
                long maLnV = Convert.ToInt64(txbMaLoaiNV.Text);//
                var dm = db.tbl_LoaiNhanVien.Find(maLnV);
                db.tbl_LoaiNhanVien.Remove(dm);
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
            txbMaLoaiNV.Text = dgvLoad[0, e.RowIndex].Value.ToString();
            txbTenLoai.Text = dgvLoad[1, e.RowIndex].Value.ToString();
            txbHeSo.Text = dgvLoad[2, e.RowIndex].Value.ToString();

        }
    }
}
