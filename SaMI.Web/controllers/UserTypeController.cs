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
    public class UserTypeController : ApiController
    {
        // GET api/usertype
        public List<UserTypes> Get()
        {
            List<UserTypes> listUserTypes = new List<UserTypes>();
            DataView dvUserType = UserTypeBO.GetAllForSync();
            foreach (DataRowView drvUserType in dvUserType)
            {
                UserTypes userType = new UserTypes();
                listUserTypes.Add(UserTypeBO.GetUserTypes(Convert.ToInt32(drvUserType["UserTypeID"])));
            }
            return listUserTypes;
        }

       
        // POST api/usertype
        public UserTypes Post(UserTypes userType)
        {
            if (userType.GUID > 0)
            {
                userType.UserTypeID = userType.GUID;
                int rowResult = UserTypeBO.UpdateUserTypes(userType);

                //Return Back to The Client               
                return userType;               
            }
            else
            {                               
                int rowResult = UserTypeBO.InsertUserTypes(userType);

                //Return Back to The Client               
                return userType;
            }
        }

       
    }
}
