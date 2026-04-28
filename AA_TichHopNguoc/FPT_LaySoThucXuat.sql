-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
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
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION FPT_LaySoThucXuat
(@p_MaVanChuyen varchar(10)
	, @p_ThucXuat int, @p_DuXuat int, @p_Convert int
)
RETURNS  int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @p_Return int
	declare @p_Bo varchar(1)
	declare @p_Thuy varchar(1)
    
    set @p_Bo = (select  KeyValue from SYS_CONFIG with (nolock)  where KeyCode='TONGDUXUAT')
    set @p_Thuy = (select  KeyValue from SYS_CONFIG with (nolock) where KeyCode='TONGDUXUATTHUY')
    if dbo.FPT_GetLoadingSite (@p_MaVanChuyen) ='THUY'
		begin
		   if @p_Thuy='1' 
				set @p_Return= @p_DuXuat
		   else
				set @p_Return= @p_ThucXuat	
		end
    else
        begin
			if @p_Bo='1' 
				set @p_Return= @p_DuXuat
		    else
				set @p_Return= @p_ThucXuat	
        end
--select * from SYS_CONFIG
--where KeyCode='TONGDUXUATTHUY'
    return isnull(@p_Return,0)
END
GO

