using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class ServicesProvidedBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new ServicesProvidedDAO().SelectAll(Select);

        }
        public static int InsertServicesProvided(ServicesProvided objServicesProvided)
        {
            return new ServicesProvidedDAO().InsertServicesProvided(objServicesProvided);
        }

        public static ServicesProvided GetServicesProvided(int ServiceProvidedID)
        {
            ServicesProvided objServicesProvided = new ServicesProvided();
            return (ServicesProvided)(new ServicesProvidedDAO().FillDTO(objServicesProvided, "ServiceProvidedID=" + ServiceProvidedID));
        }
        public static int UpdateServicesProvided(ServicesProvided objServicesProvided)
        {
            return new ServicesProvidedDAO().UpdateServicesProvided(objServicesProvided);
        }
        public static int Delete(int ServiceProvidedID)
        {
            return new ServicesProvidedDAO().Delete("ServiceProvidedID=" + ServiceProvidedID);
        }

        public static int DeleteServicesProvided(ServicesProvided objServicesProvided)
        {
            return new ServicesProvidedDAO().DeleteServicesProvided(objServicesProvided);
        }

        public static DataView GetServicesProvidedIDForSync()
        {
            return new ServicesProvidedDAO().SelectServicesProvidedIDForSync();

        }

     }
}
