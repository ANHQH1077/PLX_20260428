USE [HTTG_UAT]
GO
/****** Object:  StoredProcedure [dbo].[FPT_KiemTraKhachHang_TuyenDuong]    Script Date: 06/22/2020 15:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>   exec    FPT_KiemTraKhachHang_TuyenDuong '2345678'
-- =============================================
ALTER PROCEDURE [dbo].[FPT_KiemTraKhachHang_TuyenDuong]
	@p_SoLenh nvarchar(100)
AS
BEGIN
	declare @p_MaKhachHang nvarchar(100)
	declare @p_MaTuyenDuong nvarchar(100)
	declare @p_MaKhachHang_TD nvarchar(100)
	declare @p_MaTuyenDuong_TD nvarchar(100)

	select @p_MaKhachHang =MaKhachHang, @p_MaTuyenDuong =MaTuyenDuong  from   tblLenhXuatE5 with (nolock)  where SOlenh =@p_SoLenh

	if ISNULL(@p_MaTuyenDuong,'') <> ''   ---- Co gan ma tuyen duong thi moi check
		begin
	
			IF EXISTS(SELECT * FROM tblKhachHang_TD aa with (nolock) 
							WHERE MaKhachHang=@p_MaKhachHang )
				begin
					select @p_MaKhachHang_TD =MaKhachHang, @p_MaTuyenDuong_TD =MaTuyenDuong  
								from   tblKhachHang_TD with (nolock)
										where  MaKhachHang = @p_MaKhachHang  and MaTuyenDuong =@p_MaTuyenDuong
					if isnull(@p_MaTuyenDuong_TD,'') =''
						begin
							select 1 as nError, N'Khách hàng và Tuyến đường không hợp lệ' as sDesc
						end
					else
						begin
							select 0 as nError, N'' as sDesc
						end	
				end
			else
				begin
					select 0 as nError, N'' as sDesc
				end
		end
	else
		begin
			select 0 as nError, N'' as sDesc
		end
	
	

END
