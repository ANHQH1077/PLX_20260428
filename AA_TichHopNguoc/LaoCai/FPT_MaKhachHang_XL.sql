-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION FPT_MaKhachHang_XL (@p_MaKhacHang nvarchar)

RETURNS nvarchar
AS
BEGIN
	-- Declare the return variable here
	DECLARE @p_Return nvarchar(50)
    set @p_Return =''
	
	DECLARE @cnt INT = 0;
	if len(@p_MaKhacHang)>0
		begin
			WHILE @cnt < len(@p_MaKhacHang) --and @cnt <=4
				BEGIN	   
				   SET @cnt = @cnt + 3
				   if substring(@p_MaKhacHang,@cnt,1) <> '0'
						begin
							Break
						end
				   else
						begin 
						    set @p_Return
						end
				
				END
		end;
     return @p_Return
END
GO

