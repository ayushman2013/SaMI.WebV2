<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SaMI.Web.User.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script src="js/JScript.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="container" style="margin-top:40px;">
<table cellpadding="5" cellspacing="0" border="0" width="100%" class="table-tab">
        <tbody>
            <tr>
                <td width="20%">
                    <label>User Type</label>
                </td>
               
                <td>
                    <asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control input-sm" onchange="EnableDisablePartner();">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label>District</label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control input-sm"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
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
                    <asp:DropDownList ID="ddlPartner" runat="server" CssClass="form-control input-sm" Enabled = "false"></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    <label>Skill Partner</label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSkillPartner" runat="server" CssClass="form-control input-sm" Enabled = "false"></asp:DropDownList>
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
                <td width="20%">
                    <label>User Name</label>
                </td>
                
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="20%">
                    <label>Password</label>
                </td>
                
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td width="20%">
                    <label>&nbsp</label>
                </td>
                
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" 
                    OnClientClick="return ValidateInput(false);" onclick="btnSave_Click" CssClass = "btn btn-default" />
                    
                </td>
            </tr>
        </tbody>
    </table>
</div>
<div class="modal fade" id="validationModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title" id="H3">Please correct the error(s) below:</h4>
            </div>
            
            <div class="modal-body">
                <div id="modal-body-text" style="color:Red; font-weight:bold;">
                
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>                
            </div>
            
        </div>
    </div>
</div>
</asp:Content>


