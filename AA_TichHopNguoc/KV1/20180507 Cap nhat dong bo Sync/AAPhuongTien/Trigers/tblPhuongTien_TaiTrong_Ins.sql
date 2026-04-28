
-- =============================================
-- Author:		anhqh
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
alter TRIGGER [dbo].[tblPhuongTien_TaiTrong_INS]
   ON  [dbo].[tblPhuongTien_TaiTrong]
   AFTER INSERT
AS 
BEGIN
	INSERT INTO [tblPhuongTien_TaiTrong_Hist]
           (ID
			,[MaPhuongTien]
           ,[TuNgay]
           ,[DenNgay]
           ,[TaiTrong]
           ,[Createby]
           ,[UpdatedBy]
           ,[CreateDate]
           ,[UpdateDate]
           ,[cStatus]          
           ,CrdDate
           ,SynDate
           ,SynStatus)     
	 select  ID, MaPhuongTien
			   ,[TuNgay]
			   ,[DenNgay]
			   ,[TaiTrong]
			   ,[Createby]
			   ,[UpdatedBy]
			   ,[CreateDate]
			   ,[UpdateDate]     
				,'I' [cStatus]					  
			   ,getdate ()  as [CreateDate]			  				  								 
			  ,SynDate
           ,SynStatus
				  FROM inserted  
END
