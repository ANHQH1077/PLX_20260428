
/****** Script for SelectTopNRows command from SSMS  ******/

ALTER view [dbo].[tblTankBatchs_v] as 
SELECT a.[ID]
      ,[TankCode]
      ,[BatchNum]
      ,[Add_Content]
      ,[CreateDate]
      ,[CrUser]
      ,[UpdDate]
      ,[UpdUser]
      ,[Desc]
      , b.Product_nd
      ,'N' as CHECKUPD
	  , a.SDA_Amount
  FROM [dbo].[ztblTankBatchs] A, tblTank B
	where TankCode =b.Name_nd
GO  -- alter table ztblTankBatchs add SDA_Amount nvarchar(50)


