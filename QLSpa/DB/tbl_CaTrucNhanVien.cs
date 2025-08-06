namespace QLSpa.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_CaTrucNhanVien
    {
        public long ID { get; set; }

        public long IDNhanVien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        [StringLength(50)]
        public string CaTruc { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public virtual tbl_NhanVien tbl_NhanVien { get; set; }
    }
}
