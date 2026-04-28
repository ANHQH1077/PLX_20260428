
CREATE VIEW [dbo].[ztblTankLineImp_v]
AS
SELECT a.ID, a.CreateDate, a.CrDate, a.TankCode, a.ProductCode, b.TenHangHoa, a.TankHeight, a.TankTemp, a.PurposeCode, c.Name AS PurposeName, a.SynDate, a.SynUser, a.SAPSynStatus, a.SAPSynUser, a.SAPSynDate, a.Client, a.Dens, 
                  a.VCF, a.VolumnL, a.VolumnL15, a.VolumnKG, a.Description, a.Status, a.X, a.TankHeaderCode, 'N' AS CHECKUPD, a.Ltt, a.TankMap, a.WCF, a.WaterHeight, a.BAREM_HEIGHT, a.BAREM_WATER
FROM     dbo.ztblTankLineImp AS a INNER JOIN
                  dbo.tblHangHoa AS b ON a.ProductCode = b.MaHangHoa LEFT OUTER JOIN
                  dbo.zPurpose AS c ON a.PurposeCode = c.Code
