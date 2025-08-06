namespace QLSpa.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_DanhGiaDV
    {
        [Key]
        public long MaDG { get; set; }

        public long MaDV { get; set; }

        public long MaKH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        public double? ChatLuong { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        public virtual tbl_DichVu tbl_DichVu { get; set; }
    }
}
