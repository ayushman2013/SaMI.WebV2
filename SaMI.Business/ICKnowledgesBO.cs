using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class ICKnowledgesBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new ICKnowledgesDAO().SelectAll(Select);

        }

        public static int InsertICKnowledges(ICKnowledges objICKnowledges)
        {
            return new ICKnowledgesDAO().InsertICKnowledges(objICKnowledges);
        }
        public static ICKnowledges GetICKnowledges(int ICKnowledgeID)
        {
            ICKnowledges objICKnowledges = new ICKnowledges();
            return (ICKnowledges)(new ICKnowledgesDAO().FillDTO(objICKnowledges, "ICKnowledgeID=" + ICKnowledgeID));
        }

        public static int UpdateICKnowledges(ICKnowledges objICKnowledges)
        {
            return new ICKnowledgesDAO().UpdateICKnowledges(objICKnowledges);
        }

        public static int Delete(int ICKnowledgeID)
        {
            return new ICKnowledgesDAO().Delete("ICKnowledgeID=" + ICKnowledgeID);
        }

        public static int DeleteICKnowledges(ICKnowledges objICKnowledges)
        {
            return new ICKnowledgesDAO().DeleteICKnowledges(objICKnowledges);
        }

        public static DataView GetICKnowledgeIDForSync()
        {
            return new ICKnowledgesDAO().SelectICKnowledgeIDForSync();

        }
    }
}
