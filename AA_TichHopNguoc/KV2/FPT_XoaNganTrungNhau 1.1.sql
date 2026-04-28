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
alter PROCEDURE FPT_XoaNganTrungNhau
	@p_Row_ID decimal(11,2)
AS
BEGIN
    declare @p_Row_ID11 decimal(11,2)
	DECLARE product_cursor CURSOR FOR   
		select Row_ID  from FPT_tblLenhXuatChiTietE5_v  a where  Row_ID=@p_Row_ID
			and exists (select 1 from tblLenhXuatE5 b with (nolock) where SoLenh=a.solenh and Status in ('1','2',''))

	OPEN product_cursor  
	FETCH NEXT FROM product_cursor INTO @p_Row_ID11  	
		
	WHILE @@FETCH_STATUS = 0  
	BEGIN  
		delete from tbllenhxuatchitiete5 where Row_ID=@p_Row_ID11
		FETCH NEXT FROM product_cursor INTO @p_Row_ID11  
	END
	CLOSE product_cursor  
	DEALLOCATE product_cursor  
		--delete from tbllenhxuatchitiete5 where Row_ID=@p_Row_ID
	
END
