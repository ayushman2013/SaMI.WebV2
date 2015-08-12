using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class UserTypeBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new UserTypeDAO().SelectAll(Select);

        }
        public static int InsertUserTypes(UserTypes objUserTypes)
        {
            return new UserTypeDAO().InsertUserTypes(objUserTypes);
        }

        public static UserTypes GetUserTypes(int UserTypeID)
        {
            UserTypes objUserTypes = new UserTypes();
            return (UserTypes)(new UserTypeDAO().FillDTO(objUserTypes, "UserTypeID=" + UserTypeID));
        }

        public static int UpdateUserTypes(UserTypes objUserTypes)
        {
            return new UserTypeDAO().UpdateUserTypes(objUserTypes);
        }

        public static int Delete(int UserTypeID)
        {
            return new UserTypeDAO().Delete("UserTypeID=" + UserTypeID);
        }

        public static DataView GetAllForSync()
        {
            return new UserTypeDAO().GetAllForSync();

        }
      
    }
}
