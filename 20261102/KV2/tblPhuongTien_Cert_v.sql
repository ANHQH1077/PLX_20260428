
create or alter view  tblPhuongTien_Cert_v as
SELECT [MaPhuongTien]
      ,[SoTichKe]
      ,convert(date,[NgayXuat]) as NgayXuat
	  , convert(nvarchar(20), convert(date,[NgayXuat])  , 103) as NgayXuat_D
      ,[FormRequestCode]
      ,[TiTrong]
      ,[DoDanDien]
      ,[NhietDo]
      ,[MauSacSayBolt]
      ,[KiemTraBenNgoai]
      ,[KhoXuat]
      ,[FromRequestDate]
      ,[MaHangHoa]
      ,[SoBon]
      ,[NiemGiao]
      ,[IsTankSplit]
      ,[TiTrongTren]
      ,[TiTrongGiua]
      ,[TiTrongDuoi]
      ,[FormRequestCodeSeperationLayer]
      ,[FormRequestDateSeperationLayer]
      ,[CrDate]
      ,[CrUser]
      ,[UpdDate]
      ,[UpdUser]
      ,[ID]
	  ,CertNo
  FROM [dbo].[tblPhuongTien_Cert]

GO


