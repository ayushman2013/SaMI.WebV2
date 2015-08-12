using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_documents_per_other_member_migration")]
    public class DocumentsPerOtherMemberMigration
    {
        [ColumnAttribute(Name = "DocumentsPerOtherMemberMigrationID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int DocumentsPerOtherMemberMigrationID { get; set; }
        [ColumnAttribute(Name = "OtherMemberMigrationID", DbType = "INT NOT NULL")]
        public int OtherMemberMigrationID { get; set; }
        [ColumnAttribute(Name = "DocumentBehindID", DbType = "INT NOT NULL")]
        public int DocumentBehindID { get; set; }
    }
}
