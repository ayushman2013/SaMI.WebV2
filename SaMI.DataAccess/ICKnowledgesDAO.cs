using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class ICKnowledgesDAO: BaseDAO
    {
         public ICKnowledgesDAO() : base() { }
         public ICKnowledgesDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_ic_knowledges";
            KeyField = "ICKnowledgeID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '' AS ICKnowledgeID, '[Select]' AS ICKnowledgeDesc " +
                      "UNION " +
                      "SELECT ICKnowledgeID, ICKnowledgeDesc FROM tbl_ic_knowledges " +
                         "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_ic_knowledges " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertICKnowledges(ICKnowledges objICKnowledges)
        {
            objICKnowledges.ICKnowledgeID = 1;
            BeginTransaction();

            try
            {
                objICKnowledges.ICKnowledgeID = Insert(objICKnowledges);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objICKnowledges.ICKnowledgeID = -1;
            }

            return objICKnowledges.ICKnowledgeID;
        }

        public int UpdateICKnowledges(ICKnowledges objICKnowledges)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "ICKnowledgeDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objICKnowledges, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteICKnowledges(ICKnowledges objICKnowledges)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objICKnowledges, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectICKnowledgeIDForSync()
        {
            String sql = string.Empty;
            sql = "SELECT ICKnowledgeID FROM tbl_ic_knowledges " +
                     "WHERE SyncStatus='0'";
            return ExecuteQuery(sql);
        }
    }
}
