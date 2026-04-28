/****** Object:  LinkedServer [LOCALSERVER]    Script Date: 05/07/2018 16:20:21 ******/
EXEC master.dbo.sp_addlinkedserver @server = N'LOCALSERVER', @srvproduct=N'SQLSERVER', @provider=N'SQLNCLI', @datasrc=N'10.0.1.20'
 /* For security reasons the linked server remote logins password is changed with ######## */
EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname=N'LOCALSERVER',@useself=N'False',@locallogin=NULL,@rmtuser=N'sa',@rmtpassword='########'

GO

EXEC master.dbo.sp_serveroption @server=N'LOCALSERVER', @optname=N'collation compatible', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'LOCALSERVER', @optname=N'data access', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'LOCALSERVER', @optname=N'dist', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'LOCALSERVER', @optname=N'pub', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'LOCALSERVER', @optname=N'rpc', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'LOCALSERVER', @optname=N'rpc out', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'LOCALSERVER', @optname=N'sub', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'LOCALSERVER', @optname=N'connect timeout', @optvalue=N'0'
GO

EXEC master.dbo.sp_serveroption @server=N'LOCALSERVER', @optname=N'collation name', @optvalue=null
GO

EXEC master.dbo.sp_serveroption @server=N'LOCALSERVER', @optname=N'lazy schema validation', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'LOCALSERVER', @optname=N'query timeout', @optvalue=N'0'
GO

EXEC master.dbo.sp_serveroption @server=N'LOCALSERVER', @optname=N'use remote collation', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'LOCALSERVER', @optname=N'remote proc transaction promotion', @optvalue=N'true'
GO


