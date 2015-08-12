USE [db_SaMI]
GO
/****** Object:  UserDefinedFunction [dbo].[ufnGetPartnerCases]    Script Date: 02/04/2014 14:22:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[ufnGetPartnerCases](@SaMIProfileID int, @PartnerID int)
RETURNS int
AS 
-- Returns the stock level for the product.
BEGIN	
    DECLARE @ret int;
    SET @ret = 0;
    SELECT @ret = COUNT(CaseID) 
    FROM tbl_cases
    WHERE SaMIProfileID = @SaMIProfileID AND PartnerID  = @PartnerID
    ;        
    RETURN @ret;
END;
