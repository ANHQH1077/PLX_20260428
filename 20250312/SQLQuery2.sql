

select top 10    SoLenh as SoLenh1, NgayXuat  from tbllenhxuat_HangHoaE5  for xml path ('ABC')

/*
begin
	declare @p_SLL XML
	declare @p_STRING_LINE nvarchar(max)

	set @p_STRING_LINE =   (select MaHangHoa , TongDuXuat  from tbllenhxuat_HangHoaE5 a where a.SoLenh  ='2051570799'  for xml path ('Product'), root ('Products')  )


	set @p_SLL = (select  SoLenh as SoLenh1, NgayXuat ,
									 @p_STRING_LINE	 as Products		
				from tblLenhXuatE5  as Invoice where SoLenh ='2051570799'  
					for xml path('Inv'))
				
	print convert(nvarchar(max), @p_STRING_LINE)
end
*/

exec  ZZZZZZBUILD_XML '2051570799'

alter Procedure ZZZZZZBUILD_XML (@p_SoLenh varchar(20)) as

begin
	declare @p_SLL XML
	set @p_SLL = (select  SoLenh as SoLenh1, NgayXuat ,
					 (select MaHangHoa , TongDuXuat  from tbllenhxuat_HangHoaE5 a where a.SoLenh  ='2051570799'  for xml path ('Product'), root ('Products') , TYPE )		
					, MaPhuongTien, MaPhuongThucBan
				from tblLenhXuatE5  as Invoice where SoLenh ='2051570799'  
					for xml path('Inv'))
				
	select  @p_SLL
end








select  MaKhachHang , NgayXuat   from tblLenhXuatE5 where NgayXuat >='20250511'


select * from tblHDDT_Messages 