using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_document_types")]
    public class DocumentTypes : BaseDTO
    {
        [ColumnAttribute(Name = "DocumentTypeID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int DocumentTypeID { get; set; }
        [ColumnAttribute(Name = "DocumentTypeDesc", DbType = "VARCHAR NOT NULL")]
        public string DocumentTypeDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
