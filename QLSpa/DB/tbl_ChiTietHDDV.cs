namespace QLSpa.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ChiTietHDDV
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaHDDV { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaDV { get; set; }

        public int? SoLuong { get; set; }

        public double? TongTien { get; set; }

        public virtual tbl_DichVu tbl_DichVu { get; set; }

        public virtual tbl_HoaDonDV tbl_HoaDonDV { get; set; }
    }
}
