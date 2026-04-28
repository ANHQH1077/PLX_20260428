
-- =============================================
-- Author:		anhqh
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create TRIGGER [dbo].[SYS_TABLEID_ZR_Hist_INS]
   ON  [dbo].[SYS_TABLEID_ZR_Hist]
   AFTER INSERT
AS 
BEGIN
			INSERT INTO [SYS_TABLEID_ZR_Hist99]	
					  ([TableID]
								   ,[CrdDate]
								   ,[SoLenh]
								   ,[MaHangHoa]
								   ,[ID]
								   ,[CreateDate]
								   ,[UpdateDate]
								   ,[cStatus]
								   )
   	   													   						    
			SELECT [TableID]
								   ,[CrdDate]
								   ,[SoLenh]
								   ,[MaHangHoa]
								   ,[ID]
								   ,getdate () as [CreateDate]
								   ,getdate () [UpdateDate]
								   ,'I' as [cStatus]
								 
							  FROM inserted  
END
