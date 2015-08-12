<%@ Page Title="" Language="C#" MasterPageFile="~/CaseMaster.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="SaMI.Web.CaseDocumentation.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript" src="js/ClickScripts.js"></script>
<script type="text/javascript">
    ResetClick();        
    function AddCaseProfile() {
        if (ValidateAdd()) {
            $('#casedocumentationothercases').modal('hide')
            return true;
        }
        else
            return false;
    }

    function ValidateAdd() {
        var validation = true;
        var message = '<ul>';

        if ($('#ctl00_MainContent_txtFirstName').val() == '') {
            validation = false;
            message += "<li>First Name is empty.</li>";
        }

        if ($('#ctl00_MainContent_txtLastName').val() == '') {
            validation = false;
            message += "<li>Last Name is empty.</li>";
        }

        if ($('#ctl00_MainContent_ddlDistrict').val() == '0') {
            validation = false;
            message += "<li>Please select District.</li>";
        }

        if ($('#ctl00_MainContent_ddlVDC').val() == '0') {
            validation = false;
            message += "<li>Please select VDC.</li>";
        }


        ///Validate CASE
        if ($('#ctl00_MainContent_ddlTypeOfCase').val() == '0') {
            validation = false;
            message += "<li>Please select Case Type.</li>";
        }
        if ($('#ctl00_MainContent_txtCaseNumber').val() == '') {
            validation = false;
            message += "<li>Case Number is empty.</li>";
        }
        if ($('#ctl00_MainContent_txtNameOfOpponent').val() == '') {
            validation = false;
            message += "<li>Name of opponent is empty.</li>";
        }
        if ($('#ctl00_MainContent_txtCaseDesc').val() == '') {
            validation = false;
            message += "<li>Problem faced description is empty.</li>";
        }
        if ($('#ctl00_MainContent_txtCaseRegisteredDate').val() == '') {
            validation = false;
            message += "<li>Case registered date is empty.</li>";
        }
        

        if ($('#ctl00_MainContent_ddlCaseStatusType').val() == '0') {
            validation = false;
            message += "<li>Please select Status.</li>";
        }

        if (!validation) {
            message += "</ul>";
            $('#modal-body-text').html(message);
            $('#validationModal').modal('show');
            return false;
        }
        return true;
    }
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <div style="min-height: 64px;" class="page-header">
    <div data-spy="affix" data-offset-top="135" id="fix-page-header">
        <div class="container"><div class="row"><div class="col-md-12">
            <h3>New Case
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="return AddCaseProfile();" CssClass="btn btn-default" OnClick="btnSave_Click" />
                <button class="btn btn-default" onclick="$(location).attr('href','Index.aspx');return false;">Cancel</button>
            </h3>
        </div></div></div>
    </div>
</div>
    <div class="clearfix"></div>
    <div class="container" style="">
        <div class="row">
            <div class="clearfix">
            </div>
            <div class="col-md-12">
                <!-- Nav tabs -->
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#profile" data-toggle="tab">Profile</a></li>
                </ul>
                <!-- Tab panes -->
                <div class="tab-content" style="margin-top: 30px;">

                    <div class="tab-pane active" id="profile">

                        <asp:UpdatePanel ID="updatePanelProfile" runat="server">
                        <ContentTemplate>
                        <div class="col-lg-6">
                        <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                            <tbody>
                                    <tr>
                                        <td><label>First Name</label></td>
                                        <td><asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control input-sm"></asp:TextBox></td>
                                    </tr>

                                    <tr>
                                        <td><label>Middle Name</label></td>
                                        <td><asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control input-sm"></asp:TextBox></td>
                                    </tr>

                                    <tr>
                                        <td><label>Last Name</label></td>
                                        <td><asp:TextBox ID="txtLastName" runat="server" CssClass="form-control input-sm"></asp:TextBox></td>
                                    </tr>

                                    <tr>
                                        <td><label>District</label></td>
                                        <td><asp:DropDownList ID="ddlDistrict" AutoPostBack="true"
                                    onselectedindexchanged="ddlDistrict_SelectedIndexChanged" runat="server" CssClass="form-control input-sm"></asp:DropDownList></td>
                                    </tr>

                                    <tr>
                                        <td><label>VDC</label></td>
                                        <td><asp:DropDownList ID="ddlVDC" runat="server" CssClass="form-control input-sm"></asp:DropDownList></td>
                                    </tr>

                            </tbody>
                        </table>
                        </div>

                        <div class="col-lg-6">
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
                                    </tbody>
                                    </table>
                                    </div>

                                  
                        <div class="col-lg-6">
                        <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                        <tbody>
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
                                <asp:DropDownList ID="ddlStackeHolder" Enabled="false" runat="server" CssClass="form-control input-sm">
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
                        </tbody>
                        </table>
                        </div>
                                 
                        <div class="col-lg-6">
                        <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                        <tbody>
                        <asp:Panel ID="pnlCaseOutput" runat="server" Visible="false">
                            <tr>
                                <td>
                                    <label>
                                        Compensated?:</label>
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
                         
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
</asp:Content>
