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
alter PROCEDURE CongTo_NhomBe_Kiemtra 
	 @p_MeterId nvarchar(50)
	,@p_FromDate datetime
	,@p_ToDate datetime
	,@p_Tank nvarchar(20)
	,@p_TankGroup nvarchar(20)
	,@p_TankFromDate datetime
	,@p_TankToDate datetime,
	@p_IDLine int = null
AS
BEGIN
	
	declare @p_Table table  (nNumber int, sDesc nvarchar(2000))	

	--insert into  @p_Table (nNUmber,  sDesc)
	--	select top 1  1 as nNumber,N'Công tơ ' + @p_MeterId +  N': Ngày hiệu lực phải nằm trong khoảng hiệu lực của bể xuất.'  as sDesc  
	--		from  tblCongToNhomBe_TDH  where Meterid = @p_MeterId  
	--			and  (     Valid_to not between TankValidFrom and  TankValid_to    
	--					or    Valid_From not between TankValidFrom and  TankValid_to  )
	--			and isnull( IDLINE  ,0) = isnull(@p_IDLine,-1)
	--	union all
	--	select top 1  1 as nNumber, N'Công tơ ' + @p_MeterId +  N': Ngày hiệu lực phải nằm ngoài hết hiệu lực với bể trước.'  as sDesc  
	--		from  tblCongToNhomBe_TDH  where Meterid = @p_MeterId  and  ((Valid_From <=  @p_FromDate  and @p_FromDate <=Valid_to) 
	--					or (Valid_to>=  @p_FromDate  and Valid_to <= @p_ToDate ) )
	--			and isnull( IDLINE  ,0) <> isnull(@p_IDLine,-1)
	select  nNUmber,  sDesc  from @p_Table
	return
END
GO
