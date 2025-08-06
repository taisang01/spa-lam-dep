namespace QLSpa.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_NhanVien()
        {
            tbl_CaTrucNhanVien = new HashSet<tbl_CaTrucNhanVien>();
            tbl_DichVu = new HashSet<tbl_DichVu>();
        }

        [Key]
        public long MaNV { get; set; }

        [StringLength(100)]
        public string TenNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(3)]
        public string GioiTinh { get; set; }

        public double? ChiSoDichVu { get; set; }

        [Column(TypeName = "ntext")]
        public string HinhAnh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayVaoLam { get; set; }

        public long MaLoaiNV { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CaTrucNhanVien> tbl_CaTrucNhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_DichVu> tbl_DichVu { get; set; }

        public virtual tbl_LoaiNhanVien tbl_LoaiNhanVien { get; set; }
    }
}
