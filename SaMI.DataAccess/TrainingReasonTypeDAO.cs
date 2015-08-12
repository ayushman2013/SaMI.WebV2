using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class TrainingReasonTypeDAO : BaseDAO
    {
        public TrainingReasonTypeDAO() : base() { }
        public TrainingReasonTypeDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_training_reason_types";
            KeyField = "TrainingReasonTypeID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as TrainingReasonTypeID, '[Select]' AS TrainingReasonTypeDesc " +
                       " UNION " +
                       " SELECT TrainingReasonTypeID, TrainingReasonTypeDesc FROM tbl_training_reason_types";
            else
                sql = "SELECT * FROM tbl_training_reason_types";
            return ExecuteQuery(sql);
        }
    }
}
