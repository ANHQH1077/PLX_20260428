

--select * from [tblCongToNhomBe] 

--[dbo].[tblCongToNhomBe_V]
--TankValidfrom, TankValid_to

alter table [dbo].[tblCongToNhomBe] add TankValidfrom datetime ,TankValid_to datetime ;
alter table [dbo].tblCongToNhomBe_Hist add TankValidfrom datetime ,TankValid_to datetime ;