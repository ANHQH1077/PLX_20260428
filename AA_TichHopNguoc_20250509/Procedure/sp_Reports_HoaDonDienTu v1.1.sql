

----   LTT/L15/Nhiệt độ/VCF/WCF/D15: 99/97/33,14/0,9846/0,8437/0,8448
  --- Exec  [sp_Reports_HoaDonDienTu]  '2023765389', 'sysadin','12345678','HDTX_VN', 1
  --  Exec  [sp_Reports_HoaDonDienTu]  '2023765312', 'sysadmin','20KMPGQ4','GTGT',0
-----  Exec  [sp_Reports_HoaDonDienTu]  '662AA01157', 'sysadmin','20Q303A2','GTGT_VCNB',0
ALTER PROCEDURE [dbo].[sp_Reports_HoaDonDienTu]
		@SoLenh	NVARCHAR (10)
		,@p_CreateUser nvarchar(200)
		,@p_MaTraCuu nvarchar(50)
		,@p_LoaiCT as nvarchar(20)
		,@p_ViewHD int =0
AS
begin
	---TaoKeyCho Hoa Don
	declare @p_SQL nvarchar(max)
	declare  @p_Return table (KeyCode nvarchar(200))
	declare @p_KeyCode nvarchar(50)
	declare @p_LoaiVanChuyen nvarchar(50)
	declare @p_TongTien decimal(18,2)
	declare @p_HHH nvarchar (500)
	
	declare @TenDonVi nvarchar(3000)
	declare @DiaChi nvarchar(3000)
	declare @DiaChiFull nvarchar(3000)
	declare @MaSoThue nvarchar(300)
	declare @p_NgayGioXuatKho datetime	
	declare @p_VatRate decimal(10)		
	declare @p_Pattern nvarchar(200)
	declare @p_NgayHD date
	declare @p_Serial nvarchar(200)
	declare @p_Cty_Ext nvarchar(100) =''
	declare @p_Remark nvarchar(500)=N'Nhiệt độ TT/LTT/L15/D15/VCF/WCF: '    -----N'LTT/L15/Nhiệt độ/VCF/WCF/D15: '		
	declare @p_CamKet nvarchar(2000) =N'Doanh nghiệp chúng tôi cam kết lô hàng đạt chất lượng, phù hợp TCCS đã công bố.'
	declare @p_LoaiTien nvarchar(10) ='VND'
	declare @tblKyHieu table (Pattern nvarchar(200)
								,Serial nvarchar(200), KyHieuKLT nvarchar(200))
	declare @p_SoHoaDon nvarchar(200)
	declare @p_MSTBenBan nvarchar(200)
	declare @p_MaxTimeEnd nvarchar(10)
	declare @p_NgayGioHoaDon datetime	
	declare @p_ThongTinBoSung nvarchar(2000)
	declare @p_MaNguon nvarchar(200)
	declare @p_Inco1 nvarchar(100)
	---declare @p_MaNguon nvarchar(100)
	declare @p_Warehouse nvarchar(100)

	declare @p_CompanyCode nvarchar(100)
	declare @p_SoLenhDO1 nvarchar(100)



	declare @p_ChietKhauDesc nvarchar(200) =N'Chiết khấu thương mại:'
	if @p_LoaiCT ='HDTX_VN'
		begin
			set @p_LoaiTien ='USD'
		end
	--if @p_LoaiCT ='GTGT_VCNB'
	--	begin
	--		set @p_Cty_Ext ='VP '
	--	end
	
	select top 1 @p_Warehouse =WareHouse from tblConfig 

	select top 1 @p_MaxTimeEnd =KeyValue  from SYS_CONFIG  where upper(keyCode )= upper('MaxTimeEnd')
	if isnull(@p_MaxTimeEnd,'') =''
		begin
			set @p_MaxTimeEnd ='N'
		end
		  --Do1 chuyen thagn
	select top 1  @p_Inco1=Inco1, @p_MaNguon=MaNguon ,@p_SoLenhDO1 =isnull(DO1_SoLenh,'')
		   from tbllenhxuate5 with (nolock) where SoLenh =@SoLenh	

		   ----======================== FOB chuyen thang ========================================

	if isnull(@p_SoLenhDO1,'') <> ''  and   @p_LoaiCT ='GTGT' 
		begin
			Exec  [sp_Reports_HoaDonDienTu_DO1]  @SoLenh,@p_CreateUser,@p_MaTraCuu,'GTGT',0
			return
		end
		-----Truong hop DO1 cho tai xuat  ========================================
	select top 1  @p_SoLenhDO1 ='AA'
		   from tbllenhxuate5 with (nolock) where SoLenh =@SoLenh	and Inco1='CIF' and MaNguon ='N05'
	if isnull(@p_SoLenhDO1,'') <> ''  and   @p_LoaiCT ='HDTX_VN' 
		begin
			Exec  [sp_Reports_HoaDonDienTu_DO1_TX]  @SoLenh,@p_CreateUser,@p_MaTraCuu,'HDTX_VN',0
			return
		end


	select top 1 @p_CompanyCode=CompanyCode  from tblConfig
	select top 1 @p_MSTBenBan = MaSoThue from tblDonVi  where MaDonVi  =@p_CompanyCode    ---- in (select CompanyCode from tblConfig)
	select top 1 @p_NgayHD = dtNgayHoaDon, @p_SoHoaDon =txtSoHoaDon from tblChungTu  	where SoLenh =@SoLenh    and   LoaiChungTu =@p_LoaiCT 


	------Lấy lại @p_CompanyCode cho DO1 nếu có
	insert into @tblKyHieu (Pattern, Serial , KyHieuKLT )
		exec MauSo_KyHieuHoaDon @p_LoaiCT, @p_NgayHD, @p_CompanyCode

	select top 1 @p_Pattern= Pattern, @p_Serial= Serial  from  @tblKyHieu
		declare @TblHangHoa table(SoLenh nvarchar(20)
								, TableID nvarchar(200)
								, LineID nvarchar(20)
								,MaHangHoa nvarchar(100)
								,TenHangHoa nvarchar(2000)
								, DonViTinh  nvarchar(10)
								,TongDuXuat decimal(18,2)
								, TongThucXuat decimal(18,2)
								,L15  decimal(18,2)
								,KG  decimal(18,2)
								,VCF  decimal(6,4)
								,WCF decimal(6,4)
								,NhietDo  decimal(8,2)
								,TyTrong  decimal(6,4)
								,DonGia decimal(18,6)
								,TongTIen decimal(18,2)
								,ChietKhau decimal(18,4)
								, sTongThucXuat nvarchar(50)
								,sL15  nvarchar(50)
								,sKG  nvarchar(50)
								,sVCF nvarchar(50)
								,sWCF nvarchar(50)
								,sNhietDo  nvarchar(50)
								,sTyTrong   nvarchar(50)	
								,Remark nvarchar(1500)		
								, VatAmount decimal(18,6)
								,VatRate decimal(3),
								Total decimal(18,6)
			)
	
	select top 1 @p_KeyCode= KeyCode from tblChungTu where SoLenh =@SoLenh	  and   LoaiChungTu =@p_LoaiCT		

	insert into  @TblHangHoa ( SoLenh,TableID, LineID,MaHangHoa,TenHangHoa,
				 DonViTinh,L15,KG ,VCF,WCF,NhietDo,TyTrong, DonGia ,TongDuXuat, TongThucXuat, ChietKhau )	
	SELECT  lxhh.SoLenh, TableID, LineID, MaHangHoa,TenHangHoa,DonViTinh, L15, KG, VCF, WCF
			, NhietDo, TyTrong
			,case when LoaiTien='VND' then round(case when  @p_LoaiCT ='GTGT_VCNB'  then 0 else DonGia end ,0)
				else   case when  @p_LoaiCT ='GTGT_VCNB'  then 0 else DonGia end    end  as DonGia
			 , SoLuongThucXuat,case when isnull(lxhh.SoGhiNhan,0) =0 then SoLuongThucXuat else  SoLuong end  as SoLuongThucXuat, lxhh.ChietKhau
				--,h.txtThueGTGT   ----, (isnull(h.txtThueGTGT,0)/100) * (isnull(DonGia,0) - (isnull(lxhh.ChietKhau,0) /100)) *  (case when isnull(lxhh.SoGhiNhan,0) =0 then SoLuongThucXuat else  SoLuong end ) 
			  from  tblChungTuLine AS lxhh	, tblChungTu h
		WHERE lxhh.SoLenh=@SoLenh  and h.SoLenh = lxhh.solenh  
				and h.LoaiChungTu = lxhh.LoaiChungTu
				and  h.LoaiChungTu =@p_LoaiCT
				order by lxhh.MaHangHoa;
		

		

	update @TblHangHoa set  TongTien =round((isnull(DonGia,0)  - (isnull(DonGia,0)* (isnull(ChietKhau,0) /100)))
				* case when DonViTinh ='L' then TongThucXuat 
							else
								case when DonViTinh='KG' then
									KG
								else
									L15
								end
							 end
							
							 
							 ,2)

	--Table 1 Invoices
	
	set @p_VatRate =(select top 1 txtThueGTGT from tblChungTu where soLenh =@SoLenh  and   LoaiChungTu =@p_LoaiCT) 
	
	set @p_VatRate=isnull(@p_VatRate,0)

	update @TblHangHoa set VatRate = @p_VatRate, VatAmount = (@p_VatRate/100) * TongTIen, Total =  (@p_VatRate/100) * TongTIen + isnull(TongTien,0)


	select top 1  @TenDonVi=TenDonVi,@DiaChi=  DiaChi,@DiaChiFull= DiaChiFull, @MaSoThue= MaSoThue from tblDonVi  
			where  MaDonVi in (select ComPaNyCode from tblConfig)
	

	declare @p_LenhXuatE5 table (SoLenh nvarchar(50)
					,NgayXuat datetime
					,MaKhachHang nvarchar(200)
					,DiemTraHang nvarchar(2000)					
					,SoHopDong nvarchar(200)
					,NgayHopDong Datetime
					, MaKho nvarchar(200)
					,TenKho nvarchar(2000)
					,MaPhuongTien nvarchar(100)
					,NguoiVanChuyen nvarchar(500)
					,Niem nvarchar(2000)
					,LoaiPhieu nvarchar(200)
					,LXLoai nvarchar(100)
					,LXPhieu nvarchar(100)
					,SOType nvarchar(500)
					,Inco1 nvarchar(200)
					,Dischargepoint nvarchar(200)
					,MaNguon nvarchar(100)
					,POType nvarchar(500)
					,BSART nvarchar(500)
					,DiemTraHangTmp nvarchar(2000)		
					, HTTG nvarchar(10)	
					,MaTuyenDuong nvarchar(200)
					,MaPhuongThucBan nvarchar(100)
					----,LoaiPhieu nvarchar(100)
					)

	insert into @p_LenhXuatE5 (SoLenh,NgayXuat,MaKhachHang,----- DiemTraHang,
			 SoHopDong, NgayHopDong, MaKho, TenKho, MaPhuongTien ,NguoiVanChuyen, Niem,
				 LoaiPhieu, LXLoai, LXPhieu, SOType, Inco1, Dischargepoint, MaNguon, POType, BSART, HTTG
				 ,MaTuyenDuong, MaPhuongThucBan )
	select SoLenh,NgayXuat,MaKhachHang 		
			--,case when isnull(Dischargepoint,'') = '' then
			--	(select top 1 DGDiemDen from tblGiaoNhan  where  maTuyenDuong =a1.DiemTraHang)
			--			else
			--				(select top 1 DGDiemDen from tblGiaoNhan  where  Diemden =a1.Dischargepoint)	
			--			end 
			--			as   DiemTraHang
				, SoHopDong, NgayHopDong ,
				 MaKho, (Select  TenKho from tblKho where MaKho =a1.Makho) as TenKho
				, MaPhuongTien ,NguoiVanChuyen, Niem, a1.LoaiPhieu,
				----case when isnumeric(a1.LoaiPhieu) <> 0 then convert(nvarchar(20), convert(numeric,a1.LoaiPhieu) ) else '' end as LoaiPhieu, 
				 a1.LXLoai, a1.LXPhieu,
				 SOType, Inco1, Dischargepoint,MaNguon, POType, BSART, HTTG, MaTuyenDuong, MaPhuongThucBan
		from tblLenhXuate5 a1 with (nolock) where a1.SoLenh =@SoLenh
