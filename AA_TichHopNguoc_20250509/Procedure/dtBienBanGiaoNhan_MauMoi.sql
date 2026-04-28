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
alter PROCEDURE dtBienBanGiaoNhan_MauMoi
	@p_SoLenh nvarchar(100)
AS
BEGIN
	create table  #p_table  (
		MaNgan nvarchar(5),
		SoLenh nvarchar(20), 
		MaHangHoa nvarchar(30), 
		TenHangHoa nvarchar(500), 
		BeXuat nvarchar(10), 
		MaLuuLuongKe nvarchar(50), 
		SoHieuNiem nvarchar (300),
		V1_TT decimal(7), 
		NhietDo  decimal(6,2), 
		D15_1 decimal (6,4), 
		VCF1 decimal (6,4), 
		V1_15 decimal (7), 
		WCF1 decimal (6,4), 
		KG1 decimal (7),
		MaEntry nvarchar(30), 
		NhietDo2 decimal (6,2), 
		V2_15 decimal (7),
		VCF2 decimal (6,4)
		)
	declare @p_WareHouse nvarchar(20)
	declare @p_CompanyCode nvarchar(20)
	select @p_WareHouse= WareHouse , @p_CompanyCode= companycode  from tblconfig 
	insert into  #p_table (MaNgan, SoLenh,MaHangHoa,TenHangHoa,BeXuat, MaLuuLuongKe, SoHieuNiem, V1_TT, NhietDo,
		D15_1,VCF1, V1_15,WCF1,KG1,MaEntry ,NhietDo2)
	select a.MaNgan, a.SoLenh, a.MaHangHoa, a.TenHangHoa, a.BeXuat, a.MaLuuLuongKe, convert(nvarchar(500),'') as SoHieuNiem,
		a.SoLuongThucXuat as V1_TT, a.NhietDo as NhietDo1,a.TyTrong_15  as D15, 0.0 as VCF1,
		case when isnull(bb.MaHangHoa ,'')  ='' then  0  else a.GST end as  V1_15, 0.0 as WCF1, 0 as KG1,
		a.MaEntry as HH, (select top 1 NhietDoXe  from tblLenhXuatChiTietE5 c where c.Row_id =a.Row_id  ) as NhietDo2	
		from FPT_tblLenhXuatChiTietE5_V  a  left join tblHangHoaE5 bb on a.MaHangHoa = bb.MaHangHoa  
	where a.SoLenh =@p_SoLenh 

	update #p_table set  NhietDo2 =NhietDo where isnull(Nhietdo2,0) =0
	update  #p_table set  VCF1 =round( V1_15/V1_tt,4), WCF1 = D15_1 -0.0011  where isnull(V1_15,0)  >0 and  isnull(V1_tt,0)>0

	update   #p_table set  VCF1 = [dbo].[zzFPT_mdlQCI_GetVCF_NS] (NhietDo, D15_1),  VCF2 = [dbo].[zzFPT_mdlQCI_GetVCF_NS] (NhietDo2, D15_1)
	update  #p_table set  V1_15 = round(VCF1 * V1_tt,0) , WCF1  = D15_1 -0.0011
				, KG1 = round(( D15_1 -0.0011) * V1_TT ,0) , V2_15 = round(VCF2 * V1_tt,0)
					
			
	select a.*, format ( getdate(), 'HH')  as Gio , format ( getdate(), 'MM') as Phut, format ( getdate(), 'dd/MM/yyyy') as NgayThang,
		(select TenKho   from tblKho  where MaKho =@p_WareHouse ) as TenKho, b.TenDonVi , b.DiaChi , convert(nvarchar(500),'') as CtyCV,
		c.MaPhuongTien , c.NguoiVanChuyen 
		
		--(select TenDonVi  from tblDonvi   where MaDonVi = @p_CompanyCode ) as TenDenVi
	from  #p_table  a, tblDonVi  b, tblLenhXuatE5 c  where b.MaDonVi  = @p_CompanyCode  and a.SoLenh = c.SoLenh  COLLATE database_default


	drop table  #p_table
END
GO
