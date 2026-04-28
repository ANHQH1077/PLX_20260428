-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE FPT_SyncSYS_TABLEID_ZR_Hist99	
AS
BEGIN
	declare @p_SoLenh nvarchar(50)
	declare @p_ID as int
	declare @p_cStatus varchar(1)
	declare @p_ID_LenhXuat int
	
	declare @p_MaLenh nvarchar(50)
	declare @p_MaNgan nvarchar(50)
	declare @p_NgayXuat datetime
	
	--============Lenh xuat===========================
	DECLARE SoLenh_cursor CURSOR FOR   
		select ID, CrdDate from [SYS_TABLEID_ZR_Hist99] where isnull( SynStatus,'') = ''  
			order by  UpdateDate asc, ID asc			
	OPEN SoLenh_cursor  
	FETCH NEXT FROM SoLenh_cursor INTO @p_ID , @p_NgayXuat
	WHILE @@FETCH_STATUS = 0  
		BEGIN  
			BEGIN TRY 				
			   if isnull(@p_cStatus,'')='D'
					begin
						delete from  LOCALSERVER.[HTTG_UAT].[dbo].[SYS_TABLEID_ZR_Hist]
								where ID=@p_ID 										
										and CrdDate= @p_NgayXuat
										
						update [SYS_TABLEID_ZR_Hist99] set SynDate=getdate(), SynStatus='Y' where ID=@p_ID	 and CrdDate= @p_NgayXuat					
					end
				else --if isnull(@p_cStatus,'')='U'					
						begin	
							 INSERT INTO  LOCALSERVER.[HTTG_UAT].[dbo].[SYS_TABLEID_ZR_Hist]
										   ([TableID]
										   ,[CrdDate]
										   ,[SoLenh]
										   ,[MaHangHoa]
										   ,[ID])
							 select 	[TableID]
										   ,[CrdDate]
										   ,[SoLenh]
										   ,[MaHangHoa]
										   ,[ID]
							from  SYS_TABLEID_ZR_Hist
								where 	ID=@p_ID 										
										and CrdDate= @p_NgayXuat
							 update [SYS_TABLEID_ZR_Hist99] set SynDate=getdate(), SynStatus='Y' where ID=@p_ID and CrdDate= @p_NgayXuat
						end
					
				
			END TRY  
			BEGIN CATCH 
			--Loi thi chen vao bang theo doi
				INSERT INTO [tblSyncHistErr]
							   ([TableName]
							   ,[ErrorNumber]
							   ,[ErrorMessage]
							   ,[CreatDate]
							   ,[ObjText])
						 VALUES
							   ('SYS_TABLEID_ZR_Hist'
							   ,ERROR_NUMBER()
							   ,ERROR_MESSAGE()
							   ,Getdate() 
							   , @p_SoLenh)
					
			END CATCH;  
			--SELECT @message = '         ' + @product  
			--PRINT @message  
			FETCH NEXT FROM SoLenh_cursor INTO  @p_ID , @p_NgayXuat
		END  

	CLOSE SoLenh_cursor  
	DEALLOCATE SoLenh_cursor  	
	
	--============End Lenh xuat=======================
END
GO
