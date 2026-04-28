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
CREATE PROCEDURE FPT_Synchronized
	
AS
BEGIN
	declare @p_SoLenh nvarchar(50)
	declare @p_ID as int
	declare @p_cStatus varchar(1)
	--============Lenh xuat===========================
	DECLARE SoLenh_cursor CURSOR FOR   
		select ID, SoLenh, cStatus from [tbllenhxuate5_Hist] where isnull( SynStatus,'') = ''  
			order by isnull(UpdateDate,Createdate) asc, ID desc
	
	OPEN SoLenh_cursor  
	FETCH NEXT FROM SoLenh_cursor INTO @p_ID ,@p_SoLenh, @p_cStatus
	WHILE @@FETCH_STATUS = 0  
		BEGIN  
			BEGIN TRY  
				if isnull(@p_cStatus,'')='I'
					begin
						
					end
				else if isnull(@p_cStatus,'')='D'
					begin
					
					end
				else if isnull(@p_cStatus,'')='U'
					begin
					
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
							   ('tblLenhXuatE5'
							   ,ERROR_NUMBER()
							   ,ERROR_MESSAGE()
							   ,Getdate() 
							   ,<ObjText, @p_SoLenh)
					
			END CATCH;  
			--SELECT @message = '         ' + @product  
			--PRINT @message  
			FETCH NEXT FROM SoLenh_cursor INTO  @p_ID ,@p_SoLenh  , @p_cStatus
		END  

	CLOSE SoLenh_cursor  
	DEALLOCATE SoLenh_cursor  
	--============End Lenh xuat=======================
END
GO
