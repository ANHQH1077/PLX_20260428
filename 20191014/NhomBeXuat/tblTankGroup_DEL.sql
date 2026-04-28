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
alter TRIGGER tblTankGroup_DEL
   ON tblTankGroup
   AFTER  DELETE
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
		   ,'D', tichhop
from deleted   

END
GO
