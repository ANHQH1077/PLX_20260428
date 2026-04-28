ALTER VIEW [dbo].[FPT_tblPhuongTien_V]
AS
SELECT     dbo.tblPhuongTien.MaPhuongTien, dbo.tblPhuongTien.LaiXe, dbo.tblTu.TuText, dbo.tblPhuongTien.SoNgan, dbo.tblPhuongTien.NgayBatDau, 
                      dbo.tblPhuongTien.NgayHieuLuc, dbo.tblPhuongTien.Status, CONVERT(date, CASE WHEN dbo.tblPhuongTien.NgayBatDau = '00000000' THEN null
                      ELSE CONVERT(date, dbo.tblPhuongTien.NgayBatDau) END) AS NgayBatDau2, CONVERT(date, CASE WHEN dbo.tblPhuongTien.NgayHieuLuc = '00000000' THEN null
                       ELSE CONVERT(date, dbo.tblPhuongTien.NgayHieuLuc) END) AS NgayHieuLuc2, 'N' AS CHECKUPD, dbo.tblPhuongTien.iweight
					   , CONVERT(date, CASE WHEN dbo.tblPhuongTien.NgayBatDau = '00000000' THEN convert(nvarchar(20),getdate()+100,112) 
                      ELSE CONVERT(date, dbo.tblPhuongTien.NgayBatDau) END) AS NgayBatDau1, CONVERT(date, CASE WHEN dbo.tblPhuongTien.NgayHieuLuc = '00000000' THEN convert(nvarchar(20),getdate()-100,112)
                       ELSE CONVERT(date, dbo.tblPhuongTien.NgayHieuLuc) END) AS NgayHieuLuc1
FROM         dbo.tblTu INNER JOIN
                      dbo.tblPhuongTien ON dbo.tblTu.TuType = dbo.tblPhuongTien.LaiXe
GO


