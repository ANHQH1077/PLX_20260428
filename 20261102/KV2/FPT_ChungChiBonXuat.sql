-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
alter PROCEDURE FPT_ChungChiBonXuat  
	@p_BonXuat nvarchar(100)=null,
	@p_FormRequestCode nvarchar(100)=null
AS	
begin
			SELECT [NgayKTNhap]
				  ,[GioKTNhap]
				  ,[ThoiGianOnDinh]
				  ,[HovaTen]
				  ,[ChucDanh]
				  ,[FormRequestCode]
				  ,[titrong]
				  ,[dodandien]
				  ,[nhietdo]
				  ,[mausacsaybolt]
				  ,[kiemtrabengoai]
				  ,[khoxuat]
				  ,[FormRequestDate]
				  ,[MaHangHoa]
				  ,[TenHangHoa]
				  ,[SoBon]
				  ,[NiemGiao]
				  ,[titrongtren]
				  ,[titronggiua]
				  ,[titrongduoi]
				  ,[ghichutachlop]
				  ,[issplit]
				  ,[FormRequestCodeSeperationLayer]
				  ,[FormRequestDateSeperationLayer]
				  ,[CrUser]
				  ,[CrDate]
				  ,[UpdUser]
				  ,[UpdDate]
				  ,[ID]
				  ,[BatchNum] as BatNum
				  ,[SDA_Amount],
				  getdate() as NgayGio
			  FROM [dbo].[tblTank_Cert]
			  where SoBon = @p_BonXuat  and FormRequestCode = case when isnull(@p_FormRequestCode,'') ='' then FormRequestCode else @p_FormRequestCode end

	
END

