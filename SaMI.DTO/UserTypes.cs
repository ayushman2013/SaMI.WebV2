using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_user_types")]
    public class UserTypes : BaseDTO
    {
        [ColumnAttribute(Name = "UserTypeId", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int UserTypeID { get; set; }
        [ColumnAttribute(Name = "UserTypeDesc", DbType = "VARCHAR NOT NULL")]
        public String UserTypeDesc { get; set; }
        [ColumnAttribute(Name = "UserTypeCode", DbType = "VARCHAR NOT NULL")]
        public String UserTypeCode { get; set; }
    }
}
