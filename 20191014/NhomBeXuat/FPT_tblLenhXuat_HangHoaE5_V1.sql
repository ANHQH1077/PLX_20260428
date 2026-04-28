
ALTER VIEW [dbo].[FPT_tblLenhXuat_HangHoaE5_V1]
AS
SELECT        A.LineID, A.MaLenh, A.NgayXuat, A.SoLenh, A.TongXuat, A.TongDuXuat, A.MaHangHoa, A.TenHangHoa, A.DonViTinh, A.BeXuat, A.TableID, A.MeterId, A.Createby, A.UpdatedBy, A.CreateDate, A.UpdateDate, A.CHECKUPD, 
                         A.QCI_KG, A.QCI_NhietDo, A.QCI_TyTrong, dbo.FPT_TrangThaiLenh_V.Name AS Status, b.MaVanChuyen, CASE WHEN b.NgayTichKe IS NULL THEN CONVERT(date, getdate()) ELSE b.NgayTichKe END AS NgayTichKe, 
                         b.NhomBeXuat
FROM            dbo.FPT_tblLenhXuat_HangHoaE5_V AS A INNER JOIN
                         dbo.tblLenhXuatE5 AS b WITH (nolock) ON A.SoLenh = b.SoLenh INNER JOIN
                         dbo.FPT_TrangThaiLenh_V ON b.Status = dbo.FPT_TrangThaiLenh_V.Status

