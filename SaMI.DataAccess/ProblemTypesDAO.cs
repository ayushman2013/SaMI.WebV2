using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class ProblemTypesDAO : BaseDAO
    {
        public ProblemTypesDAO() : base() { }
        public ProblemTypesDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_problem_types";
            KeyField = "ProblemTypeID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '' AS ProblemTypeID, '[Select]' AS ProblemTypeDesc " +
                      "UNION " +
                      "SELECT ProblemTypeID, ProblemTypeDesc FROM tbl_problem_types " +
                         "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_problem_types " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertProblemTypes(ProblemsTypes objProblemTypes)
        {
            objProblemTypes.ProblemTypeID = 1;
            BeginTransaction();

            try
            {
                objProblemTypes.ProblemTypeID = Insert(objProblemTypes);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objProblemTypes.ProblemTypeID = -1;
            }

            return objProblemTypes.ProblemTypeID;
        }
        public int UpdateProblemsTypes(ProblemsTypes objProblemsTypes)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "ProblemTypeDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objProblemsTypes, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteProblemsTypes(ProblemsTypes objProblemsTypes)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objProblemsTypes, UpdateProperties);

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
