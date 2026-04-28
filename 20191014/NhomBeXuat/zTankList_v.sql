

ALTER view [dbo].[zTankList_v] as  select *
	, (select top 1 TankGroup  from tblTankGroup where  getdate() >= isnull( FromDate, getdate()-1)  and getdate ()  <=  isnull(ToDate,getdate() +1)  and Name_nd =a.Name_nd  and Product_nd = a.Product_nd )  as NhomBeXuat
	 from FPT_tblTank_V a where not exists (select 1 from zTankListATG b where  a.Name_nd=b.TankCode )
	


GO


