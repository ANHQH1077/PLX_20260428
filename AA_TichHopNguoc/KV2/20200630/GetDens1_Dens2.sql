-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		anhqh
-- Create date: 20200702
-- Description:	Tinh lai Dens1 va Dens2 theo cong thuc SAP
-- =============================================

create function GetDens1_Dens2
(
	@p_DensIn decimal(10,4)
) returns nvarchar(50)
AS 
BEGIN
	declare @p_Value  nvarchar(20)
	declare @p_Int int 
	declare @p_Return nvarchar(10)
	declare @p_Step1 decimal(10,3) = 0.001
	declare @p_Step2 decimal(10,3) = 0.002
	declare @p_Dens1 decimal(10,4) =0.0
	declare @p_Dens2 decimal(10,4)= 0.0
	---declare @p_VCF decimal(10,4) 
	declare @p_Temp decimal(10,3) 
	declare @p_Dens decimal(10,3)
	declare @p_Floor int
	declare @p_ceiling int	

	set @p_Dens = round(@p_DensIn,3)
	
--	set @p_Return =convert(nvarchar(10), round(  @p_Dens*1000,0) )	
	set @p_Int =round(  @p_Dens*1000,0)
	set @p_Return =convert(nvarchar(10), @p_Int)	
	set @p_Temp =CONVERT(DECIMAL(10,0), @p_Return)
	
	
	
	set @p_Int =len(@p_return)	
	if @p_Int =1 or @p_Int =2  
		begin
			set @p_Dens1 = @p_Dens1
			set @p_Dens2 = @p_Dens + @p_Step2
		end
	else
		begin
			-----Kieem  tra 2 truong hop @p_VCF  Mod 2 =1  va  @p_VCF Mod 2  <> 1		
			set @p_ceiling = ceiling (@p_Temp/2.0)
			set @p_Floor = floor (@p_Temp/2.0)
			
			if @p_ceiling  <> @p_Floor  ---- truong hop không chia het cho 2  => mod 2 =1
				begin
						set @p_Dens1 = @p_Dens - @p_Step1
						set @p_Dens2 = @p_Dens + @p_Step1
				end
			else
				begin					
						set @p_Dens1 = @p_Dens
						set @p_Dens2 = @p_Dens + @p_Step2
				end	
		end
	---select  @p_Return, @p_Temp, @p_ceiling, @p_Floor, @p_VCF1, @p_VCF2
	---select  @p_VCF1 as  VCF1, @p_VCF2 as  VCF1
	return convert(nvarchar(10),@p_Dens1) + '-' +  convert(nvarchar(10),@p_Dens2)
END
GO

