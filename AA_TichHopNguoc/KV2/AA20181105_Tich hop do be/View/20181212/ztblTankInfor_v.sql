

CREATE VIEW [dbo].[ztblTankInfor_v]
AS
SELECT     ID, TankCode, Plant, Description, MinHeight, MinVolume, SafeHeight, SafeVolume, Client, CreateDate, SynDate, SynUser, 'N' AS CHECKUPD

			, sType
FROM         dbo.ztblTankInfor

