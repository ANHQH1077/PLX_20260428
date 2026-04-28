
create or alter procedure KV2_BM_05_04_01_HH
	(@p_FromTime datetime =null
	,@p_ToTime datetime=null
	,@p_Client varchar(20) =null
	)
as
	declare @p_DVT int =1000
	declare @p_Round int =0
	
	declare @p_FTime datetime
	declare @p_TTime datetime
begin
	set @p_FTime =  isnull(@p_FromTime,getdate())
	if @p_FromTime is null
		begin
			set @p_FTime = DATEADD(year,-20, @p_FTime)
		end
	
	set @p_TTime =  isnull(@p_ToTime,getdate()+1)	

	if OBJECT_ID ('tempdb..#TableSoLenh_HH') is not null
		begin
			drop table #TableSoLenh_HH
		end 
	create table #TableSoLenh_HH (SoLenh varchar(100) COLLATE SQL_Latin1_General_CP850_CI_AS NULL)


	insert into #TableSoLenh_HH (SoLenh)
	select distinct solenh from
		tbllenhxuate5 h where Status in ('31','4','5') and isnull(h.Client,'E') = case when isnull(@p_Client,'E') ='E' then isnull(h.Client,'E')  else isnull(@p_Client,'E') end  and
			exists (select 1 from   FPT_tblLenhXuatChiTietE5_V h1 where  ThoiGianDau is not null and ThoiGianCuoi is not null
			and ThoiGianDau between @p_FTime and @p_TTime and h1.SoLenh = h.SoLenh)
			
