

-- =============================================
-- Author:		anhqh 20191025
-- Create date: <Create Date,,>
-- Description:	Bao bao liet ke bien ban ban giao
--  exec   [dtLietKeBienBanBanGiao_Test]  '20191230','20191230','B'
-- =============================================
ALTER PROCEDURE [dbo].[dtLietKeBienBanBanGiao]
	@p_FromDate date
	,@p_ToDate date
	,@p_Client nvarchar(140)
AS
BEGIN
	declare @p_HH nvarchar(1000)
	declare @p_TongDuXuat nvarchar(10) --TONGDUXUAT	1	1: Lấy số dự xuât, 0: Lấy số thưc xuất
	
	declare @p_TongDuXuatThuy nvarchar(10) --TONGDUXUAT	1	1: Lấy số dự xuât, 0: Lấy số thưc xuất
	declare @p_TongSoNiem nvarchar(100)
	
	
	declare @p_tblBienBanGiaoNhan table (SoBienBan nvarchar(200)
											, NgayTao datetime, BienBanID int)
	
	declare @p_tblLenhXuatChiTiet table (MaHangHoa nvarchar(100),SoLenh nvarchar(100)
					,MaLuuLuongKe nvarchar(20), SoThucXuat decimal(18,0), SoDuXuat decimal(18,0)
					,HH nvarchar(100) , MaNgan nvarchar(50), SoBienBan nvarchar(200))
	
											
	declare @p_tblLenhXuat table (SoLenh nvarchar(100),
										SoBienBan nvarchar(200), MaTraCuu nvarchar(200)
										,SoBienBanMau nvarchar(200), Niem nvarchar(500), NgayTao datetime
										, DO1_MaKhach nvarchar(200)
										,DO1_TenKhach nvarchar(2000)
										,MaVanChuyen nvarchar(100)
										,TongSoNiem nvarchar(100))
	
	 --1: Lấy số dự xuât, 0: Lấy số thưc xuất
	 set @p_TongDuXuat = (select top 1 KeyValue from sys_config  where KeyCode = 'TONGDUXUAT')
	 set @p_TongDuXuat =isnull(@p_TongDuXuat,'1')
	 
	  set @p_TongDuXuatthuy = (select top 1 KeyValue from sys_config  where KeyCode = 'TONGDUXUATTHUY')
	 set @p_TongDuXuatthuy =isnull(@p_TongDuXuatthuy,'1')
	 
	insert into @p_tblBienBanGiaoNhan (SoBienBan, NgayTao, BienBanID)
			select SoBienBan , CreateDate , Row_ID as BienBanID   from tblBienBanGiaoNhan_HIST h1 with(nolock)
				where Convert(date,CreateDate) >= @p_FromDate 
						 and Convert(date,CreateDate) <= @p_ToDate   and sStatus ='I'
						----	and Client = case when isnull(@p_Client,'')='' then Client else 'B' end
						and not exists (select SoBienBan , CreateDate  from tblBienBanGiaoNhan_HIST hh with(nolock)
										where Convert(date,cancelDate) >= @p_FromDate 
												 and Convert(date,cancelDate) <= @p_ToDate   and sStatus ='C'
													and hh.SoBienBan =h1.SoBienBan)

	--  exec   [dtLietKeBienBanBanGiao_Test]  '20191230','20191230','C'
	
	--elect*from @p_tblBienBanGiaoNhan				
	-----return		


	insert into @p_tblLenhXuat (SoLenh, SoBienBan, MaTraCuu, SoBienBanMau, Niem, NgayTao, DO1_MaKhach , MaVanChuyen, TongSoNiem) 
	 select a.SoLenh, ab.SoBienBan,(select top 1 MaTraCuu from tblHoaDonDienTu a22
									where a22.VBELN = a.SoLenh) as  MaTraCuu, 
									SoBienBanMau , Niem, ab.NgayTao, a.DO1_MaKhach
									,dbo.FPT_GetLoadingSite(a.MaVanChuyen)  as MaVanChuyen 
									, a.TongSoNiem
									 from tblLenhXuatE5 a with (nolock)
									,(select aa.SoLenh, b.SoBienBan, b.NgayTao from @p_tblBienBanGiaoNhan b, tblLenhXuatE5_BienBan aa with (nolock)  
										 where aa.BienBan_ID=b.BienBanID ) ab
							where a.SoLenh =ab.SoLenh  and a.Client = case when isnull(@p_Client,'')='' then a.Client else @p_Client end
						
	
	 update @p_tblLenhXuat  set   
				 DO1_TenKhach = (select top 1 TenKhachHang from tblKhachHang h where h.MaKhachHang = [@p_tblLenhXuat].DO1_MaKhach ) 
				where isnull(DO1_MaKhach,'') <>''
		
						  
			----where exists 
			
	insert into @p_tblLenhXuatChiTiet (MaHangHoa, SoLenh,MaLuuLuongKe , SoThucXuat, HH,  MaNgan, SoDuXuat )
			select gg.MaHangHoa, gg.SoLenh, gg.MaLuuLuongKe
			
			,case when gg1.MaVanChuyen ='THUY' then
				case when @p_TONGDUXUATTHUY ='1' then
					gg.SoLuongDuXuat
				else
					gg.SoLuongThucXuat
				end
			else
				case when @p_TONGDUXUAT ='1' then
					gg.SoLuongDuXuat
				else
					gg.SoLuongThucXuat
				end
			end  as SoLuongThucXuat
			---, gg.SoLuongThucXuat
				, case when gg.MaEntry >0 then  '+' + convert(nvarchar(10), gg.MaEntry)   else convert(nvarchar(10), gg.MaEntry)  end as HH 
						, gg.MaNgan
						, gg.SoLuongDuXuat	
			 from fpt_tblLenhXuatChiTiete5_v gg, @p_tblLenhXuat gg1
				where gg.SoLenh =gg1.SoLenh
					---where exists (select 1 from @p_tblLenhXuat b where gg.SoLenh=b.SoLenh) 
