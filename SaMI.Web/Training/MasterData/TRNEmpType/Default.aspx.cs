using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaMI.DTO;
using SaMI.Business;
using System.Data;

namespace SaMI.Web.Training.MasterData.TRNEmpType
{
    public partial class Default : System.Web.UI.Page
    {
        public string valueIn = "in";
        public int collapse = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadEmployemntType();
        }

        protected void LoadEmployemntType()
        {
            DataView dvEmployeementType = new TRNEmploymentTypeBO().GetAllEmploymentType();
            gvEmploymentType.DataSource = dvEmployeementType;
            gvEmploymentType.DataBind();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (lblID.Text != string.Empty)
            {
                TRNEmploymentType empTypeUpdate = new TRNEmploymentType();
                empTypeUpdate.EmployeeTypeID = Convert.ToInt32(lblID.Text);
                empTypeUpdate.EmploymentType = txtEmploymentType.Text;
                empTypeUpdate.Status = 1;
                empTypeUpdate.ModifiedBy = 1;
                int result = new TRNEmploymentTypeBO().UpdateTrainingAgency(empTypeUpdate);
                if (result > 0)
                {
                    Clear();
                    collapse = 1;
                    btnSave.Text = "Save";
                    LoadEmployemntType();
                }
               
                LoadEmployemntType();

            }
            else
            {
                TRNEmploymentType empTypeInsert = new TRNEmploymentType();
                empTypeInsert.EmploymentType = txtEmploymentType.Text;
                empTypeInsert.Status = 1;
                empTypeInsert.CreatedBy = 1;
                int result = new TRNEmploymentTypeBO().InsertTrainingAgency(empTypeInsert);
                if (result > 0)
                {
                    Clear();
                    collapse = 1;
                    LoadEmployemntType();
                }
                
                LoadEmployemntType();
            }

        }

        protected void gvEmploymentType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string cmdName = e.CommandName;
            if (cmdName.Equals("cmdDelete"))
            {
                // Perform Delete Operation
                TRNEmploymentType type = new TRNEmploymentType();
                type.EmployeeTypeID = id;
                type.ModifiedBy = 1;
                type.Status = 0;

                int result = new TRNEmploymentTypeBO().DeleteTrainingAgency(type);
                LoadEmployemntType();
            }

            if (cmdName.Equals("cmdEdit"))
            {
                // Show data to TextBoses and controls
                DataView dvRecord = new TRNEmploymentTypeBO().GetTrainingAgencyByID(id);
                if (dvRecord.Count > 0)
                {
                    lblID.Text = dvRecord.Table.Rows[0]["ID"].ToString();
                    txtEmploymentType.Text = dvRecord.Table.Rows[0]["EmploymentType"].ToString();
                    collapse = 0;
                    btnSave.Text = "Update";
                }
            }


        }

        protected void Clear()
        {
            txtEmploymentType.Text = string.Empty;
            lblID.Text = string.Empty;
        }
    }


}