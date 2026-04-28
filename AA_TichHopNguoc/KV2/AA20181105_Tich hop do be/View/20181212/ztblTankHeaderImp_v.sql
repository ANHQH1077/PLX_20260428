
CREATE VIEW [dbo].[ztblTankHeaderImp_v]
AS
SELECT     dbo.ztblTankHeaderImp.TankHeaderCode, dbo.ztblTankHeaderImp.CreateDate, dbo.ztblTankHeaderImp.FromDate, dbo.ztblTankHeaderImp.ToDate, dbo.ztblTankHeaderImp.Client, 
                      dbo.ztblTankHeaderImp.Tankcode, dbo.ztblTankHeaderImp.PurposeCode, dbo.zPurpose.Name AS PurposeName, dbo.ztblTankHeaderImp.Status, dbo.ztblTankHeaderImp.CreateUser, 
                      dbo.ztblTankHeaderImp.DocEntry, dbo.ztblTankHeaderImp.sType, dbo.ztblTankHeaderImp.crDate, 
                      CASE WHEN ztblTankHeaderImp.sType = 'A' THEN N'Thông tin ATG' ELSE N'Nhập tay' END AS sTypeName, dbo.ztblTankHeaderImp.App_User, dbo.ztblTankHeaderImp.App_Date, 
                      dbo.ztblTankHeaderImp.TankList
FROM         dbo.ztblTankHeaderImp LEFT OUTER JOIN
                      dbo.zPurpose ON dbo.ztblTankHeaderImp.PurposeCode = dbo.zPurpose.Code

