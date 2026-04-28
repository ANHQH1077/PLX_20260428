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
-- Author:		anhqh
-- Update date: 20180108
-- Description:	<Description,,>
-- =============================================
alter PROCEDURE FPT_TinhL15_Intank
	@p_SoLenh nvarchar(50)
AS
BEGIN
	declare @p_NhietDo decimal( 10,2)
	declare @TyTrong_15 decimal (6,6)
	declare @SoLuongThucXuat decimal (18,2)
	declare @TongL15 decimal (18,2)
	declare @L15 decimal (18,2)
	declare @L15_H decimal (18,2)
	declare @KG decimal (18,2)
	declare @Row_ID int
	declare @p_Inline nvarchar(50) 
	declare @VCF decimal (6,6)
	declare @WCF decimal (6,6)
	declare @p_TableID nvarchar(50) 
	
	declare @p_L15_Reset nvarchar(50) 
	
	
	declare  @p_TableTmp table (
		Row_ID int
		,TyTrong_15 decimal (6,4)
		,SoLuongThucXuat decimal (18,2)
		--,SoLuongDuXuat decimal (18,2)
		,NhietDoTB decimal (10,2)
		,L15 decimal (18,2)
		,L15_H decimal (18,2)
		,MaNgan nvarchar(10)
		,TableID   nvarchar(20)
		,VCF decimal (6,4)
		,WCF decimal (6,4)
		,KG decimal (18,2)
		,NhietDoBQ decimal (10,2)
		,TyTrong_BQ decimal (6,4)
			)
			
	
	
	
	set @p_Inline='FALSE'
	
	set @p_Inline = (select KeyValue from SYS_CONFIG where upper( KeyCode)='E5')
	
	set @p_L15_Reset = (select KeyValue from SYS_CONFIG where upper( KeyCode)='L15_RESET')
	
	if isnull(@p_Inline,'N') ='Y'
		begin
			set  @p_Inline='TRUE'
		end
	else
		begin
			set  @p_Inline='FALSE'
		end
		
	if isnull(@p_L15_Reset,'') =''
		begin
		    set @p_L15_Reset='N'
		end
		
	if isnull(@p_L15_Reset,'') ='N'
		begin
							
				insert into @p_TableTmp (TableID, MaNgan, Row_ID,TyTrong_15, SoLuongThucXuat, NhietDoTB)
				select a.TableID,a.MaNgan,a.Row_ID, a.TyTrong_15, dbo.FPT_LaySoThucXuat ( (select top 1 mavanchuyen from tbllenhXuate5 where solenh=a.solenh)   
										 ,a.SoLuongThucXuat, a.SoLuongDuXuat,0) as SoLuongThucXuat 
										 ,a.NhietDo        
								 from FPT_tblLenhXuatChiTietE5_V  a,tblLenhXuatChiTietE5 b  with (nolock)
								 where  a.Row_ID=b.Row_ID and a.SoLenh=@p_SoLenh
									  and  isnull(  b.FlagTankLine,0) =0 and   (   isnull(b.GST,0) <=0  
									  or  (@p_Inline ='FALSE' and isnull(b.GST,0) >=0  )
									  or  isnull( b.TYLE_TTE,0)  <=0
									  )  and a.MaHangHoa  in (select MaHangHoa from tblHangHoaE5)
			    
         end
    else   --Dung cho KV2 tinh lai ca inline va intank
		 begin
				insert into @p_TableTmp (TableID, MaNgan, Row_ID,TyTrong_15, SoLuongThucXuat, NhietDoTB)  
				select a.TableID,a.MaNgan,a.Row_ID, a.TyTrong_15,
					 dbo.FPT_LaySoThucXuat ( (select top 1 mavanchuyen from tbllenhXuate5 where solenh=a.solenh)   
														,a.SoLuongThucXuat, a.SoLuongDuXuat,0) as SoLuongThucXuat 
					 ,a.NhietDo        
			 from FPT_tblLenhXuatChiTietE5_V  a,tblLenhXuatChiTietE5 b   with (nolock)
			 where  a.Row_ID=b.Row_ID and a.SoLenh=@p_SoLenh
									 --  and a.MaHangHoa  in (select MaHangHoa from tblHangHoaE5)
			    
         end
         
         
         
   --       select TableID, sum( NhietDoTB*SoLuongThucXuat) /sum(SoLuongThucXuat)  as NhietDoTB
			--				,sum( TyTrong_15*SoLuongThucXuat)/sum(SoLuongThucXuat) as TyTrong_15
							
			--, sum(SoLuongThucXuat) as SoLuongThucXuat
			-- from   @p_TableTmp
			-- group by TableID 
			-- return
			 
			 
    
    DECLARE p_CursorTmp CURSOR FOR   
			 select TableID, dbo.FPT_ROUNDNUMBER(sum( NhietDoTB*SoLuongThucXuat) ,2) /sum(SoLuongThucXuat)  as NhietDoTB
							
							
							, case when dbo.fm_TyTrongE5_BQGQ (@p_SoLenh,TableID) <=1 then min(TyTrong_15) else
							dbo.FPT_ROUNDNUMBER(sum( TyTrong_15*SoLuongThucXuat),0) /sum(SoLuongThucXuat ) end as TyTrong_15
			, sum(SoLuongThucXuat) as SoLuongThucXuat
			 from   @p_TableTmp
				group by TableID --,NhietDoTB, TyTrong_15			
	OPEN p_CursorTmp  

	FETCH NEXT FROM p_CursorTmp   INTO @p_TableID, @p_NhietDo, @TyTrong_15, @SoLuongThucXuat

	WHILE @@FETCH_STATUS = 0  	
		begin
			--update tbllenhxuatchitiete5 set gst=@L15 where Row_ID=@Row_ID
			set @p_NhietDo  =dbo.FPT_ROUNDNUMBER( @p_NhietDo,2) 
			set @TyTrong_15 =dbo.FPT_ROUNDNUMBER( @TyTrong_15,4)
			
			set @VCF= dbo.FPT_ROUNDNUMBER(dbo.zzFPT_mdlQCI_GetVCF_NS (@p_NhietDo, @TyTrong_15),4)
			set @L15 =dbo.FPT_ROUNDNUMBER(@VCF * @SoLuongThucXuat,0)
			set @WCF = @TyTrong_15 -0.0011
			set @KG=dbo.FPT_ROUNDNUMBER(@WCF * @L15,0)
			
			update @p_TableTmp set  VCF=@VCF, L15_H=@L15, KG=@KG, WCF=@WCF, NhietDoBQ =	@p_NhietDo
			, TyTrong_BQ=		@TyTrong_15
				 where  TableID=@p_TableID
			
			---print ('sdffsfs' + convert (nvarchar(50),)
			
			FETCH NEXT FROM p_CursorTmp   INTO @p_TableID, @p_NhietDo, @TyTrong_15, @SoLuongThucXuat
		end
	--END   
	CLOSE p_CursorTmp
	DEALLOCATE p_CursorTmp
    
    
 
    --   select * from @p_TableTmp
    --return
    
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
    
    DECLARE p_CursorTmp22 CURSOR FOR   
			 select TableID, L15_H 
				, VCF 
				,WCF 
				,KG 
				,NhietDoBQ 
				,TyTrong_BQ 
			 
			 , sum(L15) as L15
			 from   @p_TableTmp
				group by TableID , L15_H 
					, VCF 
						,WCF 
						,KG 
						,NhietDoBQ 
						,TyTrong_BQ 
				
	OPEN p_CursorTmp22  

	FETCH NEXT FROM p_CursorTmp22   INTO @p_TableID , @TongL15 , @VCF 
																	,@WCF 
																	,@KG 
																	,@p_NhietDo
																	,@TyTrong_15, @L15

	WHILE @@FETCH_STATUS = 0  	
		begin
			if isnull(@L15,0) <> isnull(@TongL15,0) and isnull(@TongL15,0) >0
						begin			
										update @p_TableTmp set L15 = L15 + ( @TongL15 - @L15) 
											where MaNgan  = (select min(MaNgan) from @p_TableTmp )	
												and TableID=@p_TableID		
						end	
			
			update tbllenhxuat_HangHoae5 set VCF=@VCF
											,WCF=@WCF
											,NhietDo_BQGQ=@p_NhietDo
											,D15_BQGQ=@TyTrong_15
											,KG=@KG
											,L15	=@TongL15											
					
					where SoLenh=@p_SoLenh and TableID=@p_TableID
			
			FETCH NEXT FROM p_CursorTmp22   INTO @p_TableID , @TongL15 , @VCF 
																	,@WCF 
																	,@KG 
																	,@p_NhietDo
																	,@TyTrong_15, @L15
		end
	--END   
	CLOSE p_CursorTmp22
	DEALLOCATE p_CursorTmp22
    
    
    --select * from @p_TableTmp
    --return
    
    
    DECLARE p_Cursor CURSOR FOR   
			select Row_ID, L15, VCF  from @p_TableTmp 
			
	OPEN p_Cursor  

	FETCH NEXT FROM p_Cursor   INTO @Row_ID, @L15, @VCF

	WHILE @@FETCH_STATUS = 0  	
		begin
			update tbllenhxuatchitiete5 set gst=@L15, AVG_CTL = @VCF where Row_ID=@Row_ID
			FETCH NEXT FROM p_Cursor  INTO @Row_ID, @L15,  @VCF
		end
	--END   
	CLOSE p_Cursor
	DEALLOCATE p_Cursor
     
     --select * from @p_TableTmp 
     
   -- select * from tbllenhxuat_HangHoae5 where solenh=@p_SoLenh 
END
--GO
