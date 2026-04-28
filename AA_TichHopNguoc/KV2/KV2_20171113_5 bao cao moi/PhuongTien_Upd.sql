-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER PhuongTien_Trigger_Upd
   ON  tblPhuongTien
   AFTER UPDATE
AS 
BEGIN
		INSERT INTO [KV2].[dbo].[tblPhuongTien_Hist]
			   ([MaPhuongTien]
			   ,[LaiXe]
			   ,[SoNgan]
			   ,[NgayBatDau]
			   ,[NgayHieuLuc]
			   ,[Status]
			   ,[SyncDate]
			   ,[iweight]
			   ,[Createby]
			   ,[UpdatedBy]
			   ,[CreateDate]
			   ,[UpdateDate]
			   ,[UpdStatus])
		 SELECT [MaPhuongTien]
			   ,[LaiXe]
			   ,[SoNgan]
			   ,[NgayBatDau]
			   ,[NgayHieuLuc]
			   ,[Status]
			   ,[SyncDate]
			   ,[iweight]
			   ,[Createby]
			   , [UpdatedBy]
			   ,[CreateDate]
			   ,getdate ()  as [UpdateDate]
			   ,'U' as [UpdStatus] from inserted --where  MaPhuongTien=deleted.MaPhuongTien
	
END
GO
