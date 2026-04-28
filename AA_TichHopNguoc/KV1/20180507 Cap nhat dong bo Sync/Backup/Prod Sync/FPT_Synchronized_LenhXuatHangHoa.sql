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
create PROCEDURE FPT_Synchronized_LenhXuatHangHoa
	--(@p_SoLenh nvarchar(50))
AS
BEGIN
	declare @p_SoLenh nvarchar(50)
	declare @p_ID as int
	declare @p_cStatus varchar(1)
	declare @p_TableID nvarchar(50)
	declare @p_LineID nvarchar(50)
	declare @p_MaHangHoa nvarchar(50)
	--============Lenh xuat hang hoa===========================
	DECLARE SoLenh_cursor1 CURSOR FOR   
		select ID,  SoLenh, cStatus, TableID, LineID, MaHangHoa from [tblLenhXuat_HangHoaE5_Hist] where isnull( SynStatus,'') = '' 
			---and SoLenh=@p_SoLenh  
			order by SoLenh, isnull(UpdateDate,Createdate) asc, ID 	
	OPEN SoLenh_cursor1 
	FETCH NEXT FROM SoLenh_cursor1 INTO @p_ID, @p_SoLenh, @p_cStatus, @p_TableID,@p_LineID,  @p_MaHangHoa
	WHILE @@FETCH_STATUS = 0  
		BEGIN  
			BEGIN TRY 				
			   if isnull(@p_cStatus,'')='D'
					begin
						delete from  LOCALSERVER.[HTTG_UAT].[dbo].[tblLenhXuat_HangHoaE5]
								where Solenh=@p_SoLenh
									 and TableID = @p_TableID 
											 and LineID = @p_LineID
											 and MaHangHoa =  @p_MaHangHoa
						update [tblLenhXuat_HangHoaE5_Hist] set SynDate=getdate(), SynStatus='Y' where 
										ID=@p_ID
					end
				else --if isnull(@p_cStatus,'')='U'
					begin
						IF EXISTS(SELECT 1 FROM LOCALSERVER.[HTTG_UAT].[dbo].[tblLenhXuat_HangHoaE5] with (nolock)
								  WHERE  SoLenh =@p_SoLenh  and TableID = @p_TableID 
											 and LineID = @p_LineID
											 and MaHangHoa =  @p_MaHangHoa)
							begin
								 UPDATE sr  
										set [MaLenh] = source.MaLenh
											  ,[NgayXuat] = source.NgayXuat										  
											  ,[TongXuat] = source.TongXuat
											  ,[TongDuXuat] = source.TongDuXuat											  
											  ,[DonViTinh] =source.DonViTinh
											  ,[BeXuat] = source.BeXuat									
											  ,[MeterId] = source.MeterId
											  ,[Createby] = source.Createby
											  ,[UpdatedBy] = source.UpdatedBy
											  ,[CreateDate] = source.CreateDate
											  ,[UpdateDate] = source.UpdateDate
											  ,[QCI_KG] = source.QCI_KG
											  ,[QCI_NhietDo] = source.QCI_NhietDo
											  ,[QCI_TyTrong] = source.QCI_TyTrong
											  ,[DonGia] = source.DonGia
											  ,[CurrencyKey] = source.CurrencyKey
											  ,[VCF] = source.VCF
											  ,[WCF] = source.WCF
											  ,[NhietDo_BQGQ] = source.NhietDo_BQGQ
											  ,[D15_BQGQ] = source.D15_BQGQ
											  ,[KG] = source.KG
											  ,[L15] = source.L15
											  ,[GiaCty] = source.GiaCty
											  ,[PhiVT] = source.PhiVT
											  ,[TheBVMT] = source.TheBVMT
											   ,SynDate =getdate()
												, SynStatus='Y'
										FROM LOCALSERVER.[HTTG_UAT].[dbo].[tblLenhXuat_HangHoaE5] AS sr  
										inner JOIN [tblLenhXuat_HangHoaE5]  AS source   
											 ON sr.SoLenh = source.SoLenh  
											 and sr.TableID = source.TableID  
											 and sr.LineID = source.LineID
											 and sr.MaHangHoa = source.MaHangHoa
											 AND source.SoLenh=@p_SoLenh
											 and sr.SoLenh=@p_SoLenh	
								
								  update [tblLenhXuat_HangHoaE5_Hist] set SynDate=getdate(), SynStatus='Y' where 
										ID=@p_ID
							end
						else
							begin
							     INSERT INTO LOCALSERVER.[HTTG_UAT].[dbo].[tblLenhXuat_HangHoaE5]
											([LineID],[MaLenh],[NgayXuat],[SoLenh],[TongXuat],[TongDuXuat]
										   ,[MaHangHoa],[DonViTinh] ,[BeXuat] ,[TableID] ,[MeterId],[Createby],[UpdatedBy],[CreateDate]
										   ,[UpdateDate] ,[QCI_KG],[QCI_NhietDo],[QCI_TyTrong],[DonGia],[CurrencyKey],[VCF]
										   ,[WCF] ,[NhietDo_BQGQ],[D15_BQGQ],[KG],[L15],[GiaCty],[PhiVT] ,[TheBVMT] ,SynDate 
											, SynStatus)
								 SELECT [LineID],[MaLenh],[NgayXuat],[SoLenh],[TongXuat],[TongDuXuat]
										   ,[MaHangHoa],[DonViTinh] ,[BeXuat] ,[TableID] ,[MeterId],[Createby],[UpdatedBy],[CreateDate]
										   ,[UpdateDate] ,[QCI_KG],[QCI_NhietDo],[QCI_TyTrong],[DonGia],[CurrencyKey],[VCF]
										   ,[WCF] ,[NhietDo_BQGQ],[D15_BQGQ],[KG],[L15],[GiaCty],[PhiVT] ,[TheBVMT], getdate(), 'Y'
								 FROM tblLenhXuat_HangHoaE5
								 WHERE SoLenh=@p_SoLenh  and TableID=@p_TableID and LineID=@p_LineID and MaHangHoa= @p_MaHangHoa
								 
								 update [tblLenhXuat_HangHoaE5_Hist] set SynDate=getdate(), SynStatus='Y' where 
										ID=@p_ID
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
							   ('tblLenhXuat_HangHoaE5'
							   ,ERROR_NUMBER()
							   ,ERROR_MESSAGE()
							   ,Getdate() 
							   , @p_SoLenh)
					
			END CATCH;  
			--SELECT @message = '         ' + @product  
			--PRINT @message  
			FETCH NEXT FROM SoLenh_cursor1 INTO  @p_ID, @p_SoLenh  , @p_cStatus, @p_TableID,@p_LineID,  @p_MaHangHoa
		END  

	CLOSE SoLenh_cursor1  
	DEALLOCATE SoLenh_cursor1  
	--============End Lenh xuat hang hoa=======================
END
GO
