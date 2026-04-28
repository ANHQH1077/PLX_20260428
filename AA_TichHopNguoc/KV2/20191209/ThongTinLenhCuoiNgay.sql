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
-- Create date: 20191209
-- Description:	Ham lay du lieu cac lenh xuat in tich ke sau 23h30
---   exec  ThongTinLenhCuoiNgay 'sysadmin',null
-- =============================================
alter PROCEDURE ThongTinLenhCuoiNgay
	@p_User nvarchar (200)
	,@p_Client nvarchar(20)
AS
BEGIN


	declare @p_TableClient nvarchar(200)
	
	
	select top 1 @p_TableClient  = Terminal from SYS_USer  where upper (User_Name) =upper(@p_User)
	
	declare @p_Time nvarchar(200)
	declare @p_DateTime datetime
	select top 1 @p_Time =KeyValue from SYS_CONFIG  where KeyCode ='TIME_END'
	
	set @p_Time =isnull(@p_Time,'23:30')
	
	
	begin try
		set @p_DateTime = convert(datetime, convert(nvarchar(10),getdate(),112) + ' ' + @p_Time  )
	end try		
	begin catch
		set @p_DateTime = convert(datetime, convert(nvarchar(10),getdate(),112) + ' 23:30'  )
	end catch
	
	select 'N' as X , Client, convert(nvarchar(10), NgayTichKe, 103) as  NgayTichKe
		,convert(nvarchar(5),NgayTichKe , 108) as GioTichKe
		,SoTichKe, convert(nvarchar(5),GioVaoKho , 108) as GioVaoKho
		,SoLenh
		,case when isnull(NgayHieuLuc,'') <>'' then right( NgayHieuLuc,2) + '/' + substring(NgayHieuLuc,5,2) + '/' + left(NgayHieuLuc,4) 
			else null end NgayHieuLuc
		, NgayHetHieuLuc
		, MaNguon, MaPhuongThucBan
			, MaNgan,  DungTichNgan,MaHangHoa,
			 SoLuongDuXuat 
	from  (
			select 
					h1.Client, h1.NgayTichKe, 
					 (SELECT        TOP (1) SoTichKe
											   FROM            dbo.tblTichke AS B
											   WHERE        (SoLenh = h1.SoLenh)) AS SoTichKe,
					h1.NgayVaoKho  as GioVaoKho
					, h1.SoLenh, 
								case when ISdate(NgayHieuLuc )  =1  then
								convert(nvarchar(10),NgayHieuLuc,111)  
								 else NULL end   as NgayHieuLuc 
					, convert(nvarchar(10), h1.NgayHetHieuLuc, 103) as NgayHetHieuLuc
					, h1.MaNguon, h1.MaPhuongThucban
					, h.MaNgan, h.SoLuongDuXuat as DungTichNgan,h.MaHangHoa,
					 h.SoLuongDuXuat from fpt_tblLenhxuatChitiete5_v h, tblLenhXuate5 h1 with (nolock)	
						where h.SoLenh=h1.SoLenh  and  h1.Status  in ('3')
							and h1.NgayTichKe >= @p_DateTime 
							and charindex(h1.Client,@p_TableClient,1) >0 
							and h1.Client =case when isnull(@p_Client,'' ) <> '' then @p_Client
											else h1.Client end 
	) abc order by Client, SoLenh
						
	
END
GO
