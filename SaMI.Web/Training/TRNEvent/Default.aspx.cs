using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaMI.DTO;
using SaMI.Business;
using System.Data;
using System.Drawing;

namespace SaMI.Web.Training.TRNEvent
{
    public partial class Default : System.Web.UI.Page
    {
        String EventID = String.Empty;
        int TradeID = 0, TrainingAgencyID = 0;

       protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadOptions();
                LoadTrainingEvent();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (lblID.Text != string.Empty)
            {
                TRNTrainingEvent trnEventUpdate = new TRNTrainingEvent();
                trnEventUpdate.TrainingAgencyID = Convert.ToInt32(ddlTrainingAgency.SelectedValue);
                trnEventUpdate.EventID = Convert.ToInt32(lblID.Text);
                trnEventUpdate.Batch = txtBatch.Text;
                trnEventUpdate.Event = txtEventID.Text;
                trnEventUpdate.TradeNameID = Convert.ToInt32(ddlTradeName.SelectedValue);
                trnEventUpdate.StartDate = Convert.ToDateTime(txtStartDate.Text);
                trnEventUpdate.EndDate = Convert.ToDateTime(txtEndDate.Text);
                trnEventUpdate.ModifiedBy = 1;
                trnEventUpdate.Status = 1;

                if (chkCostSharing.Checked == true)
                    trnEventUpdate.CostSharing = 1;
                else 
                    trnEventUpdate.CostSharing = 0;
                if (chkRegular.Checked == true)
                    trnEventUpdate.Regular = 1;
                else 
                    trnEventUpdate.Regular = 0;

                int result = new TRNTrainingEventBO().UpdateTrainingEvent(trnEventUpdate);
                if (result > 0)
                {
                    Clear();
                    LoadTrainingEvent();
                    btnSave.Text = "Save";
                }

            }
            else
            {
                TRNTrainingEvent trnEvent = new TRNTrainingEvent();
                trnEvent.TrainingAgencyID = Convert.ToInt32(ddlTrainingAgency.SelectedValue);
                trnEvent.Batch = txtBatch.Text;
                trnEvent.Event = txtEventID.Text;
                trnEvent.TradeNameID = Convert.ToInt32(ddlTradeName.SelectedValue);
                trnEvent.StartDate = Convert.ToDateTime(txtStartDate.Text);
                trnEvent.EndDate = Convert.ToDateTime(txtEndDate.Text);
                trnEvent.CreatedBy = UserAuthentication.GetUserId(this.Page);
                trnEvent.Status = 1;

                if (chkCostSharing.Checked == true)
                    trnEvent.CostSharing = 1;
                else
                    trnEvent.CostSharing = 0;
                if (chkRegular.Checked == true)
                    trnEvent.Regular = 1;
                else
                    trnEvent.Regular = 0;

                int result = new TRNTrainingEventBO().InsertTrainingEvent(trnEvent);
                if (result > 0)
                {
                    Clear();
                    LoadTrainingEvent();
                }
            }
        }

        private void LoadOptions()
        {
            DataView dv = new TRNTrainingAgencyBO().GetAllTraingAgency(true);
            ddlTrainingAgency.DataSource = dv;
            ddlTrainingAgency.DataValueField = "ID";
            ddlTrainingAgency.DataTextField = "TrainingAgency";
            ddlTrainingAgency.DataBind();

            DataView dvTrade = new TRNTradeBO().SelectAllTradeName(true);
            ddlTradeName.DataSource = dvTrade;
            ddlTradeName.DataValueField = "TRNTradeID";
            ddlTradeName.DataTextField = "TradeName";
            ddlTradeName.DataBind();

            //Search By TradeName, Training Agency and EventID

            DataView dvSearchByTradeName = new TRNTradeBO().SelectAllTradeName(true);
            ddlSearchByTradeName.DataSource = dvSearchByTradeName;
             ddlSearchByTradeName.DataValueField = "TRNTradeID";
             ddlSearchByTradeName.DataTextField = "TradeName";
             ddlSearchByTradeName.DataBind();

             DataView dvSearchByTrainingAgency = new TRNTrainingAgencyBO().GetAllTraingAgency(true);
             ddlSearchByTrainingAgency.DataSource = dvSearchByTrainingAgency;
             ddlSearchByTrainingAgency.DataValueField = "ID";
             ddlSearchByTrainingAgency.DataTextField = "TrainingAgency";
             ddlSearchByTrainingAgency.DataBind();
            
        }

        public void LoadTrainingEvent()
        {
            DataView dvEvent = TRNTrainingEventBO.GetAllTrainingEvent(false, EventID, TradeID, TrainingAgencyID);
            gvTrainingEvent.DataSource = dvEvent;
            gvTrainingEvent.DataBind();
        }

