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
alter PROCEDURE FPT_Synchronized_TaiTrong
AS
BEGIN
	declare @p_SoLenh nvarchar(50)
	declare @p_ID as int
	declare @p_cStatus varchar(1)
	declare @p_IDNumber int
	--============Lenh xuat===========================
	DECLARE SoLenh_cursor CURSOR FOR   
		select IDNumber, ID, cStatus from LOCALSERVER.[ZZKV1_20171127].[dbo].[tblPhuongTien_TaiTrong_Hist] 
			with (nolock) where isnull( SynStatus,'') = ''  
				order by CrdDate, ID asc	
	OPEN SoLenh_cursor  
	FETCH NEXT FROM SoLenh_cursor INTO @p_IDNumber, @p_ID , @p_cStatus
	WHILE @@FETCH_STATUS = 0  
		BEGIN  
			BEGIN TRY 				
			   if isnull(@p_cStatus,'')='D'
					begin
						delete from  tblPhuongTien_TaiTrong
								where Map_ID=@p_ID
								
						update LOCALSERVER.[ZZKV1_20171127].[dbo].tblPhuongTien_TaiTrong_Hist
								 set SynDate=getdate(), SynStatus='Y' where IDNumber=@p_IDNumber
						
					end
				else --if isnull(@p_cStatus,'')='U'
					begin
						IF EXISTS(SELECT 1 FROM tblPhuongTien_TaiTrong where Map_ID=@p_ID)
							begin
							
								--print ('Update')
								UPDATE sr  
										set sr.MaPhuongTien =source.MaPhuongTien										
										,sr.TaiTrong =source.TaiTrong
										,sr.TuNgay =source.TuNgay
										,sr.DenNgay =source.DenNgay																	
										   ,SynDate =getdate()
											, SynStatus ='Y'											
										FROM tblPhuongTien_TaiTrong  AS sr  
										inner JOIN LOCALSERVER.[ZZKV1_20171127].[dbo].tblPhuongTien_TaiTrong  AS source   
											 ON sr.Map_ID = source.ID  
											 and  source.ID= @p_ID   
											 
								 update LOCALSERVER.[ZZKV1_20171127].[dbo].tblPhuongTien_TaiTrong_Hist
								 set SynDate=getdate(), SynStatus='Y' where IDNumber=@p_IDNumber
							end
						else
							begin
							--print ('Insert')
							INSERT INTO [tblPhuongTien_TaiTrong]
									   ([MaPhuongTien]
									   ,[TuNgay]
									   ,[DenNgay]
									   ,[TaiTrong]
									   ,[Createby]
									   ,[UpdatedBy]
									   ,[CreateDate]
									   ,[UpdateDate]
									   ,[SynDate]
									   ,[SynStatus]
									   ,[Map_ID])
							   
							   select [MaPhuongTien]
									   ,[TuNgay]
									   ,[DenNgay]
									   ,[TaiTrong]
									   ,[Createby]
									   ,[UpdatedBy]
									   ,[CreateDate]
									   ,[UpdateDate]										  											  
												   , getdate(), 'Y'
												    ,[ID]
								from LOCALSERVER.[ZZKV1_20171127].[dbo].[tblPhuongTien_TaiTrong] with (nolock) where ID=@p_ID
								 
								 update LOCALSERVER.[ZZKV1_20171127].[dbo].[tblPhuongTien_TaiTrong_Hist]
								 set SynDate=getdate(), SynStatus='Y' where IDNumber=@p_IDNumber
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
							   ('tblPhuongTien_TaiTrong'
							   ,ERROR_NUMBER()
							   ,ERROR_MESSAGE()
							   ,Getdate() 
							   , @p_SoLenh)
					
			END CATCH;  
			--SELECT @message = '         ' + @product  
			--PRINT @message  
			FETCH NEXT FROM SoLenh_cursor INTO  @p_IDNumber, @p_ID , @p_cStatus
		END  

	CLOSE SoLenh_cursor  
	DEALLOCATE SoLenh_cursor  	
	
	--exec FPT_Synchronized_LenhXuatHangHoa
	--exec FPT_Synchronized_LenhXuatChiTiet
	--============End Lenh xuat=======================
END
GO
