<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="SaMI.Web.User.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="js/JScript.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanelPersonalInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container" style="margin-top: 40px;">
                <asp:Label ID="lblStatus" Visible="false" Text="" runat="server" CssClass="alert-warning" Style="font-weight: bold; font-size: 14px; margin-left: 50px;"></asp:Label>
                <table cellpadding="5" cellspacing="0" border="0" width="100%" class="table-tab">
                    <tbody>

                        <tr>
                            <td width="20%">
                                <label>User Type</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control input-sm" onchange="EnableDisablePartner();"
                                    OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>District</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true"
                                    CssClass="form-control input-sm" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                    <asp:ListItem Text="[Organization]"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Organization</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSaMIOrganization" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Case Partner</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPartner" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <label>Skill Partner</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSkillPartner" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Full Name</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>User Name</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Password</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control input-sm"
                                    TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Confirm Password</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control input-sm"
                                    TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <label>&nbsp</label>
                            </td>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Save"
                                    OnClientClick="return ValidateInput(true)" OnClick="btnSave_Click" CssClass="btn btn-default" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="modal fade" id="validationModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="H3">Please correct the error(s) below:</h4>
                </div>

                <div class="modal-body">
                    <div id="modal-body-text" style="color: Red; font-weight: bold;">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>

            </div>
            <!-- /.modal-content -->
        </div>
    </div>
</asp:Content>
