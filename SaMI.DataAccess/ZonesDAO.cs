using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
   public class ZonesDAO : BaseDAO
    {
        public ZonesDAO() : base() { }
        public ZonesDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_zones";
            KeyField = "ZoneID";
        }

        public DataView SelectAll()
        {
            String sql = string.Empty;
            sql = "SELECT * FROM tbl_zones";
            return ExecuteQuery(sql);
        }
    }
}
