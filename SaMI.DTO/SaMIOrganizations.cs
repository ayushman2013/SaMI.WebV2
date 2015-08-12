using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_SaMI_organizations")]
    public class SaMIOrganizations : BaseDTO
    {
        [ColumnAttribute(Name = "SaMIOrganizationID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int SaMIOrganizationID { get; set; }
        [ColumnAttribute(Name = "DistrictID", DbType = "INT")]
        public int DistrictID { get; set; }
        [ColumnAttribute(Name = "SaMIOrganizationName", DbType = "VARCHAR NOT NULL")]
        public String SaMIOrganizationName { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int? Status { get; set; }
    }
}
