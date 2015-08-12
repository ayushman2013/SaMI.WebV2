using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
   public class VisitReasonDAO : BaseDAO
    {
       public VisitReasonDAO() : base() { }
       public VisitReasonDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_visit_reason";
            KeyField = "VisitReasonID";
        }

        public DataView SelectAll(String select)
        {
            String sql = "SELECT 0 AS VisitReasonID, '" + select + "' AS VisitReasonDesc UNION " +
                         "SELECT VisitReasonID, VisitReasonDesc" +
                        " FROM tbl_visit_reason WHERE Status = 1 ";
            return ExecuteQuery(sql);
        }
    }
}
