using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "TRNOrganization")]
    public class TRNOrganization:TRNBaseDTO
    {
        [ColumnAttribute(Name = "ID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int OrganizationID { get; set; }

        [ColumnAttribute(Name="Organization", DbType="VARCHAR")]
        public String Organization { get; set; }

        [ColumnAttribute(Name="Country",DbType="VARCHAR")]
        public String Country { get; set; }

        [ColumnAttribute(Name="Status",DbType="INT")]
        public int Status { get; set; }

    }
}