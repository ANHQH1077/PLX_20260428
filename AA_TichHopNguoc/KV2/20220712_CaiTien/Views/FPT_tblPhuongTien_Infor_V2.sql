
 create view [dbo].[FPT_tblPhuongTien_Infor_V2] as
 SELECT  [ID] ,[MaPhuongTien],[NoiDung] ,[FromDate] ,[ToDate] ,[sType] ,'N' as CHECKUPD  
 ,UpdUser, UpdDate
 FROM [tblPhuongTien_Infor] 
GO


