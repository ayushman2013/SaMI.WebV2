using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
   public class FamilyMembersBO
    {
       public static DataView GetAll(Boolean Select = false)
       {
           return new FamilyMembersDAO().SelectAll(Select);

       }

       public static int InsertFamilyMembers(FamilyMembers objFamilyMembers)
       {
           return new FamilyMembersDAO().InsertFamilyMembers(objFamilyMembers);
       }

       public static FamilyMembers GetFamilyMembers(int FamilyMemberID)
       {
           FamilyMembers objFamilyMembers = new FamilyMembers();
           return (FamilyMembers)(new FamilyMembersDAO().FillDTO(objFamilyMembers, "FamilyMemberID=" + FamilyMemberID));
       }
       public static int UpdateFamilyMembers(FamilyMembers objFamilyMembers)
       {
           return new FamilyMembersDAO().UpdateFamilyMembers(objFamilyMembers);
       }

    }
}
