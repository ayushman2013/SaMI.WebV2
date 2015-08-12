using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class OtherFollowupPerServiceBO
    {
        public static DataView GetAll(int ServiceProvidedPerSaMIID)
        {
            return new OtherFollowupPerServiceDAO().SelectAll(ServiceProvidedPerSaMIID);
        }

        public static DataView GetCustom(int ServiceProvidedPerSaMIID)
        {
            return new OtherFollowupPerServiceDAO().SelectCustom(ServiceProvidedPerSaMIID);
        }

        public static int InsertOtherFollowUp(OtherFollowupPerService objOtherFollowupPerService)
        {
            return new OtherFollowupPerServiceDAO().InsertOtherFollowUp(objOtherFollowupPerService);
        }

        public static int UpdateOtherFollowUp(OtherFollowupPerService objOtherFollowupPerService)
        {
            return new OtherFollowupPerServiceDAO().UpdateOtherFollowUp(objOtherFollowupPerService);
        }


        public static OtherFollowupPerService GetOtherFollowUpInfoPerService(int OtherFollowUpPerServiceID)
        {
            OtherFollowupPerService objOtherFollowupPerService = new OtherFollowupPerService();
            return (OtherFollowupPerService)(new OtherFollowupPerServiceDAO().FillDTO(objOtherFollowupPerService, "OtherFollowUpPerServiceID=" + OtherFollowUpPerServiceID));

        }

        public static int DeleteOtherFollowUp(int OtherFollowUpPerServiceID)
        {
            return new OtherFollowupPerServiceDAO().Delete("OtherFollowUpPerServiceID=" + OtherFollowUpPerServiceID);
        }

        public static DataView GetOtherFollowupPerServiceIDForSync(String CreatedBy)
        {
            return new OtherFollowupPerServiceDAO().SelectOtherFollowupPerServiceIDForSync(CreatedBy);
        }
    }
}
