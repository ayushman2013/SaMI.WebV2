using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class DocumentsPerOtherMemberMigrationBO
    {
        public static List<DocumentsPerOtherMemberMigration> GetAllByOtherMemberMigrationID(int OtherMemberMigrationID)
        {
            List<DocumentsPerOtherMemberMigration> lstDocumentsPerOtherMemberMigration = new List<DocumentsPerOtherMemberMigration>();

            DataView objDataView = new DocumentsBehindDAO().Select("*", "tbl_documents_per_other_member_migration", "OtherMemberMigrationID=" + OtherMemberMigrationID);

            foreach (DataRowView drv in objDataView)
            {
                DocumentsPerOtherMemberMigration objDocumentsPerOtherMemberMigration = new DocumentsPerOtherMemberMigration();
                objDocumentsPerOtherMemberMigration.DocumentsPerOtherMemberMigrationID = (int)drv["DocumentsPerOtherMemberMigrationID"];
                objDocumentsPerOtherMemberMigration.OtherMemberMigrationID = (int)drv["OtherMemberMigrationID"];
                objDocumentsPerOtherMemberMigration.DocumentBehindID = (int)drv["DocumentBehindID"];
                lstDocumentsPerOtherMemberMigration.Add(objDocumentsPerOtherMemberMigration);
            }

            return lstDocumentsPerOtherMemberMigration;
        }
    }
}
