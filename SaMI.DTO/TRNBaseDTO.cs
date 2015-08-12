using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
  public  class TRNBaseDTO
    {
        [ColumnAttribute(Name = "CreatedBy", DbType = "INT")]
        public int CreatedBy { get; set; }

        [ColumnAttribute(Name = "CreatedDate", DbType = "DATE")]
        public DateTime CreatedDate { get; set; }

        [ColumnAttribute(Name = "ModifiedBy", DbType = "INT")]
        public int? ModifiedBy { get; set; }

        [ColumnAttribute(Name = "ModifiedDate", DbType = "DATE")]
        public DateTime? ModifiedDate { get; set; }
    }
}
