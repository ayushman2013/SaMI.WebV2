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
    public class CaseDocumentationsDAO : BaseDAO
    {
        public CaseDocumentationsDAO() : base() { }
        public CaseDocumentationsDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_case_documentations";
            KeyField = "CaseDocumentationID";
        }

        public DataView SelectAll()
        {
            String sql = "SELECT * FROM tbl_case_documentations";
            return ExecuteQuery(sql);
        }

        public DataView SelectBySaMIProfileID(int SaMIProfileID)
        {
            String sql = "SELECT * FROM tbl_case_documentations WHERE SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public int InsertCase(CaseDocumentations objCaseDocumentations)
        {
            objCaseDocumentations.CaseDocumentationID = 1;
            BeginTransaction();

            try
            {
                objCaseDocumentations.CaseDocumentationID = Insert(objCaseDocumentations);  
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objCaseDocumentations.CaseDocumentationID = -1;
            }

            return objCaseDocumentations.CaseDocumentationID;
        }

        public int UpdateCase(CaseDocumentations objCaseDocumentations)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "ReferralToID", 
                                                            "NonReferredReasonID", "ReferralStatusID", "DateOfReferral",
                                                            "IsDifficultyFaced", "DifficultyFacedRemarks", "UpdatedBy",
                                                            "UpdatedDate"
                                                            };
                rowsaffected = Update(objCaseDocumentations, UpdateProperties);

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
