using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using SaMI.DTO;
using System.Data;
using System.Collections;

namespace SaMI.DataAccess
{
    public class FEDocumentsPerSaMIProfileDAO : BaseDAO
    {
        public FEDocumentsPerSaMIProfileDAO() : base() { }
        public FEDocumentsPerSaMIProfileDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_fe_documents_per_SaMI_profile";
            KeyField = "FEDocumentPerSaMIProfileID";
        }

        public DataView SelectAll(int SaMIProfileID)
        {
            String sql = "SELECT * FROM tbl_fe_documents_per_SaMI_profile WHERE SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public int InsertFEDocuments(FEDocumentsPerSaMIProfile objFEDocumentsPerSaMIProfile)
        {
            objFEDocumentsPerSaMIProfile.FEDocumentPerSaMIProfileID = 1;
            BeginTransaction();

            try
            {
                objFEDocumentsPerSaMIProfile.FEDocumentPerSaMIProfileID = Insert(objFEDocumentsPerSaMIProfile);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objFEDocumentsPerSaMIProfile.FEDocumentPerSaMIProfileID = -1;
            }

            return objFEDocumentsPerSaMIProfile.FEDocumentPerSaMIProfileID;
        }

        public int UpdateFEDocuments(FEDocumentsPerSaMIProfile objFEDocumentsPerSaMIProfile)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "DocumentTypeID" };
                rowsaffected = Update(objFEDocumentsPerSaMIProfile, UpdateProperties);

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
