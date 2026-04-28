USE [HTTG_UAT]
GO
/****** Object:  StoredProcedure [dbo].[KV1_Rpt_TTLenhXuat]    Script Date: 06/22/2020 16:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----exec  [KV1_Rpt_TTLenhXuat_20200622]  '20190901','20190901',NULL,NULL,NULL,NULL,NULL,NULL,null
---- exec  [KV1_Rpt_TTLenhXuat_20200622] '20200604','20200604',Null,'09',Null,Null,Null,Null,'6/4/2020 3:00:00 AM','03:10',NULL,'29C48070'
alter proc [dbo].[KV1_Rpt_TTLenhXuat]	
	@p_FDate date,
	@p_TDate date,
	--@p_Client nvarchar(10),
	@p_MaHangHoa nvarchar(4000),
	--@p_SoCongTo nvarchar(30),
	--@p_BeXuat nvarchar(20),
	@p_MaPhuongThucban nvarchar(4000),  ---Da chuyen sang dung cho MaPhuongThucban
	@p_Nguon nvarchar(10),
	@p_Status char(2), 
	--@p_TimeF datetime,
	--@p_TimeT datetime
	@p_MaKhachHang nvarchar(4000)
	,@p_DiemTraHang nvarchar(1500)
	,@p_TimeF datetime,
	@p_TimeT datetime
	,@p_NhomTD nvarchar(200)
	, @p_MaPhuongTien nvarchar(4000)  -----  Dung lai thong tin Phuong Tien
AS
begin

    declare @p_MaKhachHang22 nvarchar(50)
    
    declare @p_MaKhachHang33 nvarchar(50)
    
    
	declare @p_TenKhachHang nvarchar(1000)
	declare @p_STT numeric(11)	
	declare @p_MaHangHoa11 nvarchar(50)
	
	declare @p_MaHangHoa22 nvarchar(50)
	declare @p_TenHangHoa22 nvarchar(1000)
	declare @p_STT22 numeric(11)		
	
	declare @p_From_MINUTE int
	declare @p_From_Hour int
	----declare @p_From_MINUTE int
	declare @p_To_Hour int
	declare @p_To_MINUTE int
	
		
	set @p_From_Hour= datepart(hour,@p_TimeF)
	set @p_From_MINUTE = datepart(MINUTE ,@p_TimeF)
	set @p_to_Hour= datepart(hour,@p_TimeT)
	set @p_To_MINUTE = datepart(MINUTE ,@p_TimeT)
	
	declare @p_FromDateTime datetime
	declare @p_ToDateTime datetime

	declare @p_TableRowID table  (RowID int)

	
	

	set @p_FromDateTime   =  convert(datetime, CONVERT(char(8),@p_FDate , 112) + ' ' + CONVERT(char(8),@p_TimeF , 108)) 
	
	set @p_ToDateTime   =  convert(datetime, CONVERT(char(8),@p_TDate , 112) + ' ' + CONVERT(char(8),@p_TimeT , 108)) 
	
	--print   convert(datetime, CONVERT(char(8),@p_FDate , 112) + ' ' + CONVERT(char(8),@p_TimeF , 108)) 
	--print  convert(datetime, CONVERT(char(8),@p_TDate , 112) + ' ' + CONVERT(char(8),@p_TimeT , 108)) 
	--return

	insert @p_TableRowID (RowID)
	select Row_ID  from FPT_LenhXuat_TongHop_v  a

	where  	  isnull( a.ThoiGianDau,@p_FromDateTime) >=@p_FromDateTime
			and  isnull( a.ThoiGianDau,@p_ToDateTime) <= @p_ToDateTime	
			and convert(date,ISNULL(NgayTichKe,NgayXuat))>= @p_Fdate
				and convert(date,ISNULL(NgayTichKe,NgayXuat))<= @p_TDate

			--select * from @p_TableRowID
			--return
	--declare @p_FromTime int 
	--set @p_FromTime =  convert(nvarchar(4),	@p_From_Hour ) +  case when LEN(convert(nvarchar(4),@p_From_MINUTE)) =1 then '0' +  convert(nvarchar(4),@p_From_MINUTE)
	--							else convert(nvarchar(4),@p_From_MINUTE) end
	--declare @p_ToTime int
	--set @p_ToTime= convert(nvarchar(4),	@p_To_Hour ) + case when LEN(convert(nvarchar(4),@p_To_MINUTE)) =1 then '0' +  convert(nvarchar(4),@p_To_MINUTE)
	--							else convert(nvarchar(4),@p_To_MINUTE) end
								
	
	declare @v_Table table (
		MaKhachHang nvarchar(10),
		TenKhachHang nvarchar(200),
		MaHangHoa nvarchar(18),
		TenHangHoa nvarchar(40),
		MaPhuongTien nvarchar(10),
		SoLuongDuXuat numeric(18),
		SoLuongThucXuat numeric(18),
		SoLenh nvarchar(10),
		MaNguon nvarchar(10),
		NhietDo decimal(5, 2),
		TyTrong decimal(6, 4),
		[Status] char(2),
		STT2 nvarchar(50)
		,DiemTraHang  nvarchar(500)
		,NgayXuat datetime
	)
	
	insert into @v_Table(
			MaKhachHang,
			TenKhachHang,
			MaHangHoa,
			TenHangHoa,
			MaPhuongTien,
			SoLuongDuXuat,
			SoLuongThucXuat,
			SoLenh,
			MaNguon,
			NhietDo,
			TyTrong,
			[Status]	
			,DiemTraHang
			,NgayXuat
			)	
	select
	tbl1.MaKhachHang,
	tbl1.TenKhachHang,
	tbl1.MaHangHoa,
	tbl1.TenHangHoa,
	tbl1.MaPhuongTien,
	sum(tbl1.SoLuongDuXuat) as SoLuongDuXuat,
	sum(tbl1.SoLuongThucXuat) as SoLuongThucXuat,
	tbl1.SoLenh,
	tbl1.MaNguon,
	
	--0,0,
	--round(sum(NhietDo *  SoLuongThucXuat) / sum(SoLuongThucXuat),2) as NhietDo,
	0 as NhietDo, 
	--avg(convert(decimal(14,5),tbl1.TyTrong_15)) as TyTrong,
	0 as TyTrong,
	tbl1.[Status]
	
	, DiemTraHang
	,NgayXuat
	from (					   
				select
				MaKhachHang,
				TenKhachHang,
				MaHangHoa,
				TenHangHoa,
				MaPhuongTien,
				SoLuongDuXuat,
				SoLuongThucXuat,
				SoLenh,
				MaNguon,
				NhietDo,
				TyTrong_15,
				BeXuat,
				NgayTichKe,
				--NgayXuat,
				[Status]		
				, DiemTraHang
				,convert(date,ISNULL(a.NgayTichKe,a.NgayXuat)) as NgayXuat
				from FPT_LenhXuat_TongHop_v	a
				where 
				convert(date,ISNULL(NgayTichKe,NgayXuat))>= @p_Fdate
				and convert(date,ISNULL(NgayTichKe,NgayXuat))<= @p_TDate 
				
				and 
				CHARINDEX (',' + a.MaHangHoa +',', ',' + ISNULL(@p_MaHangHoa,a.MaHangHoa) + ',' ,1)>0									 
					and CHARINDEX (',' + a.MaPhuongTien +',', ',' + ISNULL(@p_MaPhuongTien,a.MaPhuongTien) + ',' ,1)>0
				and CHARINDEX (',' + a.MaPhuongThucBan +',', ',' + ISNULL(@p_MaPhuongThucban,a.MaPhuongThucBan) + ',' ,1)>0
				and a.MaNguon = ISNULL(@p_Nguon,a.MaNguon)  
				and a.[Status] in ('31','4','5')
				and a.[Status] = ISNULL(@p_Status,a.[Status])				  
			
				and CHARINDEX (',' + a.MaKhachHang +',', ',' + ISNULL(@p_MaKhachHang,a.MaKhachHang) + ',' ,1)>0
				
				and DiemTraHang =isnull(@p_DiemTraHang,a.DiemTraHang) 
				
				and exists (select 1 from @p_TableRowID bb where bb.RowID =a.Row_id )
				--  and   a.ThoiGianDau>=@p_FromDateTime
			--and  a.ThoiGianDau <= @p_ToDateTime	
				
			) tbl1	
			group by tbl1.MaKhachHang, tbl1.TenKhachHang, tbl1.MaHangHoa, tbl1.TenHangHoa,
					 tbl1.MaPhuongTien, tbl1.SoLenh, tbl1.MaNguon, tbl1.[Status], DiemTraHang	
					 ,NgayXuat
			
	
	--return
		
	union all
	
	select
	tbl2.MaKhachHang,
	tbl2.TenKhachHang,
	tbl2.MaHangHoa,
	tbl2.TenHangHoa,
	tbl2.MaPhuongTien,
	sum(tbl2.SoLuongDuXuat),
	sum(tbl2.SoLuongThucXuat),
	tbl2.SoLenh,
	tbl2.MaNguon,
	0 as NhietDo,
	--avg(convert(decimal(14,5),tbl2.TyTrong_15)) as TyTrong,	
	0 as  TyTrong,
	tbl2.[Status]
	, DiemTraHang
	,NgayXuat
	from (	
		select
		MaKhachHang,
		TenKhachHang,
		MaHangHoa,
		TenHangHoa,
		MaPhuongTien,
		SoLuongDuXuat,
		SoLuongThucXuat,
		SoLenh,
		MaNguon,
		NhietDo,
		--(select Dens_nd from FPT_tblTankActive_V where Name_nd = BeXuat and Date1 = convert(date,ISNULL(NgayTichKe,NgayXuat))) as TyTrong_15,
		0 as TyTrong_15,
		BeXuat,
		NgayTichKe,
	--	NgayXuat,
		[Status]
		,DiemTraHang
		,convert(date,ISNULL(a.NgayTichKe,a.NgayXuat)) as NgayXuat
		from FPT_LenhXuat_TongHop_v	a
		where convert(date,ISNULL(a.NgayTichKe,a.NgayXuat))>= @p_Fdate
		and convert(date,ISNULL(a.NgayTichKe,a.NgayXuat))<= @p_TDate 
		
		and CHARINDEX (',' + a.MaHangHoa +',', ',' + ISNULL(@p_MaHangHoa,a.MaHangHoa) + ',' ,1)>0								 
		
		and CHARINDEX (',' + a.MaPhuongTien +',', ',' + ISNULL(@p_MaPhuongTien,a.MaPhuongTien) + ',' ,1)>0
		and CHARINDEX (',' + a.MaPhuongThucBan +',', ',' + ISNULL(@p_MaPhuongThucban,a.MaPhuongThucBan) + ',' ,1)>0
		and a.MaNguon = ISNULL(@p_Nguon,a.MaNguon)  
		and a.[Status] in ('3')
		and a.[Status] = ISNULL(@p_Status,a.[Status])				  
	
		and CHARINDEX (',' + a.MaKhachHang +',', ',' + ISNULL(@p_MaKhachHang,a.MaKhachHang) + ',' ,1)>0
		
		and DiemTraHang =isnull(@p_DiemTraHang,a.DiemTraHang) 
		  -- and   a.ThoiGianDau>=@p_FromDateTime
			--	and  a.ThoiGianDau <= @p_ToDateTime	
			and exists (select 1 from @p_TableRowID bb where bb.RowID =a.Row_id )
		) tbl2	
	group by tbl2.MaKhachHang, tbl2.TenKhachHang, tbl2.MaHangHoa, tbl2.TenHangHoa,
			 tbl2.MaPhuongTien, tbl2.SoLenh, tbl2.MaNguon, tbl2.[Status], DiemTraHang
			 ,NgayXuat
	
	----return
	
	declare  @v_tblTemp2  table(
			MaKhachHang nvarchar(100),
			TenKhachHang nvarchar(1000),
			MaHangHoa nvarchar(100),
			TenHangHoa nvarchar(1000),
			MaPhuongTien nvarchar(100),			
			SoLuongDuXuat numeric(15,2) ,			
			SoLuongThucXuat numeric(15,2),
			SoLenh nvarchar(100),
			MaNguon nvarchar(100),			
			STT numeric(15),
			Status nvarchar(10),
			STT2 numeric(15)--add field to internal table 
			,DiemTraHang nvarchar(1000)
			,NgayXuat datetime
	
		)	 			  
		 			  
	
	------anhqh  20200506  them tieu chis TD
	if isnull(@p_NhomTD,'') <> ''
		begin
			if isnull(@p_NhomTD,'')  ='Y'
				begin
					delete  from  @v_Table  where isnull(Diemtrahang,'')  =''
				end
			else
				if isnull(@p_NhomTD,'')  ='N'
				
						begin
							delete  from  @v_Table  where isnull(Diemtrahang,'')  <> ''
						end
		end
	
	
    DECLARE product_cursor CURSOR FOR   			
		SELECT 
				 -- 0 as STT ,
				  makhachhang, TenKhachHang, MaHangHoa
				  --from (select  MaKhachHang,TenKhachHang, MaHangHoa
			from @v_Table abc  group by MaKhachHang, TenKhachHang, MaHangHoa
    OPEN product_cursor  
    FETCH NEXT FROM product_cursor INTO  @p_makhachhang22, @p_TenKhachHang  ,  @p_MaHangHoa11

   -- IF @@FETCH_STATUS <> 0  
    set  @p_STT=0       
    set @p_MaKhachHang33 ='-999'
	WHILE @@FETCH_STATUS = 0  
	BEGIN  	       
					
					if  @p_MaKhachHang33 <> isnull(@p_makhachhang22,'-999')
						begin
							set  @p_STT=0  
							set @p_MaKhachHang33 =@p_makhachhang22
						end
					set   @p_STT= @p_STT +1
					insert into @v_tblTemp2 (
									MaKhachHang ,
									TenKhachHang ,
									MaHangHoa ,
									TenHangHoa ,
									MaPhuongTien,		
									SoLuongDuXuat ,		
									SoLuongThucXuat ,
									SoLenh ,
									MaNguon ,
									Status ,
									STT2 ,
									DiemTraHang 
									,NgayXuat	)					
						  select  
								MaKhachHang,
								TenKhachHang,
								MaHangHoa,
								TenHangHoa,
								MaPhuongTien,
								SoLuongDuXuat,
								SoLuongThucXuat,
								SoLenh,
								MaNguon,								
								[Status],									
								--@p_STT as STT2,
								--ROW_NUMBER() OVER(Order BY makhachhang,MaHangHoa ASC) AS STT2,
								@p_STT as STT2,
								DiemTrahang,
								NgayXuat
						from @v_Table
							where MaKhachHang =@p_makhachhang22 and MaHangHoa=@p_maHangHoa11	
				
		FETCH NEXT FROM product_cursor INTO   @p_makhachhang22, @p_TenKhachHang    ,  @p_MaHangHoa11
	END  

    CLOSE product_cursor  
    DEALLOCATE product_cursor 		
	
					-- Order BY MaKhachHang, MaHangHoa	   
	DECLARE product_cursor22 CURSOR FOR   			
			SELECT 
					  --ROW_NUMBER() OVER(Order BY MaKhachHang ASC) AS STT,
					  MaKhachHang
					  
				from @v_Table abc  group by MaKhachHang 
	OPEN product_cursor22  
	FETCH NEXT FROM product_cursor22 INTO  @p_makhachhang22   
	
	set @p_STT22=0
	WHILE @@FETCH_STATUS = 0  
	BEGIN  
		set @p_STT22=@p_STT22+1
		update @v_tblTemp2 set STT =@p_STT22 where MaKhachHang=@p_makhachhang22 
		FETCH NEXT FROM product_cursor22 INTO   @p_makhachhang22   
	END  

	CLOSE product_cursor22  
	DEALLOCATE product_cursor22 	
	
	select * from @v_tblTemp2  order by STT,STT2
	
	-- where mahanghoa ='0201042' and makhachhang ='0000101920' order by STT,STT2
end