--	begin try
		update  @p_LenhXuatE5  set  LoaiPhieu = case when isnumeric(LoaiPhieu) <> 0 then convert(nvarchar(20), convert(numeric,LoaiPhieu) ) else '' end
--	end try

--	begin catch

--	end catch
	/* anhqh 20200424  phieu VCNB
	Cap nhat lai Diem tra hang 
-	Di chuyển Tập đoàn có TD: POtype = “P250” or  BSART = ‘P250’  Kho nhập = Điểm trả hàng = Diễn giải điểm đến của Ma tuyến đường (2023764792)  
	=> chưa lên điểm trả hàng, kho nhập lấy sai     GDDienDen
-	Di chuyển nội bộ TĐ không TD: POtype = “P251”  or  BSART = ‘P251’     Điểm trả hàng để trống, Kho nhập =  (tblLenhxuatE5-Makhonhap)
-	Di chuyển cửa hàng: POtype = “P222” ”  or  BSART = ‘P222’      Kho nhập = Điểm trả hàng = Dischargepoint (2023764808) GDDienDen
-	Các TH khác kho nhập và điểm trả hàng để trống

	*/
	
	

	if @p_LoaiCT ='GTGT_VCNB'
		begin
			-----  update veef nulll
			update @p_LenhXuatE5  set DiemTraHang =null where isnull(  POtype ,'') not in ( 'P250','P222') and isnull(HTTG,'') ='Y'
			update @p_LenhXuatE5  set DiemTraHang =null where  isnull( BSART ,'')  not in ( 'P250','P222') and isnull(HTTG,'') <>'Y'
			----Update lai điểm trả hàng

		--	select * from tblGiaoNhan
			update @p_LenhXuatE5  set DiemTraHang = (select top 1 DGDiemDen from tblGiaoNhan where MaTuyenDuong =[@p_LenhXuatE5].MaTuyenDuong)  
								where isnull(  POtype ,'')  in ( 'P250')  or isnull( BSART ,'')  in ( 'P250')

			update @p_LenhXuatE5  set DiemTraHang = (select top 1 DGDiemDen from tblGiaoNhan where DiemDen =[@p_LenhXuatE5].Dischargepoint)  
								where isnull(  POtype ,'')  in ( 'P222')  or isnull( BSART ,'')  in ( 'P222')
		end

		--anhqh 20200507
	if  @p_LoaiCT ='GTGT' 
		begin			
			update @p_LenhXuatE5  set DiemTraHang = (select top 1 TenKho from  tblKho  where MaKho=@p_WareHouse)     where   MaNguon='N35'
		end

	

	select @p_TongTien =sum(total) from  @TblHangHoa

	
	--select @p_TongTien =sum(TongTIen)-isnull(sum(ChietKhau),0) from  @TblHangHoa
	set @p_TongTien =isnull(@p_TongTien,0)
	
	if @p_MaxTimeEnd ='Y'
		begin
			set @p_NgayGioHoaDon =(select Max(ThoiGianCuoi) FROM fpt_tblLenhXuatChiTietE5_v  where  solenh =@SoLenh )
			set @p_NgayGioXuatKho =  @p_NgayGioHoaDon
		end
	else
		begin
			set @p_NgayGioHoaDon =(select Min(ThoiGianDau) FROM fpt_tblLenhXuatChiTietE5_v  where  solenh =@SoLenh )
				set @p_NgayGioXuatKho =  @p_NgayGioHoaDon
		end
		
	set @p_HHH =(SELECT STUFF((SELECT ',' + 'H'+ MaNgan+ ':'+convert(varchar(10),MaEntry)
					FROM fpt_tblLenhXuatChiTietE5_v  where  solenh =@SoLenh 
						order by MaNgan
        FOR XML PATH('')) ,1,1,'') )

	if len(isnull(@p_HHH,'')) >0
		begin
			set @p_HHH ='H' + right(@p_HHH,len(@p_HHH)-1)
		end

	update @TblHangHoa  set  	 sTongThucXuat  =REPLACE ( replace (convert(varchar(15),convert(money,TongThucXuat),1),'.00',''),',','.') 
							,sL15   =REPLACE ( replace (convert(varchar(15),convert(money,L15),1),'.00',''),',','.') 
							,sKG  =REPLACE ( replace (convert(varchar(15),convert(money,KG),1),'.00',''),',','.') 
							,sVCF = replace( convert(varchar(15),convert(money,VCF),2),'.',',')
							,sWCF  = replace( convert(varchar(15),convert(money,WCF),2),'.',',')
							,sNhietDo =replace( convert(varchar(15),convert(money,NhietDo),1),'.',',')
							,sTyTrong  = replace( convert(varchar(15),convert(money,TyTrong),2),'.',',')
	
	update  	 tblChungTu set TienThueGTGT =case when @p_LoaiTien ='USD' then round( @p_TongTien*( isnull(@p_VatRate,0)/100),2)
												else  round( @p_TongTien*( isnull(@p_VatRate,0)/100),0) end
			--, TongTienTruocThue =@p_TongTien , TongTienSauThue  =round( @p_TongTien*( isnull(@p_VatRate,0)/100),2)  + @p_TongTien
						 where SoLenh =@SoLenh    and   LoaiChungTu =@p_LoaiCT 
	update  	 tblChungTu set TongTienTruocThue =@p_TongTien , TongTienSauThue  =TienThueGTGT  + @p_TongTien
						 where SoLenh =@SoLenh    and   LoaiChungTu =@p_LoaiCT 
	-------Cap nhat Remark
	if @p_LoaiCT ='GTGT_VCNB'
		begin

			---	if DonViTinh ='L'
				set @p_Remark =N'L15/Kg/to/D15/VCF/WCF ' 		
				update @TblHangHoa set Remark =  @p_Remark +  sL15  +'/'+ sKG +'/'  + sNhietDo +'/'   + sTyTrong  +'/'  + sVCF +'/' + sWCF  where DonViTInh ='L'
						---	if DonViTinh ='KG'
				set  @p_Remark =N'Nhiệt độ TT/LTT/L15/D15/VCF/WCF: '			
				update @TblHangHoa set Remark = @p_Remark +  sNhietDo +'/' + sTongThucXuat +'/' + sL15  +'/'  + sTyTrong  +'/'  + sVCF +'/' + sWCF   where DonViTinh ='KG'
						

				

				set @p_Remark =N'LTT/Kg/to/D15/VCF/WCF ' 		
				update @TblHangHoa set Remark =  @p_Remark +  sTongThucXuat  +'/'+ sKG +'/'  + sNhietDo +'/'   + sTyTrong  +'/'  + sVCF +'/' + sWCF  where DonViTInh ='L15'

				

			if @p_Inco1 ='CIF' and @p_MaNguon ='N30'
				begin
					set @p_Remark =N'Nhiệt độ TT/L15/KG/D15/VCF/WCF: '  ----N'L15/Kg/to/D15/VCF/WCF ' 		
					update @TblHangHoa set Remark =  @p_Remark + sNhietDo +'/' + sL15  +'/'+ sKG +'/'    + sTyTrong  +'/'  + sVCF +'/' + sWCF  where DonViTInh ='L'
							---	if DonViTinh ='KG'
					set  @p_Remark =N'Nhiệt độ TT/LTT/L15/D15/VCF/WCF: '			
					update @TblHangHoa set Remark = @p_Remark +  sNhietDo +'/' + sTongThucXuat +'/' + sL15  +'/'  + sTyTrong  +'/'  + sVCF +'/' + sWCF   where DonViTinh ='KG'

					set @p_Remark =N'Nhiệt độ TT/Ltt/KG/D15/VCF/WCF: '  ----N'L15/Kg/to/D15/VCF/WCF ' 		
					update @TblHangHoa set Remark =  @p_Remark + sNhietDo +'/' + sTongThucXuat  +'/'+ sKG +'/'    + sTyTrong  +'/'  + sVCF +'/' + sWCF  where DonViTInh ='L15'
						
				end
			
			

		end


		

	if @p_LoaiCT ='GTGT'
		begin

			---if DonViTinh ='L'
				
					set  @p_Remark =N'Nhiệt độ TT/L15/KG/D15/VCF/WCF: '			
					update @TblHangHoa set Remark = @p_Remark +  sNhietDo +'/' + sL15  +'/'  + sKG +'/'  + sTyTrong  +'/'  + sVCF +'/' + sWCF   where DonViTinh ='L'
							
				
			---if DonViTinh ='KG'
				
					set  @p_Remark =N'Nhiệt độ TT/LTT/L15/D15/VCF/WCF: '			
					update @TblHangHoa set Remark = @p_Remark +  sNhietDo +'/' + sTongThucXuat +'/' + sL15  +'/'  + sTyTrong  +'/'  + sVCF +'/' + sWCF   where DonViTinh ='KG'
						
				
			----if DonViTinh ='L15'
				--begin
					set  @p_Remark =N'Nhiệt độ TT/LTT/KG/D15/VCF/WCF: '			
					update @TblHangHoa set Remark = @p_Remark +  sNhietDo +'/' + sTongThucXuat +'/' + sKG  +'/'  + sTyTrong  +'/'  + sVCF +'/' + sWCF    where DonViTinh ='L15'
						
				---end
		end
	if @p_LoaiCT ='HDTX_VN'
		begin
			set  @p_Remark =N'LTT/L15/Nhiệt độ/VCF/WCF/D15: '
			 update @TblHangHoa set Remark = @p_Remark + sTongThucXuat +'/'+ sL15  +'/'+  sNhietDo +'/'  + sVCF +'/' + sWCF+'/'    + sTyTrong   
				
		end	
	
	
	/*
	20200819
	anhqh
	sua truong hop tai xuat thi Vatrate =-1

	*/
	if @p_LoaiCT ='HDTX_VN'  
		begin
			set @p_VatRate =-1
		end


	select @p_MaTraCuu  as  [Key]   -- @p_KeyCode as [Key];
	select right( aa2.MaKhachHang ,6) as CusCode, --aa1.txtNguoiMuaHang as CusName, 
			case when isnull(case when isnull( txtMaSoThue,'') <> '' then txtMaSoThue else	txtMST2 end,'') <> '' then
				case when  isnull(aa1.txtDonViMuaHang ,'') <> '' then aa1.txtDonViMuaHang   else  txtDonViNhanHang  end 
			else null end as  CusName, 
			--case when  isnull(aa1.txtDonViMuaHang ,'') <> '' then aa1.txtDonViMuaHang   else  txtDonViNhanHang  end as Buyer
			case when isnull(case when isnull( txtMaSoThue,'') <> '' then txtMaSoThue else	txtMST2 end,'') ='' then aa1.txtNguoiMuaHang else null end as Buyer
			,case when isnull(aa1.txtDiChiDonViMuaHang,'') <> '' then aa1.txtDiChiDonViMuaHang else txtDiaChiDonViNhanHang end as CusAddress
			,  null as CusPhone
			, case when isnull( txtMaSoThue,'') <> '' then txtMaSoThue else	txtMST2 end as CusTaxCode, 
			case when  isnull(txtPhuongThuc,'') <> '' then txtPhuongThuc else '' end as PaymentMethod , null  as KindOfService, 
			null as CusBankNo,
			(select sum(TongTien) from @tblHangHoa) as Total , @p_VatRate as VATRate, (select sum(VatAmount ) from @tblHangHoa) as VATAmount
			, isnull((select sum(TongTien) from @tblHangHoa),0) + isnull( (select sum(VatAmount ) from @tblHangHoa) ,0) as Amount,
				convert(nvarchar(2000), '' ) as  AmountInWords, aa1.sdesc as Extra		
			,convert(nvarchaR(50),isnull( aa1.dtNgayHoaDon,dtNgayXuat) ,103)  +  ' ' + convert(nvarchaR(50),isnull( aa1.dtNgayHoaDon,dtNgayXuat) ,108)  as ArisingDate
			--,convert(nvarchaR(50),isnull( aa1.dtNgayHoaDon,dtNgayXuat) ,103)    as ArisingDate
			, null as PayMentStatus
			, null as GrossValue, null as GrossValue0, null as VATAmount0, null as GrossValue5, null as VATAmount5
			,null as  GrossValue10,null as  VATAmount10, null as  GrossValue_NonTax, @p_LoaiTien as CurrencyUnit,
			txtDonViBanHang as DonVibanHang, txtDiaChiDonViBanHang as DiaChiBanHang,  aa2.DiemTraHang as  CuaHangSo	
				, txtSoHopDong as  SoHopDong,  convert(nvarchaR(50), aa1.txtNgayHopDong ,103)       as NgayHopDong		
				
				
				,  case when @p_MaNguon ='N35' then  
					(select top 1 TenKho from tblKho where MaKho=@p_Warehouse)
					  else  aa2.DiemTraHang end as  DiemGiaoHang 			
				
				,case when  @p_LoaiCT ='HDTX_VN'  then txtDiemNhanHang else  aa2.DiemTraHang end as  DiemNhanHang
				,TextBox2 as  DaiLy, TextBox1 DiaChiDaiLy, null as TienPhiKhac, SoVanDon, convert(nvarchaR(50),NgayVanDon ,103)  as  NgayVanDon
				,txtThoiHanThanhToan as ThoiHanThanhToan, TenKho as KhoXuat, MaPhuongTien as  SoPhuongTien
				, case when convert(decimal(18,2), isnull(txtTygia,'0')) >0.0 then 
							--txtTygia 
						 --replace(convert(varchar,cast(floor(txtTygia) as money),1),'.00',
							--		 '.'+right(cast(txtTygia * 10000 +10000.5 as int),3))
							convert(decimal(10,3),txtTygia)
							else null end as TyGiaHoachToan						
				,case when isnull(txtDonViCungCapVanTai,'') <> '' then txtDonViCungCapVanTai else txtDonViCCVanTai end as DonViCungCapVanTai	
				,case when (ISNULL(LoaiPhieu,'0') ='V144') or (@p_LoaiCT ='GTGT' and  ISNULL(LoaiPhieu,'0') <> 'V144') then ''
							 else   
								----anhqh 2020506 bo sung dieu kien cho VCNB
							  ---LoaiPhieu
									case when ( ( Inco1 ='CIF' and MaNguon ='N30')  or  ( Inco1 ='CIF' and MaNguon ='N05' )
													or  ( MaPhuongThucBan in ('05','06') and MaNguon ='N05'   ) )  and  @p_LoaiCT ='GTGT_VCNB'  
									then LoaiPhieu 
										else '' 
									end
							 end as MaTimKiem
				,NguoiVanChuyen as NguoiVanTai  , @p_HHH as KhoangCachTamMuc, Niem as SoNiem 
				,txtToKhaiHQ as SoToKhaiHaiQuanNhap,txtSoTK as SoToKhaiHaiQuanXuat, 
				N'TẬP ĐOÀN XĂNG DẦU VIỆT NAM' as ComParentName
				,null as ComParentTaxCode,
				
				  null as ThongTinBoSung
				
				
				,null  as ThoiGian  ---===================================
				,null as EInvoiceType, txtSoLenh as LenhDieuDongSo, convert (varchar(10),aa1.dtpDieuDong,103)   DieuDongNgay,
				case when upper(left(txtCompany,2)) ='VP' then txtCompany else  @p_Cty_Ext + txtCompany end DonViDieuDong,
					aa1.txtKhoNhap as  KhoNhap,null NoteHuy,null NoteBienBan, null Extra2,'' as ComParentAddress
				,txtDonViGiaoHang DonViGiaoHang,txtDonViNhanHang DonViNhanHang,
				txtDiaChiDonViGiaoHang DiaChiGiaoHang,txtDiaChiDonViNhanHang DiaChiNhanHang			
				,convert(nvarchaR(50), @p_NgayGioXuatKho ,103)  + ' ' +  convert(nvarchaR(50), @p_NgayGioXuatKho ,108)   as NgayGioXuatKho
				,@p_CamKet as CamKet,null SMS, 'ABC@Petrolimex.com.vn' as  Mail, Null as Status
		from tblChungTu aa1 with (nolock) , @p_LenhXuatE5 aa2 
			where aa1.SoLenh =aa2.SoLenh    and   aa1.LoaiChungTu =@p_LoaiCT ;
	
	declare @p_XML nvarchar(max)
	set @p_XML =''
	select 0 as Products_Id  ,0 as Invocie_Id , '<?xml version="1.0" encoding="UTF-8"?>' as VerXML, @p_XML  as XML2;

	if isnull(@p_ViewHD,0) =0    ---Dữ liệu tích hợp cho HDDT
		begin  
			select MaHangHoa as Code,TenHangHoa as  ProdName,DonViTinh   as  ProdUnit
				----,TongThucXuat  as ProdQuantity,
				,case when DonViTinh ='L' then TongThucXuat 
								else
									case when DonViTinh='KG' then
										KG
									else
										L15
									end
									end    as ProdQuantity
										
				,	DonGia  as ProdPrice		
					,  Remark
					, VatRate  as VATRate,  TongTien as  Total,	VatAmount  as VatAmount	,   total as Amount
					, case when isnull(CHietKHau,0) >0 then @p_ChietKhauDesc  else '' end as zzDesc
					, Isnull(ChietKhau,0) as zzChietKhau
				from @TblHangHoa ;
				select  @p_Pattern as  Pattern, @p_Serial as Serial, @p_SoHoaDon as SoHoaDon, @p_MSTBenBan as MST;
		end
	else    -----Dữ liệu dùng cho hiển thị HDDT
		begin
			select MaHangHoa as Code,TenHangHoa as  ProdName,DonViTinh   as  ProdUnit
				----,TongThucXuat  as ProdQuantity,
				,case when DonViTinh ='L' then TongThucXuat 
								else
									case when DonViTinh='KG' then
										KG
									else
										L15
									end
									end    as ProdQuantity
										
				,	DonGia  as ProdPrice		
					,  Remark
					, VatRate  as VATRate,  TongTien as  Total,	VatAmount  as VatAmount	,   total as Amount
					,sTongThucXuat ,sL15, sNhietDo ,sVCF, sWCF,sTyTrong  
					, case when isnull(CHietKHau,0) >0 then @p_ChietKhauDesc  else '' end as zzDesc
					, Isnull(ChietKhau,0) as zzChietKhau
				from @TblHangHoa ;
				select  @p_Pattern as  Pattern, @p_Serial as Serial, @p_SoHoaDon as SoHoaDon, @p_MSTBenBan as MST;
		end

		select  N'TẬP ĐOÀN XĂNG DẦU VIỆT NAM' as ParentName ,
				case when isnull(TenDonViHD,'') <> '' then TenDonViHD else TenDonVi  end TenDonVi				
				, DiaChi, MaSoThue, 
				DiaChiFull,  getdate()as sDate
				, N'Đ/C: ' + case when isnull(DiaChiHD,'') <> '' then DiaChiHD else DiaChiFull end DiaChiHD
								, N'Giờ: ' + Convert(varchar(8),@p_NgayGioHoaDon ,114) + N' Ngày: ' + Convert(nvarchar(20),@p_NgayGioHoaDon ,103) as sGio from tblDonvi 
							  where MaDonVi in (select CompanyCode from tblConfig);


	--	select @p_Remark
		--return

end


				----select * from tblChungTuLine

				----alter table tblChungTu add CreateDate
GO


