using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "TRNDepartureChecklist")]
    public class TRNDepartureCheckList
    {
        [ColumnAttribute(Name = "ID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int DepartureChecklistID { get; set; }

        [ColumnAttribute(Name = "EmploymentID", DbType = "INT")]
        public int EmploymentID { get; set; }

        [ColumnAttribute(Name = "ChecklistID", DbType = "INT")]
        public int CheckListID { get; set; }

        [ColumnAttribute(Name = "Avaliability", DbType = "INT")]
        public int Availability { get; set; }
    }
}
