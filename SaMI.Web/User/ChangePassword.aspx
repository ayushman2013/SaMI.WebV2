<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="SaMI.Web.User.changepassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script src="js/JScript.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="container" style="margin-top:40px;">
<asp:Label ID="lblStatus" Visible="false" Text="" runat="server" CssClass="alert-warning" style="color:Red; font-weight:bold; font-size:14px; margin-left:50px;"></asp:Label>
<table cellpadding="5" cellspacing="0" border="0" width="100%" class="table-tab">
        <tbody>
        
               
            <tr>
                <td width="20%">
                    <label>Old Password:</label>
                </td>
               
                <td>
                    <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control input-sm" 
                        TextMode="Password" placeholder="Old Password" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>New Password:</label>
                </td>
                <td>
                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control input-sm" 
                        TextMode="Password" placeholder="New Password" ></asp:TextBox>
                </td>
             </tr>

             <tr>
                <td>
                    <label>Confirm New Password:</label>
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmNewPassword" runat="server" CssClass="form-control input-sm" 
                        TextMode="Password" placeholder="Comfirm New Password" ></asp:TextBox>
                </td>
             </tr>

              <tr>
                <td width="20%">
                    <label>&nbsp</label>
                </td>
                
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Change" 
                    OnClientClick="return ValidateChangePassword();" onclick="btnSave_Click"  CssClass = "btn btn-default" />
                    
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
            
        </div><!-- /.modal-content -->
    </div>
</div>
    </asp:Content>

