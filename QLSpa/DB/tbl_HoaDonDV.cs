namespace QLSpa.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_HoaDonDV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_HoaDonDV()
        {
            tbl_ChiTietHDDV = new HashSet<tbl_ChiTietHDDV>();
        }

        [Key]
        public long MaHDDV { get; set; }

        public long MaKH { get; set; }

        public double? TongTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ChiTietHDDV> tbl_ChiTietHDDV { get; set; }

        public virtual tbl_KhachHang tbl_KhachHang { get; set; }
    }
}
