
-- =============================================
-- Author:		anhqh
-- Create date: 20150120
-- Description:	Trigger Insert
-- =============================================
create TRIGGER [dbo].[ztblTankHeaderImp_UPD]
   ON  [dbo].[ztblTankHeaderImp]
   FOR UPDATE
AS 
BEGIN
		INSERT INTO [ztblTankHeaderImp_Hist]
					   ([TankHeaderCode]
					   ,[CreateDate]
					   ,[FromDate]
					   ,[ToDate]
					   ,[Client]
					   ,[Tankcode]
					   ,[PurposeCode]
					   ,[Status]
					   ,[CreateUser]
					   ,[sType]
					   ,[crDate]
					   ,[App_User]
					   ,[App_Date]
					   ,[TankList]
					   ,[SyncUser]
					   ,[SyncDate]
					   ,[sStatus]
					   --,[sUser]
					   ,[dDate])
		SELECT 
			  [TankHeaderCode]
				   ,[CreateDate]
				   ,[FromDate]
				   ,[ToDate]
				   ,[Client]
				   ,[Tankcode]
				   ,[PurposeCode]
				   ,[Status]
				   ,[CreateUser]
				   ,[sType]
				   ,[crDate]
				   ,[App_User]
				   ,[App_Date]
				   ,[TankList]
				   ,[SyncUser]
				   ,[SyncDate]
				   ,'U' as [sStatus]
				  -- ,[sUser]
				   ,getdate() as [dDate]		
		FROM inserted  
		
END

GO


