
create view  [dbo].[zTankListATG_v] as select a.*, b.TenHangHoa, 'N' as CHECKUPD from zTankListATG a , 
tblHangHoa b where a.Product =b.MaHangHoa
GO


