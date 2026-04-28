create view fpt_tblPhuongThucXuat_v

as Select  TOP (100) PERCENT  MaPhuongThucXuat, VTWEG ,BWART, TenPhuongThucXuat from tblPhuongThucXuat 
order by  VTWEG ,BWART