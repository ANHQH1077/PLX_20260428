


alter PROC [dbo].[KhachHangGetByID]
 @MaKhachHang nvarchar(10)
AS
 SELECT a.* ,  N'XN bán lẻ XD' AS TenDonVi33 FROM tblKhachHang a WHERE MaKhachHang=@MaKhachHang
GO


