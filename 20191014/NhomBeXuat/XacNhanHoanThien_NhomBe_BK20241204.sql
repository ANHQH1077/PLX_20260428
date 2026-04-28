

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

	
	select  @p_Approved = NhomBeApp  from tblLenhXuatE5  with (nolock) where solenh  = @p_SoLenh
	
	
	
	set @p_String22 = (	select 
					b.BeXuatTDH + ','
					--, b.NhomBeXuat 
					from  tblLenhXuate5 a , FPT_tblLenhXuatChiTietE5_V b 
						where a.SoLenh =b.SoLenh  and  a.SoLenh  =@p_SoLenh 
								and not  exists (select 1 from  FPT_tblTankActive_v b1 where isnull(Tank_App,'') ='Y' 
											and Date1=CONVERT(date,getdate ()) 	and b1.Name_nd=isnull( b.BeXuatTDH,'')  )
							for XML PATH(''))	
	
    if isnull(@p_String22,'') <> ''
		begin
			set @p_String22 =SUBSTRING (@p_String22,1,len(@p_String22)-1)
			set @p_String22  = N'Bể xuất TĐH: ' + @p_String22 + N' chưa được khai báo theo ngày!'
			--insert into @p_Table (sDesc) Values (@p_String)
		end

	--insert into @p_Table (sDesc) 
	declare @p_YesNo nvarchar(2)

	set @p_YesNo = (select KeyValue   from  [dbo].[SYS_CONFIG] where upper(KeyCode)  = 'TANK_GROUP_YESNO')

	set @p_String = (	select 
					b.BeXuatTDH + ','
					--, b.NhomBeXuat 
					from  tblLenhXuate5 a , FPT_tblLenhXuatChiTietE5_V b 
						where a.SoLenh =b.SoLenh  and  a.SoLenh  =@p_SoLenh 
								and (isnull(a.NhomBeXuat,'') <> isnull(b.NhomBeXuatTDH,'')
								or  not exists  (select 1 from tblLenhXuat_HangHoaE5  kk with (nolock) where kk.SoLenh = b.SoLenh  and isnull(kk.BeXuat,'') = isnull(b.BeXuatTDH,'') )
										)
								--and isnull(a.NhomBeXuat,'') <> isnull(b.NhomBeXuatTDH,'')
								--and not exists  (select 1 from tblLenhXuat_HangHoaE5  kk with (nolock) where kk.SoLenh = b.SoLenh  and kk.BeXuat = b.BeXuatTDH )
							for XML PATH(''))
	
	if isnull(@p_String,'') <> ''
		begin
			set @p_String =SUBSTRING (@p_String,1,len(@p_String)-1)
			set @p_String  = N'Bể xuất TĐH: ' + @p_String + N' không đúng với nhóm bể được khai báo trên lệnh xuất!'
			--insert into @p_Table (sDesc) Values (@p_String)
		end
	set @p_String11 =''
	set @p_String11 = (select 
					isnull(MaLuuLuongKe,'') + '-' +  isnull(b.BeXuatTDH,'.') + ','
					--, b.NhomBeXuat 
					from  tblLenhXuate5 a , FPT_tblLenhXuatChiTietE5_V b 
						where a.SoLenh =b.SoLenh  and  a.SoLenh  =@p_SoLenh
							--and isnull(a.NhomBeXuat,'') <> isnull(b.NhomBeXuatTDH,'')
							and not exists  (select 1 from [dbo].[tblCongToNhomBe_Hist]  c1 where isnull(c1.sType,'') <> 'D' and isnull(c1.MeterId,'')= isnull(b.MaLuuLuongKe ,'')
										and isnull(c1.Bexuat,'') = isnull(b.BeXuatTDH ,'')  and isnull(c1.TankGroup,'')   = isnull(b.NhomBeXuatTDH,'') 
										and b.ThoiGianDau >= isnull(c1.Valid_from ,b.ThoiGianDau) and b.ThoiGianDau < = isnull(c1.Valid_to ,b.ThoiGianDau)	)
							for XML PATH(''))
	if isnull(@p_String11,'') <> ''
		begin
			set @p_String11 =SUBSTRING (@p_String11,1,len(@p_String11)-1)
			set @p_String11  =  @p_String11 + N': bể xuất và công tơ không đúng với danh mục.'
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
