

CREATE VIEW [dbo].[tblChungTuLine_V]
AS
SELECT     SoLenh, TableID, LineID, MaHangHoa, TenHangHoa, DonViTinh, SoLuongDuXuat, SoLuongThucXuat, L15, KG, VCF, WCF, NhietDo, TyTrong, DonGia, TongTIen, KeyCode, MaVanChuyen, 
                      XITEC_OPTION, ChietKhau, NgayXuat, MaLenh, Row_ID, 'N' AS CHECKUPD, LoaiTien, SoLuong, LoaiChungTu, SoGhiNhan, SoLuong2, L15_2, KG_2
FROM         dbo.tblChungTuLine
GO

