using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_case_registrars")]
    public class CaseRegistrars : BaseDTO
    {
        [ColumnAttribute(Name = "CaseRegistrarID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int CaseRegistrarID { get; set; }
        [ColumnAttribute(Name = "CaseRegistrarName", DbType = "VARCHAR NOT NULL")]
        public string CaseRegistrarName { get; set; }
    }
}
