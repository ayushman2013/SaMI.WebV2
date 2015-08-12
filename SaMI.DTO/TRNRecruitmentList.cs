using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "TRNRecruitmentList")]
    public class TRNRecruitmentList:BaseDTO
    {
        [ColumnAttribute(Name = "RecruitmentID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int RecruitmentID { get; set; }
        [ColumnAttribute(Name = "OrganizationID", DbType = "INT NOT NULL")]
        public int OrganizationID { get; set; }
        [ColumnAttribute(Name = "SaMIProfileID", DbType = "INT NOT NULL")]
        public int SaMIProfileID { get; set; }
        [ColumnAttribute(Name = "ReferStatus", DbType = "TINYINT NOT NULL")]
        public int ReferStatus { get; set; }
    }
}
