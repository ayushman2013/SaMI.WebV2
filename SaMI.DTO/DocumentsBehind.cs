using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_documents_behind")]
    public class DocumentsBehind : BaseDTO
    {
        [ColumnAttribute(Name = "DocumentBehindID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int DocumentBehindID { get; set; }
        [ColumnAttribute(Name = "DocumentBehindDesc", DbType = "VARCHAR NOT NULL")]
        public string DocumentBehindDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
