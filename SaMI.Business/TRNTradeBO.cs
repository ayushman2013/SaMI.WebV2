using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
   public class TRNTradeBO
    {
       public DataView SelectAllTradeName(Boolean Select = false)
       {
           return new TRNTradeDAO().GetAllTradeName(Select);
       }

       public DataView SelectTradeNameByID(int TradeID)
       {
           return new TRNTradeDAO().GetTradeNameByID(TradeID);
       }

       public int InsertTradeName(TRNTrade objTrade)
       {
           objTrade.CreatedDate = DateTime.Now;
           return new TRNTradeDAO().InsertTradeName(objTrade);
       }

       public int UpdateTradeName(TRNTrade objTrade)
       {
           objTrade.ModifiedDate = DateTime.Now;
           return new TRNTradeDAO().UpdateTradeName(objTrade);
       }

       public int DeleteTradeName(TRNTrade objTrade)
       {
           objTrade.ModifiedDate = DateTime.Now;
           return new TRNTradeDAO().DeleteTradeName(objTrade);
       }

       public static object GetAllTrade(Boolean select = false)
       {
           return new TRNTradeDAO().SelectAllTrade(select);
       }

       
       
    }
}
