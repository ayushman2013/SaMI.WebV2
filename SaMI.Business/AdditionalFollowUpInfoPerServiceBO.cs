using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;


namespace SaMI.Business
{
    public class AdditionalFollowUpInfoPerServiceBO
    {
        public static DataView GetAll(int ServiceProvidedPerSaMIID)
        {
            return new AdditionalFollowUpInfoPerServiceDAO().SelectAll(ServiceProvidedPerSaMIID);
        }

        public static int InsertAdditionalFollowUp(AdditionalFollowUpInfoPerServices objAdditionalFollowUpInfoPerServices)
        {
            return new AdditionalFollowUpInfoPerServiceDAO().InsertAdditionalFollowUp(objAdditionalFollowUpInfoPerServices);
        }

        public static int UpdateAdditionalFollowUp(AdditionalFollowUpInfoPerServices objAdditionalFollowUpInfoPerServices)
        {
            return new AdditionalFollowUpInfoPerServiceDAO().UpdateAdditionalFollowUp(objAdditionalFollowUpInfoPerServices);
        }

        public static AdditionalFollowUpInfoPerServices GetAdditionalFollowUpInfoPerService(int ServiceProvidedPerSaMIID)
        {
            AdditionalFollowUpInfoPerServices objFollowUpPerServicesID = new AdditionalFollowUpInfoPerServices();
            return (AdditionalFollowUpInfoPerServices)(new AdditionalFollowUpInfoPerServiceDAO().FillDTO(objFollowUpPerServicesID, "ServiceProvidedPerSaMIID=" + ServiceProvidedPerSaMIID));

        }

        public static List<AdditionalFollowUpInfoPerServices> GetAllByServiceProvidedPerSaMIID(int ServiceProvidedPerSaMIID)
        {
            List<AdditionalFollowUpInfoPerServices> lstAdditionalFollowUpInfoPerServices = new List<AdditionalFollowUpInfoPerServices>();

            DataView objDataView = new AdditionalFollowUpInfoPerServiceDAO().SelectAll(ServiceProvidedPerSaMIID);

            foreach (DataRowView drv in objDataView)
            {
                AdditionalFollowUpInfoPerServices objAdditionalFollowUpInfoPerServices = new AdditionalFollowUpInfoPerServices();
                objAdditionalFollowUpInfoPerServices.AdditionalFollowUpInfoPerServiceID = (int)drv["AdditionalFollowUpInfoPerServiceID"];
                objAdditionalFollowUpInfoPerServices.ServiceProvidedPerSaMIID = (int)drv["ServiceProvidedPerSaMIID"];
                objAdditionalFollowUpInfoPerServices.AdditionalFollowupInfoID = (int)drv["AdditionalFollowupInfoID"];
                lstAdditionalFollowUpInfoPerServices.Add(objAdditionalFollowUpInfoPerServices);
            }

            return lstAdditionalFollowUpInfoPerServices;
        }

        public static AdditionalFollowUpInfoPerServices GetAdditionalFollowUpInfoPerServices(int AdditionalFollowUpInfoPerServiceID)
        {
            AdditionalFollowUpInfoPerServices objFollowUpPerServicesID = new AdditionalFollowUpInfoPerServices();
            return (AdditionalFollowUpInfoPerServices)(new AdditionalFollowUpInfoPerServiceDAO().FillDTO(objFollowUpPerServicesID, "AdditionalFollowUpInfoPerServiceID=" + AdditionalFollowUpInfoPerServiceID));

        }

        public static DataView GetAdditionalFollowUpInfoPerServicesIDForSync(String CreatedBy)
        {
            return new AdditionalFollowUpInfoPerServiceDAO().GetAdditionalFollowUpInfoPerServicesIDForSync(CreatedBy);
        }
    }
}
