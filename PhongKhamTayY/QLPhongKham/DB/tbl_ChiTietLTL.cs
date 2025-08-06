namespace QLPhongKham.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ChiTietLTL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaLichTL { get; set; }

        public int? Lan { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }
    }
}
