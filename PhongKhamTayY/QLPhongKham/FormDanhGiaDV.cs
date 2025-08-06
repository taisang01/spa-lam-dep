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
    public partial class FormDanhGiaDV : Form
    {
        DB.QLPhongKhamDBContext db;
        public FormDanhGiaDV()
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
            if (txbChatLuongDV.Text == "")
            {
                MessageBox.Show("Chất Lượng Dịch Vụ Không Được Để Trống!");
                txbChatLuongDV.Focus();
                return false;
            }
            else if (txbGhiChu.Text == "")
            {
                MessageBox.Show("Ghi Chú Không Được Để Trống!");
                txbGhiChu.Focus();
                return false;
            }

            return true;
        }

        //load combobox
        void loadDichVu()
        {
            var data = db.tbl_DichVu.ToList();
            if (data != null && data.Count() > 0)
            {
                cbbMaDV.DataSource = data;
                cbbMaDV.DisplayMember = "TenDV";
                cbbMaDV.ValueMember = "MaDV";
                cbbMaDV.SelectedValue = 0;
            }
        }

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
                        tbl_DanhGiaDV dm = new tbl_DanhGiaDV();
                        dm.GhiChu = txbGhiChu.Text;
                        dm.ChatLuong = float.Parse(txbChatLuongDV.Text);
                        dm.MaDV = Convert.ToInt64(cbbMaDV.SelectedValue.ToString());
                        dm.MaKH = Convert.ToInt64(cbbMaKH.SelectedValue.ToString());
                        dm.Ngay = cbbNgay.Value;
                        db.tbl_DanhGiaDV.Add(dm);
                        db.SaveChanges();
                        MessageBox.Show("Thêm mới thành công");

                        dgvLoad.Rows.Clear();
                        //  load();

                    }
                    catch
                    {
                        MessageBox.Show("Thêm mới không thành công");
                    }
                }

            }

            if (sua)
            {
                if (txbMaDG.Text != "")
                {
                    long maNv = Convert.ToInt64(txbMaDG.Text);
                    var dm = db.tbl_DanhGiaDV.Find(maNv);
                    dm.GhiChu = txbGhiChu.Text;
                    dm.ChatLuong = float.Parse(txbChatLuongDV.Text);
                    dm.MaDV = Convert.ToInt64(cbbMaDV.SelectedValue.ToString());
                    dm.MaKH = Convert.ToInt64(cbbMaKH.SelectedValue.ToString());
                    dm.Ngay = cbbNgay.Value;
                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công");

                    dgvLoad.Rows.Clear();

                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thông tin để sửa");
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txbMaDG.Text != "")
            {
                long maNv = Convert.ToInt64(txbMaDG.Text);//
                var dm = db.tbl_NhanVien.Find(maNv);//
                db.tbl_NhanVien.Remove(dm);
                db.SaveChanges();
                MessageBox.Show("Thêm mới thành công");

                dgvLoad.Rows.Clear();

            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin để sửa");
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txbMaDG.Text = "";
            txbGhiChu.Text = "";
            txbChatLuongDV.Text = "";
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            load();
            loadDichVu();
            loadKhachHang();
        }

        private void dgvLoad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaDG.Text = dgvLoad[0, e.RowIndex].Value.ToString();
            cbbMaDV.Text = dgvLoad[1, e.RowIndex].Value.ToString();
            cbbMaKH.Text = dgvLoad[2, e.RowIndex].Value.ToString();
            cbbNgay.Text = dgvLoad[3, e.RowIndex].Value.ToString();
            txbChatLuongDV.Text = dgvLoad[4, e.RowIndex].Value.ToString();
            txbGhiChu.Text = dgvLoad[5, e.RowIndex].Value.ToString();
        }
        void load()
        {
            var data = db.tbl_DanhGiaDV.ToList();
            int i = 0;
            if (data != null && data.Count() > 0)
            {

                var n = data.Count();

                dgvLoad.Rows.Add(n);
                foreach (var a in data.ToList())
                {
                    dgvLoad.Rows[i].Cells[0].Value = a.MaDG;
                    var dichvu = db.tbl_DichVu.Find(a.MaDV);
                    dgvLoad.Rows[i].Cells[1].Value = dichvu.TenDV;
                    var khachhang = db.tbl_KhachHang.Find(a.MaKH);
                    dgvLoad.Rows[i].Cells[2].Value = khachhang.TenKH;
                    dgvLoad.Rows[i].Cells[3].Value = a.Ngay;
                    dgvLoad.Rows[i].Cells[4].Value = a.ChatLuong;
                    dgvLoad.Rows[i].Cells[5].Value = a.GhiChu;
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
            txbMaDG.Text = "";
            txbChatLuongDV.Text = "";
            txbGhiChu.Text = "";

        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (them)
            {
                if (KTDL())
                {
                    try
                    {
                        tbl_DanhGiaDV dm = new tbl_DanhGiaDV();
                        dm.GhiChu = txbGhiChu.Text;
                        dm.ChatLuong = float.Parse(txbChatLuongDV.Text);
                        dm.MaDV = Convert.ToInt64(cbbMaDV.SelectedValue.ToString());
                        dm.MaKH = Convert.ToInt64(cbbMaKH.SelectedValue.ToString());
                        dm.Ngay = cbbNgay.Value;
                        db.tbl_DanhGiaDV.Add(dm);
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
                if (txbMaDG.Text != "")
                {
                    long maNv = Convert.ToInt64(txbMaDG.Text);
                    var dm = db.tbl_DanhGiaDV.Find(maNv);
                    dm.GhiChu = txbGhiChu.Text;
                    dm.ChatLuong = float.Parse(txbChatLuongDV.Text);
                    dm.MaDV = Convert.ToInt64(cbbMaDV.SelectedValue.ToString());
                    dm.MaKH = Convert.ToInt64(cbbMaKH.SelectedValue.ToString());
                    dm.Ngay = cbbNgay.Value;
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
            if (txbMaDG.Text != "")
            {
                long maNv = Convert.ToInt64(txbMaDG.Text);//
                var dm = db.tbl_NhanVien.Find(maNv);//
                db.tbl_NhanVien.Remove(dm);
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

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void FormDanhGiaDV_Load(object sender, EventArgs e)
        {
            loadDichVu();
            loadKhachHang();
            load();
        }
    }
}