----@p_TongSoNiem =
--select @p_TongSoNiem = 	sum(convert(int,isnull(TongSoNiem, '0')) )  from 
--	(	select distinct TongSoNiem from @p_tblLenhXuat where isnull(TongSoNiem,'')<> '') abc


update  @p_tblLenhXuatChiTiet set SoBienBan   = (select top  1 SoBienBan  from   @p_tblLenhXuat  where SoLenh =[@p_tblLenhXuatChiTiet].soLenh)


select top 1  @p_TongSoNiem =TongSoNiem from @p_tblLenhXuat  where isnull(TongSoNiem,'')<> ''

declare @p_Table table (MaKhachHang int
				,TenKhachHang nvarchar(2000)
				,NguoiVanChuyen nvarchar(500)
				,SoBienBanMau nvarchar(500)
				,Niem nvarchar(500)
				,SoLenh nvarchar(50)
				,DiemTraHang nvarchar(max)
				, TongXuat decimal(18,0)
				, MaHangHoa nvarchar(50)
				,DonViTinh nvarchar(50)
				,SoBienBan nvarchar(50)
				,BeXuat nvarchar(50)
				,  HongXuat nvarchar(50)
				,SoThucXuat decimal(18,0)
				,NhietDo_BQGQ decimal(10,2)
				, D15_BQGQ decimal(10,4)
				,VCF decimal(10,4)
				, L15 decimal(18,0)
				, WCF decimal(10,4)
				,KG decimal(18,0)
				, MaTraCuu nvarchar(50)
				,MaPhuongTien	nvarchar(50)
			,HH	nvarchar(500)
			,Client	nvarchar(50)
			,NgayGio datetime
			, NgayTao  nvarchar(50)			
	)
insert into @p_Table (MaKhachHang ,TenKhachHang,NguoiVanChuyen,SoBienBanMau,Niem,SoLenh,DiemTraHang, TongXuat
				, MaHangHoa,DonViTinh,SoBienBan,BeXuat,  HongXuat,SoThucXuat,NhietDo_BQGQ , D15_BQGQ
				,VCF , L15, WCF ,KG, MaTraCuu ,MaPhuongTien	,HH	,Client,NgayGio, NgayTao )
