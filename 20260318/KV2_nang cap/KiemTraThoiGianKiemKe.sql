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
alter PROCEDURE KiemTraThoiGianKiemKe (@p_SoLenh nvarchar(200), @p_Loai varchar(1), @p_CreateTime  varchar(50)
	-- Add the parameters for the stored procedure here
	)
AS
	declare @p_KIEMKE_MESS varchar(1)='N'
	declare @p_SAP_OFF varchar(1)='N'
BEGIN
	
	select @p_SAP_OFF= KeyValue  from sys_config  where upper(KeyCode) = upper('SAPOFF')

    select @p_KIEMKE_MESS= KeyValue  from sys_config  where upper(KeyCode) = upper('KIEMKE_MESS')
	set @p_KIEMKE_MESS = isnull(@p_KIEMKE_MESS,'N')

    if isnull(@p_SoLenh,'') <> '' and  (select count(1) from tblLenhXuatE5 where solenh =isnull(@p_SoLenh,'')  ) >0
		begin
			if isnull(@p_SAP_OFF,'N') = 'N'
				begin
					if @p_Loai ='T' -- Phat hanh tich ke
						begin
							select N'Lệnh xuất được khởi tạo trước thời điểm kiểm kê. Đề nghị kiểm tra lại' as sDesc, @p_KIEMKE_MESS as MESS 
								from tbllenhxuate5 k1 where solenh = @p_SoLenh and manguon ='N30'
							and exists (select 1 from tblThoiGianKiemKe k where k.NgayGio > k1.CreateDate)
							return
						end
					if @p_Loai ='R' -- Rut hong xuat
						begin
							select N'Lệnh xuất được khởi tạo trước thời điểm kiểm kê - Bơm hàng sau thời điểm kiểm kê. Đề nghị kiểm tra lại' as sDesc   , @p_KIEMKE_MESS as MESS 
								from tbllenhxuate5 k1 where solenh = @p_SoLenh and manguon ='N30'  --and Status in ('31','4')
								--and exists (select 1 from tblThoiGianKiemKe k where k.NgayGio > k1.CreateDate)
								and exists (select 1 from tblThoiGianKiemKe k where k.NgayGio > k1.CreateDate and k.NgayGio < 
									(select min(ThoiGianDau)  from FPT_tblLenhXuatChiTietE5_V where SoLenh = k1.SoLenh))
							return
						end
				end
			else
				begin
					if @p_Loai ='T' -- Phat hanh tich ke
						begin
							select N'Lệnh xuất được khởi tạo trước thời điểm kiểm kê. Đề nghị kiểm tra lại' as sDesc, @p_KIEMKE_MESS as MESS 
								from tblLenhXuatE5_THN k1 where solenh = @p_SoLenh and manguon ='N30'
							and exists (select 1 from tblThoiGianKiemKe k where k.NgayGio > k1.CreateDate)
							return
						end
					if @p_Loai ='R' -- Rut hong xuat
						begin
							select N'Lệnh xuất được khởi tạo trước thời điểm kiểm kê - Bơm hàng sau thời điểm kiểm kê. Đề nghị kiểm tra lại' as sDesc   , @p_KIEMKE_MESS as MESS 
								from tbllenhxuate5 k1 where solenh = @p_SoLenh and manguon ='N30' and Status in ('31','4')
								--and exists (select 1 from tblThoiGianKiemKe k where k.NgayGio > k1.CreateDate)
								and exists (select 1 from tblThoiGianKiemKe k where k.NgayGio > k1.CreateDate and k.NgayGio < 
									(select min(ThoiGianDau)  from FPT_tblLenhXuatChiTietE5_V where SoLenh = k1.SoLenh))
							return
						end
				end

		end
	else
		begin
			select N'Lệnh xuất được khởi tạo trước thời điểm kiểm kê. Đề nghị kiểm tra lại' as sDesc  , @p_KIEMKE_MESS as MESS   where 
					 exists (select 1 from tblThoiGianKiemKe k where k.NgayGio > @p_CreateTime)
					return
		end
	select null as sDesc , @p_KIEMKE_MESS as MESS 
END
GO
