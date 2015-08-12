using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.CounselorDifficulty
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadCounselorDifficulties();
            }
        }

        void loadCounselorDifficulties()
        {
            DataView dv = CounselorDifficultiesBO.GetAll();
            gvCounselorDifficulty.DataSource = dv;
            gvCounselorDifficulty.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CounselorDifficulties objCounselorDifficulties = new CounselorDifficulties();
            objCounselorDifficulties.CounselorDifficultyDesc = txtCounselorDifficultyDesc.Text;
            objCounselorDifficulties.Status = 1;

            if (!string.IsNullOrEmpty(hfCounselorDifficultyID.Value.ToString()))
            {
                objCounselorDifficulties.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objCounselorDifficulties.UpdatedDate = DateTime.Now;
                objCounselorDifficulties.CounselorDifficultyID = Convert.ToInt32(hfCounselorDifficultyID.Value);
                objCounselorDifficulties.CounselorDifficultyDesc = txtCounselorDifficultyDesc.Text;
                CounselorDifficultiesBO.UpdateCounselorDifficulties(objCounselorDifficulties);
            }
            else
            {
                objCounselorDifficulties.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objCounselorDifficulties.CreatedDate = DateTime.Now;
                CounselorDifficultiesBO.InsertCounselorDifficulty(objCounselorDifficulties);
            }

            txtCounselorDifficultyDesc.Text = string.Empty;
            hfCounselorDifficultyID.Value = string.Empty;
            loadCounselorDifficulties();
        }

        protected void gvCounselorDifficulty_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfCounselorDifficultyID.Value = e.CommandArgument.ToString();
            CounselorDifficulties objCounselorDifficulties = new CounselorDifficulties();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objCounselorDifficulties = CounselorDifficultiesBO.GetCounselorDifficulties(Convert.ToInt32(e.CommandArgument));
                txtCounselorDifficultyDesc.Text = objCounselorDifficulties.CounselorDifficultyDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int CounselorDifficultyID = Convert.ToInt32(e.CommandArgument);
                objCounselorDifficulties.CounselorDifficultyID = CounselorDifficultyID;
                objCounselorDifficulties.Status = 0;
                CounselorDifficultiesBO.DeleteCounselorDifficulties(objCounselorDifficulties);
                loadCounselorDifficulties();
            }
        }
    }
}