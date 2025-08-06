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
    public partial class FormDichVu : Form
    {
        DB.QLSPADBContext db;
        public FormDichVu()
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
            if (txbGia.Text == "")
            {
                MessageBox.Show("Giá Của Dịch Vụ Không Được Để Trống!");
                txbGia.Focus();
                return false;
            }
            else if (txbTenDV.Text == "")
            {
                MessageBox.Show("Tên Của Dịch Vụ Không Được Để Trống!");
                txbTenDV.Focus();
                return false;
            }

            return true;
        }

        //load combobox
        void loadNhanVien()
        {
            var data = db.tbl_NhanVien.ToList();
            if (data != null && data.Count() > 0)
            {
                cbbMaNV.DataSource = data;
                cbbMaNV.DisplayMember = "TenNhanVien";
                cbbMaNV.ValueMember = "MaNV";
                cbbMaNV.SelectedValue = 0;
            }
        }

        void load()
        {
            dgvLoad.DataSource = null;

            var data = db.tbl_DichVu.ToList();
            int i = 0;
            if (data != null && data.Count() > 0)
            {

                var n = data.Count();

                dgvLoad.Rows.Add(n);
                foreach (var a in data.ToList())
                {
                    dgvLoad.Rows[i].Cells[0].Value = a.MaDV;
                    dgvLoad.Rows[i].Cells[1].Value = a.TenDV;
                    dgvLoad.Rows[i].Cells[2].Value = a.Gia;
                    var nhanvien = db.tbl_NhanVien.Find(a.MaNV);
                    dgvLoad.Rows[i].Cells[3].Value = nhanvien.TenNV;
                    i++;
                }
            }
        }

        private void dgvLoad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaDV.Text = dgvLoad[0, e.RowIndex].Value.ToString();
            txbTenDV.Text = dgvLoad[1, e.RowIndex].Value.ToString();
            txbGia.Text = dgvLoad[2, e.RowIndex].Value.ToString();
            cbbMaNV.Text = dgvLoad[3, e.RowIndex].Value.ToString();
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
            if (txbMaDV.Text != "")
            {
                long maDv = Convert.ToInt64(txbMaDV.Text);//
                var dm = db.tbl_DichVu.Find(maDv);//
                db.tbl_DichVu.Remove(dm);
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
        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (them)
            {
                if (KTDL())
                {
                    try
                    {
                        tbl_DichVu dm = new tbl_DichVu();
                        dm.TenDV = txbTenDV.Text;
                        dm.MaNV = Convert.ToInt64(cbbMaNV.SelectedValue.ToString());
                        dm.Gia = float.Parse(txbGia.Text);

                        db.tbl_DichVu.Add(dm);
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
                if (txbMaDV.Text != "")
                {
                    long maDv = Convert.ToInt64(txbMaDV.Text);
                    var dm = db.tbl_DichVu.Find(maDv);
                    dm.TenDV = txbTenDV.Text;
                    dm.MaNV = Convert.ToInt64(cbbMaNV.SelectedValue.ToString());
                    dm.Gia = float.Parse(txbGia.Text);
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

        private void btnNhapLai_Click_1(object sender, EventArgs e)
        {
            hide(true);

            txbMaDV.Text = "";
            txbTenDV.Text = "";
            txbGia.Text = "";
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void FormDichVu_Load(object sender, EventArgs e)
        {
            loadNhanVien();
            load();

        }
    }
}
