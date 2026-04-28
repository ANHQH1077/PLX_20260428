
Create view [dbo].[zTankList_v] as  select * from FPT_tblTank_V a 
where not exists (select 1 from zTankListATG b where  a.Name_nd=b.TankCode )
	

GO


