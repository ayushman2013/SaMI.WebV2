using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class KnowAboutTrainingDAO : BaseDAO
    {
        public KnowAboutTrainingDAO() : base() { }
        public KnowAboutTrainingDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_know_about_trainings";
            KeyField = "KnowAboutTrainingID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as KnowAboutTrainingID, '[Select]' AS KnowAboutTrainingDesc " +
                       " UNION " +
                       " SELECT KnowAboutTrainingID, KnowAboutTrainingDesc FROM tbl_know_about_trainings";
            else
                sql = "SELECT * FROM tbl_know_about_trainings";
            return ExecuteQuery(sql);
        }
    }
}
