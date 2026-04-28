
-- =============================================
-- Author:		anhqh
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
alter TRIGGER [dbo].[tblPhuongTien_LaiXe_INS]
   ON  [dbo].[tblPhuongTien_LaiXe]
   AFTER INSERT
AS 
BEGIN
	INSERT INTO [tblPhuongTien_LaiXe_Hist]
           ([ID]
           ,[MaPhuongTien]
           ,[HoVaTen]
           ,[NoiDung]
           ,[FromDate]
           ,[ToDate]
           ,[sType]
           ,[sDefault]
           ,[cStatus]
           ,CrdDate
           ,SynDate
           ,SynStatus
           )
     
 	SELECT [ID]
           ,[MaPhuongTien]
           ,[HoVaTen]
           ,[NoiDung]
           ,[FromDate]
           ,[ToDate]
           ,[sType]
           ,[sDefault]
						    ,'I' [cStatus]					  
						   ,getdate ()  as [CreateDate]
						,SynDate
           ,SynStatus
							  FROM inserted  
END
