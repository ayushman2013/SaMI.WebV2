<%@ Page Title="" Language="C#" MasterPageFile="~/Trainings.Master" AutoEventWireup="true"
    CodeBehind="View.aspx.cs" Inherits="SaMI.Web.Training.View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TrainingBody" runat="server">
    <div class="col-md-12">
        <h3>
            View Trainee Profile
        </h3>
    </div>
    <div class="col-md-6">
    </div>
    <div class="col-md-12">
        <!--Personal Information-->
        <div class="col-md-4 padding padding-first">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Personal Information</h3>
                </div>
                <div class="panel-body">
                    <table>
                        <tr>
                            <td>
                                <label>
                                    First Name</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFirstName" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Last Name</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLastName" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Gender</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGender" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Marital Status</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMaritalStatus" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Date of Birth (AD)</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDateOfBirthAD" runat="server" ReadOnly="true" CssClass="date_input form-control input-sm"
                                    placeholder="MM/DD/YYYY"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Date of Birth (BS)</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDateOfBirthBS" runat="server" ReadOnly="true" CssClass="date_input form-control input-sm"
                                    placeholder="MM/DD/YYYY"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Age</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAge" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Qualification</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtQualification" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Cast/Ethnicity</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEthnicity" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbValidRegions" runat="server" RepeatDirection="Horizontal"
                                    Enabled="false">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <!--Contact Information-->
        <div class="col-md-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Contact Information</h3>
                </div>
                <div class="panel-body">
                    <table>
                        <tr>
                            <td>
                                <label>
                                    District</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDistrict" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    VDC</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtVDC" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Tole</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTol" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Ward No</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtWardNumber" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Phone Number
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhoneNumberHouse" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Mobile</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobile" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Father's Name</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFathersName" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Contact Number</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFathersContactNumber" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Contact Person</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactPerson" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Telephone Number</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactPersonContactTelephone" runat="server" ReadOnly="true"
                                    CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <!--Other Information-->
        <div class="col-md-4 padding padding-last">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Other Information</h3>
                </div>
                <div class="panel-body">
                    <table>
                        <tr>
                            <td>
                                <label>
                                    Citizenship No</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCitizenshipNumber" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Citizenship Issued Distict</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCitizenshipIssuedDistict" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Passport No</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassportNumber" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Special Case</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSpecialCase" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                <asp:HiddenField ID="hfSpecialCase" runat="server"></asp:HiddenField>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    How did get information about training?</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtInformationSource" runat="server" ReadOnly="true" CssClass="form-control input-sm">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Referred By</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtReferredBy" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-12">
        <!--Employment & Income Details-->
        <div class="col-md-4 padding padding-first">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Employment & Income Details:</h3>
                </div>
                <div class="panel-body">
                    <table>
                        <tr>
                            <td>
                                <label>
                                    Family Member</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFamilyMember" runat="server" ReadOnly="true" CssClass="form-control input-sm">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="chkUnEmployment" runat="server" Text="Unemployed" ReadOnly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Self-employment Rs.</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSelfEmploymentIncome" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Agriculture Rs.</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAgricultureIncome" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Wages Rs.</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtWageIncome" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Foreign Employment Rs.</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtForeignIncome" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Others Rs.</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOtherIncome" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <label>
                                    Feeding duration from your own land agriculture products.</label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="txtFeedDurationType" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <!--Current Abroad Information-->
        <div class="col-md-4 padding">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Abroad Information</h3>
                </div>
                <div class="panel-body">
                    <table>
                        <tr>
                            <td colspan="2">
                                <label>
                                    Are you going abroad?
                                </label>
                                <asp:RadioButton ID="rdoAbroadYes" Text="Yes" ReadOnly="true" GroupName="AbroadRecord"
                                    runat="server" />
                                <asp:RadioButton ID="rdoAbroadNo" Text="No" ReadOnly="true" GroupName="AbroadRecord"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Country:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCountry" runat="server" ReadOnly="true" CssClass="form-control input-sm">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Departure Date:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDepartureDate" runat="server" ReadOnly="true" CssClass="date_input form-control input-sm"
                                    placeholder="MM/DD/YYYY"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Recruitment Agency:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRecruitmentAgency" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Name of Company:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOrganization" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Employment Type:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmploymentType" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Employment Status:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmploymentStatus" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    EmploymentPeriod:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmploymentPeriod" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                                    <td>
                                        <label>
                                            Monthly Salary</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Nepali Currency*</label>
                                    </td>
                                   <td>
                                        <asp:TextBox ID="txtMonthlySalary" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                 <td>
                                 <label>
                                        Foreign Currency</label>
                                    </td>
                                    
                                    <td>
                                        <asp:TextBox ID="txtForeignCurrency" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                        <tr>
                            <td>
                                <label>
                                    Return Date:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtReturnDate" runat="server" ReadOnly="true" CssClass="date_input form-control input-sm"
                                    placeholder="MM/DD/YYYY"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Check List:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTraineeCheckList" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                <br />
                                <asp:HiddenField ID="hfTraineeCheckList" runat="server"></asp:HiddenField>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <!--Previous Training Information-->
        <div class="col-md-4 padding padding-last" style="margin-top:-80px">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Previous Training Information</h3>
                </div>
                <div class="panel-body">
                    <table>
                        <tr>
                            <td colspan="2">
                                <label>
                                    Have you took training before?</label>
                                <asp:RadioButton ID="rbHavePreviousTrainingYes" Text="Yes" GroupName="training-before"
                                    runat="server" />
                                <asp:RadioButton ID="rbHavePreviousTrainingNo" Text="No" GroupName="training-before"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Training Name:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTrainingName" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Training Year:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTrainingYear" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Institute Name:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTrainingInstituteName" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Training Duration:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTrainingDuration" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>

          <!-- Are You Going Abroad? -->
        <div class="col-md-4 padding padding-last">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Have the trainee gone Overseas previously?
                         <asp:RadioButton ID="rbCurrentCountryYes" Text="Yes" GroupName="training-before" ReadOnly="true"
                                    runat="server" />
                                <asp:RadioButton ID="rbCurrentCountryNo" Text="No"  GroupName="training-before" ReadOnly="true"
                                    runat="server" />
                        
                        </h3>
                </div>
                <div class="panel-body">
                    <table>
                        <tr>
                            <td>
                                <label>
                                    Which Country:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtWhichCountry" runat="server" CssClass="form-control input-sm" ReadOnly="true">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Working Period</label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            </tr>
                        <tr>
                            <td>
                                <label>
                                    Years:</label>
                            </td>

                            <td>
                               <asp:TextBox ID="txtWorkingYears" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Months:</label>
                            </td>

                            <td>
                               <asp:TextBox ID="txtWorkingMonths" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Occupation:</label>
                            </td>

                            <td>
                               <asp:TextBox ID="txtOccupation" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Monthly Salary:</label>
                            </td>

                            <td>
                               <asp:TextBox ID="txtPreviousMonthlySalary" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    </label>
                            </td>

                            <td>
                               <asp:TextBox ID="txtPreviousReturnDate" runat="server" Visible="false" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <!-- Are You Going Abroad? -->

        <div class="col-md-4 padding padding-last">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Photo</h3>
                </div>
                <div class="panel-body">
                    <table>
                        <tr>
                            <td>
                                <label>
                                    Photo:</label>
                            </td>
                            <td>
                                <asp:Image ID="ImgPrv" Style="margin-top: -18px;" Height="80px" Width="80px" runat="server" /><br />
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
