
-- =============================================
-- Author:		anhqh
-- Create date: 20150120
-- Description:	Trigger Insert
-- =============================================
create TRIGGER [dbo].[zCardLists_INS]
   ON  [dbo].zCardLists
   AFTER INSERT
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
					   ,cType
					   ,cDate
					   ,CardData)
				SELECT 
					   [CardNum]
					   ,[sDesc]
					   ,[FromDate]
					   ,[ToDate]
					   ,[Status]
					   ,[Createby]
					   ,[UpdatedBy]
					   ,[CreateDate]
					   ,[UpdateDate]
					   ,'I'
					   ,getdate()
					   ,CardData
					   FROM Inserted
		
END

GO


