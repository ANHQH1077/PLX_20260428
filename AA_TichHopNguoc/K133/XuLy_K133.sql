
alter procedure ZZXuLyBanGhi
@p_Nam int
as
begin
	if @p_Nam >=year(getdate()) -1
		begin
			select N'Năm xử lý cần < ' + convert(nvarchar(20),year(getdate()) -1) as Error
			return
		end
	delete from tblLenhXuatE5  where YEAR(NgayXuat) =@p_Nam ;
	delete from tblLenhXuat_HangHoaE5 where YEAR(NgayXuat) =@p_Nam;
	delete from tblLenhXuatChiTietE5 where YEAR(NgayXuat) =@p_Nam;

	delete from tblLenhXuatE5_Hist   where YEAR(NgayXuat) =@p_Nam ;
	delete from tblLenhXuat_HangHoaE5_Hist where YEAR(NgayXuat) =@p_Nam;
	delete from tblLenhXuatChiTietE5_Hist  where YEAR(NgayXuat) =@p_Nam;

	-- Truncate the log by changing the database recovery model to SIMPLE.

	ALTER DATABASE [K133_PROD]
	SET RECOVERY SIMPLE;

	-- Shrink the truncated log file to 1 MB.
	DBCC SHRINKFILE (FPTRETAIL_log, 1);

	-- Reset the database recovery model.
	ALTER DATABASE [K133_PROD]
	SET RECOVERY FULL;
	select N'Đã thực hiện xong' as Commnent
end