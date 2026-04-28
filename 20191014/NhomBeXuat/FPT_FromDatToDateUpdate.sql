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
-- Description:	<Description,,>     Tạm thời bỏ đi không dùng nữa
-- =============================================
alter PROCEDURE FPT_FromDatToDateUpdate	
	@p_MeterId nvarchar(10)
	,@p_Fromdate datetime,
	@p_ToDate datetime
AS
BEGIN
	begin try
		declare @pIDLINE int
		declare @p_FromdateTemp datetime 
		declare @p_TodateTemp datetime 

		declare @p_FromdateCurrent datetime 
		declare @p_TodateCurrent datetime 

	   	  
	  --return
		--TH1: Xử lý các bản ghi có ngày hiệu lực >= Todate truyền vào
		set @p_FromdateTemp =null
		set @p_TodateTemp =null

		--DECLARE product_cursor CURSOR FOR
		--		SELECT v.IDLINE , Valid_from,Valid_to 
		--				FROM tblCongToNhomBe_TDH v 
		--		WHERE MeterId = @p_MeterId
		--			 and  (v.Valid_from >=@p_ToDate  )
		--		order by  Valid_to  desc

		--		OPEN product_cursor
		--		FETCH NEXT FROM product_cursor INTO @pIDLINE, @p_FromdateCurrent, @p_TodateCurrent
				
		--		WHILE @@FETCH_STATUS = 0
		--		BEGIN
		--			if @p_FromdateTemp is null or @p_TodateTemp is null 
		--				begin
		--					set @p_FromdateTemp = @p_FromdateCurrent
		--					set @p_TodateTemp = @p_TodateCurrent
		--				end 
		--			else
		--				begin
		--					set @p_TodateTemp  = DATEADD (second ,-5,@p_FromdateTemp)  
		--					set @p_FromdateTemp  = @p_FromdateCurrent
		--					update  tblCongToNhomBe_TDH set Valid_from =@p_FromdateTemp ,Valid_to  =@p_TodateTemp  where MeterId  = @p_MeterId  
		--				end
					
		--			FETCH NEXT FROM product_cursor INTO @pIDLINE, @p_FromdateCurrent, @p_TodateCurrent
		--		END
		--CLOSE product_cursor
		--DEALLOCATE product_cursor


		--TH2: Xử lý các bản ghi có Valid_from  >= Fromdate truyền vào va Valid_from <= Todate ttruyen vao vaf  Valid_To > Todate ttruyen vao 
		set @p_FromdateTemp =null
		set @p_TodateTemp =null

		DECLARE product_cursor CURSOR FOR
				SELECT v.IDLINE , Valid_from,Valid_to 
						FROM tblCongToNhomBe_TDH v 
				WHERE MeterId = @p_MeterId
					 and  (v.Valid_from >=@p_FromDate and v.Valid_from <=@p_ToDate  and Valid_to > @p_ToDate )
				order by  Valid_to  desc

				OPEN product_cursor
				FETCH NEXT FROM product_cursor INTO @pIDLINE, @p_FromdateCurrent, @p_TodateCurrent
				
				WHILE @@FETCH_STATUS = 0
				BEGIN
					if @p_FromdateTemp is null or @p_TodateTemp is null 
						begin
							set @p_FromdateTemp = @p_FromdateCurrent
							set @p_TodateTemp = @p_TodateCurrent
							if @p_FromdateTemp <= @p_Todate
								begin
									set @p_FromdateTemp  = DATEADD (second ,+5,@p_Todate)  
									update  tblCongToNhomBe_TDH set Valid_from =@p_FromdateTemp ,Valid_to  =@p_TodateTemp   where MeterId  = @p_MeterId 
								end
						end 
					else
						begin
							set @p_TodateTemp  = DATEADD (second ,-5,@p_FromdateTemp)  
							set @p_FromdateTemp  = @p_FromdateCurrent
							if @p_FromdateTemp <= @p_Todate
								begin
									set @p_FromdateTemp  = DATEADD (second ,+5,@p_Todate)  
								end
							update  tblCongToNhomBe_TDH set Valid_from =@p_FromdateTemp ,Valid_to  =@p_TodateTemp 
						end
					
					FETCH NEXT FROM product_cursor INTO @pIDLINE, @p_FromdateCurrent, @p_TodateCurrent
				END
		CLOSE product_cursor
		DEALLOCATE product_cursor

	end try

	begin catch
		select 1 nNumber, ERROR_MESSAGE() as sDesc
	end catch
END
GO
