-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
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
create TRIGGER dbo.ztblTankLineImp_UPD
   ON  dbo.ztblTankLineImp
   for  update 
AS 
BEGIN
	INSERT INTO [dbo].[ztblTankLineImp_Hist]
           ([ID]
           ,[CreateDate]
           ,[CrDate]
           ,[TankCode]
           ,[ProductCode]
           ,[TankHeight]
           ,[TankTemp]
           ,[PurposeCode]
           ,[SynDate]
           ,[SynUser]
           ,[SAPSynStatus]
           ,[SAPSynUser]
           ,[SAPSynDate]
           ,[Client]
           ,[Dens]
           ,[VolumnL]
           ,[VCF]
           ,[VolumnL15]
           ,[VolumnKG]
           ,[Description]
           ,[Status]
           ,[X]
           ,[TankHeaderCode]
           ,[Ltt]
           ,[TankMap]
           ,[WCF]
           ,[SyncDate1]
           ,[SyncUser1]
           ,[SyncStatus1]
           ,[SyncSDesc1]
           ,[sStatus]
           --,[sUser]
           ,[dDate])
     SELECT  [ID]
           ,[CreateDate]
           ,[CrDate]
           ,[TankCode]
           ,[ProductCode]
           ,[TankHeight]
           ,[TankTemp]
           ,[PurposeCode]
           ,[SynDate]
           ,[SynUser]
           ,[SAPSynStatus]
           ,[SAPSynUser]
           ,[SAPSynDate]
           ,[Client]
           ,[Dens]
           ,[VolumnL]
           ,[VCF]
           ,[VolumnL15]
           ,[VolumnKG]
           ,[Description]
           ,[Status]
           ,[X]
           ,[TankHeaderCode]
           ,[Ltt]
           ,[TankMap]
           ,[WCF]
           ,[SyncDate1]
           ,[SyncUser1]
           ,[SyncStatus1]
           ,[SyncSDesc1]
           ,'U' as [sStatus]
           --,[sUser]
           ,getdate() as [dDate] from inserted

END
GO
