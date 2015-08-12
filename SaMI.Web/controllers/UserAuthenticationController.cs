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
    public class UserAuthenticationController : ApiController
    {
        // GET api/userauthentication
        public IEnumerable<string> Get()
        {
            if (controllers.UserValid.ValidUser)
            return new string[] { "value1", "value2" };
            else
                return new string[] { "Invalid UserrInformation", "Passwd" };

        }

       
        // POST api/userauthentication
        public Boolean Post(Users user)
        {
            
            controllers.UserValid.ValidUser= UserBO.CheckUserAuthentication(user.UserName, user.Password);

            if (controllers.UserValid.ValidUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
    }
}
