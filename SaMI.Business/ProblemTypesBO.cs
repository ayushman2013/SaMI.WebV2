using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class ProblemTypesBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new ProblemTypesDAO().SelectAll(Select);

        }
        public static int InsertProblemTypes(ProblemsTypes objProblemTypes)
        {
            return new ProblemTypesDAO().InsertProblemTypes(objProblemTypes);
        }
        public static ProblemsTypes GetProblemsTypes(int ProblemTypeID)
        {
            ProblemsTypes objProblemsTypes = new ProblemsTypes();
            return (ProblemsTypes)(new ProblemTypesDAO().FillDTO(objProblemsTypes, "ProblemTypeID=" + ProblemTypeID));
        }
        public static int UpdateProblemsTypes(ProblemsTypes objProblemsTypes)
        {
            return new ProblemTypesDAO().UpdateProblemsTypes(objProblemsTypes);
        }

        public static int Delete(int ProblemTypeID)
        {
            DataView dv = new ProblemTypesDAO().Select("ProblemID", "tbl_other_member_migrations", "ProblemID=" + ProblemTypeID);

            if(dv.Count ==0 )
                return new ProblemTypesDAO().Delete("ProblemTypeID=" + ProblemTypeID);

            return -1;
        }

        public static int DeleteProblemsTypes(ProblemsTypes objProblemsTypes)
        {
            return new ProblemTypesDAO().DeleteProblemsTypes(objProblemsTypes);
        }
    }
}
