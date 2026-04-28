

 --exec KV2_BM_05_04_01_HH_rpt '20200630', '20200630','20200629', '20200629 23:00:00'
create or alter procedure KV2_BM_05_04_01_HH_rpt
	(@p_FDate date =null
	,@p_TDate date=null
	,@p_TimeF datetime
	,@p_TimeT datetime
	,@p_Client varchar(20) =null
	)
as
begin	
	declare @p_FromDateTime datetime
	declare @p_ToDateTime datetime
	
    declare @p_From_Hour int
	declare @p_From_MINUTE int
	
	declare @p_To_Hour int
	declare @p_To_MINUTE int
	
	declare @p_FromDate datetime
	declare @p_ToDate datetime
		
	set @p_From_Hour= datepart(hour,@p_TimeF)
	set @p_From_MINUTE = datepart(MINUTE ,@p_TimeF)
	set @p_to_Hour= datepart(hour,@p_TimeT)
	set @p_To_MINUTE = datepart(MINUTE ,@p_TimeT)
		set @p_FromDateTime=  convert (datetime,     replace( CONVERT(char(10),@p_FDate, 102),'.','')  + ' ' +  CONVERT(char(5),@p_TimeF, 108))
	 
	 set @p_ToDateTime =   convert (datetime,  replace( CONVERT(char(10),@p_TDate, 102),'.','')  + ' ' +  CONVERT(char(5),@p_TimeT, 108))

	

	exec KV2_BM_05_04_01_sub  @p_FromDateTime, @p_ToDateTime, @p_Client
	exec KV2_BM_05_04_01_HH @p_FromDateTime, @p_ToDateTime, @p_Client
end