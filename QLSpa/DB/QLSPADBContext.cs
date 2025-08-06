using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLSpa.DB
{
    public partial class QLSPADBContext : DbContext
    {
        public QLSPADBContext()
            : base("name=QLSPADBContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_CaTrucNhanVien> tbl_CaTrucNhanVien { get; set; }
        public virtual DbSet<tbl_ChiTietHDBH> tbl_ChiTietHDBH { get; set; }
        public virtual DbSet<tbl_ChiTietHDDV> tbl_ChiTietHDDV { get; set; }
        public virtual DbSet<tbl_ChiTietHDN> tbl_ChiTietHDN { get; set; }
        public virtual DbSet<tbl_ChiTietLTL> tbl_ChiTietLTL { get; set; }
        public virtual DbSet<tbl_DanhGiaDV> tbl_DanhGiaDV { get; set; }
        public virtual DbSet<tbl_DichVu> tbl_DichVu { get; set; }
        public virtual DbSet<tbl_HoaDonBanHang> tbl_HoaDonBanHang { get; set; }
        public virtual DbSet<tbl_HoaDonDV> tbl_HoaDonDV { get; set; }
        public virtual DbSet<tbl_HoaDonNhap> tbl_HoaDonNhap { get; set; }
        public virtual DbSet<tbl_KhachHang> tbl_KhachHang { get; set; }
        public virtual DbSet<tbl_LichTriLieu> tbl_LichTriLieu { get; set; }
        public virtual DbSet<tbl_LieuTrinh> tbl_LieuTrinh { get; set; }
        public virtual DbSet<tbl_LoaiNhanVien> tbl_LoaiNhanVien { get; set; }
        public virtual DbSet<tbl_NhanVien> tbl_NhanVien { get; set; }
        public virtual DbSet<tbl_SanPham> tbl_SanPham { get; set; }
        public virtual DbSet<tbl_TaiKhoan> tbl_TaiKhoan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_NhanVien>()
                .Property(e => e.Password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_NhanVien>()
                .HasMany(e => e.tbl_CaTrucNhanVien)
                .WithRequired(e => e.tbl_NhanVien)
                .HasForeignKey(e => e.IDNhanVien);

            modelBuilder.Entity<tbl_TaiKhoan>()
                .Property(e => e.UserName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TaiKhoan>()
                .Property(e => e.PassWord)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TaiKhoan>()
                .Property(e => e.Permission)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
