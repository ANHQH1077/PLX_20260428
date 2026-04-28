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
alter PROCEDURE FPT_DeleteDataSMO
	@p_PhuongTien nvarchar(50)
	--,@p_SoChuyen int	
	,@p_User  nvarchar(50)
	,@p_ID int
AS
BEGIN
	
	-------
	declare @p_LenhTK int
	declare @p_Date datetime 
	
	select  top 1 @p_Date = NgayVaoKho from  tblSMO_INT   where  id =@p_ID
	set @p_LenhTK =0
	--Kiem trta neu lenh da In tich ke thi out
	select @p_LenhTK=count(*) from tbllenhxuatE5 b with (nolock) where 
		exists (select 1 from tblSMO_INT a with (nolock)  where a.SoLenh=b.SoLenh				
						and  a.MaPhuongTien =@p_PhuongTien	and TrangThai_SMO ='99' ----and a.NgayVaoKho  =@p_Date 	
										 )
		and isnull(b.Status,'1') in ('3','31','4','5')
		
	if isnull(@p_LenhTK,0) >0
		begin
			select 1 as Error , N'Lệnh đã in tích kê' as sError, 0 as sQuesion
			return
		end 
	----Kiem tra lenh da co trong httg va chua in tich ke
	--delete from tbllenhxuate5 where SoLenh in  (select SoLenh  from tblSMO_INT a with (nolock) 
	--											-- where  Convert(date,NgayVaoKho)=convert(date, getdate()) 
	--											--	and a.MaPhuongTien =@p_PhuongTien
	--											--	and a.SoChuyen = @p_SoChuyen  
	--											where a.id=@p_iD
	--												  )
	--			and isnull(Status,'1') in ('1','2') 
				
				
		declare @p_TblSoLenh table (SoLenh nvarchar(50))
		insert into 	@p_TblSoLenh  select SoLenh from 	tblSMO_INT where   MaPhuongTien =@p_PhuongTien	  and TrangThai_SMO ='99'		
	
	    delete from tblLenhXuatChiTietE5  where 
         exists (select 1 from tblLenhXuat_HangHoaE5  where tableid=  tblLenhXuatChiTietE5.tableid 
				 and SoLenh IN (select SoLenh from tbllenhxuate5 h with (nolock) where   Status ='1'    and SoLenh in (select SoLenh from @p_TblSoLenh)  ) )
		
		delete from tblLenhXuat_HangHoaE5  where SoLenh IN (select SoLenh from tbllenhxuate5 h with (nolock) where   Status ='1'    and SoLenh in (select SoLenh from @p_TblSoLenh)  )       
       delete from tblLenhXuatE5  where SoLenh in (select SoLenh from @p_TblSoLenh)  and Status ='1'  
              
		update tblSMO_INT set  TrangThai_SMO=1 where   MaPhuongTien =@p_PhuongTien	  and TrangThai_SMO ='99'
			
    select 0 as Error , N'Done' as sError, 0 as sQuesion
                    
END
GO
