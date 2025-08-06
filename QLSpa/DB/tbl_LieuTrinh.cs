namespace QLSpa.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_LieuTrinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_LieuTrinh()
        {
            tbl_LichTriLieu = new HashSet<tbl_LichTriLieu>();
        }

        [Key]
        public long MaLT { get; set; }

        [StringLength(100)]
        public string TenLT { get; set; }

        [StringLength(100)]
        public string ChiTietLT { get; set; }

        [StringLength(100)]
        public string ThoiGianLT { get; set; }

        public double? Gia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_LichTriLieu> tbl_LichTriLieu { get; set; }
    }
}
