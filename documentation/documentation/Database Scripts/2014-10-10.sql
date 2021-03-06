USE [db_SaMI]
GO
/****** Object:  Table [dbo].[TRNTrainingAgency]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRNTrainingAgency](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TrainingAgency] [varchar](100) NOT NULL,
	[Address] [varchar](100) NULL,
	[Phone] [varchar](15) NULL,
	[ContactPerson] [varchar](50) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_SaMi.TRNTrainingAgency] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRNRecruitmentAgency]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRNRecruitmentAgency](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RecruitmentAgency] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_SaMi.TRNRecruimentAgency] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRNEducationLevel]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRNEducationLevel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EducationLevel] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SaMi.TRNEducationLevel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRNTrade]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRNTrade](
	[TRNTradeID] [int] IDENTITY(1,1) NOT NULL,
	[TradeName] [varchar](100) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
 CONSTRAINT [PK_TRNTrade] PRIMARY KEY CLUSTERED 
(
	[TRNTradeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_user_types]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_user_types](
	[UserTypeID] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeDesc] [varchar](50) NOT NULL,
	[UserTypeCode] [varchar](10) NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_user_types] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRNChecklist]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRNChecklist](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Checklist] [varchar](50) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_SaMi.TRNChecklist] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_zones]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_zones](
	[ZoneID] [int] IDENTITY(1,1) NOT NULL,
	[ZoneName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tbl_zones] PRIMARY KEY CLUSTERED 
(
	[ZoneID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRNOrganization]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRNOrganization](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Organization] [varchar](100) NOT NULL,
	[Country] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_SaMi.TRNOrganization] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRNInformationSource]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRNInformationSource](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InformationSource] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SaMi.TRNReferredBy] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRNEmploymentType]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRNEmploymentType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmploymentType] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_SaMi.TRNEmploymentType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRNEmploymentStatus]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRNEmploymentStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmploymentStatus] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SaMi.TRNEmploymentStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_ethnicity]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_ethnicity](
	[EthnicityID] [int] IDENTITY(1,1) NOT NULL,
	[EthnicityName] [varchar](50) NOT NULL,
	[EthnicityNameNP] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
	[ValidRegions] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_ethnicity] PRIMARY KEY CLUSTERED 
(
	[EthnicityID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_employment_income_source]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_employment_income_source](
	[EmploymentIncomeSourceID] [int] IDENTITY(1,1) NOT NULL,
	[IncomeSource] [varchar](200) NOT NULL,
	[Description] [varchar](500) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [varchar](50) NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [varchar](50) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_income] PRIMARY KEY CLUSTERED 
(
	[EmploymentIncomeSourceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_foreign_employeement_record]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_foreign_employeement_record](
	[ForeignEmploymentRecordID] [int] IDENTITY(1,1) NOT NULL,
	[Country] [varchar](100) NOT NULL,
	[Job] [varchar](50) NOT NULL,
	[DurationYear] [varchar](50) NULL,
	[DurationMonth] [varchar](50) NULL,
	[MonthlySalary] [decimal](18, 0) NULL,
	[ReturnDate] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [varchar](50) NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [varchar](50) NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_tbl_foreign_employeement_record] PRIMARY KEY CLUSTERED 
(
	[ForeignEmploymentRecordID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_information_media]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_information_media](
	[InformationMediaID] [int] IDENTITY(1,1) NOT NULL,
	[MediaName] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [varchar](50) NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdateDate] [varchar](50) NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_tbl_information_media] PRIMARY KEY CLUSTERED 
(
	[InformationMediaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_ic_recommendations_per_service]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ic_recommendations_per_service](
	[ICRecommendationsPerServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceProvidedPerSaMIID] [int] NOT NULL,
	[ICRecommendationID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_ic_recommendations_per_service] PRIMARY KEY CLUSTERED 
(
	[ICRecommendationsPerServiceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_counselor_difficulties_per_service]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_counselor_difficulties_per_service](
	[CounseloDifficultyPerServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceProvidedPerSaMIID] [int] NOT NULL,
	[CounselorDifficultyID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_counselor_difficulties_per_service] PRIMARY KEY CLUSTERED 
(
	[CounseloDifficultyPerServiceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_districts]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_districts](
	[DistrictID] [int] IDENTITY(1,1) NOT NULL,
	[DistrictName] [varchar](100) NOT NULL,
	[ZoneID] [int] NULL,
	[DistrictCode] [varchar](2) NOT NULL,
 CONSTRAINT [PK_tbl_districts] PRIMARY KEY CLUSTERED 
(
	[DistrictID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_case_referred]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_case_referred](
	[CaseReferredID] [int] IDENTITY(1,1) NOT NULL,
	[SaMIProfileID] [int] NOT NULL,
	[ReferStatus] [tinyint] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
 CONSTRAINT [PK_tbl_case_referred] PRIMARY KEY CLUSTERED 
(
	[CaseReferredID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_case_profiles]    Script Date: 10/10/2014 10:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_case_profiles](
	[CaseProfileID] [int] IDENTITY(1,1) NOT NULL,
	[DistrictID] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[CaseProfileNumber] [varchar](50) NULL,
	[VDCID] [int] NULL,
	[SequenceNo] [int] NULL,
 CONSTRAINT [PK_tbl_case_profiles] PRIMARY KEY CLUSTERED 
(
	[CaseProfileID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCaseFollowUpUpdateReminder]    Script Date: 10/10/2014 10:37:30 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetCaseFollowUpReminder]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetCaseFollowUpReminder]
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
          SP.SaMIProfileNumber, SP.SaMIProfileID
	FROM [tbl_cases] AS C
	JOIN tbl_case_types AS CT
		ON CT.[CaseTypeID] = C.[CaseTypeID]
	JOIN tbl_case_status_types AS CST
		ON CST.[CaseStatusTypeID] = C.[CaseStatusTypeID]
	LEFT JOIN tbl_stakeholders AS SH
		ON SH.[StakeHolderID] = C.[PartnerID]
	JOIN [tbl_SaMI_profiles] AS SP
		ON SP.[SaMIProfileID] = C.[SaMIProfileID]
	WHERE
		DATEDIFF(day, getdate(),C.[CreatedDate]) = @Frequency'
	
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
/****** Object:  Table [dbo].[tbl_additional_followup_info_per_service]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_additional_followup_info_per_service](
	[AdditionalFollowUpInfoPerServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceProvidedPerSaMIID] [int] NOT NULL,
	[AdditionalFollowupInfoID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_additional_followup_info_per_service] PRIMARY KEY CLUSTERED 
(
	[AdditionalFollowUpInfoPerServiceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_skill_partners]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_skill_partners](
	[SkillPartnerID] [int] IDENTITY(1,1) NOT NULL,
	[SkillPartnerName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_skill_partners] PRIMARY KEY CLUSTERED 
(
	[SkillPartnerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_problems_per_other_member_migration]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_problems_per_other_member_migration](
	[ProblemPerOtherMemberMigrationID] [int] IDENTITY(1,1) NOT NULL,
	[OtherMemberMigrationID] [int] NOT NULL,
	[ProblemTypeID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_problems_per_other_member_migration] PRIMARY KEY CLUSTERED 
(
	[ProblemPerOtherMemberMigrationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_geo_based_ethnicity]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_geo_based_ethnicity](
	[GeoBasedEthnicityID] [int] IDENTITY(1,1) NOT NULL,
	[GeoBasedEthnicityDesc] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_GeoBasedEthnicity] PRIMARY KEY CLUSTERED 
(
	[GeoBasedEthnicityID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_previous_training_record]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_previous_training_record](
	[PreviousTrainingRecordID] [int] IDENTITY(1,1) NOT NULL,
	[TrainingName] [varchar](100) NOT NULL,
	[TrainingYear] [varchar](50) NOT NULL,
	[TrainingInstution] [varchar](100) NOT NULL,
	[TrainingDuration] [varchar](20) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [varchar](50) NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [varchar](50) NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_tbl_previous_training_record] PRIMARY KEY CLUSTERED 
(
	[PreviousTrainingRecordID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_SaMI_organizations]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_SaMI_organizations](
	[SaMIOrganizationID] [int] IDENTITY(1,1) NOT NULL,
	[SaMIOrganizationName] [varchar](255) NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_SaMI_organization] PRIMARY KEY CLUSTERED 
(
	[SaMIOrganizationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_permanent_address]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_permanent_address](
	[PermanentAddressID] [int] IDENTITY(1,1) NOT NULL,
	[District] [varchar](50) NOT NULL,
	[VdcMunicipality] [varchar](100) NOT NULL,
	[Tol] [varchar](50) NULL,
	[PhoneNumberHome] [varchar](20) NULL,
	[MobileNumber] [varchar](20) NULL,
	[PassportNumber] [varchar](20) NULL,
	[CitizenshipNumber] [varchar](20) NULL,
	[CitizenshipTakenDistrict] [varchar](50) NULL,
	[FathersName] [varchar](50) NULL,
	[FathersContactNumber] [varchar](50) NULL,
	[ContactPerson] [varchar](50) NULL,
	[ContactNumber] [varchar](20) NULL,
 CONSTRAINT [PK_tbl_permanent_address] PRIMARY KEY CLUSTERED 
(
	[PermanentAddressID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_VDC]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_VDC](
	[VDCID] [int] IDENTITY(1,1) NOT NULL,
	[VDCName] [varchar](50) NOT NULL,
	[VDCCode] [varchar](5) NOT NULL,
	[DistrictCode] [varchar](2) NOT NULL,
 CONSTRAINT [PK_tbl_VDC] PRIMARY KEY CLUSTERED 
(
	[VDCID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_users]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](100) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[UserTypeID] [int] NOT NULL,
	[DistrictID] [int] NULL,
	[PartnerID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[SaMIOrganizationID] [int] NULL,
	[SkillPartnerID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRNEmployment]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRNEmployment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TraineeID] [int] NOT NULL,
	[OrganizationID] [int] NULL,
	[EmploymentTypeID] [int] NULL,
	[EmploymentStatusID] [int] NULL,
	[RecruitmentAgencyID] [int] NULL,
	[WorkDoneMonth] [varchar](10) NULL,
	[WorkDoneYear] [varchar](10) NULL,
	[Salary] [decimal](16, 2) NULL,
	[Currency] [varchar](50) NULL,
	[DepartureDate] [date] NULL,
	[ReturnDate] [date] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_SaMi.TRNEmployment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRNTrainingEvent]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRNTrainingEvent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TrainingAgencyID] [int] NOT NULL,
	[EventID] [varchar](100) NULL,
	[Batch] [nvarchar](50) NOT NULL,
	[TradeNameID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_SaMi.TRNTrainingEvent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[ufnGetCaseProfileMaxSequenceNo]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[ufnGetCaseProfileMaxSequenceNo](@DistrictID int)
RETURNS int
AS 
-- Returns the stock level for the product.
BEGIN
	
    DECLARE @ret int;
    SET @ret = 0;        
    SELECT @ret = COUNT(SequenceNo) + 1
    FROM tbl_case_profiles 
    WHERE DistrictID = @DistrictID;    
        
    RETURN @ret;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[ufnGenerateCaseProfileNumber]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[ufnGenerateCaseProfileNumber](@DistrictID int)
RETURNS varchar(50)
AS 
-- Returns the stock level for the product.
BEGIN
	DECLARE @SeqNo int;
	DECLARE @DistrictCode varchar(3);
    DECLARE @ret varchar(50);
    SELECT @SeqNo = dbo.ufnGetCaseProfileMaxSequenceNo(@DistrictID);
    SELECT @DistrictCode = DistrictCode FROM tbl_districts WHERE DistrictID = @DistrictID;
    
    SET @ret = @DistrictCode + '-' + CONVERT(varchar(3),@SeqNo);
        
    RETURN @ret;
END;
GO
/****** Object:  Table [dbo].[TRNDepartureChecklist]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRNDepartureChecklist](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmploymentID] [int] NOT NULL,
	[ChecklistID] [int] NOT NULL,
	[Avaliability] [tinyint] NULL,
 CONSTRAINT [PK_SaMi.TRNDepartureChecklist] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_work_types]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_work_types](
	[WorkTypeID] [int] IDENTITY(1,1) NOT NULL,
	[WorkTypeDesc] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_work_plannings] PRIMARY KEY CLUSTERED 
(
	[WorkTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_visit_frequencies]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_visit_frequencies](
	[VisitFrequencyID] [int] IDENTITY(1,1) NOT NULL,
	[VisitFrequencyDesc] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_visit_frequencies] PRIMARY KEY CLUSTERED 
(
	[VisitFrequencyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_training_reason_types]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_training_reason_types](
	[TrainingReasonTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TrainingReasonTypeDesc] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_training_reason_types] PRIMARY KEY CLUSTERED 
(
	[TrainingReasonTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_additional_followup_info]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_additional_followup_info](
	[AdditionalFollowUpInfoID] [int] IDENTITY(1,1) NOT NULL,
	[AdditionalFollowUpInfoDesc] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_additional_followup_info] PRIMARY KEY CLUSTERED 
(
	[AdditionalFollowUpInfoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_case_types]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_case_types](
	[CaseTypeID] [int] IDENTITY(1,1) NOT NULL,
	[CaseTypeDesc] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_case_types] PRIMARY KEY CLUSTERED 
(
	[CaseTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_case_status_types]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_case_status_types](
	[CaseStatusTypeID] [int] IDENTITY(1,1) NOT NULL,
	[CaseStatusTypeDesc] [varchar](50) NOT NULL,
	[CaseStatusTypeCode] [varchar](10) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_case_status_types] PRIMARY KEY CLUSTERED 
(
	[CaseStatusTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_case_registrars]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_case_registrars](
	[CaseRegistrarID] [int] IDENTITY(1,1) NOT NULL,
	[CaseRegistrarName] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_case_registrars] PRIMARY KEY CLUSTERED 
(
	[CaseRegistrarID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_age_groups]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_age_groups](
	[AgeGroupID] [int] IDENTITY(1,1) NOT NULL,
	[AgeGroupDesc] [varchar](255) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_age_groups] PRIMARY KEY CLUSTERED 
(
	[AgeGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_destination_airports]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_destination_airports](
	[DestinationAirportID] [int] IDENTITY(1,1) NOT NULL,
	[DestinationAirportName] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_destination_airports] PRIMARY KEY CLUSTERED 
(
	[DestinationAirportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_decision_status]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_decision_status](
	[DecisionStatusID] [int] IDENTITY(1,1) NOT NULL,
	[DecisionStatusDesc] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_decision_status] PRIMARY KEY CLUSTERED 
(
	[DecisionStatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_countries]    Script Date: 10/10/2014 10:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](50) NOT NULL,
	[CountryCode] [varchar](3) NULL,
	[CountryGroup] [nchar](10) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_countries] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_documents_behind]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_documents_behind](
	[DocumentBehindID] [int] IDENTITY(1,1) NOT NULL,
	[DocumentBehindDesc] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_documents_behind] PRIMARY KEY CLUSTERED 
(
	[DocumentBehindID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_document_types]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_document_types](
	[DocumentTypeID] [int] IDENTITY(1,1) NOT NULL,
	[DocumentTypeDesc] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_document_types] PRIMARY KEY CLUSTERED 
(
	[DocumentTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_counselor_difficulties]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_counselor_difficulties](
	[CounselorDifficultyID] [int] IDENTITY(1,1) NOT NULL,
	[CounselorDifficultyDesc] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_counselor_difficulties] PRIMARY KEY CLUSTERED 
(
	[CounselorDifficultyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_caste]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_caste](
	[CasteID] [int] IDENTITY(1,1) NOT NULL,
	[CasteName] [varchar](50) NOT NULL,
	[EthnicityID] [int] NOT NULL,
	[CasteNameNP] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsDiscriminated] [tinyint] NOT NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_caste] PRIMARY KEY CLUSTERED 
(
	[CasteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_occupation_types]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_occupation_types](
	[OccupationTypeID] [int] IDENTITY(1,1) NOT NULL,
	[OccupationTypeDesc] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_occupation_types] PRIMARY KEY CLUSTERED 
(
	[OccupationTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_non_referral_reasons]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_non_referral_reasons](
	[NonReferralReasonID] [int] IDENTITY(1,1) NOT NULL,
	[NonReferralReasonDesc] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_non_referral_reasons] PRIMARY KEY CLUSTERED 
(
	[NonReferralReasonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_non_followup_reasons]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_non_followup_reasons](
	[NonFollowUpReasonID] [int] IDENTITY(1,1) NOT NULL,
	[NonFollowUpReasonDesc] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_non_followup_reasons] PRIMARY KEY CLUSTERED 
(
	[NonFollowUpReasonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_money_ranges]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_money_ranges](
	[MoneyRangeID] [int] IDENTITY(1,1) NOT NULL,
	[MoneyRangeDesc] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_money_ranges] PRIMARY KEY CLUSTERED 
(
	[MoneyRangeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_marital_status]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_marital_status](
	[MaritalStatusID] [int] IDENTITY(1,1) NOT NULL,
	[MaritalStatusDesc] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_marital_status] PRIMARY KEY CLUSTERED 
(
	[MaritalStatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_know_about_trainings]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_know_about_trainings](
	[KnowAboutTrainingID] [int] IDENTITY(1,1) NOT NULL,
	[KnowAboutTrainingDesc] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_know_about_trainings] PRIMARY KEY CLUSTERED 
(
	[KnowAboutTrainingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_job_offered_types]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_job_offered_types](
	[JobOfferedTypeID] [int] IDENTITY(1,1) NOT NULL,
	[JobOfferedTypeDesc] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_job_offered_types] PRIMARY KEY CLUSTERED 
(
	[JobOfferedTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_job_offer_sources]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_job_offer_sources](
	[JobOfferSourceID] [int] IDENTITY(1,1) NOT NULL,
	[JobOfferSourceDesc] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_job_off_source] PRIMARY KEY CLUSTERED 
(
	[JobOfferSourceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_ic_recommendations]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_ic_recommendations](
	[ICRecommendationID] [int] IDENTITY(1,1) NOT NULL,
	[ICRecommendationDesc] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_ic_recommendations] PRIMARY KEY CLUSTERED 
(
	[ICRecommendationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_ic_knowledges]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_ic_knowledges](
	[ICKnowledgeID] [int] IDENTITY(1,1) NOT NULL,
	[ICKnowledgeDesc] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_ic_knowledges] PRIMARY KEY CLUSTERED 
(
	[ICKnowledgeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_evidence_types]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_evidence_types](
	[EvidenceTypeID] [int] IDENTITY(1,1) NOT NULL,
	[EvidenceTypeDesc] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_evidence_types] PRIMARY KEY CLUSTERED 
(
	[EvidenceTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_family_members]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_family_members](
	[FamilyMemberID] [int] IDENTITY(1,1) NOT NULL,
	[FamilyMemberName] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_family_members] PRIMARY KEY CLUSTERED 
(
	[FamilyMemberID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_follow_up]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_follow_up](
	[FollowUpID] [int] IDENTITY(1,1) NOT NULL,
	[FollowUpDesc] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_follow_up] PRIMARY KEY CLUSTERED 
(
	[FollowUpID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_feed_duration_types]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_feed_duration_types](
	[FeedDurationTypeID] [int] IDENTITY(1,1) NOT NULL,
	[FeedDurationTypeDesc] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_feed_duration_types] PRIMARY KEY CLUSTERED 
(
	[FeedDurationTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_educational_status]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_educational_status](
	[EducationalStatusID] [int] IDENTITY(1,1) NOT NULL,
	[EducationalStatusDesc] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_educational_status] PRIMARY KEY CLUSTERED 
(
	[EducationalStatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_payment_ranges]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_payment_ranges](
	[PaymentRangeID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentRangeDesc] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_payment_ranges] PRIMARY KEY CLUSTERED 
(
	[PaymentRangeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_passport_status]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_passport_status](
	[PassportStatusID] [int] IDENTITY(1,1) NOT NULL,
	[PassportStatusDesc] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_passport_status] PRIMARY KEY CLUSTERED 
(
	[PassportStatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_referral_to]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_referral_to](
	[ReferralToID] [int] IDENTITY(1,1) NOT NULL,
	[ReferralToDesc] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_referral_to] PRIMARY KEY CLUSTERED 
(
	[ReferralToID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_referral_status]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_referral_status](
	[ReferralStausID] [int] IDENTITY(1,1) NOT NULL,
	[ReferralStatusDesc] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_referral_status] PRIMARY KEY CLUSTERED 
(
	[ReferralStausID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_stakeholders]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_stakeholders](
	[StakeHolderID] [int] IDENTITY(1,1) NOT NULL,
	[StakeHolderName] [varchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_stakeholders] PRIMARY KEY CLUSTERED 
(
	[StakeHolderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_problem_types]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_problem_types](
	[ProblemTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ProblemTypeDesc] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_problems] PRIMARY KEY CLUSTERED 
(
	[ProblemTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_services_provided]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_services_provided](
	[ServiceProvidedID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceProvidedDesc] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_services_provided] PRIMARY KEY CLUSTERED 
(
	[ServiceProvidedID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_SaMI_profiles]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_SaMI_profiles](
	[SaMIProfileID] [int] IDENTITY(1,1) NOT NULL,
	[SaMIProfileNumber] [varchar](50) NOT NULL,
	[RegistrationDate] [date] NOT NULL,
	[DistrictID] [int] NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[CasteID] [int] NOT NULL,
	[IsDiscriminated] [tinyint] NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[AddressDistrictID] [int] NOT NULL,
	[VDCID] [int] NOT NULL,
	[Ward] [varchar](50) NULL,
	[AddressTemp] [varchar](50) NULL,
	[AddressDistrictIDTemp] [int] NULL,
	[VDCIDTemp] [int] NULL,
	[WardTemp] [varchar](50) NULL,
	[VisitorPhone] [varchar](50) NOT NULL,
	[FamilyMemberPhone] [varchar](50) NULL,
	[AgeGroupID] [int] NOT NULL,
	[EducationalStatusID] [int] NOT NULL,
	[MaritalStatusID] [int] NOT NULL,
	[NoOfChildMale] [int] NULL,
	[NoOfChildFemale] [int] NULL,
	[NoOfAdultMale] [int] NULL,
	[NoOfAdultFemale] [int] NULL,
	[OccupationTypeID] [int] NOT NULL,
	[InformationSource] [varchar](255) NULL,
	[SequenceNo] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[ICKnowledgeID] [int] NOT NULL,
	[FrequencyOfVisit] [int] NOT NULL,
	[ReasonForVisiting] [int] NOT NULL,
	[RegistrationNumber] [varchar](100) NULL,
	[GPSLongitude] [float] NOT NULL,
	[GPSLatitude] [float] NOT NULL,
	[VisitCount] [int] NULL,
	[ValidRegions] [varchar](50) NULL,
	[EthnicityID] [int] NULL,
	[ReferStatus] [tinyint] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_SaMI_profiles] PRIMARY KEY CLUSTERED 
(
	[SaMIProfileID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_employments]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_employments](
	[EmploymentID] [int] IDENTITY(1,1) NOT NULL,
	[EmploymentSkillID] [int] NOT NULL,
	[CompanyName] [varchar](100) NOT NULL,
	[CountryID] [int] NOT NULL,
	[EmploymentStartDate] [date] NOT NULL,
	[WorkTypeID] [int] NOT NULL,
	[IncomeRangeID] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_employments] PRIMARY KEY CLUSTERED 
(
	[EmploymentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_employment_skills]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_employment_skills](
	[EmploymentSkillID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[DistrictID] [int] NOT NULL,
	[VDCID] [int] NOT NULL,
	[IsUnemployed] [tinyint] NOT NULL,
	[SelfEmploymentIncome] [int] NULL,
	[AgricultureIncome] [int] NULL,
	[WageIncome] [int] NULL,
	[OtherIncome] [int] NULL,
	[FamilyWageIncome] [int] NULL,
	[FamilyAgricultureIncome] [int] NULL,
	[FamilySalaryIncome] [int] NULL,
	[FamilyForeignIncome] [int] NULL,
	[FamilyBusinessIncome] [int] NULL,
	[FamilyOtherIncome] [int] NULL,
	[FeedDurationTypeID] [int] NOT NULL,
	[TrainingSubject] [varchar](100) NOT NULL,
	[TrainingDistrictID] [int] NOT NULL,
	[TrainingVDCID] [int] NOT NULL,
	[TrainingWardNumber] [varchar](20) NOT NULL,
	[TrainingStratDate] [date] NOT NULL,
	[TrainingReasonTypeID] [int] NOT NULL,
	[KnowAboutTrainingID] [int] NOT NULL,
	[HavePreviousTraining] [tinyint] NOT NULL,
	[PreTrainingName] [varchar](100) NULL,
	[PreTrainingYear] [varchar](10) NULL,
	[PreTrainingInstituteName] [varchar](100) NULL,
	[PreTrainingPeriod] [varchar](100) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[TrainingRegistrationDate] [date] NOT NULL,
 CONSTRAINT [PK_tbl_employment_skills] PRIMARY KEY CLUSTERED 
(
	[EmploymentSkillID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_cases]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_cases](
	[CaseID] [int] IDENTITY(1,1) NOT NULL,
	[CaseProfileID] [int] NOT NULL,
	[CaseTypeID] [int] NOT NULL,
	[CaseRegisteredDate] [date] NOT NULL,
	[CaseNumber] [varchar](100) NOT NULL,
	[NameOfOpponent] [varchar](255) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[PartnerID] [int] NULL,
	[CaseRegistrarID] [int] NULL,
	[ResponsibleStaff] [text] NOT NULL,
	[CaseStatusTypeID] [int] NOT NULL,
	[CompensationAmount] [int] NULL,
	[OutputDetails] [text] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_cases] PRIMARY KEY CLUSTERED 
(
	[CaseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_training]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_training](
	[TrainingID] [int] IDENTITY(1,1) NOT NULL,
	[TrainingInstution] [varchar](200) NOT NULL,
	[TrainingSubject] [varchar](200) NOT NULL,
	[TraineeName] [varchar](50) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[MaritalStatus] [varchar](15) NOT NULL,
	[DateOfBirth] [varchar](20) NOT NULL,
	[GeoBasedEthnicityID] [int] NOT NULL,
	[SpecialCase] [varchar](100) NULL,
	[PermanentAddressID] [int] NOT NULL,
	[EducationalStatusID] [int] NULL,
	[EmploymentIncomeSourceID] [varchar](10) NULL,
	[ForeignEmploymentRecordID] [int] NULL,
	[InformationMediaID] [varchar](10) NULL,
	[PreviousTrainingRecordID] [int] NULL,
 CONSTRAINT [PK_tbl_training] PRIMARY KEY CLUSTERED 
(
	[TrainingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRNTrainee]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRNTrainee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EducationLevelID] [int] NOT NULL,
	[InformationSourceID] [int] NOT NULL,
	[VDCID] [int] NOT NULL,
	[DistrictID] [int] NOT NULL,
	[EventID] [int] NOT NULL,
	[EthnicityID] [int] NOT NULL,
	[FeedDurationTypeID] [int] NULL,
	[CitizenshipIssueDistictID] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[MaritalStatus] [varchar](15) NOT NULL,
	[DOBAD] [varchar](50) NOT NULL,
	[DOBBS] [varchar](20) NOT NULL,
	[CurrentAge] [varchar](3) NOT NULL,
	[SpecialCase] [varchar](50) NULL,
	[Tole] [varchar](50) NOT NULL,
	[WardNumber] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](15) NULL,
	[MobileNumber] [varchar](15) NULL,
	[CitizenshipNumber] [varchar](50) NULL,
	[PassportNumber] [varchar](50) NULL,
	[FatherName] [varchar](50) NULL,
	[FatherTelephone] [varchar](15) NULL,
	[ContactPerson] [varchar](50) NULL,
	[ContactPersonTelephone] [varchar](15) NULL,
	[SelfEmployment] [decimal](16, 2) NULL,
	[Agriculture] [decimal](16, 2) NULL,
	[Wage] [decimal](16, 2) NULL,
	[ForeignEmploymentIncome] [decimal](16, 2) NULL,
	[Other] [decimal](16, 2) NULL,
	[Unemployment] [varchar](10) NULL,
	[RegisteredDate] [date] NULL,
	[NoOfFamilyMember] [int] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[Photo] [varchar](100) NULL,
	[Status] [tinyint] NOT NULL,
	[ReferredBy] [varchar](50) NULL,
 CONSTRAINT [PK_SaMi.TRNTrainee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[ufnGetStakeHolderName]    Script Date: 10/10/2014 10:37:31 ******/
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
GO
/****** Object:  UserDefinedFunction [dbo].[ufnGetSaMIProfileMaxSequenceNo]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufnGetSaMIProfileMaxSequenceNo](@DistrictID int)
RETURNS int
AS 
-- Returns the stock level for the product.
BEGIN
	
    DECLARE @ret int;
    SET @ret = 0;        
    SELECT @ret = COUNT(SequenceNo) + 1
    FROM tbl_SaMI_profiles 
    WHERE DistrictID = @DistrictID;    
        
    RETURN @ret;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[ufnGetSaMIOrganizationCases]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufnGetSaMIOrganizationCases](@SaMIOrganizationID int)
RETURNS int
AS 
-- Returns the stock level for the product.
BEGIN	
    DECLARE @ret int;
    SET @ret = 0;
    SELECT @ret = SP.SaMIProfileID 
    FROM tbl_SaMI_profiles SP
    JOIN tbl_users U ON U.UserID = SP.CreatedBy
    JOIN tbl_user_types UT ON UT.UserTypeID = U.UserTypeID
    LEFT JOIN tbl_SaMI_organizations SO ON SO.SaMIOrganizationID = U.SaMIOrganizationID
    WHERE 
		UT.UserTypeCode = 'Partner'
	    OR 
	    U.SaMIOrganizationID = @SaMIOrganizationID
    ;        
    RETURN @ret;
END;
GO
/****** Object:  Table [dbo].[TRNPreviousTraining]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRNPreviousTraining](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TraineeID] [int] NOT NULL,
	[Name] [varchar](100) NULL,
	[Year] [varchar](10) NULL,
	[Institute] [varchar](100) NULL,
	[Duration] [varchar](10) NULL,
 CONSTRAINT [PK_TRNPreviousTraining] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRNRecruitmentList]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRNRecruitmentList](
	[RecruitmentID] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[SaMIProfileID] [int] NOT NULL,
	[ReferStatus] [tinyint] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_TRNRecruitmentList] PRIMARY KEY CLUSTERED 
(
	[RecruitmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_case_referral_history]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_case_referral_history](
	[CaseReferralHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[CaseID] [int] NOT NULL,
	[PreviousPartnerID] [int] NOT NULL,
	[NewPartnerID] [int] NOT NULL,
	[ReferralDate] [datetime] NOT NULL,
	[Remarks] [text] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_case_referral_history] PRIMARY KEY CLUSTERED 
(
	[CaseReferralHistoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_case_follow_up]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_case_follow_up](
	[CaseFollowUpID] [int] IDENTITY(1,1) NOT NULL,
	[SaMIProfileID] [int] NOT NULL,
	[FollowUpDate] [date] NOT NULL,
	[CaseID] [int] NOT NULL,
	[Description] [varchar](255) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_case_follow_up] PRIMARY KEY CLUSTERED 
(
	[CaseFollowUpID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_case_documentations]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_case_documentations](
	[CaseDocumentationID] [int] IDENTITY(1,1) NOT NULL,
	[SaMIProfileID] [int] NULL,
	[ReferralToID] [int] NULL,
	[NonReferredReasonID] [int] NULL,
	[ReferralStatusID] [int] NOT NULL,
	[DateOfReferral] [datetime] NOT NULL,
	[IsDifficultyFaced] [tinyint] NOT NULL,
	[DifficultyFacedRemarks] [text] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[DistrictID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_case_documentations] PRIMARY KEY CLUSTERED 
(
	[CaseDocumentationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_fe_documents_per_SaMI_profile]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_fe_documents_per_SaMI_profile](
	[FEDocumentPerSaMIProfileID] [int] IDENTITY(1,1) NOT NULL,
	[SaMIProfileID] [int] NOT NULL,
	[DocumentTypeID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_fe_documents_per_SaMI_profile] PRIMARY KEY CLUSTERED 
(
	[FEDocumentPerSaMIProfileID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_evidences_per_case]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_evidences_per_case](
	[EvidencesPerCaseID] [int] IDENTITY(1,1) NOT NULL,
	[EvidenceTypeID] [int] NOT NULL,
	[CaseID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_evidences_per_case] PRIMARY KEY CLUSTERED 
(
	[EvidencesPerCaseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_services_provided_per_SaMI]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_services_provided_per_SaMI](
	[ServiceProvidedPerSaMIID] [int] IDENTITY(1,1) NOT NULL,
	[SaMIProfileID] [int] NOT NULL,
	[VisitTimes] [varchar](50) NOT NULL,
	[ServiceProvidedID] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_services_provided_per_SaMI] PRIMARY KEY CLUSTERED 
(
	[ServiceProvidedPerSaMIID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_previous_fe_experiences]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_previous_fe_experiences](
	[ForeignEmploymentExperienceID] [int] IDENTITY(1,1) NOT NULL,
	[SaMIProfileID] [int] NOT NULL,
	[CountryID] [int] NULL,
	[DestinationAirportID] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[JobOfferedTypeID] [int] NULL,
	[StayDuration] [varchar](50) NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_tbl_previous_fe_experiences] PRIMARY KEY CLUSTERED 
(
	[ForeignEmploymentExperienceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_foreign_employment_status]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_foreign_employment_status](
	[ForeignEmploymentStatusID] [int] IDENTITY(1,1) NOT NULL,
	[SaMIProfileID] [int] NOT NULL,
	[DecisionStatusID] [int] NOT NULL,
	[PassportStatusID] [int] NOT NULL,
	[HaveJobOffer] [tinyint] NOT NULL,
	[JobOfferSourceID] [int] NULL,
	[JobOfferedTypeID] [int] NULL,
	[WorkTypeID] [int] NULL,
	[MadePaymentAmount] [varchar](50) NULL,
	[AskedPaymentAmount] [varchar](50) NULL,
	[ICKnowledgeID] [int] NOT NULL,
	[NothingAskedYet] [tinyint] NOT NULL,
	[HavePaymentReceipt] [tinyint] NOT NULL,
	[ReceiptPaymentAmount] [varchar](50) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[CountryID] [int] NOT NULL,
	[ReferToFSkill] [tinyint] NULL,
	[ReferToCase] [tinyint] NULL,
	[PotentialAndNonPotentialMigrant] [tinyint] NULL,
 CONSTRAINT [PK_tbl_foreign_employment_status] PRIMARY KEY CLUSTERED 
(
	[ForeignEmploymentStatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_other_member_migrations]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_other_member_migrations](
	[OtherMemberMigrationID] [int] IDENTITY(1,1) NOT NULL,
	[SaMIProfileID] [int] NOT NULL,
	[FamilyMemberID] [int] NOT NULL,
	[CountryID] [int] NOT NULL,
	[DoesSendMoney] [tinyint] NOT NULL,
	[MoneyRangeID] [int] NULL,
	[FacedProblem] [tinyint] NOT NULL,
	[ProblemID] [int] NULL,
	[VisitSameCountry] [tinyint] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_other_member_migrations] PRIMARY KEY CLUSTERED 
(
	[OtherMemberMigrationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_other_info_per_SaMI_profile]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_other_info_per_SaMI_profile](
	[OtherInfoPerSaMIProfileID] [int] IDENTITY(1,1) NOT NULL,
	[SaMIProfileID] [int] NOT NULL,
	[HaveExperienceOrTraining] [tinyint] NOT NULL,
	[IsPreviousForeignExperienced] [tinyint] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[HaveJobExperience] [tinyint] NOT NULL,
 CONSTRAINT [PK_tbl_other_info_per_SaMI_profile] PRIMARY KEY CLUSTERED 
(
	[OtherInfoPerSaMIProfileID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_other_followup_per_service]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_other_followup_per_service](
	[OtherFollowUpPerServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceProvidedPerSaMIID] [int] NOT NULL,
	[FollowUpDate] [date] NOT NULL,
	[NonFollowUpReasonID] [int] NULL,
	[IsFollowUpComplied] [int] NULL,
	[IsFollowUpDidNotComply] [int] NULL,
	[IsReasonRecommendation] [int] NULL,
	[IsReasonReceipt] [int] NULL,
	[IsReasonFamilyMember] [int] NULL,
	[IsReasonOther] [int] NULL,
	[Remarks] [text] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_other_followup_per_service] PRIMARY KEY CLUSTERED 
(
	[OtherFollowUpPerServiceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_follow_up_per_services]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_follow_up_per_services](
	[FollowUpPerServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceProvidedPerSaMIID] [int] NOT NULL,
	[ICFollowUpRequired] [int] NOT NULL,
	[FollowUpID] [varchar](50) NULL,
	[DifficultReceipt] [int] NULL,
	[DifficultOther] [int] NULL,
	[NonComplianceFamilyReason] [int] NULL,
	[ICRecommendationID] [varchar](50) NULL,
	[CounselorDifficultyID] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[FurtherFollowUpID] [int] NULL,
	[FurtherFollowUpRequired] [int] NULL,
 CONSTRAINT [PK_tbl_follow_up_per_services] PRIMARY KEY CLUSTERED 
(
	[FollowUpPerServiceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_documents_per_other_member_migration]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_documents_per_other_member_migration](
	[DocumentsPerOtherMemberMigrationID] [int] IDENTITY(1,1) NOT NULL,
	[OtherMemberMigrationID] [int] NOT NULL,
	[DocumentBehindID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_documents_per_other_member_migration] PRIMARY KEY CLUSTERED 
(
	[DocumentsPerOtherMemberMigrationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[ufnGetNoOfEvidencePerCaseID]    Script Date: 10/10/2014 10:37:31 ******/
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
GO
/****** Object:  UserDefinedFunction [dbo].[ufnGenerateSaMIProfileNumber]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufnGenerateSaMIProfileNumber](@DistrictID int)
RETURNS varchar(50)
AS 
-- Returns the stock level for the product.
BEGIN
	DECLARE @SeqNo int;
	DECLARE @DistrictCode varchar(3);
    DECLARE @ret varchar(50);
    SELECT @SeqNo = dbo.ufnGetSaMIProfileMaxSequenceNo(@DistrictID);
    SELECT @DistrictCode = DistrictCode FROM tbl_districts WHERE DistrictID = @DistrictID;
    
    SET @ret = @DistrictCode + '-' + CONVERT(varchar(3),@SeqNo);
        
    RETURN @ret;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[ufnGetServiceProvidedPerSaMIID]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufnGetServiceProvidedPerSaMIID](@SaMIProfileID int)
RETURNS int
AS 
-- Returns the stock level for the product.
BEGIN
	
    DECLARE @ret int;
    SET @ret = 0;        
    SELECT @ret = ServiceProvidedPerSaMIID 
    FROM tbl_services_provided_per_SaMI 
    WHERE SaMIProfileID = @SaMIProfileID;    
        
    RETURN @ret;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[ufnGetOtherFollowupStatus]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufnGetOtherFollowupStatus](@OtherFollowUpPerServiceID int)
RETURNS varchar(100) 
AS 
-- Returns the stock level for the product.
BEGIN
	DECLARE @FollowUpStatus int;
    DECLARE @ret varchar(100);
    SET @ret = 'Not Possible';
    SELECT @FollowUpStatus = IsFollowUpComplied
    FROM tbl_other_followup_per_service OFPS
    WHERE OFPS.OtherFollowUpPerServiceID = @OtherFollowUpPerServiceID;
    IF (@FollowUpStatus = 1)      
        SET @ret = 'Complied';
    ElSE
		BEGIN
			SELECT @FollowUpStatus = IsReasonOther
			FROM tbl_other_followup_per_service OFPS
			WHERE OFPS.OtherFollowUpPerServiceID = @OtherFollowUpPerServiceID;
			IF (@FollowUpStatus = 1) 	     
				SET @ret = 'Was too difficult to do';
			ELSE
				BEGIN
					SELECT @FollowUpStatus = IsReasonReceipt
					FROM tbl_other_followup_per_service OFPS
					WHERE OFPS.OtherFollowUpPerServiceID = @OtherFollowUpPerServiceID;
					IF (@FollowUpStatus = 1) 	     
						SET @ret = 'Receipt could not be obtain';
					ELSE
						BEGIN
							SELECT @FollowUpStatus = IsReasonRecommendation
							FROM tbl_other_followup_per_service OFPS
							WHERE OFPS.OtherFollowUpPerServiceID = @OtherFollowUpPerServiceID;
							IF (@FollowUpStatus = 1) 	     
								SET @ret = 'Did not understand the recommendation.';
							ELSE
								BEGIN
									SELECT @FollowUpStatus = IsReasonFamilyMember
									FROM tbl_other_followup_per_service OFPS
									WHERE OFPS.OtherFollowUpPerServiceID = @OtherFollowUpPerServiceID;
									IF (@FollowUpStatus = 1) 	     
										SET @ret = 'Family Members Do not know.';
								END;
						END;
				END;
		END;
     
     
        
    RETURN @ret;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[ufnGetOtherFollowupCount]    Script Date: 10/10/2014 10:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufnGetOtherFollowupCount](@ServiceProvidedPerSaMIID int)
RETURNS int
AS 
-- Returns the stock level for the product.
BEGIN	
    DECLARE @ret int;
    SET @ret = 0;
    SELECT @ret = COUNT(ServiceProvidedPerSaMIID) 
    FROM tbl_other_followup_per_service OFPS
    WHERE OFPS.ServiceProvidedPerSaMIID = @ServiceProvidedPerSaMIID
    ;        
    RETURN @ret;
END;
GO
/****** Object:  Default [DF_SaMi.TRNTrainingAgency_Status]    Script Date: 10/10/2014 10:37:28 ******/
ALTER TABLE [dbo].[TRNTrainingAgency] ADD  CONSTRAINT [DF_SaMi.TRNTrainingAgency_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_TRNRecruitmentAgency_Status]    Script Date: 10/10/2014 10:37:28 ******/
ALTER TABLE [dbo].[TRNRecruitmentAgency] ADD  CONSTRAINT [DF_TRNRecruitmentAgency_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_user_types_CreatedDate]    Script Date: 10/10/2014 10:37:28 ******/
ALTER TABLE [dbo].[tbl_user_types] ADD  CONSTRAINT [DF_user_types_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_user_types_UpdatedDate]    Script Date: 10/10/2014 10:37:28 ******/
ALTER TABLE [dbo].[tbl_user_types] ADD  CONSTRAINT [DF_user_types_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_TRNChecklist_Status]    Script Date: 10/10/2014 10:37:28 ******/
ALTER TABLE [dbo].[TRNChecklist] ADD  CONSTRAINT [DF_TRNChecklist_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_TRNOrganization_Status]    Script Date: 10/10/2014 10:37:28 ******/
ALTER TABLE [dbo].[TRNOrganization] ADD  CONSTRAINT [DF_TRNOrganization_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_TRNEmploymentType_Status]    Script Date: 10/10/2014 10:37:28 ******/
ALTER TABLE [dbo].[TRNEmploymentType] ADD  CONSTRAINT [DF_TRNEmploymentType_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_ethnicity_CreatedDate]    Script Date: 10/10/2014 10:37:28 ******/
ALTER TABLE [dbo].[tbl_ethnicity] ADD  CONSTRAINT [DF_ethnicity_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_ethnicity_UpdatedDate]    Script Date: 10/10/2014 10:37:28 ******/
ALTER TABLE [dbo].[tbl_ethnicity] ADD  CONSTRAINT [DF_ethnicity_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_ethnicity_ValidRegions]    Script Date: 10/10/2014 10:37:28 ******/
ALTER TABLE [dbo].[tbl_ethnicity] ADD  CONSTRAINT [DF_tbl_ethnicity_ValidRegions]  DEFAULT ('1,2,3') FOR [ValidRegions]
GO
/****** Object:  Default [DF_tbl_income_Status]    Script Date: 10/10/2014 10:37:28 ******/
ALTER TABLE [dbo].[tbl_employment_income_source] ADD  CONSTRAINT [DF_tbl_income_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_tbl_foreign_employeement_record_Status]    Script Date: 10/10/2014 10:37:28 ******/
ALTER TABLE [dbo].[tbl_foreign_employeement_record] ADD  CONSTRAINT [DF_tbl_foreign_employeement_record_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_tbl_information_media_Status]    Script Date: 10/10/2014 10:37:28 ******/
ALTER TABLE [dbo].[tbl_information_media] ADD  CONSTRAINT [DF_tbl_information_media_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_tbl_districts_ZoneID]    Script Date: 10/10/2014 10:37:28 ******/
ALTER TABLE [dbo].[tbl_districts] ADD  CONSTRAINT [DF_tbl_districts_ZoneID]  DEFAULT ((0)) FOR [ZoneID]
GO
/****** Object:  Default [DF_tbl_districts_DistrictCode]    Script Date: 10/10/2014 10:37:28 ******/
ALTER TABLE [dbo].[tbl_districts] ADD  CONSTRAINT [DF_tbl_districts_DistrictCode]  DEFAULT ((0)) FOR [DistrictCode]
GO
/****** Object:  Default [DF_tbl_previous_training_record_Status]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_previous_training_record] ADD  CONSTRAINT [DF_tbl_previous_training_record_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_tbl_SaMI_organization_CreatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_SaMI_organizations] ADD  CONSTRAINT [DF_tbl_SaMI_organization_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_tbl_SaMI_organizations_UpdatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_SaMI_organizations] ADD  CONSTRAINT [DF_tbl_SaMI_organizations_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_SaMI_organizations_Status]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_SaMI_organizations] ADD  CONSTRAINT [DF_tbl_SaMI_organizations_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_tbl_users_PartnerID]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_users] ADD  CONSTRAINT [DF_tbl_users_PartnerID]  DEFAULT ((0)) FOR [PartnerID]
GO
/****** Object:  Default [DF_tbl_users_CreatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_users] ADD  CONSTRAINT [DF_tbl_users_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_tbl_users_UpdatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_users] ADD  CONSTRAINT [DF_tbl_users_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_users_SaMIOrganizationID]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_users] ADD  CONSTRAINT [DF_tbl_users_SaMIOrganizationID]  DEFAULT ((0)) FOR [SaMIOrganizationID]
GO
/****** Object:  Default [DF_tbl_users_SkillPartnerID]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_users] ADD  CONSTRAINT [DF_tbl_users_SkillPartnerID]  DEFAULT ((0)) FOR [SkillPartnerID]
GO
/****** Object:  Default [DF_TRNEmployment_Status]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[TRNEmployment] ADD  CONSTRAINT [DF_TRNEmployment_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_SaMi.TRNTrainingEvent_Status]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[TRNTrainingEvent] ADD  CONSTRAINT [DF_SaMi.TRNTrainingEvent_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_SaMi.TRNDepartureChecklist_Avaliability]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[TRNDepartureChecklist] ADD  CONSTRAINT [DF_SaMi.TRNDepartureChecklist_Avaliability]  DEFAULT ((0)) FOR [Avaliability]
GO
/****** Object:  Default [DF_work_types_CreatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_work_types] ADD  CONSTRAINT [DF_work_types_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_work_types_UpdatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_work_types] ADD  CONSTRAINT [DF_work_types_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_visit_frequencies_CreatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_visit_frequencies] ADD  CONSTRAINT [DF_visit_frequencies_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_visit_frequencies_UpdatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_visit_frequencies] ADD  CONSTRAINT [DF_visit_frequencies_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_training_reason_types_CreatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_training_reason_types] ADD  CONSTRAINT [DF_training_reason_types_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_training_reason_types_UpdatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_training_reason_types] ADD  CONSTRAINT [DF_training_reason_types_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_additional_followup_info_CreatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_additional_followup_info] ADD  CONSTRAINT [DF_tbl_additional_followup_info_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_tbl_additional_followup_info_UpdatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_additional_followup_info] ADD  CONSTRAINT [DF_tbl_additional_followup_info_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_case_types_CreatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_case_types] ADD  CONSTRAINT [DF_case_types_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_case_types_UpdatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_case_types] ADD  CONSTRAINT [DF_case_types_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_case_status_types_CreatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_case_status_types] ADD  CONSTRAINT [DF_case_status_types_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_case_status_types_UpdatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_case_status_types] ADD  CONSTRAINT [DF_case_status_types_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_case_registrars_CreatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_case_registrars] ADD  CONSTRAINT [DF_case_registrars_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_case_registrars_UpdatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_case_registrars] ADD  CONSTRAINT [DF_case_registrars_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_age_groups_CreatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_age_groups] ADD  CONSTRAINT [DF_tbl_age_groups_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_tbl_age_groups_UpdatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_age_groups] ADD  CONSTRAINT [DF_tbl_age_groups_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_age_groups_Status]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_age_groups] ADD  CONSTRAINT [DF_tbl_age_groups_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_destination_airports_CreatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_destination_airports] ADD  CONSTRAINT [DF_destination_airports_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_destination_airports_UpdatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_destination_airports] ADD  CONSTRAINT [DF_destination_airports_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_decision_status_CreatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_decision_status] ADD  CONSTRAINT [DF_decision_status_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_decision_status_UpdatedDate]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_decision_status] ADD  CONSTRAINT [DF_decision_status_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_countries_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_countries] ADD  CONSTRAINT [DF_countries_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_countries_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_countries] ADD  CONSTRAINT [DF_countries_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_documents_behind_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_documents_behind] ADD  CONSTRAINT [DF_documents_behind_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_documents_behind_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_documents_behind] ADD  CONSTRAINT [DF_documents_behind_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_document_types_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_document_types] ADD  CONSTRAINT [DF_document_types_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_document_types_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_document_types] ADD  CONSTRAINT [DF_document_types_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_counselor_difficulties_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_counselor_difficulties] ADD  CONSTRAINT [DF_counselor_difficulties_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_counselor_difficulties_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_counselor_difficulties] ADD  CONSTRAINT [DF_counselor_difficulties_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_caste_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_caste] ADD  CONSTRAINT [DF_caste_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_caste_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_caste] ADD  CONSTRAINT [DF_caste_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_caste_IsDiscriminated]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_caste] ADD  CONSTRAINT [DF_tbl_caste_IsDiscriminated]  DEFAULT ((0)) FOR [IsDiscriminated]
GO
/****** Object:  Default [DF_occupation_types_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_occupation_types] ADD  CONSTRAINT [DF_occupation_types_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_occupation_types_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_occupation_types] ADD  CONSTRAINT [DF_occupation_types_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_non_referral_reasons_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_non_referral_reasons] ADD  CONSTRAINT [DF_non_referral_reasons_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_non_referral_reasons_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_non_referral_reasons] ADD  CONSTRAINT [DF_non_referral_reasons_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_non_followup_reasons_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_non_followup_reasons] ADD  CONSTRAINT [DF_non_followup_reasons_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_non_followup_reasons_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_non_followup_reasons] ADD  CONSTRAINT [DF_non_followup_reasons_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_money_ranges_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_money_ranges] ADD  CONSTRAINT [DF_money_ranges_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_money_ranges_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_money_ranges] ADD  CONSTRAINT [DF_money_ranges_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_marital_status_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_marital_status] ADD  CONSTRAINT [DF_marital_status_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_marital_status_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_marital_status] ADD  CONSTRAINT [DF_marital_status_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_know_about_trainings_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_know_about_trainings] ADD  CONSTRAINT [DF_know_about_trainings_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_know_about_trainings_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_know_about_trainings] ADD  CONSTRAINT [DF_know_about_trainings_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_job_offered_types_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_job_offered_types] ADD  CONSTRAINT [DF_job_offered_types_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_job_offered_types_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_job_offered_types] ADD  CONSTRAINT [DF_job_offered_types_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_job_offer_sources_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_job_offer_sources] ADD  CONSTRAINT [DF_job_offer_sources_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_job_offer_sources_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_job_offer_sources] ADD  CONSTRAINT [DF_job_offer_sources_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_ic_recommendations_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_ic_recommendations] ADD  CONSTRAINT [DF_ic_recommendations_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_ic_recommendations_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_ic_recommendations] ADD  CONSTRAINT [DF_ic_recommendations_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_ic_knowledges_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_ic_knowledges] ADD  CONSTRAINT [DF_ic_knowledges_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_ic_knowledges_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_ic_knowledges] ADD  CONSTRAINT [DF_ic_knowledges_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_evidence_types_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_evidence_types] ADD  CONSTRAINT [DF_tbl_evidence_types_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_tbl_evidence_types_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_evidence_types] ADD  CONSTRAINT [DF_tbl_evidence_types_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_family_members_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_family_members] ADD  CONSTRAINT [DF_family_members_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_family_members_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_family_members] ADD  CONSTRAINT [DF_family_members_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_follow_up_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_follow_up] ADD  CONSTRAINT [DF_follow_up_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_follow_up_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_follow_up] ADD  CONSTRAINT [DF_follow_up_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_feed_duration_types_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_feed_duration_types] ADD  CONSTRAINT [DF_feed_duration_types_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_feed_duration_types_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_feed_duration_types] ADD  CONSTRAINT [DF_feed_duration_types_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_educational_status_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_educational_status] ADD  CONSTRAINT [DF_educational_status_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_educational_status_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_educational_status] ADD  CONSTRAINT [DF_educational_status_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_payment_ranges_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_payment_ranges] ADD  CONSTRAINT [DF_payment_ranges_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_payment_ranges_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_payment_ranges] ADD  CONSTRAINT [DF_payment_ranges_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_passport_status_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_passport_status] ADD  CONSTRAINT [DF_passport_status_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_passport_status_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_passport_status] ADD  CONSTRAINT [DF_passport_status_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_referral_to_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_referral_to] ADD  CONSTRAINT [DF_referral_to_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_referral_to_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_referral_to] ADD  CONSTRAINT [DF_referral_to_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_referral_status_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_referral_status] ADD  CONSTRAINT [DF_referral_status_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_referral_status_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_referral_status] ADD  CONSTRAINT [DF_referral_status_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_stakeholders_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_stakeholders] ADD  CONSTRAINT [DF_stakeholders_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_stakeholders_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_stakeholders] ADD  CONSTRAINT [DF_stakeholders_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_problem_types_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_problem_types] ADD  CONSTRAINT [DF_problem_types_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_problem_types_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_problem_types] ADD  CONSTRAINT [DF_problem_types_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_services_provided_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_services_provided] ADD  CONSTRAINT [DF_services_provided_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_services_provided_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_services_provided] ADD  CONSTRAINT [DF_services_provided_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_RegistrationDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_RegistrationDate]  DEFAULT (getdate()) FOR [RegistrationDate]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_CasteID]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_CasteID]  DEFAULT ((0)) FOR [CasteID]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_IsDiscriminated]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_IsDiscriminated]  DEFAULT ((0)) FOR [IsDiscriminated]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_NoOfChildMale]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_NoOfChildMale]  DEFAULT ((0)) FOR [NoOfChildMale]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_NoOfChildFemale]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_NoOfChildFemale]  DEFAULT ((0)) FOR [NoOfChildFemale]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_NoOfAdultMale]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_NoOfAdultMale]  DEFAULT ((0)) FOR [NoOfAdultMale]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_NoOfAdultFemale]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_NoOfAdultFemale]  DEFAULT ((0)) FOR [NoOfAdultFemale]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_SequenceNo]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_SequenceNo]  DEFAULT ((0)) FOR [SequenceNo]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_ICKnowledgeID]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_ICKnowledgeID]  DEFAULT ((0)) FOR [ICKnowledgeID]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_FrequencyOfVisit]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_FrequencyOfVisit]  DEFAULT ((1)) FOR [FrequencyOfVisit]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_ReasonForVisiting]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_ReasonForVisiting]  DEFAULT ((1)) FOR [ReasonForVisiting]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_GPSLongitude]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_GPSLongitude]  DEFAULT ((0.00)) FOR [GPSLongitude]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_GPSLatitude]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_GPSLatitude]  DEFAULT ((0.00)) FOR [GPSLatitude]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_VisitCount]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_VisitCount]  DEFAULT ((1)) FOR [VisitCount]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_ValidRegions]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_ValidRegions]  DEFAULT ('1,2,3') FOR [ValidRegions]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_ReferStatus]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_ReferStatus]  DEFAULT ((0)) FOR [ReferStatus]
GO
/****** Object:  Default [DF_tbl_SaMI_profiles_IsDeleted]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles] ADD  CONSTRAINT [DF_tbl_SaMI_profiles_IsDeleted]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_tbl_employments_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employments] ADD  CONSTRAINT [DF_tbl_employments_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_tbl_employments_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employments] ADD  CONSTRAINT [DF_tbl_employments_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_employment_skills_IsUnemployed]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills] ADD  CONSTRAINT [DF_tbl_employment_skills_IsUnemployed]  DEFAULT ((0)) FOR [IsUnemployed]
GO
/****** Object:  Default [DF_tbl_employment_skills_AgricultureIncome]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills] ADD  CONSTRAINT [DF_tbl_employment_skills_AgricultureIncome]  DEFAULT ((0)) FOR [AgricultureIncome]
GO
/****** Object:  Default [DF_tbl_employment_skills_WageIncome]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills] ADD  CONSTRAINT [DF_tbl_employment_skills_WageIncome]  DEFAULT ((0)) FOR [WageIncome]
GO
/****** Object:  Default [DF_tbl_employment_skills_OtherIncome]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills] ADD  CONSTRAINT [DF_tbl_employment_skills_OtherIncome]  DEFAULT ((0)) FOR [OtherIncome]
GO
/****** Object:  Default [DF_tbl_employment_skills_FamilyWageIncome]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills] ADD  CONSTRAINT [DF_tbl_employment_skills_FamilyWageIncome]  DEFAULT ((0)) FOR [FamilyWageIncome]
GO
/****** Object:  Default [DF_tbl_employment_skills_FamilyAgricultureIncome]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills] ADD  CONSTRAINT [DF_tbl_employment_skills_FamilyAgricultureIncome]  DEFAULT ((0)) FOR [FamilyAgricultureIncome]
GO
/****** Object:  Default [DF_tbl_employment_skills_FamilySalaryIncome]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills] ADD  CONSTRAINT [DF_tbl_employment_skills_FamilySalaryIncome]  DEFAULT ((0)) FOR [FamilySalaryIncome]
GO
/****** Object:  Default [DF_tbl_employment_skills_FamilyForeignIncome]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills] ADD  CONSTRAINT [DF_tbl_employment_skills_FamilyForeignIncome]  DEFAULT ((0)) FOR [FamilyForeignIncome]
GO
/****** Object:  Default [DF_tbl_employment_skills_FamilyBusinessIncome]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills] ADD  CONSTRAINT [DF_tbl_employment_skills_FamilyBusinessIncome]  DEFAULT ((0)) FOR [FamilyBusinessIncome]
GO
/****** Object:  Default [DF_tbl_employment_skills_FamilyOtherIncome]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills] ADD  CONSTRAINT [DF_tbl_employment_skills_FamilyOtherIncome]  DEFAULT ((0)) FOR [FamilyOtherIncome]
GO
/****** Object:  Default [DF_tbl_employment_skills_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills] ADD  CONSTRAINT [DF_tbl_employment_skills_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_tbl_employment_skills_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills] ADD  CONSTRAINT [DF_tbl_employment_skills_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_cases_PartnerID]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_cases] ADD  CONSTRAINT [DF_tbl_cases_PartnerID]  DEFAULT ((0)) FOR [PartnerID]
GO
/****** Object:  Default [DF_tbl_cases_CaseRegistrarID]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_cases] ADD  CONSTRAINT [DF_tbl_cases_CaseRegistrarID]  DEFAULT ((0)) FOR [CaseRegistrarID]
GO
/****** Object:  Default [DF_tbl_cases_CompensationAmount]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_cases] ADD  CONSTRAINT [DF_tbl_cases_CompensationAmount]  DEFAULT ((0)) FOR [CompensationAmount]
GO
/****** Object:  Default [df_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_cases] ADD  CONSTRAINT [df_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [df_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_cases] ADD  CONSTRAINT [df_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_TRNRecruitmentList_Status]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[TRNRecruitmentList] ADD  CONSTRAINT [DF_TRNRecruitmentList_Status]  DEFAULT ((0)) FOR [ReferStatus]
GO
/****** Object:  Default [DF_tbl_case_referral_history_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_referral_history] ADD  CONSTRAINT [DF_tbl_case_referral_history_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_tbl_case_referral_history_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_referral_history] ADD  CONSTRAINT [DF_tbl_case_referral_history_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_case_follow_up_SaMIProfileID]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_follow_up] ADD  CONSTRAINT [DF_tbl_case_follow_up_SaMIProfileID]  DEFAULT ((0)) FOR [SaMIProfileID]
GO
/****** Object:  Default [DF_tbl_case_follow_up_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_follow_up] ADD  CONSTRAINT [DF_tbl_case_follow_up_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_tbl_case_follow_up_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_follow_up] ADD  CONSTRAINT [DF_tbl_case_follow_up_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_case_documentations_ReferralToID]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_documentations] ADD  CONSTRAINT [DF_tbl_case_documentations_ReferralToID]  DEFAULT ((0)) FOR [ReferralToID]
GO
/****** Object:  Default [DF_tbl_case_documentations_IsDifficultyFaced]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_documentations] ADD  CONSTRAINT [DF_tbl_case_documentations_IsDifficultyFaced]  DEFAULT ((0)) FOR [IsDifficultyFaced]
GO
/****** Object:  Default [DF_tbl_case_documentations_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_documentations] ADD  CONSTRAINT [DF_tbl_case_documentations_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_tbl_case_documentations_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_documentations] ADD  CONSTRAINT [DF_tbl_case_documentations_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_services_provided_per_SaMI_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_services_provided_per_SaMI] ADD  CONSTRAINT [DF_services_provided_per_SaMI_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_services_provided_per_SaMI_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_services_provided_per_SaMI] ADD  CONSTRAINT [DF_services_provided_per_SaMI_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_previous_fe_experiences_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_previous_fe_experiences] ADD  CONSTRAINT [DF_previous_fe_experiences_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_previous_fe_experiences_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_previous_fe_experiences] ADD  CONSTRAINT [DF_previous_fe_experiences_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_previous_fe_experiences_Status]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_previous_fe_experiences] ADD  CONSTRAINT [DF_tbl_previous_fe_experiences_Status]  DEFAULT ((0)) FOR [Status]
GO
/****** Object:  Default [DF_tbl_foreign_employment_status_HaveJobOffer]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_foreign_employment_status] ADD  CONSTRAINT [DF_tbl_foreign_employment_status_HaveJobOffer]  DEFAULT ((0)) FOR [HaveJobOffer]
GO
/****** Object:  Default [DF_tbl_foreign_employment_status_NothingAskedYet]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_foreign_employment_status] ADD  CONSTRAINT [DF_tbl_foreign_employment_status_NothingAskedYet]  DEFAULT ((0)) FOR [NothingAskedYet]
GO
/****** Object:  Default [DF_tbl_foreign_employment_status_HavePaymentReceipt]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_foreign_employment_status] ADD  CONSTRAINT [DF_tbl_foreign_employment_status_HavePaymentReceipt]  DEFAULT ((0)) FOR [HavePaymentReceipt]
GO
/****** Object:  Default [DF_foreign_employment_status_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_foreign_employment_status] ADD  CONSTRAINT [DF_foreign_employment_status_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_foreign_employment_status_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_foreign_employment_status] ADD  CONSTRAINT [DF_foreign_employment_status_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_foreign_employment_status_CountryID]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_foreign_employment_status] ADD  CONSTRAINT [DF_tbl_foreign_employment_status_CountryID]  DEFAULT ((0)) FOR [CountryID]
GO
/****** Object:  Default [DF_tbl_foreign_employment_status_ReferToFSkill]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_foreign_employment_status] ADD  CONSTRAINT [DF_tbl_foreign_employment_status_ReferToFSkill]  DEFAULT ((0)) FOR [ReferToFSkill]
GO
/****** Object:  Default [DF_tbl_foreign_employment_status_ReferToCase]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_foreign_employment_status] ADD  CONSTRAINT [DF_tbl_foreign_employment_status_ReferToCase]  DEFAULT ((0)) FOR [ReferToCase]
GO
/****** Object:  Default [DF_tbl_foreign_employment_status_PotentialAndNonPotentialMigrant]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_foreign_employment_status] ADD  CONSTRAINT [DF_tbl_foreign_employment_status_PotentialAndNonPotentialMigrant]  DEFAULT ((0)) FOR [PotentialAndNonPotentialMigrant]
GO
/****** Object:  Default [DF_tbl_other_member_migrations_DoesSendMoney]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_member_migrations] ADD  CONSTRAINT [DF_tbl_other_member_migrations_DoesSendMoney]  DEFAULT ((0)) FOR [DoesSendMoney]
GO
/****** Object:  Default [DF_tbl_other_member_migrations_FacedProblem]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_member_migrations] ADD  CONSTRAINT [DF_tbl_other_member_migrations_FacedProblem]  DEFAULT ((0)) FOR [FacedProblem]
GO
/****** Object:  Default [DF_tbl_other_member_migrations_VisitSameCountry]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_member_migrations] ADD  CONSTRAINT [DF_tbl_other_member_migrations_VisitSameCountry]  DEFAULT ((0)) FOR [VisitSameCountry]
GO
/****** Object:  Default [DF_other_member_migrations_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_member_migrations] ADD  CONSTRAINT [DF_other_member_migrations_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_other_member_migrations_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_member_migrations] ADD  CONSTRAINT [DF_other_member_migrations_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_other_info_per_SaMI_profile_HaveExperienceOrTraining]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_info_per_SaMI_profile] ADD  CONSTRAINT [DF_tbl_other_info_per_SaMI_profile_HaveExperienceOrTraining]  DEFAULT ((0)) FOR [HaveExperienceOrTraining]
GO
/****** Object:  Default [DF_tbl_other_info_per_SaMI_profile_IsPreviousForeignExperienced]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_info_per_SaMI_profile] ADD  CONSTRAINT [DF_tbl_other_info_per_SaMI_profile_IsPreviousForeignExperienced]  DEFAULT ((0)) FOR [IsPreviousForeignExperienced]
GO
/****** Object:  Default [DF_other_info_per_SaMI_profile_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_info_per_SaMI_profile] ADD  CONSTRAINT [DF_other_info_per_SaMI_profile_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_other_info_per_SaMI_profile_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_info_per_SaMI_profile] ADD  CONSTRAINT [DF_other_info_per_SaMI_profile_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_other_info_per_SaMI_profile_HaveJobExperience]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_info_per_SaMI_profile] ADD  CONSTRAINT [DF_tbl_other_info_per_SaMI_profile_HaveJobExperience]  DEFAULT ((0)) FOR [HaveJobExperience]
GO
/****** Object:  Default [DF_tbl_other_followup_per_service_NonFollowUpReasonID]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_followup_per_service] ADD  CONSTRAINT [DF_tbl_other_followup_per_service_NonFollowUpReasonID]  DEFAULT ((0)) FOR [NonFollowUpReasonID]
GO
/****** Object:  Default [DF_tbl_other_followup_per_service_IsFollowUpComplied]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_followup_per_service] ADD  CONSTRAINT [DF_tbl_other_followup_per_service_IsFollowUpComplied]  DEFAULT ((0)) FOR [IsFollowUpComplied]
GO
/****** Object:  Default [DF_tbl_other_followup_per_service_IsFollowUpDidNotComply]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_followup_per_service] ADD  CONSTRAINT [DF_tbl_other_followup_per_service_IsFollowUpDidNotComply]  DEFAULT ((0)) FOR [IsFollowUpDidNotComply]
GO
/****** Object:  Default [DF_tbl_other_followup_per_service_IsReasonRecommendation]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_followup_per_service] ADD  CONSTRAINT [DF_tbl_other_followup_per_service_IsReasonRecommendation]  DEFAULT ((0)) FOR [IsReasonRecommendation]
GO
/****** Object:  Default [DF_tbl_other_followup_per_service_IsReasonReceipt]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_followup_per_service] ADD  CONSTRAINT [DF_tbl_other_followup_per_service_IsReasonReceipt]  DEFAULT ((0)) FOR [IsReasonReceipt]
GO
/****** Object:  Default [DF_tbl_other_followup_per_service_IsReasonFamilyMember]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_followup_per_service] ADD  CONSTRAINT [DF_tbl_other_followup_per_service_IsReasonFamilyMember]  DEFAULT ((0)) FOR [IsReasonFamilyMember]
GO
/****** Object:  Default [DF_tbl_other_followup_per_service_IsReasonOther]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_followup_per_service] ADD  CONSTRAINT [DF_tbl_other_followup_per_service_IsReasonOther]  DEFAULT ((0)) FOR [IsReasonOther]
GO
/****** Object:  Default [DF_other_followup_per_service_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_followup_per_service] ADD  CONSTRAINT [DF_other_followup_per_service_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_other_followup_per_service_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_followup_per_service] ADD  CONSTRAINT [DF_other_followup_per_service_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_follow_up_per_services_DifficultReceipt]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_follow_up_per_services] ADD  CONSTRAINT [DF_tbl_follow_up_per_services_DifficultReceipt]  DEFAULT ((0)) FOR [DifficultReceipt]
GO
/****** Object:  Default [DF_tbl_follow_up_per_services_ICRecommendationID]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_follow_up_per_services] ADD  CONSTRAINT [DF_tbl_follow_up_per_services_ICRecommendationID]  DEFAULT ('1,2,3,4,5,6,7,8') FOR [ICRecommendationID]
GO
/****** Object:  Default [DF_tbl_follow_up_per_services_CounselorDifficultyID]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_follow_up_per_services] ADD  CONSTRAINT [DF_tbl_follow_up_per_services_CounselorDifficultyID]  DEFAULT ((0)) FOR [CounselorDifficultyID]
GO
/****** Object:  Default [DF_follow_up_per_services_CreatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_follow_up_per_services] ADD  CONSTRAINT [DF_follow_up_per_services_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_follow_up_per_services_UpdatedDate]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_follow_up_per_services] ADD  CONSTRAINT [DF_follow_up_per_services_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/****** Object:  Default [DF_tbl_follow_up_per_services_FurtherFollowUpID]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_follow_up_per_services] ADD  CONSTRAINT [DF_tbl_follow_up_per_services_FurtherFollowUpID]  DEFAULT ((0)) FOR [FurtherFollowUpID]
GO
/****** Object:  ForeignKey [FK_tbl_users_tbl_districts]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_users]  WITH CHECK ADD  CONSTRAINT [FK_tbl_users_tbl_districts] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[tbl_districts] ([DistrictID])
GO
ALTER TABLE [dbo].[tbl_users] CHECK CONSTRAINT [FK_tbl_users_tbl_districts]
GO
/****** Object:  ForeignKey [FK_tbl_users_tbl_user_types]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_users]  WITH CHECK ADD  CONSTRAINT [FK_tbl_users_tbl_user_types] FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[tbl_user_types] ([UserTypeID])
GO
ALTER TABLE [dbo].[tbl_users] CHECK CONSTRAINT [FK_tbl_users_tbl_user_types]
GO
/****** Object:  ForeignKey [FK_SaMi.TRNEmployment_SaMi.TRNEmploymentStatus]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[TRNEmployment]  WITH CHECK ADD  CONSTRAINT [FK_SaMi.TRNEmployment_SaMi.TRNEmploymentStatus] FOREIGN KEY([EmploymentStatusID])
REFERENCES [dbo].[TRNEmploymentStatus] ([ID])
GO
ALTER TABLE [dbo].[TRNEmployment] CHECK CONSTRAINT [FK_SaMi.TRNEmployment_SaMi.TRNEmploymentStatus]
GO
/****** Object:  ForeignKey [FK_SaMi.TRNEmployment_SaMi.TRNEmploymentType]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[TRNEmployment]  WITH CHECK ADD  CONSTRAINT [FK_SaMi.TRNEmployment_SaMi.TRNEmploymentType] FOREIGN KEY([EmploymentTypeID])
REFERENCES [dbo].[TRNEmploymentType] ([ID])
GO
ALTER TABLE [dbo].[TRNEmployment] CHECK CONSTRAINT [FK_SaMi.TRNEmployment_SaMi.TRNEmploymentType]
GO
/****** Object:  ForeignKey [FK_SaMi.TRNEmployment_SaMi.TRNOrganization]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[TRNEmployment]  WITH CHECK ADD  CONSTRAINT [FK_SaMi.TRNEmployment_SaMi.TRNOrganization] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[TRNOrganization] ([ID])
GO
ALTER TABLE [dbo].[TRNEmployment] CHECK CONSTRAINT [FK_SaMi.TRNEmployment_SaMi.TRNOrganization]
GO
/****** Object:  ForeignKey [FK_SaMi.TRNEmployment_SaMi.TRNRecruimentAgency1]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[TRNEmployment]  WITH CHECK ADD  CONSTRAINT [FK_SaMi.TRNEmployment_SaMi.TRNRecruimentAgency1] FOREIGN KEY([RecruitmentAgencyID])
REFERENCES [dbo].[TRNRecruitmentAgency] ([ID])
GO
ALTER TABLE [dbo].[TRNEmployment] CHECK CONSTRAINT [FK_SaMi.TRNEmployment_SaMi.TRNRecruimentAgency1]
GO
/****** Object:  ForeignKey [FK_SaMi.TRNTrainingEvent_SaMi.TRNTrainingAgency]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[TRNTrainingEvent]  WITH CHECK ADD  CONSTRAINT [FK_SaMi.TRNTrainingEvent_SaMi.TRNTrainingAgency] FOREIGN KEY([TrainingAgencyID])
REFERENCES [dbo].[TRNTrainingAgency] ([ID])
GO
ALTER TABLE [dbo].[TRNTrainingEvent] CHECK CONSTRAINT [FK_SaMi.TRNTrainingEvent_SaMi.TRNTrainingAgency]
GO
/****** Object:  ForeignKey [FK_SaMi.TRNDepartureChecklist_SaMi.TRNChecklist]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[TRNDepartureChecklist]  WITH CHECK ADD  CONSTRAINT [FK_SaMi.TRNDepartureChecklist_SaMi.TRNChecklist] FOREIGN KEY([ChecklistID])
REFERENCES [dbo].[TRNChecklist] ([ID])
GO
ALTER TABLE [dbo].[TRNDepartureChecklist] CHECK CONSTRAINT [FK_SaMi.TRNDepartureChecklist_SaMi.TRNChecklist]
GO
/****** Object:  ForeignKey [FK_SaMi.TRNDepartureChecklist_SaMi.TRNEmployment]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[TRNDepartureChecklist]  WITH CHECK ADD  CONSTRAINT [FK_SaMi.TRNDepartureChecklist_SaMi.TRNEmployment] FOREIGN KEY([EmploymentID])
REFERENCES [dbo].[TRNEmployment] ([ID])
GO
ALTER TABLE [dbo].[TRNDepartureChecklist] CHECK CONSTRAINT [FK_SaMi.TRNDepartureChecklist_SaMi.TRNEmployment]
GO
/****** Object:  ForeignKey [FK_work_types_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_work_types]  WITH CHECK ADD  CONSTRAINT [FK_work_types_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_work_types] CHECK CONSTRAINT [FK_work_types_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_work_types_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_work_types]  WITH CHECK ADD  CONSTRAINT [FK_work_types_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_work_types] CHECK CONSTRAINT [FK_work_types_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_visit_frequencies_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_visit_frequencies]  WITH CHECK ADD  CONSTRAINT [FK_visit_frequencies_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_visit_frequencies] CHECK CONSTRAINT [FK_visit_frequencies_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_visit_frequencies_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_visit_frequencies]  WITH CHECK ADD  CONSTRAINT [FK_visit_frequencies_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_visit_frequencies] CHECK CONSTRAINT [FK_visit_frequencies_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_training_reason_types_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_training_reason_types]  WITH CHECK ADD  CONSTRAINT [FK_training_reason_types_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_training_reason_types] CHECK CONSTRAINT [FK_training_reason_types_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_training_reason_types_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_training_reason_types]  WITH CHECK ADD  CONSTRAINT [FK_training_reason_types_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_training_reason_types] CHECK CONSTRAINT [FK_training_reason_types_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_additional_followup_info_tbl_users_createdBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_additional_followup_info]  WITH CHECK ADD  CONSTRAINT [FK_tbl_additional_followup_info_tbl_users_createdBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_additional_followup_info] CHECK CONSTRAINT [FK_tbl_additional_followup_info_tbl_users_createdBy]
GO
/****** Object:  ForeignKey [FK_tbl_additional_followup_info_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_additional_followup_info]  WITH CHECK ADD  CONSTRAINT [FK_tbl_additional_followup_info_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_additional_followup_info] CHECK CONSTRAINT [FK_tbl_additional_followup_info_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_case_types_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_case_types]  WITH CHECK ADD  CONSTRAINT [FK_case_types_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_case_types] CHECK CONSTRAINT [FK_case_types_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_case_types_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_case_types]  WITH CHECK ADD  CONSTRAINT [FK_case_types_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_case_types] CHECK CONSTRAINT [FK_case_types_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_case_status_types_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_case_status_types]  WITH CHECK ADD  CONSTRAINT [FK_case_status_types_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_case_status_types] CHECK CONSTRAINT [FK_case_status_types_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_case_status_types_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_case_status_types]  WITH CHECK ADD  CONSTRAINT [FK_case_status_types_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_case_status_types] CHECK CONSTRAINT [FK_case_status_types_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_case_registrars_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_case_registrars]  WITH CHECK ADD  CONSTRAINT [FK_case_registrars_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_case_registrars] CHECK CONSTRAINT [FK_case_registrars_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_case_registrars_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_case_registrars]  WITH CHECK ADD  CONSTRAINT [FK_case_registrars_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_case_registrars] CHECK CONSTRAINT [FK_case_registrars_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_age_groups_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_age_groups]  WITH CHECK ADD  CONSTRAINT [FK_tbl_age_groups_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_age_groups] CHECK CONSTRAINT [FK_tbl_age_groups_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_age_groups_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_age_groups]  WITH CHECK ADD  CONSTRAINT [FK_tbl_age_groups_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_age_groups] CHECK CONSTRAINT [FK_tbl_age_groups_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_destination_airports_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_destination_airports]  WITH CHECK ADD  CONSTRAINT [FK_destination_airports_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_destination_airports] CHECK CONSTRAINT [FK_destination_airports_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_destination_airports_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_destination_airports]  WITH CHECK ADD  CONSTRAINT [FK_destination_airports_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_destination_airports] CHECK CONSTRAINT [FK_destination_airports_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_decision_status_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_decision_status]  WITH CHECK ADD  CONSTRAINT [FK_decision_status_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_decision_status] CHECK CONSTRAINT [FK_decision_status_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_decision_status_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_decision_status]  WITH CHECK ADD  CONSTRAINT [FK_decision_status_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_decision_status] CHECK CONSTRAINT [FK_decision_status_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_countries_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:30 ******/
ALTER TABLE [dbo].[tbl_countries]  WITH CHECK ADD  CONSTRAINT [FK_countries_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_countries] CHECK CONSTRAINT [FK_countries_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_countries_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_countries]  WITH CHECK ADD  CONSTRAINT [FK_countries_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_countries] CHECK CONSTRAINT [FK_countries_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_documents_behind_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_documents_behind]  WITH CHECK ADD  CONSTRAINT [FK_documents_behind_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_documents_behind] CHECK CONSTRAINT [FK_documents_behind_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_documents_behind_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_documents_behind]  WITH CHECK ADD  CONSTRAINT [FK_documents_behind_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_documents_behind] CHECK CONSTRAINT [FK_documents_behind_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_document_types_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_document_types]  WITH CHECK ADD  CONSTRAINT [FK_document_types_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_document_types] CHECK CONSTRAINT [FK_document_types_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_document_types_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_document_types]  WITH CHECK ADD  CONSTRAINT [FK_document_types_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_document_types] CHECK CONSTRAINT [FK_document_types_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_counselor_difficulties_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_counselor_difficulties]  WITH CHECK ADD  CONSTRAINT [FK_counselor_difficulties_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_counselor_difficulties] CHECK CONSTRAINT [FK_counselor_difficulties_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_counselor_difficulties_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_counselor_difficulties]  WITH CHECK ADD  CONSTRAINT [FK_counselor_difficulties_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_counselor_difficulties] CHECK CONSTRAINT [FK_counselor_difficulties_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_caste_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_caste]  WITH CHECK ADD  CONSTRAINT [FK_caste_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_caste] CHECK CONSTRAINT [FK_caste_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_caste_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_caste]  WITH CHECK ADD  CONSTRAINT [FK_caste_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_caste] CHECK CONSTRAINT [FK_caste_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_occupation_types_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_occupation_types]  WITH CHECK ADD  CONSTRAINT [FK_occupation_types_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_occupation_types] CHECK CONSTRAINT [FK_occupation_types_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_occupation_types_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_occupation_types]  WITH CHECK ADD  CONSTRAINT [FK_occupation_types_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_occupation_types] CHECK CONSTRAINT [FK_occupation_types_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_non_referral_reasons_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_non_referral_reasons]  WITH CHECK ADD  CONSTRAINT [FK_non_referral_reasons_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_non_referral_reasons] CHECK CONSTRAINT [FK_non_referral_reasons_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_non_referral_reasons_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_non_referral_reasons]  WITH CHECK ADD  CONSTRAINT [FK_non_referral_reasons_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_non_referral_reasons] CHECK CONSTRAINT [FK_non_referral_reasons_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_non_followup_reasons_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_non_followup_reasons]  WITH CHECK ADD  CONSTRAINT [FK_non_followup_reasons_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_non_followup_reasons] CHECK CONSTRAINT [FK_non_followup_reasons_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_non_followup_reasons_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_non_followup_reasons]  WITH CHECK ADD  CONSTRAINT [FK_non_followup_reasons_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_non_followup_reasons] CHECK CONSTRAINT [FK_non_followup_reasons_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_money_ranges_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_money_ranges]  WITH CHECK ADD  CONSTRAINT [FK_money_ranges_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_money_ranges] CHECK CONSTRAINT [FK_money_ranges_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_money_ranges_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_money_ranges]  WITH CHECK ADD  CONSTRAINT [FK_money_ranges_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_money_ranges] CHECK CONSTRAINT [FK_money_ranges_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_marital_status_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_marital_status]  WITH CHECK ADD  CONSTRAINT [FK_marital_status_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_marital_status] CHECK CONSTRAINT [FK_marital_status_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_marital_status_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_marital_status]  WITH CHECK ADD  CONSTRAINT [FK_marital_status_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_marital_status] CHECK CONSTRAINT [FK_marital_status_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_know_about_trainings_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_know_about_trainings]  WITH CHECK ADD  CONSTRAINT [FK_know_about_trainings_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_know_about_trainings] CHECK CONSTRAINT [FK_know_about_trainings_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_know_about_trainings_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_know_about_trainings]  WITH CHECK ADD  CONSTRAINT [FK_know_about_trainings_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_know_about_trainings] CHECK CONSTRAINT [FK_know_about_trainings_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_job_offered_types_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_job_offered_types]  WITH CHECK ADD  CONSTRAINT [FK_job_offered_types_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_job_offered_types] CHECK CONSTRAINT [FK_job_offered_types_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_job_offered_types_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_job_offered_types]  WITH CHECK ADD  CONSTRAINT [FK_job_offered_types_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_job_offered_types] CHECK CONSTRAINT [FK_job_offered_types_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_job_offer_sources_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_job_offer_sources]  WITH CHECK ADD  CONSTRAINT [FK_job_offer_sources_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_job_offer_sources] CHECK CONSTRAINT [FK_job_offer_sources_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_job_offer_sources_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_job_offer_sources]  WITH CHECK ADD  CONSTRAINT [FK_job_offer_sources_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_job_offer_sources] CHECK CONSTRAINT [FK_job_offer_sources_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_ic_recommendations_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_ic_recommendations]  WITH CHECK ADD  CONSTRAINT [FK_ic_recommendations_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_ic_recommendations] CHECK CONSTRAINT [FK_ic_recommendations_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_ic_recommendations_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_ic_recommendations]  WITH CHECK ADD  CONSTRAINT [FK_ic_recommendations_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_ic_recommendations] CHECK CONSTRAINT [FK_ic_recommendations_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_ic_knowledges_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_ic_knowledges]  WITH CHECK ADD  CONSTRAINT [FK_ic_knowledges_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_ic_knowledges] CHECK CONSTRAINT [FK_ic_knowledges_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_ic_knowledges_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_ic_knowledges]  WITH CHECK ADD  CONSTRAINT [FK_ic_knowledges_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_ic_knowledges] CHECK CONSTRAINT [FK_ic_knowledges_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_evidence_types_tbl_users_createdBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_evidence_types]  WITH CHECK ADD  CONSTRAINT [FK_tbl_evidence_types_tbl_users_createdBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_evidence_types] CHECK CONSTRAINT [FK_tbl_evidence_types_tbl_users_createdBy]
GO
/****** Object:  ForeignKey [FK_tbl_evidence_types_tbl_users_updatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_evidence_types]  WITH CHECK ADD  CONSTRAINT [FK_tbl_evidence_types_tbl_users_updatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_evidence_types] CHECK CONSTRAINT [FK_tbl_evidence_types_tbl_users_updatedBy]
GO
/****** Object:  ForeignKey [FK_family_members_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_family_members]  WITH CHECK ADD  CONSTRAINT [FK_family_members_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_family_members] CHECK CONSTRAINT [FK_family_members_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_family_members_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_family_members]  WITH CHECK ADD  CONSTRAINT [FK_family_members_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_family_members] CHECK CONSTRAINT [FK_family_members_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_follow_up_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_follow_up]  WITH CHECK ADD  CONSTRAINT [FK_follow_up_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_follow_up] CHECK CONSTRAINT [FK_follow_up_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_follow_up_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_follow_up]  WITH CHECK ADD  CONSTRAINT [FK_follow_up_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_follow_up] CHECK CONSTRAINT [FK_follow_up_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_feed_duration_types_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_feed_duration_types]  WITH CHECK ADD  CONSTRAINT [FK_feed_duration_types_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_feed_duration_types] CHECK CONSTRAINT [FK_feed_duration_types_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_feed_duration_types_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_feed_duration_types]  WITH CHECK ADD  CONSTRAINT [FK_feed_duration_types_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_feed_duration_types] CHECK CONSTRAINT [FK_feed_duration_types_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_educational_status_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_educational_status]  WITH CHECK ADD  CONSTRAINT [FK_educational_status_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_educational_status] CHECK CONSTRAINT [FK_educational_status_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_educational_status_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_educational_status]  WITH CHECK ADD  CONSTRAINT [FK_educational_status_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_educational_status] CHECK CONSTRAINT [FK_educational_status_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_payment_ranges_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_payment_ranges]  WITH CHECK ADD  CONSTRAINT [FK_payment_ranges_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_payment_ranges] CHECK CONSTRAINT [FK_payment_ranges_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_payment_ranges_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_payment_ranges]  WITH CHECK ADD  CONSTRAINT [FK_payment_ranges_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_payment_ranges] CHECK CONSTRAINT [FK_payment_ranges_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_passport_status_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_passport_status]  WITH CHECK ADD  CONSTRAINT [FK_passport_status_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_passport_status] CHECK CONSTRAINT [FK_passport_status_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_passport_status_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_passport_status]  WITH CHECK ADD  CONSTRAINT [FK_passport_status_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_passport_status] CHECK CONSTRAINT [FK_passport_status_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_referral_to_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_referral_to]  WITH CHECK ADD  CONSTRAINT [FK_referral_to_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_referral_to] CHECK CONSTRAINT [FK_referral_to_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_referral_to_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_referral_to]  WITH CHECK ADD  CONSTRAINT [FK_referral_to_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_referral_to] CHECK CONSTRAINT [FK_referral_to_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_referral_status_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_referral_status]  WITH CHECK ADD  CONSTRAINT [FK_referral_status_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_referral_status] CHECK CONSTRAINT [FK_referral_status_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_referral_status_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_referral_status]  WITH CHECK ADD  CONSTRAINT [FK_referral_status_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_referral_status] CHECK CONSTRAINT [FK_referral_status_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_stakeholders_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_stakeholders]  WITH CHECK ADD  CONSTRAINT [FK_stakeholders_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_stakeholders] CHECK CONSTRAINT [FK_stakeholders_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_stakeholders_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_stakeholders]  WITH CHECK ADD  CONSTRAINT [FK_stakeholders_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_stakeholders] CHECK CONSTRAINT [FK_stakeholders_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_problem_types_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_problem_types]  WITH CHECK ADD  CONSTRAINT [FK_problem_types_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_problem_types] CHECK CONSTRAINT [FK_problem_types_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_problem_types_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_problem_types]  WITH CHECK ADD  CONSTRAINT [FK_problem_types_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_problem_types] CHECK CONSTRAINT [FK_problem_types_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_services_provided_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_services_provided]  WITH CHECK ADD  CONSTRAINT [FK_services_provided_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_services_provided] CHECK CONSTRAINT [FK_services_provided_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_services_provided_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_services_provided]  WITH CHECK ADD  CONSTRAINT [FK_services_provided_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_services_provided] CHECK CONSTRAINT [FK_services_provided_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_SaMI_profiles_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles]  WITH CHECK ADD  CONSTRAINT [FK_SaMI_profiles_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_SaMI_profiles] CHECK CONSTRAINT [FK_SaMI_profiles_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_SaMI_profiles_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles]  WITH CHECK ADD  CONSTRAINT [FK_SaMI_profiles_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_SaMI_profiles] CHECK CONSTRAINT [FK_SaMI_profiles_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_SaMI_profiles_tbl_age_groups]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaMI_profiles_tbl_age_groups] FOREIGN KEY([AgeGroupID])
REFERENCES [dbo].[tbl_age_groups] ([AgeGroupID])
GO
ALTER TABLE [dbo].[tbl_SaMI_profiles] CHECK CONSTRAINT [FK_tbl_SaMI_profiles_tbl_age_groups]
GO
/****** Object:  ForeignKey [FK_tbl_SaMI_profiles_tbl_districts]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaMI_profiles_tbl_districts] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[tbl_districts] ([DistrictID])
GO
ALTER TABLE [dbo].[tbl_SaMI_profiles] CHECK CONSTRAINT [FK_tbl_SaMI_profiles_tbl_districts]
GO
/****** Object:  ForeignKey [FK_tbl_SaMI_profiles_tbl_districts_addr]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaMI_profiles_tbl_districts_addr] FOREIGN KEY([AddressDistrictID])
REFERENCES [dbo].[tbl_districts] ([DistrictID])
GO
ALTER TABLE [dbo].[tbl_SaMI_profiles] CHECK CONSTRAINT [FK_tbl_SaMI_profiles_tbl_districts_addr]
GO
/****** Object:  ForeignKey [FK_tbl_SaMI_profiles_tbl_educational_status]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaMI_profiles_tbl_educational_status] FOREIGN KEY([EducationalStatusID])
REFERENCES [dbo].[tbl_educational_status] ([EducationalStatusID])
GO
ALTER TABLE [dbo].[tbl_SaMI_profiles] CHECK CONSTRAINT [FK_tbl_SaMI_profiles_tbl_educational_status]
GO
/****** Object:  ForeignKey [FK_tbl_SaMI_profiles_tbl_marital_status]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaMI_profiles_tbl_marital_status] FOREIGN KEY([MaritalStatusID])
REFERENCES [dbo].[tbl_marital_status] ([MaritalStatusID])
GO
ALTER TABLE [dbo].[tbl_SaMI_profiles] CHECK CONSTRAINT [FK_tbl_SaMI_profiles_tbl_marital_status]
GO
/****** Object:  ForeignKey [FK_tbl_SaMI_profiles_tbl_SaMI_profiles]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaMI_profiles_tbl_SaMI_profiles] FOREIGN KEY([SaMIProfileID])
REFERENCES [dbo].[tbl_SaMI_profiles] ([SaMIProfileID])
GO
ALTER TABLE [dbo].[tbl_SaMI_profiles] CHECK CONSTRAINT [FK_tbl_SaMI_profiles_tbl_SaMI_profiles]
GO
/****** Object:  ForeignKey [FK_tbl_SaMI_profiles_tbl_VDC]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_SaMI_profiles]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaMI_profiles_tbl_VDC] FOREIGN KEY([VDCID])
REFERENCES [dbo].[tbl_VDC] ([VDCID])
GO
ALTER TABLE [dbo].[tbl_SaMI_profiles] CHECK CONSTRAINT [FK_tbl_SaMI_profiles_tbl_VDC]
GO
/****** Object:  ForeignKey [FK_employments_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employments]  WITH CHECK ADD  CONSTRAINT [FK_employments_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_employments] CHECK CONSTRAINT [FK_employments_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_employments_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employments]  WITH CHECK ADD  CONSTRAINT [FK_employments_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_employments] CHECK CONSTRAINT [FK_employments_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_employments_tbl_countries]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employments]  WITH CHECK ADD  CONSTRAINT [FK_tbl_employments_tbl_countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[tbl_countries] ([CountryID])
GO
ALTER TABLE [dbo].[tbl_employments] CHECK CONSTRAINT [FK_tbl_employments_tbl_countries]
GO
/****** Object:  ForeignKey [FK_tbl_employments_tbl_payment_ranges]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employments]  WITH CHECK ADD  CONSTRAINT [FK_tbl_employments_tbl_payment_ranges] FOREIGN KEY([IncomeRangeID])
REFERENCES [dbo].[tbl_payment_ranges] ([PaymentRangeID])
GO
ALTER TABLE [dbo].[tbl_employments] CHECK CONSTRAINT [FK_tbl_employments_tbl_payment_ranges]
GO
/****** Object:  ForeignKey [FK_tbl_employments_tbl_work_types]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employments]  WITH CHECK ADD  CONSTRAINT [FK_tbl_employments_tbl_work_types] FOREIGN KEY([WorkTypeID])
REFERENCES [dbo].[tbl_work_types] ([WorkTypeID])
GO
ALTER TABLE [dbo].[tbl_employments] CHECK CONSTRAINT [FK_tbl_employments_tbl_work_types]
GO
/****** Object:  ForeignKey [FK_employment_skills_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills]  WITH CHECK ADD  CONSTRAINT [FK_employment_skills_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_employment_skills] CHECK CONSTRAINT [FK_employment_skills_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_employment_skills_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills]  WITH CHECK ADD  CONSTRAINT [FK_employment_skills_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_employment_skills] CHECK CONSTRAINT [FK_employment_skills_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_employment_skills_tbl_districts]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills]  WITH CHECK ADD  CONSTRAINT [FK_tbl_employment_skills_tbl_districts] FOREIGN KEY([TrainingDistrictID])
REFERENCES [dbo].[tbl_districts] ([DistrictID])
GO
ALTER TABLE [dbo].[tbl_employment_skills] CHECK CONSTRAINT [FK_tbl_employment_skills_tbl_districts]
GO
/****** Object:  ForeignKey [FK_tbl_employment_skills_tbl_feed_duration_types]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills]  WITH CHECK ADD  CONSTRAINT [FK_tbl_employment_skills_tbl_feed_duration_types] FOREIGN KEY([FeedDurationTypeID])
REFERENCES [dbo].[tbl_feed_duration_types] ([FeedDurationTypeID])
GO
ALTER TABLE [dbo].[tbl_employment_skills] CHECK CONSTRAINT [FK_tbl_employment_skills_tbl_feed_duration_types]
GO
/****** Object:  ForeignKey [FK_tbl_employment_skills_tbl_know_about_trainings]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills]  WITH CHECK ADD  CONSTRAINT [FK_tbl_employment_skills_tbl_know_about_trainings] FOREIGN KEY([KnowAboutTrainingID])
REFERENCES [dbo].[tbl_know_about_trainings] ([KnowAboutTrainingID])
GO
ALTER TABLE [dbo].[tbl_employment_skills] CHECK CONSTRAINT [FK_tbl_employment_skills_tbl_know_about_trainings]
GO
/****** Object:  ForeignKey [FK_tbl_employment_skills_tbl_training_reason_types]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills]  WITH CHECK ADD  CONSTRAINT [FK_tbl_employment_skills_tbl_training_reason_types] FOREIGN KEY([TrainingReasonTypeID])
REFERENCES [dbo].[tbl_training_reason_types] ([TrainingReasonTypeID])
GO
ALTER TABLE [dbo].[tbl_employment_skills] CHECK CONSTRAINT [FK_tbl_employment_skills_tbl_training_reason_types]
GO
/****** Object:  ForeignKey [FK_tbl_employment_skills_tbl_VDC]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_employment_skills]  WITH CHECK ADD  CONSTRAINT [FK_tbl_employment_skills_tbl_VDC] FOREIGN KEY([TrainingVDCID])
REFERENCES [dbo].[tbl_VDC] ([VDCID])
GO
ALTER TABLE [dbo].[tbl_employment_skills] CHECK CONSTRAINT [FK_tbl_employment_skills_tbl_VDC]
GO
/****** Object:  ForeignKey [FK_cases_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_cases]  WITH CHECK ADD  CONSTRAINT [FK_cases_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_cases] CHECK CONSTRAINT [FK_cases_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_cases_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_cases]  WITH CHECK ADD  CONSTRAINT [FK_cases_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_cases] CHECK CONSTRAINT [FK_cases_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_cases_tbl_case_status_types]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_cases]  WITH CHECK ADD  CONSTRAINT [FK_tbl_cases_tbl_case_status_types] FOREIGN KEY([CaseStatusTypeID])
REFERENCES [dbo].[tbl_case_status_types] ([CaseStatusTypeID])
GO
ALTER TABLE [dbo].[tbl_cases] CHECK CONSTRAINT [FK_tbl_cases_tbl_case_status_types]
GO
/****** Object:  ForeignKey [FK_tbl_cases_tbl_case_types]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_cases]  WITH CHECK ADD  CONSTRAINT [FK_tbl_cases_tbl_case_types] FOREIGN KEY([CaseTypeID])
REFERENCES [dbo].[tbl_case_types] ([CaseTypeID])
GO
ALTER TABLE [dbo].[tbl_cases] CHECK CONSTRAINT [FK_tbl_cases_tbl_case_types]
GO
/****** Object:  ForeignKey [FK_tbl_training_tbl_educational_status]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_training]  WITH CHECK ADD  CONSTRAINT [FK_tbl_training_tbl_educational_status] FOREIGN KEY([EducationalStatusID])
REFERENCES [dbo].[tbl_educational_status] ([EducationalStatusID])
GO
ALTER TABLE [dbo].[tbl_training] CHECK CONSTRAINT [FK_tbl_training_tbl_educational_status]
GO
/****** Object:  ForeignKey [FK_tbl_training_tbl_foreign_employeement_record]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_training]  WITH CHECK ADD  CONSTRAINT [FK_tbl_training_tbl_foreign_employeement_record] FOREIGN KEY([ForeignEmploymentRecordID])
REFERENCES [dbo].[tbl_foreign_employeement_record] ([ForeignEmploymentRecordID])
GO
ALTER TABLE [dbo].[tbl_training] CHECK CONSTRAINT [FK_tbl_training_tbl_foreign_employeement_record]
GO
/****** Object:  ForeignKey [FK_tbl_training_tbl_geo_based_ethnicity]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_training]  WITH CHECK ADD  CONSTRAINT [FK_tbl_training_tbl_geo_based_ethnicity] FOREIGN KEY([GeoBasedEthnicityID])
REFERENCES [dbo].[tbl_geo_based_ethnicity] ([GeoBasedEthnicityID])
GO
ALTER TABLE [dbo].[tbl_training] CHECK CONSTRAINT [FK_tbl_training_tbl_geo_based_ethnicity]
GO
/****** Object:  ForeignKey [FK_tbl_training_tbl_permanent_address]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_training]  WITH CHECK ADD  CONSTRAINT [FK_tbl_training_tbl_permanent_address] FOREIGN KEY([PermanentAddressID])
REFERENCES [dbo].[tbl_permanent_address] ([PermanentAddressID])
GO
ALTER TABLE [dbo].[tbl_training] CHECK CONSTRAINT [FK_tbl_training_tbl_permanent_address]
GO
/****** Object:  ForeignKey [FK_tbl_training_tbl_previous_training_record]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_training]  WITH CHECK ADD  CONSTRAINT [FK_tbl_training_tbl_previous_training_record] FOREIGN KEY([PreviousTrainingRecordID])
REFERENCES [dbo].[tbl_previous_training_record] ([PreviousTrainingRecordID])
GO
ALTER TABLE [dbo].[tbl_training] CHECK CONSTRAINT [FK_tbl_training_tbl_previous_training_record]
GO
/****** Object:  ForeignKey [FK_TRNTrainee_tbl_districts]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[TRNTrainee]  WITH CHECK ADD  CONSTRAINT [FK_TRNTrainee_tbl_districts] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[tbl_districts] ([DistrictID])
GO
ALTER TABLE [dbo].[TRNTrainee] CHECK CONSTRAINT [FK_TRNTrainee_tbl_districts]
GO
/****** Object:  ForeignKey [FK_TRNTrainee_tbl_districts1]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[TRNTrainee]  WITH CHECK ADD  CONSTRAINT [FK_TRNTrainee_tbl_districts1] FOREIGN KEY([CitizenshipIssueDistictID])
REFERENCES [dbo].[tbl_districts] ([DistrictID])
GO
ALTER TABLE [dbo].[TRNTrainee] CHECK CONSTRAINT [FK_TRNTrainee_tbl_districts1]
GO
/****** Object:  ForeignKey [FK_TRNTrainee_tbl_ethnicity]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[TRNTrainee]  WITH CHECK ADD  CONSTRAINT [FK_TRNTrainee_tbl_ethnicity] FOREIGN KEY([EthnicityID])
REFERENCES [dbo].[tbl_ethnicity] ([EthnicityID])
GO
ALTER TABLE [dbo].[TRNTrainee] CHECK CONSTRAINT [FK_TRNTrainee_tbl_ethnicity]
GO
/****** Object:  ForeignKey [FK_TRNTrainee_tbl_feed_duration_types]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[TRNTrainee]  WITH CHECK ADD  CONSTRAINT [FK_TRNTrainee_tbl_feed_duration_types] FOREIGN KEY([FeedDurationTypeID])
REFERENCES [dbo].[tbl_feed_duration_types] ([FeedDurationTypeID])
GO
ALTER TABLE [dbo].[TRNTrainee] CHECK CONSTRAINT [FK_TRNTrainee_tbl_feed_duration_types]
GO
/****** Object:  ForeignKey [FK_TRNTrainee_tbl_VDC]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[TRNTrainee]  WITH CHECK ADD  CONSTRAINT [FK_TRNTrainee_tbl_VDC] FOREIGN KEY([VDCID])
REFERENCES [dbo].[tbl_VDC] ([VDCID])
GO
ALTER TABLE [dbo].[TRNTrainee] CHECK CONSTRAINT [FK_TRNTrainee_tbl_VDC]
GO
/****** Object:  ForeignKey [FK_TRNTrainee_TRNEducationLevel]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[TRNTrainee]  WITH CHECK ADD  CONSTRAINT [FK_TRNTrainee_TRNEducationLevel] FOREIGN KEY([EducationLevelID])
REFERENCES [dbo].[TRNEducationLevel] ([ID])
GO
ALTER TABLE [dbo].[TRNTrainee] CHECK CONSTRAINT [FK_TRNTrainee_TRNEducationLevel]
GO
/****** Object:  ForeignKey [FK_TRNTrainee_TRNInformationSource]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[TRNTrainee]  WITH CHECK ADD  CONSTRAINT [FK_TRNTrainee_TRNInformationSource] FOREIGN KEY([InformationSourceID])
REFERENCES [dbo].[TRNInformationSource] ([ID])
GO
ALTER TABLE [dbo].[TRNTrainee] CHECK CONSTRAINT [FK_TRNTrainee_TRNInformationSource]
GO
/****** Object:  ForeignKey [FK_TRNTrainee_TRNTrainee]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[TRNTrainee]  WITH CHECK ADD  CONSTRAINT [FK_TRNTrainee_TRNTrainee] FOREIGN KEY([ID])
REFERENCES [dbo].[TRNTrainee] ([ID])
GO
ALTER TABLE [dbo].[TRNTrainee] CHECK CONSTRAINT [FK_TRNTrainee_TRNTrainee]
GO
/****** Object:  ForeignKey [FK_TRNTrainee_TRNTrainingEvent]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[TRNTrainee]  WITH CHECK ADD  CONSTRAINT [FK_TRNTrainee_TRNTrainingEvent] FOREIGN KEY([EventID])
REFERENCES [dbo].[TRNTrainingEvent] ([ID])
GO
ALTER TABLE [dbo].[TRNTrainee] CHECK CONSTRAINT [FK_TRNTrainee_TRNTrainingEvent]
GO
/****** Object:  ForeignKey [FK_TRNPreviousTraining_TRNTrainee]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[TRNPreviousTraining]  WITH CHECK ADD  CONSTRAINT [FK_TRNPreviousTraining_TRNTrainee] FOREIGN KEY([TraineeID])
REFERENCES [dbo].[TRNTrainee] ([ID])
GO
ALTER TABLE [dbo].[TRNPreviousTraining] CHECK CONSTRAINT [FK_TRNPreviousTraining_TRNTrainee]
GO
/****** Object:  ForeignKey [FK_TRNRecruitmentList_tbl_SaMI_profiles]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[TRNRecruitmentList]  WITH CHECK ADD  CONSTRAINT [FK_TRNRecruitmentList_tbl_SaMI_profiles] FOREIGN KEY([SaMIProfileID])
REFERENCES [dbo].[tbl_SaMI_profiles] ([SaMIProfileID])
GO
ALTER TABLE [dbo].[TRNRecruitmentList] CHECK CONSTRAINT [FK_TRNRecruitmentList_tbl_SaMI_profiles]
GO
/****** Object:  ForeignKey [FK_tbl_case_referral_history_tbl_cases]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_referral_history]  WITH CHECK ADD  CONSTRAINT [FK_tbl_case_referral_history_tbl_cases] FOREIGN KEY([CaseID])
REFERENCES [dbo].[tbl_cases] ([CaseID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_case_referral_history] CHECK CONSTRAINT [FK_tbl_case_referral_history_tbl_cases]
GO
/****** Object:  ForeignKey [FK_tbl_case_referral_history_tbl_stakeholders_new]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_referral_history]  WITH CHECK ADD  CONSTRAINT [FK_tbl_case_referral_history_tbl_stakeholders_new] FOREIGN KEY([NewPartnerID])
REFERENCES [dbo].[tbl_stakeholders] ([StakeHolderID])
GO
ALTER TABLE [dbo].[tbl_case_referral_history] CHECK CONSTRAINT [FK_tbl_case_referral_history_tbl_stakeholders_new]
GO
/****** Object:  ForeignKey [FK_tbl_case_referral_history_tbl_stakeholders_perv]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_referral_history]  WITH CHECK ADD  CONSTRAINT [FK_tbl_case_referral_history_tbl_stakeholders_perv] FOREIGN KEY([PreviousPartnerID])
REFERENCES [dbo].[tbl_stakeholders] ([StakeHolderID])
GO
ALTER TABLE [dbo].[tbl_case_referral_history] CHECK CONSTRAINT [FK_tbl_case_referral_history_tbl_stakeholders_perv]
GO
/****** Object:  ForeignKey [FK_case_follow_up_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_follow_up]  WITH CHECK ADD  CONSTRAINT [FK_case_follow_up_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_case_follow_up] CHECK CONSTRAINT [FK_case_follow_up_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_case_follow_up_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_follow_up]  WITH CHECK ADD  CONSTRAINT [FK_case_follow_up_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_case_follow_up] CHECK CONSTRAINT [FK_case_follow_up_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_case_follow_up_tbl_cases]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_follow_up]  WITH CHECK ADD  CONSTRAINT [FK_tbl_case_follow_up_tbl_cases] FOREIGN KEY([CaseID])
REFERENCES [dbo].[tbl_cases] ([CaseID])
GO
ALTER TABLE [dbo].[tbl_case_follow_up] CHECK CONSTRAINT [FK_tbl_case_follow_up_tbl_cases]
GO
/****** Object:  ForeignKey [FK_case_documentations_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_documentations]  WITH CHECK ADD  CONSTRAINT [FK_case_documentations_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_case_documentations] CHECK CONSTRAINT [FK_case_documentations_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_case_documentations_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_documentations]  WITH CHECK ADD  CONSTRAINT [FK_case_documentations_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_case_documentations] CHECK CONSTRAINT [FK_case_documentations_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_case_documentations_tbl_districts]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_documentations]  WITH CHECK ADD  CONSTRAINT [FK_tbl_case_documentations_tbl_districts] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[tbl_districts] ([DistrictID])
GO
ALTER TABLE [dbo].[tbl_case_documentations] CHECK CONSTRAINT [FK_tbl_case_documentations_tbl_districts]
GO
/****** Object:  ForeignKey [FK_tbl_case_documentations_tbl_referral_status]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_documentations]  WITH CHECK ADD  CONSTRAINT [FK_tbl_case_documentations_tbl_referral_status] FOREIGN KEY([ReferralStatusID])
REFERENCES [dbo].[tbl_referral_status] ([ReferralStausID])
GO
ALTER TABLE [dbo].[tbl_case_documentations] CHECK CONSTRAINT [FK_tbl_case_documentations_tbl_referral_status]
GO
/****** Object:  ForeignKey [FK_tbl_case_documentations_tbl_SaMI_profiles]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_case_documentations]  WITH CHECK ADD  CONSTRAINT [FK_tbl_case_documentations_tbl_SaMI_profiles] FOREIGN KEY([SaMIProfileID])
REFERENCES [dbo].[tbl_SaMI_profiles] ([SaMIProfileID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_case_documentations] CHECK CONSTRAINT [FK_tbl_case_documentations_tbl_SaMI_profiles]
GO
/****** Object:  ForeignKey [FK_tbl_fe_documents_per_SaMI_profile_tbl_document_types]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_fe_documents_per_SaMI_profile]  WITH CHECK ADD  CONSTRAINT [FK_tbl_fe_documents_per_SaMI_profile_tbl_document_types] FOREIGN KEY([DocumentTypeID])
REFERENCES [dbo].[tbl_document_types] ([DocumentTypeID])
GO
ALTER TABLE [dbo].[tbl_fe_documents_per_SaMI_profile] CHECK CONSTRAINT [FK_tbl_fe_documents_per_SaMI_profile_tbl_document_types]
GO
/****** Object:  ForeignKey [FK_tbl_fe_documents_per_SaMI_profile_tbl_SaMI_profiles]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_fe_documents_per_SaMI_profile]  WITH CHECK ADD  CONSTRAINT [FK_tbl_fe_documents_per_SaMI_profile_tbl_SaMI_profiles] FOREIGN KEY([SaMIProfileID])
REFERENCES [dbo].[tbl_SaMI_profiles] ([SaMIProfileID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_fe_documents_per_SaMI_profile] CHECK CONSTRAINT [FK_tbl_fe_documents_per_SaMI_profile_tbl_SaMI_profiles]
GO
/****** Object:  ForeignKey [FK_tbl_evidences_per_case_tbl_cases]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_evidences_per_case]  WITH CHECK ADD  CONSTRAINT [FK_tbl_evidences_per_case_tbl_cases] FOREIGN KEY([CaseID])
REFERENCES [dbo].[tbl_cases] ([CaseID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_evidences_per_case] CHECK CONSTRAINT [FK_tbl_evidences_per_case_tbl_cases]
GO
/****** Object:  ForeignKey [FK_tbl_evidences_per_case_tbl_evidences_per_case]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_evidences_per_case]  WITH CHECK ADD  CONSTRAINT [FK_tbl_evidences_per_case_tbl_evidences_per_case] FOREIGN KEY([EvidenceTypeID])
REFERENCES [dbo].[tbl_evidence_types] ([EvidenceTypeID])
GO
ALTER TABLE [dbo].[tbl_evidences_per_case] CHECK CONSTRAINT [FK_tbl_evidences_per_case_tbl_evidences_per_case]
GO
/****** Object:  ForeignKey [FK_services_provided_per_SaMI_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_services_provided_per_SaMI]  WITH CHECK ADD  CONSTRAINT [FK_services_provided_per_SaMI_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_services_provided_per_SaMI] CHECK CONSTRAINT [FK_services_provided_per_SaMI_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_services_provided_per_SaMI_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_services_provided_per_SaMI]  WITH CHECK ADD  CONSTRAINT [FK_services_provided_per_SaMI_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_services_provided_per_SaMI] CHECK CONSTRAINT [FK_services_provided_per_SaMI_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_services_provided_per_SaMI_tbl_SaMI_profiles]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_services_provided_per_SaMI]  WITH CHECK ADD  CONSTRAINT [FK_tbl_services_provided_per_SaMI_tbl_SaMI_profiles] FOREIGN KEY([SaMIProfileID])
REFERENCES [dbo].[tbl_SaMI_profiles] ([SaMIProfileID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_services_provided_per_SaMI] CHECK CONSTRAINT [FK_tbl_services_provided_per_SaMI_tbl_SaMI_profiles]
GO
/****** Object:  ForeignKey [FK_tbl_services_provided_per_SaMI_tbl_services_provided]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_services_provided_per_SaMI]  WITH CHECK ADD  CONSTRAINT [FK_tbl_services_provided_per_SaMI_tbl_services_provided] FOREIGN KEY([ServiceProvidedID])
REFERENCES [dbo].[tbl_services_provided] ([ServiceProvidedID])
GO
ALTER TABLE [dbo].[tbl_services_provided_per_SaMI] CHECK CONSTRAINT [FK_tbl_services_provided_per_SaMI_tbl_services_provided]
GO
/****** Object:  ForeignKey [FK_previous_fe_experiences_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_previous_fe_experiences]  WITH CHECK ADD  CONSTRAINT [FK_previous_fe_experiences_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_previous_fe_experiences] CHECK CONSTRAINT [FK_previous_fe_experiences_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_previous_fe_experiences_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_previous_fe_experiences]  WITH CHECK ADD  CONSTRAINT [FK_previous_fe_experiences_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_previous_fe_experiences] CHECK CONSTRAINT [FK_previous_fe_experiences_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_previous_fe_experiences_tbl_countries]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_previous_fe_experiences]  WITH CHECK ADD  CONSTRAINT [FK_tbl_previous_fe_experiences_tbl_countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[tbl_countries] ([CountryID])
GO
ALTER TABLE [dbo].[tbl_previous_fe_experiences] CHECK CONSTRAINT [FK_tbl_previous_fe_experiences_tbl_countries]
GO
/****** Object:  ForeignKey [FK_tbl_previous_fe_experiences_tbl_job_offered_types]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_previous_fe_experiences]  WITH CHECK ADD  CONSTRAINT [FK_tbl_previous_fe_experiences_tbl_job_offered_types] FOREIGN KEY([JobOfferedTypeID])
REFERENCES [dbo].[tbl_job_offered_types] ([JobOfferedTypeID])
GO
ALTER TABLE [dbo].[tbl_previous_fe_experiences] CHECK CONSTRAINT [FK_tbl_previous_fe_experiences_tbl_job_offered_types]
GO
/****** Object:  ForeignKey [FK_tbl_previous_fe_experiences_tbl_SaMI_profiles]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_previous_fe_experiences]  WITH CHECK ADD  CONSTRAINT [FK_tbl_previous_fe_experiences_tbl_SaMI_profiles] FOREIGN KEY([SaMIProfileID])
REFERENCES [dbo].[tbl_SaMI_profiles] ([SaMIProfileID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_previous_fe_experiences] CHECK CONSTRAINT [FK_tbl_previous_fe_experiences_tbl_SaMI_profiles]
GO
/****** Object:  ForeignKey [FK_foreign_employment_status_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_foreign_employment_status]  WITH CHECK ADD  CONSTRAINT [FK_foreign_employment_status_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_foreign_employment_status] CHECK CONSTRAINT [FK_foreign_employment_status_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_foreign_employment_status_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_foreign_employment_status]  WITH CHECK ADD  CONSTRAINT [FK_foreign_employment_status_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_foreign_employment_status] CHECK CONSTRAINT [FK_foreign_employment_status_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_foreign_employment_status_tbl_decision_status]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_foreign_employment_status]  WITH CHECK ADD  CONSTRAINT [FK_tbl_foreign_employment_status_tbl_decision_status] FOREIGN KEY([DecisionStatusID])
REFERENCES [dbo].[tbl_decision_status] ([DecisionStatusID])
GO
ALTER TABLE [dbo].[tbl_foreign_employment_status] CHECK CONSTRAINT [FK_tbl_foreign_employment_status_tbl_decision_status]
GO
/****** Object:  ForeignKey [FK_tbl_foreign_employment_status_tbl_passport_status]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_foreign_employment_status]  WITH CHECK ADD  CONSTRAINT [FK_tbl_foreign_employment_status_tbl_passport_status] FOREIGN KEY([PassportStatusID])
REFERENCES [dbo].[tbl_passport_status] ([PassportStatusID])
GO
ALTER TABLE [dbo].[tbl_foreign_employment_status] CHECK CONSTRAINT [FK_tbl_foreign_employment_status_tbl_passport_status]
GO
/****** Object:  ForeignKey [FK_tbl_foreign_employment_status_tbl_SaMI_profiles]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_foreign_employment_status]  WITH CHECK ADD  CONSTRAINT [FK_tbl_foreign_employment_status_tbl_SaMI_profiles] FOREIGN KEY([SaMIProfileID])
REFERENCES [dbo].[tbl_SaMI_profiles] ([SaMIProfileID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_foreign_employment_status] CHECK CONSTRAINT [FK_tbl_foreign_employment_status_tbl_SaMI_profiles]
GO
/****** Object:  ForeignKey [FK_other_member_migrations_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_member_migrations]  WITH CHECK ADD  CONSTRAINT [FK_other_member_migrations_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_other_member_migrations] CHECK CONSTRAINT [FK_other_member_migrations_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_other_member_migrations_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_member_migrations]  WITH CHECK ADD  CONSTRAINT [FK_other_member_migrations_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_other_member_migrations] CHECK CONSTRAINT [FK_other_member_migrations_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_other_member_migrations_tbl_countries]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_member_migrations]  WITH CHECK ADD  CONSTRAINT [FK_tbl_other_member_migrations_tbl_countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[tbl_countries] ([CountryID])
GO
ALTER TABLE [dbo].[tbl_other_member_migrations] CHECK CONSTRAINT [FK_tbl_other_member_migrations_tbl_countries]
GO
/****** Object:  ForeignKey [FK_tbl_other_member_migrations_tbl_family_members]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_member_migrations]  WITH CHECK ADD  CONSTRAINT [FK_tbl_other_member_migrations_tbl_family_members] FOREIGN KEY([FamilyMemberID])
REFERENCES [dbo].[tbl_family_members] ([FamilyMemberID])
GO
ALTER TABLE [dbo].[tbl_other_member_migrations] CHECK CONSTRAINT [FK_tbl_other_member_migrations_tbl_family_members]
GO
/****** Object:  ForeignKey [FK_tbl_other_member_migrations_tbl_SaMI_profiles]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_member_migrations]  WITH CHECK ADD  CONSTRAINT [FK_tbl_other_member_migrations_tbl_SaMI_profiles] FOREIGN KEY([SaMIProfileID])
REFERENCES [dbo].[tbl_SaMI_profiles] ([SaMIProfileID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_other_member_migrations] CHECK CONSTRAINT [FK_tbl_other_member_migrations_tbl_SaMI_profiles]
GO
/****** Object:  ForeignKey [FK_other_info_per_SaMI_profile_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_info_per_SaMI_profile]  WITH CHECK ADD  CONSTRAINT [FK_other_info_per_SaMI_profile_tbl_users_CreatedBy] FOREIGN KEY([SaMIProfileID])
REFERENCES [dbo].[tbl_SaMI_profiles] ([SaMIProfileID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_other_info_per_SaMI_profile] CHECK CONSTRAINT [FK_other_info_per_SaMI_profile_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_other_info_per_SaMI_profile_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_info_per_SaMI_profile]  WITH CHECK ADD  CONSTRAINT [FK_other_info_per_SaMI_profile_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_other_info_per_SaMI_profile] CHECK CONSTRAINT [FK_other_info_per_SaMI_profile_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_other_followup_per_service_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_followup_per_service]  WITH CHECK ADD  CONSTRAINT [FK_other_followup_per_service_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_other_followup_per_service] CHECK CONSTRAINT [FK_other_followup_per_service_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_other_followup_per_service_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_followup_per_service]  WITH CHECK ADD  CONSTRAINT [FK_other_followup_per_service_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_other_followup_per_service] CHECK CONSTRAINT [FK_other_followup_per_service_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_other_followup_per_service_tbl_services_provided_per_SaMI]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_other_followup_per_service]  WITH CHECK ADD  CONSTRAINT [FK_tbl_other_followup_per_service_tbl_services_provided_per_SaMI] FOREIGN KEY([ServiceProvidedPerSaMIID])
REFERENCES [dbo].[tbl_services_provided_per_SaMI] ([ServiceProvidedPerSaMIID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_other_followup_per_service] CHECK CONSTRAINT [FK_tbl_other_followup_per_service_tbl_services_provided_per_SaMI]
GO
/****** Object:  ForeignKey [FK_follow_up_per_services_tbl_users_CreatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_follow_up_per_services]  WITH CHECK ADD  CONSTRAINT [FK_follow_up_per_services_tbl_users_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_follow_up_per_services] CHECK CONSTRAINT [FK_follow_up_per_services_tbl_users_CreatedBy]
GO
/****** Object:  ForeignKey [FK_follow_up_per_services_tbl_users_UpdatedBy]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_follow_up_per_services]  WITH CHECK ADD  CONSTRAINT [FK_follow_up_per_services_tbl_users_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([UserID])
GO
ALTER TABLE [dbo].[tbl_follow_up_per_services] CHECK CONSTRAINT [FK_follow_up_per_services_tbl_users_UpdatedBy]
GO
/****** Object:  ForeignKey [FK_tbl_follow_up_per_services_tbl_services_provided_per_SaMI]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_follow_up_per_services]  WITH CHECK ADD  CONSTRAINT [FK_tbl_follow_up_per_services_tbl_services_provided_per_SaMI] FOREIGN KEY([ServiceProvidedPerSaMIID])
REFERENCES [dbo].[tbl_services_provided_per_SaMI] ([ServiceProvidedPerSaMIID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_follow_up_per_services] CHECK CONSTRAINT [FK_tbl_follow_up_per_services_tbl_services_provided_per_SaMI]
GO
/****** Object:  ForeignKey [FK_tbl_documents__tbl_other_member_migrations]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_documents_per_other_member_migration]  WITH CHECK ADD  CONSTRAINT [FK_tbl_documents__tbl_other_member_migrations] FOREIGN KEY([OtherMemberMigrationID])
REFERENCES [dbo].[tbl_other_member_migrations] ([OtherMemberMigrationID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_documents_per_other_member_migration] CHECK CONSTRAINT [FK_tbl_documents__tbl_other_member_migrations]
GO
/****** Object:  ForeignKey [FK_tbl_documents_per_other_member_migration_tbl_documents_behind]    Script Date: 10/10/2014 10:37:31 ******/
ALTER TABLE [dbo].[tbl_documents_per_other_member_migration]  WITH CHECK ADD  CONSTRAINT [FK_tbl_documents_per_other_member_migration_tbl_documents_behind] FOREIGN KEY([DocumentBehindID])
REFERENCES [dbo].[tbl_documents_behind] ([DocumentBehindID])
GO
ALTER TABLE [dbo].[tbl_documents_per_other_member_migration] CHECK CONSTRAINT [FK_tbl_documents_per_other_member_migration_tbl_documents_behind]
GO
