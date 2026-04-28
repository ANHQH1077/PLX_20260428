
-- =============================================
-- Author:		anhqh
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create TRIGGER [dbo].[SYS_TABLEID_INS]
   ON  [dbo].[SYS_TABLEID]
   AFTER INSERT
AS 
BEGIN
			INSERT INTO [SYS_TABLEID_Hist]						
				   ([TableID]
					   ,[CrdDate]
					   ,[SoLenh]
					 --  ,[ID]
					   ,[CreateDate]
					   ,[UpdateDate]
					   ,[cStatus], Old_ID					   
				  )						   						    
			SELECT TableID
					   ,[CrdDate]
					   ,[SoLenh]
					 --  ,[ID]
				   ,getdate () as [CreateDate]
				   ,getdate() as [UpdateDate]
				   ,'I' as [cStatus], ID
								 
							  FROM inserted  
END
