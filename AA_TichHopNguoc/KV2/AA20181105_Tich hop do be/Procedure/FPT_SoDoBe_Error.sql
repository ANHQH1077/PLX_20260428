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
CREATE PROCEDURE FPT_SoDoBe
	@p_FromDate datetime
	,@p_ToDate datetime
	,@p_Client nvarchar(50)
	,@p_Tank nvarchar(50)
	,@p_MDD nvarchar(50)  --Muc dich do
AS
BEGIN
	SELECT  a.TankCode as MSB, a.ProductCode  as MAHH,b.FromDate as NGAYDO, b.FromDate as GIODO
, PurposeName as  MUCDD, a.TankHeight as CCAODAU, TankTemp as NHIETDO, a.Dens as D15
,case when isnull(sType,'A') ='M' then N'Thủ công' else  N'Tự động' end as CHEDO,  a.*
  FROM [ztblTankLineImp] a with (nolock), ztblTankHeaderImp_v b
	where a.TankHeaderCode =b.TankHeaderCode
	
END
GO
