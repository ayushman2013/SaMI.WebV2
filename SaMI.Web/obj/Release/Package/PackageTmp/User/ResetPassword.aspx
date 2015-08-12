<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="SaMI.Web.User.ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function ValidateInput() {
        var validation = true;
        var message = '<ul>';

        if ($('#ctl00_MainContent_txtNewPassword').val() == '') {
            validation = false;
            message += "<li>New Password is empty.</li>";
        }
        if ($('#ctl00_MainContent_txtConfirmNewPassword').val() == '') {
            validation = false;
            message += "<li>Confirm Password is empty.</li>";
        }
        if ($('#ctl00_MainContent_txtNewPassword').val() != '' && $('#ctl00_MainContent_txtConfirmNewPassword').val() != '') {
            if ($('#ctl00_MainContent_txtNewPassword').val() != $('#ctl00_MainContent_txtConfirmNewPassword').val()) {
                validation = false;
                message += "<li>New Password & Confirm Password mis-matched.</li>";
            }
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
<div class="container" style="margin-top:40px;">
<table cellpadding="5" cellspacing="0" border="0" width="100%" class="table-tab">
        <tbody>
            <tr>
                <td>
                    <label>Full Name</label>
                </td>
               
                <td>
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
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
                <td>
                    <label>New Password</label>
                </td>
                
                <td>
                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control input-sm" TextMode="Password"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <label>Confirm Password</label>
                </td>
                
                <td>
                    <asp:TextBox ID="txtConfirmNewPassword" runat="server" CssClass="form-control input-sm" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            

            <tr>
                <td width="20%">
                    <label>&nbsp</label>
                </td>
                
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Reset Password" 
                    OnClientClick="return ValidateInput(false);" CssClass = "btn btn-default" 
                        onclick="btnSave_Click" />
                    
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
