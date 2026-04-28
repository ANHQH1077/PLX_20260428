select distinct TableName, DatabaseScada from tblMap_cp order by DatabaseScada, TableName

alter table [KA_TDH_E5].dbo.Lenh_GH add CARDNUM nvarchar(150), CARDDATA nvarchar(150), MaPhuongTien nvarchar(150);
alter table [KATDHDB].dbo.KA_FILELUU add CARDNUM nvarchar(150), CARDDATA nvarchar(150), MaPhuongTien nvarchar(150);
alter table [KATDHDB].dbo.KA_LENH_GH add CARDNUM nvarchar(150), CARDDATA nvarchar(150), MaPhuongTien nvarchar(150);

alter table KB_TDH_E5.dbo.Lenh_GH add CARDNUM nvarchar(150), CARDDATA nvarchar(150), MaPhuongTien nvarchar(150);
alter table KBTDHDB.dbo.KB_FILELUU add CARDNUM nvarchar(150), CARDDATA nvarchar(150), MaPhuongTien nvarchar(150);
alter table KBTDHDB.dbo.KB_LENH_GH add CARDNUM nvarchar(150), CARDDATA nvarchar(150), MaPhuongTien nvarchar(150);

alter table KC_TDH_E5.dbo.Lenh_GH add CARDNUM nvarchar(150), CARDDATA nvarchar(150), MaPhuongTien nvarchar(150);
alter table KCTDHDB.dbo.KC_FILELUU add CARDNUM nvarchar(150), CARDDATA nvarchar(150), MaPhuongTien nvarchar(150);
alter table KCTDHDB.dbo.KC_LENH_GH add CARDNUM nvarchar(150), CARDDATA nvarchar(150), MaPhuongTien nvarchar(150);