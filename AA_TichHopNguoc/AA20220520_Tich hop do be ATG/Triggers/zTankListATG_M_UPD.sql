

-- =============================================
-- Author:		anhqh
-- Create date: 20150120
-- Description:	Trigger Insert
-- =============================================
create TRIGGER [dbo].[zTankListATG_M_UPD]
   ON  [dbo].[zTankListATG_M]
   FOR UPDATE
AS 
BEGIN
		INSERT INTO [zTankListATG_M_HIST]
           ([ID]
           ,[TankCode]
           ,[CrDate]
           ,[CrUser]
           ,[UpdDate]
           ,[UpdUser]
           ,[FromDate]
           ,[ToDate]
           ,UpdateDate 
           , UpdatedBy 
           ,  Createby 
           ,Product
           ,[sStatus]
           ,[dDate]
           )
     select   [ID]
           ,[TankCode]
           ,[CrDate]
           ,[CrUser]
           ,[UpdDate]
           ,[UpdUser]
           ,[FromDate]
           ,[ToDate]
            ,UpdateDate 
           , UpdatedBy 
           ,  Createby 
           ,Product
				   ,'U' as [sStatus]
				  -- ,[sUser]
				   ,getdate() as [dDate]			
		FROM inserted  
		
END


GO


