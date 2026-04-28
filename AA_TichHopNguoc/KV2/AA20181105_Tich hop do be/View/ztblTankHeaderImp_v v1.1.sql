

ALTER VIEW [dbo].[ztblTankHeaderImp_v]
AS
SELECT     dbo.ztblTankHeaderImp.TankHeaderCode, dbo.ztblTankHeaderImp.CreateDate, dbo.ztblTankHeaderImp.FromDate, dbo.ztblTankHeaderImp.ToDate, dbo.ztblTankHeaderImp.Client, 
                      dbo.ztblTankHeaderImp.Tankcode, dbo.ztblTankHeaderImp.PurposeCode, dbo.zPurpose.Name as PurposeName, dbo.ztblTankHeaderImp.Status, dbo.ztblTankHeaderImp.CreateUser, 
                      dbo.ztblTankHeaderImp.DocEntry
                      , dbo.ztblTankHeaderImp.sType, ztblTankHeaderImp.crDate
                  , case when ztblTankHeaderImp.sType ='A' then    N'Thông tin ATG' else  N'Nhập tay' end as sTypeName
                     
FROM         dbo.ztblTankHeaderImp LEFT OUTER JOIN
                      dbo.zPurpose ON dbo.ztblTankHeaderImp.PurposeCode = dbo.zPurpose.Code


GO


