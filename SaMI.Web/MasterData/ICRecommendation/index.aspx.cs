using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.ICRecommendation
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                loadICRecommendation();
        }

        void loadICRecommendation()
        {
            DataView dv = ICRecommendationsBO.GetAll();
            gvICRecommendationDesc.DataSource = dv;
            gvICRecommendationDesc.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ICRecommendations objICRecommendations = new ICRecommendations();
            objICRecommendations.ICRecommendationDesc = txtICRecommendationDesc.Text;
            objICRecommendations.Status = 1;

            if (!string.IsNullOrEmpty(hfICRecommendationID.Value.ToString()))
            {
                objICRecommendations.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objICRecommendations.UpdatedDate = DateTime.Now;
                objICRecommendations.ICRecommendationID = Convert.ToInt32(hfICRecommendationID.Value);
                objICRecommendations.ICRecommendationDesc = txtICRecommendationDesc.Text;
                ICRecommendationsBO.UpdateICRecommendations(objICRecommendations);

            }
            else
            {
                objICRecommendations.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objICRecommendations.CreatedDate = DateTime.Now;
                ICRecommendationsBO.InsertICRecommendations(objICRecommendations);
            }

            txtICRecommendationDesc.Text = string.Empty;
            hfICRecommendationID.Value = string.Empty;
            loadICRecommendation();

        }

        protected void gvICRecommendationDesc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfICRecommendationID.Value = e.CommandArgument.ToString();
            ICRecommendations objICRecommendations = new ICRecommendations();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objICRecommendations = ICRecommendationsBO.GetICRecommendations(Convert.ToInt32(e.CommandArgument));
                txtICRecommendationDesc.Text = objICRecommendations.ICRecommendationDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int ICRecommendationID = Convert.ToInt32(e.CommandArgument);
                objICRecommendations.ICRecommendationID = ICRecommendationID;
                objICRecommendations.Status = 0;
                ICRecommendationsBO.DeleteICRecommendations(objICRecommendations);
                loadICRecommendation();
            }
        }
    }
}