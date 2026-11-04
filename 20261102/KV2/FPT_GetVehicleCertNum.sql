


alter PROCEDURE [dbo].[FPT_GetVehicleCertNum]	(@p_User varchar(100))
	
AS
BEGIN
	declare @p_Year  nvarchar(10)
	declare @Value nvarchar(20)
	declare @p_Tmp nvarchar(30)
	declare @p_TableID nvarchar(20)
	declare @p_Number int
	declare @ID int
	declare @p_SQL nvarchar(1000)
	
   
   set @p_Tmp='00000000'
   set @p_Year =CONVERT(nvarchar(10), year(getdate()))
	
	
   set @p_SQL=' insert into [tblVehicleCertNum] (CrDate,CrUser) values (getdate(),''' + @p_User + '''); SELECT @ID = SCOPE_IDENTITY()'
						 execute sp_executesql @p_sql,N'@Id Numeric OUTPUT',  @ID output

		
   set @Value= right(@p_Tmp + CAST( @ID as varchar(8))   , 8) 
   
   select @Value as TableID
END
