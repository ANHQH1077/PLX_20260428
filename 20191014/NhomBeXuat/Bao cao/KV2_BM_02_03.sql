
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[KV2_BM_02_03]
	@p_FromDate date,
	@p_ToDate date,
	@p_Client nvarchar(10),
	@p_NhomBe nvarchar(10)
AS
BEGIN
	
	if isnull(@p_NhomBe,'') ='' 
		begin
			set @p_NhomBe =null
		end 
	if upper(ISNULL(@p_Client,'ALL'))='ALL'
		begin
			select NhomBeXuat as NhomBe, Client, MeterId , MaHangHoa, SoLuongThucXuat, LuongGiamDinh, ChenhLech, 
				 round(	((ChenhLech/((case when isnull(SoLuongThucXuat,1)=0 then 1 else SoLuongThucXuat end)  )) ) *100,3) as TyLe_CT
			,  CongTo_PTien, PTien_CongTo, SoLanXuat
			 ,  case when isnull(BM0203.NhomBeXuat,'')  <> '' then  isnull(BM0203.NhomBeXuat,'')  + ' - ' +  a2.GrpName else '' end as TenNhomBe
			from (
				select a.NhomBeXuat , Client, MeterId , MaHangHoa,
						SUM( Sl_llkekt-Sl_llkebd ) as SoLuongThucXuat, sum(convert(numeric, LuongGiamDinh)) as LuongGiamDinh , 
						SUM(Sl_llkekt-Sl_llkebd ) - sum(convert(numeric, LuongGiamDinh))   as ChenhLech
						,SUM( case when ((Sl_llkekt-Sl_llkebd )-LuongGiamDinh)>=0 then 1 else 0 end ) as CongTo_PTien,
							sum(case when ((Sl_llkekt-Sl_llkebd )-LuongGiamDinh)>=0 then 0 else 1 end ) as PTien_CongTo,
						COUNT (ThoiGianCuoi) as SoLanXuat	
						 from FPT_LenhXuat_TongHop_v  a
								
						where [Status] in ('31','4','5')
							and convert(date,ThoiGianDau)>=@p_FromDate and convert(date,ThoiGianDau)<=@p_ToDate 
							and UPPER( dbo.FPT_GetLoadingSite(MaVanChuyen)) ='THUY'	
							and isnull(a.NhomBeXuat,'') = case when isnull(@p_NhomBe,'') ='' then isnull(a.NhomBeXuat,'') else @p_NhomBe  end 
			Group by a.NhomBeXuat , Client, MeterId , MaHangHoa , isnull( a.NhomBeXuat,'')	) BM0203
				left join tblTankGroupList_V a2  on    isnull(BM0203.NhomBeXuat,'')  =  a2.Code
				
		end
	else  --Theo Kho
		begin
			select NhomBeXuat as NhomBe , Client, MeterId , MaHangHoa, SoLuongThucXuat, LuongGiamDinh, ChenhLech, 
					 round(	((ChenhLech/((case when isnull(SoLuongThucXuat,1)=0 then 1 else SoLuongThucXuat end)  )) ) *100,3) as TyLe_CT
				,  CongTo_PTien, PTien_CongTo, SoLanXuat
				,  case when isnull(BM0203.NhomBeXuat,'')  <> '' then  isnull(BM0203.NhomBeXuat,'')  + ' - ' +  a2.GrpName else '' end as TenNhomBe
				from (
					select a.NhomBeXuat , Client, MeterId , MaHangHoa,
							SUM( Sl_llkekt-Sl_llkebd ) as SoLuongThucXuat, sum(convert(numeric, LuongGiamDinh)) as LuongGiamDinh , 
							SUM(Sl_llkekt-Sl_llkebd ) - sum(convert(numeric, LuongGiamDinh))   as ChenhLech
							,SUM( case when ((Sl_llkekt-Sl_llkebd )-LuongGiamDinh)>=0 then 1 else 0 end ) as CongTo_PTien,
								sum(case when ((Sl_llkekt-Sl_llkebd )-LuongGiamDinh)>=0 then 0 else 1 end ) as PTien_CongTo,
							COUNT (ThoiGianCuoi) as SoLanXuat	
							 from FPT_LenhXuat_TongHop_v  a
							where [Status] in ('31','4','5')
								and convert(date,ThoiGianDau)>=@p_FromDate and convert(date,ThoiGianDau)<=@p_ToDate 
								and UPPER( dbo.FPT_GetLoadingSite(MaVanChuyen)) ='THUY'	
									and isnull(a.NhomBeXuat,'') = case when isnull(@p_NhomBe,'') ='' then isnull(a.NhomBeXuat,'') else @p_NhomBe  end 
								and Client=@p_Client
				Group by NhomBeXuat , Client, MeterId , MaHangHoa	, isnull( a.NhomBeXuat,'') ) BM0203
					left join tblTankGroupList_V a2  on    isnull(BM0203.NhomBeXuat,'')  =  a2.Code
		end
	
END
GO