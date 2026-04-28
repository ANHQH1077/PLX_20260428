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
alter PROCEDURE FPT_SyncFPT_Synctableid_old
AS
BEGIN
	declare @p_SoLenh nvarchar(50)
	declare @p_ID as int
	declare @p_cStatus varchar(1)
	declare @p_MaxTable int
	
	declare @p_MaLenh nvarchar(50)
	declare @p_MaNgan nvarchar(50)
	declare @p_NgayXuat datetime
	
	--============Lenh xuat===========================
	DECLARE SoLenh_cursor CURSOR FOR   
		select ID, NgayXuat,MaxTable from SERVER_HTTG.[HTTG_UAT].[dbo].[Sys_tableid_old_Hist] with (nolock)  where isnull( SynStatus,'') = ''  
			order by  UpdateDate asc, ID asc			
	OPEN SoLenh_cursor  
	FETCH NEXT FROM SoLenh_cursor INTO @p_ID , @p_NgayXuat, @p_MaxTable
	WHILE @@FETCH_STATUS = 0  
		BEGIN  
			BEGIN TRY 				
			   if isnull(@p_cStatus,'')='D'
					begin
						delete from  [Sys_tableid_old]
								where MaxTable=@p_MaxTable 										
										and NgayXuat= @p_NgayXuat										
						update SERVER_HTTG.[HTTG_UAT].[dbo].[Sys_tableid_old_Hist] set SynDate=getdate(), SynStatus='Y' where ID=@p_ID	 and NgayXuat= @p_NgayXuat
														and MaxTable =@p_MaxTable					
					end
				else --if isnull(@p_cStatus,'')='U'					
						begin	
							 INSERT INTO  [Sys_tableid_old]
										   ([SoLenh]
											   ,[MaxTable]
											   ,[NgayXuat])
							 select 	[SoLenh]
										   ,[MaxTable]
										   ,[NgayXuat]
							from  SERVER_HTTG.[HTTG_UAT].[dbo].Sys_tableid_old
								where 	  ID=@p_ID				
						
							update SERVER_HTTG.[HTTG_UAT].[dbo].[Sys_tableid_old_Hist] set SynDate=getdate(), SynStatus='Y' where ID=@p_ID	 and NgayXuat= @p_NgayXuat
														and MaxTable =@p_MaxTable						
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
							   ('Sys_tableid_old'
							   ,ERROR_NUMBER()
							   ,ERROR_MESSAGE()
							   ,Getdate() 
							   , @p_SoLenh)
					
			END CATCH;  
			--SELECT @message = '         ' + @product  
			--PRINT @message  
			FETCH NEXT FROM SoLenh_cursor INTO  @p_ID , @p_NgayXuat, @p_MaxTable
		END  

	CLOSE SoLenh_cursor  
	DEALLOCATE SoLenh_cursor  	
	
	--============End Lenh xuat=======================
END
GO
