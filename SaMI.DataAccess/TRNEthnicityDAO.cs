using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
   public class TRNEthnicityDAO:BaseDAO
    {
       public TRNEthnicityDAO() : base() { }
       public TRNEthnicityDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_ethnicity";
            KeyField = "EthnicityID";
        }

        public DataView SelectAllEthnicity(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as EthnicityID, '[Ethnicity]' AS EthnicityName " +
                       " UNION " +
                       " SELECT EthnicityID, EthnicityName FROM tbl_ethnicity";
            else
                sql = "SELECT EthnicityID, EthnicityName FROM tbl_ethnicity";
            return ExecuteQuery(sql);
        }
    }
}
