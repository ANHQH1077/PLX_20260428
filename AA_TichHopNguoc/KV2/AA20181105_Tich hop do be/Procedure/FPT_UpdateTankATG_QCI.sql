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
alter PROCEDURE FPT_UpdateTankATG_QCI
	@p_TankHeadercode nvarchar(100)
	
AS
BEGIN
	update ztblTankLineImp   set VCF = dbo.zzFPT_mdlQCI_GetVCF_NS (TankTemp, Dens) 
		  where  TankHeadercode    = @p_TankHeadercode
						and isnull(Dens,0) <> 0.0
	update ztblTankLineImp   set VolumnL15 =round( VCF * TankHeight,0)
		  where  TankHeadercode    = @p_TankHeadercode
						and isnull(Dens,0) <> 0.0
	update ztblTankLineImp   set VolumnKG = round( ( Dens -0.0011 ) * TankHeight,0) 
		  where  TankHeadercode    = @p_TankHeadercode
						and isnull(Dens,0) <> 0.0
END
GO
