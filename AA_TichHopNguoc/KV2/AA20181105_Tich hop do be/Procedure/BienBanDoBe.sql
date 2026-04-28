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
create PROCEDURE BienBanDoBe
	@p_SoLenh int
AS
BEGIN
	select aa.CrDate as Ngay,aa.CrDate as Gio, aa.TankCode as Be, aa.ProductCode as MaHangHoa,
			 aa.TenHangHoa, aa.TankHeight as ChieuCao, aa.TankTemp as NhietDo , aa.PurposeCode as MaMDD, 
			 aa.PurposeName as TenMDD  from  dbo.ztblTankLineImp_v aa, ztblTankHeaderImp bb 
	  where aa.TankHeaderCode =bb.TankHeaderCode and bb.DocEntry=@p_SoLenh and aa.X='Y' ;
	   select * from dbo.ztblTankHeaderImp where DocEntry =@p_SoLenh;

END
GO
