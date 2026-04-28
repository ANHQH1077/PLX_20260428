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
create PROCEDURE FPT_SyncFPT_SyncSYS_TABLEID_NEW
AS
BEGIN
	declare @p_TableID nvarchar(50)
	declare @p_ID as int
	declare @p_cStatus varchar(1)
	declare @p_MaxTable int
	declare @p_Old_ID as int
	declare @p_MaLenh nvarchar(50)
	declare @p_MaNgan nvarchar(50)
	declare @p_NgayXuat datetime
	
	--============Lenh xuat===========================
	DECLARE SoLenh_cursor CURSOR FOR   
		select ID, CrdDate, TableID, Old_ID  from [SYS_TABLEID_NEW_Hist] where isnull( SynStatus,'') = ''  
			order by  UpdateDate asc, ID asc			
	OPEN SoLenh_cursor  
	FETCH NEXT FROM SoLenh_cursor INTO @p_ID , @p_NgayXuat, @p_TableID,@p_Old_ID 
	WHILE @@FETCH_STATUS = 0  
		BEGIN  
			BEGIN TRY 			
				begin	
					 INSERT INTO  LOCALSERVER.[HTTG_UAT].[dbo].[SYS_TABLEID_NEW_TMP]
								   ([TableID]
							   ,[CrdDate]
							   ,[SoLenh], ID)
					 select 	[TableID]
							   ,[CrdDate]
							   ,[SoLenh], ID
					from  SYS_TABLEID_NEW
					
						where 	  ID= @p_Old_ID 		
				
					update [SYS_TABLEID_NEW_Hist] set SynDate=getdate(), SynStatus='Y' where ID=@p_ID	--and CrdDate=@p_NgayXuat
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
							   ('SYS_TABLEID_NEW'
							   ,ERROR_NUMBER()
							   ,ERROR_MESSAGE()
							   ,Getdate() 
							   , @p_TableID)
					
			END CATCH;  
			--SELECT @message = '         ' + @product  
			--PRINT @message  
			FETCH NEXT FROM SoLenh_cursor INTO  @p_ID , @p_NgayXuat, @p_TableID, @p_Old_ID 
		END  

	CLOSE SoLenh_cursor  
	DEALLOCATE SoLenh_cursor  	
	
	--============End Lenh xuat=======================
END
GO
