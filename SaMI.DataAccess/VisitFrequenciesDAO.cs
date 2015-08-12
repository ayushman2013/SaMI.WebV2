using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class VisitFrequenciesDAO : BaseDAO
    {
        public VisitFrequenciesDAO() : base() { }
        public VisitFrequenciesDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_visit_frequencies";
            KeyField = "VisitFrequencyID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '' AS VisitFrequencyID, '[Select]' AS VisitFrequencyDesc " +
                      "UNION " +
                      "SELECT VisitFrequencyID, VisitFrequencyDesc FROM tbl_visit_frequencies " +
                         "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_visit_frequencies " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertVisitFrequencies(VisitFrequencies objVisitFrequencies)
        {
            objVisitFrequencies.VisitFrequencyID = 1;
            BeginTransaction();

            try
            {
                objVisitFrequencies.VisitFrequencyID = Insert(objVisitFrequencies);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objVisitFrequencies.VisitFrequencyID = -1;
            }

            return objVisitFrequencies.VisitFrequencyID;
        }
        public int UpdateVisitFrequencies(VisitFrequencies objVisitFrequencies)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "VisitFrequencyDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objVisitFrequencies, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteVisitFrequencies(VisitFrequencies objVisitFrequencies)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objVisitFrequencies, UpdateProperties);

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
