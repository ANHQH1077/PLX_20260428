
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>   exec [FPT_DanhSachATG_SAP] null, 'C',null,'20190101', '20190131', 'aaaaa'
-- =============================================
ALTER PROCEDURE [dbo].[FPT_DanhSachATG_SAP]
	@p_DocEntry int
	,@p_Client nvarchar(50)
	, @p_PurposeCode nvarchar(50)
	,@p_FromDate datetime
	, @p_ToDate datetime
	,@p_UserName nvarchar(50)
AS
BEGIN
    declare @p_TableReport table(
					DocEntry int
					, crDate datetime
					, sType nvarchar(100), 
					SyncUser nvarchar(100)
					,SyncDate datetime  		
					, TankCode nvarchar(500)
					,ProductCode nvarchar(200)
					,TankHeight numeric(18,4), 
					TankTemp numeric(18,4) ,
					PurposeCode nvarchar(200)
					,Purposename nvarchar(3000),
					Dens numeric(18,4)
					,VCF numeric(18,4)
					,WCF numeric(18,4), 
					Ltt numeric(18,2),
					VolumnL15 numeric(18,2),
					VolumnKG numeric(18,2)
					,Status nvarchar(20)
					,fromdate datetime
					,NhomBe  nvarchar(100)
				)
	Insert into @p_TableReport (	
							DocEntry
							, crDate 
							, sType , 
							SyncUser 
							,SyncDate   		
							, TankCode 
							,ProductCode
							,TankHeight, 
							TankTemp,
							PurposeCode
							,Purposename ,
							Dens 
							,VCF
							,WCF , 
							Ltt ,
							VolumnL15 ,
							VolumnKG 
							,Status, fromdate , NhomBe )
	select a.DocEntry as [Số giao dịch], a.crDate as [Ngày tháng]  , sType, 
						a.SyncUser as [User đồng bộ], a.SyncDate as [Ngày đồng bộ SAP]  , 
					b.TankCode as [Bồn xuất], b.ProductCode as [Mã hàng],  TankHeight as [Chiều cao dầu], 
					TankTemp as [Nhiệt độ],	b.PurposeCode as [Mã MDD], b.Purposename as [Tên MDD],
					b.Dens as [Tỷ trọng], b.VCF, b.WCF, b.Ltt,
					 B.VolumnL15 as L15,b.VolumnKG as KG 
					 , case when isnull(b.X,'') ='Y' then a.Status  else '' end as Status
					 , a.fromdate, b.NhomBeXuat 
					 from dbo.ztblTankHeaderImp  a with(nolock ),
					  dbo.ztblTankLineImp_v b with(nolock)
				where a.TankHeaderCode =b.TankHeaderCode
						and  a.DocEntry =  isnull(@p_DocEntry,a.DocEntry)
						and   b.PurposeCode =  isnull(@p_PurposeCode, b.PurposeCode)					
					and a.FromDate   >=  isnull(@p_FromDate,a.FromDate) 
					and a.FromDate <=  isnull(@p_ToDate,a.FromDate) 
					and a.sType ='A'
	union all

	select a.DocEntry as [Số giao dịch], a.crDate as [Ngày tháng]  , sType, 
						a.SyncUser as [User đồng bộ], a.SyncDate as [Ngày đồng bộ SAP]  , 
					b.TankCode as [Bồn xuất], b.ProductCode as [Mã hàng],  TankHeight as [Chiều cao dầu], 
					TankTemp as [Nhiệt độ],	b.PurposeCode as [Mã MDD], b.Purposename as [Tên MDD],
					b.Dens as [Tỷ trọng], b.VCF, b.WCF, b.Ltt,
					 B.VolumnL15 as L15,b.VolumnKG as KG 
					 , case when isnull(b.X,'') ='Y' then a.Status  else '' end as Status
					 , b.crDate, b.NhomBeXuat 
					 from dbo.ztblTankHeaderImp  a with(nolock ),
					  dbo.ztblTankLineImp_v b with(nolock)
				where a.TankHeaderCode =b.TankHeaderCode
						and  a.DocEntry =  isnull(@p_DocEntry,a.DocEntry)
						and   b.PurposeCode =  isnull(@p_PurposeCode, b.PurposeCode)					
					and b.crDate   >=  isnull(@p_FromDate,b.crDate) 
					and b.crDate <=  isnull(@p_ToDate,b.crDate) 
					and a.sType ='M'

	
	

	if @p_Client ='ALL'
		begin
			select DocEntry as [Số giao dịch],TankCode as [Mã bể], ProductCode as [Mã hàng], fromdate  as [Thời gian đo bồn], 
			 TankHeight as [Chiều cao dầu], TankTemp as [Nhiệt độ],	PurposeCode as [Mã MDD], Purposename as [Tên MDD],
					Dens as [Tỷ trọng], Ltt, VCF, VolumnL15 as L15,	WCF,VolumnKG as KG ,
					 case when isnull( Status,'')  ='S' then N'Đồng bộ lên SAP' else N'Chưa đồng bộ' end as [Trạng thái]
					  , case when  sType='A' then N'Tự động' else N'Nhập tay' end as [Loại],crDate as [Thời gian tạo giao dịch] , 
										SyncUser as [User đồng bộ], SyncDate as [Ngày đồng bộ SAP]  , NhomBe as [Nhóm bể]
						 from @p_TableReport
									 order by TankCode, CrDate
					
		end
	else
		if @p_Client ='C'			
			begin
					select DocEntry as [Số giao dịch],TankCode as [Mã bể], ProductCode as [Mã hàng], fromdate  as [Thời gian đo bồn], 
						 TankHeight as [Chiều cao dầu], TankTemp as [Nhiệt độ],	PurposeCode as [Mã MDD], Purposename as [Tên MDD],
								Dens as [Tỷ trọng], Ltt, VCF, VolumnL15 as L15,	WCF,VolumnKG as KG ,
								 case when isnull( Status,'')  ='S' then N'Đồng bộ lên SAP' else N'Chưa đồng bộ' end as [Trạng thái]
									  , case when  sType='A' then N'Tự động' else N'Nhập tay' end as [Loại],crDate as [Thời gian tạo giao dịch] , 
														SyncUser as [User đồng bộ], SyncDate as [Ngày đồng bộ SAP]  , NhomBe as [Nhóm bể]
										 from @p_TableReport
											
							where  ( charindex (@p_Client,TankCode ,1) >0 or charindex ('D',TankCode ,1) >0)   order by TankCode, CrDate		
			end			
		else
			begin
					select DocEntry as [Số giao dịch],TankCode as [Mã bể], ProductCode as [Mã hàng], fromdate  as [Thời gian đo bồn], 
						 TankHeight as [Chiều cao dầu], TankTemp as [Nhiệt độ],	PurposeCode as [Mã MDD], Purposename as [Tên MDD],
								Dens as [Tỷ trọng], Ltt, VCF, VolumnL15 as L15,	WCF,VolumnKG as KG ,
								 case when isnull( Status,'')  ='S' then N'Đồng bộ lên SAP' else N'Chưa đồng bộ' end as [Trạng thái]
									  , case when  sType='A' then N'Tự động' else N'Nhập tay' end as [Loại],crDate as [Thời gian tạo giao dịch] , 
														SyncUser as [User đồng bộ], SyncDate as [Ngày đồng bộ SAP]  , NhomBe as [Nhóm bể]
										 from @p_TableReport
							where  charindex (@p_Client,TankCode ,1) >0   order by TankCode, CrDate		
						--	and a.Status ='S'
			end				
END
