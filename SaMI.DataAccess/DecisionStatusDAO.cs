using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class DecisionStatusDAO : BaseDAO
    {
        public DecisionStatusDAO() : base() { }
        public DecisionStatusDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_decision_status";
            KeyField = "DecisionStatusID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "Select '' AS DecisionStatusID, '[Decision]' AS DecisionStatusDesc " +
                      "UNION " +
                      "SELECT DecisionStatusID, DecisionStatusDesc FROM tbl_decision_status " +
                         "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_decision_status " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertDecisionStatus(DecisionStatus objDecisionStatus)
        {
            objDecisionStatus.DecisionStatusID = 1;
            BeginTransaction();

            try
            {
                objDecisionStatus.DecisionStatusID = Insert(objDecisionStatus);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objDecisionStatus.DecisionStatusID = -1;
            }

            return objDecisionStatus.DecisionStatusID;
        }

        public int UpdateDecisionStatus(DecisionStatus objDecisionStatus)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "DecisionStatusDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objDecisionStatus, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteDecisionStatus(DecisionStatus objDecisionStatus)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objDecisionStatus, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectDecisionStatusIDForSync()
        {
            String sql = string.Empty;

            sql = "SELECT DecisionStatusID FROM tbl_decision_status " +
                     "WHERE SyncStatus='0'";
            return ExecuteQuery(sql);
        }
    }
}
