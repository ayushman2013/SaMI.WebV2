using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using System.Data;


namespace SaMI.DataAccess
{
 public   class TRNInformationSourceDAO:BaseDAO
    {
         public TRNInformationSourceDAO() : base() { }
         public TRNInformationSourceDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNInformationSource";
            KeyField = "ID";
        }

        public DataView SelectAllInformationSource(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as ID, '[Information Source]' AS InformationSource " +
                       " UNION " +
                       " SELECT ID, InformationSource FROM TRNInformationSource";
            else
                sql = "SELECT ID, InformationSource FROM TRNInformationSource";
            return ExecuteQuery(sql);
        }
    }
}
