
-- =============================================
-- Author:		anhqh
-- Create date: 20150120
-- Description:	Trigger Insert
-- =============================================
CREATE TRIGGER [dbo].[zCardLists_DEL]
   ON  [dbo].zCardLists
   AFTER DELETE
AS 
BEGIN
		INSERT INTO [zCardLists_Hist]		
           ([CardNum]
           ,[sDesc]
           ,[FromDate]
           ,[ToDate]
           ,[Status]
           ,[Createby]
           ,[UpdatedBy]
           ,[CreateDate]
           ,[UpdateDate]
           ,[cType]
           ,[cDate]
		   ,CardData)     
		select 
			[CardNum]
           ,[sDesc]
           ,[FromDate]
           ,[ToDate]
           ,[Status]
           ,[Createby]
           ,[UpdatedBy]
           ,[CreateDate]
           ,[UpdateDate]
           ,'D'
           ,getdate()
		   ,CardData
		FROM Deleted 		
END

GO


