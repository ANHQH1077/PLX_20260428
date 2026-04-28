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
CREATE PROCEDURE FPT_GetDensATG
	@p_Tank nvarchar(50)
	,@p_DateTime datetime
AS
BEGIN
	
	select  isnull((select top 1   dens  from dbo.ztblTankLineImp b where 
					b.tankcode =@p_Tank and isnull(b.Dens,0) >0
		and b.CrDate<=@p_DateTime order by b.CrDate desc),0) as Dens
END
GO
