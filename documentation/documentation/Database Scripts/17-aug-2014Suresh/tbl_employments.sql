/*
   Sunday, August 17, 20144:54:23 PM
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
ALTER TABLE dbo.tbl_employments
	DROP CONSTRAINT FK_tbl_employments_tbl_SaMI_profiles
GO
ALTER TABLE dbo.tbl_SaMI_profiles SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
EXECUTE sp_rename N'dbo.tbl_employments.SaMIProfileID', N'Tmp_EmploymentSkillID_2', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.tbl_employments.Tmp_EmploymentSkillID_2', N'EmploymentSkillID', 'COLUMN' 
GO
ALTER TABLE dbo.tbl_employments SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
