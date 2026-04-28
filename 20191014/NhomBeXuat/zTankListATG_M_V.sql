
/****** Script for SelectTopNRows command from SSMS  ******/
ALTER VIEW [dbo].[zTankListATG_M_V]
AS
SELECT     ID, TankCode, Product, CrDate, CrUser, UpdDate, UpdUser, FromDate, ToDate, 'N' AS CHECKUPD, a.NhomBeXuat
FROM         dbo.zTankListATG_M AS A
GO


