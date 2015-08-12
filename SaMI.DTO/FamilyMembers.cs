using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_family_members")]
    public class FamilyMembers : BaseDTO
    {
        [ColumnAttribute(Name = "FamilyMemberID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int FamilyMemberID { get; set; }
        [ColumnAttribute(Name = "FamilyMemberName", DbType = "VARCHAR NOT NULL")]
        public string FamilyMemberName { get; set; }
    }
}
