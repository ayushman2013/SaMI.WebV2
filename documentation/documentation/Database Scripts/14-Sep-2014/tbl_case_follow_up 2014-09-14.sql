/*
   Sunday, September 14, 20144:14:42 PM
   User: sa
   Server: ANIMESH
   Database: db_SaMI
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tbl_case_follow_up
	DROP CONSTRAINT FK_tbl_case_follow_up_tbl_SaMI_profiles
GO
ALTER TABLE dbo.tbl_SaMI_profiles SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tbl_case_follow_up ADD CONSTRAINT
	DF_tbl_case_follow_up_SaMIProfileID DEFAULT 0 FOR SaMIProfileID
GO
ALTER TABLE dbo.tbl_case_follow_up SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
