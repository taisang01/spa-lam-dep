namespace QLPhongKham.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_HoaDonDV
    {
        [Key]
        public long MaHDDV { get; set; }

        public long MaKH { get; set; }

        public double? TongTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }
    }
}
