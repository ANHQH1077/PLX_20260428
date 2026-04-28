

/****** Script for SelectTopNRows command from SSMS  ******/
--drop view zPurpose_v
create view  [dbo].[zPurpose_v] as 
SELECT  [ID]
      ,[Code]
      ,[Name]
      ,[Status]
      ,[CreateDate]
      ,[SynDate]
      ,[SynUser], 'N'as CHECKUPD
  FROM [dbo].[zPurpose]
GO


