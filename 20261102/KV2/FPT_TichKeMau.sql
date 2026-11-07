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
alter  PROCEDURE FPT_TichKeMau  
	@p_SoTichKe nvarchar(100)=null,
	@p_NgayThang nvarchar(100)=null
AS	
begin
	declare @p_SoLenh nvarchar(20)
	declare @p_TenHangHoa nvarchar(500)
	select top 1 @p_TenHangHoa= tenhanghoa from tblHangHoa where mahanghoa  ='0101002'

	select top 1 @p_SoLenh = solenh from tblTichke where NgayTichKe = @p_NgayThang  and SoTichKe = @p_SoTichKe 
	SELECT a.TenKhachHang as KhachHang,
			@p_TenHangHoa as TenHangHoa,
			a.Client ,
			@p_SoTichKe   as SoTichKe,
			a.MaPhuongTien as PhuongTien,
			@p_NgayThang as NgayTichKe
			  FROM [dbo].FPT_tblLenhXuatE5_V a 
			  where  solenh = @p_SoLenh
			   and exists (select 1 from FPT_tblLenhXuatChiTietE5_V k where a.SoLenh = k.SoLenh  and k.MaHangHoa =  '0101002')

	
END

