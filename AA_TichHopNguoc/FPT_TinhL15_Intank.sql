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
Create PROCEDURE FPT_TinhL15_Intank
	@p_SoLenh nvarchar(50)
AS
BEGIN
	declare @p_NhietDo decimal( 10,2)
	declare @TyTrong_15 decimal (6,4)
	declare @SoLuongThucXuat decimal (18,2)
	declare @TongL15 decimal (18,2)
	declare @L15 decimal (18,2)
	declare @Row_ID int
	declare @p_Inline nvarchar(50) 
	declare  @p_TableTmp table (
		Row_ID int
		,TyTrong_15 decimal (6,4)
		,SoLuongThucXuat decimal (18,2)
		--,SoLuongDuXuat decimal (18,2)
		,NhietDoTB decimal (10,2)
		,L15 decimal (18,2)
		,MaNgan nvarchar(10)
			)
			
	
	
	
	set @p_Inline='FALSE'
	
	set @p_Inline = (select KeyValue from SYS_CONFIG where upper( KeyCode)='E5')
	
	if isnull(@p_Inline,'N') ='Y'
		begin
			set  @p_Inline='TRUE'
		end
	else
		begin
			set  @p_Inline='FALSE'
		end
		
		
    insert into @p_TableTmp (MaNgan, Row_ID,TyTrong_15, SoLuongThucXuat, NhietDoTB)     
    select a.MaNgan,a.Row_ID, a.TyTrong_15, dbo.FPT_LaySoThucXuat ( (select top 1 mavanchuyen from tbllenhXuate5 where solenh=a.solenh)   
                             ,a.SoLuongThucXuat, a.SoLuongDuXuat,0) as SoLuongThucXuat , 
                        dbo.FPT_ROUNDNUMBER( (
                         
                         select  sum(NhietDo)/sum(LuongXuat) as NhietDo from (                         
                         
                         select  
                             isnull(NhietDo,0)  *  dbo.FPT_LaySoThucXuat ( (select top 1 mavanchuyen from tbllenhXuate5 where solenh=a.solenh)   
                             ,SoLuongThucXuat, SoLuongDuXuat,0)   as NhietDo  
                                                     ,dbo.FPT_LaySoThucXuat ( (select top 1 mavanchuyen from tbllenhXuate5 where solenh=a.solenh)   
                             ,SoLuongThucXuat, SoLuongDuXuat,0) as LuongXuat	  
                                                  from fpt_tbllenhxuatchitiete5_v a11 where solenh=@p_SoLenh
													--and a11.MaHangHoa=a.MaHangHoa 
                                                    and Row_id in (select a.Row_id from  FPT_tblLenhXuatChiTietE5_V  a,tblLenhXuatChiTietE5 b  
														 where  a.Row_ID=b.Row_ID and a.SoLenh=@p_SoLenh 
															  and  isnull(  b.FlagTankLine,0) =0 and   (   isnull(b.GST,0) <=0  
															  or  (@p_Inline ='FALSE' and isnull(b.GST,0) >=0  )
															  or  isnull( b.TYLE_TTE,0)  <=0
															  )  and a.MaHangHoa  in (select MaHangHoa from tblHangHoaE5))
                                                  
                                                  ) abc	  
                                               having sum(LuongXuat) <> 0 
                                               
                                               ) ,2) as NhietDo   
                                               
                     from FPT_tblLenhXuatChiTietE5_V  a,tblLenhXuatChiTietE5 b  
                     where  a.Row_ID=b.Row_ID and a.SoLenh=@p_SoLenh
                          and  isnull(  b.FlagTankLine,0) =0 and   (   isnull(b.GST,0) <=0  
                          or  (@p_Inline ='FALSE' and isnull(b.GST,0) >=0  )
                          or  isnull( b.TYLE_TTE,0)  <=0
                          )  and a.MaHangHoa  in (select MaHangHoa from tblHangHoaE5)
      
     update @p_TableTmp set L15= [dbo].[zzFPT_mdlQCI_CalculateQCI_NS]
										(
											SoLuongThucXuat, 
											'L',
											NhietDoTB, 
											TyTrong_15,
											'0201004', 
											'')
    
 
 
    --select * from @p_TableTmp 
    --return
    
    
    
    
    select  @p_NhietDo =NhietDoTB, @TyTrong_15=TyTrong_15
			,@SoLuongThucXuat= sum(SoLuongThucXuat)
			,@L15=sum(L15) from   @p_TableTmp
				group by NhietDoTB, TyTrong_15
    
    set @TongL15 = [dbo].[zzFPT_mdlQCI_CalculateQCI_NS]
										(
											@SoLuongThucXuat, 
											'L',
											@p_NhietDo, 
											@TyTrong_15,
											'0201004', 
											'')
    if isnull(@L15,0) <> isnull(@TongL15,0) and isnull(@TongL15,0) >0
		begin			
						update @p_TableTmp set L15 = L15 + ( @TongL15 - @L15) 
							where MaNgan  = (select min(MaNgan) from @p_TableTmp )				
		end
    
    DECLARE p_Cursor CURSOR FOR   
			select Row_ID, L15 from @p_TableTmp 
			
	OPEN p_Cursor  

	FETCH NEXT FROM p_Cursor   INTO @Row_ID, @L15

	WHILE @@FETCH_STATUS = 0  	
		begin
			update tbllenhxuatchitiete5 set gst=@L15 where Row_ID=@Row_ID
			FETCH NEXT FROM p_Cursor  INTO @Row_ID, @L15
		end
	--END   
	CLOSE p_Cursor
	DEALLOCATE p_Cursor
   
END
--GO
