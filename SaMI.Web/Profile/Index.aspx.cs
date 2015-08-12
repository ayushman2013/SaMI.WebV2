using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using SaMI.DTO;
using SaMI.Business;
using System.IO;
using ClosedXML.Excel;

namespace SaMI.Web.Profile
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                LoadOptions();

                if (UserAuthentication.GetUserType(this.Page) == "ADMIN" || UserAuthentication.GetUserType(this.Page) == "KTMUSER" || UserAuthentication.GetUserType(this.Page) == "CASEUSR" || UserAuthentication.GetUserType(this.Page) == "PARTNER")
                {
                    ddlDistrict.Enabled = true;
                    ddlDistrict.SelectedValue = UserAuthentication.GetDistrictId(this.Page).ToString();
                }
                else
                {
                    ddlDistrict.SelectedValue = UserAuthentication.GetDistrictId(this.Page).ToString();
                    ddlOrganization.SelectedValue = UserAuthentication.GetSaMIOrganizationId(this.Page).ToString();
                    ddlDistrict.Enabled = false;
                }

                if (UserAuthentication.GetUserType(this.Page) == "USER")
                {
                    ddlOrganization.SelectedValue = UserAuthentication.GetSaMIOrganizationId(this.Page).ToString();
                    ddlOrganization.Enabled = false;
                }
                else
                {
                    ddlOrganization.Enabled = true;
                }

                string usertype = UserAuthentication.GetUserType(this.Page);
                LoadProfiles();

                if (UserAuthentication.GetUserType(this.Page) == "ADMIN" || UserAuthentication.GetUserType(this.Page) == "USER" || UserAuthentication.GetUserType(this.Page) == "CASEUSR")
                {
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                }

            }
        }

        protected void btnAdd_click(object sender, EventArgs e)
        {
            Response.Redirect("Add.aspx");
        }

       

        void LoadOptions()
        {
           
            if (UserAuthentication.GetUserType(this.Page) == "USER" || UserAuthentication.GetUserType(this.Page) == "CASEUSR" || UserAuthentication.GetUserType(this.Page) == "PARTNER")
            {
                int DistrictID = UserAuthentication.GetDistrictId(this.Page);
                ddlOrganization.DataSource = SaMIOrganizationBO.GetByDistrictID(DistrictID);
                ddlOrganization.DataValueField = "SaMIOrganizationID";
                ddlOrganization.DataTextField = "SaMIOrganizationName";
                ddlOrganization.DataBind();
            }

            ddlEthnicity.DataSource = EthnicityBO.GetAll(true);
            ddlEthnicity.DataValueField = "EthnicityID";
            ddlEthnicity.DataTextField = "EthnicityName";
            ddlEthnicity.DataBind();

            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();

            

            ListItem li = new ListItem("[Follow-up]", "");
            ddlFollowUpStatus.Items.Add(li);
            li = new ListItem("Yes", "Yes");
            ddlFollowUpStatus.Items.Add(li);
            li = new ListItem("No", "No");
            ddlFollowUpStatus.Items.Add(li);

            if (UserAuthentication.GetUserType(this.Page) == "ADMIN")
            {
                ddlUsers.DataSource = UserBO.GetUsers(true);
                ddlUsers.DataValueField = "UserID";
                ddlUsers.DataTextField = "FullName";
                ddlUsers.DataBind();
            }
            else
            {
                ddlUsers.Visible = false;
            }
        }

        public String GetDeleteLink(string strID, string strTitle)
        {
            String strOut = string.Empty;

            strOut += "<a href= 'Delete.aspx?ID=" + strID + "' class=\"delete_link\" onclick=\"javascript:return ReturnConfirmation('Are you sure to delete News:" + strTitle + "');\" >Delete</a>";

            return strOut;
        }

        protected void gvSaMIProfile_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            SaMIProfiles objSamiProfile = new SaMIProfiles();
            if (e.CommandName.Equals("cmdDelete"))
            {
                int SaMIProfileID = Convert.ToInt32(e.CommandArgument);
                objSamiProfile.SaMIProfileID = SaMIProfileID;
                objSamiProfile.Status = 0;
                int rowaffected = SaMIProfileBO.DeleteProfile(objSamiProfile);
               LoadProfiles();
            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDistrict.SelectedIndex > 0)
            {
                if (UserAuthentication.GetUserType(this.Page) == "ADMIN")
                {
                    ddlOrganization.DataSource = SaMIOrganizationBO.GetOrganizationByDistrictID(Convert.ToInt32(ddlDistrict.SelectedValue), "[Organization]");
                    ddlOrganization.DataValueField = "SaMIOrganizationID";
                    ddlOrganization.DataTextField = "SaMIOrganizationName";
                    ddlOrganization.DataBind();

                    ddlUsers.DataSource = UserBO.SelectByDistrictID(Convert.ToInt32(ddlDistrict.SelectedValue), "[Users]");
                    ddlUsers.DataValueField = "UserID";
                    ddlUsers.DataTextField = "FullName";
                    ddlUsers.DataBind();
                }
                else
                {
                    int DistrictID = UserAuthentication.GetDistrictId(this.Page);
                    ddlOrganization.DataSource = SaMIOrganizationBO.GetOrganizationByDistrictID(DistrictID, "[Organization]");
                    ddlOrganization.DataValueField = "SaMIOrganizationID";
                    ddlOrganization.DataTextField = "SaMIOrganizationName";
                    ddlOrganization.DataBind();
                }

                txtSearchText.Text = String.Empty;

                LoadProfiles();
            }
        }

        protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrganization.SelectedIndex > 0)
            {
                txtSearchText.Text = String.Empty;
                LoadProfiles();
            }
        }

        protected void ddlFollowUpStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFollowUpStatus.SelectedIndex > 0)
            {
                txtSearchText.Text = String.Empty;
                LoadProfiles();
            }
        }

        protected void gvSaMIProfile_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadProfiles();
            gvSaMIProfile.PageIndex = e.NewPageIndex;
            gvSaMIProfile.DataBind();
            
            Session["pageNumber"] = e.NewPageIndex;
            //if(!IsPostBack)
           
            
        }

        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsers.SelectedIndex > 0)
            {
                txtSearchText.Text = String.Empty;
                LoadProfiles();
            }
        }

        protected void ddlEthnicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEthnicity.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(ddlEthnicity.SelectedValue))
                {
                    LoadValidRegions(Convert.ToInt32(ddlEthnicity.SelectedValue));
                }
                txtSearchText.Text = String.Empty;
                LoadProfiles();
            }
        }

        void LoadValidRegions(int EthnicityID)
        {
            List<int> lstValidRegions = EthnicityBO.SelectValidRegionForEthnicity(EthnicityID);

            ddlValidRegions.DataSource = EthnicityBO.SelectRegionsForDropdown(lstValidRegions, "[Regions]");
            ddlValidRegions.DataValueField = "GeoBasedEthnicityID";
            ddlValidRegions.DataTextField = "GeoBasedEthnicityDesc";
            ddlValidRegions.DataBind();
        }

        protected void ddlValidRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlValidRegions.SelectedIndex > 0)
            {
                txtSearchText.Text = String.Empty;
                LoadProfiles();
            }
        }

        protected void LoadProfiles()
        {
            int partnerID = 0;
            int userID = 0;
            int ethnicityID = 0;
            int validRegionID = 0;
            int districtID = 0;
            int createdBy = 0;
            string followUpStatus = string.Empty;
            int saMIOrganizationID = 0;
            String search = String.Empty;

            if (!string.IsNullOrEmpty(ddlEthnicity.SelectedValue))
                ethnicityID = Convert.ToInt32(ddlEthnicity.SelectedValue);
            if (!string.IsNullOrEmpty(ddlValidRegions.SelectedValue))
                validRegionID = Convert.ToInt32(ddlValidRegions.SelectedValue);
            if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                districtID = Convert.ToInt32(ddlDistrict.SelectedValue);

            if (!string.IsNullOrEmpty(ddlFollowUpStatus.SelectedValue))
                followUpStatus = ddlFollowUpStatus.SelectedValue;
            if (!string.IsNullOrEmpty(ddlUsers.SelectedValue))
                createdBy = Convert.ToInt32(ddlUsers.SelectedValue);

            if (UserAuthentication.GetUserType(this.Page) == "PARTNER")
            {
                partnerID = UserAuthentication.GetPartnerId(this.Page);
                userID = UserAuthentication.GetUserId(this.Page);
            }
            //else if (UserAuthentication.GetUserType(this.Page) == "USER")
            //{
            //    saMIOrganizationID = UserAuthentication.GetSaMIOrganizationId(this.Page);
            //}
            else if (UserAuthentication.GetUserType(this.Page) == "ADMIN" || UserAuthentication.GetUserType(this.Page) == "USER")
            {
                if (!string.IsNullOrEmpty(ddlOrganization.SelectedValue))
                    saMIOrganizationID = Convert.ToInt32(ddlOrganization.SelectedValue);
            }

            search = txtSearchText.Text;

            // Load Data in Grid View
            gvSaMIProfile.DataSource = SaMIProfileBO.GetCustom(search, ethnicityID, validRegionID, districtID, saMIOrganizationID, followUpStatus, 0, "", "", "SP.CreatedDate DESC", partnerID, userID, createdBy, saMIOrganizationID);

            gvSaMIProfile.DataBind();

            //Get Record Count
            DataView dv = SaMIProfileBO.CountRecord(search, string.Empty, string.Empty, saMIOrganizationID, ethnicityID, validRegionID, districtID, followUpStatus, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", createdBy);
            int count = Convert.ToInt32(dv.Table.Rows[0]["Count"]);
            lblNoOfRecords.Text = count.ToString();


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProfiles();
            //if (!string.IsNullOrEmpty(txtSearchText.Text))
            //{
            //    int districtID = 0;
            //    int partnerID = 0;
            //    int OrganizationID = 0;
            //    int ethnicityID = 0;
            //    int validRegionID = 0;
            //    string followUpStatus = string.Empty;
            //    int createdBy = 0;

            //    if (UserAuthentication.GetUserType(this.Page) == "USER" || UserAuthentication.GetUserType(this.Page) == "PARTNER" || UserAuthentication.GetUserType(this.Page) == "CASEUSR")
            //        districtID = UserAuthentication.GetDistrictId(this.Page);
            //    else
            //        districtID = Convert.ToInt32(ddlDistrict.SelectedValue);
            //    if (UserAuthentication.GetUserType(this.Page) == "PARTNER")
            //        partnerID = UserAuthentication.GetPartnerId(this.Page);
            //    if (UserAuthentication.GetUserType(this.Page) == "USER" || UserAuthentication.GetUserType(this.Page) == "PARTNER" || UserAuthentication.GetUserType(this.Page) == "CASEUSR")
            //        OrganizationID = UserAuthentication.GetSaMIOrganizationId(this.Page);
            //    else
            //    {
            //        if(!String.IsNullOrEmpty(ddlOrganization.SelectedValue))
            //        OrganizationID = Convert.ToInt32(ddlOrganization.SelectedValue);
            //    }

            //    if (!string.IsNullOrEmpty(ddlEthnicity.SelectedValue))
            //        ethnicityID = Convert.ToInt32(ddlEthnicity.SelectedValue);
            //    if (!string.IsNullOrEmpty(ddlValidRegions.SelectedValue))
            //        validRegionID = Convert.ToInt32(ddlValidRegions.SelectedValue);

            //    if (!string.IsNullOrEmpty(ddlFollowUpStatus.SelectedValue))
            //        followUpStatus = ddlFollowUpStatus.SelectedValue;

            //    if (!string.IsNullOrEmpty(ddlUsers.SelectedValue))
            //        createdBy = Convert.ToInt32(ddlUsers.SelectedValue);

                

            //    gvSaMIProfile.DataSource = SaMIProfileBO.GetReport(txtSearchText.Text.Trim(), string.Empty, string.Empty, OrganizationID, ethnicityID, validRegionID, districtID, "", 0, "", 
            //                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, partnerID, createdBy, 0, "", "", "", "", "", "", followUpStatus, "", "", "");
            //    gvSaMIProfile.DataBind();

            //    //Get Record Count
            //    DataView dv = SaMIProfileBO.CountRecord(txtSearchText.Text.Trim(), string.Empty, string.Empty, OrganizationID, ethnicityID, validRegionID, districtID, "", 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", createdBy);
            //    int count = Convert.ToInt32(dv.Table.Rows[0]["Count"]);
            //    lblNoOfRecords.Text = count.ToString();
            //}
        }

        //protected void GetSelectedRecords(object sender, EventArgs e)
        //{
        //    TRNRecruitmentList objRecruitmentList = new TRNRecruitmentList();
        //    SaMIProfiles objSamiProfile = new SaMIProfiles();
        //    foreach (GridViewRow row in gvSaMIProfile.Rows)
        //    {
        //        if (row.RowType == DataControlRowType.DataRow)
        //        {
        //            CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
        //            if (chkRow.Checked)
        //            {
        //                string SaMIProfileID = row.Cells[1].Text;
        //                string OrganizationID = row.Cells[2].Text;
        //                objRecruitmentList.SaMIProfileID = Convert.ToInt32(SaMIProfileID);
        //                objRecruitmentList.OrganizationID = Convert.ToInt32(OrganizationID);

        //                objRecruitmentList.CreatedBy = UserAuthentication.GetUserId(this.Page);
        //                objRecruitmentList.CreatedDate = DateTime.Now;
        //                int intresult = TRNRecruitmentListBO.InsertRecruitmentList(objRecruitmentList);

        //                objSamiProfile.SaMIProfileID = objRecruitmentList.SaMIProfileID;
        //                objSamiProfile.ReferStatus = 1;
        //                objSamiProfile.UpdatedBy = UserAuthentication.GetUserId(this.Page);
        //                objSamiProfile.UpdatedDate = DateTime.Now;
        //                int result = SaMIProfileBO.UpdateProfileReferred(objSamiProfile);
        //            }
        //        }
        //    }
        //}

       
    }
}