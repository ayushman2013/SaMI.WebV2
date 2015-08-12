using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class FeedDurationTypeDAO : BaseDAO
    {
        public FeedDurationTypeDAO() : base() { }
        public FeedDurationTypeDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_feed_duration_types";
            KeyField = "FeedDurationTypeID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '0' as FeedDurationTypeID, '[Select]' AS FeedDurationTypeDesc " +
                       " UNION " +
                       " SELECT FeedDurationTypeID, FeedDurationTypeDesc FROM tbl_feed_duration_types";
            else
                sql = "SELECT * FROM tbl_feed_duration_types";
            return ExecuteQuery(sql);
        }

    }
}
