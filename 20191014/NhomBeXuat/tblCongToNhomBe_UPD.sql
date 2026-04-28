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
CREATE TRIGGER tblCongToNhomBe_UPD
   ON  tblCongToNhomBe
   AFTER UPDATE
AS 
BEGIN
	
	INSERT INTO [dbo].[tblCongToNhomBe_Hist]
           ([ID]
           ,[MeterId]
           ,[Valid_from]
           ,[Valid_to]
           ,[Bexuat]
           ,[TankGroup]
           ,[TankGroup_Name]
           ,[MaHangHoa]
           ,[TenHangHoa]
           ,[Push_TDH]
           ,[Push_XTTD]
           ,[User_Push_TDH]
           ,[Date_Push_TDH]
           ,[User_Push_XTTD]
           ,[Date_Push_XTTD]
           ,[CreateUser]
           ,[CreateDate]
			,[UpdateUser]
           ,[UpdateDate]
           ,[sType])
     select [ID]
           ,[MeterId]
           ,[Valid_from]
           ,[Valid_to]
           ,[Bexuat]
           ,[TankGroup]
           ,[TankGroup_Name]
           ,[MaHangHoa]
           ,[TenHangHoa]
           ,[Push_TDH]
           ,[Push_XTTD]
           ,[User_Push_TDH]
           ,[Date_Push_TDH]
           ,[User_Push_XTTD]
           ,[Date_Push_XTTD]
           ,[CreateUser]
           ,CreateDate
           ,[UpdateUser]
           ,getdate()
           ,'U' 
		from inserted
END
GO
