

ALTER VIEW [dbo].[FPT_tblLenhXuatE5_V]
AS
SELECT     A.MaLenh, A.NgayXuat, A.SoLenh, A.MaDonVi, A.MaNguon,
                          (SELECT     TOP (1) TenNguon
                            FROM          dbo.tblNguon AS a1
                            WHERE      (MaNguon = A.MaNguon)) AS TenNguon, A.MaKho,
                          (SELECT     TOP (1) TenKho
                            FROM          dbo.tblKho
                            WHERE      (MaKho = A.MaKho)) AS TenKho, A.MaVanChuyen,
                          (SELECT     TOP (1) TenVanChuyen
                            FROM          dbo.tblVanChuyen
                            WHERE      (MaVanChuyen = A.MaVanChuyen)) AS TenMaVanChuyen,
                          (SELECT     TOP (1) TenVanChuyen
                            FROM          dbo.tblVanChuyen AS tblVanChuyen_1
                            WHERE      (MaVanChuyen = A.MaVanChuyen)) AS Expr1, A.MaPhuongTien, A.NguoiVanChuyen, A.MaPhuongThucBan,
                          (SELECT     TOP (1) TenPhuongThucBan
                            FROM          dbo.tblPhuongThucBan
                            WHERE      (MaPhuongThucBan = A.MaPhuongThucBan)) AS TenPhuongThucBan, A.MaPhuongThucXuat, A.MaKhachHang,
                          (SELECT     TOP (1) TenKhachHang
                            FROM          dbo.tblKhachHang
                            WHERE      (MaKhachHang = A.MaKhachHang)) AS TenKhachHang, A.LoaiPhieu, A.Niem, A.LuongGiamDinh, A.NhietDoTaiTau, A.GhiChu, A.NgayHieuLuc, RTRIM(LTRIM(A.Status)) AS Status, 
                      A.Number, A.Createby, A.UpdatedBy, A.CreateDate, A.UpdateDate, A.SoLenhSAP, CASE WHEN LoaiPhieu = 'V144' THEN 'N' ELSE 'Y' END AS ChuyenVanChuyen, A.Client, A.HTTG, A.Approved, 
                      A.User_Approve, A.Date_Approve, A.EditApprove, A.NhaCungCap,
                          (SELECT     Name
                            FROM          dbo.FPT_TrangThaiLenh_V AS a2
                            WHERE      (Status = RTRIM(LTRIM(A.Status)))) AS Status_Name, 'N' AS CHECKUPD,
                          (SELECT     TOP (1) SoTichKe
                            FROM          dbo.tblTichke AS B
                            WHERE      (SoLenh = A.SoLenh)) AS SoTichKe, A.AppDesc, A.Slog, A.NgayHetHieuLuc, A.NgayTichKe, A.STO, A.NguoiDaiDien, b.TenPhuongThucXuat, c.TenNhaCungCap, A.Tax, A.PaymentMethod, 
                      d.NoiDung AS PhuongThucThanhToan, A.Term, e.GhiChu AS ThoiHanThanhToan, A.MaTuyenDuong, g.DGTuyenDuong AS TenTuyenDuong, A.MaKhoNhap, h.TenKho AS TenKhoNhap, A.SoHopDong, 
                      A.NgayHopDong, A.TyGia, A.SoTKHQNhap, A.SoTKHQXuat, A.SelfShipping, A.PriceGroup, pg.PriceGroupName, A.Inco1, A.Inco2, A.DiemTraHang, A.XuatHangGui, A.DischargePoint, 
                      A.DesDischargePoint, A.CardNum, A.CardData, A.Prcing, A.SO_POType, A.LXLoai, A.LXPhieu, A.DOCT, A.So_TKTX, A.Ngay_TKTX
					  , a.NhomBeXuat 
FROM         dbo.tblLenhXuatE5 AS A WITH (Nolock) LEFT OUTER JOIN
                      dbo.tblPhuongThucXuat AS b WITH (Nolock) ON b.MaPhuongThucXuat = A.MaPhuongThucXuat AND b.VTWEG = A.MaPhuongThucBan AND ISNULL(b.BSART, N'') = ISNULL(A.BSART, N'') 
                      LEFT OUTER JOIN
                      dbo.tblNhaCungCap AS c WITH (Nolock) ON c.MaNhaCungCap = A.NhaCungCap LEFT OUTER JOIN
                      dbo.tblPhuongThucThanhToan AS d WITH (Nolock) ON d.MaPhuongThuc = A.PaymentMethod LEFT OUTER JOIN
                      dbo.tblThoiHanThanhToan AS e WITH (Nolock) ON e.TermKey = A.Term LEFT OUTER JOIN
                      dbo.tblGiaoNhan AS g WITH (Nolock) ON g.MaTuyenDuong = A.MaTuyenDuong AND g.DiemDen = A.DischargePoint LEFT OUTER JOIN
                      dbo.tblKho AS h WITH (Nolock) ON h.MaKho = A.MaKhoNhap LEFT OUTER JOIN
                      dbo.tblPriceGroup AS pg WITH (nolock) ON pg.PriceGroup = A.PriceGroup
GO


