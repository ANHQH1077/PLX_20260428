
-- =============================================
-- Author:		anhqh
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create TRIGGER [dbo].[SYS_TABLEID_NEW_UPD]
   ON  [dbo].[SYS_TABLEID_NEW]
   AFTER Update
AS 
BEGIN
			INSERT INTO [SYS_TABLEID_NEW_Hist]						
				   ([TableID]
					   ,[CrdDate]
					   ,[SoLenh]
					   --,[ID]
					   ,[CreateDate]
					   ,[UpdateDate]
					   ,[cStatus]		, Old_ID		   
				  )						   						    
			SELECT [TableID]
					   ,[CrdDate]
					   ,[SoLenh]
					 --  ,[ID]
				   ,getdate () as [CreateDate]
				   ,getdate() as [UpdateDate]
				   ,'U' as [cStatus], ID
								 
							  FROM inserted  
END
