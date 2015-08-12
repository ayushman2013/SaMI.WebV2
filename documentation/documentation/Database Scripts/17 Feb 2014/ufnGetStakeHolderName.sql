USE [db_SaMI]
GO
/****** Object:  UserDefinedFunction [dbo].[ufnGetStakeHolderName]    Script Date: 02/13/2014 16:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufnGetStakeHolderName](@StakeHolderID int)
RETURNS varchar(100)
AS 
-- Returns the stock level for the product.
BEGIN
	DECLARE @StakeHolderName varchar(100);
    SELECT @StakeHolderName = StakeHolderName FROM tbl_stakeholders WHERE StakeHolderID = @StakeHolderID;
    
    
        
    RETURN @StakeHolderName;
END;
