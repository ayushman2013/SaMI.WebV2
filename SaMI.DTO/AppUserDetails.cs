using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaMI.DTO
{
    public class AppUserDetails
    {
        public String FullName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String UserType { get; set; }
        public int UserID { get; set; }
        public int UserTypeID { get; set; }
        public int DistrictID { get; set; }
        public int PartnerID { get; set; }
        public String DistrictName { get; set; }
        public int SaMIOrganizationID { get; set; }

        public void Reset()
        {
            FullName = null;
            UserName = null;
            Password = null;
            UserType = null;
            UserID = -1;
            UserTypeID = -1;
            DistrictID = -1;
            PartnerID = -1;
            DistrictName = null;
            SaMIOrganizationID = -1;
        }
    }
}
