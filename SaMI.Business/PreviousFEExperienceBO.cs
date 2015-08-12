using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class PreviousFEExperienceBO
    {
        public static DataView GetAll(int SaMIProfileID)
        {
            return new PreviousFEExperienceDAO().SelectAll(SaMIProfileID);
        }

        public static DataView GetCustom(int SaMIProfileID)
        {
            return new PreviousFEExperienceDAO().SelectCustom(SaMIProfileID);
        }

        public static int InsertFEExperience(PreviousFEExperiences objPreviousFEExperiences)
        {
            objPreviousFEExperiences.CreatedDate = DateTime.Now;
            return new PreviousFEExperienceDAO().InsertFEExperience(objPreviousFEExperiences);
        }

        public static int UpdateFEExperience(PreviousFEExperiences objPreviousFEExperiences)
        {
            objPreviousFEExperiences.UpdatedDate = DateTime.Now;
            return new PreviousFEExperienceDAO().UpdateFEExperience(objPreviousFEExperiences);
        }

        public static int DeletePreviousFEExperience(PreviousFEExperiences objPreviousFEExperience)
        {
            return new PreviousFEExperienceDAO().DeletePreviousFEExperience(objPreviousFEExperience);
        }

        public static PreviousFEExperiences GetFEExperience(int ForeignEmploymentExperienceID)
        {
            PreviousFEExperiences objPreviousFEExperiences = new PreviousFEExperiences();
            return (PreviousFEExperiences)(new PreviousFEExperienceDAO().FillDTO(objPreviousFEExperiences, "ForeignEmploymentExperienceID=" + ForeignEmploymentExperienceID));

        }

        public static int Delete(int SaMIProfileID)
        {
            return new PreviousFEExperienceDAO().Delete("SaMIProfileID=" + SaMIProfileID);
        }

        public static PreviousFEExperiences GetPreviousFEExperiences(int SaMIProfileID)
        {
            PreviousFEExperiences objPreviousFEExperiences = new PreviousFEExperiences();
            return (PreviousFEExperiences)(new PreviousFEExperienceDAO().FillDTO(objPreviousFEExperiences, "SaMIProfileID=" + SaMIProfileID));

        }

        public static DataView SelectAllBySaMIProfileID(int SaMIProfileID)
        {
            return new PreviousFEExperienceDAO().SelectAllBySaMIProfileID(SaMIProfileID);
        }

        public static PreviousFEExperiences GetByID(int PreviousFEID)
        {
            PreviousFEExperiences objPreviousFEExperiences = new PreviousFEExperiences();
            return (PreviousFEExperiences)(new PreviousFEExperienceDAO().FillDTO(objPreviousFEExperiences, "ForeignEmploymentExperienceID=" + PreviousFEID));
        }

        public static DataView GetPreviousFEExperienceIDForSync(String CreatedBy)
        {
            return new PreviousFEExperienceDAO().SelectPreviousFEExperienceIDForSync(CreatedBy);
        }
        
    }
}
