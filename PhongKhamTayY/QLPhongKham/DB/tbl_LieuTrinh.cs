namespace QLPhongKham.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_LieuTrinh
    {
        [Key]
        public long MaLT { get; set; }

        [StringLength(100)]
        public string TenLT { get; set; }

        [StringLength(100)]
        public string ChiTietLT { get; set; }

        [StringLength(100)]
        public string ThoiGianLT { get; set; }

        public double? Gia { get; set; }
    }
}
