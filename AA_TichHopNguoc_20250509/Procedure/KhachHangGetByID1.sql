

Create PROC [dbo].[KhachHangGetByID1]
 @MaKhachHang nvarchar(10)
AS
 SELECT * FROM tblKhachHang WHERE MaKhachHang=@MaKhachHang
GO


