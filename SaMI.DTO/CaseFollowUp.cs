using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_case_follow_up")]
    public class CaseFollowUp : BaseDTO
    {
        [ColumnAttribute(Name = "CaseFollowUpID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int CaseFollowUpID { get; set; }
        [ColumnAttribute(Name = "SaMIProfileID", DbType = "INT NOT NULL")]
        public int SaMIProfileID { get; set; }
        [ColumnAttribute(Name = "CaseID", DbType = "INT NOT NULL")]
        public int CaseID { get; set; }
        [ColumnAttribute(Name = "Description", DbType = "TEXT")]
        public String Description { get; set; }
        [ColumnAttribute(Name = "FollowUpDate", DbType = "DATETIME NOT NULL")]
        public DateTime FollowUpDate { get; set; }

    }
}
