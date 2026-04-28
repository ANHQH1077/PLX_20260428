--USE [HTTG_Prod]
--GO
--/****** Object:  StoredProcedure [dbo].[KV2_BM_05_04]    Script Date: 12/08/2018 13:22:07 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GOfv
 -- exec [KV2_BM_05_04_20200630] '20200630', '20200630','B',null,null,null,'60C48736', '20200629', '20200629 23:00:00'
 ---20200630  Sua lay D15 tren tblLenhXuatHangHoaE5
create  PROCEDURE [dbo].[KV2_BM_05_04_TH]
	-- Add the parameters for the stored procedure here
	@p_FDate date, 
	@p_TDate date,
	@p_Client nvarchar(10),
	@p_NhomBe nvarchar(10),
	@p_MaHangHoa nvarchar(18),
	@p_SoCongTo nvarchar(30),
	@p_BeXuat nvarchar(20),
	@p_MaPhuongTien nvarchar(10),
	@p_TimeF datetime,
	@p_TimeT datetime
	WITH RECOMPILE  
AS
BEGIN
	
	declare @p_FromDateTime datetime
	declare @p_ToDateTime datetime
	
    declare @p_From_Hour int
	declare @p_From_MINUTE int
	
	declare @p_To_Hour int
	declare @p_To_MINUTE int
	
	declare @p_FromDate datetime
	declare @p_ToDate datetime
	
	declare @p_TableID nvarchar(50)
	declare @p_SoLenh nvarchar(50)
	declare @p_Count int
	declare @p_NgayXuat date
	declare @p_LineID nvarchar(50)
	declare @p_MaLenh nvarchar(50)
	
	set @p_From_Hour= datepart(hour,@p_TimeF)
	set @p_From_MINUTE = datepart(MINUTE ,@p_TimeF)
	set @p_to_Hour= datepart(hour,@p_TimeT)
	set @p_To_MINUTE = datepart(MINUTE ,@p_TimeT)
	
	
	
	 set @p_FromDateTime=  convert (datetime,     replace( CONVERT(char(10),@p_FDate, 102),'.','')  + ' ' +  CONVERT(char(5),@p_TimeF, 108))
	 
	 set @p_ToDateTime =   convert (datetime,  replace( CONVERT(char(10),@p_TDate, 102),'.','')  + ' ' +  CONVERT(char(5),@p_TimeT, 108))
	

	IF OBJECT_ID('tempdb..#TableVar2') IS NOT NULL
				 DROP TABLE #TableVar2			

	create table #TableVar2  (
			MeterID nvarchar(50) COLLATE SQL_Latin1_General_CP850_CI_AS
			)
	insert into #TableVar2
	select distinct  MeterId  from vwMeterAll where Client =ISNULL(@p_Client,client) 
			
	--select * from @TableVar2 
	
	
	declare @TableVar3 table (
			Client nvarchar(50)
			)
	insert into @TableVar3
	select Client   from FPT_Client_V  where Client =ISNULL(@p_Client,client) 
	
	declare @TableVarTmp table (
		MaHangHoa nvarchar(50), 
			TenHangHoa nvarchar(500), 
			SoLenh nvarchar(50),
			SoLuongThucXuat decimal(18,0) , --a.SoLuongThucXuat,
			SoLuongDuXuat_Ndo decimal(18,0) , --a.SoLuongThucXuat,
			BeXuat nvarchar(50), 
			MaPhuongTien nvarchar(50),
			SoCongTo nvarchar(50), 
			Sl_llkebd decimal(18,0),
			Sl_llkekt decimal(18,0),
			MaEntry decimal (5,1),
			 NhietDo decimal(10,2),
			TyTrong decimal (10,4),
			VCF decimal (10,4), 
			SluongQC decimal (18), 
			GioXuatKho datetime,
			Status nvarchar(5),
			client nvarchar(5),
			MaVanChuyen nvarchar(20),
			MaLuuLuongKe nvarchar(20),
			SoLuongDuXuat decimal(18),
			LineID nvarchar(20),
			MaLenh nvarchar(20),
			NgayXuat datetime,
			NgayTichKe datetime,
			TyTrong_15 numeric(10,4),
			ThoiGianDau datetime,
			DVT nvarchar(10),
			gst numeric(18,2)
			--CustomerID nchar(5) NOT NULL			
			,NhomBe nvarchar(10)
			)	
	
	--anhqh  20181208 lien quan den dung bang tam @TableVarTmp chayj cham khong len du lieu
	IF OBJECT_ID('tempdb..#TableVarTmp') IS NOT NULL
				 DROP TABLE #TableVarTmp			
	select * into #TableVarTmp from @TableVarTmp
	
		--anhqh  20181208 lien quan den dung bang tam @TableVarTmp chayj cham khong len du lieu
	IF OBJECT_ID('tempdb..#TableVarTmp22') IS NOT NULL
				 DROP TABLE #TableVarTmp22	
				 
	if isnull(@p_NhomBe,'') =''
		begin
			set @p_NhomBe ='ALL'
		end
	-- Enhance 12/06/2024
	SELECT *
	INTO #FPT_LenhXuat_TongHop_v
	FROM FPT_LenhXuat_TongHop_v
	WHERE Ngayxuat >= @p_FDate
		AND NgayXuat <= @p_TDate
			and isnull(NhomBeXuat,'') = case when isnull(@p_NhomBe,'') ='ALL' then isnull(NhomBeXuat,'') else @p_NhomBe  end 
	
	

	select SoLenh, min(ThoiGianDau) as ThoiGianDau   into #TableVarTmp22 
			from  (
							select kk.SoLenh, ThoiGianDau from  
							Fpt_tblLenhXuatChiTietE5_V kk inner join (select Distinct a.SoLenh 
															from #FPT_LenhXuat_TongHop_v a , #TableVar2 bb
														where ThoiGianDau>=  @p_FromDateTime --dateadd (day,-1 ,@p_Fdate) and 
															and  ThoiGianDau<=@p_ToDateTime   ---@p_TDate 
																	and a.Status in ('1','3','31','4','5')
																	and a.MaVanChuyen = 'ZT' 	
																	and a.MaLuuLuongKe =bb.MeterID 
																	--and exists (select 1 from  #TableVar2 bb where  a.MaLuuLuongKe =bb.MeterID 	)
																		and  a.MaHangHoa = ISNULL(@p_MaHangHoa,a.mahanghoa) -- case when len(@p_MaHangHoa)=0 OR @p_MaHangHoa IS NULL then a.MaHangHoa else @p_MaHangHoa end and
																  and ISNULL(a.MaLuuLuongKe,'') =isnull(@p_SoCongTo,isnull(MaLuuLuongKe,''))  -- case when  @p_SoCongTo IS NULL then ISNULL(a.MaLuuLuongKe,'') else @p_SoCongTo end and   -- case when len(@p_SoCongTo)=0 OR @p_SoCongTo IS NULL then ISNULL(a.MaLuuLuongKe,'') else @p_SoCongTo end and
																 and a.BeXuat =  ISNULL(@p_BeXuat,a.BeXuat)   --case when LEN(@p_BeXuat)=0 OR @p_BeXuat IS NULL then a.BeXuat else @p_BeXuat end and
																  and a.MaPhuongTien =isnull(@p_MaPhuongTien,a.maphuongtien) 		
															) kk1  
							on kk.SoLenh = kk1.SoLenh
								
								) kk2 group by SoLenh
				Having min(ThoiGianDau) > = @p_FromDateTime
							and  min(ThoiGianDau) < =@p_ToDateTime	
	--	Group by a.SoLenh		
				--and isnull(a.ThoiGianDau,getdate() )  > = @p_FromDateTime
				--and isnull(a.ThoiGianDau,getdate()) < =@p_ToDateTime				
	
	--return

	

	insert into #TableVarTmp
		(MaHangHoa , 
				TenHangHoa , 
				SoLenh ,
				SoLuongThucXuat 
				,SoLuongDuXuat_Ndo
				,BeXuat ,
				MaPhuongTien ,
				SoCongTo ,
				Sl_llkebd ,
				Sl_llkekt,
				MaEntry ,
				 NhietDo,
				TyTrong ,
				VCF ,
				SluongQC ,
				GioXuatKho ,
				Status,
				client,
				MaVanChuyen,
				MaLuuLuongKe,
				SoLuongDuXuat,
				LineID,
				MaLenh,
				NgayXuat,
				NgayTichKe,
				TyTrong_15,
				ThoiGianDau,
				gst, NhomBe ) 	
		SELECT	a.MaHangHoa, 
				a.TenHangHoa, 
				a.SoLenh, 
				a.SoLuongDuXuat as SoLuongThucXuat, --a.SoLuongThucXuat,
				a.SoLuongThucXuat as SoLuongDuXuat_Ndo,
				a.BeXuat, 
				a.MaPhuongTien,
				a.MaLuuLuongKe as SoCongTo, 
				a.Sl_llkebd,
				a.Sl_llkekt,
				a.MaEntry,
				--dbo.fm_NhietDo_TBE5 (a.LineID, a.MaLenh, a.NgayXuat) AS NhietDo,
				NhietDo as NhietDo,
				0 as  TyTrong,
				0.0000 as VCF, 
				0 as SluongQC, 
				 isnull(a.NgayTichKe,a.NgayXuat) as GioXuatKho,
				a.[Status], a.client,
				MaVanChuyen,
				MaLuuLuongKe,
				SoLuongDuXuat,
				LineID,
				MaLenh,
				NgayXuat,
				NgayTichKe,
				TyTrong_15,
				ThoiGianDau,
				gst, a.NhomBeXuat 
		from #FPT_LenhXuat_TongHop_v a, @TableVar3 a22
		where 
		
			CONVERT(date, isnull(a.NgayTichKe,a.NgayXuat))>=@p_Fdate and 
			convert(date,isnull(a.NgayTichKe,a.NgayXuat)) <=@p_TDate 
					and a.Status ='3'
					and a.MaVanChuyen = 'ZT' 
					and a.Client =a22.Client 	
					and  a.MaHangHoa = ISNULL(@p_MaHangHoa,a.mahanghoa)
					 and a.BeXuat =  ISNULL(@p_BeXuat,a.BeXuat) 	
					and a.MaPhuongTien =isnull(@p_MaPhuongTien,a.maphuongtien)  


	update  #TableVarTmp set  	ThoiGianDau=isnull(NgayTichKe,NgayXuat), 
					TyTrong=(select top 1 Dens_nd from FPT_tblTankActive_V where Name_nd = BeXuat and Date1 = convert(date,ISNULL( NgayTichKe,NgayXuat )))					
	
	--return

	declare @TableVar1 table (
		MaHangHoa nvarchar(50), 
			TenHangHoa nvarchar(500), 
			SoLenh nvarchar(50),
			SoLuongThucXuat decimal(18,0) , --a.SoLuongThucXuat,
			SoLuongDuXuat_Ndo decimal(18,0) , --a.SoLuongThucXuat,
			BeXuat nvarchar(50), 
			MaPhuongTien nvarchar(50),
			SoCongTo nvarchar(50), 
			Sl_llkebd decimal(18,0),
			Sl_llkekt decimal(18,0),
			MaEntry decimal (5,1),
			 NhietDo decimal(10,2),
			TyTrong decimal (10,4),
			VCF decimal (10,4), 
			SluongQC decimal (18), 
			GioXuatKho datetime,
			Status nvarchar(5),
			client nvarchar(5),
			MaVanChuyen nvarchar(20),
			MaLuuLuongKe nvarchar(20),
			SoLuongDuXuat decimal(18),
			LineID nvarchar(20),
			MaLenh nvarchar(20),
			NgayXuat datetime,
			NgayTichKe datetime,
			TyTrong_15 numeric(10,4),
			ThoiGianDau datetime,
			DVT nvarchar(10),
			gst numeric(18,2)
			
			,Tableid nvarchar(50)
			,Niem nvarchar(500)
			,NhomBe nvarchar(50)
			--CustomerID nchar(5) NOT NULL			
			)		
	IF OBJECT_ID('tempdb..#TableVarTmp33') IS NOT NULL
				 DROP TABLE #TableVarTmp33		
	
	select * into #TableVarTmp33 from @TableVar1

	insert into #TableVarTmp33   -----@TableVar1
		(MaHangHoa , 
				TenHangHoa , 
				SoLenh ,
				--SoLuongThucXuat 
				--,SoLuongDuXuat_Ndo,
					SoLuongDuXuat , 
					SoLuongThucXuat ,
				BeXuat ,
				MaPhuongTien ,
				SoCongTo ,
				Sl_llkebd ,
				Sl_llkekt,
				MaEntry ,
				 NhietDo,
				TyTrong ,
				VCF ,
				SluongQC ,
				GioXuatKho ,
				Status,
				client,
				MaVanChuyen,
				MaLuuLuongKe,
				--SoLuongDuXuat,
				LineID,
				MaLenh,
				NgayXuat,
				NgayTichKe,
				TyTrong_15,
				ThoiGianDau,
				gst
				,Tableid
				,Niem, NhomBe)
		SELECT	a.MaHangHoa, 
							a.TenHangHoa, 
							a.SoLenh, 
							a.SoLuongDuXuat , 
							a.SoLuongThucXuat ,
							--MaVanChuyen,
						--	dbo.FPT_LaySoThucXuat(MaVanChuyen , SoLuongThucXuat ,SoLuongDuXuat,0) as SoLuongThucXuat, 
							-- dbo.FPT_LaySoThucXuat(MaVanChuyen , SoLuongThucXuat ,SoLuongDuXuat,0) as SoLuongDuXuat_Ndo,		 
				 
							a.BeXuat, 
							a.MaPhuongTien,
							a.MaLuuLuongKe as SoCongTo, 
							a.Sl_llkebd,
							a.Sl_llkekt,
							a.MaEntry,
							--dbo.fm_NhietDo_TBE5 (a.LineID, a.MaLenh, a.NgayXuat) AS NhietDo,
							NhietDo as NhietDo,
							 TyTrong_15  as  TyTrong,
							0.0000 as VCF, 
							0 as SluongQC, 
							--case when a.[Status] = '3' then isnull(a.NgayTichKe,a.NgayXuat)
							--else a.ThoiGianDau end as GioXuatKho,
							 a.ThoiGianDau  as GioXuatKho,
							a.[Status], a.client,
							a.MaVanChuyen,
							MaLuuLuongKe,
							--SoLuongDuXuat,
							a.LineID,
							a.MaLenh,
							a.NgayXuat,
							a.NgayTichKe,
							TyTrong_15,
							a.ThoiGianDau,
							gst
							,a.Tableid
							--,(select Niem from tbllenhxuate5 with (nolock )  where SoLenh=a.SoLenh)  as Niem
							,a.Niem, a.NhomBeXuat 
					from 
						#FPT_LenhXuat_TongHop_v a INNER JOIN #TableVarTmp22 cc  -- enhanced below line
						-- FPT_LenhXuat_TongHop_v   a INNER JOIN #TableVarTmp22 cc 
						--, (select c1.MaPhuongTien, c1.MaVanChuyen, c1.Client
						--	, c1.NgayTichKe, c1.Niem, c1.SoLenh from tblLenhXuate5 c1 with (nolock)
						--			, #TableVarTmp22 bb  where c1.SoLenh =bb.SoLenh) cc					
							
						on  ---a.SoLenh =bb.SoLenh 
						
							 a.SoLenh =cc.SoLenh	
					and  a.MaHangHoa = ISNULL(@p_MaHangHoa,a.mahanghoa)
					 and a.BeXuat =  ISNULL(@p_BeXuat,a.BeXuat) 	
					and a.MaPhuongTien =isnull(@p_MaPhuongTien,a.maphuongtien)  
print @p_fromDatetime
print @p_todatetime
	--return
		--SoLuongThucXuat 
				--,SoLuongDuXuat_Ndo,
				--	dbo.FPT_LaySoThucXuat(MaVanChuyen , SoLuongThucXuat ,SoLuongDuXuat,0) as SoLuongThucXuat, 
							-- dbo.FPT_LaySoThucXuat(MaVanChuyen , SoLuongThucXuat ,SoLuongDuXuat,0) as SoLuongDuXuat_Ndo,	
		update  #TableVarTmp33 set SoLuongThucXuat  = dbo.FPT_LaySoThucXuat(MaVanChuyen , SoLuongThucXuat ,SoLuongDuXuat,0)
						, SoLuongDuXuat_Ndo =dbo.FPT_LaySoThucXuat(MaVanChuyen , SoLuongThucXuat ,SoLuongDuXuat,0)
		update #TableVarTmp33 set DVT ='L15' where MaHangHoa not like '07%'
		update #TableVarTmp33 set DVT ='KG' where MaHangHoa  like '07%'
		--update @TableVar1 set DVT ='L15' where MaHangHoa not like '07%'
		--update @TableVar1 set DVT ='KG' where MaHangHoa  like '07%'
		
	declare @p_TblSoLenh table (SoLenh nvarchar(50))
		  insert into @p_TblSoLenh (SoLenh)
		  select distinct SoLenh from #TableVarTmp22   ----@TableVar1

	
	--select * from @p_TblSoLenh
	--return
	

	declare @p_tbllenhxuat_hanghoaE5 table (
					NgayXuat date
					,SoLenh nvarchar(50)
					,TableID nvarchar(50), 
					NhietDo_BQGQ decimal (10,5)
					,D15_BQGQ decimal (10,5) 
					, vcf decimal (10,5)
					,Wcf decimal (10,5)
					, Kg decimal (18,2)
					, L15 decimal (18,2)
					 ,MaHangHoa nvarchar(50)
					 ,LineID nvarchar(50),
					MaLenh nvarchar(50)
					,MultiD15 int
					
					--NgayXuat date
					-- ,Tableid nvarchar(50)
		) 
	insert into @p_tbllenhxuat_hanghoaE5 (
					NgayXuat 
					,SoLenh 
					,TableID , 
					NhietDo_BQGQ 
					,D15_BQGQ 
					, vcf
					,Wcf 
					, Kg 
					, L15 
					 ,MaHangHoa 
					 ,LineID ,
					MaLenh 
					,MultiD15
					--NgayXuat 
					 --,Tableid 
							)
	select  NgayXuat 
					,SoLenh 
					,TableID , 
					NhietDo_BQGQ 
					,D15_BQGQ 
					, vcf
					,Wcf 
					, Kg 
					, L15 
					 ,MaHangHoa 
					, LineID ,
					MaLenh 
					,1				
					 from tbllenhxuat_hanghoaE5 aa with (nolock ) 
		where exists (select 1 from @p_TblSoLenh where SoLenh=aa.SoLenh)			

	declare @TableVar22 table (
		MaHangHoa nvarchar(50), 
			TenHangHoa nvarchar(500), 
			SoLenh nvarchar(50),
			SoLuongThucXuat decimal(18,0) , --a.SoLuongThucXuat,
			SoLuongDuXuat_Ndo decimal(18,0) , --a.SoLuongThucXuat,
			BeXuat nvarchar(50), 
			MaPhuongTien nvarchar(50),
			SoCongTo nvarchar(50), 
			Sl_llkebd decimal(18,0),
			Sl_llkekt decimal(18,0),
			MaEntry decimal (5,1),
			 NhietDo decimal(10,2),
			TyTrong decimal (10,4),
			VCF decimal (10,4), 
			SluongQC decimal (18), 
			GioXuatKho datetime,
			Status nvarchar(5),
			client nvarchar(5),
			MaVanChuyen nvarchar(20),
			MaLuuLuongKe nvarchar(20),
			SoLuongDuXuat decimal(18),
			LineID nvarchar(20),
			MaLenh nvarchar(20),
			NgayXuat datetime,
			NgayTichKe datetime,
			TyTrong_15 numeric(10,4),
			ThoiGianDau datetime,
			DVT nvarchar(10),
			gst numeric(18,2)
			,Niem nvarchar(400)
			,TableID nvarchar(50)
			,NhietDo_BQGQ  decimal(10,2) 
			,NhietDoBQ  decimal(10,2)
			,D15_BQGQ  numeric(10,4)
			,TyTrongBQ numeric(10,4)
			,TyTrong15 numeric(10,4)
			,Wcf numeric(10,4)
			,Kg   numeric(18,2)
			,L15 	  numeric(18,2)								
			,MultiD15  int 
			,SluongXuatCto   numeric(18,2)		
			,CCHH 	numeric(6,2)
			,NgayXuatKho datetime	
			,NhomBeXuat nvarchar(10)
			--CustomerID nchar(5) NOT NULL			
			)	



		insert into @TableVar22 
			(MaHangHoa, 
			   TenHangHoa,
			   SoLenh, 			
			    SoLuongDuXuat_Ndo, 
			   BeXuat, 
			   MaPhuongTien,
			   SoCongTo, 
				 Sl_llkebd,
			   Sl_llkekt,
			   SluongXuatCto, 
			    CCHH, -- Chiều cao hầm hàng			   
			    NhietDo_BQGQ 
			   ,NhietDoBQ			  
			  ,D15_BQGQ
			  ,TyTrongBQ 
			  ,TyTrong15			   
			  , VCF  			
			   ,SluongQC,
				GioXuatKho,
				NgayXuatKho,
				[Status],
				DVT,
				gst , Niem
				,MultiD15
				-- ,vcf
				,Wcf 
				 ,Kg 
				 ,L15 
				 ,NhomBeXuat 			)			
		select MaHangHoa, 
			   TenHangHoa,
			   SoLenh, 
			 --  Niem,
			    SluongThucXuat, 
			   BeXuat, 
			   MaPhuongTien,
			   SoCongTo, 
				 CSCtoDau,
			   CSCtoCuoi,
			   SluongXuatCto, 
			    CCHH, -- Chiều cao hầm hàng
			    NhietDo_BQGQ 
			   ,NhietDoBQ			  
			  ,D15_BQGQ
			  ,TyTrongBQ 
			  ,TyTrong15			   
			  , VCF  			
			   ,SluongQC,
				GioXuatKho,
				NgayXuatKho,
				[Status],
				DVT,
				gst , Niem
				,MultiD15
				-- ,vcf
				,Wcf 
				 ,Kg 
				 ,L15 	
				 , NhomBe
				from  (			
				
						select MaHangHoa, 
							   TenHangHoa,
							   SoLenh, 							  
								SluongThucXuat, 
							   BeXuat, 
							   MaPhuongTien,
							   SoCongTo, 
								 CSCtoDau,
							   CSCtoCuoi,
							   SluongXuatCto, 
								CCHH, -- Chiều cao hầm hàng
							  round( (NhietDoBQ /SluongThucXuat),2) NhietDoBQ,
							  round((TyTrongBQ/SluongThucXuat),4) as TyTrongBQ
								  , TyTrong15,
								   --VCF,
									 L15 as SluongQC,
									GioXuatKho,
									NgayXuatKho,
									[Status],
									DVT,
									gst, Niem
								,isnull(NhietDo_BQGQ,0) as NhietDo_BQGQ 
													,isnull(D15_BQGQ,0) as D15_BQGQ 
													,isnull(vcf,0) as vcf
													,isnull(Wcf,0) as Wcf 
													, isnull(Kg,0) as Kg 
													, isnull(L15,0) L15 									
													,MultiD15 , NhomBe
								from  (
											select h.MaHangHoa, 
												   TenHangHoa,
												   h.SoLenh, 
												   Niem,
												   sum(SoLuongDuXuat_Ndo) as SluongThucXuat, 
												   BeXuat, 
												   MaPhuongTien,
												   SoCongTo, 
												   min(Sl_llkebd) as CSCtoDau,
												   max(Sl_llkekt) as CSCtoCuoi,
												   max(Sl_llkekt) - min(Sl_llkebd) as SluongXuatCto, 
												   sum(MaEntry) as CCHH, -- Chiều cao hầm hàng
												   round(sum(NhietDo *  SoLuongDuXuat_Ndo) ,0) as NhietDoBQ,								  
													
												  round(sum(TyTrong *  SoLuongDuXuat_Ndo) ,0) as TyTrongBQ,		
												  min(TyTrong) as TyTrong15			 
												,  0 as SluongQC,   	   
												min(GioXuatKho)	as GioXuatKho,			
												 min(GioXuatKho)	as NgayXuatKho,			
												
												Status ,
												DVT		,
												round( SUM(isnull(gst,0)),0) as gst	 
												,NhietDo_BQGQ 
													,D15_BQGQ 
													, h1.vcf
													,Wcf 
													, Kg 
													, L15 									
													,MultiD15  	
													, isnull(h.NhomBe,'') as NhomBe
											from  --@TableVar1 h
												#TableVarTmp33 h   ----@TableVar1
													INNER JOIN @p_tbllenhxuat_hanghoaE5 h1
												
													ON h.solenh=h1.solenh and h.tableid=h1.tableid
																 and h.ngayxuat=h1.ngayxuat												
																and h.LineID =h1.LineID
																and h.MaLenh=H1.MaLenh 									
															
											group by h.MaHangHoa, TenHangHoa, h.SoLenh,Niem,  h.BeXuat
													, h.MaPhuongTien, h.SoCongTo, [Status],DVT 
													,NhietDo_BQGQ 
													,D15_BQGQ 
													, h1.vcf
													,Wcf 
													, Kg 
													, L15 									
													,MultiD15  , isnull(h.NhomBe,'')
										) anhqh		

		) abc 
		
		
	--	return
		
		--select * from @TableVar22
		--return


		--update @TableVar22 set NhietDo=NhietDoBQ where isnull(NhietDo_BQGQ,0) <=0

		update @TableVar22 set NhietDo=NhietDo_BQGQ where isnull(NhietDo_BQGQ,0) >0
		
		--update  @TableVar22 set TyTrong=D15_BQGQ where isnull(D15_BQGQ,0) >0 and MultiD15<=
		
		update  @TableVar22 set TyTrong=TyTrong15 where  isnull(D15_BQGQ,0) <=0      ---MultiD15<=1 --isnull(D15_BQGQ,0) <=0 and MultiD15<=1
		update  @TableVar22 set TyTrong=D15_BQGQ where isnull(D15_BQGQ,0) >0 ----and MultiD15 >1
		


		update @TableVar22 set 			
								  VCF = dbo.zzFPT_mdlQCI_GetVCF_NS (NhietDo,TyTrong)								
							  where vcf =0
		
		
		
		update @TableVar22 set SluongQC=  L15 ----round (SoLuongDuXuat_Ndo *VCF  ,0)
				, SoLuongThucXuat=SoLuongDuXuat_Ndo --where isnull(SluongQC,0) <=0
		
	
		
		update @TableVar22 set SluongQC=  KG ----- case when isnull(kg,0) >0 then kg  else(TyTrong -0.0011) * SluongQC end
						where upper( DVT) = 'KG' 
		
	
	
	
		
	select MaHangHoa, 
			   TenHangHoa,
			   SoLenh, 
			   sum(SoLuongDuXuat) as SluongThucXuat,
			   BeXuat, 
			   MaPhuongTien,
			   SoCongTo,
			   min(Sl_llkebd) as CSCtoDau,
			   max(Sl_llkekt) as CSCtoCuoi,
			   max(Sl_llkekt) - min(Sl_llkebd) as SluongXuatCto, 
			   sum(MaEntry) as CCHH, -- Chiều cao hầm hàng
			   0 as NhietDo,
			 avg(convert(decimal(14,5),TyTrong)) as TyTrong,
			-- -- 0.0000 as VCF, --BM_05_04.VCF, 
			 0 as VCF,
			  0 as SluongQC,   	   
			convert(char(5), min(GioXuatKho), 108)	as GioXuatKho,			
			 min(GioXuatKho)	as NgayXuatKho,			
			--GioXuatKho,	
			Status ,
			DVT,
			0 as gst
			, isnull(a1.NhomBe,'') as NhomBe 
				, case when isnull(a1.NhomBe,'')  <> '' then  isnull(a1.NhomBe,'')  + ' - ' +  a2.GrpName else '' end as TenNhomBe,  isnull(@p_Client,'')  as Client
		from  #TableVarTmp  a1 
				left join tblTankGroupList_V a2  on    isnull(a1.NhomBe,'')  =  a2.Code			
		group by MaHangHoa, TenHangHoa, SoLenh,  BeXuat, MaPhuongTien, SoCongTo, [Status],DVT ,isnull(a1.NhomBe,''), a2.GrpName

   union  all
      
	select MaHangHoa, 
				   TenHangHoa,
				   SoLenh, 
				   SoLuongThucXuat as SluongThucXuat,
				   BeXuat, 
				   MaPhuongTien,
				   SoCongTo,
				   Sl_llkebd as CSCtoDau,
				   Sl_llkekt as CSCtoCuoi,
				   SluongXuatCto, 
				   CCHH, -- Chiều cao hầm hàng
				  NhietDo,
				 TyTrong,
				-- -- 0.0000 as VCF, --BM_05_04.VCF, 
				 VCF,
				 SluongQC,   	   
				convert(char(5), GioXuatKho, 108)	as GioXuatKho,			
				 GioXuatKho	as NgayXuatKho,			
				--GioXuatKho,	
				Status ,
				DVT,
				0 as gst
				, a2.Code as NhomBe 
				, case when isnull(a1.NhomBeXuat,'')  <> '' then  isnull(a1.NhomBeXuat,'')  + ' - ' +  a2.GrpName else '' end as TenNhomBe,  isnull(@p_Client,'')   as Client
			from  @TableVar22 	a1  
			left join tblTankGroupList_V a2  on    isnull(a1.NhomBeXuat,'')  =  a2.Code
	------Bổ sung cho nhóm tổng hợp========================================================================
	 union all
	select MaHangHoa, 
			   TenHangHoa,
			   SoLenh, 
			   sum(SoLuongDuXuat) as SluongThucXuat,
			   BeXuat, 
			   MaPhuongTien,
			   SoCongTo,
			   min(Sl_llkebd) as CSCtoDau,
			   max(Sl_llkekt) as CSCtoCuoi,
			   max(Sl_llkekt) - min(Sl_llkebd) as SluongXuatCto, 
			   sum(MaEntry) as CCHH, -- Chiều cao hầm hàng
			   0 as NhietDo,
			 avg(convert(decimal(14,5),TyTrong)) as TyTrong,
			-- -- 0.0000 as VCF, --BM_05_04.VCF, 
			 0 as VCF,
			  0 as SluongQC,   	   
			convert(char(5), min(GioXuatKho), 108)	as GioXuatKho,			
			 min(GioXuatKho)	as NgayXuatKho,			
			--GioXuatKho,	
			Status ,
			DVT,
			0 as gst
			,'' as NhomBe 
				, N'Tổng cộng' as TenNhomBe, isnull(@p_Client,'')  as Client
		from  #TableVarTmp  a1 
				--left join tblTankGroupList_V a2  on    isnull(a1.NhomBe,'')  =  a2.Code			
		group by MaHangHoa, TenHangHoa, SoLenh,  BeXuat, MaPhuongTien, SoCongTo, [Status],DVT 
	
	union  all      
	select MaHangHoa, 
				   TenHangHoa,
				   SoLenh, 
				   SoLuongThucXuat as SluongThucXuat,
				   BeXuat, 
				   MaPhuongTien,
				   SoCongTo,
				   Sl_llkebd as CSCtoDau,
				   Sl_llkekt as CSCtoCuoi,
				   SluongXuatCto, 
				   CCHH, -- Chiều cao hầm hàng
				  NhietDo,
				 TyTrong,
				-- -- 0.0000 as VCF, --BM_05_04.VCF, 
				 VCF,
				 SluongQC,   	   
				convert(char(5), GioXuatKho, 108)	as GioXuatKho,			
				 GioXuatKho	as NgayXuatKho,			
				--GioXuatKho,	
				Status ,
				DVT,
				0 as gst
				, '' as NhomBe 
				, N'Tổng cộng' as TenNhomBe, isnull(@p_Client,'')  as Client
			from  @TableVar22 	a1  
			--left join tblTankGroupList_V a2  ---on    isnull(a1.NhomBeXuat,'')  =  a2.Code

	DROP TABLE #TableVar2
	DROP TABLE #TableVarTmp
	DROP TABLE #TableVarTmp22
	DROP TABLE #TableVarTmp33
END
