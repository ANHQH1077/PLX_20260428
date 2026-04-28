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
-- Author:		anhqh
-- Create date: 20191014
-- Description:T Ham lay du lieu cho Bien ban giao nhan
-- =============================================
alter PROCEDURE dtBienBanGiaoNhan
	@p_SoLenh as nvarchar(100)
AS
BEGIN

	declare @p_BienSo nvarchar (100)
	declare @p_NguoiVanChuyen nvarchar(500)

	declare @p_MaSoNiem nvarchar (500)
	declare @p_TongSoNiem nvarchar(500)

	declare @p_Table table (SoLenh nvarchar(100))


	declare @p_TableLine table (SoLenh nvarchar(100)
								, MaHangHoa nvarchar(100)
								,SoThucXuat decimal(18,0)
								,SoDuXuat decimal(18,0)
								,HongXuat nvarchar(100)
					)

	declare @p_TableLenhXuat table (SoLenh nvarchar(100)
								, MaKhach nvarchar(500)
								, TenKhachHang nvarchar(2000)
								, MaPhuongTien nvarchar(100)
								, NguoiVanChuyen nvarchar(500)
								, DiemTraHang nvarchar(2000)
			)
	Insert into @p_Table  (SoLenh )
	select Distinct SoLenh from tblTichke a where  exists 
		(select 1   from tblTichKe  b where SoLenh =@p_SoLenh and a.SoTichKe =b.SoTichKe and  a.NgayTichKe =b.NgayTichKe )


	insert into @p_TableLenhXuat  (SoLenh
								, MaKhach
								, TenKhachHang
								, MaPhuongTien
								, NguoiVanChuyen
								,DiemTraHang)	
	select  SoLenh, MaKhachHang, TenKhachHang, MaPhuongTien, NguoiVanChuyen, DiemTraHang from fpt_tbllenhxuate5_v
			 where SoLenh in (select SoLenh from @p_Table)

	
	select  top 1 @p_BienSo = MaPhuongTien, @p_NguoiVanChuyen = NguoiVanChuyen from @p_TableLenhXuat where SoLenh=@p_SoLenh
	

	

	insert into @p_TableLine (SoLenh 
								, MaHangHoa 
								,SoThucXuat 
								,SoDuXuat 
								,HongXuat )
	select SoLenh, MaHangHoa,SoLuongThucXuat, SoLuongDuXuat, MaLuuLuongKe 
			 from fpt_tblLenhXuatChiTietE5_v where SoLenh in (select SoLenh from @p_Table ) 

	
	-------Noi Dung So 1
	select '..../..../2019/PLXKV2-BBGN' as SoBienBan, getdate() as TimePrint,MaDonVi, TenDonVi, DiaChi, DiaChiFull, MaSoThue  from tblDonvi  where 
								MaDonVi in (select warehouse  from tblConfig);
	-------Noi Dung So 2
	select b.SoLenh, b.MaHangHoa , b.TenHangHoa, b.BeXuat
		, (select top 1 HongXuat  from @p_TableLine  c 
			where C.SoLenh =b.SoLenh and c.MaHangHoa =b.MaHangHoa  )  as HongXuat
		,b.NhietDo_BQGQ , b.D15_BQGQ, b.VCF, b.L15, b.WCF , b.KG 
	
  from  fpt_tblLenhXuat_HangHoaE5_v  b 
			where  b.SoLenh in (select SoLenh from @p_Table ) ;
			
	-------Noi Dung So 3
	select @p_BienSo as BienSo, @p_NguoiVanChuyen as NguoiVanChuyen
		,MaNgan, SoluongDuXuat  as DungTich
		, TenHangHoa , MaEntry  as HH, @p_MaSoNiem as MaSoNiem, @p_TongSoNiem  as TongNiem
		 from   fpt_tblLenhXuatChiTietE5_v where SoLenh in  (select SoLenh from @p_Table ) ;
	-------Noi Dung So 4
	select  a.SoLenh, a.TenKhachHang 
		, b.TenHangHoa, DiemTraHang, (select Sum(SoThucXuat )   from @p_TableLine  c 
			where C.SoLenh =b.SoLenh and c.MaHangHoa =b.MaHangHoa)   as Ltt
			, b.DonViTinh, '' as MaTraCuu
	,(select Sum(SoDuXuat )   from @p_TableLine  c 
			where C.SoLenh =b.SoLenh and c.MaHangHoa =b.MaHangHoa)   as DuXuat
				 from  @p_TableLenhXuat a,  FPT_tblLenhXuat_Hanghoae5_v b where a.SoLenh=b.SoLenh;

END
