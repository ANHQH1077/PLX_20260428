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
alter PROCEDURE FPT_Synchronized_LenhXuatChiTiet
	--(@p_SoLenh nvarchar(50))
AS
BEGIN
	declare @p_SoLenh nvarchar(50)
	declare @p_ID as int
	declare @p_cStatus varchar(1)
	declare @p_TableID nvarchar(50)
	declare @p_LineID nvarchar(50)
	declare @p_MaHangHoa nvarchar(50)
	declare @p_Row_ID int
	--============Lenh xuat hang hoa===========================
	DECLARE SoLenh_cursor2 CURSOR FOR   
		select Row_ID, ID, cStatus, TableID, LineID from [tblLenhXuatChiTietE5_Hist] where isnull( SynStatus,'') = '' 
			---and SoLenh=@p_SoLenh  
			order by  NgayXuat, TableID, isnull(UpdateDate,Createdate) ,  ID 	
	OPEN SoLenh_cursor2 
	FETCH NEXT FROM SoLenh_cursor2 INTO @p_Row_ID, @p_ID,  @p_cStatus, @p_TableID,@p_LineID
	WHILE @@FETCH_STATUS = 0  
		BEGIN  
			BEGIN TRY 				
			   if isnull(@p_cStatus,'')='D'
					begin
						delete from  LOCALSERVER.[HTTG_UAT].[dbo].[tblLenhXuatChiTietE5]
								where MapRowID =@p_Row_ID
						 update [tblLenhXuatChiTietE5_Hist] set SynDate=getdate(), SynStatus='Y' where 
										ID=@p_ID
					end
				else --if isnull(@p_cStatus,'')='U'
					begin
						IF EXISTS(SELECT 1 FROM LOCALSERVER.[HTTG_UAT].[dbo].[tblLenhXuatChiTietE5] with (nolock)
								  WHERE   MapRowID =@p_Row_ID)
							begin
								 UPDATE sr
									   SET --[MaNgan] = <MaNgan, nvarchar(3),>
										  --,[MaLenh] = <MaLenh, nvarchar(4),>
										  [NgayXuat] = source.NgayXuat
										  --,[LineID] = <LineID, nvarchar(6),>
										  ,[SoLuongDuXuat] = source.SoLuongDuXuat
										  ,[SoLuongThucXuat] = source.SoLuongThucXuat
										  ,[ThoiGianDau] = source.ThoiGianDau
										  ,[ThoiGianCuoi] = source.ThoiGianCuoi
										  ,[Sl_llkebd] = source.Sl_llkebd
										  ,[Sl_llkekt] = source.Sl_llkekt
										  ,[HeSo_k] = source.HeSo_k
										  ,[NhietDo] = source.NhietDo
										  ,[TyTrong_15] = source.TyTrong_15
										  ,[MaDanXuat] = source.MaDanXuat
										  ,[MaLoi] = source.MaLoi
										  ,[TrangThai] = source.TrangThai
										  ,[MaLuuLuongKe] = source.MaLuuLuongKe
										  ,[MaEntry] = source.MaEntry
										  ,[MaLo] = source.MaLo
										  ,[GhiChu] = source.GhiChu
										  ,[Status] = source.Status
										  ,[ERate] = source.ERate
										  ,[GV] = source.GV
										  ,[GST] = source.GST
										  ,[GVTOTAL_START] = source.GVTOTAL_START
										  ,[GVTOTAL_END] = source.GVTOTAL_END
										  ,[GSTTOTAL_START] = source.GSTTOTAL_START
										  ,[GSTTOTAL_END] = source.GSTTOTAL_END
										  ,[KF] = source.KF
										  ,[KF_E] = source.KF_E
										  ,[TY_TRONG] = source.TY_TRONG
										  ,[AVG_MF] = source.AVG_MF
										  ,[AVG_MF_E] = source.AVG_MF_E
										  ,[AVG_CTL] = source.AVG_CTL
										  ,[AVG_CTL_E] = source.AVG_CTL_E
										  ,[AVG_CTL_BASE] = source.AVG_CTL_BASE
										  ,[RTD_OFFSET] = source.RTD_OFFSET
										  ,[GV_E] = source.GV_E
										  ,[GST_E] = source.GST_E
										  ,[GVTOTAL_E_START] = source.GVTOTAL_E_START
										  ,[GVTOTAL_E_END] = source.GVTOTAL_E_END
										  ,[GSTTOTAL_E_START] = source.GSTTOTAL_E_START
										  ,[GSTTOTAL_E_END] = source.GSTTOTAL_E_END
										  ,[GV_BASE] = source.GV_BASE
										  ,[GST_BASE] = source.GST_BASE
										  ,[GVTOTAL_BASE_START] = source.GVTOTAL_BASE_START
										  ,[GVTOTAL_BASE_END] = source.GVTOTAL_BASE_END
										  ,[GSTTOTAL_BASE_START] =source.GSTTOTAL_BASE_START
										  ,[GSTTOTAL_BASE_END] = source.GSTTOTAL_BASE_END
										  ,[TYLE_TTE] = source.TYLE_TTE
										  ,[V_PRESET] = source.V_PRESET
										  ,[TYLE_PRESET] = source.TYLE_PRESET
										  ,[TYTRONG_BASE] = source.TYTRONG_BASE
										  ,[TYTRONG_E] = source.TYTRONG_E
										  ,[NGAY_DKY] = source.NGAY_DKY
										  ,[NGAY_BD] = source.NGAY_BD
										  ,[NGAY_KT] = source.NGAY_KT
										  ,[SO_CTU] = source.SO_CTU
										  ,[MA_LENH] = source.MA_LENH
										  ,[CARD_DATA] = source.CARD_DATA
										  ,[MA_NGAN] = source.MA_NGAN
										  ,[MA_HHOA] = source.MA_HHOA
										  ,[MA_HONG] = source.MA_HONG
										  ,[MA_KHO] = source.MA_KHO
										  ,[NHIET_DOTB] = source.NHIET_DOTB
										  ,[TRANG_THAI] = source.TRANG_THAI
										  ,[SO_PTIEN] = source.SO_PTIEN
										  ,[LAI_XE] = source.LAI_XE
										  ,[TY_TRONGTB] = source.TY_TRONGTB
										  ,[TY_TRONGTB_BASE] = source.TY_TRONGTB_BASE
										  ,[TY_TRONGTB_E] = source.TY_TRONGTB_E
										  ,[MASS] = source.MASS
										  ,[MASS_BASE] = source.MASS_BASE
										  ,[MASS_E] = source.MASS_E
										  ,[MASSTOTAL_START] =source.MASSTOTAL_START
										  ,[MASSTOTAL_END] = source.MASSTOTAL_END
										  ,[MASSTOTAL_BASE_START] = source.MASSTOTAL_BASE_START
										  ,[MASSTOTAL_BASE_END] = source.MASSTOTAL_BASE_END
										  ,[MASSTOTAL_E_START] = source.MASSTOTAL_E_START
										  ,[MASSTOTAL_E_END] = source.MASSTOTAL_E_END
										  ,[Createby] = source.Createby
										  ,[UpdatedBy] = source.UpdatedBy
										  ,[CreateDate] = source.CreateDate
										  ,[UpdateDate] = source.UpdateDate
										  ,[DungTichNgan] = source.DungTichNgan
										  ,[TableID] = source.TableID
										  ,[MaTuDongHoa] = source.MaTuDongHoa
										  ,[PhuongTien] = source.PhuongTien
										  ,[Record_Status] = source.Record_Status
										  ,[SO_TT] = source.SO_TT
										  ,[FlagTankLine] = source.FlagTankLine
										  ,[GST_TDH] = source.GST_TDH
										   ,SynDate =getdate()
											, SynStatus ='Y'
										  ,[MapRowID] = source.Row_ID
							FROM LOCALSERVER.[HTTG_UAT].[dbo].[tblLenhXuatChiTietE5] AS sr  
										inner JOIN [tblLenhXuatChiTietE5]  AS source   
											 ON sr.MapRowID = source.Row_ID  
											 and sr.TableID = source.TableID  
											 and sr.LineID = source.LineID		
												and source.Row_ID  = @p_Row_ID		
												and source.MapRowID  = @p_Row_ID	
																				
							  update [tblLenhXuatChiTietE5_Hist] set SynDate=getdate(), SynStatus='Y' where 
									ID=@p_ID
							end
						else
							begin
							     INSERT INTO LOCALSERVER.[HTTG_UAT].[dbo].[tblLenhXuatChiTietE5]
										([MaNgan],[MaLenh],[NgayXuat],[LineID],[SoLuongDuXuat],[SoLuongThucXuat]
									   ,[ThoiGianDau],[ThoiGianCuoi],[Sl_llkebd] ,[Sl_llkekt],[HeSo_k],[NhietDo],[TyTrong_15]
									   ,[MaDanXuat] ,[MaLoi],[TrangThai] ,[MaLuuLuongKe],[MaEntry],[MaLo],[GhiChu],[Status]
									   ,[ERate],[GV] ,[GST] ,[GVTOTAL_START],[GVTOTAL_END],[GSTTOTAL_START],[GSTTOTAL_END]
									   ,[KF] ,[KF_E] ,[TY_TRONG] ,[AVG_MF],[AVG_MF_E] ,[AVG_CTL],[AVG_CTL_E],[AVG_CTL_BASE]
									   ,[RTD_OFFSET],[GV_E] ,[GST_E] ,[GVTOTAL_E_START],[GVTOTAL_E_END]  ,[GSTTOTAL_E_START]
									   ,[GSTTOTAL_E_END]   ,[GV_BASE] ,[GST_BASE] ,[GVTOTAL_BASE_START] ,[GVTOTAL_BASE_END]
									   ,[GSTTOTAL_BASE_START] ,[GSTTOTAL_BASE_END] ,[TYLE_TTE] ,[V_PRESET],[TYLE_PRESET]
									   ,[TYTRONG_BASE],[TYTRONG_E],[NGAY_DKY] ,[NGAY_BD],[NGAY_KT]  ,[SO_CTU] ,[MA_LENH]
									   ,[CARD_DATA]   ,[MA_NGAN] ,[MA_HHOA] ,[MA_HONG] ,[MA_KHO]   ,[NHIET_DOTB] ,[TRANG_THAI]
									   ,[SO_PTIEN] ,[LAI_XE] ,[TY_TRONGTB] ,[TY_TRONGTB_BASE],[TY_TRONGTB_E],[MASS] ,[MASS_BASE]
									   ,[MASS_E],[MASSTOTAL_START] ,[MASSTOTAL_END],[MASSTOTAL_BASE_START],[MASSTOTAL_BASE_END]
									   ,[MASSTOTAL_E_START] ,[MASSTOTAL_E_END] ,[Createby],[UpdatedBy],[CreateDate],[UpdateDate]
									   ,[DungTichNgan],[TableID] ,[MaTuDongHoa],[PhuongTien] ,[Record_Status],[SO_TT]
									   ,[FlagTankLine],[GST_TDH],[SynDate] ,[SynStatus] ,[MapRowID])
								
								SELECT [MaNgan],[MaLenh],[NgayXuat],[LineID],[SoLuongDuXuat],[SoLuongThucXuat]
									   ,[ThoiGianDau],[ThoiGianCuoi],[Sl_llkebd] ,[Sl_llkekt],[HeSo_k],[NhietDo],[TyTrong_15]
									   ,[MaDanXuat] ,[MaLoi],[TrangThai] ,[MaLuuLuongKe],[MaEntry],[MaLo],[GhiChu],[Status]
									   ,[ERate],[GV] ,[GST] ,[GVTOTAL_START],[GVTOTAL_END],[GSTTOTAL_START],[GSTTOTAL_END]
									   ,[KF] ,[KF_E] ,[TY_TRONG] ,[AVG_MF],[AVG_MF_E] ,[AVG_CTL],[AVG_CTL_E],[AVG_CTL_BASE]
									   ,[RTD_OFFSET],[GV_E] ,[GST_E] ,[GVTOTAL_E_START],[GVTOTAL_E_END]  ,[GSTTOTAL_E_START]
									   ,[GSTTOTAL_E_END]   ,[GV_BASE] ,[GST_BASE] ,[GVTOTAL_BASE_START] ,[GVTOTAL_BASE_END]
									   ,[GSTTOTAL_BASE_START] ,[GSTTOTAL_BASE_END] ,[TYLE_TTE] ,[V_PRESET],[TYLE_PRESET]
									   ,[TYTRONG_BASE],[TYTRONG_E],[NGAY_DKY] ,[NGAY_BD],[NGAY_KT]  ,[SO_CTU] ,[MA_LENH]
									   ,[CARD_DATA]   ,[MA_NGAN] ,[MA_HHOA] ,[MA_HONG] ,[MA_KHO]   ,[NHIET_DOTB] ,[TRANG_THAI]
									   ,[SO_PTIEN] ,[LAI_XE] ,[TY_TRONGTB] ,[TY_TRONGTB_BASE],[TY_TRONGTB_E],[MASS] ,[MASS_BASE]
									   ,[MASS_E],[MASSTOTAL_START] ,[MASSTOTAL_END],[MASSTOTAL_BASE_START],[MASSTOTAL_BASE_END]
									   ,[MASSTOTAL_E_START] ,[MASSTOTAL_E_END] ,[Createby],[UpdatedBy],[CreateDate],[UpdateDate]
									   ,[DungTichNgan],[TableID] ,[MaTuDongHoa],[PhuongTien] ,[Record_Status],[SO_TT]
									   ,[FlagTankLine],[GST_TDH],getdate() ,'Y' as [SynStatus] ,Row_ID
								from [tblLenhXuatChiTietE5]
									where Row_ID=@p_Row_ID
								
								 update [tblLenhXuatChiTietE5_Hist] set SynDate=getdate(), SynStatus='Y' where 
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
			FETCH NEXT FROM SoLenh_cursor2 INTO  @p_Row_ID, @p_ID,  @p_cStatus, @p_TableID,@p_LineID
		END  

	CLOSE SoLenh_cursor2  
	DEALLOCATE SoLenh_cursor2 
	--============End Lenh xuat hang hoa=======================
END
GO
