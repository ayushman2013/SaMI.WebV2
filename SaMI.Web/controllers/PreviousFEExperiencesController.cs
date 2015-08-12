using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using SaMI.DTO;
using SaMI.Business;

namespace Sync.Controllers
{
    public class PreviousFEExperiencesController : ApiController
    {

        // GET api/previousfeexperiences
        public IEnumerable<PreviousFEExperiences> Get(int Organization)
        {
            List<PreviousFEExperiences> listPreviousFEExperiences = new List<PreviousFEExperiences>();
            DataView dvUsers = UserBO.GetUsersIDByOrganization(Organization);//PUT The Organization As Dynamic
            string TempCreatedBy = "";
            if (dvUsers.Count > 0)
            {
                foreach (DataRowView drvUsers in dvUsers)
                {
                    TempCreatedBy += "CreatedBy=" + drvUsers["UserID"] + " OR ";
                }
                string CreatedBy = TempCreatedBy.Remove(TempCreatedBy.Length - 3);


                DataView dvlistPreviousFEExperiences = PreviousFEExperienceBO.GetPreviousFEExperienceIDForSync(CreatedBy);
                foreach (DataRowView drvPreviousFEExperiences in dvlistPreviousFEExperiences)
                {
                    PreviousFEExperiences PreviousFEExperiences = new PreviousFEExperiences();
                    listPreviousFEExperiences.Add(PreviousFEExperienceBO.GetFEExperience(Convert.ToInt32(drvPreviousFEExperiences["ForeignEmploymentExperienceID"])));
                }
            }
            return listPreviousFEExperiences;
        }

        // POST api/previousfeexperiences
        public PreviousFEExperiences Post(PreviousFEExperiences PreviousFEExperiences)
        {
            if (PreviousFEExperiences.GUID > 0)
            {
                PreviousFEExperiences.SyncStatus = 1;
                PreviousFEExperiences.ForeignEmploymentExperienceID = PreviousFEExperiences.GUID;
                int rowResult = PreviousFEExperienceBO.UpdateFEExperience(PreviousFEExperiences);

                //Return Back to The Client               
                return PreviousFEExperiences;
            }
            else
            {
                PreviousFEExperiences.SyncStatus = 1;
                int rowResult = PreviousFEExperienceBO.InsertFEExperience(PreviousFEExperiences);
                PreviousFEExperiences.ForeignEmploymentExperienceID = rowResult;

                //Return Back to The Client               
                return PreviousFEExperiences;
            }

        }

    }
}
