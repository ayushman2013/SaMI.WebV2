using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.AgeGroup
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            LoadAgeGroup();

        }

        void LoadAgeGroup()
        {
            DataView dv = AgeGroupBO.GetAll();
            gvAgeGroup.DataSource = dv;
            gvAgeGroup.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AgeGroups objAgeGroups = new AgeGroups();
            objAgeGroups.AgeGroupDesc = txtAgeGroupDesc.Text;
            objAgeGroups.Status = 1;

            if (!string.IsNullOrEmpty(hfAgeGroupID.Value.ToString()))
            {
                objAgeGroups.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objAgeGroups.UpdatedDate = DateTime.Now;
                objAgeGroups.AgeGroupID = Convert.ToInt32(hfAgeGroupID.Value);
                objAgeGroups.AgeGroupDesc = txtAgeGroupDesc.Text;
                AgeGroupBO.UpdateAgeGroups(objAgeGroups);

            }
            else
            {
                objAgeGroups.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objAgeGroups.CreatedDate = DateTime.Now;
                AgeGroupBO.InsertAgeGroup(objAgeGroups);
            }


            txtAgeGroupDesc.Text = string.Empty;
            hfAgeGroupID.Value = string.Empty;
            LoadAgeGroup();
        }

        protected void gvAgeGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            AgeGroups objAgeGroups = new AgeGroups();
            hfAgeGroupID.Value = e.CommandArgument.ToString();

            if (e.CommandName.Equals("cmdEdit"))
            {
                AgeGroups objCaseType = AgeGroupBO.GetAgeGroups(Convert.ToInt32(e.CommandArgument));
                txtAgeGroupDesc.Text = objCaseType.AgeGroupDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int AgeGroupID = Convert.ToInt32(e.CommandArgument);
                objAgeGroups.AgeGroupID = AgeGroupID;
                objAgeGroups.Status = 0;
                AgeGroupBO.DeleteAgeGroups(objAgeGroups);
                LoadAgeGroup();
            }
        }

       
    }
}