using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data;
using SaMI.Business;
using SaMI.DTO;

namespace Sync.Controllers
{
    public class AdditionalFollowupInfoController : ApiController
    {
        // GET api/additionalfollowupinfo
        public IEnumerable<AdditionalFollowupInfo> Get()
        {
            List<AdditionalFollowupInfo> listAdditionalFollowupInfo = new List<AdditionalFollowupInfo>();
            DataView dvAdditionalFollowupInfo = AdditionalFollowUpInfoBO.GetAdditionalFollowupInfoIDForSync();
            foreach (DataRowView drvAdditionalFollowupInfo in dvAdditionalFollowupInfo)
            {
                AdditionalFollowupInfo AdditionalFollowupInfo = new AdditionalFollowupInfo();
                listAdditionalFollowupInfo.Add(AdditionalFollowUpInfoBO.GetAdditionalFollowupInfo(Convert.ToInt32(drvAdditionalFollowupInfo["AdditionalFollowUpInfoID"])));
            }
            return listAdditionalFollowupInfo;
        }
       
        // POST api/additionalfollowupinfo
        public AdditionalFollowupInfo Post(AdditionalFollowupInfo AdditionalFollowupInfo)
        {
            if (AdditionalFollowupInfo.GUID > 0)
            {
                AdditionalFollowupInfo.AdditionalFollowUpInfoID = AdditionalFollowupInfo.GUID;
                int rowResult = AdditionalFollowUpInfoBO.UpdateAdditionalFollowUpInfo(AdditionalFollowupInfo);
                //Return Back to The Client               
                return AdditionalFollowupInfo;
            }
            else
            {               
                AdditionalFollowupInfo.SyncStatus = 1;
                int rowResult = AdditionalFollowUpInfoBO.InsertAddtionalFollowUpInfo(AdditionalFollowupInfo);
                //Return Back to The Client               
                return AdditionalFollowupInfo;
            }
        }

    }
}
