
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[Get_DonViGiaoHangDiaChi]
(
	@p_SoLenh nvarchar(100)
)
RETURNS nvarchar(2000)
AS
BEGIN
	declare @p_DiaChi nvarchar(2000)	
	declare @p_MaDonVi nvarchar(200)
	declare @p_Inco1 nvarchar(100)
	declare @p_MaNguon nvarchar(100)
	declare @p_MaPTB nvarchar(100)
	declare @p_BSART nvarchar(200)
	declare @p_POTYPE nvarchar(200)

	declare @p_Warehouse nvarchar(100)


	set @p_DiaChi =''
	
	select top 1 @p_Warehouse =WareHouse from tblConfig
	select top 1  @p_Inco1=Inco1, @p_MaNguon=MaNguon 
		, @p_MaPTB=MaPhuongThucBan, @p_BSART =BSART, @p_POTYPE =POTYPE, @p_MaDonVi=MaDonVi from tbllenhxuate5 with (nolock) where SoLenh =@p_SoLenh
	
	select top 1 @p_DiaChi  = isnull(HOUSE_UM,'') + '-' +  isnull(STREET,'')  + '-' +  isnull(CITY,'')
					from tblDonvi  where MaDonvi =@p_MaDonVi		

	if ( ( @p_Inco1 ='CIF' and @p_MaNguon ='N30' ) or  (@p_MaNguon ='N05'  and @p_MaPTB in ('05','06') )  )  --NBN co TD
		begin 
			select top 1 @p_DiaChi  = isnull(HOUSE_UM,'') + '-' +  isnull(STREET,'')  + '-' +  isnull(CITY,'') + '-' + isnull(Country,'')
					from tblDonvi  where MaDonvi =@p_MaDonVi				
		end
	if (@p_POTYPE  in ( 'P222') or  @p_BSART in ('P222'))    --Company code tương ứng với plant xuất (tblConfig-warehouse(3) + '0')
			begin 
				set @p_MaDonVi =left( @p_Warehouse ,3)  + '0'
				select top 1 @p_DiaChi  = isnull(HOUSE_UM,'') + ' ' +  isnull(STREET,'')  + '-' +  isnull(CITY,'') 
						from tblDonvi  where MaDonvi =@p_MaDonVi				
			end

	RETURN @p_DiaChi

END
GO

