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
alter PROCEDURE FPT_TRangThaiSoLenhGhep
	-- Add the parameters for the stored procedure here
	@p_SoLenh nvarchar(2000)
AS
BEGIN
	declare @p_SoLenh22 nvarchar(2000)
	set @p_SoLenh22 =replace(@p_SoLenh,' ','')
	select SoLenh, Status from tblLenhXuatE5 with (nolock) where charindex (SoLenh,@p_SoLenh22, 1)>0
END
GO
