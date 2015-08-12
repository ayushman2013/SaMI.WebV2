using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_users")]
    public class Users : BaseDTO
    {

        [ColumnAttribute(Name = "UserID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int UserID { get; set; }            
        [ColumnAttribute(Name = "UserName", DbType = "VARCHAR NOT NULL")]
        public String UserName { get; set; }
        [ColumnAttribute(Name = "Password", DbType = "VARCHAR NOT NULL")]
        public String Password { get; set; }
        [ColumnAttribute(Name = "UserTypeID", DbType = "INT NOT NULL")]
        public int UserTypeID { get; set; }
        [ColumnAttribute(Name = "DistrictID", DbType = "INT NOT NULL")]
        public int DistrictID { get; set; }
        [ColumnAttribute(Name = "PartnerID", DbType = "INT NOT NULL")]
        public int PartnerID { get; set; }
        [ColumnAttribute(Name = "SaMIOrganizationID", DbType = "INT NOT NULL")]
        public int SaMIOrganizationID { get; set; }

        [ColumnAttribute(Name="FullName", DbType="VARCHAR NOT NULL")]
        public string FullName { get; set; }

        
        public String Email { get; set; }

        [ColumnAttribute(Name = "SkillPartnerID", DbType = "INT NOT NULL")]
        public int SkillPartnerID { get; set; }

    }
}
