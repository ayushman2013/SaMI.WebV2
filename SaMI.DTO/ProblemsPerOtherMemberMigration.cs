using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_problems_per_other_member_migration")]
    public class ProblemsPerOtherMemberMigration
    {
        [ColumnAttribute(Name = "ProblemPerOtherMemberMigrationID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int ProblemPerOtherMemberMigrationID { get; set; }
        [ColumnAttribute(Name = "OtherMemberMigrationID", DbType = "INT NOT NULL")]
        public int OtherMemberMigrationID { get; set; }
        [ColumnAttribute(Name = "ProblemTypeID", DbType = "INT NOT NULL")]
        public int ProblemTypeID { get; set; }
    }
}
