
alter view  tblCongToNhomBe_V as select  MeterId,Valid_from,Valid_to,Bexuat,
TankGroup,TankGroup_Name,MaHangHoa,TenHangHoa,Push_TDH,Push_XTTD,User_Push_TDH,
Date_Push_TDH,User_Push_XTTD,Date_Push_XTTD,ID,'N' as CHECKUPD, 'N' as X 
, (select top 1 MaHangHoa_Scada  from tblMap_MaHangHoa b where b.MaHangHoa_Sap = a.MaHangHoa ) MaHangHoaTDH, TankValidfrom, TankValid_to
,IDLine
from  tblCongToNhomBe a


