using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class WorkTypesDAO : BaseDAO
    {
        public WorkTypesDAO() : base() { }
        public WorkTypesDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_work_types";
            KeyField = "WorkTypeID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '' AS WorkTypeID, '[Work Type]' AS WorkTypeDesc " +
                      "UNION " +
                      "SELECT WorkTypeID, WorkTypeDesc FROM tbl_work_types " +
                         "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_work_types " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }
        public int InsertWorkTypes(WorkTypes objWorkTypes)
        {
            objWorkTypes.WorkTypeID = 1;
            BeginTransaction();

            try
            {
                objWorkTypes.WorkTypeID = Insert(objWorkTypes);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objWorkTypes.WorkTypeID = -1;
            }

            return objWorkTypes.WorkTypeID;
        }
        public int UpdateWorkTypes(WorkTypes objWorkTypes)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "WorkTypeDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objWorkTypes, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteWorkTypes(WorkTypes objWorkTypes)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objWorkTypes, UpdateProperties);

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
