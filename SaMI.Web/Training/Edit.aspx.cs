using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.Training
{
    public partial class Edit : System.Web.UI.Page
    {
        public int TraineeID = 0;
        public List<int> list = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString.Get("ID")))
                TraineeID = Convert.ToInt32(Request.QueryString.Get("ID"));

            if (!Page.IsPostBack)
            {
                LoadTraineeOptions();
                LoadAllData(TraineeID);
            }
        }

        void LoadTraineeOptions()
        {
            ddlCountry.DataSource = CountriesBO.GetAll(true);
            ddlCountry.DataValueField = "CountryID";
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataBind();

            ddlWhichCountry.DataSource = CountriesBO.GetAll(true);
            ddlWhichCountry.DataValueField = "CountryID";
            ddlWhichCountry.DataTextField = "CountryName";
            ddlWhichCountry.DataBind();

            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();

            ddlVDC.DataSource = VDCBO.GetAll(true);
            ddlVDC.DataValueField = "VDCID";
            ddlVDC.DataTextField = "VDCName";
            ddlVDC.DataBind();

            ddlFeedDurationTypeID.DataSource = FeedDurationTypeBO.GetAll(true);
            ddlFeedDurationTypeID.DataValueField = "FeedDurationTypeID";
            ddlFeedDurationTypeID.DataTextField = "FeedDurationTypeDesc";
            ddlFeedDurationTypeID.DataBind();

            ddlQualification.DataSource = new TRNEducationLevelBO().GetAllEducationLevel(true);
            ddlQualification.DataValueField = "ID";
            ddlQualification.DataTextField = "EducationLevel";
            ddlQualification.DataBind();

            ddlInformationSource.DataSource = new TRNInformaitonSourceBO().GetAllInformationSource(true);
            ddlInformationSource.DataValueField = "ID";
            ddlInformationSource.DataTextField = "InformationSource";
            ddlInformationSource.DataBind();


            ddlCastEthinicity.DataSource = new TRNEthnicityBO().GetAllEthnicity(true);
            ddlCastEthinicity.DataValueField = "EthnicityID";
            ddlCastEthinicity.DataTextField = "EthnicityName";
            ddlCastEthinicity.DataBind();

            ddlCitizenshipIssuedDistict.DataSource = DistrictBO.GetAll(true);
            ddlCitizenshipIssuedDistict.DataValueField = "DistrictID";
            ddlCitizenshipIssuedDistict.DataTextField = "DistrictName";
            ddlCitizenshipIssuedDistict.DataBind();



            ddlEmploymentType.DataSource = new TRNEmploymentTypeBO().GetAllEmploymentType(true);
            ddlEmploymentType.DataValueField = "ID";
            ddlEmploymentType.DataTextField = "EmploymentType";
            ddlEmploymentType.DataBind();

            ddlEmploymentStatus.DataSource = new TRNEmploymentStatusBO().GetAllEmploymentStatus(true);
            ddlEmploymentStatus.DataValueField = "ID";
            ddlEmploymentStatus.DataTextField = "EmploymentStatus";
            ddlEmploymentStatus.DataBind();

            ddlTraineeCheckList.DataSource = new TRNCheckListBO().GetAllCheckList(false);
            ddlTraineeCheckList.DataTextField = "Checklist";
            ddlTraineeCheckList.DataValueField = "ID";
            ddlTraineeCheckList.DataBind();
        }

        private void LoadAllData(int TraineeID)
        {
            LoadGeoBasedEthnicity();
            LoadTrainee(TraineeID);
            LoadCurrentEmployment(TraineeID);
            LoadEmployment(TraineeID);
            LoadPreviousTraining(TraineeID);
        }

        void LoadGeoBasedEthnicity()
        {
            rbValidRegions.DataSource = EthnicityBO.SelectGeoBasedEthnicity();
            rbValidRegions.DataValueField = "GeoBasedEthnicityID";
            rbValidRegions.DataTextField = "GeoBasedEthnicityDesc";
            rbValidRegions.DataBind();
        }

        void LoadValidRegions(int EthnicityID)
        {
            List<int> lstValidRegions = EthnicityBO.SelectValidRegionForEthnicity(EthnicityID);

            if (lstValidRegions.Count > 0)
            {

                for (int j = 0; j < rbValidRegions.Items.Count; j++)
                {

                    if (lstValidRegions.Exists(delegate(int region) { return region == Convert.ToInt32(rbValidRegions.Items[j].Value); }))
                    {
                    }
                    else
                        list.Add(j);

                }
                foreach (int a in list)
                {
                    rbValidRegions.Items[a].Attributes.Add("hidden", "hidden");
                }

            }
            else
            {
                for (int j = 0; j < rbValidRegions.Items.Count; j++)
                {
                    rbValidRegions.Items[j].Attributes.Add("hidden", "hidden");

                }
            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
            {
                if (Convert.ToInt32(ddlDistrict.SelectedValue) > 0)
                {
                    LoadValidRegions(Convert.ToInt32(ddlCastEthinicity.SelectedValue));
                    int districtID = Convert.ToInt32(ddlDistrict.SelectedValue);
                    ddlVDC.DataSource = VDCBO.GetAllByDistrictID(districtID, true);
                    ddlVDC.DataValueField = "VDCID";
                    ddlVDC.DataTextField = "VDCName";
                    ddlVDC.DataBind();
                }
            }
        }

        private void LoadTrainee(int TraineeID)
        {
            TRNTrainee objTrainee = TRNTraineeBO.GetTraineeByID(TraineeID);
            ddlQualification.SelectedValue = objTrainee.EducationLevelID.ToString();
            ddlInformationSource.SelectedValue = objTrainee.InformationSourceID.ToString();

            ddlDistrict.SelectedValue = objTrainee.DistrictID.ToString();
            ddlVDC.SelectedValue = objTrainee.VDCID.ToString();
            ddlCastEthinicity.SelectedValue = objTrainee.EthnicityID.ToString();

            LoadValidRegions(Convert.ToInt32(ddlCastEthinicity.SelectedValue));

            List<int> lstValidRegions = EthnicityBO.SelectValidRegionsForTrainee(Convert.ToInt32(ddlCastEthinicity.SelectedValue), TraineeID);


            if (lstValidRegions.Count > 0)
            {
                for (int j = 0; j < rbValidRegions.Items.Count; j++)
                {
                    if (lstValidRegions.Exists(delegate(int region) { return region == Convert.ToInt32(rbValidRegions.Items[j].Value); }))
                    {
                        rbValidRegions.Items[j].Selected = true;
                    }

                }
            }

            ddlFeedDurationTypeID.SelectedValue = objTrainee.FeedDurationTypeID.ToString();
            ddlCitizenshipIssuedDistict.SelectedValue = objTrainee.CitizenshipIssueDistictID.ToString();
            ddlGender.SelectedValue = objTrainee.Gender.ToString();
            ddlMaritalStatus.SelectedValue = objTrainee.MaritalStatus.ToString();

            txtFirstName.Text = objTrainee.FirstName;
            txtLastName.Text = objTrainee.LastName;
            txtDateOfBirthAD.Text = objTrainee.DateOfBirthAD;
            txtDateOfBirthBS.Text = objTrainee.DateOfBirthBS;
            txtAge.Text = objTrainee.CurrentAge;
            hfSpecialCase.Value = objTrainee.SpecialCase;
            txtTol.Text = objTrainee.Tole;
            txtWardNumber.Text = objTrainee.WardNumber;
            txtPhoneNumberHouse.Text = objTrainee.PhoneNumber;
            txtMobile.Text = objTrainee.MobileNumber;
            txtCitizenshipNumber.Text = objTrainee.CitizenshipNumber;
            txtPassportNumber.Text = objTrainee.PassportNumber;
            txtFathersName.Text = objTrainee.FatherName;
            txtFathersContactNumber.Text = objTrainee.FatherTelephone;
            txtContactPerson.Text = objTrainee.ContactPerson;
            txtContactPersonContactTelephone.Text = objTrainee.ContactPersonTelephone;
            ImgPrv.ImageUrl = objTrainee.Photo;
            if (Convert.ToInt32(objTrainee.Unemployment) == 1)
            {
                chkUnEmployment.Checked = true;
                txtSelfEmploymentIncome.Enabled = false;
            }
            else
            {
                chkUnEmployment.Checked = false;
                txtSelfEmploymentIncome.Text = objTrainee.SelfEmployment.ToString();
            }

            txtWageIncome.Text = objTrainee.Wage.ToString();
            txtAgricultureIncome.Text = objTrainee.Agriculture.ToString();
            txtForeignIncome.Text = objTrainee.ForeignEmploymentIncome.ToString();
            txtOtherIncome.Text = objTrainee.Other.ToString();

            //txtTrainingRegistrationDate.Text = objTrainee.RegisteredDate.ToShortDateString();
            txtFamilyMember.Text = objTrainee.NoOfFamilyMember.ToString();

            txtReferredBy.Text = objTrainee.ReferredBy;

        }

        private void LoadCurrentEmployment(int TraineeID)
        {
            DataView dvCurrentEmploymentInfo = TRNCurrentEmploymentBO.GetCurrentEmploymentInfoByID(TraineeID);
            if (dvCurrentEmploymentInfo.Count > 0)
            {
                if (dvCurrentEmploymentInfo.Table.Rows[0]["CountryID"].ToString() != "")
                {
                    rbCurrentCountryYes.Checked = true;
                    ddlWhichCountry.SelectedValue = dvCurrentEmploymentInfo.Table.Rows[0]["CountryID"].ToString();
                    txtWorkingYears.Text = dvCurrentEmploymentInfo.Table.Rows[0]["WorkingYear"].ToString();
                    txtWorkingMonths.Text = dvCurrentEmploymentInfo.Table.Rows[0]["WorkingMonth"].ToString();
                    txtOccupation.Text = dvCurrentEmploymentInfo.Table.Rows[0]["Occupation"].ToString();
                    txtPreviousMonthlySalary.Text = dvCurrentEmploymentInfo.Table.Rows[0]["MonthlySalary"].ToString();
                    txtPreviousReturnDate.Text = dvCurrentEmploymentInfo.Table.Rows[0]["ReturnDate"].ToString();
                }
                else
                {
                    rbCurrentCountryNo.Checked = true;
                    DisableCurrentAbroadInfo();
                }
            }
            else
            {
                rbCurrentCountryNo.Checked = true;
                DisableCurrentAbroadInfo();
            }
        }

        private void LoadEmployment(int TraineeID)
        {
            DataView dvEmploymentInfo = TRNEmploymentBO.GetEmploymentInfoByTraineeID(TraineeID);
            if (dvEmploymentInfo.Count > 0)
            {
                if (dvEmploymentInfo.Table.Rows[0]["CountryID"].ToString() != "")
                {
                    rdoAbroadYes.Checked = true;

                    if (!String.IsNullOrEmpty(dvEmploymentInfo.Table.Rows[0]["CountryID"].ToString()))
                        ddlCountry.SelectedValue = dvEmploymentInfo.Table.Rows[0]["CountryID"].ToString();
                    if (!String.IsNullOrEmpty(dvEmploymentInfo.Table.Rows[0]["RecruitmentAgency"].ToString()))
                        txtPastRecruitmentAgency.Text = dvEmploymentInfo.Table.Rows[0]["RecruitmentAgency"].ToString();
                    if (!String.IsNullOrEmpty(dvEmploymentInfo.Table.Rows[0]["Organization"].ToString()))
                        txtCompany.Text = dvEmploymentInfo.Table.Rows[0]["Organization"].ToString();
                    if (!String.IsNullOrEmpty(dvEmploymentInfo.Table.Rows[0]["EmploymentStatusID"].ToString()))
                        ddlEmploymentStatus.SelectedValue = dvEmploymentInfo.Table.Rows[0]["EmploymentStatusID"].ToString();
                    if (!String.IsNullOrEmpty(dvEmploymentInfo.Table.Rows[0]["EmploymentTypeID"].ToString()))
                        ddlEmploymentType.SelectedValue = dvEmploymentInfo.Table.Rows[0]["EmploymentTypeID"].ToString();
                    if (!String.IsNullOrEmpty(dvEmploymentInfo.Table.Rows[0]["DepartureDate"].ToString()))
                        txtDepartureDate.Text = dvEmploymentInfo.Table.Rows[0]["DepartureDate"].ToString();
                   

                    if (!String.IsNullOrEmpty(dvEmploymentInfo.Table.Rows[0]["EmploymentPeriod"].ToString()))
                        txtEmploymentPeriod.Text = dvEmploymentInfo.Table.Rows[0]["EmploymentPeriod"].ToString();
                    if (!String.IsNullOrEmpty(dvEmploymentInfo.Table.Rows[0]["Salary"].ToString()))
                        txtMonthlySalary.Text = dvEmploymentInfo.Table.Rows[0]["Salary"].ToString();
                    if (!String.IsNullOrEmpty(dvEmploymentInfo.Table.Rows[0]["Currency"].ToString()))
                        txtForeignCurrency.Text = dvEmploymentInfo.Table.Rows[0]["Currency"].ToString();
                    if (!String.IsNullOrEmpty(dvEmploymentInfo.Table.Rows[0]["ReturnDate"].ToString()))
                        txtReturnDate.Text = dvEmploymentInfo.Table.Rows[0]["ReturnDate"].ToString();


                    DataView dvTrainee = TRNTraineeBO.GetTrainingByID(TraineeID);

                    if (dvTrainee.Table.Rows[0]["Unemployment"].ToString() == "1")
                    {
                        chkUnEmployment.Checked = true;
                    }
                    else
                    {
                        chkUnEmployment.Checked = false;
                    }

                    DataView dvCheckList = TRNEmploymentBO.GetCheckList(TraineeID);
                    string value = "";
                    foreach (DataRowView drv in dvCheckList)
                    {
                        if (drv["ChecklistID"] != null)
                        {

                            value += drv["ChecklistID"] + ",";
                        }
                    }

                    hfTraineeCheckList.Value = value;
                }

                else
                {
                    rdoAbroadNo.Checked = true;
                    DisableAbroadInfo();
                }
            }
            else
            {
                rdoAbroadNo.Checked = true;
                DisableAbroadInfo();
            }
        }

        private void DisableCurrentAbroadInfo()
        {
            ddlWhichCountry.Enabled = false;
            txtWorkingYears.Enabled = false;
            txtWorkingMonths.Enabled = false;
            txtOccupation.Enabled = false;
            txtPreviousMonthlySalary.Enabled = false;
            txtPreviousReturnDate.Enabled = false;


        }

        public void DisableAbroadInfo()
        {
            txtDepartureDate.Enabled = false;
            txtPastRecruitmentAgency.Enabled = false;
            txtCompany.Enabled = false;
            ddlEmploymentType.Enabled = false;
            ddlEmploymentStatus.Enabled = false;
            //txtJobDoneMonth.Enabled = false;
            //txtJobDoneYear.Enabled = false;
            txtEmploymentPeriod.Enabled = false;
            txtMonthlySalary.Enabled = false;
            txtForeignCurrency.Enabled = false;
            txtReturnDate.Enabled = false;
            ddlTraineeCheckList.Enabled = false;
        }

        private void LoadPreviousTraining(int TraineeID)
        {
            DataView dvPreviousTrainingInfo = TRNPreviousTrainingBO.GetPreviousTrainingInfoByID(TraineeID);
            if (dvPreviousTrainingInfo.Count > 0)
            {
                if (dvPreviousTrainingInfo.Table.Rows[0]["Name"].ToString() != "")
                {
                    rbHavePreviousTrainingYes.Checked = true;

                    txtTrainingName.Text = dvPreviousTrainingInfo.Table.Rows[0]["Name"].ToString();
                    txtTrainingYear.Text = dvPreviousTrainingInfo.Table.Rows[0]["Year"].ToString();
                    txtTrainingInstituteName.Text = dvPreviousTrainingInfo.Table.Rows[0]["Institute"].ToString();
                    txtTrainingDuration.Text = dvPreviousTrainingInfo.Table.Rows[0]["Duration"].ToString();

                }
                else
                {
                    rbHavePreviousTrainingNo.Checked = true;
                    txtTrainingName.Enabled = false;
                    txtTrainingYear.Enabled = false;
                    txtTrainingInstituteName.Enabled = false;
                    txtTrainingDuration.Enabled = false;
                }
            }
            else
            {
                rbHavePreviousTrainingNo.Checked = true;
                txtTrainingName.Enabled = false;
                txtTrainingYear.Enabled = false;
                txtTrainingInstituteName.Enabled = false;
                txtTrainingDuration.Enabled = false;
            }
        }

        TRNTrainee MapTrainee()
        {
            TRNTrainee objTrainee = new TRNTrainee();

            objTrainee.TraineeID = TraineeID;

            if (!String.IsNullOrEmpty(ddlQualification.SelectedValue.ToString()))
                objTrainee.EducationLevelID = Convert.ToInt32(ddlQualification.SelectedValue);
            if (!String.IsNullOrEmpty(ddlInformationSource.SelectedValue.ToString()))
                objTrainee.InformationSourceID = Convert.ToInt32(ddlInformationSource.SelectedValue);
            //if (!String.IsNullOrEmpty(ddlTrainingEvent.SelectedValue.ToString()))
            //    objTrainee.EventID = Convert.ToInt32(ddlTrainingEvent.SelectedValue);

            DataView dvTrainingInfo = TRNTraineeBO.GetTrainingInfoByID(TraineeID);
            objTrainee.EventID = Convert.ToInt32(dvTrainingInfo.Table.Rows[0]["TrainingEventID"]);

            if (!String.IsNullOrEmpty(ddlDistrict.SelectedValue.ToString()))
                objTrainee.DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (!String.IsNullOrEmpty(ddlVDC.SelectedValue.ToString()))
                objTrainee.VDCID = Convert.ToInt32(ddlVDC.SelectedValue);
            if (!String.IsNullOrEmpty(ddlCastEthinicity.SelectedValue.ToString()))
                objTrainee.EthnicityID = Convert.ToInt32(ddlCastEthinicity.SelectedValue);


            string ValidRegions = string.Empty;

            for (int j = 0; j < rbValidRegions.Items.Count; j++)
            {
                if (rbValidRegions.Items[j].Selected == true)
                {
                    if (j == 0)
                        ValidRegions = rbValidRegions.Items[j].Value;
                    else
                        ValidRegions = ValidRegions + "," + rbValidRegions.Items[j].Value;
                }
            }

            objTrainee.ValidRegions = ValidRegions;


            if (!String.IsNullOrEmpty(ddlCitizenshipIssuedDistict.SelectedValue.ToString()))
                objTrainee.CitizenshipIssueDistictID = Convert.ToInt32(ddlCitizenshipIssuedDistict.SelectedValue);
            objTrainee.FirstName = txtFirstName.Text;
            objTrainee.LastName = txtLastName.Text;
            objTrainee.Gender = ddlGender.SelectedValue;
            objTrainee.MaritalStatus = ddlMaritalStatus.SelectedValue;
            objTrainee.DateOfBirthAD = txtDateOfBirthAD.Text;
            objTrainee.DateOfBirthBS = txtDateOfBirthBS.Text;
            objTrainee.CurrentAge = txtAge.Text;

            objTrainee.SpecialCase = hfSpecialCase.Value;

            objTrainee.Tole = txtTol.Text;
            objTrainee.WardNumber = txtWardNumber.Text;
            objTrainee.PhoneNumber = txtPhoneNumberHouse.Text;
            objTrainee.MobileNumber = txtMobile.Text;
            objTrainee.CitizenshipNumber = txtCitizenshipNumber.Text;
            objTrainee.PassportNumber = txtPassportNumber.Text;
            objTrainee.FatherName = txtFathersName.Text;
            objTrainee.FatherTelephone = txtFathersContactNumber.Text;
            objTrainee.ContactPerson = txtContactPerson.Text;
            objTrainee.ContactPersonTelephone = txtContactPersonContactTelephone.Text;
            if (chkUnEmployment.Checked)
                objTrainee.Unemployment = 1;
            else
            {
                objTrainee.Unemployment = 0;
                if (!String.IsNullOrEmpty(txtSelfEmploymentIncome.Text))
                    objTrainee.SelfEmployment = Convert.ToDecimal(txtSelfEmploymentIncome.Text);
                else
                    objTrainee.SelfEmployment = 0;
                if (!String.IsNullOrEmpty(txtWageIncome.Text))
                    objTrainee.Wage = Convert.ToDecimal(txtWageIncome.Text);
                else
                    objTrainee.Wage = 0;
                if (!String.IsNullOrEmpty(txtAgricultureIncome.Text))
                    objTrainee.Agriculture = Convert.ToDecimal(txtAgricultureIncome.Text);
                else
                    objTrainee.Agriculture = 0;
                if (!String.IsNullOrEmpty(txtForeignIncome.Text))
                    objTrainee.ForeignEmploymentIncome = Convert.ToDecimal(txtForeignIncome.Text);
                else
                    objTrainee.ForeignEmploymentIncome = 0;
                if (!String.IsNullOrEmpty(txtOtherIncome.Text))
                    objTrainee.Other = Convert.ToDecimal(txtOtherIncome.Text);
                else
                    objTrainee.Other = 0;
                if (!String.IsNullOrEmpty(ddlFeedDurationTypeID.SelectedValue.ToString()))
                    objTrainee.FeedDurationTypeID = Convert.ToInt32(ddlFeedDurationTypeID.SelectedValue);
            }

            //if (!String.IsNullOrEmpty(txtTrainingRegistrationDate.Text))
            //    objTrainee.RegisteredDate = Convert.ToDateTime(txtTrainingRegistrationDate.Text);
            if (!String.IsNullOrEmpty(txtFamilyMember.Text))
                objTrainee.NoOfFamilyMember = Convert.ToInt32(txtFamilyMember.Text);
            objTrainee.CreatedBy = UserAuthentication.GetUserId(this.Page);
            if (fuPhoto.HasFile)
            {
                string path = "~/Training/Photos/";
                objTrainee.Photo = UploadImage(fuPhoto, path);
            }
            objTrainee.Status = 1;

            objTrainee.ReferredBy = txtReferredBy.Text;

            return objTrainee;
        }

        string UploadImage(FileUpload fileupload, string ImageSavedPath)
        {
            FileUpload fu = fileupload;
            string imagepath = "";
            if (fileupload.HasFile)
            {
                string filepath = Server.MapPath(ImageSavedPath);
                String fileExtension = System.IO.Path.GetExtension(fu.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        try
                        {
                            string s_newfilename = DateTime.Now.Year.ToString() +
                                DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
                                DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + fileExtension;
                            fu.PostedFile.SaveAs(filepath + s_newfilename);

                            imagepath = ImageSavedPath + s_newfilename;
                        }
                        catch (Exception ex)
                        {
                            return "";
                        }

                    }

                }

            }
            return imagepath;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TRNDepartureCheckList objDepartureCheckList = new TRNDepartureCheckList();

            int CurrentEmploymentId = 0;
            int employmentId = 0;
            int updateEmp = 0;
            int updateCurrentEmployment = 0;

            #region Current Abroad Information

            TRNCurrentEmployment objCurrentEmployment = new TRNCurrentEmployment();
            objCurrentEmployment.TraineeID = TraineeID;
            DataView dvCurrentEmployment = TRNCurrentEmploymentBO.GetCurrentEmploymentIdByTraineeID(TraineeID);

            if (rbCurrentCountryYes.Checked)
            {
                objCurrentEmployment.CountryID = Convert.ToInt32(ddlWhichCountry.SelectedValue);
                objCurrentEmployment.WorkingYear = txtWorkingYears.Text;
                objCurrentEmployment.WorkingMonth = txtWorkingMonths.Text;
                objCurrentEmployment.Occupation = txtOccupation.Text;
                objCurrentEmployment.MonthlySalary = txtPreviousMonthlySalary.Text;
                objCurrentEmployment.ReturnDate = txtPreviousReturnDate.Text;
            }
            else
            {
                objCurrentEmployment.CountryID = 0;
                objCurrentEmployment.WorkingYear = "";
                objCurrentEmployment.WorkingMonth = "";
                objCurrentEmployment.Occupation = "";
                objCurrentEmployment.MonthlySalary = "";
                objCurrentEmployment.ReturnDate = "";
            }

            objCurrentEmployment.Status = 1;


            if (rbCurrentCountryYes.Checked)
            {
                if (dvCurrentEmployment.Count == 0)
                {
                    objCurrentEmployment.CreatedBy = UserAuthentication.GetUserId(this.Page);
                    CurrentEmploymentId = new TRNTraineeBO().InsertCurrentEmployment(objCurrentEmployment);
                }
                else
                {
                    objCurrentEmployment.ModifiedBy = UserAuthentication.GetUserId(this.Page);

                    CurrentEmploymentId = Convert.ToInt32(dvCurrentEmployment.Table.Rows[0]["ID"]);
                    objCurrentEmployment.EmploymentID = CurrentEmploymentId;
                    objCurrentEmployment.ModifiedBy = UserAuthentication.GetUserId(this.Page);
                    new TRNTraineeBO().UpdateCurrentEmployment(objCurrentEmployment);
                }
            }
            else
            {
                if (dvCurrentEmployment.Count > 0)
                {

                    CurrentEmploymentId = Convert.ToInt32(dvCurrentEmployment.Table.Rows[0]["ID"]);


                    objCurrentEmployment.EmploymentID = CurrentEmploymentId;
                    //objEmployment.Status = 0;
                    updateCurrentEmployment = TRNCurrentEmploymentBO.Delete(CurrentEmploymentId);
                    DisableCurrentAbroadInfo();
                }
                else
                {

                }
            }

            #endregion

            #region Past Abroad Information

            TRNEmployment objEmployment = new TRNEmployment();
            objEmployment.TraineeID = TraineeID;
            DataView dvEmployment = TRNEmploymentBO.GetEmploymentIdByTraineeID(TraineeID);

            if (rdoAbroadYes.Checked)
            {
                if (!String.IsNullOrEmpty(ddlCountry.SelectedValue.ToString()))
                    objEmployment.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                objEmployment.Organization = txtCompany.Text;
                objEmployment.RecruitmentAgency = txtPastRecruitmentAgency.Text;
                //if (!String.IsNullOrEmpty(ddlOrganization.SelectedValue.ToString()))
                //    objEmployment.OrganizationID = Convert.ToInt32(ddlOrganization.SelectedValue);
                if (!String.IsNullOrEmpty(ddlEmploymentType.SelectedValue.ToString()))
                    objEmployment.EmploymentTypeID = Convert.ToInt32(ddlEmploymentType.SelectedValue);
                if (!String.IsNullOrEmpty(ddlEmploymentStatus.SelectedValue.ToString()))
                    objEmployment.EmploymentStatusID = Convert.ToInt32(ddlEmploymentStatus.SelectedValue);
                //if (!String.IsNullOrEmpty(ddlRecruitmentAgency.SelectedValue.ToString()))
                //    objEmployment.RecruitmentAgencyID = Convert.ToInt32(ddlRecruitmentAgency.SelectedValue);
                //objEmployment.WorkDoneMonth = txtJobDoneMonth.Text;
                //objEmployment.WorkDoneYear = txtJobDoneYear.Text;
                objEmployment.EmploymentPeriod = txtEmploymentPeriod.Text;
                if (!String.IsNullOrEmpty(txtMonthlySalary.Text))
                    objEmployment.Salary = txtMonthlySalary.Text.ToString();
                if (!String.IsNullOrEmpty(txtForeignCurrency.Text))
                    objEmployment.Currency = txtForeignCurrency.Text;
                if (!String.IsNullOrEmpty(txtDepartureDate.Text))
                    objEmployment.DepartureDate = Convert.ToDateTime(txtDepartureDate.Text);
                if (!String.IsNullOrEmpty(txtReturnDate.Text))
                    objEmployment.ReturnDate = Convert.ToDateTime(txtReturnDate.Text);
            }

            else
            {
                objEmployment.CountryID = 0;
                objEmployment.Organization = "";
                objEmployment.EmploymentTypeID = 0;
                objEmployment.EmploymentStatusID = 0;
                objEmployment.RecruitmentAgency = "";
                objEmployment.WorkDoneMonth = "";
                objEmployment.WorkDoneYear = "";
                objEmployment.Salary = "";
                objEmployment.Currency = "";
                objEmployment.DepartureDate = null;
                objEmployment.ReturnDate = null;
            }


            objEmployment.Status = 1;

            if (rdoAbroadYes.Checked)
            {
                if (dvEmployment.Count == 0)
                {
                    objEmployment.CreatedBy = UserAuthentication.GetUserId(this.Page);
                    employmentId = new TRNTraineeBO().InsertEmployment(objEmployment);
                }
                else
                {
                    objEmployment.ModifiedBy = UserAuthentication.GetUserId(this.Page);

                    employmentId = Convert.ToInt32(dvEmployment.Table.Rows[0]["ID"]);
                    objEmployment.EmploymentID = employmentId;
                    new TRNTraineeBO().UpdateEmployment(objEmployment);
                }
            }
            else
            {
                if (dvEmployment.Count > 0)
                {

                    employmentId = Convert.ToInt32(dvEmployment.Table.Rows[0]["ID"]);

                    List<int> count = TRNDepartureChecklistBO.GetDepartureCheckListByEmploymentID(employmentId);
                    for (int b = 0; b < count.Count; b++)
                    {
                        DataView dvDepartureCheckList = TRNEmploymentBO.GetDepartureIDByEmploymentID(employmentId);
                        objDepartureCheckList.DepartureChecklistID = Convert.ToInt32(dvDepartureCheckList.Table.Rows[0]["ID"]);

                        TRNDepartureChecklistBO.Delete(Convert.ToInt32(dvDepartureCheckList.Table.Rows[0]["ID"]));
                    }

                    objEmployment.EmploymentID = employmentId;
                    //objEmployment.Status = 0;
                    updateEmp = TRNEmploymentBO.Delete(employmentId);
                    DisableAbroadInfo();
                }
                else
                {

                }
            }
            #endregion


            #region DepartureCheckList


            List<TRNDepartureCheckList> lstDeparture = new List<TRNDepartureCheckList>();
            List<int> checkList = new List<int>();

            string departureList = hfTraineeCheckList.Value;
            string[] list = departureList.Split(',');


            foreach (string item in list)
            {
                if (item != string.Empty)
                {
                    checkList.Add(Convert.ToInt32(item));
                }
            }

            //int EmploymentID = 0;
            //DataView dv = TRNEmploymentBO.GetEmploymentIdByTraineeID(TraineeID);
            //int EmploymentID = Convert.ToInt32(dv.Table.Rows[0]["ID"]);

            if (employmentId > 0)
            {
                String a = hfTraineeCheckList.Value;

                List<int> lstCheckList = TRNDepartureChecklistBO.GetDepartureCheckListByEmploymentID(employmentId);

                //if (lstCheckList.Count > 0)
                //{

                for (int j = 0; j < ddlTraineeCheckList.Items.Count; j++)
                {

                    if (lstCheckList.Exists(delegate(int region) { return region == Convert.ToInt32(ddlTraineeCheckList.Items[j].Value); }))
                    {
                        if (checkList.Exists(delegate(int region) { return region == Convert.ToInt32(ddlTraineeCheckList.Items[j].Value); }))
                        {

                        }
                        else
                        {
                            new TRNDepartureChecklistBO().DeleteDepartureList(employmentId, Convert.ToInt32(ddlTraineeCheckList.Items[j].Value));
                        }
                    }
                    else
                    {
                        if (checkList.Exists(delegate(int region) { return region == Convert.ToInt32(ddlTraineeCheckList.Items[j].Value); }))
                        {
                            objDepartureCheckList.EmploymentID = employmentId;
                            objDepartureCheckList.CheckListID = Convert.ToInt32(ddlTraineeCheckList.Items[j].Value);
                            objDepartureCheckList.Availability = 1;
                            objDepartureCheckList.DepartureChecklistID = new TRNTraineeBO().InsertDepartureList(objDepartureCheckList);
                        }
                        else
                        {

                        }

                    }
                    //list.Add(j);
                }
                //}
            }
            //if (updateEmp > 0)
            //{
            //    employmentId = Convert.ToInt32(dvEmployment.Table.Rows[0]["ID"]);
            //    DataView dvDepartureCheckList = TRNEmploymentBO.GetDepartureIDByEmploymentID(employmentId);
            //    objDepartureCheckList.DepartureChecklistID = Convert.ToInt32(dvDepartureCheckList.Table.Rows[0]["ID"]);

            //    int a = TRNDepartureChecklistBO.Delete(Convert.ToInt32(dvDepartureCheckList.Table.Rows[0]["ID"]));
            //    //new TRNDepartureChecklistBO().DeleteDepartureList(employmentId, Convert.ToInt32(ddlTraineeCheckList.Items[j].Value));
            //}

            #endregion

            #region PreviousTraining

            int previousTrainingId = 0;

            TRNPreviousTraining objPreviousTraining = new TRNPreviousTraining();

            DataView dvPreviousTraining = TRNPreviousTrainingBO.GetPreviousTrainingIDByTraineeID(TraineeID);


            objPreviousTraining.TraineeID = Convert.ToInt32(Request.QueryString.Get("ID"));

            if (rbHavePreviousTrainingYes.Checked)
            {
                objPreviousTraining.Name = txtTrainingName.Text;
                objPreviousTraining.Year = txtTrainingYear.Text;
                objPreviousTraining.Institute = txtTrainingInstituteName.Text;
                objPreviousTraining.Duration = txtTrainingDuration.Text;
            }
            else
            {
                objPreviousTraining.Name = "";
                objPreviousTraining.Year = "";
                objPreviousTraining.Institute = "";
                objPreviousTraining.Duration = "";
            }

            if (rbHavePreviousTrainingYes.Checked)
            {
                if (dvPreviousTraining.Count == 0)
                {
                    previousTrainingId = new TRNTraineeBO().InsertPreviousTraining(objPreviousTraining);
                }
                else
                {
                    objPreviousTraining.PreviousTrainingID = Convert.ToInt32(dvPreviousTraining.Table.Rows[0]["ID"]);
                    previousTrainingId = new TRNTraineeBO().UpdatePreviousTraining(objPreviousTraining);
                }
            }
            else
            {
                if (dvPreviousTraining.Count > 0)
                {
                    objPreviousTraining.PreviousTrainingID = Convert.ToInt32(dvPreviousTraining.Table.Rows[0]["ID"]);
                    previousTrainingId = new TRNTraineeBO().UpdatePreviousTraining(objPreviousTraining);
                }
                else
                {

                }
            }

            #endregion

            int result = new TRNTraineeBO().UpdateTrainee(MapTrainee());


            if (employmentId > 0 || objDepartureCheckList.DepartureChecklistID > 0 || previousTrainingId > 0)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

            //Update TRNTrainee, TRNEmployment, TRNPreviousTraining, TRNDepartureCheckList
            //if (dvPreviousTraining.Count > 0 && dvEmployment.Count > 0)
            //{
            //    int result = new TRNTraineeBO().UpdateTrainee(MapTrainee(), objEmployment, objPreviousTraining);
            //}

            //if (result > 0)
            //{
            //    Response.Redirect("Default.aspx");
            //}
            //else
            //{

            //}
        }

        protected void ddlCastEthinicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGeoBasedEthnicity();
            if (!string.IsNullOrEmpty(ddlCastEthinicity.SelectedValue))
            {
                LoadValidRegions(Convert.ToInt32(ddlCastEthinicity.SelectedValue));
            }
        }

        public void GetAge(String date)
        {
            if (date.Length == 10)
            {
                NepaliToEnglishConversion convert = new NepaliToEnglishConversion();
                Dictionary<string, string> enDate = convert.nep_to_eng(date);
                //return enDate["year"].ToString() + "-" + enDate["month"].ToString() + "-" + enDate["date"].ToString();
                string dateAD = enDate["year"].ToString() + "/" + enDate["month"].ToString() + "/" + enDate["date"].ToString();


                String[] dateofBirths = dateAD.Split('/');

                int yy = DateTime.Now.Year;
                int mm = DateTime.Now.Month;
                int dd = DateTime.Now.Day;

                int yyyy = Convert.ToInt32(dateofBirths[0]);
                int mmmm = Convert.ToInt32(dateofBirths[1]);
                int dddd = Convert.ToInt32(dateofBirths[2]);

                int year = yy - yyyy;
                int month = mm - mmmm;
                int day = dd - dddd;

                if (day >= 30)
                    month++;

                if (month >= 12)
                    year++;

                txtAge.Text = year.ToString();


            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            GetAge(txtDateOfBirthBS.Text);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Training/TRNEvent/");
        }
    }
}
