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
alter PROCEDURE CapNhatNhomBe_HangHoa
	@p_MaBe nvarchar(20) =null,
	@p_MaHangHoa nvarchar(20) =null
	,@p_UserName nvarchar(100) =null
	, @p_MeterID nvarchar(10) =null
AS
BEGIN
	declare @p_tenhangHoa nvarchar(200)
	--select top 1 @p_tenhangHoa =TenHangHoa  from tblHangHoa  where MaHangHoa = @p_MaHangHoa
	if isnull(@p_MaBe,'') =''
		begin
			set @p_MaBe =null
		end 
	if isnull(@p_MaHangHoa,'') =''
		begin
			set @p_MaHangHoa =null
		end 
	if isnull(@p_MeterID,'') =''
		begin		
				update a set a.Product_nd =b.Product_nd , a.UpdateDate =getdate(), a.UpdateUser = isnull(@p_UserName,'')   from  tblTankGroup a,  tblTank  b where a.Name_nd = b.Name_nd
							and getdate() >= isnull(a.FromDate,getdate()-1) and  getdate() <= isnull(a.ToDate ,getdate()+1) 
								and isnull( a.Product_nd,'')  <> isnull( b.Product_nd  ,'') and isnull( b.Product_nd  ,'') <> '' and isnull(a.Name_nd,'')  = isnull(@p_MaBe,isnull(a.Name_nd,''))
								and  isnull(a.Product_nd,'')  = isnull(@p_MaHangHoa,isnull(a.Product_nd,''))
				--update a set a.MaHangHoa  = b.Product_nd  , a.TenHangHoa  = (select top 1 TenHangHoa  from tblHangHoa  where MaHangHoa = b.Product_nd) 	
				--	 , a.UpdateDate =getdate(), a.UpdateUser = isnull(@p_UserName,'') 
				--	from  tblCongToNhomBe a,  tblTank  b where a.Bexuat  = b.Name_nd
				--			and getdate() >= isnull(Valid_from ,getdate()-1) and  getdate() <= isnull(Valid_to  ,getdate()+1)   and isnull( a.MaHangHoa ,'')  <> isnull( b.Product_nd  ,'') and isnull( b.Product_nd  ,'') <> ''
				--			and isnull(a.Bexuat,'')  = isnull(@p_MaBe,isnull(a.Bexuat,''))
				--			and  isnull(a.MaHangHoa,'')  = isnull(@p_MaHangHoa,isnull(a.MaHangHoa,''))
				--update a set a.MaHangHoa  = b.Product_nd  , a.TenHangHoa  = (select top 1 TenHangHoa  from tblHangHoa  where MaHangHoa = b.Product_nd) 	
				--	 , a.UpdateDate =getdate(), a.UpdateUser = isnull(@p_UserName,'') 
				--	from  tblCongToNhomBe_TDH a,  tblTank  b where a.Bexuat  = b.Name_nd
				--			and getdate() >= isnull(Valid_from ,getdate()-1) and  getdate() <= isnull(Valid_to  ,getdate()+1)   and isnull( a.MaHangHoa ,'')  <> isnull( b.Product_nd  ,'') and isnull( b.Product_nd  ,'') <> ''
				--			and isnull(a.Bexuat,'')  = isnull(@p_MaBe,isnull(a.Bexuat,''))
				--			and  isnull(a.MaHangHoa,'')  = isnull(@p_MaHangHoa,isnull(a.MaHangHoa,''))
		end 
	else
		begin
			return 
		end

END
GO
