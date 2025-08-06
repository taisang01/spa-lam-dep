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
    public partial class FormChiTietHDBH : Form
    {
        DB.QLSPADBContext db;
        public FormChiTietHDBH()
        {
            InitializeComponent();
            db = new DB.QLSPADBContext();
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
            dgvLoad.DataSource = null;

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
            var data = db.tbl_ChiTietHDBH.ToList();
            int i = 0;
            if (data != null && data.Count() > 0)
            {

                var n = data.Count();

                dgvLoad.Rows.Add(n);
                foreach (var a in data.ToList())
                {
                    dgvLoad.Rows[i].Cells[0].Value = a.MaHDBH;
                    var sanpham = db.tbl_SanPham.Find(a.MaSP);
                    dgvLoad.Rows[i].Cells[1].Value = sanpham.TenSP;
                    dgvLoad.Rows[i].Cells[2].Value = a.SoLuong;
                    dgvLoad.Rows[i].Cells[3].Value = a.TongTien;
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
            if (txbMaHDBH.Text != "")
            {
                long mahDbH = Convert.ToInt64(txbMaHDBH.Text);
                long msp = Convert.ToInt64(cbbMaSP.SelectedValue.ToString());
                var dm = db.tbl_ChiTietHDBH.Where(x => x.MaHDBH == mahDbH && x.MaSP == msp).First();
                db.tbl_ChiTietHDBH.Remove(dm);
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
                        tbl_ChiTietHDBH dm = new tbl_ChiTietHDBH();
                        dm.MaHDBH = Convert.ToInt64(txbMaHDBH.Text);
                        dm.MaSP = Convert.ToInt64(cbbMaSP.SelectedValue.ToString());
                        dm.TongTien = float.Parse(txbTongTien.Text);
                        dm.SoLuong = Convert.ToInt32(txbSoLuong.Text);
                        db.tbl_ChiTietHDBH.Add(dm);
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
                    long mahDbH = Convert.ToInt64(txbMaHDBH.Text);
                    long msp = Convert.ToInt64(cbbMaSP.SelectedValue.ToString());
                    var dm = db.tbl_ChiTietHDBH.Where(x => x.MaHDBH == mahDbH && x.MaSP == msp).First();
                    dm.TongTien = float.Parse(txbTongTien.Text);
                    dm.SoLuong = Convert.ToInt32(txbSoLuong.Text);
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
            txbMaHDBH.Text = "";
            txbTongTien.Text = "";
            hide(true);

        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void dgvLoad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaHDBH.Text = dgvLoad[0, e.RowIndex].Value.ToString();
            cbbMaSP.Text = dgvLoad[1, e.RowIndex].Value.ToString();
            txbSoLuong.Text = dgvLoad[2, e.RowIndex].Value.ToString();
            txbTongTien.Text = dgvLoad[3, e.RowIndex].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(cbbMaSP.SelectedValue.ToString());
            var data = db.tbl_SanPham.Find(id);
            txbTongTien.Text = (Convert.ToInt32(txbSoLuong.Text) * data.GiaBan).ToString();
        }

        private void FormQLHoaDonBH_Load(object sender, EventArgs e)
        {
            loadSanPham();
            load();
            txbMaHDBH.Text = id;
        }
    }
}