

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[XacNhanHoanThien_NhomBe] 
	@p_SoLenh nvarchar(100)
AS
BEGIN
	declare @p_Table table (sDesc nvarchar(1500))
	declare @p_String nvarchar(1500) =''
	declare @p_String11 nvarchar(1500) =''

	declare @p_String22 nvarchar(1500) =''

	declare @p_Approved nvarchar(10)='N'
	declare @p_NhomBe nvarchar(10)

	select @p_NhomBe =NhomBeXuat   from tblLenhXuate5 where solenh =@p_SoLenh 
			--=Kiem tra theo be xuat dau ngay
	set @p_String22 = (
			select 
											isnull(MaLuuLuongKe,'')  + ','
											--, b.NhomBeXuat 
											from  tblLenhXuate5 aa ,(select SoLenh, BeXuat, MaLuuLuongKe,Min(ThoiGianDau) as ThoiGianDau from FPT_tblLenhXuatChiTietE5_V where SoLenh  = @p_SoLenh
																	 group by SoLenh, BeXuat, MaLuuLuongKe )	b 
												where aa.SoLenh =b.SoLenh  and  aa.SoLenh  = @p_SoLenh							
														and    exists  (select 1 from [dbo].[tblCongToNhomBe_TDH]  c1 where isnull(c1.MeterId,'')= b.MaLuuLuongKe 									
										
																	and  c1.IDLINE in ( select IDLine   from  [tblCongToNhomBe_TDH] c22 where isnull(c22.MeterId,'')= b.MaLuuLuongKe 
																		 and c22.Valid_from  = 
																			(select max(Valid_from) as Valid_from from tblCongToNhomBe_TDH  aa2
																					where Valid_from <=   b.ThoiGianDau
																					and meterid = c22.meterid   --and aa2.TankGroup = c1.TankGroup  and aa2.Bexuat  =  c1.Bexuat 
																							)  
																	and c1.Bexuat = b.BeXuat )											
																	)
												and  not  exists (select 1 from  FPT_tblTankActive_v b1 where isnull(Tank_App,'') ='Y' 
															and Date1=CONVERT(date,getdate ()) 	and b1.Name_nd=isnull( b.BeXuat,'')  )
													for XML PATH('')
			--select 
			--		isnull(b.BeXuat ,'')  + ','
			--		--, b.NhomBeXuat 
			--		from  tblLenhXuate5 aa ,(select SoLenh, BeXuat, MaLuuLuongKe,Min(ThoiGianDau) as ThoiGianDau from FPT_tblLenhXuatChiTietE5_V where SoLenh  =@p_SoLenh
			--								 group by SoLenh, BeXuat, MaLuuLuongKe )	b 
			--			where aa.SoLenh =b.SoLenh  and  aa.SoLenh  =@p_SoLenh
							
			--				and  exists  (select 1 from [dbo].[tblCongToNhomBe_TDH]  c1 where isnull(c1.MeterId,'')= isnull(b.MaLuuLuongKe ,'')
			--							and isnull(c1.Bexuat,'') = isnull(b.BeXuat  ,'')	
			--							and c1.IDLINE  in (select a.IDLINE   from  tblCongToNhomBe_TDH a where a.TankGroup = @p_NhomBe  and  meterid = c1.meterid and a.Valid_from = 
			--										(select max(Valid_from) as Valid_from from tblCongToNhomBe_TDH  aa2
			--												where Valid_from <= b.ThoiGianDau and meterid = c1.meterid  and aa2.TankGroup = a.TankGroup )   )									
										
			--							)

			--					and not  exists (select 1 from  FPT_tblTankActive_v b1 where isnull(Tank_App,'') ='Y' 
			--								and Date1=CONVERT(date,getdate ()) 	and b1.Name_nd=isnull( b.BeXuat,'')  )

			--				for XML PATH('')
							
							
							)

    if isnull(@p_String22,'') <> ''
		begin
			set @p_String22 =SUBSTRING (@p_String22,1,len(@p_String22)-1)
			set @p_String22  = N'Bể xuất TĐH: ' + @p_String22 + N' chưa được khai báo theo ngày!'
			--insert into @p_Table (sDesc) Values (@p_String)
		end

	--insert into @p_Table (sDesc) 
	declare @p_YesNo nvarchar(2)='N'
	   --truong hop khong doi be  ================================================================
	set @p_String11 =''
	set @p_String11 = (
				select 
					isnull(MaLuuLuongKe,'')  + ','
					--, b.NhomBeXuat 
					from  tblLenhXuate5 aa ,(select SoLenh, BeXuat, MaLuuLuongKe,Min(ThoiGianDau) as ThoiGianDau from FPT_tblLenhXuatChiTietE5_V where SoLenh  =@p_SoLenh  
											 group by SoLenh, BeXuat, MaLuuLuongKe )	b 
						where aa.SoLenh =b.SoLenh  and  aa.SoLenh  =@p_SoLenh  						
								and not  exists  (select 1 from [dbo].[tblCongToNhomBe_TDH]  c1 where isnull(c1.MeterId,'')= b.MaLuuLuongKe 									
										
											and  c1.IDLINE in ( select IDLine   from  [tblCongToNhomBe_TDH] c22 where isnull(c22.MeterId,'')= isnull(c1.MeterId,'') 
												 and c22.Valid_from  = 
													(select max(Valid_from) as Valid_from from tblCongToNhomBe_TDH  aa2
															where Valid_from <=   b.ThoiGianDau
															and meterid = c22.meterid   --and aa2.TankGroup = c1.TankGroup  and aa2.Bexuat  =  c1.Bexuat 
																	)  
											and c1.Bexuat = b.BeXuat )											
											)
							for XML PATH('')
			
				--select 
				--	isnull(MaLuuLuongKe,'')  + ','
				--	--, b.NhomBeXuat 
				--	from  tblLenhXuate5 aa ,(select SoLenh, BeXuat, MaLuuLuongKe,Min(ThoiGianDau) as ThoiGianDau from FPT_tblLenhXuatChiTietE5_V where SoLenh  =@p_SoLenh 
				--							 group by SoLenh, BeXuat, MaLuuLuongKe )	b 
				--		where aa.SoLenh =b.SoLenh  and  aa.SoLenh  =@p_SoLenh 
							
				--			and not exists  (select 1 from [dbo].[tblCongToNhomBe_TDH]  c1 where isnull(c1.MeterId,'')= isnull(b.MaLuuLuongKe ,'')
				--						--and isnull(c1.Bexuat,'') = isnull(b.BeXuat  ,'')  		
				--						and c1.IDLINE  in (select a.IDLINE   from  tblCongToNhomBe_TDH a where a.TankGroup = aa.NhomBeXuat   and  meterid = c1.meterid and a.Valid_from = 
				--									(select max(Valid_from) as Valid_from from tblCongToNhomBe_TDH  aa2
				--											where Valid_from <= b.ThoiGianDau and meterid = c1.meterid  and aa2.TankGroup = a.TankGroup  and aa2.Bexuat = a.Bexuat   and Bexuat = b.BeXuat)  and a.Bexuat = b.BeXuat   )
				--											)
				--							--)
				--			for XML PATH('')
							
							
							)
				--- truong hop doi be=======================================================
	set @p_String =''
	set @p_String = (
			select 
					isnull(MaLuuLuongKe,'')  + ','
					--, b.NhomBeXuat 
					from  tblLenhXuate5 aa ,(select SoLenh, BeXuat, MaLuuLuongKe,Min(ThoiGianDau) as ThoiGianDau from FPT_tblLenhXuatChiTietE5_V where SoLenh  =@p_SoLenh  
											 group by SoLenh, BeXuat, MaLuuLuongKe )	b 
						where aa.SoLenh =b.SoLenh  and  aa.SoLenh  =@p_SoLenh  						
								and   exists  (select 1 from [dbo].[tblCongToNhomBe_TDH]  c1 where isnull(c1.MeterId,'')= b.MaLuuLuongKe 									
										
											and  c1.IDLINE in ( select IDLine   from  [tblCongToNhomBe_TDH] c22 where isnull(c22.MeterId,'')= isnull(c1.MeterId,'') 
												 and c22.Valid_from  = 
													(select max(Valid_from) as Valid_from from tblCongToNhomBe_TDH  aa2
															where Valid_from <=   b.ThoiGianDau
															and meterid = c22.meterid   --and aa2.TankGroup = c1.TankGroup  and aa2.Bexuat  =  c1.Bexuat 
																	)  
											and c1.Bexuat <> b.BeXuat )											
											)
							for XML PATH('')
			--select 
			--		isnull(MaLuuLuongKe,'')  + ','
			--		--, b.NhomBeXuat 
			--		from  tblLenhXuate5 aa ,(select SoLenh, BeXuat, MaLuuLuongKe,Min(ThoiGianDau) as ThoiGianDau from FPT_tblLenhXuatChiTietE5_V where SoLenh  =@p_SoLenh  	
			--								 group by SoLenh, BeXuat, MaLuuLuongKe )	b 
			--			where aa.SoLenh =b.SoLenh  and  aa.SoLenh  = @p_SoLenh  							
			--					and  exists  (select 1 from [dbo].[tblCongToNhomBe_TDH]  c1 where isnull(c1.MeterId,'')= b.MaLuuLuongKe 									
			--							and c1.Valid_from  = 
			--										(select max(Valid_from) as Valid_from from tblCongToNhomBe_TDH  aa2
			--												where Valid_from <=  b.ThoiGianDau
			--												and meterid = c1.meterid   --and aa2.TankGroup = c1.TankGroup  and aa2.Bexuat  =  c1.Bexuat 
			--														)  
			--								and c1.Bexuat <>  b.BeXuat 
			--								)
			--				for XML PATH('')
		)

	if isnull(@p_String11,'') <> ''
		begin
			set @p_String11 =SUBSTRING (@p_String11,1,len(@p_String11)-1)
			set @p_String11  =  @p_String11 + N': Công tơ-Bể xuất không có trong danh mục.'
			--insert into @p_Table (sDesc) Values (@p_String)
		end
	if isnull(@p_String,'') <> ''
		begin
			set @p_String =SUBSTRING (@p_String,1,len(@p_String)-1)
			set @p_String  =  @p_String + N': Công tơ-Bể xuất không đúng với bể xuất trên danh mục.'
			--insert into @p_Table (sDesc) Values (@p_String)
		end
	set @p_String =isnull(@p_String,'')
	set @p_String11 =isnull(@p_String11,'')
	set @p_String22 =isnull(@p_String22,'')
	if isnull(@p_String,'') <> '' or isnull( @p_String11,'') <> '' or isnull(@p_String22,'') <> ''
		begin
			set @p_String =@p_String  + char(13) + char(10) + @p_String11 + char(13) + char(10) + @p_String22
			insert into @p_Table (sDesc) Values (@p_String)
		end

	
	if isnull(@p_Approved,'')  ='Y'
	
		begin
			exec CapNhatThongTin_NhomBe  @p_SoLenh
			select 0 nError,  '' from @p_Table  where 1=0
			return
		end
	else
		begin
			if isnull(@p_YesNo,'') ='Y'
				begin
		
					select 0 nError,  sDesc + char(13) + char(10) + N'Bạn có muốn tiếp tục không?' from @p_Table 
				end
			else
				begin
					select 1 nError,  sDesc from @p_Table 
				end
		end

		--select isnull(@p_String,'') , isnull( @p_String11,'') 
END
