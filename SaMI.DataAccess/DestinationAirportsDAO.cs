using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
   public class DestinationAirportsDAO : BaseDAO
    {
       public DestinationAirportsDAO() : base() { }
       public DestinationAirportsDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_destination_airports";
            KeyField = "DestinatinAirpotID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '' AS DestinationAirportID, '[Select]' AS DestinationAirportName " +
                      "UNION " +
                      "SELECT DestinationAirportID, DestinationAirportName FROM tbl_destination_airports ";
            else
                sql = "SELECT * FROM tbl_destination_airports";
            return ExecuteQuery(sql);
        }
    }
}
