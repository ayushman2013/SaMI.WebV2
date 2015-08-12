using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using SaMI.Business;
using SaMI.DTO;

namespace SaMI.Web.controllers
{
    public class DistrictsController : ApiController
    {
        // GET api/districts
        public IEnumerable<Districts> Get()
        {
            List<Districts> listDistricts = new List<Districts>();
            DataView dvDistricts = DistrictBO.GetDistrictIDForSync();
            foreach (DataRowView drvDistricts in dvDistricts)
            {
                Districts District = new Districts();
                listDistricts.Add(DistrictBO.GetDistrict(Convert.ToInt32(drvDistricts["DistrictID"])));
            }
            return listDistricts;
        }

       
        // POST api/districts
        public Districts Post(Districts Districts)
        {
            if (Districts.GUID > 0)
            {
                Districts.DistrictID = Districts.GUID;
                Districts.SyncStatus = 1;
                int rowResult = DistrictBO.UpdateDistrict(Districts);                
                //Return Back to The Client               
                return Districts;
            }
            else
            {  
                int rowResult = DistrictBO.InsertDistrict(Districts);
                //Return Back to The Client               
                return Districts;
            }

        }
       
    }
}
