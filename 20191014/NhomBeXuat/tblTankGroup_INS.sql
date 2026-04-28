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
create TRIGGER tblTankGroup_INS
   ON tblTankGroup
   AFTER  INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



INSERT INTO [dbo].[tblTankGroup_HIST]
           ([id]
           ,[Name_nd]
           ,[Product_nd]
           ,[TankGroup]
           ,[FromDate]
           ,[ToDate]
           ,[CreateUser]
           ,[CreateDate]
           ,[UpdateUser]
           ,[UpdateDate]
           ,[ID_SAP]
           ,[sType], tichhop
           )
   select  [id]
           ,[Name_nd]
           ,[Product_nd]
           ,[TankGroup]
           ,[FromDate]
           ,[ToDate]
           ,[CreateUser]
           ,[CreateDate]
           ,[UpdateUser]
           ,[UpdateDate]
           ,[ID_SAP]
		   ,'I', tichhop
from inserted  

END
GO
