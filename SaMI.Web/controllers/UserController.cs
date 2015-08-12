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
    public class UserController : ApiController
    {
        // GET api/user
        public IEnumerable<Users> Get(int Organization)
        {
         
            List<Users> listUsers = new List<Users>();
            DataView dvUser = UserBO.GetAllUsersIDByOrganizationID(Organization);
            foreach (DataRowView drvUser in dvUser)
            {
                Users users = new Users();
                listUsers.Add(UserBO.GetUser(Convert.ToInt32(drvUser["UserID"])));
            }
            return listUsers;
        }
       
        // POST api/user
        public Users Post(Users user)
        {
            if (user.GUID > 0)
            {
                user.UserID = user.GUID;
                int rowResult = UserBO.UpdateUser(user);

                //Return Back to The Client               
                return user;
            }
            else
            {                               
                int rowResult = UserBO.InsertUser(user);

                //Return Back to The Client               
                return user;
            }
        }

       
    }
}
