

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
alter PROCEDURE [dbo].[FPT_UpdateTankBatch]
	@p_NgayThang nvarchar(15)
	,@p_TankOld nvarchar(20)
	,@p_TankNew nvarchar(20)
	,@p_User nvarchar(100)
	,@p_NhomBeXuat nvarchar(10) =null
AS
BEGIN

	begin try
		--Kiem tra xem cos lenh xuất nào không đúng với Nhóm bể thì thông báo
		declare @p_exist int =0
		--declare @p_NhomBe nvarchar(10)

		--select * from SYS_CONFIG 

		if isnull(@p_TankOld,'') ='' or isnull(@p_TankNew,'') =''
			begin
				select 1 as nNumber, N'Bể xuất chưa nhập' as sDesc
				return
			end 
		if isnull(@p_NgayThang,'') ='' 
			begin
				select 1 as nNumber, N'Ngày tháng chưa nhập' as sDesc
				return
			end 
		if isnull(@p_NhomBeXuat,'') =''
			begin
				update tbllenhxuat_hanghoae5 set BeXuat = @p_TankNew, [UpdatedBy]=@p_user where
					exists (select 1 from   tblLenhXuatE5 a with (nolock) where NgayXuat =@p_NgayThang and Status  in ('1','2','3')
							and a.SoLenh =tbllenhxuat_hanghoae5.SoLenh ) and BeXuat =@p_TankOld	  and isnull(NhomBeXuat,'') =''
			end
		else
			begin
				--cap nhat theo nhom be
				select @p_exist =count(1) from   tbllenhxuat_hanghoae5 a2  where
					exists (select 1 from   tblLenhXuatE5 a with (nolock) where NgayXuat =@p_NgayThang and Status  in ('1','2','3')
							and a.SoLenh =a2.SoLenh ) and BeXuat =@p_TankOld and isnull(a2.NhomBeXuat,'') <> @p_NhomBeXuat 
				
				if isnull(@p_exist,0) >0
					begin
						select 1 as nNumber, N'Tích kê có bể xuất ' + @p_TankOld + N'  có nhóm bể khác với nhóm bể của bể xuất mới ' +  @p_TankNew  as sDesc
						return
					end 
				else
					begin
						update tbllenhxuat_hanghoae5 set BeXuat = @p_TankNew, [UpdatedBy]=@p_user where
							exists (select 1 from   tblLenhXuatE5 a with (nolock) where NgayXuat =@p_NgayThang and Status  in ('1','2','3')
									and a.SoLenh =tbllenhxuat_hanghoae5.SoLenh ) and BeXuat =@p_TankOld and isnull(NhomBeXuat,'') =@p_NhomBeXuat 
					end				
			end
		
		select 0 as nNumber, N'Đã thực hiện xong' as sDesc
	end try

	begin catch
		select ERROR_NUMBER () as nNumber, ERROR_MESSAGE () as sDesc
	end catch
	
END
GO

