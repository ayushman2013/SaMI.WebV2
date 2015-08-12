using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_other_member_migrations")]
    public class OtherMemberMigrations : BaseDTO
    {
        [ColumnAttribute(Name = "OtherMemberMigrationID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int OtherMemberMigrationID { get; set; }
        [ColumnAttribute(Name = "SaMIProfileID", DbType = "INT NOT NULL")]
        public int SaMIProfileID { get; set; }
        [ColumnAttribute(Name = "FamilyMemberID", DbType = "INT NOT NULL")]
        public int FamilyMemberID { get; set; }
        [ColumnAttribute(Name = "CountryID", DbType = "INT NOT NULL")]
        public int CountryID { get; set; }
        [ColumnAttribute(Name = "VisitSameCountry", DbType = "INT NOT NULL")]
        public int VisitSameCountry { get; set; }
        [ColumnAttribute(Name = "DoesSendMoney", DbType = "TINYINT NOT NULL")]
        public int DoesSendMoney { get; set; }
        [ColumnAttribute(Name = "MoneyRangeID", DbType = "INT")]
        public int? MoneyRangeID { get; set; }
        
        [ColumnAttribute(Name = "FacedProblem", DbType = "TINYINT NOT NULL")]
        public int FacedProblem { get; set; }
        [ColumnAttribute(Name = "ProblemID", DbType = "INT")]
        public int? ProblemID { get; set; }
    }
}
