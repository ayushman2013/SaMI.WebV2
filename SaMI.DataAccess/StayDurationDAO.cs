using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
   public class StayDurationDAO : BaseDAO
    {
       public StayDurationDAO() : base() { }
       public StayDurationDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_stay_duration";
            KeyField = "StayDurationID";
        }

        public DataView SelectAll(String select)
        {
            String sql = "SELECT 0 AS StayDurationID, '" + select + "' AS StayDurationDesc UNION " +
                         "SELECT StayDurationID, StayDurationDesc" +
                        " FROM tbl_stay_duration WHERE Status = 1 ";
            return ExecuteQuery(sql);
        }
    }
}
