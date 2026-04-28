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
create PROCEDURE CotoNhomBe_CapNhatCurrent
	@p_Client nvarchar(10)
AS
BEGIN
	declare @p_Ct nvarchar(10)

	begin try

	
	if @p_Client ='A'
		begin
			set @p_Ct ='C1'
		end
	if @p_Client ='B'
		begin
			set @p_Ct ='C2'
		end
	if @p_Client ='C'
		begin
			set @p_Ct ='C3'
		end
	
		---Xu ly sửa
	 update T SET t.[Push_TDH] =null, t.[Push_XTTD] =null,t.[User_Push_TDH] =null, t.[User_Push_XTTD] =null, t.Date_Push_TDH =null, t.Date_Push_XTTD =null				
					,t.TankValidfrom =s.TankValidfrom, t.MeterId=s.MeterId,t.TankValid_to = s.TankValid_to, t.Valid_from=s.Valid_from
							,t.Valid_to=s.Valid_to ,t.Bexuat=s.Bexuat,t.TankGroup=s.TankGroup,t.MaHangHoa=s.MaHangHoa,t.TenHangHoa =s.TenHangHoa, t.UpdateDate =s.UpdateDate 
							,t.CreateUser =s.CreateUser, t.CreateDate=s.CreateDate,t.UpdateUser =s.UpdateUser 
	 from tblCongToNhomBe T, 
			 (select 
					   MeterId ,Valid_from,  Valid_to ,Bexuat,TankGroup,TankGroup_Name,MaHangHoa,TenHangHoa           
					   ,CreateUser,CreateDate,UpdateUser,UpdateDate,TankValidfrom,TankValid_to,IDLine
						from [dbo].[tblCongToNhomBe_TDH] where  substring (MeterId,1,2) = @p_Ct  and idline in (
									select IDLine from [tblCongToNhomBe_TDH] kk where  
											exists (select 1 from (
													select   MeterId, max(Valid_to) as Valid_to  from  [dbo].[tblCongToNhomBe_TDH]   
															group by MeterId) abc  where abc.Meterid = kk.MeterId  and kk.Valid_to = abc.Valid_to))													
						)  S
				  
				where  (T.MeterId = S.MeterId and (t.Valid_from <> s.Valid_from or  t.Valid_to  <> s.Valid_to  	or 
							  t.Meterid <>  s.MeterId or t.BeXuat <> s.Bexuat or t.TankGroup <> s.TankGroup 
							  or t.MaHangHoa <> s.MaHangHoa or t.TankValidfrom <> s.TankValidfrom or t.TankValid_to <> s.TankValid_to )  )
				
					 ;
				

		---Xu ly thêm mơi 
	 MERGE tblCongToNhomBe T
			USING (select 
					   MeterId ,Valid_from,Valid_to ,Bexuat,TankGroup,TankGroup_Name,MaHangHoa,TenHangHoa           
					   ,CreateUser,CreateDate,UpdateUser,UpdateDate,TankValidfrom,TankValid_to,IDLine
						from [dbo].[tblCongToNhomBe_TDH] where  substring (MeterId,1,2) = @p_Ct  and idline in (
									select IDLine from [tblCongToNhomBe_TDH] kk where  
											exists (select 1 from (
													select   MeterId, max(Valid_to) as Valid_to  from  [dbo].[tblCongToNhomBe_TDH]   
															group by MeterId) abc  where abc.Meterid = kk.MeterId  and kk.Valid_to = abc.Valid_to))													
						)
				  AS S (MeterId,Valid_from ,Valid_to,Bexuat,TankGroup,TankGroup_Name ,MaHangHoa,TenHangHoa           
					   ,CreateUser,CreateDate,UpdateUser,UpdateDate,TankValidfrom,TankValid_to,IDLine )
				on (T.Meterid = S.Meterid )				
					WHEN NOT MATCHED THEN 
						INSERT( MeterId,Valid_from ,Valid_to,Bexuat,TankGroup,TankGroup_Name ,MaHangHoa,TenHangHoa           
							,CreateUser,CreateDate,UpdateUser,UpdateDate,TankValidfrom,TankValid_to,IDLine )
						VALUES ( s.MeterId, s.Valid_from ,s.Valid_to,s.Bexuat,s.TankGroup,s.TankGroup_Name ,s.MaHangHoa,s.TenHangHoa           
							,s.CreateUser,s.CreateDate,s.UpdateUser,s.UpdateDate,s.TankValidfrom,s.TankValid_to,s.IDLine);
		
		select 0  as nNumber,'' as sDesc where 1=0
	end try
		
	begin catch
		select 1 as nNumber, ERROR_MESSAGE() as sDesc
	end catch 

END
GO
