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
alter PROCEDURE CapNhatThongTin_NhomBe
	@p_SoLenh nvarchar(50)
AS
BEGIN
		declare @p_TableId nvarchar(50)
		
		update tblLenhXuat_HangHoaE5   set NhomBeXuat =  (select top 1 a.NhomBeXuatTDH  from FPT_tblLenhXuatChiTietE5_V a 
				where a.SoLenh  =tblLenhXuat_HangHoaE5.SoLenh   and a.TableID = tblLenhXuat_HangHoaE5.TableID and a.MaHangHoa =tblLenhXuat_HangHoaE5.MaHangHoa   ) 
			where Solenh = @p_SoLenh
		update tblLenhXuat_HangHoaE5   set BeXuat =  (select top 1 a.BeXuatTDH   from FPT_tblLenhXuatChiTietE5_V a 
				where a.SoLenh  =tblLenhXuat_HangHoaE5.SoLenh  and a.TableID = tblLenhXuat_HangHoaE5.TableID and a.MaHangHoa =tblLenhXuat_HangHoaE5.MaHangHoa  ) 
			 where Solenh = @p_SoLenh
		--select top 1  @p_TableId = TableID  from  tblLenhXuat_HangHoaE5 with (nolock) where Solenh = @p_SoLenh and  (isnull(NhomBeXuat,'') ='' or  isnull(BeXuat,'') ='')
		--if isnull(@p_TableId,'') <> ''
		--	begin
		--		select 1 as nNumber, N'Nhóm bể xuất/Bể xuất không hợp lệ' as sDesc
		--	end
		--else
		--	begin
		--		select 0 as nNumber, N'' as sDesc where 1=0
		--	end

END
GO
