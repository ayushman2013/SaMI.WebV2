using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class FollowUpPerServicesBO
    {
        public static FollowUpPerServices GetFollowUpPerService(int ServiceProvidedPerSaMIID)
        {
            FollowUpPerServices objFollowUpPerServicesID = new FollowUpPerServices();
            return (FollowUpPerServices)(new FollowUpPerServicesDAO().FillDTO(objFollowUpPerServicesID, "ServiceProvidedPerSaMIID=" + ServiceProvidedPerSaMIID));

        }

        public static DataView GetFollowUpPerServicesIDForSync(String CreatedBy)
        {
            return new FollowUpPerServicesDAO().GetFollowUpPerServicesIDForSync(CreatedBy);
        }

        public static FollowUpPerServices GetFollowUpPerServices(int FollowUpPerServiceID)
        {
            FollowUpPerServices objFollowUpPerServicesID = new FollowUpPerServices();
            return (FollowUpPerServices)(new FollowUpPerServicesDAO().FillDTO(objFollowUpPerServicesID, "FollowUpPerServiceID=" + FollowUpPerServiceID));

        }

        public static int InsertFollowUpPerServices(FollowUpPerServices objFollowServices)
        {
            return new FollowUpPerServicesDAO().InsertFollowUpPerServices(objFollowServices);
        }

        public static int UpdateInsertFollowUpPerServices(FollowUpPerServices objFollowServices)
        {
            return new FollowUpPerServicesDAO().UpdateInsertFollowUpPerServices(objFollowServices);
        }


        public static int UpdateServiceProvidedPerSaMI(ServicesProvidedPerSaMI objServicesProvidedPerSaMI, FollowUpPerServices objFollowServices, List<AdditionalFollowUpInfoPerServices> lstAdditionalFollowUpInfoPerServices)
        {
            return new ServicesProvidedPerSaMIDAO().UpdateServiceProvided(objServicesProvidedPerSaMI, objFollowServices, lstAdditionalFollowUpInfoPerServices);
        }


    }
}
