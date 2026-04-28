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
create PROCEDURE BienBanDoBe_ALL
	@p_Value nvarchar(max)
AS
BEGIN
	select   aa.CrDate as Ngay,aa.CrDate as Gio, aa.TankCode as Be, aa.ProductCode as MaHangHoa,
					 aa.TenHangHoa, aa.TankHeight as ChieuCao, aa.TankTemp as NhietDo , aa.PurposeCode as MaMDD, 
					 aa.PurposeName as TenMDD, bb.DocEntry   as SoGD from  dbo.ztblTankLineImp_v aa, ztblTankHeaderImp bb 
			  where aa.TankHeaderCode =bb.TankHeaderCode  --and convert(date,aa.CrDate ) =convert(date,@ToDate)			   
					 and aa.X='Y' and  charindex (',' +  convert(nvarchar(20),bb.DocEntry) + ',' ,',' + @p_Value + ',',1) >0	
					 

	--if @Client <> ''
	--	begin
	--		if isnull(@Client,'') ='C'
	--			begin
	--				select   aa.CrDate as Ngay,aa.CrDate as Gio, aa.TankCode as Be, aa.ProductCode as MaHangHoa,
	--						 aa.TenHangHoa, aa.TankHeight as ChieuCao, aa.TankTemp as NhietDo , aa.PurposeCode as MaMDD, 
	--						 aa.PurposeName as TenMDD, bb.DocEntry as SoGD from  dbo.ztblTankLineImp_v aa, ztblTankHeaderImp bb 
	--				  where aa.TankHeaderCode =bb.TankHeaderCode  
	--				  --and convert(date,aa.CrDate ) =convert(date,@ToDate)			   
	--						 and aa.X='Y' 
	--						--and (  aa.TankCode like 'C%' or 
	--						--			 aa.TankCode like 'D%' or  aa.TankCode like 'OD%'   or  aa.TankCode like 'OC%'  )
	--			end
	--		else if isnull(@Client,'') ='A'
	--			begin
	--				select   aa.CrDate as Ngay,aa.CrDate as Gio, aa.TankCode as Be, aa.ProductCode as MaHangHoa,
	--						 aa.TenHangHoa, aa.TankHeight as ChieuCao, aa.TankTemp as NhietDo , aa.PurposeCode as MaMDD, 
	--						 aa.PurposeName as TenMDD, bb.DocEntry  as SoGD from  dbo.ztblTankLineImp_v aa, ztblTankHeaderImp bb 
	--				  where aa.TankHeaderCode =bb.TankHeaderCode  --and convert(date,aa.CrDate ) =convert(date,@ToDate)			   
	--						 and aa.X='Y' 	
	--						--and (  aa.TankCode like 'A%' or aa.TankCode like 'OA%'  )
	--			end	
						
	--		else
	--			begin
	--				select   aa.CrDate as Ngay,aa.CrDate as Gio, aa.TankCode as Be, aa.ProductCode as MaHangHoa,
	--						 aa.TenHangHoa, aa.TankHeight as ChieuCao, aa.TankTemp as NhietDo , aa.PurposeCode as MaMDD, 
	--						 aa.PurposeName as TenMDD, bb.DocEntry  as SoGD from  dbo.ztblTankLineImp_v aa, ztblTankHeaderImp bb 
	--				  where aa.TankHeaderCode =bb.TankHeaderCode  --and convert(date,aa.CrDate ) =convert(date,@ToDate)			   
	--						 and aa.X='Y' 	
	--							--and (  aa.TankCode like 'B%' or aa.TankCode like 'OB%'  )
	--			end			
					
	--	end
	--else
	--	begin
	--		select   aa.CrDate as Ngay,aa.CrDate as Gio, aa.TankCode as Be, aa.ProductCode as MaHangHoa,
	--				 aa.TenHangHoa, aa.TankHeight as ChieuCao, aa.TankTemp as NhietDo , aa.PurposeCode as MaMDD, 
	--				 aa.PurposeName as TenMDD, bb.DocEntry   as SoGD from  dbo.ztblTankLineImp_v aa, ztblTankHeaderImp bb 
	--		  where aa.TankHeaderCode =bb.TankHeaderCode  --and convert(date,aa.CrDate ) =convert(date,@ToDate)			   
	--				 and aa.X='Y' ;			  
	--	end

END
GO
