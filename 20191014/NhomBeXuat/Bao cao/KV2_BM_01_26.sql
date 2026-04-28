
ALTER PROCEDURE [dbo].[KV2_BM_01_26]
	@p_FromDate date,
	@p_ToDate date,
	@p_Client nvarchar(10)
	,@p_NhomBe nvarchar(10) =null
AS
BEGIN	
	if isnull(@p_NhomBe,'') =''
		begin
			set @p_NhomBe =null
		end
	select DoiGiaoNhan,
		   SoCongTo,
		   MaHangHoa,
		   Sum(SluongXuatCto) as SluongXuatCto,
		   Sum(SoLanXuat) as SoLanXuat,
		   Sum(CCHH) as TongChenhLech,
		   Convert(int,(Sum(CCHH)/Sum(SoLanXuat))) as ChenhLechTB 
		   , NhomBeXuat
		  , case when isnull(NhomBeXuat,'') ='' then ''  else NhomBeXuat + ' - ' + isnull((select GrpName from  tblTankGroupList_V a2  where    isnull(a2.Code,'')  =  isnull(bm_01_26.NhomBeXuat,'')),'') end  as TenNhomBe
	from
	(	select a.Client as DoiGiaoNhan, 
			   a.MaLuuLuongKe as SoCongTo,
			   a.MaHangHoa,
			   a.Sl_llkekt - a.Sl_llkebd as SluongXuatCto,
			   1 as SoLanXuat,
			   a.MaEntry as CCHH, isnull(a.NhomBeXuat,'') as NhomBeXuat
		from FPT_LenhXuat_TongHop_v a
			
		where CONVERT(date,a.ThoiGianDau)>=CONVERT(date,@p_FromDate) and 
			  CONVERT(date,a.ThoiGianDau)<=CONVERT(date,@p_ToDate) and
			  a.Client = ISNULL(@p_Client,a.Client) and
			  a.MaVanChuyen = 'ZT'  and
			  a.[Status] in ('31','4','5')
				and isnull(a.nhombexuat,'') = isnull(@p_NhomBe ,isnull(a.nhombexuat,''))
	) bm_01_26		  
	group by DoiGiaoNhan, SoCongTo, MaHangHoa, NhomBeXuat
	order by DoiGiaoNhan, SoCongTo, MaHangHoa 
END
