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
alter PROCEDURE KiemTraGiaoNhan_HH
	@p_StrLenh nvarchar(2000)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	declare @p_TLenhXuatE5 table (SoLenh nvarchar(50) 
							,MaTuyenDuong nvarchar(200)
								)
	begin try
			insert into  @p_TLenhXuatE5 (SoLenh, MaTuyenDuong)
			select SoLenh , MaTuyenDuong from tblLenhXuatE5  a	with(nolock)		
					where   CHARINDEX (',' + solenh +',', ',' + @p_StrLenh + ',' ,1)>0 
							and exists (select 1 from tblGiaoNhan_HangHoa b 
									where a.MaTuyenDuong =b.MaTuyenDuong and isnull(Status,'')='Y')
			select top 1 0  as nError, N'Hàng hóa không đúng với điểm giao hàng' as sDesc 
				 from  tblLenhXuat_HangHoaE5 b with (nolock), @p_TLenhXuatE5 a  where a.SoLenh =b.SoLenh
				and not exists (select 1 from tblGiaoNhan_HangHoa cc with (nolock) where a.MaTuyenDuong =cc.MaTuyenDuong
									and b.MaHangHoa =cc.MaHangHoa
							)

			---select ERROR_NUMBER() as nError, ERROR_MESSAGE() as sDesc
	end try

	begin catch
		select ERROR_NUMBER() as nError, ERROR_MESSAGE() as sDesc
	end catch
END
GO
