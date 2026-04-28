
-- =============================================
-- Author:		anhqh
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create TRIGGER [dbo].[SYS_TABLEID_NEW_Del]
   ON  [dbo].[SYS_TABLEID_NEW]
   AFTER	DELETE
AS 
BEGIN
			INSERT INTO [SYS_TABLEID_NEW_Hist]						
				   ([TableID]
					   ,[CrdDate]
					   ,[SoLenh]
					 --  ,[ID]
					   ,[CreateDate]
					   ,[UpdateDate]
					   ,[cStatus]	, Old_ID			   
				  )						   						    
			SELECT [TableID]
					   ,[CrdDate]
					   ,[SoLenh]
					   --,[ID]
				   ,getdate () as [CreateDate]
				   ,getdate() as [UpdateDate]
				   ,'D' as [cStatus], ID
								 
							  FROM inserted  
END
