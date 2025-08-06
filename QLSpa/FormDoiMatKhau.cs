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
    public partial class FormDoiMatKhau : Form
    {
        DB.QLSPADBContext db = new DB.QLSPADBContext();
        public FormDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                long id = Convert.ToInt64(txtMNV.Text);
                var nhanvien = db.tbl_NhanVien.Find(id);
                if (nhanvien == null)
                {
                    MessageBox.Show("Nhân Viên Không Tồn Tại!!");
                }
                else
                {
                    if (nhanvien.Password.Trim() != txtMaKhauCu.Text.Trim())
                    {

                        MessageBox.Show("Mật Khẩu Cũ Không Đúng!!");

                    }
                    else
                    {
                        nhanvien.Password = txtMatKhauMoi.Text.Trim();
                        db.SaveChanges();
                        MessageBox.Show("Đổi Mật Khẩu Thành Công!!!");
                    }
                }



            }
            catch
            {
                MessageBox.Show("Nhập Không Đúng!!");

            }
        }
    }
}
