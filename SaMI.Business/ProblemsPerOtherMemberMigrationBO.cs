using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class ProblemsPerOtherMemberMigrationBO
    {
        public static List<ProblemsPerOtherMemberMigration> GetAllByOtherMemberMigrationID(int OtherMemberMigrationID)
        {
            List<ProblemsPerOtherMemberMigration> lstProblemsPerOtherMemberMigration = new List<ProblemsPerOtherMemberMigration>();

            DataView objDataView = new DocumentsBehindDAO().Select("*", "tbl_problems_per_other_member_migration", "OtherMemberMigrationID=" + OtherMemberMigrationID);

            foreach (DataRowView drv in objDataView)
            {
                ProblemsPerOtherMemberMigration objProblemsPerOtherMemberMigration = new ProblemsPerOtherMemberMigration();
                objProblemsPerOtherMemberMigration.ProblemPerOtherMemberMigrationID = (int)drv["ProblemPerOtherMemberMigrationID"];
                objProblemsPerOtherMemberMigration.OtherMemberMigrationID = (int)drv["OtherMemberMigrationID"];
                objProblemsPerOtherMemberMigration.ProblemTypeID = (int)drv["ProblemTypeID"];
                lstProblemsPerOtherMemberMigration.Add(objProblemsPerOtherMemberMigration);
            }
            return lstProblemsPerOtherMemberMigration;
        }
    }
}
