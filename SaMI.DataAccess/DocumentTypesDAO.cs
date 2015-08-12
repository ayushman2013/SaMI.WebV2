using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
   public class DocumentTypesDAO : BaseDAO
    {
       public DocumentTypesDAO() : base() { }
       public DocumentTypesDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_document_types";
            KeyField = "DocumentTypeID";
        }

        public DataView SelectAll()
        {
            String sql = string.Empty;
            sql = "SELECT * FROM tbl_document_types " +
                       "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertDocumentTypes(DocumentTypes objDocumentTypes)
        {
            objDocumentTypes.DocumentTypeID = 1;
            BeginTransaction();

            try
            {
                objDocumentTypes.DocumentTypeID = Insert(objDocumentTypes);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objDocumentTypes.DocumentTypeID = -1;
            }

            return objDocumentTypes.DocumentTypeID;
        }

        public int UpdateDocumentTypes(DocumentTypes objDocumentTypes)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "DocumentTypeDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objDocumentTypes, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;
        }

        public int DeleteDocumentTypes(DocumentTypes objDocumentTypes)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objDocumentTypes, UpdateProperties);

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
