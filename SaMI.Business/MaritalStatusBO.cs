using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class MaritalStatusBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new MaritalStatusDAO().SelectAll(Select);

        }

        public static MaritalStatus GetMaritalStatus(int MaritalStatusID)
        {
            MaritalStatus obj = new MaritalStatus();
            return (MaritalStatus)(new MaritalStatusDAO().FillDTO(obj, "MaritalStatusID=" + MaritalStatusID));
        }

        public static DataView GetMaritalStatusIDForSync()
        {
            return new MaritalStatusDAO().SelectMaritalStatusIDForSync();

        }
        public static int InsertmaritalStatus(MaritalStatus objStatus)
        {

            return new MaritalStatusDAO().InsertMaritalStatus(objStatus);
        }

        public static int UpdateMaritalStatus(MaritalStatus objStatus)
        {

            return new MaritalStatusDAO().UpdateMaritalStatus(objStatus);
        }

    }
}
