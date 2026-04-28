

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[FPT_CheckTankE5]
(
	@p_Meter nvarchar(50)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @p_Return int
	set @p_Return=0
	
    select top 1  @p_Return=1 from tblMeterE5  where  TankE5 =@p_Meter
	
	RETURN @p_Return

END


GO

