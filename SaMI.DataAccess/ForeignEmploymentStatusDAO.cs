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
    public class ForeignEmploymentStatusDAO : BaseDAO
    {
        public ForeignEmploymentStatusDAO() : base() { }
        public ForeignEmploymentStatusDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_foreign_employment_status";
            KeyField = "ForeignEmploymentStatusID";
        }

        public DataView SelectAll(int SaMIProfileID)
        {
            String sql = "SELECT * FROM tbl_foreign_employment_status WHERE SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public int InsertFEStatus(ForeignEmploymentStatus objForeignEmploymentStatus)
        {
            objForeignEmploymentStatus.ForeignEmploymentStatusID = 1;
            BeginTransaction();

            try
            {
                objForeignEmploymentStatus.ForeignEmploymentStatusID = Insert(objForeignEmploymentStatus);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objForeignEmploymentStatus.ForeignEmploymentStatusID = -1;
            }

            return objForeignEmploymentStatus.ForeignEmploymentStatusID;
        }

        public int UpdateFEStatus(ForeignEmploymentStatus objForeignEmploymentStatus)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "DecisionStatusID", "PassportStatusID", "HaveJobOffer", 
                                                            "JobOfferSourceID", "JobOfferedTypeID", "WorkTypeID",
                                                            "MadePaymentAmount", "AskedPaymentAmount", "ICKnowledgeID",
                                                            "NothingAskedYet", "HavePaymentReceipt",
                                                            "ReceiptPaymentAmount", "UpdatedBy", "UpdatedDate", "CountryID",
                                                            "ReferToFSkill", "ReferToCase", "SyncStatus"
                                                            };
                rowsaffected = Update(objForeignEmploymentStatus, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int UpdateFSkillReferred(ForeignEmploymentStatus objForeignEmploymentStatus)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "UpdatedBy", "UpdatedDate", "ReferToFSkill" };
                rowsaffected = Update(objForeignEmploymentStatus, UpdateProperties);


                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int UpdateCaseReferred(ForeignEmploymentStatus objForeignEmploymentStatus)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "UpdatedBy", "UpdatedDate", "ReferToCase" };
                rowsaffected = Update(objForeignEmploymentStatus, UpdateProperties);


                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectForeignEmploymentStatusIDForSync(String CreatedBy)
        {
            String sql = "SELECT ForeignEmploymentStatusID FROM tbl_foreign_employment_status WHERE SyncStatus='0' AND " + CreatedBy;
            return ExecuteQuery(sql);
        }

    }
}
