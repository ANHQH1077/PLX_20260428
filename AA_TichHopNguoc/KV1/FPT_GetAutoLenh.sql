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
alter PROCEDURE FPT_GetAutoLenh
	@p_NgayThang datetime
AS
BEGIN
	select SoLenh, NgayXuat,dbo.FPT_GetLoadingSite( MavanChuyen) as MavanChuyen, MaPhuongTien From tbllenhxuate5 with (nolock)
		where NgayXuat =@p_NgayThang and Status  in ('3','31')
END
GO
