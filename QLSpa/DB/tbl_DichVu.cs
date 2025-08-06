namespace QLSpa.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_DichVu()
        {
            tbl_ChiTietHDDV = new HashSet<tbl_ChiTietHDDV>();
            tbl_DanhGiaDV = new HashSet<tbl_DanhGiaDV>();
        }

        [Key]
        public long MaDV { get; set; }

        [StringLength(100)]
        public string TenDV { get; set; }

        public double? Gia { get; set; }

        public long MaNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ChiTietHDDV> tbl_ChiTietHDDV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_DanhGiaDV> tbl_DanhGiaDV { get; set; }

        public virtual tbl_NhanVien tbl_NhanVien { get; set; }
    }
}
