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
create PROCEDURE FPT_SyncSYS_TABLEID
AS
BEGIN
	declare @p_TableID nvarchar(50)
	declare @p_ID as int
	declare @p_Old_ID as int
	declare @p_cStatus varchar(1)
	declare @p_MaxTable int
	
	declare @p_MaLenh nvarchar(50)
	declare @p_MaNgan nvarchar(50)
	declare @p_NgayXuat datetime
	
	--============Lenh xuat===========================
	DECLARE SoLenh_cursor CURSOR FOR   
		select ID, CrdDate, TableID, Old_ID from [SYS_TABLEID_Hist] where isnull( SynStatus,'') = ''  
			order by  UpdateDate asc, ID asc			
	OPEN SoLenh_cursor  
	FETCH NEXT FROM SoLenh_cursor INTO @p_ID , @p_NgayXuat, @p_TableID, @p_Old_ID
	WHILE @@FETCH_STATUS = 0  
		BEGIN  
			BEGIN TRY 				
			   if isnull(@p_cStatus,'')='D'
					begin
						delete from  LOCALSERVER.[HTTG_UAT].[dbo].[SYS_TABLEID]
								where  Old_ID=@p_Old_ID
								--TableID=@p_TableID 										
								--		and CrdDate= @p_NgayXuat										
						update [SYS_TABLEID_Hist] set SynDate=getdate(), SynStatus='Y' where ID=@p_ID	
					end
				else --if isnull(@p_cStatus,'')='U'			
					 IF EXISTS(SELECT 1 FROM LOCALSERVER.[HTTG_UAT].[dbo].[SYS_TABLEID] with (nolock)
									where Old_ID=@p_Old_ID)
						begin
								update 	LOCALSERVER.[HTTG_UAT].[dbo].[SYS_TABLEID]
										set 	TableID = @p_TableID 	 where  Old_ID=@p_Old_ID
								update [SYS_TABLEID_Hist] set SynDate=getdate(), SynStatus='Y' where ID=@p_ID
						end
					 else		
							begin	
									 INSERT INTO  LOCALSERVER.[HTTG_UAT].[dbo].[SYS_TABLEID]
												   ([TableID]
											   ,[CrdDate]
											   ,[SoLenh], Old_ID)
									 select 	[TableID]
											   ,[CrdDate]
											   ,[SoLenh]
											   , ID
									from  SYS_TABLEID
										where 	  ID= @p_Old_ID				
								
								update [SYS_TABLEID_Hist] set SynDate=getdate(), SynStatus='Y' where ID=@p_ID	
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
							   ('SYS_TABLEID'
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
