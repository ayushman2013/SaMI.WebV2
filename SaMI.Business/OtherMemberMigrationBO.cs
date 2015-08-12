using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class OtherMemberMigrationBO
    {
        public static DataView GetAll(int SaMIProfileID)
        {
            return new OtherMemberMigrationDAO().SelectAll(SaMIProfileID);
        }

        public static DataView GetCustom(int SaMIProfileID)
        {
            return new OtherMemberMigrationDAO().SelectCustom(SaMIProfileID);
        }

        public static int InsertOtherMigration(OtherMemberMigrations objOtherMemberMigrations,
                                              List<DocumentsPerOtherMemberMigration> lstDocumentsPerOtherMemberMigration,
                                              List<ProblemsPerOtherMemberMigration> lstProblemsPerOtherMemberMigration)
        {
            return new OtherMemberMigrationDAO().InsertOtherMigration(objOtherMemberMigrations, lstDocumentsPerOtherMemberMigration, lstProblemsPerOtherMemberMigration);
        }

        public static int UpdateOtherMigration(OtherMemberMigrations objOtherMemberMigrations, 
                                              List<DocumentsPerOtherMemberMigration> lstDocumentsPerOtherMemberMigration,
                                              List<ProblemsPerOtherMemberMigration> lstProblemsPerOtherMemberMigration)
        {
            return new OtherMemberMigrationDAO().UpdateOtherMigration(objOtherMemberMigrations, lstDocumentsPerOtherMemberMigration, lstProblemsPerOtherMemberMigration);
        }

        public static OtherMemberMigrations GetOtherMemberMigration(int OtherMemberMigrationID)
        {
            OtherMemberMigrations objOtherMemberMigrations = new OtherMemberMigrations();
            return (OtherMemberMigrations)(new OtherMemberMigrationDAO().FillDTO(objOtherMemberMigrations, "OtherMemberMigrationID=" + OtherMemberMigrationID));

        }

        public static int DeleteOtherMemberMigrant(int OtherMemberMigrationID)
        {
            return new OtherMemberMigrationDAO().Delete("OtherMemberMigrationID=" + OtherMemberMigrationID);
        }
    }
}
