namespace QLSpa.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_SanPham()
        {
            tbl_ChiTietHDBH = new HashSet<tbl_ChiTietHDBH>();
            tbl_ChiTietHDN = new HashSet<tbl_ChiTietHDN>();
        }

        [Key]
        public long MaSP { get; set; }

        [StringLength(100)]
        public string TenSP { get; set; }

        [StringLength(100)]
        public string MoTaSP { get; set; }

        public int? SLTon { get; set; }

        public double? GiaBan { get; set; }

        [Column(TypeName = "ntext")]
        public string HinhAnh { get; set; }

        public int? SoHieuNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ChiTietHDBH> tbl_ChiTietHDBH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ChiTietHDN> tbl_ChiTietHDN { get; set; }
    }
}
