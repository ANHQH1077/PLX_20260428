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
create PROCEDURE FPT_TonKhoThucTe
	--@p_FromDate datetime
	@p_ToDateTime datetime
	,@p_Client nvarchar(50)
	,@p_TankCode nvarchar(50)	
AS
BEGIN
		declare @p_BeXuat table (MaBe nvarchar(50))
		--declare @p_MucDich table (Code nvarchar(50))
		declare @p_KHoXuat table (MaKho nvarchar(50))
		
		--Bang luu thong tin lan do be cuoi cung
		declare @p_TankLineImp_Temp table 
						(TankCode nvarchar(50)
							, ID int
							, CrDate datetime
							,CreateDate datetime
												)
		
		declare @p_Date1 datetime
		declare @p_Date2 datetime
		set @p_Date1=getdate()
		set @p_Date2=getdate()
		--if not @p_FromDateTime is null
		--	begin
		--		set @p_Date1=@p_FromDateTime
		--	end
		if not @p_ToDateTime is null
			begin
				set @p_Date2=@p_ToDateTime
			end
			
		--insert into @p_BeXuat (MaBe) select Name_ND from tblTank where len( isnull(Product_nd,'')) >0 and Name_ND = isnull(@p_TankCode,Name_nd)
		if isnull(@p_Client,'') <>'' 
			begin
				if isnull(@p_Client,'') ='C'
					begin
						--delete @p_BeXuat where left(MaBe,1) ='A' or left(MaBe,1) ='B'
						insert into @p_BeXuat (MaBe) select Name_ND from tblTank  where name_nd like 'C%' or Name_ND like 'D%' or Name_ND like 'OD%'   or Name_ND like 'OC%'  
					end
				else if isnull(@p_Client,'') ='A'
							begin
								--delete @p_BeXuat where left(MaBe,1) =@p_Client
								insert into @p_BeXuat (MaBe) select Name_ND from tblTank  where Name_ND like 'A%' or Name_ND like 'OA%' 
							end
				else
					begin
							insert into @p_BeXuat (MaBe) select Name_ND from tblTank  where Name_ND like 'B%' or Name_ND like 'OB%' 
							
					end
			end
		else
			begin 
				insert into @p_BeXuat (MaBe) select Name_ND from tblTank
			end

		---Lay casc ban ghi cuoi cung theo be
		
		insert into @p_TankLineImp_Temp  
						(TankCode ,  CrDate,ID
							,CreateDate) 
		select  b.TankCode,bb.CrDate,Max(ID) as ID, max( isnull( b.SynDate, b.CreateDate) )  as  CreateDate  from dbo.ztblTankLineImp b  with (nolock)
						,(select  b.TankCode,max( CrDate)  as CrDate from dbo.ztblTankLineImp b with (nolock)  where 
								X='Y' and isnull(Ltt,0) >0 and b.CrDate<=@p_Date2  group by b.TankCode ) bb
					  where  b.TankCode =bb.TankCode and  b.CrDate =bb.CrDate
							and X='Y' and isnull(Ltt,0) >0 and b.CrDate<=@p_Date2		
							 and exists (select 1 from @p_BeXuat dd where dd.MaBe=b.TankCode)					
					  group by b.TankCode, bb.CrDate
					order by b.TankCode	



		select  case when left(client,1)='D' then 'C' else client end as Client
				, 'Kho ' + case when left(client,1)='D' then 'C' else client end as ClientDesc
				, MAHH,TenHangHoa  as  TenHH, MSB as MaBe, SafeVolumeM3 as DungTichBe, MinHeight as ChieuCaoMin
				, TankHeight as ChieuCaoDau, Ltt as DungTichChua, DungTichTrongM3 as DungTichTrong				
				, DungTichXuat as  DungTichXuatDuoc
		--	,SafeVolumeM3, SafeVolume,TankHeight,Ltt, DungTichTrong, DungTichTrongM3, DungTichXuat
		from (
			SELECT   case when left(a.tankcode,1) ='O' then substring(a.tankcode,2,1) else case when isnull(a.client,'') ='' 
								then left(a.TankCode,1) else a.client end end as client, 
					 a.TankCode as MSB, a.ProductCode  as MAHH, a.TenHangHoa,
				round (isnull(c.SafeVolume,0) /1000,0) as SafeVolumeM3,
				c.SafeVolume,a.TankHeight,a.Ltt,MinHeight,
				isnull(c.SafeVolume,0)  - isnull( a.Ltt,0) as DungTichTrong, 
				round((isnull(c.SafeVolume,0)  - isnull( a.Ltt,0))/1000,0) as DungTichTrongM3, 
				case when isnull( a.Ltt,0 ) <=0 then 0 else isnull( a.Ltt,0) - isnull(c.MinHeight,0) end  as DungTichXuat
			  FROM [ztblTankLineImp_v] a with (nolock), ztblTankHeaderImp_v b  with (nolock), ztblTankInfor c	  with (nolock)	
				where a.TankHeaderCode =b.TankHeaderCode  and a.TankCode =c.tankcode 
					and exists (select 1 from  @p_TankLineImp_Temp gg where gg.ID=a.ID)
					and exists (select 1 from @p_BeXuat dd where dd.MaBe=a.TankCode)) anhqh123

END
