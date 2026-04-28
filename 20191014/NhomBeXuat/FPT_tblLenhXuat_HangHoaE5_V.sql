

/****** Script for SelectTopNRows command from SSMS  ******/
ALTER VIEW [dbo].[FPT_tblLenhXuat_HangHoaE5_V]
AS
SELECT LineID, MaLenh, NgayXuat, SoLenh, TongXuat, TongDuXuat, MaHangHoa,
                      (SELECT TOP (1) TenHangHoa
                       FROM      dbo.tblHangHoa
                       WHERE   (MaHangHoa = dbo.tblLenhXuat_HangHoaE5.MaHangHoa)) AS TenHangHoa, DonViTinh, BeXuat, TableID, MeterId, Createby, UpdatedBy, CreateDate, UpdateDate, 'N' AS CHECKUPD, QCI_KG, QCI_NhietDo, QCI_TyTrong, 
                  DonGia, CurrencyKey, L15, KG, VCF, WCF, NhietDo_BQGQ, D15_BQGQ, NhomBeXuat 
FROM     dbo.tblLenhXuat_HangHoaE5 WITH (nolock)
WHERE  (NgayXuat >= DATEADD(DAY, - 365, GETDATE()))
GO


