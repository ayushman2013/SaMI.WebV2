using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class DocumentsBehindDAO : BaseDAO
    {
        public DocumentsBehindDAO() : base() { }
        public DocumentsBehindDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_documents_behind";
            KeyField = "DocumentBehindID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '' AS DocumentBehindID, '[Select]' AS DocumentBehindDesc " +
                      "UNION " +
                      "SELECT DocumentBehindID, DocumentBehindDesc FROM tbl_documents_behind " +
                       "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_documents_behind " +
                       "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertDocumentsBehind(DocumentsBehind objDocumentsBehind)
        {
            objDocumentsBehind.DocumentBehindID = 1;
            BeginTransaction();

            try
            {
                objDocumentsBehind.DocumentBehindID = Insert(objDocumentsBehind);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objDocumentsBehind.DocumentBehindID = -1;
            }

            return objDocumentsBehind.DocumentBehindID;
        }

        public int UpdateDocumentsBehind(DocumentsBehind objDocumentsBehind)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "DocumentBehindDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objDocumentsBehind, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteDocumentsBehind(DocumentsBehind objDocumentsBehind)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objDocumentsBehind, UpdateProperties);

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
