/*
   Sunday, August 17, 20142:54:41 PM
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
ALTER TABLE dbo.tbl_users ADD
	SkillPartnerID int NOT NULL CONSTRAINT DF_tbl_users_SkillPartnerID DEFAULT 0
GO
ALTER TABLE dbo.tbl_users SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
