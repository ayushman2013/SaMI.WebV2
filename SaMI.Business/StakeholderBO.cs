using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class StakeholderBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new StakeholderDAO().SelectAll(Select);

        }
        public static int InsertStakeHolders(StakeHolders objStakeHolders)
        {
            return new  StakeholderDAO().InsertStakeHolders(objStakeHolders);
        }

        public static StakeHolders GetStakeHolders(int StakeHolderID)
        {
            StakeHolders objStakeHolders = new StakeHolders();
            return (StakeHolders)(new StakeholderDAO().FillDTO(objStakeHolders, "StakeHolderID=" + StakeHolderID));
        }
        public static int UpdateStakeHolders(StakeHolders objStakeHolders)
        {
            return new StakeholderDAO().UpdateStakeHolders(objStakeHolders);
        }

        public static int Delete(int StakeHolderID)
        {
            return new StakeholderDAO().Delete("StakeHolderID=" + StakeHolderID);
        }

    }
}
