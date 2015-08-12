using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class FeedDurationTypeBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new FeedDurationTypeDAO().SelectAll(Select);

        }
        public static FeedDurationTypes GetFeedDurationType(int? FeedDurationTypeID)
        {
            FeedDurationTypes obj = new FeedDurationTypes();
            return (FeedDurationTypes)(new FeedDurationTypeDAO().FillDTO(obj, "FeedDurationTypeID=" + FeedDurationTypeID));
        }

    }
}
