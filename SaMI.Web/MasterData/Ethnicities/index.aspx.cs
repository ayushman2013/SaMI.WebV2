using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.Ethnicities
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadEthinicity();
                LoadGeoBasedEthnicity();
            }
        }

        private void Reset()
        {
            chkValidRegions.Items[0].Selected = false;
            chkValidRegions.Items[1].Selected = false;
            chkValidRegions.Items[2].Selected = false;
            chkValidRegions.Items[3].Selected = false;
            chkValidRegions.Items[4].Selected = false;
        }

        void loadEthinicity()
        {
            DataView dv = EthnicityBO.GetAll();
            gvEthnicity.DataSource = dv;
            gvEthnicity.DataBind();
        }

        void LoadGeoBasedEthnicity(){
            chkValidRegions.DataSource = EthnicityBO.SelectGeoBasedEthnicity();
            chkValidRegions.DataValueField = "GeoBasedEthnicityID";
            chkValidRegions.DataTextField = "GeoBasedEthnicityDesc";
            chkValidRegions.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Ethnicity objEthnicity = new Ethnicity();
            objEthnicity.EthnicityName = txtEthnicityName.Text;
            objEthnicity.Category = txtCategory.Text;
            objEthnicity.Status = 1;

            string ValidRegions = string.Empty;

            for (int j = 0; j < chkValidRegions.Items.Count; j++)
            {
                if (chkValidRegions.Items[j].Selected == true)
                {
                    if (j == 0)
                        ValidRegions = chkValidRegions.Items[j].Value;
                    else
                        ValidRegions = ValidRegions + "," + chkValidRegions.Items[j].Value;
                }
            }
            objEthnicity.ValidRegions = ValidRegions;
            if (!string.IsNullOrEmpty(hfEthnicityID.Value.ToString()))
            {
                objEthnicity.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objEthnicity.UpdatedDate = DateTime.Now;
                objEthnicity.EthnicityID = Convert.ToInt32(hfEthnicityID.Value);
                //objEthnicity.EthnicityName = txtEthnicityName.Text;
                //objEthnicity.Category = txtCategory.Text;
                
                EthnicityBO.UpdateEthnicity(objEthnicity);

            }
            else
            {
                objEthnicity.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objEthnicity.CreatedDate = DateTime.Now;
                EthnicityBO.InsertEthnicity(objEthnicity);
            }

            txtEthnicityName.Text = string.Empty;
            txtCategory.Text = string.Empty;
            hfEthnicityID.Value = string.Empty;
            loadEthinicity();
            LoadGeoBasedEthnicity();

        }

        protected void gvEthnicity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfEthnicityID.Value = e.CommandArgument.ToString();
            Ethnicity objEthnicity = new Ethnicity();

            if (e.CommandName.Equals("cmdEdit"))
            {
                Reset();
                objEthnicity = EthnicityBO.GetEthnicity(Convert.ToInt32(e.CommandArgument));
                txtEthnicityName.Text = objEthnicity.EthnicityName;
                txtCategory.Text = objEthnicity.Category;

                List<int> lstValidRegions = EthnicityBO.SelectValidRegionForEthnicity(Convert.ToInt32(e.CommandArgument));


                if (lstValidRegions.Count > 0)
                {
                    for (int j = 0; j < chkValidRegions.Items.Count; j++)
                    {
                        if (lstValidRegions.Exists(delegate(int region) { return region == Convert.ToInt32(chkValidRegions.Items[j].Value); }))
                        {
                            chkValidRegions.Items[j].Selected = true;
                        }

                    }
                }
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int EthnicityID = Convert.ToInt32(e.CommandArgument);
                objEthnicity.EthnicityID = EthnicityID;
                objEthnicity.Status = 0;
                EthnicityBO.DeleteEthnicity(objEthnicity);
                loadEthinicity();
                LoadGeoBasedEthnicity();
            }
        }
    }
}