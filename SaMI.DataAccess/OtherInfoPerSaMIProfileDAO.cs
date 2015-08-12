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
    public class OtherInfoPerSaMIProfileDAO : BaseDAO
    {
        public OtherInfoPerSaMIProfileDAO() : base() { }
        public OtherInfoPerSaMIProfileDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_other_info_per_SaMI_profile";
            KeyField = "OtherInfoPerSaMIProfileID";
        }

        public DataView SelectAll(int SaMIProfileID)
        {
            String sql = "SELECT * FROM tbl_other_info_per_SaMI_profile WHERE SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public int InsertOtherInfo(OtherInfoPerSaMIProfile objOtherInfoPerSaMIProfile, List<FEDocumentsPerSaMIProfile> lstFEDocumentsPerSaMIProfile)
        {
            objOtherInfoPerSaMIProfile.OtherInfoPerSaMIProfileID = 1;
            BeginTransaction();

            try
            {
                objOtherInfoPerSaMIProfile.OtherInfoPerSaMIProfileID = Insert(objOtherInfoPerSaMIProfile);


                foreach (FEDocumentsPerSaMIProfile objFEDocumentsPerSaMIProfile in lstFEDocumentsPerSaMIProfile)
                {
                    objFEDocumentsPerSaMIProfile.SaMIProfileID = objOtherInfoPerSaMIProfile.SaMIProfileID;
                    Insert(objFEDocumentsPerSaMIProfile);
                }


                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objOtherInfoPerSaMIProfile.OtherInfoPerSaMIProfileID = -1;
            }

            return objOtherInfoPerSaMIProfile.OtherInfoPerSaMIProfileID;
        }

        public int UpdateOtherInfo(OtherInfoPerSaMIProfile objOtherInfoPerSaMIProfile, List<FEDocumentsPerSaMIProfile> lstFEDocumentsPerSaMIProfile)
        {
            int rowsaffected = 1;
            BeginTransaction();

            try
            {
                objOtherInfoPerSaMIProfile.OtherInfoPerSaMIProfileID = Insert(objOtherInfoPerSaMIProfile);

                String[] UpdateProperties = new String[] { "HaveExperienceOrTraining", "IsPreviousForeignExperienced", "UpdatedBy", "UpdatedDate", "HaveJobExperience"
                                                            };
                rowsaffected = Update(objOtherInfoPerSaMIProfile, UpdateProperties);

                Delete("tbl_fe_documents_per_SaMI_profile", "SaMIProfileID = " + objOtherInfoPerSaMIProfile.SaMIProfileID);
                foreach (FEDocumentsPerSaMIProfile objFEDocumentsPerSaMIProfile in lstFEDocumentsPerSaMIProfile)
                {
                    objFEDocumentsPerSaMIProfile.SaMIProfileID = objOtherInfoPerSaMIProfile.SaMIProfileID;
                    Insert(objFEDocumentsPerSaMIProfile);
                }

              

                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }

            return rowsaffected;
        }

    }
}
