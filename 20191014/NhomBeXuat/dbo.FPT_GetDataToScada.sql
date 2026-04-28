
-- =============================================
-- Author:		Anhqh
-- Create date: 01/07/2015
-- Description:	Ham lay thong tin du lieu de day vao Scadar
-- =============================================
ALTER PROCEDURE [dbo].[FPT_GetDataToScadar]
	@p_SoLenh nvarchar(500)
AS
BEGIN
	/* 
	 ** Enhancing
	 ** Date: 16/12/2021 14g29
	 **/

	/* T?o danh sách l?nh xu?t t? chu?i ??u vào */
	SELECT Value AS SoLenh
	INTO #DanhSachLenhXuat
	FROM [dbo].StringSplit(@p_SoLenh, ',')

	/* Ki?m tra n?u có d?u ph?y ? ??u chu?i thì xóa */
	IF (LEFT(@p_SoLenh,1) = ',')
		DELETE FROM #DanhSachLenhXuat WHERE SoLenh = ''

	/* L?c ra b?ng HangHoaE5 ch? có nh?ng l?nh xu?t trên */
	SELECT *
	INTO #HangHoaE5
	FROM tblLenhXuat_HangHoaE5
	WHERE SoLenh IN (SELECT SoLenh FROM #DanhSachLenhXuat)
	/* 
	 ** Enhancing
	 ** Date: 16/12/2021 14g29
	 **/

	select aa.MaNgan,aa.MaLenh,
	
	--convert(date, getdate())  
	aa.ngayxuat
	 as NgayXuat ,aa.LineID ,aa.SoLuongDuXuat
      ,aa.SoLuongThucXuat,aa.ThoiGianDau,aa.ThoiGianCuoi,aa.Sl_llkebd,aa.Sl_llkekt
      ,aa.HeSo_k,aa.NhietDo,aa.TyTrong_15,aa.MaDanXuat,aa.MaLoi,aa.TrangThai
      ,aa.MaLuuLuongKe ,aa.MaEntry,aa.MaLo,aa.GhiChu ,aa.Status,aa.ERate,aa.GV
      ,aa.GST,aa.GVTOTAL_START ,aa.GVTOTAL_END,aa.GSTTOTAL_START,aa.GSTTOTAL_END,aa.KF
      ,aa.KF_E,aa.TY_TRONG,aa.AVG_MF,aa.AVG_MF_E,aa.AVG_CTL,aa.AVG_CTL_E,aa.AVG_CTL_BASE
      ,aa.RTD_OFFSET,aa.GV_E,aa.GST_E,aa.GVTOTAL_E_START ,aa.GVTOTAL_E_END,aa.GSTTOTAL_E_START
      ,aa.GSTTOTAL_E_END,aa.GV_BASE,aa.GST_BASE,aa.GVTOTAL_BASE_START,aa.GVTOTAL_BASE_END
      ,aa.GSTTOTAL_BASE_START,aa.GSTTOTAL_BASE_END ,aa.TYLE_TTE ,aa.V_PRESET
      ,aa.TYLE_PRESET ,aa.TYTRONG_BASE ,aa.TYTRONG_E ,aa.NGAY_DKY ,aa.NGAY_BD
      ,aa.NGAY_KT ,aa.SO_CTU,aa.MA_LENH,aa.SO_PTIEN ,aa.LAI_XE  ,aa.TY_TRONGTB 
      ,aa.DungTichNgan ,aa.TableID ,aa.MaTuDongHoa,aa.Row_id,aa.PhuongTien ,aa.Record_Status
      ,aa.SO_TT   ,aa.FlagTankLine, AA.Ma_Ngan, aa.Ma_HHoa
      , bb.MaHangHoa as MaHangHoaTG, aa.Ma_Hong,Nhiet_DoTB,TRANG_THAI,TY_TRONGTB_BASE,TY_TRONGTB_E      
      ,[MASS]
      ,[MASS_BASE]
      ,[MASS_E]
      ,[MASSTOTAL_START]
      ,[MASSTOTAL_END]
      ,[MASSTOTAL_BASE_START]
      ,[MASSTOTAL_BASE_END]
      ,[MASSTOTAL_E_START]
      ,[MASSTOTAL_E_END]
    
      ,[DungTichNgan]
    
      ,[MaTuDongHoa]
      ,[Row_id]
      ,[PhuongTien]
      ,[Record_Status]
      ,[SO_TT]
      ,[FlagTankLine],
      
                (select top 1 MaHangHoa_Scada  from tblMap_MaHangHoa where MaHangHoa_Sap =bb.MaHangHoa) as MaHangHoa  
                ,(select top 1 MaPhuongTien   from tblLenhXuatE5 with (nolock) where SoLenh  =bb.SoLenh ) as PhuongTienH 
                ,0 as Flag1,
                bb.TableID as H_TableID ,
                bb.BeXuat , bb.MeterId ---, convert(date, getdate()) as Ngay_DKY
                ,aa.CardNum, aa.CardData, bb.NhomBeXuat 
            from tblLenhXuatChiTietE5 aa with (Nolock), #HangHoaE5 bb with (Nolock)  /* Enhancing with #HangHoaE5 */
             where aa.TableID=bb.TableID and bb.NgayXuat=aa.NgayXuat
             --bb.LineID=aa.LineID and bb.NgayXuat=aa.NgayXuat and aa.MaLenh=bb.MaLenh 
				and CHARINDEX (',' + bb.SoLenh +',',',' +@p_SoLenh+',',1)>0
				--bb.SoLenh=@p_SoLenh

	DROP TABLE #DanhSachLenhXuat
	DROP TABLE #HangHoaE5
END
