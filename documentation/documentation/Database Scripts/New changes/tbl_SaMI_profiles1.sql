/*
   Tuesday, September 2, 201411:10:53 AM
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
ALTER TABLE dbo.tbl_SaMI_profiles
	DROP CONSTRAINT DF_tbl_SaMI_profiles_ReferStatus

GO
ALTER TABLE dbo.tbl_SaMI_profiles SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
