namespace QLPhongKham.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_LoaiNhanVien
    {
        [Key]
        public long MaLoaiNV { get; set; }

        [StringLength(100)]
        public string TenLoai { get; set; }

        public double? HeSo { get; set; }
    }
}
