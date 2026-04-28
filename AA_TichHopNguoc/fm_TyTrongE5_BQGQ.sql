
create FUNCTION [dbo].[fm_TyTrongE5_BQGQ]
(@p_SoLenh nvarchar(50)
	, @p_Table_ID nvarchar(10)
)
RETURNS int 
BEGIN
	DECLARE @p_Return  int
	set @p_Return =0
		
	select @p_Return=count (*) from 	
				( SELECT 
						TyTrong_15
				FROM 
					fpt_tblLenhXuatChiTietE5_v AS lxct 
				WHERE 
					--lxct.LineID=@LineID AND 
					--lxct.MaLenh=@MaLenh AND 
					--lxct.NgayXuat=@NgayXuat
					--and
					 tableid=@p_Table_ID  and SoLenh=@p_SoLenh
				group by TyTrong_15 ) anhqh
	
	
	RETURN isnull(@p_Return,0)
	
END
