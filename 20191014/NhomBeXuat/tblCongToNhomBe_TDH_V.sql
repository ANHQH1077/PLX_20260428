
create view tblCongToNhomBe_TDH_V as 

SELECT [IDLINE]
      ,[ID]
      ,[MeterId]
      ,[Valid_from]
      ,[Valid_to]
      ,[Bexuat]
      ,[TankGroup]
      ,[TankGroup_Name]
      ,[MaHangHoa]
      ,[TenHangHoa]
      ,[Push_TDH]
      ,[Push_XTTD]
      ,[User_Push_TDH]
      ,[Date_Push_TDH]
      ,[User_Push_XTTD]
      ,[Date_Push_XTTD]
      ,[CreateUser]
      ,[CreateDate]
      ,[UpdateUser]
      ,[UpdateDate]
      ,[sType]
      ,[TankValidfrom]
      ,[TankValid_to]
	  ,'U' as CHECKUPD
  FROM [dbo].[tblCongToNhomBe_TDH]

GO


