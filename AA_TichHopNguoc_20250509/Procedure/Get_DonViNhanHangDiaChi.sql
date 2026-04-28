

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[Get_DonViNhanHangDiaChi]
(
	@p_SoLenh nvarchar(100)
)
RETURNS nvarchar(2000)
AS
BEGIN
	declare @p_DiaChi nvarchar(2000)	
	--declare @p_MaDonVi nvarchar(200)
	--declare @p_Inco1 nvarchar(100)
	--declare @p_MaNguon nvarchar(100)
	--declare @p_MaPTB nvarchar(100)
	--declare @p_BSART nvarchar(200)
	--declare @p_POTYPE nvarchar(200)
	--declare @p_MaKhachHang nvarchar(100)
	--declare @p_Warehouse nvarchar(100)


	--set @p_DiaChi =''
	
	--select top 1  @p_Inco1=Inco1, @p_MaNguon=MaNguon 
	--	, @p_MaPTB=MaPhuongThucBan, @p_BSART =BSART, @p_POTYPE =POTYPE, @p_MaDonVi=MaDonVi 
	--		,@p_MaKhachHang =MaKhachHang from tbllenhxuate5 with (nolock) where SoLenh =@p_SoLenh
	
	--select top 1 @p_DiaChi  = isnull(HOUSE_UM,'') + '-' +  isnull(STREET,'')  + '-' +  isnull(CITY,'')
	--				from tblDonvi  where MaDonvi =@p_MaDonVi		

	--if ( ( @p_Inco1 ='CIF' and @p_MaNguon ='N30' ) or  (@p_MaNguon ='N05'  and @p_MaPTB in ('05','06') )  )  --NBN co TD
	--	begin 
	--		 select @p_DiaChi =isnulL(Diachi ,'') + '-VN'  from tblKhachHang  where MaKhachHang = @p_MaKhachHang	
	--	end
	--declare @p_TenDonVi nvarchar(2000)	
	declare @p_MaDonVi nvarchar(200)
	declare @p_Inco1 nvarchar(100)
	declare @p_MaNguon nvarchar(100)
	declare @p_MaPTB nvarchar(100)
	declare @p_BSART nvarchar(200)
	declare @p_POTYPE nvarchar(200)
	declare @p_KHoNhap nvarchar(100)
	declare @p_Warehouse nvarchar(100)
	declare @p_MaKhachhang nvarchar(100)

	set @p_DiaChi =''
	select top 1 @p_Warehouse =WareHouse from tblConfig
	select top 1  @p_Inco1=Inco1, @p_MaNguon=MaNguon 
		, @p_MaPTB=MaPhuongThucBan, @p_BSART =BSART, @p_POTYPE =POTYPE, @p_KHoNhap =MaKhoNhap
			, @p_MaKhachhang =MaKhachHang from tbllenhxuate5 with (nolock) where SoLenh =@p_SoLenh
	
	---Truong hop khac
	select top 1 @p_MaDonVi =MaDonvi from tblKho  where Makho =@p_KHoNhap
	select top 1 @p_DiaChi  = isnull(HOUSE_UM,'') + '-' +  isnull(STREET,'')  + '-' +  isnull(CITY,'')
					from tblDonvi  where MaDonvi =@p_MaDonVi		

	if ( @p_BSART in ('P222', 'P223')  or @p_POTYPE  in ('P222', 'P223'))    --Company code tương ứng với plant cửa hàng  (tblLenhxuatE5-Makhonhap(3) + '0')
			begin 
				set @p_MaDonVi =left( @p_KHoNhap,3)  + '0'
				select top 1 @p_DiaChi  = isnull(HOUSE_UM,'') + '-' +  isnull(STREET,'')  + '-' +  isnull(CITY,'')
						from tblDonvi  where MaDonvi =@p_MaDonVi		
			end
	
	if ( @p_Inco1 ='CIF' and @p_MaNguon ='N30' ) or  (@p_MaNguon ='N05'  and @p_MaPTB in ('05','06') and (substring(@p_MaKhachHang,5,1) <> '8' )  )  --NBN co TD
		begin 
			select top 1 @p_DiaChi= Diachi + '-VN'  from  tblKhachhang where MaKhachHang = @p_MaKhachHang				
		end
	if (@p_MaNguon ='N05'  and @p_MaPTB in ('05','06') and substring(@p_MaKhachHang,5,1) = '8' ) --KHNN
			begin 
				select top 1 @p_DiaChi= Diachi  from  tblKhachhang where MaKhachHang = @p_MaKhachHang				
			end
	RETURN @p_DiaChi

END
GO

