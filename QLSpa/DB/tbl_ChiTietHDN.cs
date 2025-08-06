namespace QLSpa.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ChiTietHDN
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaHDN { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaSP { get; set; }

        public int? SoLuong { get; set; }

        public double? GiaNhap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanSD { get; set; }

        public double? TongTien { get; set; }

        public int? SoHieuNhap { get; set; }

        public virtual tbl_SanPham tbl_SanPham { get; set; }
    }
}
