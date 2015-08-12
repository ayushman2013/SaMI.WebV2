using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "TRNInformationSource")]
   public class TRNInformationSource
    {
        [ColumnAttribute(Name="ID", DbType="INT NOT NULL", IsPrimaryKey=true)]
        public int ID { get; set; }

        [ColumnAttribute(Name="InformationSource", DbType="VARCHAR")]
        public string InformationSource { get; set; }
    }
}
