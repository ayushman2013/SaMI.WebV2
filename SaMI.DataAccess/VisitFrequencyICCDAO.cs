using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
   public class VisitFrequencyICCDAO : BaseDAO
    {
       public VisitFrequencyICCDAO() : base() { }
       public VisitFrequencyICCDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_visit_frequency_ICC";
            KeyField = "VisitFrequencyID";
        }

        public DataView SelectAll(String select)
        {
            String sql = "SELECT 0 AS VisitFrequencyID, '" + select + "' AS VisitFrequencyDesc UNION " +
                         "SELECT VisitFrequencyID, VisitFrequencyDesc" +
                        " FROM tbl_visit_frequency_ICC WHERE Status = 1 ";
            return ExecuteQuery(sql);
        }
    }
}
