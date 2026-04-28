
-- =============================================
-- Author:		anhqh
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create TRIGGER [dbo].[Sys_tableid_old_Del]
   ON  [dbo].[Sys_tableid_old]
   AFTER	DELETE
AS 
BEGIN
			INSERT INTO [Sys_tableid_old_Hist]						
				   ([SoLenh]
				   ,[MaxTable]
				   ,[NgayXuat]
				  ,[ID]
				   ,[CreateDate]
				   ,[UpdateDate]
				   ,[cStatus]
				  )						   						    
			SELECT [SoLenh]
				   ,[MaxTable]
				   ,[NgayXuat]
				  ,[ID]
				   ,getdate () as [CreateDate]
				   ,getdate() as [UpdateDate]
				   ,'D' as [cStatus]
								 
							  FROM inserted  
END
