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
CREATE PROCEDURE FPT_SaoChepSoLenh
	@p_SoLenhGoc nvarchar(50)
	,@p_User nvarchar(50)
	,@p_MaLenh nvarchar(50)
	,@p_SoLenhNew nvarchar(50)
AS
BEGIN
	INSERT INTO [tblLenhXuatE5]
           ([MaLenh],[NgayXuat] ,[SoLenh] ,[MaDonVi],[MaNguon] ,[MaKho],[MaVanChuyen]
           ,[MaPhuongTien],[NguoiVanChuyen],[MaPhuongThucBan],[MaPhuongThucXuat]
           ,[MaKhachHang] ,[LoaiPhieu],[NgayHieuLuc],[Status],[Number] ,[Createby] ,[CreateDate],[SoLenhSAP]
           ,[Client],[HTTG] ,[NhaCungCap] ,[Slog],[NgayHetHieuLuc] ,[NguoiDaiDien],[DonViCungCapVanTai]         
           ,[DiemTraHang],[Tax] ,[PaymentMethod] ,[Term],[MaKhoNhap],[SoHopDong] ,[NgayHopDong]
           ,[TyGia],[SoTKHQNhap],[SoTKHQXuat],[SelfShipping],[PriceGroup] ,[Inco1],[Inco2]
           ,[SoPXK],[NgayPXK] ,[MaTuyenDuong] ,[XuatHangGui],[So_TKTN],[So_TKTX],[Ngay_TKTX]
           ,[PTXuat_ID],[DischargePoint] ,[DesDischargePoint] ,[BSART] ,[BWART],[VTWEG],[TenKhoNhap],[SoLenhGoc])
      select  [MaLenh]
           ,[NgayXuat]
           ,[SoLenh]
           ,[MaDonVi]
           ,[MaNguon]
           ,[MaKho]
           ,[MaVanChuyen]
           ,[MaPhuongTien]L2tPFis16
           ,[NguoiVanChuyen]
           ,[MaPhuongThucBan]
           ,[MaPhuongThucXuat]
           ,[MaKhachHang]
           ,[LoaiPhieu]
           ,[Niem]
           ,[LuongGiamDinh]
           ,[NhietDoTaiTau]
           ,[GhiChu]
           ,[NgayHieuLuc]
           ,[Status]
           ,[Number]
           ,[Createby]
           ,[UpdatedBy]
           ,[CreateDate]
           ,[UpdateDate]
           ,[SoLenhSAP]
           ,[Client]
           ,[HTTG]
           ,[Approved]
           ,[User_Approve]
           ,[Date_Approve]
           ,[EditApprove]
           ,[NhaCungCap]
           ,[AppDesc]
           ,[AppN30]
           ,[AppN30Date]
           ,[AppN30User]
           ,[QCI_KG]
           ,[QCI_NhietDo]
           ,[Slog]
           ,[NgayHetHieuLuc]
           ,[NgayTichKe]
           ,[STO]
           ,[NguoiDaiDien]
           ,[DonViCungCapVanTai]
           ,[UserTichKe]
           ,[DiemTraHang]
           ,[Tax]
           ,[PaymentMethod]
           ,[Term]
           ,[MaKhoNhap]
           ,[SoHopDong]
           ,[NgayHopDong]
           ,[TyGia]
           ,[SoTKHQNhap]
           ,[SoTKHQXuat]
           ,[SelfShipping]
           ,[PriceGroup]
           ,[Inco1]
           ,[Inco2]
           ,[SoPXK]
           ,[NgayPXK]
           ,[MaTuyenDuong]
           ,[XuatHangGui]
           ,[So_TKTN]
           ,[So_TKTX]
           ,[Ngay_TKTX]
           ,[PTXuat_ID]
           ,[DischargePoint]
           ,[DesDischargePoint]
           ,[BSART]
           ,[BWART]
           ,[VTWEG]
           ,[TenKhoNhap]
           ,[Xitec_Option]
           ,@p_SoLenhGoc as [SoLenhGoc] from tbllenhxuate5
			where SoLenh=@p_SoLenhGoc
END
GO
