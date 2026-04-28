
--select * from [zTankListATG_Hist_v]

ALTER view  [dbo].[zTankListATG_M_Hist_v] as select a.*, b.TenHangHoa, 'N' as CHECKUPD
 from zTankListATG_M_Hist a , 
tblHangHoa b where a.Product =b.MaHangHoa

