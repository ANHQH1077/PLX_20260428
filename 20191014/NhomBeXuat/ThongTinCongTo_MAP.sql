
Create table tblCongToNhomBe(ID int IDENTITY(1,1) NOT NULL,MeterId	nvarchar(10),Valid_from	DateTime,Valid_to	DateTime,Bexuat	nvarchar(20),TankGroup	nvarchar(10),
TankGroup_Name	nvarchar(140),MaHangHoa	nvarchar(18),TenHangHoa	nvarchar(40),Push_TDH	nvarchar(2),Push_XTTD	nvarchar(2),User_Push_TDH	nvarchar(120)
,Date_Push_TDH	DateTime,User_Push_XTTD	nvarchar(120),Date_Push_XTTD	DateTime, CreateUser nvarchar(100), 
CreateDate datetime default getdate() , UpdateUser nvarchar(100), UpdateDate datetime default getdate() )

Create table tblCongToNhomBe_Hit(ID int IDENTITY(1,1) NOT NULL,MeterId	nvarchar(10),Valid_from	DateTime,Valid_to	DateTime,Bexuat	nvarchar(20),TankGroup	nvarchar(10),
TankGroup_Name	nvarchar(140),MaHangHoa	nvarchar(18),TenHangHoa	nvarchar(40),Push_TDH	nvarchar(2),Push_XTTD	nvarchar(2),User_Push_TDH	nvarchar(120)
,Date_Push_TDH	DateTime,User_Push_XTTD	nvarchar(120),Date_Push_XTTD	DateTime, CreateUser nvarchar(100), 
CreateDate datetime default getdate() , UpdateUser nvarchar(100), UpdateDate datetime default getdate() , sType nvarchar(2))
