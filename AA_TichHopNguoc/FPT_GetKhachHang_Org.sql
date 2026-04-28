
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION FPT_GetKhachHang_Org
(@p_MaKhachHang nvarchar(50)
	,@p_PTBan nvarchar(50)
	,@p_TenKhachHang nvarchar(1000)
)
RETURNS nvarchar(1500)
AS
BEGIN
     declare @p_Retun nvarchar(1500)
	 if @p_PTBan ='03'
		begin		
		    set @p_Retun = (select Desciption from tblKhachHang_Org
								where Purchasing_Org = right(@p_MaKhachHang,4) ) 
		end
     if isnull(@p_Retun,'') ='' 
		begin
		     set @p_Retun =   @p_TenKhachHang
		end
   return @p_Retun
END
GO

