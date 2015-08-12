using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_phonefollowup_info")]
    public class PhoneFollowUpInfo : BaseDTO
    {
        [ColumnAttribute(Name = "PhoneFollowUpInfoID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int PhoneFollowUpInfoID { get; set; }
        [ColumnAttribute(Name = "SaMIProfileID", DbType = "INT NOT NULL")]
        public int SaMIProfileID { get; set; }
        [ColumnAttribute(Name = "InformantsName", DbType = "VARCHAR")]
        public String InformantsName { get; set; }
        [ColumnAttribute(Name = "MigrantRelation", DbType = "VARCHAR")]
        public string MigrantRelation { get; set; }
        [ColumnAttribute(Name = "FollowUpDate", DbType = "VARCHAR")]
        public string FollowUpDate { get; set; }
        [ColumnAttribute(Name = "Remarks", DbType = "VARCHAR")]
        public string Remarks { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT NOT NULL")]
        public int Status { get; set; }
    }
}
