namespace QLSpa.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_HoaDonBanHang
    {
        [Key]
        public long MaHDBH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }

        public double? TongTien { get; set; }
    }
}
