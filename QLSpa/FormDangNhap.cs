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
    public partial class FormDangNhap : Form
    {
        QLSPADBContext db = new QLSPADBContext();
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void lklblDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(txbMaNV.Text);

            var data = db.tbl_NhanVien.Find(id);
            if (data != null) {

                if (data.Password.Trim() == txbMatKhau.Text.Trim()) {
                    Contants.id = data.MaLoaiNV;
                    FormMenu menu = new FormMenu(data.MaLoaiNV);
                    menu.Show();
                }
            }
            else
            {
                MessageBox.Show("Nhân viên không tồn tại");
            }
        }
    }
}
