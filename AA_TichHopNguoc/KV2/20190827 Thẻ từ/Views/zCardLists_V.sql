
create view zCardLists_V as
SELECT [CardNum]
      ,[sDesc]
      ,[FromDate]
      ,[ToDate]
      ,[Status]
      ,[Createby]
      ,[UpdatedBy]
      ,[CreateDate]
      ,[UpdateDate]
      ,'N' as CHECKUPD
	  ,CardData
	  ,ID
  FROM [zCardLists]
GO


