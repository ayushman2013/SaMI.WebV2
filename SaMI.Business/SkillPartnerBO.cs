using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class SkillPartnerBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            String sql = "SELECT 0 AS SkillPartnerID, '[Skill Partner]' AS SkillPartnerName UNION SELECT SkillPartnerID, SkillPartnerName FROM tbl_skill_partners";
            return new BaseDAO().ExecuteQuery(sql);
        }
    }
}
