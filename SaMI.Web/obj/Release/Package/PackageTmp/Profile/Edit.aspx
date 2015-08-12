<%@ Page Title="Edit Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Edit.aspx.cs" Inherits="SaMI.Web.Profile.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="js/ClickScript.js"></script>
    <script type="text/javascript">
        var pageUrl = '<%=ResolveUrl("Edit.aspx")%>';
        PFEClickScript();
        PhoneFollowUpClickScript();
        ResetClick();
        //Func();
    </script>
   
    <script type="text/javascript" src="js/CasteDropDown.js"></script>
    <script type="text/javascript" src="js/ValidateAdd.js"></script>
    <script type="text/javascript" src="js/ValidateEdit.js"></script>
    <script type="text/javascript" src="js/JScriptEdit.js"></script>

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
                                <h3>Edit Profile
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-default"
                                        OnClientClick="return SaveProfile();" />
                                    <asp:Button ID="btnSaveForeignEmployment" CssClass="btn btn-default" runat="server"
                                        Text="Save" OnClick="btnSaveForeignEmployment_Click" OnClientClick="return SaveForeignEmployment();" />
                                    <asp:Button ID="btnSaveServices" OnClientClick="return SaveServices();" CssClass="btn btn-default"
                                        runat="server" Text="Save" OnClick="btnSaveServices_Click" />
                                    <asp:Button ID="btnSavePhoneFollowUp" runat="server" Text="Save" OnClick="btnSavePhoneFollowUp_Click" 
                                        CssClass="btn btn-default" OnClientClick="return SavePhoneFollowUp();"/>
                                    <button class="btn btn-default" onclick="$(location).attr('href','Index.aspx');return false;">
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
                        <asp:Panel ID="pnlGeneral" runat="server">
                            <div>
                                <asp:UpdatePanel ID="updateProfile" runat="server">
                                    <ContentTemplate>
                                        <div class="col-md-6">
                                            <table width="100%" cellpadding="5" cellspacing="0" border="0">
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Profile Number:</label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSaMIProfileNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Registration Date:</label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRegistrationDate" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            District:</label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control input-sm pull-left"
                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Enabled="false">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Gender:</label>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="rbMale" Text="Male" Checked="False" GroupName="gender" runat="server" />
                                                        <asp:RadioButton ID="rbFemale" Text="Female" Checked="False" GroupName="gender" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Name:</label>
                                                    </td>
                                                    <td class="tablespan">
                                                        <span class="col-md-4">
                                                            <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name" CssClass="form-control input-sm"></asp:TextBox></span>
                                                        <span class="col-md-4">
                                                            <asp:TextBox ID="txtMiddleName" runat="server" placeholder="Middle Name" CssClass="form-control input-sm"></asp:TextBox></span>
                                                        <span class="col-md-4">
                                                            <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name" CssClass="form-control input-sm"></asp:TextBox></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Age:</label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlAgeGroup" runat="server" CssClass="form-control input-sm">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Ethnicity/Caste:</label>
                                                    </td>
                                                    <td class="tablespan">
                                                        <span class="col-md-4">
                                                            <asp:DropDownList ID="ddlEthnicity" runat="server" CssClass="form-control input-sm"
                                                                AutoPostBack="true" OnSelectedIndexChanged="ddlEthnicity_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rbValidRegions" runat="server" RepeatDirection="Horizontal">
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Phone:</label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtVisitorPhone" runat="server" CssClass="form-control input-sm"
                                                            placeholder="Phone"></asp:TextBox>
                                                    </td>
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFamilyMemberPhone" runat="server" CssClass="form-control input-sm"
                                                                placeholder="Family Phone"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label>
                                                                Address:</label>
                                                        </td>
                                                        <td class="tablespan">
                                                            <span class="col-md-12 padding padding-first padding-last"><span class="col-md-4 padding padding-first">
                                                                <asp:DropDownList ID="ddlAddressDistrict" runat="server" CssClass="form-control input-sm"
                                                                    placeholder="[District]" AutoPostBack="True" OnSelectedIndexChanged="ddlAddressDistrict_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </span><span class="col-md-3 padding">
                                                                <asp:DropDownList ID="ddlVDC" runat="server" CssClass="form-control input-sm">
                                                                    <asp:ListItem Text="[VDC]" Value="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </span><span class="col-md-2 padding">
                                                                <asp:TextBox ID="txtWard" runat="server" CssClass="form-control input-sm" placeholder="Ward"></asp:TextBox></span>
                                                                <span class="col-md-3 padding padding-last">
                                                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control input-sm" placeholder="Details"></asp:TextBox></span>
                                                        </td>
                                                    </tr>
                                            </table>
                                        </div>
                                        <div class="col-md-6">
                                            <table width="100%" cellpadding="5" cellspacing="0" border="0">
                                                <tr>
                                                    <td colspan="2">
                                                        <h4>&raquo; Other Background</h4>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Family Head :</label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFamilyHeadName" runat="server" CssClass="form-control input-sm">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <tr>
                                                        <td>
                                                            <label>
                                                                Relation with Family Head :</label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFamilyHeadRelation" runat="server" CssClass="form-control input-sm">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label>
                                                                Educational Status:</label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlEducationalStatus" runat="server" CssClass="form-control input-sm pull-left">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label>
                                                                Marital Status:</label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="form-control input-sm pull-left">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <asp:Panel runat="server" ID="pnlIC">
                                                        <tr>
                                                            <td>
                                                                <label>
                                                                    How do you know about ICC?</label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlICKnowledge" runat="server" CssClass="form-control input-sm pull-left">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>
                                                                    Frequency Of Visit to ICC:</label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlFrequencyOfVisit" runat="server" CssClass="form-control input-sm pull-left">
                                                                    <%--<asp:ListItem Value="1" Text="Once"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="More than once"></asp:ListItem>--%>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>
                                                                    Reason For Visiting to ICC?</label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlReasonOfVisit" runat="server" CssClass="form-control input-sm pull-left">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <h4>&raquo; Previous foreign employment experience</h4>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <h5>Do you have previous foreign employment experience? &nbsp;
                                                                <asp:RadioButton ID="rbPrevFEExperienceYes" Text="Yes" runat="server" GroupName="rbGroup" />
                                                                    &nbsp;
                                                                <asp:RadioButton ID="rbPrevFEExperienceNo" Text="No" runat="server" GroupName="rbGroup"
                                                                    OnCheckedChanged="rbPrevFEExperienceNo_CheckedChanged" />
                                                                    <%--&nbsp;
                                                                <button class="btn btn-default" data-toggle="modal" data-target="#PreviousFEExperience">
                                                                    Add</button>--%>
                                                                </h5>
                                                            </td>
                                                        </tr>
                                                    </asp:Panel>
                                            </table>
                                            <asp:UpdatePanel ID="updatepanel" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvPFE" runat="server" ShowHeader="true" AutoGenerateColumns="false"
                                                        ViewStateMode="Enabled" ShowHeaderWhenEmpty="true" OnRowCommand="gvPFE_RowCommand"
                                                        CssClass="table table-hover table-condensed">
                                                        <Columns>
                                                            <asp:BoundField DataField="CountryName" HeaderText="Country" />
                                                            <asp:BoundField DataField="JobOfferedTypeDesc" HeaderText="JobOffered Type" />
                                                            <asp:BoundField DataField="StayDuration" HeaderText="StayDuration" />
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="EditLinkButton" runat="server" CommandArgument='<%# Eval("ForeignEmploymentExperienceID") %>'
                                                                        CommandName="cmdEdit" Text="Edit" OnClientClick="$('#PreviousFEExperience').modal('show');"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandArgument='<%# Eval("ForeignEmploymentExperienceID") %>'
                                                                        CommandName="cmdDelete" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:Label ID="lblPreviousID" runat="server" Visible="false"></asp:Label>
                                            <asp:HiddenField ID="hfForeignEmploymentExperienceID" runat="server" Value="" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="tab-pane" id="foreign">
                        <asp:Panel ID="pnlForeign" runat="server">
                            <div>
                                <asp:UpdatePanel ID="updateForeignEmployment" runat="server">
                                    <ContentTemplate>
                                        <div class="col-md-6">
                                            <table width="100%" cellpadding="5" cellspacing="0" border="0">
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Country willing to go:</label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlWillingCountry" runat="server" CssClass="form-control input-sm pull-left">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Decision:</label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDecisionStatus" runat="server" CssClass="form-control input-sm pull-left">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Passport:</label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPassportStatus" runat="server" CssClass="form-control input-sm pull-left">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Do You Already Have Offer:</label>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="rbJobOfferYes" Text="Yes" Checked="False" GroupName="JobOffer"
                                                            runat="server" />
                                                        <asp:RadioButton ID="rbJobOfferNo" Text="No" Checked="False" GroupName="JobOffer"
                                                            runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            If Offer,from Whom?</label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlJobOfferSource" runat="server" CssClass="form-control input-sm pull-left">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            If Yes, What type of Work?</label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlJobOfferedType" runat="server" CssClass="form-control input-sm pull-left">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <h4>
                                                            <asp:CheckBox ID="chkReferred" runat="server" />
                                                            Refer to F-Skill</h4>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <h4>
                                                            <asp:CheckBox ID="chkReferredToCase" runat="server" />
                                                            Refer to Case Support</h4>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="col-md-6">
                                            <table width="100%" cellpadding="5" cellspacing="0" border="0" style="margin-top: -26px">
                                                <tr>
                                                    <td colspan="2">
                                                        <h3>Payments</h3>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Have you made any payments?</label>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="rbMadePaymentYes" Text="Yes" Checked="False" GroupName="MadePayment"
                                                            runat="server" />
                                                        <asp:RadioButton ID="rbMadePaymentNo" Text="No" Checked="False" GroupName="MadePayment"
                                                            runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            How much did you paid?</label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMadePaymentAmount" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Did you received receipt?</label>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="rblPaymentReceiptYes" Text="Yes" Checked="False" GroupName="MadePaymentReceipt"
                                                            runat="server" />
                                                        <asp:RadioButton ID="rblPaymentReceiptNo" Text="No" Checked="False" GroupName="MadePaymentReceipt"
                                                            runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            How much was Payment Receipt Amount?</label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtReceiptPaymentAmount" runat="server" CssClass="form-control input-sm"></asp:TextBox>
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
                                                        <asp:CheckBox ID="chkNothingYet" Text="Nothing Yet" Checked="false" runat="server" />
                                                        <asp:TextBox ID="txtAskedPaymentAmount" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td colspan="2">
                                                        <h4>
                                                            <asp:CheckBox ID="chkPotentialMigrants" runat="server" />
                                                            Potential and Non-potential migrants</h4>
                                                    </td>
                                                </tr>--%>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="tab-pane" id="servicesandfollowup">
                        <asp:Panel ID="pnlServices" runat="server">
                            <asp:UpdatePanel ID="updateService" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-6">
                                        <table width="100%" border="0" cellpadding="5" cellspacing="0" class="table-tab">
                                            <tbody>
                                                <tr>
                                                    <td colspan="2">
                                                        <label>
                                                            How many times has the visitor come to the center?</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtVisitTimes" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Services provided:</label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlServiceProvided" runat="server" CssClass="form-control input-sm">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="1">
                                                        <label>
                                                            Follow-up required by ICC:</label>
                                                    </td>
                                                    <td colspan="1" align="left">
                                                        <asp:RadioButton ID="rdYes" Text="Yes" Checked="false" GroupName="follow_up" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="rbNo" Text="No" Checked="false" GroupName="follow_up" runat="server" />
                                                        <div style="padding-left: 10px;">
                                                            <asp:TextBox ID="txtFollowUp" runat="server" CssClass="form-control input-sm">
                                                            </asp:TextBox>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div class="panel panel-default">
                                                            <div class="panel-heading">
                                                                <label>
                                                                    Suggestion provided by ICC:</label>
                                                            </div>
                                                            <div class="panel-body">
                                                                <asp:CheckBoxList ID="cblICRecommendation" runat="server" RepeatLayout="Table" RepeatDirection="Vertical"
                                                                    RepeatColumns="2">
                                                                </asp:CheckBoxList>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <%-- <tr>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlICRecommendation" runat="server" CssClass="form-control input-sm">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Further Follow Up Required:</label>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="rbFurtherFollowUpYes" Text="Yes" Checked="false" GroupName="further_followup"
                                                            runat="server" />
                                                        <asp:DropDownList ID="ddlFurtherFollowUp" runat="server" CssClass="form-control input-sm">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:RadioButton ID="rbFurtherFollowUpNo" Text="No" Checked="false" GroupName="further_followup"
                                                                runat="server" />
                                                        </td>
                                                    </tr>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div class="panel panel-default">
                                                            <div class="panel-heading">
                                                                <label>
                                                                    During follow-up, clarification and additional information was provided:&nbsp;</label>
                                                                <asp:RadioButton ID="rbAdditionalInfoYes" Text="Yes" Checked="false" GroupName="additional_document"
                                                                    runat="server" />
                                                                <asp:RadioButton ID="rbAdditionalInfoNo" Text="No" Checked="false" GroupName="additional_document"
                                                                    runat="server" />
                                                            </div>
                                                            <div class="panel-body">
                                                                <asp:CheckBoxList ID="cblAdditionalDocument" runat="server" RepeatLayout="Table"
                                                                    RepeatDirection="Vertical" RepeatColumns="2">
                                                                </asp:CheckBoxList>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                
                                                <asp:HiddenField ID="hfServiceProvidedPerSaMIID" runat="server" Value="" />
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="col-md-6 headerDivider-left">
                                        <table width="100%" border="0" cellpadding="5" cellspacing="0" class="table-tab">
                                            <tbody>
                                                <tr>
                                                    <td colspan="2">
                                                        <h3>Follow-up</h3>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <button onclick="CheckService();" class="btn btn-default">
                                                            Add Follow-up</button>
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
                                                        <asp:LinkButton ID="EditLinkButton" runat="server" CommandArgument='<%# Eval("OtherFollowUpPerServiceID") %>'
                                                            CommandName="cmdEdit" Text="Edit" OnClientClick="$('#followupservices').modal('show');"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandArgument='<%# Eval("OtherFollowUpPerServiceID") %>'
                                                            CommandName="cmdDelete" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                    
                    <!--Phone Follow-Up -->
                    <div class="tab-pane" id="phonefollowup">
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                                        <asp:RadioButton ID="rbtnLeftFEYes" Text="Yes" Checked="false" GroupName="LeftFE" runat="server" />
                                                        <asp:RadioButton ID="rbtnLeftFENo" Text="No" Checked="false" GroupName="LeftFE" runat="server" />
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
                                                                <asp:TextBox ID="txtContractNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>Country of Migration:</label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtMigratedCountry" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>Date of Migration:</label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtMigratedDate" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>Migrated after training:</label>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="rbtnMigratedAfterTrainingYes" Text="Yes" Checked="false" GroupName="MigratedAfterTraining" runat="server" />
                                                                <asp:RadioButton ID="rbtnMigratedAfterTrainingNo" Text="No" Checked="false" GroupName="MigratedAfterTraining" runat="server" />
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
                                                                <asp:DropDownList ID="ddlCurrentStatus" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="Select">[Select]</asp:ListItem>
                                                                    <asp:ListItem Value="Decidednottogo">Decided not to go</asp:ListItem>
                                                                    <asp:ListItem Value="StartedWorkingInNepal">Started Working In Nepal</asp:ListItem>
                                                                    <asp:ListItem Value="Inprocessofmigration">In process of migration</asp:ListItem>
                                                                    <asp:ListItem Value="Unsuccessmigration process">Unsuccess migration process</asp:ListItem>
                                                                    <asp:ListItem Value="Other">Other</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtCurrentStatus" runat="server" CssClass="form-control input-sm"></asp:TextBox>
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
                                                                <asp:TextBox ID="txtManpowerAgent" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>
                                                                    Amount paid for foreign employment:</label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtAmountPaidforFE" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="1">
                                                                <label>
                                                                    Source of investment:</label>
                                                            </td>
                                                            <td colspan="3" align="left">
                                                                <asp:CheckBoxList ID="chkSourceOfInvestment" runat="server" RepeatDirection="Horizontal">
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
                                                                <asp:RadioButton ID="rbtnReceiptFromManpowerYes" Text="Yes" Checked="false" GroupName="ReceiptFromManpower" runat="server" />
                                                                <asp:RadioButton ID="rbtnReceiptFromManpowerNo" Text="No" Checked="false" GroupName="ReceiptFromManpower" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>Left document before departure:</label>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="rbtnLeftDocumentYes" Text="Yes" Checked="false" GroupName="LeftDocument" runat="server" />
                                                                <asp:RadioButton ID="rbtnLeftDocumentNo" Text="No" Checked="false" GroupName="LeftDocument" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>Same work as per agreement: </label>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="rbtnWorkAggreementYes" Text="Yes" Checked="false" GroupName="WorkAggreement" runat="server" />
                                                                <asp:RadioButton ID="rbtnWorkAggreementNo" Text="No" Checked="false" GroupName="WorkAggreement" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label>Same salary/wage as per agreement: </label>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="rbtnSalaryAgreementYes" Text="Yes" Checked="false" GroupName="SalaryAggreement" runat="server" />
                                                                <asp:RadioButton ID="rbtnSalaryAgreementNo" Text="No" Checked="false" GroupName="SalaryAggreement" runat="server" />
                                                            </td>
                                                        </tr>
                                                       <%-- <asp:HiddenField ID="hfPhoneFollowUpId" runat="server" Value="" />--%>

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
                                                        <asp:TextBox ID="txtAdditionalInfo" runat="server" CssClass="form-control input-sm" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <label>Recommendations:</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtRecommendations" runat="server" CssClass="form-control input-sm" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                            <td>
                                                <label>Name of informants:</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNameOfInformants" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>Relation with migrant:</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRelationMigrant" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>Date of follow up:</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDateOfFollowUp" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <label>Remarks:</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control input-sm" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <div class="col-lg-12">
                                        <h3>Phone Follow-Up 
                                            <%--&nbsp; &nbsp; &nbsp; 
                                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-default" />--%>
                                        </h3>
                                         <asp:UpdatePanel ID="updatepanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvPhoneFollowUp" runat="server" ShowHeader="true" AutoGenerateColumns="false"
                                                        ViewStateMode="Enabled" ShowHeaderWhenEmpty="true" OnRowCommand="gvPhoneFollowUp_RowCommand"
                                                        CssClass="table table-hover table-condensed">
                                                        <Columns>
                                                            <asp:BoundField DataField="FollowUpDate" HeaderText="Follow Up Date" />
                                                            <asp:BoundField DataField="InformantsName" HeaderText="Informant's Name" />
                                                            <asp:BoundField DataField="MigrantRelation" HeaderText="Relation with Migrant" />
                                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="EditLinkButton" runat="server" CommandArgument='<%# Eval("PhoneFollowUpID") %>'
                                                                        CommandName="cmdEdit" Text="Edit" ></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandArgument='<%# Eval("PhoneFollowUpID") %>'
                                                                        CommandName="cmdDelete" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        <asp:HiddenField ID="hfPhoneFollowUpID" runat="server" Value="" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Previous Foreign Employment Experience Popup Modal-->
    <div class="modal fade" id="PreviousFEExperience" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H2">Previous Foreign Employment Experience</h4>
                </div>
                <asp:UpdatePanel ID="updatePFEExperience" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="col-md-12">
                                <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <label>
                                                    Which Country?</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control input-sm pull-left">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    What Type of Job?</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlJobType" runat="server" CssClass="form-control input-sm pull-left">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Stay Duration</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlStayDuration" runat="server" CssClass="form-control input-sm pull-left">
                                                    <asp:ListItem Value="0" Text="[Select]"></asp:ListItem>
                                                </asp:DropDownList>
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
                                Cancel</button>
                            <asp:Button ID="btnAddPFEExperience" CssClass="btn btn-default" runat="server" Text="Save"
                                OnClick="btnAddPFEExperience_Click" OnClientClick="return AddPreviousFEExperience();" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- Followup Popup Modal-->
    <div class="modal fade" id="followupservices" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H1">Follow-up</h4>
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
                                                <asp:TextBox ID="txtFollowUpDate" runat="server" CssClass="form-control input-sm"
                                                    placeholder="MM/DD/YYYY"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    i. Follow-up was not possible, because</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlNonFollowup" runat="server" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Followup was possible :</label>
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbComplied" Text="Complied" Checked="false" GroupName="followup_possible"
                                                    runat="server" /><br />
                                                <asp:RadioButton ID="rbCompliedPartly" Text="Complied Partly" Checked="false" GroupName="followup_possible"
                                                    runat="server" /><br />
                                                <span style="margin-left: 25px;"></span>
                                                <asp:RadioButton ID="rbDidNotComply" Text="Did not comply" Checked="false" GroupName="didnot_comply"
                                                    runat="server" /><br />
                                                <span style="margin-left: 25px;"></span>
                                                <asp:RadioButton ID="rbReasonForNonCompliance" Text="Reasons for non-compliance"
                                                    Checked="false" GroupName="didnot_comply" runat="server" /><br />
                                                <span style="margin-left: 50px;"></span>
                                                <asp:RadioButton ID="rbReasonRecommendation" Text="Didn't understand the Recommendation"
                                                    Checked="false" GroupName="reason" runat="server" /><br />
                                                <span style="margin-left: 50px;"></span>
                                                <asp:RadioButton ID="rbWasTooDifficult" Text="Was too dificult to do" Checked="false"
                                                    GroupName="reason" runat="server" /><br />
                                                <span style="margin-left: 75px;"></span>
                                                <asp:RadioButton ID="rbReasonReceipt" Text="Receipt could not be obtain" Checked="false"
                                                    GroupName="reason2" runat="server" /><br />
                                                <span style="margin-left: 75px;"></span>
                                                <asp:RadioButton ID="rbOther" Text="Other" Checked="false" GroupName="reason2" runat="server" /><br />
                                                <span style="margin-left: 50px;"></span>
                                                <asp:RadioButton ID="rbReasonFamilyMember" Text="Family members don't know" Checked="false"
                                                    GroupName="reason" runat="server" /><br />
                                                <asp:TextBox ID="txtDidNoComplyReason" runat="server" CssClass="form-control input-sm"></asp:TextBox>
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
                                Cancel</button>
                            <asp:Button ID="btnAddOtherFollowUp" OnClientClick="return AddOtherFollowUp();" CssClass="btn btn-default"
                                runat="server" Text="Save" OnClick="btnAddOtherFollowUp_Click" />
                        </div>
                        <asp:HiddenField ID="hfOtherFollowUpPerServiceID" Value="" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <!-- Phone Follow Up Info Popup Modal-->
    <div class="modal fade" id="PhoneFollowUpInfo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H3">Phone Follow Up</h4>
                </div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="col-md-12">
                                <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                    <tbody>
                                        <%--<tr>
                                            <td>
                                                <label>Name of informants:</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNameOfInformants" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>Relation with migrant:</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRelationMigrant" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>Date of follow up:</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDateOfFollowUp" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <label>Remarks:</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control input-sm" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>--%>
                                    </tbody>
                                </table>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="modal-footer">
                            <%--<button type="button" class="btn btn-default" data-dismiss="modal">
                                Cancel</button>--%>
                           <%-- <asp:Button ID="btnCancel" CssClass="btn btn-default" runat="server" Text="Cancel" 
                                OnClick="btnCancel_Click" />
                            <asp:Button ID="btnAddPhoneFollowUp" CssClass="btn btn-default" runat="server" Text="Save"
                                OnClick="btnAddPhoneFollowUp_Click" OnClientClick="return AddPhoneFollowUp();" />--%>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <asp:HiddenField ID="hfSaMIProfileID" runat="server" Value="" />
    <asp:HiddenField ID="hfSaMIDistrictID" runat="server" Value="" />
    <asp:HiddenField ID="hfSaMIProfileNumber" runat="server" Value="" />
    <asp:HiddenField ID="hfForeignEmploymentID" runat="server" Value="" />
    <div class="modal fade" id="divProgressBar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    <div id="divProgressBarText">
                        <img src="../images/loading.gif" alt="" style="margin-right: 10px;" />
                        <strong>Saving Please Wait.........</strong>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="divSaveMessage" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    <div id="div2">
                        <strong>Saved Successfully!</strong>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="validationModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H4">Please correct the error(s) below:</h4>
                </div>
                <div class="modal-body">
                    <div id="modal-body-text" style="color: Red; font-weight: bold;">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);

        function BeginRequestHandler(sender, args) {
            PFEClickScript();
            PhoneFollowUpClickScript();
        }

        function EndRequestHandler(sender, args) {
            $('#divProgressBar').modal('hide')


            setTimeout(function () { $('#divSaveMessage').modal('hide') }, 1400);
            PhoneFollowUpClickScript();
            PFEClickScript();
            ResetClick();


        }
    </script>
</asp:Content>
