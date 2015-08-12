using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_case_profiles")]
    public class CaseProfiles : BaseDTO
    {
        [ColumnAttribute(Name = "CaseProfileID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int CaseProfileID { get; set; }
        [ColumnAttribute(Name = "DistrictID", DbType = "INT NOT NULL")]
        public int DistrictID { get; set; }
        [ColumnAttribute(Name = "VDCID", DbType = "INT NOT NULL")]
        public int VDCID { get; set; }
        [ColumnAttribute(Name = "FirstName", DbType = "VARCHAR NOT NULL")]
        public String FirstName { get; set; }
        [ColumnAttribute(Name = "MiddleName", DbType = "VARCHAR NOT NULL")]
        public String MiddleName { get; set; }
        [ColumnAttribute(Name = "LastName", DbType = "VARCHAR NOT NULL")]
        public String LastName { get; set; }
        [ColumnAttribute(Name = "CaseProfileNumber", DbType = "VARCHAR NOT NULL")]
        public String CaseProfileNumber { get; set; }

    }
}
