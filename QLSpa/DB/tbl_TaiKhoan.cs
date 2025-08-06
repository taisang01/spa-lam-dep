namespace QLSpa.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_TaiKhoan
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(40)]
        public string PassWord { get; set; }

        [StringLength(20)]
        public string Permission { get; set; }
    }
}
