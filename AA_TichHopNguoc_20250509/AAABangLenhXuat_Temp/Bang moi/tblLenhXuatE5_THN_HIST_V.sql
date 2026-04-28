

alter  view tblLenhXuatE5_THN_HIST_V as 
select a.SoLenh, a.sDesc, a.CreateDate, b.NgayXuat,c.TenKhachHang ,  b.MaPhuongTien, b.NguoiVanChuyen
	from tblLenhXuatE5_THN_HIST a left join  tblLenhXuatE5 b on a.solenh =b.solenh
		left join tblKhachHang c on b.MaKhachHang =c.MaKhachHang