namespace QLPhongKham.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_HoaDonNhap
    {
        [Key]
        public long MaHDN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }

        public double? TongTien { get; set; }
    }
}
