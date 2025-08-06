namespace QLPhongKham.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_NhanVien
    {
        [Key]
        public long MaNV { get; set; }

        [StringLength(100)]
        public string TenNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(3)]
        public string GioiTinh { get; set; }

        public double? ChiSoDichVu { get; set; }

        [Column(TypeName = "ntext")]
        public string HinhAnh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayVaoLam { get; set; }

        public long MaLoaiNV { get; set; }
    }
}
