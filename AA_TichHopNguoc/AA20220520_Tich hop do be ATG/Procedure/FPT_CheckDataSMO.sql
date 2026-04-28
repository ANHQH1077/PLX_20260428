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
alter PROCEDURE FPT_CheckDataSMO
	@p_PhuongTien nvarchar(50)
	--,@p_SoChuyen int
	,@p_Delete int
	,@p_User  nvarchar(50)
	,@p_ID int
AS
BEGIN
	
	-------
	declare @p_Date datetime
	declare @p_LenhTK int
	set @p_LenhTK =0
	
	select  top 1 @p_Date = NgayVaoKho from  tblSMO_INT   where  id =@p_ID
	
	--Kiem trta neu lenh da In tich ke thi out
	select @p_LenhTK=count(*) from tbllenhxuatE5 b with (nolock) where 
		exists (select 1 from tblSMO_INT a with (nolock)  where a.SoLenh=b.SoLenh 
					and  a.MaPhuongTien =@p_PhuongTien	and a.NgayVaoKho  =@p_Date )
				 --and Convert(date,NgayVaoKho)=convert(date, getdate()) and a.MaPhuongTien =@p_PhuongTien									
				and isnull(b.Status,'1') in ('3','31','4','5')
	if isnull(@p_LenhTK,0) >0
		begin
			select 1 as Error , N'Lệnh đã in tích kê' as sError, 0 as sQuesion
			return
		end 
	--Kiem tra lenh da co trong httg va chua in tich ke
	
	set @p_LenhTK =0
	--Kiem trta neu lenh da In tich ke thi out
	select @p_LenhTK=count(*) from tbllenhxuatE5 b with (nolock) where 
		exists (select 1 from tblSMO_INT a with (nolock)  where a.SoLenh=b.SoLenh 
							and  a.MaPhuongTien =@p_PhuongTien	and a.NgayVaoKho  =@p_Date )
				-- and Convert(date,NgayVaoKho)=convert(date, getdate()) and a.MaPhuongTien =@p_PhuongTien
										
		and isnull(b.Status,'1') in ('1','2')
	if isnull(@p_LenhTK,0) >0
		begin
			if isnull(@p_Delete,0) =0
				begin
					select 1 as Error , N'Lệnh đã được lấy xuống HTTG. Bạn có muốn tiếp tục không?' as sError,  1 as sQuesion
					return
				end 
			else
				begin
					delete from tbllenhxuate5 where SoLenh in  (select SoLenh  from tblSMO_INT a with (nolock) 
																where   a.MaPhuongTien =@p_PhuongTien	and a.NgayVaoKho  =@p_Date    )
								and isnull(Status,'1') in ('1','2') 
				end
		end 
		 select 0 as Error , N'' as sError,  0 as sQuesion ;
		 select  MaPhuongTien, SoLenh, NguoiLaiXe, Convert(date,NgayVaoKho) as NgayXuat from dbo.tblSMO_INT a with (nolock)  
				   where 
				 ---  Convert(date,NgayVaoKho)=convert(date, getdate()) 
						  not exists (select 1 from tbllenhxuate5 b  with (nolock) 
								 where a.SoLenh =b.SoLenh	 ) and  a.MaPhuongTien =@p_PhuongTien	and a.NgayVaoKho  =@p_Date  ; 
END
GO
