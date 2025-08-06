namespace QLPhongKham.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_DichVu
    {
        [Key]
        public long MaDV { get; set; }

        [StringLength(100)]
        public string TenDV { get; set; }

        public double? Gia { get; set; }

        public long MaNV { get; set; }
    }
}
