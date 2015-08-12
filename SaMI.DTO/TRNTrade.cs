using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "TRNTrade")]
    public class TRNTrade : TRNBaseDTO
    {
        [ColumnAttribute(Name = "TRNTradeID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int TradeID { get; set; }

        [ColumnAttribute(Name = "TradeName", DbType = "VARCHAR")]
        public String TradeName { get; set; }

        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }


    }
}
