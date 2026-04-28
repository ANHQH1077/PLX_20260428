declare @TableLenh table([MaLenh] [nvarchar](4)  NULL,
						[NgayXuat] [datetime] ,
						[SoLenh] [nvarchar](10) ,
						[MaTichKe] [nvarchar](4) ,
						[MaDonVi] [nvarchar](40),
						[MaNguon] [nvarchar](10),
						[MaKho] [nvarchar](40) NULL,
						[MaVanChuyen] [nvarchar](20) NULL,
						[MaPhuongTien] [nvarchar](20) NULL,
						[NguoiVanChuyen] [nvarchar](200) NULL,
						[MaPhuongThucBan] [nvarchar](50) NULL,
						[MaKhachHang] [nvarchar](50) NULL,
						[mangan] [nvarchar](3)  NULL,
						[MaHangHoa] [nvarchar](50) NULL,
						[DonViTinh] [nvarchar](10) NULL,
						[SoLuongDuXuat] [int] NULL,
						[SoLuongThucXuat] [int] NULL,
						[ThoiGianDau] [datetime] NULL,
						[ThoiGianCuoi] [datetime] NULL,
						[Sl_llkebd] [decimal](18, 2) NULL,
						[Sl_llkekt] [decimal](18, 2) NULL,
						[HeSo_k] [nvarchar](10) NULL,
						[NhietDo] [decimal](5, 2) NULL,
						[TyTrong_15] [decimal](6, 4) NULL,
						[Status] [varchar](2) NULL,
						[MaBeXuat] [nvarchar](20) NULL,
						[TenHangHoa] [nvarchar](200) NULL,
						[Thuy] [varchar](1)  NULL,
						[Sat] [varchar](1)  NULL,
						[Bo] [varchar](1)  NULL,
						[MaCongTo] [char](4) NULL,
						[PR_KEY] [nvarchar](20)  NULL,
						[LineID] [nvarchar](10)  NULL,
						[TableID] [nvarchar](10)  NULL,
						[LoaiPhieu] [nvarchar](200) NULL,
						[MaTuDongHoa] [varchar](20) NULL) 
declare @p_SoLenh varchar(20)										
DECLARE vendor_cursor CURSOR FOR   
		select SoLenh from tbllenhxuate5 b where 
				CHARINDEX ( SoLenh, '662AA00945' ,1) >0 and SoLenh<>'0'
				
OPEN vendor_cursor  

FETCH NEXT FROM vendor_cursor INTO  @p_SoLenh

WHILE @@FETCH_STATUS = 0  
    BEGIN
		insert into @TableLenh
		SELECT 
				  [MaLenh]			     
				 ,isnull(NgayTichKe,GETDATE()) as NgayXuat
				  ,a.SoLenh
				  ,MaTichKe
				  ,[MaDonVi]
				  ,[MaNguon]
				  ,[MaKho]
				  ,[MaVanChuyen]
				  ,[MaPhuongTien]
				  ,[NguoiVanChuyen]
				  ,[MaPhuongThucBan]  + '-' + [TenPhuongThucBan] as [MaPhuongThucBan]      
				  ,[MaKhachHang]+ '-' + [TenKhachHang] as [MaKhachHang]
				  , mangan
				   ,[MaHangHoa]
					,[DonViTinh]
					 ,convert(int,[SoLuongDuXuat])  as SoLuongDuXuat
				  ,convert(int,[SoLuongDuXuat])  as [SoLuongThucXuat] 
					,[ThoiGianDau]
				  ,[ThoiGianCuoi]
				   ,[Sl_llkebd]
				  ,[Sl_llkekt]
				   ,convert(nvarchar(10),[HeSo_k] ) as HeSo_k
				  ,[NhietDo]
				  ,[TyTrong_15]
				  ,Status
				  ,[BeXuat] as MaBeXuat
				  ,TenHangHoa 
				  ,case when MaVanChuyen='ZB' OR MaVanChuyen='ZM' then 'X' else '' end as  Thuy
				  ,case when MaVanChuyen='ZR'  then 'X' else '' end as  Sat
				  , case when MaVanChuyen='ZR' OR MaVanChuyen='ZT' then 'X' else '' end as  Bo
			    
				 , MeterId as MaCongTo
				   ,TableID as PR_KEY
				  ,LineID
				  ,TableID
				  ,LoaiPhieu
				,MaTuDongHoa   -----into AAAA_TMP
			  FROM  FPT_LenhXuat_TongHop_v a   where a.Solenh=@p_SoLenh
			FETCH NEXT FROM vendor_cursor INTO  @p_SoLenh	
    END
    
CLOSE vendor_cursor;  
DEALLOCATE vendor_cursor; 
select * from @TableLenh order by MaNgan  				
						
	 
	-- SELECT 
	 
	--  [MaLenh]
     
 --    ,isnull(NgayTichKe,GETDATE()) as NgayXuat
 --     ,a.SoLenh
 --     ,MaTichKe
 --     ,[MaDonVi]
 --     ,[MaNguon]
 --     ,[MaKho]
 --     ,[MaVanChuyen]
 --     ,[MaPhuongTien]
 --     ,[NguoiVanChuyen]
 --     ,[MaPhuongThucBan]  + '-' + [TenPhuongThucBan] as [MaPhuongThucBan]      
 --     ,[MaKhachHang]+ '-' + [TenKhachHang] as [MaKhachHang]
 --     , mangan
 --      ,[MaHangHoa]
 --       ,[DonViTinh]
 --        ,convert(int,[SoLuongDuXuat])  as SoLuongDuXuat
 --     ,convert(int,[SoLuongDuXuat])  as [SoLuongThucXuat] 
 --       ,[ThoiGianDau]
 --     ,[ThoiGianCuoi]
 --      ,[Sl_llkebd]
 --     ,[Sl_llkekt]
 --      ,convert(nvarchar(10),[HeSo_k] ) as HeSo_k
 --     ,[NhietDo]
 --     ,[TyTrong_15]
 --     ,Status
 --     ,[BeXuat] as MaBeXuat
 --     ,TenHangHoa 
 --     ,case when MaVanChuyen='ZB' OR MaVanChuyen='ZM' then 'X' else '' end as  Thuy
 --     ,case when MaVanChuyen='ZR'  then 'X' else '' end as  Sat
 --     , case when MaVanChuyen='ZR' OR MaVanChuyen='ZT' then 'X' else '' end as  Bo
    
 --    , MeterId as MaCongTo
 --      ,TableID as PR_KEY
 --     ,LineID
 --     ,TableID
 --     ,LoaiPhieu
 --   ,MaTuDongHoa   -----into AAAA_TMP
 -- FROM  FPT_LenhXuat_TongHop_v a   where 
	----a.solenh=b.solenh
	--exists  ( select 1 from @TableSoLenh b where 
	--			 b.SoLenh=a.SoLenh )
  
	----CHARINDEX ( SoLenh, @p_SoLenh ,1) >0 and SoLenh<>'0'
 ---- order by mangan