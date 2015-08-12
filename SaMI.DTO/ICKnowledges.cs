using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;
namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_ic_knowledges")]
    public class ICKnowledges : BaseDTO
    {
        [ColumnAttribute(Name = "ICKnowledgeID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int ICKnowledgeID { get; set; }
        [ColumnAttribute(Name = "ICKnowledgeDesc", DbType = "VARCHAR NOT NULL")]
        public string ICKnowledgeDesc { get; set; } 
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
