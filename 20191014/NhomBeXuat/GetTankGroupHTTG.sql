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
-- Create date: <Create Date,,>  select top 10 * from FPT_tblTankActive_V  where isnull(loadingSite ,'')  <> ''
-- Description:	<Description,,>
-- =============================================
alter PROCEDURE GetTankGroupHTTG 
	@p_TankCode nvarchar(50), @p_NhomMaBeSAP nvarchar(50), @p_MaHangHoa nvarchar(50) = null, @p_Client nvarchar(10) =null
	, @p_MaVanChuyen nvarchar(100) =null
AS
BEGIN
	if isnull(@p_MaVanChuyen,'') =''
		begin
			set @p_MaVanChuyen =null
		end
	if isnull(@p_TankCode,'') = ''
		begin
			
				select top 1 TankGroup , Name_nd  from tblTankGroup dd  where    getdate () >= isnull(FromDate , getdate () -1)  and getdate ()  < = isnull(ToDate,getdate()+1)
							and TankGroup  =@p_NhomMaBeSAP and isnull(Product_nd ,'') = isnull(@p_MaHangHoa,'') 
							and exists(select 1 from   FPT_tblTankActive_V cc  where date1=convert(date, getdate())		
										and tank_app='Y' and cc.Name_nd  = dd.Name_nd
								 and (case when isnull(@p_MaVanChuyen,'') ='' then  upper(isnull(loadingSite ,'')) else upper( @p_MaVanChuyen) end =      upper(isnull(loadingSite ,'')) 
										or isnull(loadingSite ,'') ='')
										)
							and SUBSTRING (isnull(dd.Name_nd,''),1,1) = isnull(@p_Client,SUBSTRING (isnull(dd.Name_nd,''),1,1))
		end
	else
		begin
				select top 1 TankGroup  , Name_nd  from tblTankGroup dd where  Name_nd  = @p_TankCode and  getdate () >= isnull(FromDate , getdate () -1)  and getdate ()  < = isnull(ToDate,getdate()+1)
							and TankGroup  =@p_NhomMaBeSAP and isnull(Product_nd ,'') = isnull(@p_MaHangHoa,'') 
							and exists(select 1 from   FPT_tblTankActive_V cc  where date1=convert(date, getdate()) 
										and tank_app='Y' and cc.Name_nd  = dd.Name_nd
								and (case when isnull(@p_MaVanChuyen,'') ='' then  upper(isnull(loadingSite ,'')) else upper( @p_MaVanChuyen) end =      upper(isnull(loadingSite ,'')) 
								or isnull(loadingSite ,'') =''))
							and SUBSTRING (isnull(dd.Name_nd,''),1,1) = isnull(@p_Client,SUBSTRING (isnull(dd.Name_nd,''),1,1))
								
		end
END
GO


--select * from   tblTankGroup  where name_nd like 'D%'


