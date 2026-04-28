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
-- Description:	<Description,,>  KiemTraCongto_DongboNhomBe 'B'
-- =============================================
alter PROCEDURE KiemTraCongto_DongboNhomBe
	@p_Client nvarchar(10)
AS
BEGIN
	declare @p_LoaiCongTo nvarchar(10)
	declare @p_Value nvarchar(max)
	if @p_Client ='A'	
		begin
			set @p_LoaiCongTo ='C1'
		end
	if @p_Client ='B'	
		begin
			set @p_LoaiCongTo ='C2'
		end
	if @p_Client ='C'	
		begin
			set @p_LoaiCongTo ='C3'
		end
	 set @p_Value =(select 
						Meterid + ','
					from tblCongToNhomBe k 
						where   not   exists 
							(select 1 from 
							  (	select aa2.Name_nd, aa2.FromDate, aa2.ToDate, aa2.TankGroup from  tblTankGroup aa2 ,
								 (select Name_nd, TankGroup , Max(FromDate) as FromDate from  tblTankGroup group by Name_nd, TankGroup ) aa1
										where aa2.Name_nd =aa1.Name_nd and aa2.FromDate =aa1.FromDate  and aa2.TankGroup = aa1.TankGroup
								) k1
							where k.Bexuat = isnull(k1.Name_nd,'')
												and k.TankValidfrom = k1.FromDate and k.TankValid_to =k1.ToDate and k.TankGroup = k1.TankGroup  )
								and substring(Meterid,1,2) =@p_LoaiCongTo
						for XML PATH(''))
	if isnull(@p_Value,'') <> ''
		begin
			set @p_Value =substring(@p_Value,1,len(@p_Value)-1)
			select 1 as nNUmber, N'Công tơ (' + @p_Value + N') Hiệu lực của nhóm bể công tơ không đúng với hiệu lực nhóm bể đồng bộ.' as sDesc 
		end
	else
		begin
			select 0 as nNUmber, N'' as sDesc  where 1=0
		end
END
GO
