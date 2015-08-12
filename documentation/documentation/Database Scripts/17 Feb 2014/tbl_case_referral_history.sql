USE [db_SaMI]
GO

/****** Object:  Table [dbo].[tbl_case_referral_history]    Script Date: 02/13/2014 16:06:00 ******/
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
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tbl_case_referral_history]  WITH CHECK ADD  CONSTRAINT [FK_tbl_case_referral_history_tbl_cases] FOREIGN KEY([CaseID])
REFERENCES [dbo].[tbl_cases] ([CaseID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tbl_case_referral_history] CHECK CONSTRAINT [FK_tbl_case_referral_history_tbl_cases]
GO

ALTER TABLE [dbo].[tbl_case_referral_history]  WITH CHECK ADD  CONSTRAINT [FK_tbl_case_referral_history_tbl_stakeholders_new] FOREIGN KEY([NewPartnerID])
REFERENCES [dbo].[tbl_stakeholders] ([StakeHolderID])
GO

ALTER TABLE [dbo].[tbl_case_referral_history] CHECK CONSTRAINT [FK_tbl_case_referral_history_tbl_stakeholders_new]
GO

ALTER TABLE [dbo].[tbl_case_referral_history]  WITH CHECK ADD  CONSTRAINT [FK_tbl_case_referral_history_tbl_stakeholders_perv] FOREIGN KEY([PreviousPartnerID])
REFERENCES [dbo].[tbl_stakeholders] ([StakeHolderID])
GO

ALTER TABLE [dbo].[tbl_case_referral_history] CHECK CONSTRAINT [FK_tbl_case_referral_history_tbl_stakeholders_perv]
GO

ALTER TABLE [dbo].[tbl_case_referral_history] ADD  CONSTRAINT [DF_tbl_case_referral_history_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[tbl_case_referral_history] ADD  CONSTRAINT [DF_tbl_case_referral_history_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO


