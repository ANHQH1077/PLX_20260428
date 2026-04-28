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
alter PROCEDURE FPT_GetBaremTankATG_QCI
	@p_TankCode nvarchar(50)
	,@p_Temp  nvarchar(10)
	,@p_Den nvarchar(10)
	,@p_TankHeight numeric(16,0)
AS
BEGIN
	declare @p_VCF numeric(10,4)
	declare @p_WCF numeric(10,4)
	declare @p_Ltt numeric(16,0)
	declare @p_L15 numeric(16,0)
	declare @p_Kg numeric(16,0)
	declare @p_TankMap  nvarchar(50)
	declare @p_MaHangHoa  nvarchar(50)
	set @p_VCF =0.0
	
	select top 1 @p_MaHangHoa  = product_nd from tblTank where Name_nd=@p_TankCode
	if (isnull(@p_MaHangHoa,'') ='0301002' or  isnull(@p_MaHangHoa,'')  ='0301001' ) and isnull(@p_Temp,'') <>''
		begin	
			set @p_VCF = dbo.[zzFPT_mdlQCI_GetVCF_NS_E] (@p_Temp,@p_MaHangHoa) 
		end
		
	if isnull(@p_VCF,0) =0
		begin
				set @p_VCF= dbo.zzFPT_mdlQCI_GetVCF_NS (@p_Temp, @p_Den) 	
		end 
	
	
	set @p_VCF=isnull(@p_VCF,0)
	
	set @p_TankMap=( select top 1 case when isnull(Map_Sap1,'') <>'' then Map_Sap1 else Null end 
								from tblTank b  where Name_nd= @p_TankCode)  
	
	select top 1  @p_Ltt = VOLCON from ztbltankbarem with (nolock) 
											where SEQNR= case when isnull(@p_TankMap,'') <>'' then @p_TankMap else @p_TankCode end
											and   Lincon=isnull(@p_TankHeight,0)	
	set @p_Ltt=isnull(@p_Ltt,0)
	set @p_L15 = round(	@p_Ltt * @p_VCF	,0)
	set @p_WCF=(convert(numeric(10,4),@p_Den)  -0.0011 )	
	set @p_Kg =		round( (@p_WCF * @p_L15) ,0)	
	
	select @p_VCF as VCF, 	@p_WCF as Wcf, @p_Ltt as Ltt, @p_L15 as L15, @p_Kg as Kg, @p_TankMap as TankMap
											
END
GO
