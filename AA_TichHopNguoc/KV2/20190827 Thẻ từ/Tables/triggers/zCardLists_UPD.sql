

-- =============================================
-- Author:		anhqh
-- Create date: 20150120
-- Description:	Trigger Insert
-- =============================================
CREATE TRIGGER [dbo].[zCardLists_UPD]
   ON  [dbo].[zCardLists]
   FOR UPDATE
AS 
BEGIN
		INSERT INTO [zCardLists_Hist]					 
           ([CardNum]
           ,[sDesc]
           ,[FromDate]
           ,[ToDate]
           ,[Status]
           ,[Createby]          
           ,[CreateDate]           
           ,[cType]
           ,[cDate]
           ,[UpdateDate]
            ,[UpdatedBy]
			,CardData
           )
     
				SELECT 
					  [CardNum]
					   ,[sDesc]
					   ,[FromDate]
					   ,[ToDate]
					   ,[Status]
					   ,[Createby]
					   --,[UpdatedBy]
					   ,[CreateDate]
					   --,[UpdateDate]
					   ,'U' as [cType]
					   ,getdate() as [cDate]
					,[UpdateDate]
					 ,[UpdatedBy]
					   ,CardData
				FROM inserted  
		
END

GO


