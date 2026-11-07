-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
alter PROCEDURE FPT_ChungChiPhuongTien  
	@p_CertNo nvarchar(100)=null,
	@p_FormRequestCode nvarchar(100)=null,
	@p_SoTichKe nvarchar(10) = null,
	@p_NgayXuat nvarchar(10) = null
AS
BEGIN
	declare @pSoLo nvarchar(100)
	declare @p_0C varchar(10) = '°C'
	declare @p_NgayGioXepHang datetime
	declare @p_HienTruong nvarchar(100)
	declare @p_SDA_Amount as decimal(20,4)
	declare @p_NgayXuat1 date
	declare @p_SoTichKe1 nvarchar(100)
	declare @p_MaHangHoa varchar(10)='0101002'
	declare @p_TenHangHoa nvarchar(100)
	declare @p_PhuongTien nvarchar(100)
	declare @p_TankCode varchar(10)
	declare @p_MaNgan varchar(200)

	select top 1 @p_TenHangHoa = TenHangHoa from tblHangHoa where maHangHoa = @p_MaHangHoa
	select  @p_PhuongTien= MaPhuongTien, @p_SoTichKe1= SoTichKe, @p_NgayXuat1= NgayXuat,@p_TankCode=SoBon, @pSoLo = BatNum, @p_SDA_Amount = SDA_Amount 
		from  tblPhuongTien_Cert where CertNo = case when isnull(@p_CertNo,'') ='' then CertNo else @p_CertNo end
			and SoTichKe = case when isnull(@p_SoTichKe,'') ='' then SoTichKe else @p_SoTichKe end
			and NgayXuat = case when isnull(@p_NgayXuat,'') ='' then NgayXuat else @p_NgayXuat end
			and FormRequestCode = case when isnull(@p_FormRequestCode,'') ='' then FormRequestCode else @p_FormRequestCode end
	if isnull(@p_SoTichKe1,'') <> ''
		begin
			select @p_NgayGioXepHang = min(kk.ThoiGianDau) from FPT_tblLenhXuatChiTietE5_V kk where kk.NgayXuat=NgayXuat and
				solenh in (select SoLenh from tblTichke hh where hh.SoTichKe = @p_SoTichKe1 and hh.NgayTichKe =@p_NgayXuat1)
					and kk.MaHangHoa = @p_MaHangHoa
		end
	 SELECT @p_MaNgan= STRING_AGG(replace(MaNgan,'0',''), ',') WITHIN GROUP (ORDER BY replace(MaNgan,'0','') ASC) 
			FROM  FPT_tblLenhXuatChiTietE5_V kk where kk.NgayXuat=NgayXuat and
				solenh in (select SoLenh from tblTichke hh where hh.SoTichKe = @p_SoTichKe1 and hh.NgayTichKe =@p_NgayXuat1)
					and kk.MaHangHoa = @p_MaHangHoa
	
 --  --Ngan1,Ngan2,Ngan3,Ngan4,Ngan5,getdate() as NgayIn,HienTruong, SDA_Amount
	--select @pSoLo= BatchNum, @p_SDA_Amount = isnull(SDA_Amount,0)  from ztblTankBatchs where   
	--	TankCode in (select Name_nd from tblTank where Map_Sap =@p_TankCode and Product_nd = @p_MaHangHoa) and  CreateDate =isnull( (
	--	select max(CreateDate) as CreateDate from ztblTankBatchs where   TankCode in (select Name_nd from tblTank where Map_Sap =@p_TankCode and Product_nd = @p_MaHangHoa)
	--			and CreateDate <= getdate()),'2000-01-01 07:58:01.227')


	select @p_PhuongTien as MaPhuongTien, MaNgan from  FPT_tblLenhXuatChiTietE5_V kk where kk.NgayXuat=NgayXuat and
				solenh in (select SoLenh from tblTichke hh where hh.SoTichKe = @p_SoTichKe1 and hh.NgayTichKe =@p_NgayXuat1)
					and kk.MaHangHoa = @p_MaHangHoa 	 
	select 
		 CertNo, MaPhuongTien, SoTichKe, NgayXuat,FormRequestCode, TiTrong,DoDanDien, NhietDo,
		MauSacSayBolt,KiemTraBenNgoai,KhoXuat,FromRequestDate,@p_TenHangHoa as MaHangHoa,SoBon,NiemGiao,IsTankSplit,
		TiTrongTren, TiTrongGiua,TiTrongDuoi,FormRequestCodeSeperationLayer,FormRequestDateSeperationLayer,
		@pSoLo as SoLo,@p_NgayGioXepHang as NgayGioXepHang, convert(nvarchar(20),'') as  Ngan1,convert(nvarchar(20),'') as Ngan2,
		convert(nvarchar(20),'') as Ngan3,convert(nvarchar(20),'') as Ngan4,convert(nvarchar(20),'') as Ngan5,getdate() as NgayIn,
		DoDanDien + N' tại ' + NhietDo + ' ' + @p_0C as HienTruong, @p_SDA_Amount as SDA_Amount, @p_MaNgan as DS_MaNgan
	from  tblPhuongTien_Cert where CertNo = case when isnull(@p_CertNo,'') ='' then CertNo else @p_CertNo end
			and SoTichKe = case when isnull(@p_SoTichKe,'') ='' then SoTichKe else @p_SoTichKe end
			and NgayXuat = case when isnull(@p_NgayXuat,'') ='' then NgayXuat else @p_NgayXuat end
			and FormRequestCode = case when isnull(@p_FormRequestCode,'') ='' then FormRequestCode else @p_FormRequestCode end
END
GO
