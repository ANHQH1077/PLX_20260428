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
create PROCEDURE FPT_Synchronized_LenhXuat		
AS
BEGIN
	declare @p_SoLenh nvarchar(50)
	declare @p_ID as int
	declare @p_cStatus varchar(1)
	--============Lenh xuat===========================
	DECLARE SoLenh_cursor CURSOR FOR   
		select ID, SoLenh, cStatus from [tbllenhxuate5_Hist] where isnull( SynStatus,'') = ''  
			order by SoLenh, isnull(UpdateDate,Createdate) asc, ID asc	
	OPEN SoLenh_cursor  
	FETCH NEXT FROM SoLenh_cursor INTO @p_ID ,@p_SoLenh, @p_cStatus
	WHILE @@FETCH_STATUS = 0  
		BEGIN  
			BEGIN TRY 				
			   if isnull(@p_cStatus,'')='D'
					begin
						delete from  LOCALSERVER.[HTTG_UAT].[dbo].[tblLenhXuatE5]
								where Solenh=@p_SoLenh
						update [tbllenhxuate5_Hist] set SynDate=getdate(), SynStatus='Y' where ID=@p_ID
						
					end
				else --if isnull(@p_cStatus,'')='U'
					begin
						IF EXISTS(SELECT 1 FROM LOCALSERVER.[HTTG_UAT].[dbo].[tblLenhXuatE5] with (nolock)
								  WHERE  SoLenh =@p_SoLenh)
							begin
							
								--print ('Update')
								UPDATE sr  
										set [MaLenh]=source.[MaLenh],[NgayXuat]=source.[NgayXuat],[SoLenh]=source.[SoLenh]
											,[MaDonVi] =source.[MaDonVi],[MaNguon]=source.[MaNguon],[MaKho]=source.[MaKho],[MaVanChuyen]=source.[MaVanChuyen]
										  ,[MaPhuongTien]=source.[MaPhuongTien],[NguoiVanChuyen]=source.[NguoiVanChuyen],[MaPhuongThucBan]=source.[MaPhuongThucBan],
										  [MaPhuongThucXuat]=source.[MaPhuongThucXuat],[MaKhachHang]=source.[MaKhachHang],
										  [LoaiPhieu]=source.[LoaiPhieu]  ,[Niem]=source.[Niem] ,[LuongGiamDinh] =source.[LuongGiamDinh] ,[NhietDoTaiTau]=source.[NhietDoTaiTau]
										   ,[GhiChu]=source.[GhiChu],[NgayHieuLuc]=source.[NgayHieuLuc] ,[Status]=source.[Status] ,[Number]=source.[Number] 
										  ,[Createby]=source.[Createby] ,[UpdatedBy]=source.[UpdatedBy]  ,[CreateDate]=source.[CreateDate] ,[UpdateDate]=source.[UpdateDate]
										   ,[SoLenhSAP]=source.[SoLenhSAP],[Client]=source.[Client] ,[HTTG]=source.[HTTG] ,[Approved]=source.[Approved]
										  ,[User_Approve]=source.[User_Approve] ,[Date_Approve]=source.[Date_Approve]  ,[EditApprove]=source.[EditApprove]  
										  ,[NhaCungCap]=source.[NhaCungCap] ,[AppDesc]=source.[AppDesc] , [AppN30]=source.[AppN30] ,[AppN30Date]=source.[AppN30Date] 
										  ,[AppN30User]=source.[AppN30User] ,[QCI_KG]=source.[QCI_KG] ,[QCI_NhietDo]=source.[QCI_NhietDo] ,[Slog]=source.[Slog] 
										  ,[NgayHetHieuLuc]=source.[NgayHetHieuLuc] ,[NgayTichKe]=source.[NgayTichKe],[STO]=source.[STO]  ,[NguoiDaiDien]=source.[NguoiDaiDien]
										  ,[DonViCungCapVanTai]=source.[DonViCungCapVanTai] ,[UserTichKe]=source.[UserTichKe] ,[DiemTraHang]=source.[DiemTraHang]
										   ,[Tax]=source.[Tax] ,[PaymentMethod]=source.[PaymentMethod] ,[Term]=source.[Term] 
										  ,[MaKhoNhap]=source.[MaKhoNhap]  ,[SoHopDong]=source.[SoHopDong] ,[NgayHopDong]=source.[NgayHopDong]  ,[TyGia]=source.[TyGia]
										   ,[SoTKHQNhap]=source.[SoTKHQNhap] ,[SoTKHQXuat]=source.[SoTKHQXuat] , [SelfShipping]=source.[SelfShipping] ,[PriceGroup]=source.[PriceGroup] 
										  ,[Inco1]=source.[Inco1] ,[Inco2]=source.[Inco2] ,[SoPXK]=source.[SoPXK]  ,[NgayPXK]=source.[NgayPXK] ,[MaTuyenDuong]=source.[MaTuyenDuong]
										   ,[XuatHangGui]=source.[XuatHangGui] ,[So_TKTN]=source.[So_TKTN],[So_TKTX]=source.[So_TKTX]  ,[Ngay_TKTX]=source.[Ngay_TKTX] 
										  ,[DischargePoint]=source.[DischargePoint] ,[DesDischargePoint]=source.[DesDischargePoint] ,[BSART]=source.[BSART] ,[BWART]=source.[BWART]  ,[VTWEG]=source.[VTWEG] 
										  ,[TenKhoNhap]=source.[TenKhoNhap] ,[Xitec_option]=source.[Xitec_option] ,[SoLenhGoc]=source.[SoLenhGoc] 
										   ,SynDate =getdate()
											, SynStatus ='Y'
										FROM LOCALSERVER.[HTTG_UAT].[dbo].[tblLenhXuatE5] AS sr  
										inner JOIN [tblLenhXuatE5]  AS source   
											 ON sr.SoLenh = source.SoLenh  
											 AND source.SoLenh=@p_SoLenh
											 and sr.SoLenh=@p_SoLenh
								  update [tbllenhxuate5_Hist] set SynDate=getdate(), SynStatus='Y' where ID=@p_ID
							end
						else
							begin
							--print ('Insert')
								INSERT INTO LOCALSERVER.[HTTG_UAT].[dbo].[tblLenhXuatE5] 
										([MaLenh],[NgayXuat],[SoLenh],[MaDonVi] ,[MaNguon],[MaKho],[MaVanChuyen]
									  ,[MaPhuongTien],[NguoiVanChuyen],[MaPhuongThucBan],[MaPhuongThucXuat],[MaKhachHang],[LoaiPhieu]
									  ,[Niem],[LuongGiamDinh] ,[NhietDoTaiTau],[GhiChu],[NgayHieuLuc],[Status],[Number]
									  ,[Createby],[UpdatedBy] ,[CreateDate],[UpdateDate],[SoLenhSAP],[Client],[HTTG],[Approved]
									  ,[User_Approve],[Date_Approve] ,[EditApprove] ,[NhaCungCap],[AppDesc],[AppN30],[AppN30Date]
									  ,[AppN30User],[QCI_KG],[QCI_NhietDo],[Slog],[NgayHetHieuLuc],[NgayTichKe],[STO] ,[NguoiDaiDien]
									  ,[DonViCungCapVanTai],[UserTichKe],[DiemTraHang],[Tax],[PaymentMethod],[Term],[MaKhoNhap]
									  ,[SoHopDong],[NgayHopDong] ,[TyGia],[SoTKHQNhap],[SoTKHQXuat],[SelfShipping],[PriceGroup]
									  ,[Inco1],[Inco2],[SoPXK] ,[NgayPXK],[MaTuyenDuong],[XuatHangGui],[So_TKTN],[So_TKTX] ,[Ngay_TKTX]
									  ,[DischargePoint],[DesDischargePoint],[BSART],[BWART] ,[VTWEG],[TenKhoNhap],[Xitec_option],[SoLenhGoc] ,SynDate 
										, SynStatus)
							   select  [MaLenh],[NgayXuat],[SoLenh],[MaDonVi] ,[MaNguon],[MaKho],[MaVanChuyen]
									  ,[MaPhuongTien],[NguoiVanChuyen],[MaPhuongThucBan],[MaPhuongThucXuat],[MaKhachHang],[LoaiPhieu]
									  ,[Niem],[LuongGiamDinh] ,[NhietDoTaiTau],[GhiChu],[NgayHieuLuc],[Status],[Number]
									  ,[Createby],[UpdatedBy] ,[CreateDate],[UpdateDate],[SoLenhSAP],[Client],[HTTG],[Approved]
									  ,[User_Approve],[Date_Approve] ,[EditApprove] ,[NhaCungCap],[AppDesc],[AppN30],[AppN30Date]
									  ,[AppN30User],[QCI_KG],[QCI_NhietDo],[Slog],[NgayHetHieuLuc],[NgayTichKe],[STO] ,[NguoiDaiDien]
									  ,[DonViCungCapVanTai],[UserTichKe],[DiemTraHang],[Tax],[PaymentMethod],[Term],[MaKhoNhap]
									  ,[SoHopDong],[NgayHopDong] ,[TyGia],[SoTKHQNhap],[SoTKHQXuat],[SelfShipping],[PriceGroup]
									  ,[Inco1],[Inco2],[SoPXK] ,[NgayPXK],[MaTuyenDuong],[XuatHangGui],[So_TKTN],[So_TKTX] ,[Ngay_TKTX]
									  ,[DischargePoint],[DesDischargePoint],[BSART],[BWART] ,[VTWEG],[TenKhoNhap],[Xitec_option],[SoLenhGoc], getdate(), 'Y'
								from tblLenhXuatE5 where SoLenh=@p_SoLenh
								 update [tbllenhxuate5_Hist] set SynDate=getdate(), SynStatus='Y' where ID=@p_ID
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
			FETCH NEXT FROM SoLenh_cursor INTO  @p_ID ,@p_SoLenh  , @p_cStatus
		END  

	CLOSE SoLenh_cursor  
	DEALLOCATE SoLenh_cursor  	
	
	--============End Lenh xuat=======================
END
GO
