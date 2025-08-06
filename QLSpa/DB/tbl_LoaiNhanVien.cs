namespace QLSpa.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_LoaiNhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_LoaiNhanVien()
        {
            tbl_NhanVien = new HashSet<tbl_NhanVien>();
        }

        [Key]
        public long MaLoaiNV { get; set; }

        [StringLength(100)]
        public string TenLoai { get; set; }

        public double? HeSo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_NhanVien> tbl_NhanVien { get; set; }
    }
}
