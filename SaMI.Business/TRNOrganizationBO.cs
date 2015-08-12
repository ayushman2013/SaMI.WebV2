using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
   public class TRNOrganizationBO
    {
        public  DataView GetAllOrganization(Boolean Select = false)
        {
            return new TRNOrganizationDAO().SelectAllOrganization(Select);
        }

        public DataView GetOrganizationByID(int OrganizationID)
        {
            return new TRNOrganizationDAO().SelectOrganizationByID(OrganizationID);

        }

        public int InsertOrganization(TRNOrganization objOrganization)
        {
            objOrganization.CreatedDate = DateTime.Now;
            return new TRNOrganizationDAO().InsertOrganization(objOrganization);
        }

        public int UpdateOrganization(TRNOrganization objOrganization)
        {
            objOrganization.ModifiedDate = DateTime.Now;
            return new TRNOrganizationDAO().UpdateOrganization(objOrganization);
        }

        public int DeleteOrganization(TRNOrganization objOrganization)
        {
            objOrganization.ModifiedDate = DateTime.Now;
            return new TRNOrganizationDAO().DeleteOrganization(objOrganization);
        }   
    }
}
