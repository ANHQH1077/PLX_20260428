
-- =============================================
-- Author:		anhqh
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create TRIGGER [dbo].[SYS_TABLEID_ZR_Hist_Del]
   ON  [dbo].[SYS_TABLEID_ZR_Hist]
   AFTER delete
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
								   ,'D' as [cStatus]
								 
							  FROM inserted  
END
