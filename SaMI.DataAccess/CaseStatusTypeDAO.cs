using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class CaseStatusTypeDAO : BaseDAO
    {
        public CaseStatusTypeDAO() : base() { }
        public CaseStatusTypeDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_case_status_types";
            KeyField = "CaseStatusTypeID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as CaseStatusTypeID, '[Select]' AS CaseStatusTypeDesc " +
                       " UNION " +
                       " SELECT CaseStatusTypeID, CaseStatusTypeDesc FROM tbl_case_status_types";
            else
                sql = "SELECT * FROM tbl_case_status_types";
            return ExecuteQuery(sql);
        }
    }
}
