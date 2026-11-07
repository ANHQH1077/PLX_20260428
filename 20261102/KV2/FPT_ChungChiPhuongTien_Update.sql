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
alter PROCEDURE FPT_ChungChiPhuongTien_Update  	
AS
BEGIN
	declare @pSoLo nvarchar(100)
	declare @p_0C varchar(10) = '°C'
	declare @p_NgayGioXepHang datetime
	declare @p_MaPhuongTien nvarchar(100)
	declare @p_SDA_Amount as decimal(20,4)
	declare @p_NgayXuat1 date
	declare @p_SoTichKe1 nvarchar(100)
	declare @p_MaHangHoa varchar(10)='0101002'
	declare @p_TenHangHoa nvarchar(100)
	declare @p_PhuongTien nvarchar(100)
	declare @p_TankCode varchar(10)
	declare @p_MaNgan varchar(200)
	declare @p_CertNo nvarchar(100)=null
	--@p_FormRequestCode nvarchar(100)=null,
	declare @p_SoTichKe nvarchar(10) = null
	declare @p_NgayXuat date

	select top 1 @p_TenHangHoa = TenHangHoa from tblHangHoa where maHangHoa = @p_MaHangHoa
	
	IF CURSOR_STATUS('global','p_cursor')>=-1
	BEGIN
	 DEALLOCATE p_cursor
	END


	DECLARE p_cursor CURSOR FOR
    select CertNo, NgayXuat, MaPhuongTien, SoTichKe, SoBon from tblPhuongTien_Cert 	where isnull(BatNum,'' )  =''
    OPEN p_cursor
    FETCH NEXT FROM p_cursor
		INTO @p_CertNo , @p_NgayXuat, @p_MaPhuongTien, @p_SoTichKe1,@p_TankCode
    IF @@FETCH_STATUS <> 0 return
    WHILE @@FETCH_STATUS = 0
		BEGIN				
				
				begin try
				select @pSoLo= BatchNum, @p_SDA_Amount = isnull(SDA_Amount,0)  from ztblTankBatchs where   
					TankCode in (select Name_nd from tblTank where Map_Sap =@p_TankCode and Product_nd = @p_MaHangHoa) and  CreateDate =isnull( (
					select max(CreateDate) as CreateDate from ztblTankBatchs 
						where   TankCode in (select Name_nd from tblTank where Map_Sap =@p_TankCode and Product_nd = @p_MaHangHoa)
							and CreateDate <= getdate()),'2000-01-01 07:58:01.227')		
				if isnull(@pSoLo,'') <> ''
					begin
						update tblPhuongTien_Cert set BatNum =@pSoLo, SDA_Amount   = @p_SDA_Amount
							where CertNo =@p_CertNo and NgayXuat =@p_NgayXuat and MaPhuongTien =@p_MaPhuongTien and SoTichKe=@p_SoTichKe1
					end
				end try
				begin catch
					set @p_SoTichKe =null
				end catch
				FETCH NEXT FROM p_cursor
					INTO @p_CertNo , @p_NgayXuat, @p_MaPhuongTien, @p_SoTichKe1,@p_TankCode
        END

    CLOSE p_cursor
    DEALLOCATE p_cursor

END
GO
