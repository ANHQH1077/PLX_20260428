
-- =============================================
-- Author:		anhqh
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
alter TRIGGER [dbo].[tblPhuongTien_Infor_INS]
   ON  [dbo].[tblPhuongTien_Infor]
   AFTER INSERT
AS 
BEGIN
			INSERT INTO [tblPhuongTien_Infor_Hist]
						   ([ID]
						   ,[MaPhuongTien]
						   ,[NoiDung]
						   ,[FromDate]
						   ,[ToDate]
						   ,[sType]
						   ,[cStatus]
						   ,CrdDate
						   ,SynDate
           ,SynStatus)
																	   						    
			SELECT [ID]
						   ,[MaPhuongTien]
						   ,[NoiDung]
						   ,[FromDate]
						   ,[ToDate]
						   ,[sType]		
						    ,'I' [cStatus]					  
						   ,getdate ()  as [CreateDate]
						  ,SynDate
           ,SynStatus
							  FROM inserted  
END
