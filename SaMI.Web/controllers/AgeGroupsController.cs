using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using SaMI.Business;
using SaMI.DTO;
using System.Data;
namespace Sync.Controllers
{
    public class AgeGroupsController : ApiController
    {
        // GET api/agegroups
        public IEnumerable<AgeGroups> Get()
        {
            List<AgeGroups> listAgeGroup = new List<AgeGroups>();
            DataView dvAgeGroup = AgeGroupBO.GetAgeGroupIDForSync();
            foreach (DataRowView drvAgeGroup in dvAgeGroup)
            {
                listAgeGroup.Add(AgeGroupBO.GetAgeGroups(Convert.ToInt32(drvAgeGroup["AgeGroupID"])));

            }
            return listAgeGroup;
        }

        // POST api/agegroups
        public AgeGroups Post(AgeGroups ageGroup)
        {
            if (ageGroup.GUID > 0)
            {
                ageGroup.AgeGroupID = ageGroup.GUID;
                int rowResult = AgeGroupBO.UpdateAgeGroups(ageGroup);

                //Return Back to The Client               
                return ageGroup;
            }
            else
            {
                ageGroup.GUID = ageGroup.AgeGroupID;               
                int rowResult = AgeGroupBO.InsertAgeGroup(ageGroup);

                //Return Back to The Client               
                return ageGroup;
            }
        }

    }
}
