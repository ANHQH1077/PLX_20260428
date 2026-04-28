

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GetKeyztblTankHeader] 
	@p_Value nvarchar(500)
AS
BEGIN
	declare @p_Return TABLE (newKey nvarchar(50), NumberID nvarchar(50),AcDate date, CrDate datetime)
	declare @p_NumID as int
	INSERT INTO ztblTankHeaderKEY(CrUser)
		OUTPUT Inserted.ID,  Inserted.NumID,  convert(date, inserted.Crdate ) , inserted.Crdate  INTO @p_Return
		VALUES(@p_Value)
	select * from @p_Return
END

GO

