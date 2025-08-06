using QLPhongKham.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongKham
{
    public partial class FormNhanVien : Form
    {
        DB.QLPhongKhamDBContext db;
        public FormNhanVien()
        {
            InitializeComponent();
            db = new DB.QLPhongKhamDBContext();
        }
        //code
        bool them, sua;
        static string fileAnh;
        void hide(bool tt)
        {
            btnThem.Enabled = tt;
            btnSua.Enabled = tt;
            btnLuu.Enabled = !tt;
            btnXoa.Enabled = tt;

        }
        
        bool KTDL()
        {
            if (txbTenNV.Text == "")
            {
                MessageBox.Show("Tên Nhân Viên Không Được Để Trống!");
                txbTenNV.Focus();
                return false;
            }
            else if (txbChiSoDV.Text == "")
            {
                MessageBox.Show("Chỉ Số Dịch Vụ Không Được Để Trống!");
                txbChiSoDV.Focus();
                return false;
            }


            else if (fileAnh == "")
            {
                MessageBox.Show("Hình Ảnh Không Được Để Trống!");
                return false;
            }

            return true;
        }

        //load combobox
        void loadLoaiNhanVien()
        {
            var data = db.tbl_LoaiNhanVien.ToList();
            if(data != null && data.Count() > 0)
            {
                cbbMaLoaiNhanVien.DataSource = data;
                cbbMaLoaiNhanVien.DisplayMember = "TenLoai";
                cbbMaLoaiNhanVien.ValueMember = "MaLoaiNV";
                cbbMaLoaiNhanVien.SelectedValue = 0;
            }
        }

        void load()
        {
            var data = db.tbl_NhanVien.ToList();
            int i = 0;
            if (data != null && data.Count() > 0)
            {

                var n = data.Count();

                dgvLoad.Rows.Add(n);
                foreach (var a in data.ToList())
                {
                    dgvLoad.Rows[i].Cells[0].Value = a.MaNV;
                    dgvLoad.Rows[i].Cells[1].Value = a.TenNV;
                    var loainhanvien = db.tbl_LoaiNhanVien.Find(a.MaLoaiNV);
                    dgvLoad.Rows[i].Cells[2].Value = loainhanvien.TenLoai;
                    dgvLoad.Rows[i].Cells[3].Value = a.NgaySinh;
                    dgvLoad.Rows[i].Cells[4].Value = a.GioiTinh;
                    dgvLoad.Rows[i].Cells[5].Value = a.ChiSoDichVu;
                    dgvLoad.Rows[i].Cells[6].Value = a.HinhAnh;
                    dgvLoad.Rows[i].Cells[7].Value = a.NgayVaoLam;
                    i++;
                }
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
                        tbl_NhanVien dm = new tbl_NhanVien();
                        dm.TenNV = txbTenNV.Text;
                        dm.MaLoaiNV = Convert.ToInt64(cbbMaLoaiNhanVien.SelectedValue.ToString());
                        dm.NgaySinh = dtpNgaySinh.Value;
                        dm.NgayVaoLam = dtpNgayVaoLam.Value;
                        dm.GioiTinh = cbbGioiTinh.Text ;
                        dm.ChiSoDichVu = float.Parse(txbChiSoDV.Text) ;
                        dm.HinhAnh = fileAnh;
                        db.tbl_NhanVien.Add(dm);
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
                if (txbMaNV.Text != "")
                {
                    long maNv = Convert.ToInt64(txbMaNV.Text);
                    var dm = db.tbl_NhanVien.Find(maNv);
                    dm.TenNV = txbTenNV.Text;
                    dm.MaLoaiNV = Convert.ToInt64(cbbMaLoaiNhanVien.SelectedValue.ToString());
                    dm.NgaySinh = dtpNgaySinh.Value;
                    dm.NgayVaoLam = dtpNgayVaoLam.Value;
                    dm.GioiTinh = cbbGioiTinh.Text;
                    dm.ChiSoDichVu = float.Parse(txbChiSoDV.Text);
                    dm.HinhAnh = fileAnh;
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

        private void dgvAvatar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string appPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + @"\Img\"; // <---
            OpenFileDialog dalOpen = new OpenFileDialog();
            dalOpen.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            dalOpen.FilterIndex = 2;
            dalOpen.Title = "Anh Minh Hoa";

            if (dalOpen.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dalOpen.FileName);
                try
                {
                    System.IO.File.Copy(dalOpen.FileName, appPath + dalOpen.SafeFileName);
                    fileAnh = dalOpen.FileName.Substring(dalOpen.FileName.LastIndexOf("\\") + 1);
                }
                catch
                {
                    fileAnh = dalOpen.FileName.Substring(dalOpen.FileName.LastIndexOf("\\") + 1);
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txbMaNV.Text != "")
            {
                long maNv = Convert.ToInt64(txbMaNV.Text);//
                var dm = db.tbl_NhanVien.Find(maNv);//
                db.tbl_NhanVien.Remove(dm);
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
            txbMaNV.Text = "";
            txbChiSoDV.Text = "";
            txbTenNV.Text = "";
        }

        private void dgvLoad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaNV.Text = dgvLoad[0, e.RowIndex].Value.ToString();
            txbTenNV.Text = dgvLoad[1, e.RowIndex].Value.ToString();
            cbbMaLoaiNhanVien.Text = dgvLoad[2, e.RowIndex].Value.ToString();
            dtpNgaySinh.Text = dgvLoad[3, e.RowIndex].Value.ToString();
            cbbGioiTinh.Text = dgvLoad[4, e.RowIndex].Value.ToString();
            txbChiSoDV.Text = dgvLoad[5, e.RowIndex].Value.ToString();
            var path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\" + "Img\\";
            string filename = path + dgvLoad[6, e.RowIndex].Value.ToString();
            pictureBox1.Image = Image.FromFile(filename);
            dtpNgayVaoLam.Text = dgvLoad[7, e.RowIndex].Value.ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))
                             + @"\Img\";
            OpenFileDialog dalOpen = new OpenFileDialog();
            dalOpen.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            dalOpen.FilterIndex = 2;
            dalOpen.Title = "Anh Minh Hoa";

            if (dalOpen.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dalOpen.FileName);
                try
                {
                    System.IO.File.Copy(dalOpen.FileName, appPath + dalOpen.SafeFileName);
                    fileAnh = dalOpen.FileName.Substring(dalOpen.FileName.LastIndexOf("\\") + 1);
                }
                catch
                {
                    fileAnh = dalOpen.FileName.Substring(dalOpen.FileName.LastIndexOf("\\") + 1);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLoaiNhanVien loai = new FormLoaiNhanVien();
            loai.Show();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            loadLoaiNhanVien();
            load();
        }
    }
}
