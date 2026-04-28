alter PROCEDURE FPT_XoaNganTableID	
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
