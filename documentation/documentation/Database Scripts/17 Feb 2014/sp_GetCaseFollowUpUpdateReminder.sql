USE [db_SaMI]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCaseFollowUpUpdateReminder]    Script Date: 02/13/2014 10:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetCaseFollowUpUpdateReminder]
	@Frequency int,
	@PartnerID int,
	@DistrictID int
AS
	Set NoCount ON
	Declare @SQLQuery AS NVarchar(4000)
    Declare @ParamDefinition AS NVarchar(2000) 
    Set @SQLQuery = '
	SELECT C.[CaseID],C.[Description], C.[CaseNumber], CONVERT(varchar(10),C.[CaseRegisteredDate], 111) AS CaseRegisteredDate,
		   CT.[CaseTypeDesc], CST.[CaseStatusTypeDesc],
		   CASE dbo.ufnGetNoOfEvidencePerCaseID(C.[CaseID])
                    WHEN 0 THEN ''N/A''
                    ELSE CONVERT(varchar(100),dbo.ufnGetNoOfEvidencePerCaseID(C.[CaseID]))
           END AS Evidences,
           CASE C.[PartnerID]
				WHEN 0 THEN ''''
				ELSE SH.[StakeHolderName]
           END AS PartnerName,
          SP.SaMIProfileNumber, SP.SaMIProfileID,
          CONVERT(varchar(10),CFU.[FollowUpDate], 111) AS FollowUpDate, CFU.[Description] AS CaseFollowUpDescription
	FROM [tbl_cases] AS C
	JOIN tbl_case_types AS CT
		ON CT.[CaseTypeID] = C.[CaseTypeID]
	JOIN tbl_case_status_types AS CST
		ON CST.[CaseStatusTypeID] = C.[CaseStatusTypeID]
	LEFT JOIN tbl_stakeholders AS SH
		ON SH.[StakeHolderID] = C.[PartnerID]
	JOIN [tbl_SaMI_profiles] AS SP
		ON SP.[SaMIProfileID] = C.[SaMIProfileID]
	JOIN [tbl_case_follow_up] AS CFU
		ON C.[CaseID] = CFU.[CaseID]
	WHERE
		DATEDIFF(day, getdate(),CFU.[CreatedDate])<=0
		AND
		DATEDIFF(day, getdate(),CFU.[CreatedDate]) >= @Frequency'
	
	IF @PartnerID > 0 
		SET @SQLQuery = @SQLQuery + ' And (C.[PartnerID] = @PartnerID)' 
	IF @DistrictID > 0
		SET @SQLQuery = @SQLQuery + ' And (SP.[DistrictID] = @DistrictID)' 
		
	Set @ParamDefinition =      ' @Frequency int,
								@PartnerID int,
								@DistrictID int'
								
    /* Execute the Transact-SQL String with all parameter value's 
       Using sp_executesql Command */
    Execute sp_Executesql     @SQLQuery, 
                @ParamDefinition, 
                @Frequency,
				@PartnerID,
				@DistrictID
	If @@ERROR <> 0 GoTo ErrorHandler
    Set NoCount OFF
    Return(0)
  
ErrorHandler:
    Return(@@ERROR)
GO
                
