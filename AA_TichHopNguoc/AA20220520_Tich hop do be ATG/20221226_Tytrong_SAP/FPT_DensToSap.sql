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
CREATE PROCEDURE FPT_DensToSap
	@p_date date, @p_INT_USER nvarchar(100) = null
AS
BEGIN
	declare @p_sDate nvarchar(50)
	declare @p_Plant nvarchar(100)
	begin try
		select @p_Plant = Plant_DB from tblconfig 
		select @p_sDate = Date_nd from FPT_tblTankActive_V  where Date1  =@p_date 

		select @p_Plant as WERKS,  Name_nd as LGORT
						, right( Date_nd,4) + substring(Date_nd,4,2) + left(Date_nd,2)  as DIPDATE
						--, isnull( updatedate,convert(datetime, convert (nvarchar(15), @p_date) +  ' 00:00:01',101) )   as DIM_TIME
					,   replace(  convert(varchaR(8),isnull( updatedate,convert(datetime, convert (nvarchar(15), @p_date) +  ' 00:00:01',101) )  ,114) ,':','')    as DIPTIME
						, Dens_nd as DENS_15
						,'X' as  INT_FLG 
						, @p_INT_USER as INT_USER 
				from [dbo].[tblTankActive_Hist] where Date_nd = @p_sDate
		select 0  as nNumber, null as nDesc
	end try

	begin catch
		select ERROR_NUMBER ()  as nNumber, ERROR_MESSAGE() as nDesc
	end catch
	
END
GO
