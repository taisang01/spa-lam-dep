namespace QLPhongKham.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SanPham
    {
        [Key]
        public long MaSP { get; set; }

        [StringLength(100)]
        public string TenSP { get; set; }

        [StringLength(100)]
        public string MoTaSP { get; set; }

        public int? SLTon { get; set; }

        public double? GiaBan { get; set; }

        [Column(TypeName = "ntext")]
        public string HinhAnh { get; set; }

        public int? SoHieuNhap { get; set; }
    }
}
