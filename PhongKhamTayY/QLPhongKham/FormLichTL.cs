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
    public partial class FormLichTL : Form
    {
        DB.QLPhongKhamDBContext db;
        public FormLichTL()
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
            if (txbTrangThai.Text == "")
                {
                    MessageBox.Show("Trạng Thái Trị Liệu Không Được Để Trống!");
                    txbTrangThai.Focus();
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

        void loadLieuTrinh()
        {
            var data = db.tbl_LieuTrinh.ToList();
            if (data != null && data.Count() > 0)
            {
                cbbMaLT.DataSource = data;
                cbbMaLT.DisplayMember = "TenLT";
                cbbMaLT.ValueMember = "MaLT";
                cbbMaLT.SelectedValue = 0;
            }
        }
        void load()
        {
            var data = db.tbl_LichTriLieu.ToList();
            int i = 0;
            if (data != null && data.Count() > 0)
            {

                var n = data.Count();

                dgvLoad.Rows.Add(n);
                foreach (var a in data.ToList())
                {
                    dgvLoad.Rows[i].Cells[0].Value = a.MaLichTL;
                    var khachhang = db.tbl_KhachHang.Find(a.MaKH);
                    dgvLoad.Rows[i].Cells[1].Value = khachhang.TenKH;
                    var lieutrinh = db.tbl_LieuTrinh.Find(a.MaLT);
                    dgvLoad.Rows[i].Cells[2].Value = lieutrinh.TenLT;
                    dgvLoad.Rows[i].Cells[3].Value = a.TrangThai;
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

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            them = false;
            sua = true;
            hide(false);
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (txbMaLichTL.Text != "")
            {
                long maLtL = Convert.ToInt64(txbMaLichTL.Text);//
                var dm = db.tbl_LichTriLieu.Find(maLtL);//
                db.tbl_LichTriLieu.Remove(dm);
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

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (them)
            {
                if (KTDL())
                {
                    try
                    {
                        tbl_LichTriLieu dm = new tbl_LichTriLieu();
                        
                        dm.MaKH = Convert.ToInt64(cbbMaKH.SelectedValue.ToString());
                        dm.MaLT = Convert.ToInt64(cbbMaLT.SelectedValue.ToString());
                        dm.TrangThai = txbTrangThai.Text;
                        db.tbl_LichTriLieu.Add(dm);
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
                if (txbMaLichTL.Text != "")
                {
                    long maLtL = Convert.ToInt64(txbMaLichTL.Text);
                    var dm = db.tbl_LichTriLieu.Find(maLtL);
                    dm.MaKH = Convert.ToInt64(cbbMaKH.SelectedValue.ToString());
                    dm.MaLT = Convert.ToInt64(cbbMaLT.SelectedValue.ToString());
                    dm.TrangThai = txbTrangThai.Text;
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
            txbMaLichTL.Text = "";
            txbTrangThai.Text = "";
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void dgvLoad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaLichTL.Text = dgvLoad[0, e.RowIndex].Value.ToString();
            cbbMaKH.Text = dgvLoad[1, e.RowIndex].Value.ToString();
            cbbMaLT.Text = dgvLoad[2, e.RowIndex].Value.ToString();
            txbTrangThai.Text = dgvLoad[3, e.RowIndex].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormChiTietLTL chitiet = new FormChiTietLTL();
            chitiet.id = txbMaLichTL.Text;
            chitiet.Show();
        }

        private void FormLichTL_Load(object sender, EventArgs e)
        {
            load();
            loadKhachHang();
            loadLieuTrinh();
            
        }
    }
}
