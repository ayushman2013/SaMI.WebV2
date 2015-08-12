<%@ Page Title="" Language="C#" MasterPageFile="~/CaseMaster.Master" AutoEventWireup="true"
    CodeBehind="Edit.aspx.cs" Inherits="SaMI.Web.CaseDocumentation.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript" src="js/ClickScripts.js"></script>
<script type="text/javascript" src="js/JScript.js"></script>
<script type="text/javascript">
    ResetClick();        
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    <div class="clearfix"></div>
<div style="min-height: 64px;" class="page-header">
    <div data-spy="affix" data-offset-top="135" id="fix-page-header">
        <div class="container"><div class="row"><div class="col-md-12">
            <h3>Edit Case
                <button class="btn btn-default" onclick="$(location).attr('href','Index.aspx');return false;">Cancel</button>
            </h3>
        </div></div></div>
    </div>
</div>
    <div class="container" style="">
        <div class="row">
            <div class="clearfix">
            </div>
            <div class="col-md-12">
                <!-- Nav tabs -->
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#profile" data-toggle="tab">Profile</a></li>
                    <li><a href="#casedocumentation" data-toggle="tab">Case Documentation</a></li>
                </ul>
                <!-- Tab panes -->
                <div class="tab-content" style="margin-top: 30px;">
                    <div class="tab-pane active" id="profile">
                        <asp:UpdatePanel ID="updatePanelCaseProfile" runat="server">
                            <ContentTemplate>
                            <div class="col-lg-6">
                            
                          
                                <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <label>
                                                    First Name</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Middle Name</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Last Name</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    District</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"
                                                    runat="server" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    VDC</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlVDC" runat="server" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                  </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSaveCaseProfile" CssClass="btn btn-default" runat="server" Text="Save Profile" OnClick="btnSaveCaseProfile_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>


                    <div class="tab-pane" id="casedocumentation">
                        <asp:Panel ID="pnlCases" runat="server">
                            <asp:UpdatePanel ID="updateCase" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-6 headerDivider-right">
                                        <asp:Panel ID="pnlAddCases" runat="server">
                                            <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="2">
                                                            <label>
                                                                Type of Cases :</label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <button class="btn btn-default" data-toggle="modal" data-target="#casedocumentationothercases">
                                                                Add Other</button>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </asp:Panel>
                                        <asp:GridView ID="gvCases" runat="server" ShowHeaderWhenEmpty="True" OnRowCommand="gvCases_RowCommand"
                                            AutoGenerateColumns="False" ShowHeader="True" CssClass="table table-hover table-condensed">
                                            <Columns>
                                                <asp:BoundField DataField="CaseTypeDesc" HeaderText="Case Type" />
                                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                                <asp:BoundField DataField="CaseStatusTypeDesc" HeaderText="Status" />
                                                <asp:BoundField DataField="Evidences" HeaderText="Evidences" />
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="EditLinkButton" runat="server" CommandArgument='<%# Eval("CaseID") %>'
                                                            CommandName="cmdEdit" Text="Edit" OnClientClick="$('#casedocumentationothercases').modal('show');"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandArgument='<%# Eval("CaseID") %>'
                                                            CommandName="cmdDelete" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                            <tbody>
                                                <tr>
                                                    <td colspan="2">
                                                        <button class="btn btn-default" data-toggle="modal" data-target="#casefollowup">
                                                            Add Case Follow-up</button>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <asp:GridView ID="gvCaseFollowUp" runat="server" ShowHeaderWhenEmpty="True" OnRowCommand="gvCaseFollowUp_RowCommand"
                                            AutoGenerateColumns="False" ShowHeader="True" CssClass="table table-hover table-condensed">
                                            <Columns>
                                                <asp:BoundField DataField="FollowUpDate" HeaderText="Date" />
                                                <asp:BoundField DataField="CaseTypeDesc" HeaderText="Case Type" />
                                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="EditLinkButton" runat="server" CommandArgument='<%# Eval("CaseFollowUpID") %>'
                                                            CommandName="cmdEdit" Text="Edit" OnClientClick="$('#casefollowup').modal('show');"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandArgument='<%# Eval("CaseFollowUpID") %>'
                                                            CommandName="cmdDelete" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div class="col-md-6">
                                        <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                            <tbody>
                                                <tr>
                                                    <td colspan="2">
                                                        <button class="btn btn-default" data-toggle="modal" data-target="#casereferrals">
                                                            Add Case Referral</button>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <asp:GridView ID="gvCaseReferralHistory" runat="server" ShowHeaderWhenEmpty="True"
                                            OnRowCommand="gvCaseReferralHistory_RowCommand" AutoGenerateColumns="False" ShowHeader="True"
                                            CssClass="table table-hover table-condensed">
                                            <Columns>
                                                <asp:BoundField DataField="ReferralDate" HeaderText="Date" />
                                                <asp:BoundField DataField="CaseTypeDesc" HeaderText="Case Type" />
                                                <asp:BoundField DataField="PreviousPartnerName" HeaderText="Previous Partner" />
                                                <asp:BoundField DataField="NewPartnerName" HeaderText="New Partner" />
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="EditLinkButton" runat="server" CommandArgument='<%# Eval("CaseReferralHistoryID") %>'
                                                            CommandName="cmdEdit" Text="Edit" OnClientClick="$('#casereferrals').modal('show');"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandArgument='<%# Eval("CaseReferralHistoryID") %>'
                                                            CommandName="cmdDelete" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:HiddenField ID="hfCaseReferralHistoryID" Value="" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="casereferrals" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H7">
                        Case Referral</h4>
                </div>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
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
                                                <asp:TextBox ID="txtReferralDate" runat="server" CssClass="form-control input-sm"
                                                    placeholder="MM/DD/YYYY"></asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Case Type :</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlReferralCaseType" runat="server" CssClass="form-control input-sm"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlReferralCaseType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Current Partner :</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPerviousPartner" runat="server" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                New Partner :</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlNewPartner" runat="server" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Remarks :</label>
                                        </td>
                                        <td>
                                            <span class="col-md-6">
                                                <asp:TextBox ID="txtReferralRemarks" TextMode="MultiLine" runat="server" CssClass="form-control input-sm"
                                                    Rows="4" Style="word-wrap: break-word; resize: vertical;" placeholder="Description"></asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                Cancel</button>
                            <asp:Button ID="btnSaveCaseReferral" CssClass="btn btn-default" runat="server" Text="Save"
                                OnClick="btnSaveCaseReferral_Click" OnClientClick="return AddCaseReferralHistory();" />
                        </div>
                        <asp:HiddenField ID="HiddenField2" Value="" runat="server" />
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
                        Add Cases</h4>
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
                                            <asp:DropDownList ID="ddlTypeOfCase" runat="server" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Case Number :</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCaseNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Name of opponent :</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNameOfOpponent" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Problem faced :</label>
                                        </td>
                                        <td>
                                            <span class="col-md-6">
                                                <asp:TextBox ID="txtCaseDesc" TextMode="MultiLine" runat="server" CssClass="form-control input-sm"
                                                    Rows="4" Style="word-wrap: break-word; resize: vertical;" placeholder="Description"></asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Case Registered Date :</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCaseRegisteredDate" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Partner :</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlStackeHolder" runat="server" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Registered At:</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCaseRegistrar" runat="server" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Responsible staff :</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtResponsibleStaff" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Status :</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCaseStatusType" runat="server" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <asp:Panel ID="pnlCaseOutput" runat="server" Visible="false">
                                        <tr>
                                            <td>
                                                <label>
                                                    Compensated?</label>
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbCompensationYes" Text="Yes" Checked="false" GroupName="compensation"
                                                    runat="server" />
                                                <asp:RadioButton ID="rbCompensationNo" Text="No" Checked="false" GroupName="compensation"
                                                    runat="server" />
                                                Compensation Amount:
                                                <asp:TextBox ID="txtCompensationAmount" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Output Details:</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtOutputDetails" runat="server" CssClass="form-control input-sm"
                                                    TextMode="MultiLine"></asp:TextBox>
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
                                                <asp:CheckBoxList ID="cblEvidenceTypes" runat="server" RepeatColumns="3">
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
                                Cancel</button>
                            <asp:Button ID="btnAddOtherCase" OnClientClick="return ValidateOtherCase();" CssClass="btn btn-default"
                                runat="server" Text="Save" OnClick="btnAddOtherCase_Click" />
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
                                                <asp:TextBox ID="txtCaseFollowUpDate" runat="server" CssClass="form-control input-sm"
                                                    placeholder="MM/DD/YYYY"></asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Case Type :</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlFollowupCaseType" runat="server" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Description :</label>
                                        </td>
                                        <td>
                                            <span class="col-md-6">
                                                <asp:TextBox ID="txtCaseFollowUpDesc" TextMode="MultiLine" runat="server" CssClass="form-control input-sm"
                                                    Rows="4" Style="word-wrap: break-word; resize: vertical;" placeholder="Description"></asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                Cancel</button>
                            <asp:Button ID="btnAddCaseFollowUp" CssClass="btn btn-default" runat="server" Text="Save"
                                OnClick="btnAddCaseFollowUp_Click" OnClientClick="return AddCaseFollowUp();" />
                        </div>
                        <asp:HiddenField ID="hfCaseFollowUpID" Value="" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
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
    <div class="modal fade" id="validationModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H4">
                        Please correct the error(s) below:</h4>
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

        }

        function EndRequestHandler(sender, args) {
            $('#divProgressBar').modal('hide')
            ResetClick();
        }
    </script>
    <asp:HiddenField ID="hfCaseProfileID" runat="server" Value="" />
    <asp:HiddenField ID="hfSaMIDistrictID" runat="server" Value="" />
    <asp:HiddenField ID="hfSaMIProfileNumber" runat="server" Value="" />
</asp:Content>