        protected void gvTraining_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmdName = e.CommandName;
            int eventID = Convert.ToInt32(e.CommandArgument);
            if (cmdName.Equals("cmdDelete"))
            {
                TRNTrainingEvent eventDelete = new TRNTrainingEvent();
                eventDelete.EventID = eventID;
                eventDelete.ModifiedBy = 1;
                eventDelete.Status = 0;

                int result = new TRNTrainingEventBO().DeleteTrainingEvent(eventDelete);
                LoadTrainingEvent();
            }
            if (cmdName.Equals("cmdEdit"))
            {
                DataView dvRecord = new TRNTrainingEventBO().GetTrainingEventByID(eventID);
                if (dvRecord.Count > 0)
                {
                    txtBatch.Text = dvRecord.Table.Rows[0]["Batch"].ToString();
                    txtEventID.Text = dvRecord.Table.Rows[0]["EventID"].ToString();
                    ddlTradeName.SelectedValue = dvRecord.Table.Rows[0]["TradeNameID"].ToString();
                    txtStartDate.Text = Convert.ToDateTime(dvRecord.Table.Rows[0]["StartDate"]).ToShortDateString();
                    txtEndDate.Text = Convert.ToDateTime(dvRecord.Table.Rows[0]["EndDate"]).ToShortDateString();
                    lblID.Text = dvRecord.Table.Rows[0]["ID"].ToString();
                    if (Convert.ToInt32(dvRecord.Table.Rows[0]["CostSharing"]) == 1)
                        chkCostSharing.Checked = true;
                    else
                        chkCostSharing.Checked = false;
                    if (Convert.ToInt32(dvRecord.Table.Rows[0]["Regular"]) == 1)
                        chkRegular.Checked = true;
                    else
                        chkRegular.Checked = false;
                }
            }

            if (cmdName.Equals("cmdAdd"))
            {
                Response.Redirect("~/Training/Add.aspx?ID=" + eventID);
            }

            LoadTrainingEvent();
        }

        protected void Clear()
        {
            txtBatch.Text = string.Empty;
            txtEventID.Text = string.Empty;
            ddlTradeName.SelectedIndex = 0;
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            lblID.Text = string.Empty;
            chkCostSharing.Checked = false;
            chkRegular.Checked = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ddlSearchByTrainingAgency.SelectedValue = "0";
            ddlSearchByTradeName.SelectedValue = "0";
            if (txtSearchByEventID.Text.Length>=1)
            {
                EventID = txtSearchByEventID.Text;
                DataView dvIDs = TRNTrainingEventBO.GetEID(EventID, 0, 0);
                GetTotalMaleFemale(dvIDs);
                LoadTrainingEvent();
            }
            else
            {
                //txtSearrchByEventID.Text = "Please Enter Event ID";
                //txtSearrchByEventID.ToolTip = "Please Enter Event ID";
                //txtSearrchByEventID.ForeColor = Color.Red;
            }
        }

        public void GetTotalMaleFemale(DataView dvIDs)
        {
            String ID = "EventID IN (";
            foreach (DataRowView drvIDs in dvIDs)
            {
                ID +=  drvIDs["ID"] + ",";
            }

            if (dvIDs.Count!=0)
            {
                String EventID = ID.Substring(0, ID.Length - 1) + ")";

                DataView dvTotalMaleFemale = TRNTrainingEventBO.GetTotalMaleFemale(EventID);

                lblMale.Text = "M: "+ dvTotalMaleFemale.Table.Rows[0]["Male"].ToString();
                lblFemale.Text = "F: " + dvTotalMaleFemale.Table.Rows[0]["Female"].ToString();
                lblTotal.Text = "T: " + dvTotalMaleFemale.Table.Rows[0]["Total"].ToString();
            }
            else
            {
                lblMale.Text = "";
                lblFemale.Text = "";
                lblTotal.Text = "";
            }
        }

        protected void ddlSearchByTrainingAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSearchByTrainingAgency.SelectedIndex > 0)
            {
                TrainingAgencyID = Convert.ToInt32(ddlSearchByTrainingAgency.SelectedValue);
                ddlSearchByTradeName.SelectedValue = "0";
                txtSearchByEventID.Text = "";
                DataView dvIDs = TRNTrainingEventBO.GetEID("", 0,Convert.ToInt32(ddlSearchByTrainingAgency.SelectedValue));
                GetTotalMaleFemale(dvIDs);
                LoadTrainingEvent();
            }
        }
       
        protected void ddlSearchByTradeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlSearchByTradeName.SelectedIndex>0)
            {
                TradeID = Convert.ToInt32(ddlSearchByTradeName.SelectedValue);
                ddlSearchByTrainingAgency.SelectedValue = "0";
                txtSearchByEventID.Text = "";
                DataView dvIDs = TRNTrainingEventBO.GetEID("", Convert.ToInt32(ddlSearchByTradeName.SelectedValue), 0);
                GetTotalMaleFemale(dvIDs);
                LoadTrainingEvent();
            }
        }
    }
}