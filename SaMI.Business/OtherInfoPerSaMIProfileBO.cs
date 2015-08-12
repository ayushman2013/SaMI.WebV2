using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class OtherInfoPerSaMIProfileBO
    {
        public static int InsertOtherInfo(OtherInfoPerSaMIProfile objOtherInfoPerSaMIProfile, List<FEDocumentsPerSaMIProfile> lstFEDocumentsPerSaMIProfile)
        {
            return new OtherInfoPerSaMIProfileDAO().InsertOtherInfo(objOtherInfoPerSaMIProfile, lstFEDocumentsPerSaMIProfile);
        }

        public static OtherInfoPerSaMIProfile GetOtherInfo(int SaMIProfileID)
        {
            OtherInfoPerSaMIProfile objOtherInfoPerSaMIProfile = new OtherInfoPerSaMIProfile();
            return (OtherInfoPerSaMIProfile)(new OtherInfoPerSaMIProfileDAO().FillDTO(objOtherInfoPerSaMIProfile, "SaMIProfileID=" + SaMIProfileID));

        }

        public static int UpdateOtherInfo(OtherInfoPerSaMIProfile objOtherInfoPerSaMIProfile, List<FEDocumentsPerSaMIProfile> lstFEDocumentsPerSaMIProfile)
        {
            
            return new OtherInfoPerSaMIProfileDAO().UpdateOtherInfo(objOtherInfoPerSaMIProfile, lstFEDocumentsPerSaMIProfile);
        }
    }
}
