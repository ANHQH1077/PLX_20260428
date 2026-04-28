
-- =============================================
-- Author:		anhqh
-- Create date: 20150120
-- Description:	Trigger Insert
-- =============================================
alter TRIGGER [dbo].[ztblTankBarem_INS]
   ON  [dbo].[ztblTankBarem]
   AFTER INSERT
AS 
BEGIN
		INSERT INTO [ztblTankBarem_Hist]
			   ([WERKS]
			   ,[SEQNR]
			   ,[LINCON]
			   ,[VOLCON]
			   ,[SyncDate]
			   ,SyncUser
			  )
		
		 SELECT 
				WERKS
				,SEQNR
				,LINCON
				,VOLCON
				,SyncDate
				,SyncUser
		 FROM Inserted	
END
