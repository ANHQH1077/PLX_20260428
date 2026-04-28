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
alter PROCEDURE FPT_SODOBON
	@p_FromDateTime datetime
	,@p_ToDateTime datetime
	,@p_Client nvarchar(50)	
	,@p_TankCode nvarchar(50)
	,@p_MucDichDo nvarchar(100)
AS
BEGIN
	declare @p_BeXuat table (MaBe nvarchar(50))
	declare @p_MucDich table (Code nvarchar(50))
	declare @p_KHoXuat table (MaKho nvarchar(50))
	declare @p_Date1 datetime
	declare @p_Date2 datetime
	set @p_Date1=getdate()
	set @p_Date2=getdate()
	if not @p_FromDateTime is null
		begin
			set @p_Date1=@p_FromDateTime
		end
	if not @p_ToDateTime is null
		begin
			set @p_Date2=@p_ToDateTime
		end
		
	insert into @p_BeXuat (MaBe) select Name_ND from tblTank where len( isnull(Product_nd,'')) >0 and Name_ND = isnull(@p_TankCode,Name_nd)
	if isnull(@p_Client,'') <>'' 
		begin
			if isnull(@p_Client,'') ='C'
				begin
					delete @p_BeXuat where left(MaBe,1) ='A' or left(MaBe,1) ='B'
				end
			else
				begin
					delete @p_BeXuat where left(MaBe,1) =@p_Client
				end
		end
	
	--select * from  @p_BeXuat
	--return
	
	insert into @p_MucDich (Code) select Code from zPurpose where  Code = isnull(@p_MucDichDo,Code)
	--insert into @p_KHoXuat (Code) select Code from zPurpose where  Code = isnull(@p_MucDichDo,Code)
	--select * from @p_BeXuat
	select B.TankCode as MSB, b.ProductCode as MAHH, convert(date,b.CrDate) as NGAYDO,b.CrDate as GIODO
			,b.PurposeName as MucDD, b.TankHeight as CCAODAU, 
			 case when a.sType='M' then N'Nhập tay' else N'Tự động' end as CHEDO,
			 b.TankTemp as NHIETDO, b.Dens as D15, b.Ltt as SLTT, VCF, VolumnL15 as SLQC, VolumnKG as KG
			 , b.WCF 
			  from dbo.ztblTankLineImp_v  b, ztblTankHeaderImp_v a  where b.TankHeaderCode=a.TankHeaderCode
			  and isnull(Ltt,0) >0.0
			  and  b.CrDate >=@p_Date1 and b.CrDate <=@p_Date2
			 and exists (select 1 from @p_MucDich cc where cc.Code = case when isnull(b.PurposeCode,'') ='' then cc.Code else b.PurposeCode end)
			and exists (select 1 from @p_BeXuat dd where dd.MaBe=b.TankCode)

END
GO
