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
    public partial class FormSanPham : Form
    {
        DB.QLPhongKhamDBContext db;
        public FormSanPham()
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
        void load()
        {
            var data = db.tbl_SanPham.ToList();
            if(data.Count()>0 && data != null)
            {
                dgvLoad.DataSource = data;
            }
        }
        bool KTDL()
        {
            if (txbTenSP.Text == "")
            {
                MessageBox.Show("Tên Sản Phẩm Không Được Để Trống!");
                txbTenSP.Focus();
                return false;
            }
            else if (txbMoTaSP.Text == "")
            {
                MessageBox.Show("Mô Tả Sản Phẩm Không Được Để Trống!");
                txbMoTaSP.Focus();
                return false;
            }
            else if (txbGiaBan.Text == "")
            {
                MessageBox.Show("Giá Bán Sản Phẩm Không Được Để Trống!");
                txbGiaBan.Focus();
                return false;
            }
            else if (txbSLTon.Text == "")
            {
                MessageBox.Show("Số Lượng Tồn Của Sản Phẩm Không Được Để Trống!");
                txbSLTon.Focus();
                return false;
            }

            else if (fileAnh == "")
            {
                MessageBox.Show("Hình Ảnh Của Sản Phẩm Không Được Để Trống!");
                return false;
            }    

            return true;
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
            if (txbMaSP.Text != "")
            {
                long maNv = Convert.ToInt64(txbMaSP.Text);//
                var dm = db.tbl_SanPham.Find(maNv);//
                db.tbl_SanPham.Remove(dm);
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

        private void btnNhapLai_Click_1(object sender, EventArgs e)
        {
            txbMaSP.Text = "";
            txbTenSP.Text = "";
            txbMoTaSP.Text = "";
            txbGiaBan.Text = "";
            txbSLTon.Text = "";
            txbSoHieuNhap.Text = "";
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {

            if (them)
            {
                if (KTDL())
                {
                    try
                    {
                        tbl_SanPham dm = new tbl_SanPham();
                        dm.TenSP = txbTenSP.Text;
                        dm.MoTaSP = txbMoTaSP.Text;
                        dm.GiaBan = float.Parse(txbGiaBan.Text);
                        dm.SLTon = int.Parse(txbSLTon.Text);
                        dm.SoHieuNhap = int.Parse(txbSoHieuNhap.Text);
                        dm.HinhAnh = fileAnh;
                        db.tbl_SanPham.Add(dm);
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
                if (txbMaSP.Text != "")
                {
                    long maSp = Convert.ToInt64(txbMaSP.Text);
                    var dm = db.tbl_SanPham.Find(maSp);
                    dm.TenSP = txbTenSP.Text;
                    dm.MoTaSP = txbMoTaSP.Text;
                    dm.GiaBan = float.Parse(txbGiaBan.Text);
                    dm.SLTon = int.Parse(txbSLTon.Text);
                    dm.SoHieuNhap = int.Parse(txbSoHieuNhap.Text);
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

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void dgvLoad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void dgvLoad_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txbMaSP.Text = dgvLoad[0, e.RowIndex].Value.ToString();
            txbTenSP.Text = dgvLoad[1, e.RowIndex].Value.ToString();
            txbSoHieuNhap.Text = dgvLoad[6, e.RowIndex].Value.ToString();
            txbMoTaSP.Text = dgvLoad[2, e.RowIndex].Value.ToString();
            txbSLTon.Text = dgvLoad[3, e.RowIndex].Value.ToString();
            txbGiaBan.Text = dgvLoad[4, e.RowIndex].Value.ToString();
            var path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\" + "Img\\";
            string filename = path + dgvLoad[5, e.RowIndex].Value.ToString();
            pictureBox1.Image = Image.FromFile(filename);
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
