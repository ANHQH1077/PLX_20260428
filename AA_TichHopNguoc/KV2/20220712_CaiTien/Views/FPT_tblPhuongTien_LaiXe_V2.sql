

 CREATE VIEW [dbo].[FPT_tblPhuongTien_LaiXe_V2] AS  
 SELECT     ID, MaPhuongTien, HoVaTen, NoiDung, FromDate, ToDate, sType, sDefault, 'N' AS CHECKUPD, Dem,  
 (SELECT     '1' AS Expr1  FROM          dbo.FPT_tblPhuongTien_V AS a  
 WHERE      (MaPhuongTien = b.MaPhuongTien) 
 AND (CONVERT(date, GETDATE()) >= CONVERT(date, ISNULL(NgayBatDau1, GETDATE() - 5)))  
 AND (CONVERT(date, GETDATE()) <= CONVERT(date,ISNULL(NgayHieuLuc1, GETDATE() + 5)))) AS X  
 ,UpdUser, UpdDate
 FROM       
 dbo.tblPhuongTien_LaiXe AS b 
GO


