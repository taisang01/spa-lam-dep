namespace QLPhongKham.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_LichTriLieu
    {
        [Key]
        public long MaLichTL { get; set; }

        public long MaKH { get; set; }

        public long MaLT { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }
    }
}
