-- Add foreign keys with ON DELETE CASCADE and ON UPDATE CASCADE





ALTER TABLE [dbo].[tbl_LichTriLieu] 
ADD CONSTRAINT FK_tbl_LichTriLieu_LieuTrinh FOREIGN KEY ([MaLT]) REFERENCES [dbo].[tbl_LieuTrinh]([MaLT])
ON DELETE CASCADE ON UPDATE CASCADE;

-- tbl_DichVu references tbl_NhanVien
ALTER TABLE [dbo].[tbl_DichVu] 
ADD CONSTRAINT FK_tbl_DichVu_NhanVien FOREIGN KEY ([MaNV]) REFERENCES [dbo].[tbl_NhanVien]([MaNV])
ON DELETE CASCADE ON UPDATE CASCADE;

-- tbl_HoaDonDV references tbl_KhachHang
ALTER TABLE [dbo].[tbl_HoaDonDV] 
ADD CONSTRAINT FK_tbl_HoaDonDV_KhachHang FOREIGN KEY ([MaKH]) REFERENCES [dbo].[tbl_KhachHang]([MaKH])
ON DELETE CASCADE ON UPDATE CASCADE;

-- tbl_NhanVien references tbl_LoaiNhanVien
ALTER TABLE [dbo].[tbl_NhanVien] 
ADD CONSTRAINT FK_tbl_NhanVien_LoaiNhanVien FOREIGN KEY ([MaLoaiNV]) REFERENCES [dbo].[tbl_LoaiNhanVien]([MaLoaiNV])
ON DELETE CASCADE ON UPDATE CASCADE;

-- tbl_DanhGiaDV references tbl_DichVu and tbl_KhachHang
ALTER TABLE [dbo].[tbl_DanhGiaDV] 
ADD CONSTRAINT FK_tbl_DanhGiaDV_DichVu FOREIGN KEY ([MaDV]) REFERENCES [dbo].[tbl_DichVu]([MaDV])
ON DELETE CASCADE ON UPDATE CASCADE;
