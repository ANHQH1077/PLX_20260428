

ALTER VIEW [dbo].[FPT_LenhXuat_TongHop_v]
AS
SELECT        A.MaLenh, A.NgayXuat, A.SoLenh, A.MaDonVi, A.MaNguon, A.MaKho, A.MaVanChuyen, A.MaPhuongTien, A.NguoiVanChuyen, A.MaPhuongThucBan, A.TenPhuongThucBan, A.MaPhuongThucXuat, A.MaKhachHang, 
                         A.TenKhachHang, A.LoaiPhieu, A.Niem, A.LuongGiamDinh, A.NhietDoTaiTau, A.GhiChu, A.NgayHieuLuc, A.Status, A.Number, A.SoLenhSAP, b.LineID, b.TongXuat, b.TongDuXuat, b.MaHangHoa, b.DonViTinh, b.BeXuat, b.TableID, 
                         b.MeterId, c.SoLuongDuXuat, c.SoLuongThucXuat, c.ThoiGianDau, c.ThoiGianCuoi, c.Sl_llkebd, c.Sl_llkekt, c.HeSo_k, c.NhietDo, c.TyTrong_15, c.MaDanXuat, c.MaLoi, c.TrangThai, c.MaLuuLuongKe, c.MaEntry, c.DungTichNgan, 
                         c.MaTuDongHoa, c.Row_id, c.MaNgan, b.TenHangHoa,
                             (SELECT        TOP (1) SoTichKe
                               FROM            dbo.tblTichke AS b1
                               WHERE        (SoLenh = A.SoLenh) AND (MaNgan = c.MaNgan) AND (TableId = b.TableID)) AS MaTichKe, c.GST, A.NhaCungCap, A.Client, A.HTTG, A.Slog, c.GV_BASE, c.GST_BASE, c.GV_E, c.GST_E, c.AVG_CTL, A.NgayTichKe, 
                         A.SoHopDong, A.STO, b.DonGia, b.CurrencyKey, A.SelfShipping, A.MaTuyenDuong, b.L15, b.KG, b.VCF, b.WCF, b.NhietDo_BQGQ, b.D15_BQGQ, A.NhomBeXuat
FROM            dbo.FPT_tblLenhXuatE5_V AS A INNER JOIN
                         dbo.FPT_tblLenhXuat_HangHoaE5_V AS b ON A.SoLenh = b.SoLenh INNER JOIN
                         dbo.FPT_tblLenhXuatChiTietE5_V AS c ON b.TableID = c.H_TableID AND A.SoLenh = c.SoLenh
WHERE        (A.NgayXuat >= DATEADD(DAY, - 365, GETDATE()))
GO


