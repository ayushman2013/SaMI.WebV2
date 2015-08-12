using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "TRNRecruitmentAgency")]
    public class TRNRecruitmentAgency : TRNBaseDTO
    {
        [ColumnAttribute(Name = "ID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int RecAgencyID { get; set; }

        [ColumnAttribute(Name = "RecruitmentAgency", DbType = "VARCHAR")]
        public String RecruitmentAgency { get; set; }

        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }

    }
}
