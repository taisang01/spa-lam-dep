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
    public partial class frmInHoaDonBanHang : Form
    {
        public frmInHoaDonBanHang()
        {
            InitializeComponent();
        }
        public long id;
        private void frmInHoaDonBanHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1, id);

            this.reportViewer1.RefreshReport();
        }
    }
}
