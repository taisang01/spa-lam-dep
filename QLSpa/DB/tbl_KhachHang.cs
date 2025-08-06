namespace QLSpa.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_KhachHang()
        {
            tbl_HoaDonDV = new HashSet<tbl_HoaDonDV>();
            tbl_LichTriLieu = new HashSet<tbl_LichTriLieu>();
        }

        [Key]
        public long MaKH { get; set; }

        [StringLength(100)]
        public string TenKH { get; set; }

        [StringLength(3)]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        public string Loai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HoaDonDV> tbl_HoaDonDV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_LichTriLieu> tbl_LichTriLieu { get; set; }
    }
}
