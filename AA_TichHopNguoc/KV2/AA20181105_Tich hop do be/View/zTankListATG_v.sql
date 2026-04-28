
Create view [dbo].[zTankList_v] as  select * from FPT_tblTank_V a 
where not exists (select 1 from zTankListATG b where  a.Name_nd=b.TankCode )
	
GO

--drop view zTankListATG_v
create view  zTankListATG_v as select a.*, b.TenHangHoa, 'N' as CHECKUPD from zTankListATG a , 
tblHangHoa b where a.Product =b.MaHangHoa