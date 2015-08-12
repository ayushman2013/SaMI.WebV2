<%@ Page Title="View Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="View.aspx.cs" Inherits="SaMI.Web.Profile.View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="js/ClickScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="clearfix">
    </div>
    <div style="min-height: 64px;" class="page-header">
        <div data-spy="affix" data-offset-top="135" id="fix-page-header">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <asp:UpdatePanel ID="updatePanelButton" runat="server">
                            <ContentTemplate>
                                <h3>
                                    View Profile
                                    <button class="btn btn-default" onclick="$(location).attr('href','Index.aspx');">
                                        Cancel</button>
                                </h3>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container" style="">
        <div class="row">
            <div class="clearfix">
            </div>
            <div class="col-md-12">
                <!-- Nav tabs -->
                <ul class="nav nav-tabs">
                    <% Response.Write(SetPermission()); %>
                </ul>
                <!-- Tab panes -->
                <div class="tab-content" style="margin-top: 30px;">
                    <div class="tab-pane active" id="general">
                        <div>
                            <asp:UpdatePanel ID="updateProfile" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-6">
                                        <table width="100%" cellpadding="5" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    <label>
                                                        Profile Number :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSaMIProfileNumber" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Registration Date :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblRegistrationDate" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        District :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDistrict" runat="server" CssClass="form-control input-sm pull-left">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Gender :</label>
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rbMale" Text="Male" Checked="False" GroupName="gender" runat="server"
                                                        Enabled="false" />
                                                    <asp:RadioButton ID="rbFemale" Text="Female" Checked="False" GroupName="gender" runat="server"
                                                        Enabled="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Name :</label>
                                                </td>
                                                <td class="tablespan">
                                                    <span class="col-md-4">
                                                        <asp:Label ID="lblFirstName" runat="server" placeholder="First Name" CssClass="form-control input-sm"></asp:Label></span>
                                                    <span class="col-md-4">
                                                        <asp:Label ID="lblMiddleName" runat="server" placeholder="Middle Name" CssClass="form-control input-sm"></asp:Label></span>
                                                    <span class="col-md-4">
                                                        <asp:Label ID="lblLastName" runat="server" placeholder="Last Name" CssClass="form-control input-sm"></asp:Label></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Age :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAgeGroup" runat="server" CssClass="form-control input-sm">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Ethnicity/Caste :</label>
                                                </td>
                                                <td class="tablespan">
                                                  <asp:Label ID="lblEthnicity" runat="server" CssClass="form-control input-sm">
                                                        </asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rbValidRegions" runat="server" RepeatDirection="Horizontal" Enabled="false">
                                                </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Phone :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblVisitorPhone" runat="server" CssClass="form-control input-sm" placeholder="Phone"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFamilyMemberPhone" runat="server" CssClass="form-control input-sm"
                                                        placeholder="Family Phone"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Address :</label>
                                                </td>
                                                <td class="tablespan">
                                                    <span class="col-md-12 padding padding-first padding-last"><span class="col-md-4 padding padding-first">
                                                        <asp:Label ID="lblAddressDistrict" runat="server" CssClass="form-control input-sm">
                                                        </asp:Label>
                                                    </span><span class="col-md-3 padding">
                                                        <asp:Label ID="lblVDC" runat="server" CssClass="form-control input-sm">
                                                        </asp:Label>
                                                    </span><span class="col-md-2 padding">
                                                        <asp:Label ID="lblWard" runat="server" CssClass="form-control input-sm" placeholder="Ward"></asp:Label></span>
                                                        <span class="col-md-3 padding padding-last">
                                                            <asp:Label ID="lblAddress" runat="server" CssClass="form-control input-sm"></asp:Label></span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="col-md-6">
                                        <table width="100%" cellpadding="5" cellspacing="0" border="0">
                                            <tr>
                                                <td colspan="2">
                                                    <h4>
                                                        &raquo; Other Background</h4>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td>
                                                <label>
                                                    Family Head :</label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFamilyHeadName" runat="server" CssClass="form-control input-sm">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                         <tr>
                                            <td>
                                                <label>
                                                    Relation with Family Head :</label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFamilyHeadRelation" runat="server" CssClass="form-control input-sm">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Educational Status :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEducationalStatus" runat="server" CssClass="form-control input-sm pull-left">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Marital Status :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMaritalStatus" runat="server" CssClass="form-control input-sm pull-left">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <asp:Panel runat="server" ID="pnlIC">
                                                <tr>
                                                    <td>
                                                        <label>
                                                            How do you know about ICC?</label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblProfileICKnowledge" runat="server" CssClass="form-control input-sm pull-left">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Frequency Of Visito to ICC:</label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblFrequencyOfVisit" runat="server" CssClass="form-control input-sm pull-left">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Reason For Visiting to ICC?</label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblReasonOfVisit" runat="server" CssClass="form-control input-sm pull-left">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                            <tr>
                                                <td colspan="2">
                                                    <h4>
                                                        &raquo; Previous foreign employment experience</h4>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <h5>Do you have previous foreign employment experience? &nbsp;  
                                                    <asp:RadioButton ID="rbPrevFEExperienceYes" Text="Yes" runat="server" Enabled="false" GroupName="rbGroup" /> &nbsp;
                                                    <asp:RadioButton ID="rbPrevFEExperienceNo" Text="No" runat="server" Enabled="false" GroupName="rbGroup" />
                                                    </h5>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Which Country?</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCountry" runat="server" CssClass="form-control input-sm pull-left">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        What Type of Job?</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblJobType" runat="server" CssClass="form-control input-sm pull-left">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Stay Duration:</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblStayDuration" runat="server" CssClass="form-control input-sm pull-left">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="tab-pane" id="foreign">
                        <div>
                            <asp:UpdatePanel ID="updateForeignEmployment" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-6">
                                        <table width="100%" cellpadding="5" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    <label>
                                                        Decision :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDecisionStatus" runat="server" CssClass="form-control input-sm pull-left">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Passport :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPassportStatus" runat="server" CssClass="form-control input-sm pull-left">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Do You Already Have Offer:</label>
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rbJobOfferYes" Text="Yes" Checked="False" GroupName="JobOffer"
                                                        runat="server" Enabled="false" />
                                                    <asp:RadioButton ID="rbJobOfferNo" Text="No" Checked="False" GroupName="JobOffer"
                                                        runat="server" Enabled="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        If Offer, from Whom?</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblJobOfferSource" runat="server" CssClass="form-control input-sm pull-left">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        If Yes, What type of Work?</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblJobOfferedType" runat="server" CssClass="form-control input-sm pull-left">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <h4><asp:CheckBox ID="chkReferred" runat="server" Enabled="false" /> Refer to F-Skill</h4>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="2"> 
                                                    <h4><asp:CheckBox ID="chkReferredToCase" runat="server" Enabled="false" /> Refer to Free Legal Aid Clinic</h4> 
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="col-md-6">
                                        <table width="100%" cellpadding="5" cellspacing="0" border="0">
                                            <tr>
                                                <td colspan="2">
                                                    <h3>
                                                        Payments</h3>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Have you made any payments?:</label>
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rbMadePaymentYes" Text="Yes" Checked="False" GroupName="MadePayment"
                                                        runat="server" Enabled="false" />
                                                    <asp:RadioButton ID="rbMadePaymentNo" Text="No" Checked="False" GroupName="MadePayment"
                                                        runat="server" Enabled="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        How much did you paid?</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPaymentRange" runat="server" CssClass="form-control input-sm pull-left">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Did you received receipt?</label>
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rblPaymentReceiptYes" Text="Yes" Checked="False" GroupName="MadePaymentReceipt"
                                                        runat="server" Enabled="false" />
                                                    <asp:RadioButton ID="rblPaymentReceiptNo" Text="No" Checked="False" GroupName="MadePaymentReceipt"
                                                        runat="server" Enabled="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        How much was Payment Receipt Amount?</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPaymentRangeReceipt" runat="server" CssClass="form-control input-sm pull-left">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <label>
                                                        If no payment is being made to anybody yet for foreign employment,</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        How much amount being asked for?</label>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkNothingYet" Text="Nothing Yet" Checked="false" runat="server"
                                                        Enabled="false" />
                                                    <asp:Label ID="lblPaymentRangeAskedFor" runat="server" CssClass="form-control input-sm pull-left">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                           <%-- <tr>
                                                    <td colspan="2">
                                                        <h4>
                                                            <asp:CheckBox ID="chkPotentialMigrants" runat="server" Enabled="false" />
                                                            Potential and Non-potential migrants</h4>
                                                    </td>
                                                </tr>--%>
                                            
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    
                    <div class="tab-pane" id="skills">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="col-md-6">
                                    <table width="100%" border="0" cellpadding="5" cellspacing="0" class="table-tab">
                                        <tbody>
                                            <tr>
                                                <td colspan="2">
                                                    <label>
                                                        Employment & Income Details</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:CheckBox ID="chkUnEmployment" runat="server" Text="Unemployed" Enabled="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <label>
                                                        Income From :</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <span class="col-md-5">Self-employment Rs.<asp:Label ID="lblSelfEmploymentIncome"
                                                        runat="server" CssClass="form-control input-sm"></asp:Label>
                                                    </span><span class="col-md-5">Agriculture Rs.<asp:Label ID="lblAgricultureIncome"
                                                        runat="server" CssClass="form-control input-sm"></asp:Label>
                                                    </span><span class="col-md-5">Wages Rs.<asp:Label ID="lblWageIncome" runat="server"
                                                        CssClass="form-control input-sm"></asp:Label>
                                                    </span><span class="col-md-5">Others Rs.<asp:Label ID="lblOtherIncome" runat="server"
                                                        CssClass="form-control input-sm"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <label>
                                                        Yearly family income except yours</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <label>
                                                        Income From:</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <span class="col-md-4">Wage Rs.<asp:Label ID="lblFamilyWageIncome" runat="server"
                                                        CssClass="form-control input-sm"></asp:Label>
                                                    </span><span class="col-md-4">Agriculture Rs.<asp:Label ID="lblFamilyAgricultureIncome"
                                                        runat="server" CssClass="form-control input-sm"></asp:Label>
                                                    </span><span class="col-md-4">Salary Rs.<asp:Label ID="lblFamilySalaryIncome" runat="server"
                                                        CssClass="form-control input-sm"></asp:Label>
                                                    </span><span class="col-md-4">Foreign Rs.<asp:Label ID="lblFamilyForeignIncome" runat="server"
                                                        CssClass="form-control input-sm"></asp:Label>
                                                    </span><span class="col-md-4">Business Rs.<asp:Label ID="lblFamilyBusinessIncome"
                                                        runat="server" CssClass="form-control input-sm"></asp:Label>
                                                    </span><span class="col-md-4">Others Rs.<asp:Label ID="lblFamilyOtherIncome" runat="server"
                                                        CssClass="form-control input-sm"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Feeding duration from your own land agriculture products.</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFeedDurationTypeID" runat="server" CssClass="form-control input-sm">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="col-md-6">
                                    <table width="100%" border="0" cellpadding="5" cellspacing="0" class="table-tab">
                                        <tbody>
                                            <tr>
                                                <td colspan="2">
                                                    <label>
                                                        Details about training.</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Subject of training:</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTrainingSubject" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Training Location</label>
                                                </td>
                                                <td class="tablespan">
                                                    <span class="col-md-4">
                                                        <asp:Label ID="lblTrainingDistrict" runat="server" CssClass="form-control input-sm">
                                                        </asp:Label>
                                                    </span><span class="col-md-4">
                                                        <asp:Label ID="lblTrainingVDC" runat="server" CssClass="form-control input-sm">
                                                        </asp:Label>
                                                    </span><span class="col-md-4">
                                                        <asp:Label ID="lblTrainingWardNumber" runat="server" CssClass="form-control input-sm"
                                                            placeholder="Ward"></asp:Label></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Training Start Date</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTrainingStartDate" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <label>
                                                        Reason for interested in Training</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblTrainingReasonType" runat="server" CssClass="form-control input-sm">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <label>
                                                        How did get information about training?</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblKnowAboutTraining" runat="server" CssClass="form-control input-sm">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <label>
                                                        Have you took training before?</label>
                                                    <asp:RadioButton ID="rbHavePreviousTrainingYes" Text="Yes" Checked="False" GroupName="training-before"
                                                        runat="server" Enabled="false" />
                                                    <asp:RadioButton ID="rbHavePreviousTrainingNo" Text="No" Checked="False" GroupName="training-before"
                                                        runat="server" Enabled="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Training Name:</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPreTrainingName" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Training Year:</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPreTrainingYear" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Institute Name:</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPreTrainingInstituteName" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Training Duration:</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPreTrainingPeriod" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="tab-pane" id="tabemployment">
                        <div class="mid-col-12">
                            <table width="100%" border="0" cellpadding="5" cellspacing="0" class="table-tab">
                                <tbody>
                                    <tr>
                                        <td colspan="2">
                                            <h3>
                                                Employment
                                            </h3>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <asp:UpdatePanel ID="UpdatePanelEmployment" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvEmployment" runat="server" ShowHeaderWhenEmpty="True" OnRowCommand="gvEmployment_RowCommand"
                                        AutoGenerateColumns="False" ShowHeader="True" CssClass="table table-hover table-condensed">
                                        <Columns>
                                            <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" />
                                            <asp:BoundField DataField="CountryName" HeaderText="Country" />
                                            <asp:BoundField DataField="EmploymentStartDate" HeaderText="Start Date" />
                                            <asp:BoundField DataField="WorkTypeDesc" HeaderText="Work Type" />
                                            <asp:BoundField DataField="PaymentRangeDesc" HeaderText="Income Range" />
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="ViewLinkButton" runat="server" CommandArgument='<%# Eval("EmploymentID") %>'
                                                        CommandName="cmdView" Text="View" OnClientClick="$('#employment').modal('show');"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="tab-pane" id="servicesandfollowup">
                        <asp:UpdatePanel ID="updateService" runat="server">
                            <ContentTemplate>
                                <div class="col-md-6">
                                    <table width="100%" border="0" cellpadding="5" cellspacing="0">
                                        <tbody>
                                            <tr>
                                                <td colspan="2">
                                                    <label>
                                                        How many times has the visitor come to the center?</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblVisitTimes" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:200px">
                                                    <label>
                                                        Services provided :</label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblServiceProvided" runat="server" CssClass="form-control input-sm">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1">
                                                    <label>
                                                        Follow-up required by ICC :</label>
                                                </td>
                                                     <td colspan="1" align="left">
                                                      <asp:RadioButton ID="rdYes" Text="Yes" Checked="false" GroupName="follow_up" runat="server"
                                                        Enabled="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rbNo" Text="No" Checked="false" GroupName="follow_up" runat="server"
                                                        Enabled="false" />
                                                        <div style="padding-left: 10px;">
                                                        <asp:Label ID="lblFollowUp" runat="server" CssClass="form-control input-sm">
                                                        </asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <%-- <tr>
                                                <td colspan="2"><label>Recommendations provided by IC :</label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblICRecommendation" runat="server" CssClass="form-control input-sm">
                                                    </asp:Label>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td colspan="2">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading">
                                                            <label>
                                                                Recommendations provided by ICC :</label>
                                                        </div>
                                                        <div class="panel-body">
                                                            <asp:CheckBoxList ID="cblICRecommendation" Enabled="false" runat="server" RepeatLayout="Table"
                                                                RepeatDirection="Vertical" RepeatColumns="2">
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading">
                                                            <label>
                                                                During follow-up, clarification and additional information was provided :&nbsp;</label>
                                                            <asp:RadioButton ID="rbAdditionalInfoYes" Text="Yes" Checked="false" GroupName="additional_document"
                                                                runat="server" Enabled="false" />
                                                            <asp:RadioButton ID="rbAdditionalInfoNo" Text="No" Checked="false" GroupName="additional_document"
                                                                runat="server" Enabled="false" /></div>
                                                        <div class="panel-body">
                                                            <asp:CheckBoxList ID="cblAdditionalDocument" Enabled="false" runat="server" RepeatLayout="Table"
                                                                RepeatDirection="Vertical" RepeatColumns="2">
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Counselors' difficulties faced :</label>
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rbCounselorDifficultyYes" Text="Yes" Checked="false" GroupName="couselor_difficulty"
                                                        runat="server" Enabled="false" />
                                                    <asp:RadioButton ID="rbCounselorDifficultyNo" Text="No" Checked="false" GroupName="couselor_difficulty"
                                                        runat="server" Enabled="false" /><br />
                                                    <asp:Label ID="lblCounselorsDifficuties" runat="server" CssClass="form-control input-sm">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="col-md-6 headerDivider-left">
                                    <table width="100%" border="0" cellpadding="5" cellspacing="0" class="table-tab">
                                        <tbody>
                                            <tr>
                                                <td colspan="2">
                                                    <h3>
                                                        Follow-up</h3>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <asp:GridView ID="gvOtherFollowUp" runat="server" ShowHeaderWhenEmpty="True" OnRowCommand="gvOtherFollowUp_RowCommand"
                                        AutoGenerateColumns="False" ShowHeader="True" CssClass="table table-hover table-condensed">
                                        <Columns>
                                            <asp:BoundField DataField="FollowUpDate" HeaderText="Date" />
                                            <asp:BoundField DataField="FollowUpStatus" HeaderText="Status" />
                                            <asp:BoundField DataField="NonFollowUpReasonDesc" HeaderText="Reason" />
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="ViewLinkButton" runat="server" CommandArgument='<%# Eval("OtherFollowUpPerServiceID") %>'
                                                        CommandName="cmdView" Text="View" OnClientClick="$('#followupservices').modal('show');"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="tab-pane" id="casedocumentation">
                        <asp:UpdatePanel ID="updateCase" runat="server">
                            <ContentTemplate>
                                <div class="col-md-6 headerDivider-right">
                                    <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                        <tbody>
                                            <tr>
                                                <td colspan="2">
                                                    <label>
                                                        Type of Cases :</label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <asp:GridView ID="gvCases" runat="server" ShowHeaderWhenEmpty="True" OnRowCommand="gvCases_RowCommand"
                                        AutoGenerateColumns="False" ShowHeader="True" CssClass="table table-hover table-condensed">
                                        <Columns>
                                            <asp:BoundField DataField="CaseTypeDesc" HeaderText="Case Type" />
                                            <asp:BoundField DataField="Description" HeaderText="Description" />
                                            <asp:BoundField DataField="CaseStatusTypeDesc" HeaderText="Status" />
                                            <asp:BoundField DataField="Evidences" HeaderText="Evidences" />
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="ViewLinkButton" runat="server" CommandArgument='<%# Eval("CaseID") %>'
                                                        CommandName="cmdView" Text="View" OnClientClick="$('#casedocumentationothercases').modal('show');"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gvCaseFollowUp" runat="server" ShowHeaderWhenEmpty="True" OnRowCommand="gvCaseFollowUp_RowCommand"
                                        AutoGenerateColumns="False" ShowHeader="True" CssClass="table table-hover table-condensed">
                                        <Columns>
                                            <asp:BoundField DataField="FollowUpDate" HeaderText="Date" />
                                            <asp:BoundField DataField="CaseTypeDesc" HeaderText="Case Type" />
                                            <asp:BoundField DataField="Description" HeaderText="Description" />
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="ViewLinkButton" runat="server" CommandArgument='<%# Eval("CaseFollowUpID") %>'
                                                        CommandName="cmdView" Text="View" OnClientClick="$('#casefollowup').modal('show');"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <asp:Panel ID="pnlCaseReferral" runat="server">
                                    <div class="col-md-6">
                                        <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Referral :</label>
                                                    </td>
                                                    <td>
                                                        <span class="col-md-6"><span class="span-check-radio-1">
                                                            <asp:RadioButton ID="rbRefferToYes" Text="Yes" Checked="false" GroupName="Reffer_to"
                                                                runat="server" Enabled="false" /></span></span> <span class="col-md-6">
                                                                    <asp:Label ID="lblRefferToYes" runat="server" CssClass="form-control input-sm">
                                                                    </asp:Label>
                                                                </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <span class="col-md-6"><span class="span-check-radio-1">
                                                            <asp:RadioButton ID="rbRefferToNo" Text="No" Checked="false" GroupName="Reffer_to"
                                                                runat="server" Enabled="false" /></span></span> <span class="col-md-6">
                                                                    <asp:Label ID="lblRefferToNo" runat="server" CssClass="form-control input-sm">
                                                                    </asp:Label>
                                                                </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Date of referral:</label>
                                                    </td>
                                                    <td>
                                                        <span class="col-md-6">
                                                            <asp:Label ID="lblDateofRefferal" runat="server" CssClass="form-control input-sm"
                                                                placeholder="MM/DD/YYYY"></asp:Label></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Referral organization is updating you on the status</label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRefferalStatus" runat="server" CssClass="form-control input-sm">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Difficulties faced with this case:</label>
                                                    </td>
                                                    <td>
                                                        <span class="col-md-4">
                                                            <asp:RadioButton ID="rblDifficultyFaceYes" Text="Yes" Checked="false" GroupName="Difficulty_Faced"
                                                                runat="server" Enabled="false" />
                                                        </span><span class="col-md-4">
                                                            <asp:RadioButton ID="tblDifficultyFaceNo" Text="No" Checked="false" GroupName="Difficulty_Faced"
                                                                runat="server" Enabled="false" /></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <span class="col-md-6">
                                                            <asp:Label ID="lblDifficultyFaceReason" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <!--Phone Follow-Up -->
                    <div class="tab-pane" id="phonefollowup">
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-6">
                                        <table width="100%" border="0" cellpadding="5" cellspacing="0" class="table-tab">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <label>Name:</label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNameOfVisitor" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td>
                                                        <label>Address:</label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAddressOfVisitor" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td>
                                                        <label>ICC Visited Date:</label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblICCVisitedDate" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                </tbody>
                                            </table>
                                        <div class="clearfix"></div>
                                        <table width="100%" border="0" cellpadding="5" cellspacing="0" class="table-tab">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <label>Left for foreign employment:</label>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="rbtnLeftFEYes" Text="Yes" Enabled="false" Checked="false" GroupName="LeftFE" runat="server" />
                                                        <asp:RadioButton ID="rbtnLeftFENo" Text="No" Enabled="false" Checked="false" GroupName="LeftFE" runat="server" />
                                                    </td>
                                                </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    <div class="col-lg-12">
                                        <div class="col-sm-6 panel panel-default" id="panelLeftFEYes">
                                            <div class="panel-body">
                                                <table width="100%" border="0" cellpadding="5" cellspacing="0" class="table-tab">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <label>If migrated contract number of destination country:</label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblContractNumber" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>Country of Migration:</label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblMigratedCountry" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>Date of Migration:</label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblMigratedDate" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>Migrated after training:</label>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="rbtnMigratedAfterTrainingYes" Text="Yes" Enabled="false" Checked="false" GroupName="MigratedAfterTraining" runat="server" />
                                                                <asp:RadioButton ID="rbtnMigratedAfterTrainingNo" Text="No" Enabled="false" Checked="false" GroupName="MigratedAfterTraining" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>

                                        <div class="col-sm-6 panel panel-default" id="panelLeftFENo">
                                            <div class="panel-body">
                                                <table width="100%" border="0" cellpadding="5" cellspacing="0" class="table-tab">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <label>Current status of visitors:</label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCurrentStatusOption" runat="server" CssClass="form-control">
                                                                </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCurrentStatus" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>

                                        <div class="col-sm-6 panel panel-default" id="panelMigratedAfterTraining">
                                            <div class="panel-body">
                                                <table width="100%" border="0" cellpadding="5" cellspacing="0" class="table-tab">
                                                    <tbody>
                                                        <tr>
                                                            <td colspan="2">
                                                                <label>Name of Manpower or Agent:</label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="lblManpowerAgent" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>
                                                                    Amount paid for foreign employment:</label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAmountPaidforFE" runat="server" CssClass="form-control input-sm"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="1">
                                                                <label>
                                                                    Source of investment:</label>
                                                            </td>
                                                            <td colspan="3" align="left">
                                                                <asp:CheckBoxList ID="chkSourceOfInvestment" runat="server" Enabled="false" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="Self">Self</asp:ListItem>
                                                                    <asp:ListItem Value="Loan">Loan</asp:ListItem>
                                                                    <asp:ListItem Value="Sale Property">Sale Property</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>Receipt received from manpower:</label>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="rbtnReceiptFromManpowerYes" Text="Yes" Enabled="false" Checked="false" GroupName="ReceiptFromManpower" runat="server" />
                                                                <asp:RadioButton ID="rbtnReceiptFromManpowerNo" Text="No" Enabled="false" Checked="false" GroupName="ReceiptFromManpower" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>Left document before departure:</label>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="rbtnLeftDocumentYes" Text="Yes" Enabled="false" Checked="false" GroupName="LeftDocument" runat="server" />
                                                                <asp:RadioButton ID="rbtnLeftDocumentNo" Text="No" Enabled="false" Checked="false" GroupName="LeftDocument" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>Same work as per agreement: </label>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="rbtnWorkAggreementYes" Text="Yes" Enabled="false" Checked="false" GroupName="WorkAggreement" runat="server" />
                                                                <asp:RadioButton ID="rbtnWorkAggreementNo" Text="No" Enabled="false" Checked="false" GroupName="WorkAggreement" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>Same salary/wage as per agreement: </label>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="rbtnSalaryAgreementYes" Text="Yes" Enabled="false" Checked="false" GroupName="SalaryAggreement" runat="server" />
                                                                <asp:RadioButton ID="rbtnSalaryAgreementNo" Text="No" Enabled="false" Checked="false" GroupName="SalaryAggreement" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <asp:HiddenField ID="hfPhoneFollowUpId" runat="server" Value="" />

                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-6">
                                        <table width="100%" border="0" cellpadding="5" cellspacing="0" class="table-tab">
                                            <tbody>
                                                <tr>
                                                    <td colspan="2">
                                                        <label>Additional Information found during follow up:</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:label ID="lblAdditionalInfo" runat="server" CssClass="form-control input-sm" TextMode="MultiLine"></asp:label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <label>Recommendations:</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblRecommendations" runat="server" CssClass="form-control input-sm" TextMode="MultiLine"></asp:Label>
                                                    </td>
                                                </tr>
                                                
                                            </tbody>
                                        </table>
                                    </div>
                                    </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <div class="col-lg-12">
                                        <h3>Phone Follow-Up
                                        </h3>
                                         <asp:UpdatePanel ID="updatepanel6" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvPhoneFollowUp" runat="server" ShowHeader="true" AutoGenerateColumns="false"
                                                        ViewStateMode="Enabled" ShowHeaderWhenEmpty="true"
                                                        CssClass="table table-hover table-condensed">
                                                        <Columns>
                                                            <asp:BoundField DataField="FollowUpDate" HeaderText="Follow Up Date" />
                                                            <asp:BoundField DataField="InformantsName" HeaderText="Informant's Name" />
                                                            <asp:BoundField DataField="MigrantRelation" HeaderText="Relation with Migrant" />
                                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        <asp:HiddenField ID="hfPhoneFollowUpInfoID" runat="server" Value="" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Other Migrants Popup Modal-->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="myModalLabel">
                        Other Migrants</h4>
                </div>
                <asp:UpdatePanel ID="updateOtherMigrant" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="col-md-12">
                                <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <label>
                                                    Family Members</label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFamilyMember" runat="server" CssClass="form-control input-sm">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Country</label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFamilyMemberCountry" runat="server" CssClass="form-control input-sm">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Where Visitor want to go (Same Country)?</label>
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbSameCountryYes" Text="Yes" Checked="False" GroupName="samecountry"
                                                    runat="server" Enabled="false" />
                                                <asp:RadioButton ID="rbSameCountryNo" Text="No" Checked="False" GroupName="samecountry"
                                                    runat="server" Enabled="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Sending Money?</label>
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbSendMoneyYes" Text="Yes" Checked="False" GroupName="send-money"
                                                    runat="server" Enabled="false" />
                                                <asp:RadioButton ID="rbSendMoneyNo" Text="No" Checked="False" GroupName="send-money"
                                                    runat="server" Enabled="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMoneyRange" runat="server" CssClass="form-control input-sm">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        <label>
                                                            Documents Left?&nbsp;</label>
                                                        <asp:RadioButton ID="rbDocumentLeftYes" Text="Yes" Checked="False" GroupName="document-left"
                                                            runat="server" Enabled="false" />
                                                        <asp:RadioButton ID="rbDocumentLeftNo" Text="No" Checked="False" GroupName="document-left"
                                                            runat="server" Enabled="false" />
                                                    </div>
                                                    <asp:CheckBoxList ID="cblDocumentsBehind" runat="server" RepeatColumns="3">
                                                    </asp:CheckBoxList>
                                                    <div class="panel-body">
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        <label>
                                                            Does she/he face any problems?&nbsp;</label>
                                                        <asp:RadioButton ID="rbProblemFacedYes" Text="Yes" Checked="False" GroupName="problem-faced"
                                                            runat="server" Enabled="false" />
                                                        <asp:RadioButton ID="rbProblemFacedNo" Text="No" Checked="False" GroupName="problem-faced"
                                                            runat="server" Enabled="false" />
                                                    </div>
                                                    <asp:CheckBoxList ID="cblProblemType" runat="server" RepeatColumns="2" Enabled="false">
                                                    </asp:CheckBoxList>
                                                    <div class="panel-body">
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                Close</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Followup Popup Modal-->
    <div class="modal fade" id="followupservices" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H1">
                        Follow-up</h4>
                </div>
                <asp:UpdatePanel ID="updateOtherFollowUp" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="col-md-12">
                                <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <label>
                                                    Date :</label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFollowUpDate" runat="server" CssClass="form-control input-sm"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    i.Follow-up was not possible, because</label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNonFollowup" runat="server" CssClass="form-control input-sm">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Followup was possible :</label>
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbComplied" Text="Compiled" Checked="false" GroupName="followup_possible"
                                                    runat="server" Enabled="false" /><br />
                                                <asp:RadioButton ID="rbCompliedPartly" Text="Complied Partly" Checked="false" GroupName="followup_possible"
                                                    runat="server" Enabled="false" /><br />
                                                <span style="margin-left: 25px;"></span>
                                                <asp:RadioButton ID="rbDidNotComply" Text="Did not comply" Checked="false" GroupName="didnot_comply"
                                                    runat="server" Enabled="false" /><br />
                                                <span style="margin-left: 25px;"></span>
                                                <asp:RadioButton ID="rbReasonForNonCompliance" Text="Reasons for non-compliance"
                                                    Checked="false" GroupName="didnot_comply" runat="server" Enabled="false" /><br />
                                                <span style="margin-left: 50px;"></span>
                                                <asp:RadioButton ID="rbReasonRecommendation" Text="Didn't understand the Recommendation"
                                                    Checked="false" GroupName="reason" runat="server" Enabled="false" /><br />
                                                <span style="margin-left: 50px;"></span>
                                                <asp:RadioButton ID="rbWasTooDifficult" Text="Was too dificult to do" Checked="false"
                                                    GroupName="reason" runat="server" Enabled="false" /><br />
                                                <span style="margin-left: 75px;"></span>
                                                <asp:RadioButton ID="rbReasonReceipt" Text="Receipt could not be obtain" Checked="false"
                                                    GroupName="reason2" runat="server" Enabled="false" /><br />
                                                <span style="margin-left: 75px;"></span>
                                                <asp:RadioButton ID="rbOther" Text="Other" Checked="false" GroupName="reason2" runat="server"
                                                    Enabled="false" /><br />
                                                <span style="margin-left: 50px;"></span>
                                                <asp:RadioButton ID="rbReasonFamilyMember" Text="Family members don't know" Checked="false"
                                                    GroupName="reason" runat="server" Enabled="false" /><br />
                                                <asp:Label ID="lblDidNoComplyReason" runat="server" CssClass="form-control input-sm"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                Close</button>
                        </div>
                        <asp:HiddenField ID="hfOtherFollowUpPerServiceID" Value="" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- Case documentation -->
    <div class="modal fade" id="casedocumentationothercases" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H2">
                        Case</h4>
                </div>
                <asp:UpdatePanel ID="updateOtherCase" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                <tbody>
                                    <tr>
                                        <td>
                                            <label>
                                                Case Type :</label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTypeOfCase" runat="server" CssClass="form-control input-sm">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Case Number :</label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCaseNumber" runat="server" CssClass="form-control input-sm"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Name of opponent :</label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNameOfOpponent" runat="server" CssClass="form-control input-sm"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Problem faced :</label>
                                        </td>
                                        <td>
                                            <span class="col-md-6">
                                                <asp:Label ID="lblCaseDesc" TextMode="MultiLine" runat="server" CssClass="form-control input-sm"
                                                    Rows="4" Style="word-wrap: break-word; resize: vertical;" placeholder="Description"></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Case Registered Date :</label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCaseRegisteredDate" runat="server" CssClass="form-control input-sm"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Partner :</label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblStackeHolder" runat="server" CssClass="form-control input-sm">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Registered At:</label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCaseRegistrar" runat="server" CssClass="form-control input-sm">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Responsible staff :</label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblResponsibleStaff" runat="server" CssClass="form-control input-sm"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Status :</label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCaseStatusType" runat="server" CssClass="form-control input-sm">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <asp:Panel ID="pnlCaseOutput" runat="server" Visible="true">
                                        <tr>
                                            <td>
                                                <label>
                                                    Compensated?:</label>
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbCompensationYes" Text="Yes" Checked="false" GroupName="compensation"
                                                    runat="server" Enabled="false" />
                                                <asp:RadioButton ID="rbCompensationNo" Text="No" Checked="false" GroupName="compensation"
                                                    runat="server" Enabled="false" />
                                                Compensation Amount:
                                                <asp:Label ID="lblCompensationAmount" runat="server" CssClass="form-control input-sm"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Output Details:</label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblOutputDetails" runat="server" CssClass="form-control input-sm"
                                                    TextMode="MultiLine"></asp:Label>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td colspan="2">
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <label>
                                                        Evidences?&nbsp;</label>
                                                </div>
                                                <asp:CheckBoxList ID="cblEvidenceTypes" runat="server" RepeatColumns="3" Enabled="false">
                                                </asp:CheckBoxList>
                                                <div class="panel-body">
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                Close</button>
                        </div>
                        <asp:HiddenField ID="hfCaseID" Value="" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- Case Documentation--Followup-->
    <div class="modal fade" id="casefollowup" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H3">
                        Case Follow-up</h4>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                <tbody>
                                    <tr>
                                        <td>
                                            <label>
                                                Date :</label>
                                        </td>
                                        <td>
                                            <span class="col-md-6">
                                                <asp:Label ID="lblCaseFollowUpDate" runat="server" CssClass="form-control input-sm"></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Case Type :</label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFollowupCaseType" runat="server" CssClass="form-control input-sm">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Description :</label>
                                        </td>
                                        <td>
                                            <span class="col-md-6">
                                                <asp:Label ID="lblCaseFollowUpDesc" TextMode="MultiLine" runat="server" CssClass="form-control input-sm"
                                                    Rows="4" Style="word-wrap: break-word; resize: vertical;" placeholder="Description"></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                Close</button>
                        </div>
                        <asp:HiddenField ID="hfCaseFollowUpID" Value="" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- Employment--->
    <div class="modal fade" id="employment" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H5">
                        Employment</h4>
                </div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="col-md-12">
                                <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <label>
                                                    Company Name:</label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEmploymentCompanyName" runat="server" CssClass="form-control input-sm"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Country:</label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEmploymentCountry" runat="server" CssClass="form-control input-sm">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Employment Start Date:</label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEmploymentStartDate" runat="server" CssClass="form-control input-sm"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Type of work:</label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEmploymentWorkType" runat="server" CssClass="form-control input-sm">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Income Range:</label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEmploymentIncomeRange" runat="server" CssClass="form-control input-sm">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                Close</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);

        function BeginRequestHandler(sender, args) {

        }

        function EndRequestHandler(sender, args) {

        }
    </script>
</asp:Content>
