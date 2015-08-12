using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class FEDocumentsPerSaMIProfileBO
    {
        public static List<FEDocumentsPerSaMIProfile> GetAll(int SaMIProfileID)
        {
            List<FEDocumentsPerSaMIProfile> lstFEDocumentsPerSaMIProfile = new List<FEDocumentsPerSaMIProfile>();

            DataView objDataView = new FEDocumentsPerSaMIProfileDAO().SelectAll(SaMIProfileID);

            foreach (DataRowView drv in objDataView)
            {
                FEDocumentsPerSaMIProfile objFEDocumentsPerSaMIProfile = new FEDocumentsPerSaMIProfile();
                objFEDocumentsPerSaMIProfile.FEDocumentPerSaMIProfileID = (int)drv["FEDocumentPerSaMIProfileID"];
                objFEDocumentsPerSaMIProfile.SaMIProfileID = (int)drv["SaMIProfileID"];
                objFEDocumentsPerSaMIProfile.DocumentTypeID = (int)drv["DocumentTypeID"];
                lstFEDocumentsPerSaMIProfile.Add(objFEDocumentsPerSaMIProfile);
            }

            return lstFEDocumentsPerSaMIProfile;
        }

        public static int InsertFEDocuments(FEDocumentsPerSaMIProfile objFEDocumentsPerSaMIProfile)
        {
            return new FEDocumentsPerSaMIProfileDAO().InsertFEDocuments(objFEDocumentsPerSaMIProfile);
        }

        public static int UpdateFEDocuments(FEDocumentsPerSaMIProfile objFEDocumentsPerSaMIProfile)
        {
            return new FEDocumentsPerSaMIProfileDAO().UpdateFEDocuments(objFEDocumentsPerSaMIProfile);
        }

        public static FEDocumentsPerSaMIProfile GetFEExperience(int SaMIProfileID)
        {
            FEDocumentsPerSaMIProfile objFEDocumentsPerSaMIProfile = new FEDocumentsPerSaMIProfile();
            return (FEDocumentsPerSaMIProfile)(new FEDocumentsPerSaMIProfileDAO().FillDTO(objFEDocumentsPerSaMIProfile, "SaMIProfileID=" + SaMIProfileID));

        }
    }
}
