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
    public partial class FormChiTietLTL : Form
    {
        DB.QLSPADBContext db;
        public FormChiTietLTL()
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
            if (txbGhiChu.Text == "")
            {
                MessageBox.Show("Ghi Chú Không Được Để Trống!");
                txbGhiChu.Focus();
                return false;
            }
            else if (txbLan.Text == "")
            {
                MessageBox.Show("Số Lần Điều Trị Không Được Để Trống!");
                txbLan.Focus();
                return false;
            }
            else if (txbTrangThai.Text == "")
            {
                MessageBox.Show("Trạng Thái Không Được Để Trống!");
                txbTrangThai.Focus();
                return false;
            }


            return true;
        }

        void load()
        {
            dgvLoad.DataSource = null;

            var data = db.tbl_ChiTietLTL.ToList();
            if (data.Count() > 0 && data != null)
            {
                dgvLoad.DataSource = data;
            }
        }
        private void FormChiTietLTL_Load(object sender, EventArgs e)
        {
            load();
            txbMaLichTL.Text = id;
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
            if (txbMaLichTL.Text != "")
            {
                long maLtL = Convert.ToInt64(txbMaLichTL.Text);
                var dm = db.tbl_ChiTietLTL.Find(maLtL);
                db.tbl_ChiTietLTL.Remove(dm);
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

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (them)
            {
                if (KTDL())
                {
                    try
                    {
                        tbl_ChiTietLTL dm = new tbl_ChiTietLTL();
                        dm.MaLichTL = Convert.ToInt64(txbMaLichTL.Text);
                        dm.Lan = int.Parse(txbLan.Text);
                        dm.TrangThai = txbTrangThai.Text;
                        dm.GhiChu = txbGhiChu.Text;
                        db.tbl_ChiTietLTL.Add(dm);
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
                    var dm = db.tbl_ChiTietLTL.Find(maLtL);
                    dm.Lan = int.Parse(txbLan.Text);
                    dm.TrangThai = txbTrangThai.Text;
                    dm.GhiChu = txbGhiChu.Text;
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

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txbMaLichTL.Text = "";
            txbLan.Text = "";
            txbTrangThai.Text = "";
            txbGhiChu.Text = "";
            hide(true);

        }

        private void dgvLoad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaLichTL.Text = dgvLoad[0, e.RowIndex].Value.ToString();
            txbLan.Text = dgvLoad[1, e.RowIndex].Value.ToString();
            txbGhiChu.Text = dgvLoad[2, e.RowIndex].Value.ToString();
            txbTrangThai.Text = dgvLoad[3, e.RowIndex].Value.ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }
    }
}
