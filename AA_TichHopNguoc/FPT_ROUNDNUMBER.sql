
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION FPT_ROUNDNUMBER 
(@p_Value decimal (15,6),
  @p_Digit int	
)
RETURNS decimal  (15,6)
AS
BEGIN
	return round (@p_Value,@p_Digit)

END
GO

