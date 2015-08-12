using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
   public class TRNCheckListBO:BaseDTO
    {
        public DataView GetAllCheckList(Boolean Select = false)
        {
            return new TRNCheckListDAO().SelectAllCheckList(Select);

        }

        public DataView GetCheckListByID(int CheckListID)
        {
            return new TRNCheckListDAO().SelectCheckListByID(CheckListID);

        }

        public DataView GetCheckListByTraineeID(int TraineeID)
        {
            return new TRNCheckListDAO().SelectCheckListByTraineeID(TraineeID);

        }

        public int InsertCheckList(TRNCheckList objCheckList)
        {
            objCheckList.CreatedDate = DateTime.Now;
            return new TRNCheckListDAO().InsertCheckList(objCheckList);
        }

        public int UpdateCheckList(TRNCheckList objCheckList)
        {
            objCheckList.ModifiedDate = DateTime.Now;
            return new TRNCheckListDAO().UpdateCheckList(objCheckList);
        }

        public int DeleteCheckList(TRNCheckList objCheckList)
        {
            objCheckList.ModifiedDate = DateTime.Now;
            return new TRNCheckListDAO().DeleteCheckList(objCheckList);
        }   
    }
}
