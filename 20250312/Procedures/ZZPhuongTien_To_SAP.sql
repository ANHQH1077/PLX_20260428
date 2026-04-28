-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
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
CREATE PROCEDURE ZZPhuongTien_To_SAP
	@p_MaPhuongTien nvarchar(100)
AS
BEGIN
	select aa.*,
			(select top 1 HoVaTen from tblPhuongTien_LaiXe abc where MaPhuongTien  =aa.[MaPhuongTien] 
				and convert(date,getdate())  > =  convert(date,isnull(FromDate,getdate()-1)) and  
				convert(date,getdate())  < =  convert(date,isnull(ToDate ,getdate()+1))) as DIRVER 	from  [FPT_tblPhuongTien_V] aa
					where MaPhuongTien = @p_MaPhuongTien;
	select * from  tblChiTietPhuongTien  where   MaPhuongTien = @p_MaPhuongTien;
END
GO
