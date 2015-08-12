using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using SaMI.DTO;
using System.Data;
using System.Collections;

namespace SaMI.DataAccess
{
    public class OtherMemberMigrationDAO : BaseDAO
    {
        public OtherMemberMigrationDAO() : base() { }
        public OtherMemberMigrationDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_other_member_migrations";
            KeyField = "OtherMemberMigrationID";
        }

        public DataView SelectAll(int SaMIProfileID)
        {
            String sql = "SELECT * FROM tbl_other_member_migrations WHERE SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public DataView SelectCustom(int SaMIProfileID)
        {
            String sql = "SELECT OMM.OtherMemberMigrationID, FM.FamilyMemberName, C.CountryName, P.ProblemTypeDesc, " +
                            "CASE OMM.DoesSendMoney " +
	                         "   When 0 then 'No' " +
	                          "  Else " +
	                           "   (SELECT MoneyRangeDesc FROM tbl_money_ranges WHERE MoneyRangeID = OMM.MoneyRangeID) " +
	                            "END AS Remittance, " +
                            "CASE (SELECT COUNT(OtherMemberMigrationID) FROM tbl_documents_per_other_member_migration WHERE OtherMemberMigrationID = OMM.OtherMemberMigrationID) " +
	                         "   WHEN 0 then 'No' " +
	                          "  Else 'Yes' " +
	                           " END AS DocumentsLeft " +
				                "FROM tbl_other_member_migrations  AS OMM " +
                            "JOIN tbl_family_members FM ON FM.FamilyMemberID = OMM.FamilyMemberID " +
                            "JOIN tbl_countries C ON C.CountryID = OMM.CountryID " +
                            "LEFT JOIN tbl_problem_types P ON P.ProblemTypeID = OMM.ProblemID " +
                            "WHERE OMM.SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public int InsertOtherMigration(OtherMemberMigrations objOtherMemberMigrations,
                                        List<DocumentsPerOtherMemberMigration> lstDocumentsPerOtherMemberMigration,
                                        List<ProblemsPerOtherMemberMigration> lstProblemsPerOtherMemberMigration)
        {
            objOtherMemberMigrations.OtherMemberMigrationID = 1;
            BeginTransaction();

            try
            {
                objOtherMemberMigrations.OtherMemberMigrationID = Insert(objOtherMemberMigrations);

                foreach (DocumentsPerOtherMemberMigration objDocumentsPerOtherMemberMigration in lstDocumentsPerOtherMemberMigration)
                {
                    objDocumentsPerOtherMemberMigration.OtherMemberMigrationID = objOtherMemberMigrations.OtherMemberMigrationID;
                    Insert(objDocumentsPerOtherMemberMigration);
                }
                foreach (ProblemsPerOtherMemberMigration objProblemsPerOtherMemberMigration in lstProblemsPerOtherMemberMigration)
                {
                    objProblemsPerOtherMemberMigration.OtherMemberMigrationID = objOtherMemberMigrations.OtherMemberMigrationID;
                    Insert(objProblemsPerOtherMemberMigration);
                }

                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objOtherMemberMigrations.OtherMemberMigrationID = -1;
            }

            return objOtherMemberMigrations.OtherMemberMigrationID;
        }

        public int UpdateOtherMigration(OtherMemberMigrations objOtherMemberMigrations, 
                                        List<DocumentsPerOtherMemberMigration> lstDocumentsPerOtherMemberMigration,
                                        List<ProblemsPerOtherMemberMigration> lstProblemsPerOtherMemberMigration)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "FamilyMemberID", "CountryID", "DoesSendMoney", 
                                                            "MoneyRangeID", "FacedProblem",
                                                            "ProblemID", "VisitSameCountry", "UpdatedBy", "UpdatedDate"
                                                            };
                rowsaffected = Update(objOtherMemberMigrations, UpdateProperties);

                Delete("tbl_documents_per_other_member_migration", "OtherMemberMigrationID = " + objOtherMemberMigrations.OtherMemberMigrationID);
                foreach (DocumentsPerOtherMemberMigration objDocumentsPerOtherMemberMigration in lstDocumentsPerOtherMemberMigration)
                {
                    objDocumentsPerOtherMemberMigration.OtherMemberMigrationID = objOtherMemberMigrations.OtherMemberMigrationID;
                    Insert(objDocumentsPerOtherMemberMigration);
                }

                Delete("tbl_problems_per_other_member_migration", "OtherMemberMigrationID = " + objOtherMemberMigrations.OtherMemberMigrationID);
                foreach (ProblemsPerOtherMemberMigration objProblemsPerOtherMemberMigration in lstProblemsPerOtherMemberMigration)
                {
                    objProblemsPerOtherMemberMigration.OtherMemberMigrationID = objOtherMemberMigrations.OtherMemberMigrationID;
                    Insert(objProblemsPerOtherMemberMigration);
                }

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }
    }
}
