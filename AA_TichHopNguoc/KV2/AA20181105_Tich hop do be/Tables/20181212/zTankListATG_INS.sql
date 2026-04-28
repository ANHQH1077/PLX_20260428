


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[zTankListATG_INS]
   ON  [dbo].[zTankListATG]
   AFTER INSERT
AS 
BEGIN
			INSERT INTO [zTankListATG_Hist] ([TankCode] ,[Product],[CrDate],[CrUser],
								[Client],[Status],[DateHist])
		 SELECT
					[TankCode] ,[Product],[CrDate],[CrUser],
								[Client],'I',getdate() as DateHist					   
		FROM inserted 

END



GO


