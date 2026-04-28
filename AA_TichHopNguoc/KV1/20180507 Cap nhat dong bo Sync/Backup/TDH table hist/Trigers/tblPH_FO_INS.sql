
-- =============================================
-- Author:		anhqh
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create TRIGGER [dbo].[tblPH_FO_INS]
   ON  [dbo].[PH_FO]
   AFTER INSERT
AS 
BEGIN
			INSERT INTO [PH_FO_Hist]
							  
									   ([ID_LenhXuat]
									   ,[SoLenh]
									   ,[LineID]
									   ,[Ma_lenh]
									   ,[Ngay_ctu]
									   ,[Ma_ngan]
									   ,[Ma_hhoa]
									   ,[So_ptien]
									   ,[Sl_preset]
									   ,[Sl_ltt]
									   ,[Nhiet_do]
									   ,[Thoigiandau]
									   ,[Thoigiancuoi]
									   ,[Ma_hong]
									   ,[Trang_thai]
									   ,[sl_llkebd]
									   ,[sl_llkekt]
									   ,[CreateDate]
									   ,[UpdateDate]
									   ,[cStatus]
									   )
     
													   						    
			SELECT [ID_LenhXuat]
									   ,[SoLenh]
									   ,[LineID]
									   ,[Ma_lenh]
									   ,[Ngay_ctu]
									   ,[Ma_ngan]
									   ,[Ma_hhoa]
									   ,[So_ptien]
									   ,[Sl_preset]
									   ,[Sl_ltt]
									   ,[Nhiet_do]
									   ,[Thoigiandau]
									   ,[Thoigiancuoi]
									   ,[Ma_hong]
									   ,[Trang_thai]
									   ,[sl_llkebd]
									   ,[sl_llkekt]
									   ,getdate ()  as [CreateDate]
									   ,getdate ()  as [UpdateDate]
									   ,'I' [cStatus]									 
						  
							  FROM inserted  
END
