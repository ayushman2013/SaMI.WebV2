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
    public class PassportStatusController : ApiController
    {
        // GET api/passportstatus
        public IEnumerable<PassportStatus> Get()
        {

            List<PassportStatus> listPassportStatus = new List<PassportStatus>();
            DataView dvPassportStatus = PassportStatusBO.GetPassporttatusIDForSync();
            foreach (DataRowView drvPassportStatus in dvPassportStatus)
            {
                PassportStatus status = new PassportStatus();
                listPassportStatus.Add(PassportStatusBO.GetPassportStatus(Convert.ToInt32(drvPassportStatus["PassportStatusID"])));
            }
            return listPassportStatus;
        }

        // POST api/passportstatus
        public PassportStatus Post(PassportStatus passport)
        {
            if (passport.GUID > 0)
            {
                passport.PassportStatusID = passport.GUID;
                int rowResult = PassportStatusBO.UpdatePassportStatus(passport);

                //Return Back to The Client               
                return passport;
            }
            else
            {
               
                int rowResult = PassportStatusBO.InsertPassportStatus(passport);

                //Return Back to The Client               
                return passport;
            }
        }

       
    }
}
