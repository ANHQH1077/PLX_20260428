

alter view [dbo].[tblTankGroup_V] as 
SELECT a.id
      ,a.Name_nd
      ,a.Product_nd
	  ,b.TenHangHoa
      ,a.TankGroup
      ,a.FromDate
      ,a.ToDate
      ,a.CreateUser
      ,a.CreateDate
      ,a.UpdateUser
      ,a.UpdateDate
      ,a.ID_SAP, 'N' as CHECKUPD, a.TichHop
  FROM dbo.tblTankGroup a, tblHangHoa b where a.Product_nd = b.MaHangHoa



GO


