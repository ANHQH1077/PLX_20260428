

-- =============================================
-- Author:		anhqh	
-- Create date: 07-sep-2015
-- Description:	Ham liet ke cho ghep lenh xuat
-- =============================================
ALTER PROCEDURE [dbo].[FPT_LenhXuatHangHoaE5_Ghep_V]
	-- Add the parameters for the stored procedure here
	@p_SoLenh nvarchar(3000)
AS
BEGIN
	DECLARE @theday DATETIME
	SET @theday = DATEADD(DAY, -1, GETDATE())

	/* 
	 ** Enhancing
	 ** Date: 16/12/2021 14g29
	 **/

	/* Tạo danh sách lệnh xuất từ chuỗi đầu vào */
	SELECT Value AS SoLenh
	INTO #DanhSachLenhXuat
	FROM [dbo].StringSplit(@p_SoLenh, ',')

	DELETE FROM #DanhSachLenhXuat WHERE SoLenh = ''
	/* 
	 ** Enhancing
	 ** Date: 16/12/2021 14g29
	 **/

	


	select *  
	FROM  (SELECT        LineID, MaLenh, NgayXuat, SoLenh, TongXuat, TongDuXuat, MaHangHoa,
								 (SELECT        TOP (1) TenHangHoa
								   FROM            dbo.tblHangHoa
								   WHERE        (MaHangHoa = dbo.tblLenhXuat_HangHoaE5.MaHangHoa)) AS TenHangHoa, DonViTinh, BeXuat, TableID, MeterId, Createby, UpdatedBy, CreateDate, UpdateDate, 'N' AS CHECKUPD, QCI_KG, QCI_NhietDo, 
							 QCI_TyTrong, DonGia, CurrencyKey, L15, KG, VCF, WCF, NhietDo_BQGQ, D15_BQGQ, NhomBeXuat 
			FROM            dbo.tblLenhXuat_HangHoaE5 WITH (nolock)
			WHERE NgayXuat >= @theday) a where CHARINDEX ( ',' + SoLenh + ',' , @p_SoLenh ,1) >0 order by TableID;


	select * from (
		SELECT        a.MaNgan, a.MaLenh, a.NgayXuat, a.LineID, a.SoLuongDuXuat, a.SoLuongThucXuat, a.ThoiGianDau, a.ThoiGianCuoi, a.Sl_llkebd, a.Sl_llkekt, a.NhietDo, a.TyTrong_15, a.MaDanXuat, a.TrangThai, a.MaLuuLuongKe, a.MaEntry, 
                         a.GhiChu, 'N' AS CHECKUPD, a.TableID, B_1.MaHangHoa, B_1.SoLenh, a.MaTuDongHoa, a.HeSo_k, a.MaLoi, a.MaLo, a.Status, a.ERate, a.GV, a.GST, a.GVTOTAL_START, a.GVTOTAL_END, a.GSTTOTAL_START, 
                         a.GSTTOTAL_END, a.KF, a.KF_E, a.TY_TRONG, a.AVG_MF, a.AVG_MF_E, a.AVG_CTL, a.AVG_CTL_E, a.AVG_CTL_BASE, a.RTD_OFFSET, a.GV_E, a.GST_E, a.GVTOTAL_E_START, a.GVTOTAL_E_END, a.GSTTOTAL_E_START, 
                         a.GSTTOTAL_E_END, a.GV_BASE, a.GST_BASE, a.GVTOTAL_BASE_START, a.GVTOTAL_BASE_END, a.GSTTOTAL_BASE_START, a.GSTTOTAL_BASE_END, a.TYLE_TTE, a.V_PRESET, a.TYLE_PRESET, a.TYTRONG_BASE, 
                         a.TYTRONG_E, a.NGAY_DKY, a.NGAY_BD, a.NGAY_KT, a.SO_CTU, a.MA_LENH, a.CARD_DATA, a.MA_NGAN, a.MA_HHOA, a.MA_HONG, a.MA_KHO, a.NHIET_DOTB, a.TRANG_THAI, a.SO_PTIEN, a.LAI_XE, a.TY_TRONGTB, 
                         a.TY_TRONGTB_BASE, a.TY_TRONGTB_E, a.MASS, a.MASS_BASE, a.MASS_E, a.MASSTOTAL_START, a.MASSTOTAL_END, a.MASSTOTAL_BASE_START, a.MASSTOTAL_BASE_END, a.MASSTOTAL_E_START, 
                         a.MASSTOTAL_E_END, a.Createby, a.UpdatedBy, a.CreateDate, a.UpdateDate, a.DungTichNgan, B_1.BeXuat, a.Row_id, B_1.TableID AS H_TableID, a.PhuongTien, B2.TenHangHoa, B_1.MeterId, a.GST_TDH, a.FlagTankLine, 
                         a.L15, a.KG, a.BQGQ_NhietDo, a.BQGQ_D15, a.VCF, a.WCF
	FROM            (SELECT *
					FROM dbo.tblLenhXuatChiTietE5 WITH (Nolock)
					WHERE NgayXuat >= @theday) AS a INNER JOIN
                             (SELECT        TableID, MaLenh, NgayXuat, LineID, MaHangHoa, SoLenh, BeXuat, MeterId
                               FROM            (SELECT        LineID, MaLenh, NgayXuat, SoLenh, TongXuat, TongDuXuat, MaHangHoa,
										(SELECT        TOP (1) TenHangHoa
										FROM            dbo.tblHangHoa
										WHERE        (MaHangHoa = dbo.tblLenhXuat_HangHoaE5.MaHangHoa)) AS TenHangHoa, DonViTinh, BeXuat, TableID, MeterId, Createby, UpdatedBy, CreateDate, UpdateDate, 'N' AS CHECKUPD, QCI_KG, QCI_NhietDo, 
									QCI_TyTrong, DonGia, CurrencyKey, L15, KG, VCF, WCF, NhietDo_BQGQ, D15_BQGQ
		FROM            dbo.tblLenhXuat_HangHoaE5 WITH (nolock)
		WHERE NgayXuat >= @theday) AS B) AS B_1 ON a.TableID = B_1.TableID INNER JOIN
                         dbo.tblHangHoa AS B2 ON B_1.MaHangHoa = B2.MaHangHoa
	) ViewChiTiet where CHARINDEX (',' + SoLenh + ',' , @p_SoLenh ,1) >0 order by MaNgan;
	--select client from tbllenhxuatE5 with (Nolock) where CHARINDEX ( ',' + SoLenh + ',' , @p_SoLenh ,1) >0 
	--	and Client is not null and Client <>'' Group by Client ;

	-- DROP ALL TEMP TABLES
	DROP TABLE #DanhSachLenhXuat
	--DROP TABLE #ViewChiTietE5
END
GO


