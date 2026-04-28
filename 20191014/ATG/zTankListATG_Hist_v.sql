

ALTER view  [dbo].[zTankListATG_Hist_v] as select a.*, b.TenHangHoa, 'N' as CHECKUPD
 from zTankListATG_Hist a , 
tblHangHoa b where a.Product =b.MaHangHoa


GO

