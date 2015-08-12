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
    public class TRNRecruitmentListController : ApiController
    {
        // GET api/trnrecruitmentlist
        public IEnumerable<TRNRecruitmentList> Get(int Organization)
        {
            List<TRNRecruitmentList> listTRNRecruitmentList = new List<TRNRecruitmentList>();
            DataView dvUsers = UserBO.GetUsersIDByOrganization(Organization);  ////PUT The Organization As Dynamic
            string TempCreatedBy = "";
            if (dvUsers.Count > 0)
            {
                foreach (DataRowView drvUsers in dvUsers)
                {
                    TempCreatedBy += "CreatedBy=" + drvUsers["UserID"] + " OR ";
                }
                string CreatedBy = TempCreatedBy.Remove(TempCreatedBy.Length - 3);
                DataView dvlistTRNRecruitmentList = TRNRecruitmentListBO.GetTRNRecruitmentListIDForSync(CreatedBy);
                foreach (DataRowView drvTRNRecruitmentList in dvlistTRNRecruitmentList)
                {
                    TRNRecruitmentList TRNRecruitmentList = new TRNRecruitmentList();
                    listTRNRecruitmentList.Add(TRNRecruitmentListBO.GetTRNRecruitmentList(Convert.ToInt32(drvTRNRecruitmentList["RecruitmentID"])));
                }
            }
            return listTRNRecruitmentList;
        }

        
        // POST api/trnrecruitmentlist
        public TRNRecruitmentList Post(TRNRecruitmentList TRNRecruitmentList)
        {

            if (TRNRecruitmentList.GUID > 0)
            {
                TRNRecruitmentList.RecruitmentID = TRNRecruitmentList.GUID;
                TRNRecruitmentList.SyncStatus = 1;
                int rowResult = TRNRecruitmentListBO.UpdateRecruitmentList(TRNRecruitmentList);

                //Return Back to The Client               
                return TRNRecruitmentList;
            }
            else
            {
                TRNRecruitmentList.SyncStatus = 1;
                int rowResult = TRNRecruitmentListBO.InsertRecruitmentList(TRNRecruitmentList);
                TRNRecruitmentList.RecruitmentID = rowResult;

                //Return Back to The Client               
                return TRNRecruitmentList;
            }
        }

    }
}
