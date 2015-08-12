using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class DistrictBO
    {
        
            public static DataView GetAll(Boolean Select = false)
            {
                return new DistrictsDAO().SelectAll(Select);

            }
            public static DataView GetDistrictIDForSync()
            {
                return new DistrictsDAO().GetDistrictIDForSync();

            }
        
            public static Districts GetDistrict(int DistrictID)
            {
                Districts objDistricts = new Districts();
                return (Districts)(new DistrictsDAO().FillDTO(objDistricts, "DistrictID=" + DistrictID));
            }

            public static int InsertDistrict(Districts Districts)
            {
                return new DistrictsDAO().InsertDistrict(Districts);
            }
            public static int UpdateDistrict(Districts Districts)
            {
                return new DistrictsDAO().UpdateDistrict(Districts);
            }

            public static int Delete(int DistrictID)
            {
                return new DistrictsDAO().Delete("DistrictID=" + DistrictID);
            }
        
    }
}
