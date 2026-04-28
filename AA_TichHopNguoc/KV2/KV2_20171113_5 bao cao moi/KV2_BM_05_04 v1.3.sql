--USE [HTTG_Prod]
--GO
--/****** Object:  StoredProcedure [dbo].[KV2_BM_05_04]    Script Date: 12/08/2018 13:22:07 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

alter PROCEDURE [dbo].[KV2_BM_05_04]
	-- Add the parameters for the stored procedure here
	@p_FDate date, 
	@p_TDate date,
	@p_Client nvarchar(10),
	@p_MaHangHoa nvarchar(18),
	@p_SoCongTo nvarchar(30),
	@p_BeXuat nvarchar(20),
	@p_MaPhuongTien nvarchar(10),
	@p_TimeF datetime,
	@p_TimeT datetime
AS
BEGIN

	
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
	
	
	
	
	declare @p_FromTime int 
	set @p_FromTime =  convert(nvarchar(4),	@p_From_Hour ) +  case when LEN(convert(nvarchar(4),@p_From_MINUTE)) =1 then '0' +  convert(nvarchar(4),@p_From_MINUTE)
								else convert(nvarchar(4),@p_From_MINUTE) end
	declare @p_ToTime int
	set @p_ToTime= convert(nvarchar(4),	@p_To_Hour ) + case when LEN(convert(nvarchar(4),@p_To_MINUTE)) =1 then '0' +  convert(nvarchar(4),@p_To_MINUTE)
								else convert(nvarchar(4),@p_To_MINUTE) end
	
	
	
	declare @TableVar2 table (
			MeterID nvarchar(50)
			)
	insert into @TableVar2
	select distinct  MeterId  from vwMeterAll where Client =ISNULL(@p_Client,client) 
			
	--select * from @TableVar2 
	--return
	
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
			)	
	
	--anhqh  20181208 lien quan den dung bang tam @TableVarTmp chayj cham khong len du lieu
	IF OBJECT_ID('tempdb..#TableVarTmp') IS NOT NULL
				 DROP TABLE #TableVarTmp			
	select * into #TableVarTmp from @TableVarTmp
	
	
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
				gst ) 	
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
				gst
		from FPT_LenhXuat_TongHop_v a, @TableVar3 a22
		where 
		
			CONVERT(date, isnull(a.NgayTichKe,a.NgayXuat))>=@p_Fdate and 
			convert(date,isnull(a.NgayTichKe,a.NgayXuat)) <=@p_TDate 
					and a.Status ='3'
					and a.MaVanChuyen = 'ZT' 
					and a.Client =a22.Client 	
					 and a.BeXuat =  ISNULL(@p_BeXuat,a.BeXuat) 	
					and a.MaPhuongTien =isnull(@p_MaPhuongTien,a.maphuongtien)  
	update  #TableVarTmp set  	ThoiGianDau=isnull(NgayTichKe,NgayXuat), 
					TyTrong=(select top 1 Dens_nd from FPT_tblTankActive_V where Name_nd = BeXuat and Date1 = convert(date,ISNULL( NgayTichKe,NgayXuat )))					
								
				
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
			--CustomerID nchar(5) NOT NULL			
			)		
	insert into @TableVar1
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
				gst
				,Tableid
				,Niem)
	SELECT	a.MaHangHoa, 
				a.TenHangHoa, 
				a.SoLenh, 
				--a.SoLuongDuXuat as SoLuongThucXuat, 
				--a.SoLuongThucXuat as SoLuongDuXuat_Ndo,
				
				dbo.FPT_LaySoThucXuat(MaVanChuyen , SoLuongThucXuat ,SoLuongDuXuat,0) as SoLuongThucXuat, 
				 dbo.FPT_LaySoThucXuat(MaVanChuyen , SoLuongThucXuat ,SoLuongDuXuat,0) as SoLuongDuXuat_Ndo,
				 
				 
				a.BeXuat, 
				a.MaPhuongTien,
				a.MaLuuLuongKe as SoCongTo, 
				a.Sl_llkebd,
				a.Sl_llkekt,
				a.MaEntry,
				--dbo.fm_NhietDo_TBE5 (a.LineID, a.MaLenh, a.NgayXuat) AS NhietDo,
				NhietDo as NhietDo,
				case when a.[Status] = '3' then --dbo.fm_TyTrongE5 (a.LineID, a.MaLenh, a.NgayXuat) 
				0 else TyTrong_15 end as  TyTrong,
				0.0000 as VCF, 
				0 as SluongQC, 
				case when a.[Status] = '3' then isnull(a.NgayTichKe,a.NgayXuat)
				else a.ThoiGianDau end as GioXuatKho,
				a.[Status], client,
				MaVanChuyen,
				MaLuuLuongKe,
				SoLuongDuXuat,
				LineID,
				MaLenh,
				NgayXuat,
				NgayTichKe,
				TyTrong_15,
				ThoiGianDau,
				gst
				,Tableid
				,(select Niem from tbllenhxuate5 with (nolock )  where SoLenh=a.SoLenh)  as Niem
		from FPT_LenhXuat_TongHop_v a, @TableVar2 bb
		where convert(date,ThoiGianDau)>=@p_Fdate and 
			CONVERT(date,ThoiGianDau)<=@p_TDate 
					and a.Status in ('31','4','5')
					and a.MaVanChuyen = 'ZT' 	
					and a.MaLuuLuongKe =bb.MeterID 				
						and  a.MaHangHoa = ISNULL(@p_MaHangHoa,a.mahanghoa) -- case when len(@p_MaHangHoa)=0 OR @p_MaHangHoa IS NULL then a.MaHangHoa else @p_MaHangHoa end and
				  and ISNULL(a.MaLuuLuongKe,'') =isnull(@p_SoCongTo,isnull(MaLuuLuongKe,''))  -- case when  @p_SoCongTo IS NULL then ISNULL(a.MaLuuLuongKe,'') else @p_SoCongTo end and   -- case when len(@p_SoCongTo)=0 OR @p_SoCongTo IS NULL then ISNULL(a.MaLuuLuongKe,'') else @p_SoCongTo end and
				 and a.BeXuat =  ISNULL(@p_BeXuat,a.BeXuat)   --case when LEN(@p_BeXuat)=0 OR @p_BeXuat IS NULL then a.BeXuat else @p_BeXuat end and
				  and a.MaPhuongTien =isnull(@p_MaPhuongTien,a.maphuongtien)  
				  
				  and  CONVERT(int, REPLACE( CONVERT(char(5),a.ThoiGianDau, 108),':','')) >=  @p_FromTime
				and convert(int,  REPLACE( CONVERT(char(5),a.ThoiGianDau, 108),':','')) <= @p_ToTime	
	
		
		update @TableVar1 set DVT ='L15' where MaHangHoa not like '07%'
		update @TableVar1 set DVT ='KG' where MaHangHoa  like '07%'
		
	declare @p_TblSoLenh table (SoLenh nvarchar(50))
  insert into @p_TblSoLenh (SoLenh)
  select distinct SoLenh from @TableVar1

	
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
	
	DECLARE p_CursorTmp CURSOR FOR  
				select SoLenh, tableid, NgayXuat, LineID, MaLenh, count(TyTrong_15) as nCount from  (

				SELECT 
									 SoLenh, tableid,NgayXuat, LineID, MaLenh,TyTrong_15
								FROM 
									@TableVar1 AS lxct 
								where  exists (select 1 from @p_tbllenhxuat_hanghoaE5 b
													where b.SoLenh=lxct.SoLenh 
														and b.Tableid=lxct.Tableid
														and b.NgayXuat=lxct.NgayXuat
														and b.LineID=lxct.LineID
														and b.MaLenh=lxct.MaLenh)
								group by SoLenh, tableid , TyTrong_15,NgayXuat, LineID, MaLenh
								---having count (TyTrong_15)>1
								) abc  group by SoLenh, tableid , NgayXuat, LineID, MaLenh
								having count (TyTrong_15)>1
	OPEN p_CursorTmp  

	FETCH NEXT FROM p_CursorTmp   INTO @p_SoLenh, @p_TableID
						,@p_NgayXuat, @p_LineID, @p_MaLenh,@p_Count

	WHILE @@FETCH_STATUS = 0  	
		begin
		    update   @p_tbllenhxuat_hanghoaE5  set MultiD15 =@p_Count
					where SoLenh=@p_SoLenh and TableID=@p_TableID
						and NgayXuat=@p_NgayXuat and LineID=@p_LineID and MaLenh=@p_MaLenh
			FETCH NEXT FROM p_CursorTmp   INTO @p_SoLenh, @p_TableID, @p_NgayXuat, @p_LineID, @p_MaLenh, @p_Count
		end
	
	CLOSE p_CursorTmp
	DEALLOCATE p_CursorTmp
	
	
	
	
	
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
			)			
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
													,MultiD15 
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
											from  @TableVar1 h, @p_tbllenhxuat_hanghoaE5 h1
												
													where h.solenh=h1.solenh and h.tableid=h1.tableid
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
													,MultiD15  
										) anhqh		
		) abc
		
		--select * from @TableVar22
		--return
		
		update @TableVar22 set NhietDo=NhietDoBQ where isnull(NhietDo_BQGQ,0) <=0
		update @TableVar22 set NhietDo=NhietDo_BQGQ where isnull(NhietDo_BQGQ,0) >0
		
		--update  @TableVar22 set TyTrong=D15_BQGQ where isnull(D15_BQGQ,0) >0 and MultiD15<=
		
		update  @TableVar22 set TyTrong=TyTrong15 where  MultiD15<=1 --isnull(D15_BQGQ,0) <=0 and MultiD15<=1
		update  @TableVar22 set TyTrong=TyTrongBQ where isnull(D15_BQGQ,0) >0 and MultiD15 >1
		
		update @TableVar22 set 			
								  VCF = dbo.zzFPT_mdlQCI_GetVCF_NS (NhietDo,TyTrong)								
							  where vcf =0
		
		
		update @TableVar22 set SluongQC= round (SoLuongDuXuat_Ndo *VCF  ,0), SoLuongThucXuat=SoLuongDuXuat_Ndo
		
		update @TableVar22 set SluongQC= (TyTrong -0.0011) * SluongQC
						where upper( DVT) = 'KG'
		
	---	select * from @TableVar22
	---- return
	
	
		
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
		from  #TableVarTmp 			
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
			from  @TableVar22		
		
END