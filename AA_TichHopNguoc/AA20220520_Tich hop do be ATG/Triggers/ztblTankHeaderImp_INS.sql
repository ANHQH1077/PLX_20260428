

CREATE TRIGGER [dbo].[ztblTankHeaderImp_INS]
   ON  [ztblTankHeaderImp]
   AFTER INSERT
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
				   ,'I' as [sStatus]
				  -- ,[sUser]
				   ,getdate() as [dDate]		
			  FROM Inserted
		
END


