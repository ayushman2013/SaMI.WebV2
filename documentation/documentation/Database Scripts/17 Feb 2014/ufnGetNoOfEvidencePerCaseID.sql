USE [db_SaMI]
GO
/****** Object:  UserDefinedFunction [dbo].[ufnGetNoOfEvidencePerCaseID]    Script Date: 02/12/2014 16:00:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufnGetNoOfEvidencePerCaseID](@CaseID int)
RETURNS int
AS 
-- Returns the stock level for the product.
BEGIN
	
    DECLARE @ret int;
    SET @ret = 0;        
    SELECT @ret = COUNT(CaseID) 
    FROM tbl_evidences_per_case 
    WHERE CaseID = @CaseID;    
        
    RETURN @ret;
END;
