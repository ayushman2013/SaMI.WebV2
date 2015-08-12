using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    public class BaseDTO
    {
        [ColumnAttribute(Name = "CreatedBy", DbType = "INT NOT NULL")]
        public int CreatedBy { get; set; }
        [ColumnAttribute(Name = "CreatedDate", DbType = "DATE NOT NULL")]
        public DateTime CreatedDate { get; set; }

        [ColumnAttribute(Name = "UpdatedBy", DbType = "INT")]
        public int? UpdatedBy { get; set; }
        [ColumnAttribute(Name = "UpdatedDate", DbType = "DATE")]
        public DateTime? UpdatedDate { get; set; }


        [ColumnAttribute(Name = "GUID", DbType = "INT")]
        public int GUID { get; set; }
        [ColumnAttribute(Name = "SyncStatus", DbType = "INT")]
        public int SyncStatus { get; set; }
        
    }
}
