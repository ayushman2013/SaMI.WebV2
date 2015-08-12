using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "TRNChecklist")]
    public class TRNCheckList:TRNBaseDTO
    {
        [ColumnAttribute(Name = "ID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int ChkListID { get; set; }

        [ColumnAttribute(Name = "Checklist", DbType = "VARCHAR")]
        public String CheckList { get; set; }

        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }

    }
}
