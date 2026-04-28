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
alter PROCEDURE FPT_Synchronized_PH_Xitec	
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
		select ID, cStatus , Ma_Lenh, Ma_Ngan,Ngay_ctu, ID_LenhXuat from [PH_Xitec_HIST] where isnull( SynStatus,'') = ''  
			order by  isnull(UpdateDate,Createdate) asc, ID asc
	OPEN SoLenh_cursor  
	FETCH NEXT FROM SoLenh_cursor INTO @p_ID , @p_cStatus, @p_MaLenh, @p_MaNgan, @p_NgayXuat, @p_ID_LenhXuat
	WHILE @@FETCH_STATUS = 0  
		BEGIN  
			BEGIN TRY 				
			   if isnull(@p_cStatus,'')='D'
					begin
						delete from  LOCALSERVER.[HTTG_UAT].[dbo].[PH_Xitec]
								where Ma_Lenh=@p_MaLenh
										and Ma_Ngan=@p_MaNgan
										and Ngay_ctu= @p_NgayXuat
										
						update [PH_Xitec_HIST] set SynDate=getdate(), SynStatus='Y' where ID=@p_ID
						
					end
				else --if isnull(@p_cStatus,'')='U'
					begin
						IF EXISTS(SELECT 1 FROM LOCALSERVER.[HTTG_UAT].[dbo].[PH_Xitec] with (nolock)
									where Ma_Lenh=@p_MaLenh
										and Ma_Ngan=@p_MaNgan
										and Ngay_ctu= @p_NgayXuat)
							begin
								 UPDATE sr  
										set [SoLenh] = source.SoLenh
												  ,[LineID] = source.LineID
												  ,[So_ptien] = source.So_ptien
												  ,[Sl_preset] = source.Sl_preset
												  ,[Sl_ltt] = source.Sl_ltt
												  ,[Nhiet_do] = source.Nhiet_do
												  ,[Thoigiandau] = source.Thoigiandau
												  ,[Thoigiancuoi] = source.Thoigiancuoi
												  ,[Ma_hong] = source.Ma_hong
												  ,[Trang_thai] = source.Trang_thai
												  ,[sl_llkebd] = source.sl_llkebd
												  ,[sl_llkekt] = source.sl_llkekt
										FROM LOCALSERVER.[HTTG_UAT].[dbo].[PH_Xitec] AS sr  
											inner JOIN [PH_Xitec]  AS source   
											 ON  source.Ma_Lenh=@p_MaLenh
												and source.Ma_Ngan=@p_MaNgan
												and source.Ngay_ctu= @p_NgayXuat
												and source.Ma_Lenh=sr.Ma_Lenh
												and source.Ma_Ngan=sr.Ma_Ngan
												and source.Ngay_ctu= sr.Ngay_ctu	
								
								  update [PH_Xitec_Hist] set SynDate=getdate(), SynStatus='Y' where ID=@p_ID
							end
						else
							begin	
								 INSERT INTO LOCALSERVER.[HTTG_UAT].[dbo].[PH_Xitec]
										   ([SoLenh] ,[LineID] ,[Ma_lenh] ,[Ngay_ctu],[Ma_ngan],[Ma_hhoa]
										   ,[So_ptien],[Sl_preset],[Sl_ltt],[Nhiet_do],[Thoigiandau]
										   ,[Thoigiancuoi],[Ma_hong],[Trang_thai],[sl_llkebd],[sl_llkekt])	
								 select 	[SoLenh] ,[LineID] ,[Ma_lenh] ,[Ngay_ctu],[Ma_ngan],[Ma_hhoa]
										   ,[So_ptien],[Sl_preset],[Sl_ltt],[Nhiet_do],[Thoigiandau]
										   ,[Thoigiancuoi],[Ma_hong],[Trang_thai],[sl_llkebd],[sl_llkekt]
									FROM  PH_Xitec
									 WHERE  ID_LenhXuat =@p_ID_LenhXuat
														
								 update [PH_Xitec_Hist] set SynDate=getdate(), SynStatus='Y' where ID=@p_ID
							end
							
						
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
							   , @p_SoLenh)
					
			END CATCH;  
			--SELECT @message = '         ' + @product  
			--PRINT @message  
			FETCH NEXT FROM SoLenh_cursor INTO   @p_ID , @p_cStatus, @p_MaLenh, @p_MaNgan, @p_NgayXuat, @p_ID_LenhXuat
		END  

	CLOSE SoLenh_cursor  
	DEALLOCATE SoLenh_cursor  	
	
	--============End Lenh xuat=======================
END
GO