select Client , NhomBeXuat,
				round( isnull(sum(M95_V),@p_Round)/@p_DVT,0) +
				round(isnull(sum(M95_3),0)/@p_DVT,@p_Round) + 
				round(isnull(sum(E10),0)/@p_DVT,@p_Round) +
				round(isnull(sum(DO_2),0)/@p_DVT,@p_Round) + 
				round(isnull(sum(DO_V),0)/@p_DVT,@p_Round) +
				round(isnull(sum (JET),0)/@p_DVT,@p_Round)+
				round(isnull(sum(KO),0)/@p_DVT,@p_Round) + 
				round(isnull(sum(FO_35),0)/@p_DVT,@p_Round) +
				round(isnull(sum (FO_05),0)/@p_DVT,@p_Round)

						as TONGCONG ,
				round( isnull(sum(M95_V),@p_Round)/@p_DVT,0)  as M95_V , 
				round(isnull(sum(M95_3),0)/@p_DVT,@p_Round)  as M95_3, 
				round(isnull(sum(E10),0)/@p_DVT,@p_Round)  as E10 , 
				round(isnull(sum(DO_2),0)/@p_DVT,@p_Round) as DO_2, 
				round(isnull(sum(DO_V),0)/@p_DVT,@p_Round)  as DO_V, 
				round(isnull(sum (JET),0)/@p_DVT,@p_Round)  as JET,
				round(isnull(sum(DO_2),0)/@p_DVT,@p_Round) as KO, 
				round(isnull(sum(DO_V),0)/@p_DVT,@p_Round)  as FO_35, 
				round(isnull(sum (JET),0)/@p_DVT,@p_Round)  as FO_05 
		from (

		select Client, NhomBeXuat,
				case when MaHangHoa = '0201052' then SanLuong else 0 end as M95_V, 
				case when MaHangHoa = '0201032' then SanLuong else 0 end as M95_3, 
				case when MaHangHoa = '0201005' then SanLuong else 0 end as E10,
				case when MaHangHoa = '0601002' then SanLuong else 0 end as DO_2,
				case when MaHangHoa = '0601005' then SanLuong else 0 end as DO_V,
				case when MaHangHoa = '0101002' then SanLuong else 0 end as JET,
				case when MaHangHoa = '0501001' then SanLuong else 0 end as KO,
				case when MaHangHoa = '0701001' then SanLuong else 0 end as FO_35,
				case when MaHangHoa = '0701005' then SanLuong else 0 end as FO_05
					  from (
		select a.Client, a.NhomBeXuat,b.MaHangHoa, count(a.MaPhuongTien) as LuotXe, sum(b.SoLuongThucXuat) as SanLuong	
			from tblLenhXuatE5 a , FPT_tblLenhXuatChiTietE5_V b where a.SoLenh = b.SoLenh
			and exists (select 1 from #TableSoLenh_HH h2 where h2.SoLenh = a.SoLenh)
			and a.MaKhachHang  like  '%106610' and a.MaNguon ='N05'
			and a.Status in ('31','4','5')
			and ThoiGianDau is not null and ThoiGianDau between @p_FTime and @p_TTime
			--and isnull(a.Client,'E') =  ISNULL(@p_Client,'E')
			group by a.Client, a.NhomBeXuat,b.MaHangHoa
		union all
		select a.Client , a.NhomBeXuat,b.MaHangHoa, count(a.MaPhuongTien) as LuotXe, sum(b.SoLuongThucXuat) as SanLuong	
			from tblLenhXuatE5 a , FPT_tblLenhXuatChiTietE5_V b where a.SoLenh = b.SoLenh
				and exists (select 1 from #TableSoLenh_HH h2 where h2.SoLenh = a.SoLenh)
				and ( a.MaKhachHang  like  '%106680' or a.MaKhachHang  like  '%106660') and a.MaNguon ='N05'
				and a.Status in ('31','4','5')
				and ThoiGianDau is not null and ThoiGianDau between @p_FTime and @p_TTime
				--and isnull(a.Client,'E') =  ISNULL(@p_Client,'E')
				group by a.Client, a.NhomBeXuat,b.MaHangHoa
		union all
		select a.Client , a.NhomBeXuat,b.MaHangHoa, count(a.MaPhuongTien) as LuotXe, sum(b.SoLuongThucXuat) as SanLuong	
			from tblLenhXuatE5 a , FPT_tblLenhXuatChiTietE5_V b where a.SoLenh = b.SoLenh
				and exists (select 1 from #TableSoLenh_HH h2 where h2.SoLenh = a.SoLenh)
				and ( a.MaKhachHang  not like  '%106680' and  a.MaKhachHang  not like  '%106660' and  a.MaKhachHang  not like  '%106610') 
					and a.MaNguon ='N05'
					and a.Status in ('31','4','5')
					and ThoiGianDau between @p_FTime and @p_TTime
					--and isnull(a.Client,'E') =  ISNULL(@p_Client,'E')
					group by a.Client, a.NhomBeXuat,b.MaHangHoa
		union all
		select a.Client, a.NhomBeXuat,b.MaHangHoa, count(a.MaPhuongTien) as LuotXe, sum(b.SoLuongThucXuat) as SanLuong	
			from tblLenhXuatE5 a , FPT_tblLenhXuatChiTietE5_V b where a.SoLenh = b.SoLenh
					and exists (select 1 from #TableSoLenh_HH h2 where h2.SoLenh = a.SoLenh)		
					and a.MaNguon ='N30'
					and a.Status in ('31','4','5')
					and ThoiGianDau is not null and ThoiGianDau between @p_FTime and @p_TTime
					--and isnull(a.Client,'E') =  ISNULL(@p_Client,'E')
					group by a.Client, a.NhomBeXuat,b.MaHangHoa
		union all
		select a.Client, a.NhomBeXuat,b.MaHangHoa, count(a.MaPhuongTien) as LuotXe, sum(b.SoLuongThucXuat) as SanLuong	
			from tblLenhXuatE5 a , FPT_tblLenhXuatChiTietE5_V b where a.SoLenh = b.SoLenh
					and exists (select 1 from #TableSoLenh_HH h2 where h2.SoLenh = a.SoLenh)
					and a.MaNguon in ('N45','N40') and b.MaHangHoa  <> '0101002'
					and a.Status in ('31','4','5')
					and ThoiGianDau is not null and ThoiGianDau between @p_FTime and @p_TTime
					--and isnull(a.Client,'E') =  ISNULL(@p_Client,'E')
					group by a.Client, a.NhomBeXuat,b.MaHangHoa
		union all
		select a.Client, a.NhomBeXuat,b.MaHangHoa, count(a.MaPhuongTien) as LuotXe, sum(b.SoLuongThucXuat) as SanLuong	
			from tblLenhXuatE5 a , FPT_tblLenhXuatChiTietE5_V b where a.SoLenh = b.SoLenh
				and a.Status in ('31','4','5')
					and exists (select 1 from #TableSoLenh_HH h2 where h2.SoLenh = a.SoLenh)		
					and a.MaNguon in ('N45','N40') and b.MaHangHoa  = '0101002'
					--and isnull(a.Client,'E') =  ISNULL(@p_Client,'E')
					and ThoiGianDau is not null and ThoiGianDau between @p_FTime and @p_TTime
					group by a.Client, a.NhomBeXuat,b.MaHangHoa
					) abc 
		) abc1 group by NhomBeXuat, Client
	drop table #TableSoLenh_HH
end