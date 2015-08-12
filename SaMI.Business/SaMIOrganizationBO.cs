using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;


namespace SaMI.Business
{
    public class SaMIOrganizationBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new SaMIOrganizationDAO().SelectAll(Select);
        }

        public static int InsertSaMIOrganization(SaMIOrganizations objSaMIOrganizations)
        {
            return new SaMIOrganizationDAO().InsertSaMIOrganization(objSaMIOrganizations);
        }

        public static SaMIOrganizations GetSaMIOrganization(int caseTypeID)
        {
            SaMIOrganizations objSaMIOrganizations = new SaMIOrganizations();
            return (SaMIOrganizations)(new SaMIOrganizationDAO().FillDTO(objSaMIOrganizations, "SaMIOrganizationID=" + caseTypeID));
        }

        public static int UpdateSaMIOrganization(SaMIOrganizations objSaMIOrganizations)
        {
            return new SaMIOrganizationDAO().UpdateSaMIOrganization(objSaMIOrganizations);
        }

        public static int Delete(int SaMIOrganizationID)
        {
            return new SaMIOrganizationDAO().Delete("SaMIOrganizationID=" + SaMIOrganizationID);
        }

        public static int DeleteSaMIOrganization(SaMIOrganizations objSaMIOrganizations)
        {
            return new SaMIOrganizationDAO().DeleteSaMIOrganization(objSaMIOrganizations);
        }


        public static DataView GetByDistrictID(int DistrictID)
        {
            return new SaMIOrganizationDAO().SelectByDistrictID(DistrictID);
        }


        public static DataView GetOrganizationByDistrictID(int districtId, String select)
        {
            return new SaMIOrganizationDAO().SelectOrganizationByDistrictID(districtId, select);
        }

        public static DataView GetSaMIOrganizationID()
        {
            return new SaMIOrganizationDAO().SelectSaMIOrganizationID();
        }

        public static object GetByUserID(int userID)
        {
            return new SaMIOrganizationDAO().SelectByUserID(userID);
        }
    }
}
