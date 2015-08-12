using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SaMI.Business;
using SaMI.DTO;

namespace SaMI.Web.Training.MasterData.TRNChkList
{
    public partial class Default : System.Web.UI.Page
    {
        public string valueIn = "in";
        public int collapse = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCheckList();
        }

        protected void LoadCheckList()
        {
            DataView dvCheckList = new TRNCheckListBO().GetAllCheckList();
            gvTRNChkList.DataSource = dvCheckList;
            gvTRNChkList.DataBind();
        }

        protected void Clear()
        {
            txtCheckList.Text = string.Empty;
            lblID.Text = string.Empty;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (lblID.Text != string.Empty)
            {
                TRNCheckList chkList = new TRNCheckList();
                chkList.ChkListID = Convert.ToInt32(lblID.Text);
                chkList.CheckList = txtCheckList.Text;
                chkList.ModifiedBy = 1;
                chkList.Status = 1;
                int result = new TRNCheckListBO().UpdateCheckList(chkList);
                if (result > 0)
                {
                    Clear();
                    LoadCheckList();
                    collapse = 1;
                    btnSave.Text = "Save";
                }
               
            }
            else
            {
                TRNCheckList chkListInsert = new TRNCheckList();
                chkListInsert.CheckList = txtCheckList.Text;
                chkListInsert.CreatedBy = 1;
                chkListInsert.Status = 1;
                int result = new TRNCheckListBO().InsertCheckList(chkListInsert);
                if (result > 0)
                {
                    Clear();
                    collapse = 1;
                    LoadCheckList();
                }
             
            }

        }
        protected void gvTRNChkList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string cmdName = e.CommandName;
            if (cmdName.Equals("cmdDelete"))
            {
               // Perform Delete Operation
                TRNCheckList chkList = new TRNCheckList();
                chkList.ChkListID = id;
                chkList.ModifiedBy = 1;
                chkList.Status = 0;

                int result = new TRNCheckListBO().DeleteCheckList(chkList);
                LoadCheckList();
            }

            if (cmdName.Equals("cmdEdit"))
            {
                // Show data to TextBoses and controls
                DataView dvRecord = new TRNCheckListBO().GetCheckListByID(id);
                if (dvRecord.Count > 0)
                {
                    lblID.Text = dvRecord.Table.Rows[0]["ID"].ToString();
                    txtCheckList.Text = dvRecord.Table.Rows[0]["Checklist"].ToString();
                    collapse = 0;
                    btnSave.Text = "Update";
                }

            }
        }
    }
}