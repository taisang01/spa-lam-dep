namespace QLPhongKham.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_KhachHang
    {
        [Key]
        public long MaKH { get; set; }

        [StringLength(100)]
        public string TenKH { get; set; }

        [StringLength(3)]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        public string Loai { get; set; }
    }
}
