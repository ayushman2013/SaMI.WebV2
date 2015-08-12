USE [db_SaMI]
GO

/****** Object:  Table [dbo].[tbl_case_referred]    Script Date: 09/04/2014 13:53:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_case_referred](
	[CaseReferredID] [int] IDENTITY(1,1) NOT NULL,
	[SaMIProfileID] [int] NOT NULL,
	[ReferStatus] [tinyint] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_case_referred] PRIMARY KEY CLUSTERED 
(
	[CaseReferredID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