select convert(int,MaKhachHang) as MaKhachHang,TenKhachHang,NguoiVanChuyen,SoBienBanMau,Niem 
		--+ ' ('+ convert(nvarchar(100),isnull(@p_TongSoNiem,'')) +')   ' 
		+ ' ('+ convert(nvarchar(100),isnull(TongSoNiem,'')) +')   ' 
		+ HH 	as Niem,
		 SoLenh,
		 DiemTraHang,
		
				case when left(MaHangHoa,2) ='07' then KG else 
					case when DonViTinh='L' then SoThucXuat else 
							case when DonViTinh='L15' then L15 else 
									KG 						
							end  
					end 
				end as TongXuat 
					,MaHangHoa,case when left(MaHangHoa,2) ='07' then 'KG' else DonViTinh end as  DonViTinh,
						left(SoBienBan,7) as SoBienBan
	, BeXuat,  HongXuat
		,SoThucXuat,NhietDo_BQGQ, D15_BQGQ,VCF, L15, WCF,KG, MaTraCuu,MaPhuongTien	
			,HH	,Client	,NgayGio, convert(nvarchar(10),NgayTao,103) as  NgayTao 	
	from (			
			select  TongSoNiem,
				case when isnull(c.DO1_MaKhach,'') <>'' then c.DO1_MaKhach
					else a.MaKhachHang
				end MaKhachHang
				,case when isnull(c.DO1_MaKhach,'') <>'' then  c.DO1_TenKhach
					else a.TenKhachHang
				end as TenKhachHang,a.NguoiVanChuyen,N'BBM: ' + c.SoBienBanMau as SoBienBanMau ,N'Niêm: ' + a.Niem as Niem,
				 a.SoLenh
				 --, a.DiemTraHang
				 ,case when isnull(a.DesDisChargePoint,'') <>'' then a.DesDisChargePoint  else  a.DiemTraHang end  DiemTraHang
				 , b.TongXuat,b.MaHangHoa, b.DonViTinh, c.SoBienBan
			, b.BeXuat, (select top 1 MaLuuLuongKe from @p_tblLenhXuatChiTiet c
								where c.SoLenh=b.SoLenh and c.MaHangHoa =b.MaHangHoa) as HongXuat
				,(select sum(case when @p_TongDuXuat ='1' then SoDuXuat   else SoThucXuat  end )  from @p_tblLenhXuatChiTiet c
								where c.SoLenh=b.SoLenh and c.MaHangHoa =b.MaHangHoa) as SoThucXuat
								
					, b.NhietDo_BQGQ, b.D15_BQGQ, b.VCF, b.L15, b.WCF, b.KG, c.MaTraCuu		, a.MaPhuongTien	
					,(SELECT 'H' + Mangan + ':' + HH + ';' AS [text()] 							
						 from (	select SoBienBan, MaNgan, HH FROM @p_tblLenhXuatChiTiet  g1 where g1.SoLenh 
											in (select SoLenh from @p_tblLenhXuat)  ) abc
													where abc.SoBienBan =c.SoBienBan  order by MaNgan
									FOR XML PATH ('') ) as HH	
									, a.Client	, c.NgayTao as NgayGio, convert(date,c.NgayTao) as NgayTao 	
							from fpt_tblLenhXuate5_v a, tblLenhXuat_HangHoaE5 b  with (nolock) ,@p_tblLenhXuat c
								where a.SoLenh =b.SoLenh and a.SoLenh=c.SoLenh) abc;
	
	
	---========================================================
	select * from @p_Table	;						
	select getdate() as PrintDate, isnull((select count(*) from @p_tblLenhXuat),0) as TongSoLenh;	

	
	select MaHangHoa,    isnull( sum(SoThucXuat),0)   as Ltt , 'L' as sLtt
			 ,  isnull( sum(L15),0)  as L15, 'L15'  as sL15
			   ,  isnull( sum(KG),0) as KG, 'KG' as sKG
					 from @p_Table 
		group by MaHangHoa;	
	--select MaHangHoa, convert(nvarchar(50), isnull( sum(SoThucXuat),0)  ) +'L' as Ltt
	--		 ,  convert(nvarchar(50),isnull( sum(L15),0)) + 'L15'  as L15
	--		   , convert(nvarchar(50), isnull( sum(KG),0)) as Ltt
			
		--from (
		--	select  
		--			b.MaHangHoa, b.L15, b.KG,(select sum(case when @p_TongDuXuat ='1' then SoDuXuat   else SoThucXuat  end )  from @p_tblLenhXuatChiTiet c
		--								where c.SoLenh=b.SoLenh and c.MaHangHoa =b.MaHangHoa) as SoThucXuat
		--							from fpt_tblLenhXuate5_v a, tblLenhXuat_HangHoaE5 b  with (nolock) ,@p_tblLenhXuat c
		--								where a.SoLenh =b.SoLenh and a.SoLenh=c.SoLenh  ) aaa
		--	group by MaHangHoa;
								
								
END


