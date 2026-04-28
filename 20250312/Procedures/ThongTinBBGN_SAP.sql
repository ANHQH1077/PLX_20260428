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
ALTER PROCEDURE ThongTinBBGN_SAP_UPD
	@p_User nvarchar(100)
	,@p_Solenh nvarchar(50)
AS
BEGIN
	select  @p_User as UsrName, convert(nvarchar (20),getdate(),113)  as Sysdate, b.MaNgan,  b.SoLenh as ORDER_NO, b.LineID  as LINEID , 
                                convert(nvarchar (10),ThoiGianDau ,112) as ZZERDAT, replace (convert(nvarchar (20),ThoiGianDau,108),':','')  as ZZERTIM 
                                , convert(nvarchar (10),ThoiGianCuoi ,112) as ZZAEDAT, replace (convert(nvarchar (20),ThoiGianCuoi,108),':','')  as ZZAETIM    --, b.NhomBeXuatTDH, b.BeXuatTDH  
								,MaEntry , a.MaPhuongTien, a.NguoiVanChuyen, b.TrangThai as FLG_HTTG, b.HeSo_k as  NhietDoXe,
								(select top 1  ThongTinTDH from tblLenhXuatChiTietE5  k with ( nolock)  where k.Row_id=b.Row_id  ) as FLG_RUT_TDH
								, a.BatchNum as BATCH_ND, SUBSTRING(REPLICATE('0', 18),1,18 - LEN(b.MaHangHoa)) + b.MaHangHoa  as MATNR, a.MaKhachHang  as CUSTOMER, a.MaPhuongTien as VEHICLE, b.MaLuuLuongKe  as METER_NO
								, convert(float , b.Sl_llkebd )  as  METER_START, convert(float, b.Sl_llkekt) as METER_END, b.SoLuongThucXuat as QUANTITY_CONFIRM
								, b.NhietDo as TEMP_CONFIRM ,  b.TyTrong_15 as DENS_COMFIRM, a.Niem as NIEM_TEXT
									
                                     from FPT_tblLenhXuatChiTietE5_V b , tblLenhXuatE5 a  where b.SoLenh = @p_Solenh and a.SoLenh =b.SoLenh  and a.Status ='5'
END
GO
