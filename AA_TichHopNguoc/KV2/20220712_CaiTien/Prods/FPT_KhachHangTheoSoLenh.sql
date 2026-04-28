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
alter PROCEDURE FPT_KhachHangTheoSoLenh
	@p_SoLenhGhep nvarchar(4000)
	,@p_TableId nvarchar(4000) =null
AS
BEGIN
	if isnull(@p_TableId,'') =''
		begin
			select  distinct MaKhachHang  from  tblLenhXuatE5  with (nolock)   where CHARINDEX (SoLenh,@p_SoLenhGhep,1) >0 
			select a.SoLenh, a.TableID, b.MaKhachHang   from tblLenhXuat_HangHoaE5 a  with (nolock) ,tblLenhXuatE5 b  with (nolock)  
					where CHARINDEX (a.SoLenh,@p_SoLenhGhep,1) >0 
				and a.SoLenh =b.SoLenh 
		end
	else
		begin
			select distinct b.MaKhachHang   from tblLenhXuat_HangHoaE5 a  with (nolock) ,tblLenhXuatE5 b  with (nolock)  
					where CHARINDEX (a.TableID,@p_TableId,1) >0 
				and a.SoLenh =b.SoLenh 
		end
END
GO
