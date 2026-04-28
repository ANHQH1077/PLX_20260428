

  --- Exec  [sp_Reports_TaoHoaDonDienTu]  '2023763790', 'sysadin','', 'GTGT'
CREATE PROCEDURE [dbo].[sp_Reports_TaoHoaDonDienTu]
		@SoLenh	NVARCHAR (10)
		,@p_CreateUser nvarchar(200)
		,@p_KeyCodeIn nvarchar(50)
		,@p_LoaiCT as nvarchar(20)
AS
begin
	---TaoKeyCho Hoa Don
	declare @p_SQL nvarchar(max)
	declare  @p_Return table (KeyCode nvarchar(200))
	declare @p_KeyCode nvarchar(50)
	declare @p_LoaiVanChuyen nvarchar(50)
	declare @p_XITEC_OPTION nvarchar(50)
	
	declare @TONGDUXUAT nvarchar(10)
	declare @TONGDUXUATTHUY nvarchar(10)
	declare @p_Count int
	select  @TONGDUXUAT =KeyValue  from sys_config where  keycode ='TONGDUXUAT'
	select  @TONGDUXUATTHUY =  KeyValue from sys_config where  keycode ='TONGDUXUATTHUY'

	declare @p_Inco1 nvarchar(100)
	declare @p_MaNguon nvarchar(100)
	declare @p_MaPhuongThucBan nvarchar(100)
	declare @tblDO_Item_Material table (SoLenh nvarchar(200)
					,LineID nvarchar(100)
					,DonGia decimal(18,6)
					,Currency nvarchar(10)
						)
	declare @p_SoLenhDO1 nvarchar(100)


	

	select top 1 @p_XITEC_OPTION = XITEC_OPTION, @p_LoaiVanChuyen = dbo.FPT_GetLoadingSite(MaVanChuyen) 
		, @p_Inco1=Inco1, @p_MaNguon=MaNguon, @p_MaPhuongThucBan =MaPhuongThucBan ,@p_SoLenhDO1 =isnull(DO1_SoLenh,'')
	from tblLenhXuatE5 with(nolock) where SoLenh= @SoLenh
		
	if  (isnull(@p_SoLenhDO1,'')  <> ''  and @p_LoaiCT ='GTGT' ) 
		or (@p_LoaiCT ='HDTX_VN' and @p_Inco1='CIF' and @p_MaNguon ='N05') 
		begin
			set @p_SoLenhDO1 =@SoLenh
			insert into @tblDO_Item_Material  (SoLenh,LineID ,DonGia ,Currency)
				select SoLenh,right( replicate('0',10) + convert(nvarchar(10),LineID) ,6)  ,DonGia 
				,CurrencyKey  from  tblDO_Item_Material  where SoLenh =@p_SoLenhDO1
		end


		
	select @p_Count =Count(*) from tblChungTuLine where SoLenh =@SoLenh  and LoaiChungTu =@p_LoaiCT 
	if isnull(@p_Count,0) >0
		begin
			return
		end
	
		----======================================================
	declare @TblHangHoa table(SoLenh nvarchar(20)
							, TableID nvarchar(200)
							, LineID nvarchar(20)
							,MaHangHoa nvarchar(100)
							,TenHangHoa nvarchar(2000)
							, DonViTinh  nvarchar(10)
							,SoLuongDuXuat decimal(18,2)
							, SoLuongThucXuat decimal(18,2)
							,L15  decimal(18,2)
							,KG  decimal(18,2)
							,VCF  decimal(6,4)
							,WCF decimal(6,4)
							,NhietDo  decimal(8,2)
							,TyTrong  decimal(6,4)
							,DonGia decimal(18,6)
							,TongTIen decimal(18,2), KeyCode nvarchar(50)
							,MaVanChuyen nvarchar(50)
							,XITEC_OPTION nvarchar(50)
							,ChietKhau decimal(18,6)
							,NgayXuat datetime
							,MaLenh nvarchar(10)
							,LoaiTien nvarchar(20)	
							,SoLuong  decimal(18,2)	 					
	)
	

	if ( isnull(@p_SoLenhDO1,'')  <> '' and @p_LoaiCT ='GTGT') 
			or (@p_LoaiCT ='HDTX_VN' and @p_Inco1='CIF' and @p_MaNguon ='N05')  -------Lay thong tin  DO1
		begin
			insert into  @TblHangHoa ( SoLenh,TableID, LineID,MaHangHoa,TenHangHoa, DonViTinh,L15,KG 
						,VCF,WCF,NhietDo,TyTrong, DonGia , MaVanChuyen, XITEC_OPTION ,
						 NgayXuat,MaLenh, KeyCode, ChietKhau , LoaiTien)	
			SELECT SoLenh, TableID, LineID, MaHangHoa,TenHangHoa,DonViTinh, L15, KG, VCF, WCF
					, NhietDo_BQGQ, D15_BQGQ
					, isnull((select top 1 DonGia from @tblDO_Item_Material k  where k.SoLenh =lxhh.SoLenh and k.LineID =lxhh.LineID),0) as  DonGia
					,@p_LoaiVanChuyen, @p_XITEC_OPTION , NgayXuat,MaLenh, @p_KeyCodeIn
								,isnull(ChietKhau,0)  as ChietKhau, CurrencyKey from  fpt_tblLenhXuat_HangHoaE5_new_v AS lxhh	
				WHERE lxhh.SoLenh=@SoLenh  order by lxhh.MaHangHoa;
		end 
	else
		begin
			insert into  @TblHangHoa ( SoLenh,TableID, LineID,MaHangHoa,TenHangHoa, DonViTinh,L15,KG 
							,VCF,WCF,NhietDo,TyTrong, DonGia , MaVanChuyen, XITEC_OPTION ,
							 NgayXuat,MaLenh, KeyCode, ChietKhau , LoaiTien)	
			SELECT SoLenh, TableID, LineID, MaHangHoa,TenHangHoa,DonViTinh, L15, KG, VCF, WCF
					, NhietDo_BQGQ, D15_BQGQ,DonGia,@p_LoaiVanChuyen, @p_XITEC_OPTION , NgayXuat,MaLenh, @p_KeyCodeIn
								,isnull(ChietKhau,0)  as ChietKhau, CurrencyKey from  fpt_tblLenhXuat_HangHoaE5_new_v AS lxhh	
				WHERE lxhh.SoLenh=@SoLenh  order by lxhh.MaHangHoa;
		end

	update @TblHangHoa set SoLuongThucXuat =
					(select sum(SoLuongThucXuat) from fpt_tblLenhXuatChiTietE5_V 
										where SoLenh =[@TblHangHoa].SoLenh  and MahangHoa= [@TblHangHoa].MaHangHoa)
	update @TblHangHoa set SoLuongDuXuat =
					(select sum(SoLuongDuXuat) from fpt_tblLenhXuatChiTietE5_V 
										where SoLenh =[@TblHangHoa].SoLenh  and MahangHoa= [@TblHangHoa].MaHangHoa)
										

										


	if @TONGDUXUAT ='1'    --Lay du xuat
		begin
			update @TblHangHoa set 				
				SoLuongThucXuat  =   case when isnull(XITEC_OPTION,'') ='Y' then SoLuongThucXuat else   SoLuongDuXuat end 
				,SoLuongDuXuat =  case when isnull(XITEC_OPTION,'') ='Y' then SoLuongThucXuat else   SoLuongDuXuat end 
					where MaVanChuyen ='BO'
			--where   dbo.FPT_GetLoadingSite(MavanChuyen)='BO'
		end
	else       --Laytheo thu xuats
		begin
				update @TblHangHoa set 				
				SoLuongThucXuat  =   case when isnull(XITEC_OPTION,'') ='Y' then SoLuongDuXuat else   SoLuongThucXuat end 
				,SoLuongDuXuat =  case when isnull(XITEC_OPTION,'') ='Y' then SoLuongDuXuat else   SoLuongThucXuat end   
					where MaVanChuyen ='BO'
				--where   dbo.FPT_GetLoadingSite(MavanChuyen)='BO'
		end
	if @TONGDUXUATTHUY ='1'    --Lay du xuat
		begin
			update @TblHangHoa set 				
				SoLuongThucXuat  =   case when isnull(XITEC_OPTION,'') ='Y' then SoLuongThucXuat else   SoLuongDuXuat end 
				,SoLuongDuXuat =  case when isnull(XITEC_OPTION,'') ='Y' then SoLuongThucXuat else   SoLuongDuXuat end 
					where MaVanChuyen ='THUY'
			--where   dbo.FPT_GetLoadingSite(MavanChuyen)='BO'
		end
	else       --Laytheo thu xuats
		begin
				update @TblHangHoa set 				
				SoLuongThucXuat  =   case when isnull(XITEC_OPTION,'') ='Y' then SoLuongDuXuat else   SoLuongThucXuat end 
				,SoLuongDuXuat =  case when isnull(XITEC_OPTION,'') ='Y' then SoLuongDuXuat else   SoLuongThucXuat end   
					where MaVanChuyen ='THUY'
				--where   dbo.FPT_GetLoadingSite(MavanChuyen)='BO'
		end

	update @TblHangHoa set SoLuong  = case when DonViTinh ='L' 
										then 
											SoLuongThucXuat
										else case when DonViTinh ='L15' 
													then 
														L15													
													else case when DonViTinh ='KG' 
														then 
															KG													
														else 
															SoLuongThucXuat	
														end		
													
													end										
										end
										
	
		
	update @TblHangHoa set  TongTIen =isnull(DonGia,0) * isnull(SoLuong,0) 
	


	----delete from tblChungTuLine where SoLenh =@SoLenh
	
	INSERT INTO [dbo].[tblChungTuLine]
           ([SoLenh],[TableID],[LineID],[MaHangHoa],[TenHangHoa] ,[DonViTinh]
           ,[SoLuongDuXuat],[SoLuongThucXuat],[L15],[KG],[VCF],[WCF] ,[NhietDo]
           ,[TyTrong] ,[DonGia],[TongTIen],[KeyCode] ,[MaVanChuyen],[XITEC_OPTION]
           ,[ChietKhau] ,[NgayXuat] ,[MaLenh],[LoaiTien], SoLuong, LoaiChungTu)
    select [SoLenh],[TableID],[LineID],[MaHangHoa],
			case when  ( ( @p_Inco1 ='CIF' and @p_MaNguon ='N30' )  or (@p_Inco1 ='CIF' and @p_MaNguon ='N05')  
					or (@p_MaPhuongThucBan in ('05','06')  and @p_MaNguon ='N05' ) )   and  @p_LoaiCT ='GTGT_VCNB'  then
					--CIF noi dia va Tai xuat N05
				MaHangHoa + ' ' + TenhangHoa
			else  
				TenHangHoa  end  as [TenHangHoa] ,[DonViTinh]
           ,[SoLuongDuXuat],[SoLuongThucXuat],[L15],[KG],[VCF],[WCF] ,[NhietDo]
           ,[TyTrong] ,[DonGia],[TongTIen],[KeyCode] ,[MaVanChuyen],[XITEC_OPTION]
           ,[ChietKhau] ,[NgayXuat] ,[MaLenh],[LoaiTien], SoLuong, @p_LoaiCT as LoaiChungTu
           from @TblHangHoa

		--(select sum(SoLuongThucXuat) from fpt_tblLenhXuatChiTietE5_V 
		--									where SoLenh =[@TblHangHoa].SoLenh  and MahangHoa= [@TblHangHoa].MaHangHoa)

	--select  @p_KeyCode as [Key] , 0 as Inv_Id;


	--select 0 as Products_Id  ,0 as Invocie_Id ;
	
end
GO

