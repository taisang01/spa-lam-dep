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
    public partial class FormChiTietHDDV : Form
    {
        DB.QLPhongKhamDBContext db;
        public FormChiTietHDDV()
        {
            InitializeComponent();
            db = new DB.QLPhongKhamDBContext();
            
        }
        public  string id;
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
            if (txbSoLuong.Text == "")
            {
                MessageBox.Show("Chất Lượng Dịch Vụ Không Được Để Trống!");
                txbSoLuong.Focus();
                return false;
            }
            else if (txbTongTien.Text == "")
            {
                MessageBox.Show("Ghi Chú Không Được Để Trống!");
                txbTongTien.Focus();
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
                cbbMaDV.SelectedIndex = 0;
            }
        }
        void load()
        {
            var data = db.tbl_ChiTietHDDV.ToList();
            int i = 0;
            if (data != null && data.Count() > 0)
            {

                var n = data.Count();

                dataGridView1.Rows.Add(n);
                foreach (var a in data.ToList())
                {
                    dataGridView1.Rows[i].Cells[0].Value = a.MaHDDV;
                    var dichvu = db.tbl_DichVu.Find(a.MaDV);
                    dataGridView1.Rows[i].Cells[1].Value = dichvu.TenDV;
                    dataGridView1.Rows[i].Cells[2].Value = a.SoLuong;
                    dataGridView1.Rows[i].Cells[3].Value = a.TongTien;
                    i++;
                }
            }
        }

        private void ChiTietHDDV_Load(object sender, EventArgs e)
        {
            load();
            loadDichVu();
            txbMaHDDV.Text = id;

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
            if (txbMaHDDV.Text != "")
            {
                long maHdDv = Convert.ToInt64(txbMaHDDV.Text);
                var dm = db.tbl_ChiTietHDDV.Find(maHdDv);
                db.tbl_ChiTietHDDV.Remove(dm);
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
            txbMaHDDV.Text = "";
            txbSoLuong.Text = "";
            txbTongTien.Text = "";

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                if (KTDL())
                {
                    try
                    {
                        tbl_ChiTietHDDV dm = new tbl_ChiTietHDDV();
                        dm.MaHDDV = Convert.ToInt64(txbMaHDDV.Text);
                        dm.TongTien = float.Parse(txbTongTien.Text);
                        dm.SoLuong = int.Parse(txbSoLuong.Text);
                        dm.MaDV = Convert.ToInt64(cbbMaDV.SelectedValue.ToString());
                        db.tbl_ChiTietHDDV.Add(dm);
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
                if (txbMaHDDV.Text != "")
                {
                    long maHdDv = Convert.ToInt64(txbMaHDDV.Text);
                    var dm = db.tbl_ChiTietHDDV.Find(maHdDv);
                    dm.TongTien = float.Parse(txbTongTien.Text);
                    dm.SoLuong = int.Parse(txbSoLuong.Text);
                    dm.MaDV = Convert.ToInt64(cbbMaDV.SelectedValue.ToString());

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
            txbMaHDDV.Text = dgvLoad[0, e.RowIndex].Value.ToString();
            cbbMaDV.Text = dgvLoad[1, e.RowIndex].Value.ToString();
            txbSoLuong.Text = dgvLoad[2, e.RowIndex].Value.ToString();
            txbTongTien.Text = dgvLoad[3, e.RowIndex].Value.ToString();
        }

        private void cbbMaDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(cbbMaDV.SelectedValue.ToString());
            var data = db.tbl_DichVu.Find(id);
            txbTongTien.Text = (Convert.ToInt32(txbSoLuong.Text) * data.Gia).ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }
    }
}
