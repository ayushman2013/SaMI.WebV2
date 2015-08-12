using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class ServicesProvidedPerSaMIBO
    {
        public static DataView GetAll(int SaMIProfileID)
        {
            return new ServicesProvidedPerSaMIDAO().SelectAll(SaMIProfileID);
        }

        public static int InsertServiceProvided(ServicesProvidedPerSaMI objServicesProvidedPerSaMI, FollowUpPerServices objFollowServices, List<AdditionalFollowUpInfoPerServices> lstAdditionalFollowUpInfoPerServices)
        {
            return new ServicesProvidedPerSaMIDAO().InsertServiceProvided(objServicesProvidedPerSaMI, objFollowServices, lstAdditionalFollowUpInfoPerServices);
        }

        public static int UpdateServiceProvided(ServicesProvidedPerSaMI objServicesProvidedPerSaMI, FollowUpPerServices objFollowServices, List<AdditionalFollowUpInfoPerServices> lstAdditionalFollowUpInfoPerServices)
        {
            return new ServicesProvidedPerSaMIDAO().UpdateServiceProvided(objServicesProvidedPerSaMI, objFollowServices, lstAdditionalFollowUpInfoPerServices);
        }

        public static ServicesProvidedPerSaMI GetServicesProvidedPerSaMI(int SaMIProfileID)
        {
            ServicesProvidedPerSaMI objServicesProvidedPerSaMIID = new ServicesProvidedPerSaMI();
            return (ServicesProvidedPerSaMI)(new ServicesProvidedPerSaMIDAO().FillDTO(objServicesProvidedPerSaMIID, "SaMIProfileID=" + SaMIProfileID));
        }

        public static DataView GetServicesProvidedPerSaMIIDForSync(String CreatedBy)
        {
            return new ServicesProvidedPerSaMIDAO().SelectServicesProvidedPerSaMIIDForSync(CreatedBy);
        }

        public static ServicesProvidedPerSaMI GetServicesProvidedPerSaMIID(int ServiceProvidedPerSaMIID)
        {
            ServicesProvidedPerSaMI objServicesProvidedPerSaMIID = new ServicesProvidedPerSaMI();
            return (ServicesProvidedPerSaMI)(new ServicesProvidedPerSaMIDAO().FillDTO(objServicesProvidedPerSaMIID, "ServiceProvidedPerSaMIID=" + ServiceProvidedPerSaMIID));
        }


        public static int InsertServiceProvidedPerSaMI(ServicesProvidedPerSaMI objServicesProvidedPerSaMI)
        {
            return new ServicesProvidedPerSaMIDAO().InsertServiceProvidedPerSaMI(objServicesProvidedPerSaMI);
        }

        public static int UpdateServiceProvidedPerSaMI(ServicesProvidedPerSaMI objServicesProvidedPerSaMI)
        {
            return new ServicesProvidedPerSaMIDAO().UpdateServiceProvidedPerSaMI(objServicesProvidedPerSaMI);
        }



    }
}
