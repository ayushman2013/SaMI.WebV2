using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class CaseRegistrarDAO : BaseDAO
    {
        public CaseRegistrarDAO() : base() { }
        public CaseRegistrarDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_case_registrars";
            KeyField = "CaseRegistrarID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as CaseRegistrarID, '[Select]' AS CaseRegistrarName " +
                       " UNION " +
                       " SELECT CaseRegistrarID, CaseRegistrarName FROM tbl_case_registrars";
            else
                sql = "SELECT * FROM tbl_case_registrars";
            return ExecuteQuery(sql);
        }
    }
}
