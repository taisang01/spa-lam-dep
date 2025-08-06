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
    public partial class FormCaTrucNhanVien : Form
    {
        DB.QLSPADBContext db;

        public FormCaTrucNhanVien()
        {
            InitializeComponent();
            db = new DB.QLSPADBContext();

        }

        bool them, sua;
        void hide(bool tt)
        {
            btnThem.Enabled = tt;
            btnSua.Enabled = tt;
            btnLuu.Enabled = !tt;
            btnXoa.Enabled = tt;

        }

        void loadLoaiNhanVien()
        {
            var data = db.tbl_NhanVien.ToList();
            if (data != null && data.Count() > 0)
            {
                cbbMaNV.DataSource = data;
                cbbMaNV.DisplayMember = "TenNV";
                cbbMaNV.ValueMember = "MaNV";
                cbbMaNV.SelectedValue = 0;
            }
        }
        void load()
        {
            if (Contants.id == 1)
            {
                dgvLoad.DataSource = null;
                var data = db.tbl_CaTrucNhanVien.ToList();
                if (data.Count() > 0 && data != null)
                {
                    dgvLoad.DataSource = data;
                }
            }
            else
            {
                dgvLoad.DataSource = null;
                var data = db.tbl_CaTrucNhanVien.Where(x=>x.IDNhanVien== Contants.id).ToList();
                if (data.Count() > 0 && data != null)
                {
                    dgvLoad.DataSource = data;
                }
            }
            
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    tbl_CaTrucNhanVien dm = new tbl_CaTrucNhanVien();
                    dm.IDNhanVien = Convert.ToInt64(cbbMaNV.SelectedValue.ToString());
                    dm.Ngay = datetimeNgay.Value;
                    dm.TrangThai = cbbTrangThai.Text;
                    dm.CaTruc = cbbCaTruc.Text;
                    db.tbl_CaTrucNhanVien.Add(dm);
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

            if (sua)
            {
                if (txtMaPC.Text != "")
                {
                    long id = Convert.ToInt64(txtMaPC.Text);
                    tbl_CaTrucNhanVien dm = db.tbl_CaTrucNhanVien.Find(id);
                    dm.IDNhanVien = Convert.ToInt64(cbbMaNV.SelectedValue.ToString());
                    dm.Ngay = datetimeNgay.Value;
                    dm.TrangThai = cbbTrangThai.Text;
                    dm.CaTruc = cbbCaTruc.Text;
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            sua = true;
            hide(false);
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            hide(true);

            txtMaPC.Text = "";
        }

        private void FormCaTrucNhanVien_Load(object sender, EventArgs e)
        {
            loadLoaiNhanVien();
            load();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                long id = Convert.ToInt64(txtMaPC.Text);
                tbl_CaTrucNhanVien dm = db.tbl_CaTrucNhanVien.Find(id);
                db.tbl_CaTrucNhanVien.Remove(dm);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");

                dgvLoad.Refresh();
                load();
            }
            catch
            {
                MessageBox.Show("Xóa KHÔNG thành công");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Contants.id == 1)
            {
                dgvLoad.DataSource = null;

                var data = db.tbl_CaTrucNhanVien.Where(x => x.TrangThai.Trim().Contains(cbbTrangThai.Text)).ToList();
                if (data.Count() > 0 && data != null)
                {
                    dgvLoad.DataSource = data;
                }
            }
            else
            {
                dgvLoad.DataSource = null;

                var data = db.tbl_CaTrucNhanVien.Where(x => x.IDNhanVien == Contants.id && x.TrangThai.Trim().Contains(cbbTrangThai.Text)).ToList();
                if (data.Count() > 0 && data != null)
                {
                    dgvLoad.DataSource = data;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (Contants.id == 1)
            {
                dgvLoad.DataSource = null;

                var data = db.tbl_CaTrucNhanVien.Where(x => x.Ngay.Value.Equals(datetimeNgay.Value.Date)).ToList();
                if (data.Count() > 0 && data != null)
                {
                    dgvLoad.DataSource = data;
                }
            }
            else
            {
                dgvLoad.DataSource = null;

                var data = db.tbl_CaTrucNhanVien.Where(x => x.IDNhanVien == Contants.id && x.Ngay.Value.Equals(datetimeNgay.Value.Date)).ToList();
                if (data.Count() > 0 && data != null)
                {
                    dgvLoad.DataSource = data;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Contants.id == 1)
            {
                dgvLoad.DataSource = null;

                var data = db.tbl_CaTrucNhanVien.Where(x => x.CaTruc.Trim().Contains(cbbCaTruc.Text)).ToList();
                if (data.Count() > 0 && data != null)
                {
                    dgvLoad.DataSource = data;
                }
            }
            else
            {
                dgvLoad.DataSource = null;

                var data = db.tbl_CaTrucNhanVien.Where(x => x.IDNhanVien == Contants.id && x.CaTruc.Trim().Contains(cbbCaTruc.Text)).ToList();
                if (data.Count() > 0 && data != null)
                {
                    dgvLoad.DataSource = data;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            sua = false;
            hide(false);
        }
    }
}
