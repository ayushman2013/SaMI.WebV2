using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using SaMI.DTO;
using SaMI.Business;

namespace SaMI.Web.controllers
{
    public class UpdateSyncStatusController : ApiController
    {
        // GET api/updatesyncstatus
        public String Get()
        {
          return "OK";
        }

        // POST api/updatesyncstatus
        public UpdateQuery Post(UpdateQuery query)
        {
            int result=SaMIProfileBO.UpdateQuery(query.Sql);
            query.Sql = result.ToString();
            return query;
        }
               
    }
}
