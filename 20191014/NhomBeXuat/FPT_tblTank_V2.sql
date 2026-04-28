

create VIEW [dbo].[FPT_tblTank_V2]
AS
--SELECT     dbo.tblTank.Name_nd, dbo.tblTank.Dens_nd, dbo.tblTank.Product_nd, dbo.tblHangHoa.TenHangHoa, 'N' AS CHECKUPD, LEFT(dbo.tblTank.Name_nd, 1) AS Client
--FROM         dbo.tblTank LEFT OUTER JOIN
--                      dbo.tblHangHoa ON dbo.tblTank.Product_nd = dbo.tblHangHoa.MaHangHoa
	SELECT     dbo.tblTank.Name_nd, dbo.tblTank.Dens_nd, dbo.tblTank.Product_nd, dbo.tblHangHoa.TenHangHoa, 'N' AS CHECKUPD, LEFT(dbo.tblTank.Name_nd, 1) AS Client
			, aa2.TankGroup , aa2.FromDate , aa2.ToDate 
				FROM         dbo.tblTank LEFT OUTER JOIN
									  dbo.tblHangHoa ON dbo.tblTank.Product_nd = dbo.tblHangHoa.MaHangHoa
							left join (select a1.Name_nd , a1.TankGroup , a1.FromDate , a1.ToDate  from tblTankGroup a1 ,  (
				select Name_nd, Max(isnull(FromDate,getdate())) as FromDate from tblTankGroup  group by Name_nd) a2 where a1.Name_nd =a2.Name_nd and isnull(a1.FromDate,getdate()) = a2.FromDate ) aa2
								on dbo.tblTank.Name_nd  = aa2.Name_nd 
GO


