
ALTER VIEW [dbo].[zTankListATG_AM_V] AS SELECT     ID, TankCode, Product, CrDate, CrUser, UpdDate,UpdUser, FromDate, ToDate, 'N' AS CHECKUPD , NhomBeXuat  FROM         dbo.zTankListATG_AM  
GO

