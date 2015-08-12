<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SaMI.Web.User.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function Redirect() {
        window.location.href = "Add.aspx";
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:UpdatePanel runat="server" ID="updatePanel">
<ContentTemplate>
<div class="container" style="margin-top:40px;">
<div class="col-md-5">
    <h1>User List
        <button class="btn btn-default" onclick="Redirect(); return false;">New User</button>
        
    </h1>
</div>
 <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
<div class="col-md-7 text-right">
    <h1>
       <span class="col-md-3">
            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" 
            AutoPostBack="True" onselectedindexchanged="ddlDistrict_SelectedIndexChanged">
            </asp:DropDownList>
            
        </span>
        <span class="col-md-3">
         <asp:DropDownList ID="ddlSaMIOrganization" runat="server" CssClass="form-control" 
            AutoPostBack="True" onselectedindexchanged="ddlDistrict_SelectedIndexChanged">
             <asp:ListItem Text="[Organization]"></asp:ListItem>
            </asp:DropDownList>
        </span>
        <span class="col-md-3">
         <asp:DropDownList ID="ddlCasePartner" runat="server" CssClass="form-control" 
            AutoPostBack="True" onselectedindexchanged="ddlDistrict_SelectedIndexChanged">
            </asp:DropDownList>
        </span>
        <span class="col-md-3">
         <asp:DropDownList ID="ddlSkillPartner" runat="server" CssClass="form-control" 
            AutoPostBack="True" onselectedindexchanged="ddlDistrict_SelectedIndexChanged">
            </asp:DropDownList>
        </span>
    </h1>
</div>
<div class="clearfix"></div>
<asp:GridView ID="gvUsers" runat="server" ShowHeaderWhenEmpty="True"
            OnRowCommand = "gvUsers_RowCommand"
            AllowPaging="True" OnPageIndexChanging = "gvUsers_PageIndexChanging" PageSize="20"
            AutoGenerateColumns="False" ShowHeader="True" CssClass="table table-striped table-hover">
            <AlternatingRowStyle BackColor="White"  />

            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="Full Name" />      
                <asp:BoundField DataField="UserName" HeaderText="User Name" />  
                <asp:BoundField DataField="UserTypeDesc" HeaderText="UserType" /> 
                <asp:BoundField DataField="DistrictName" HeaderText="District" />
                <asp:BoundField DataField="SaMIOrganizationName" HeaderText="Organization" />    
                <asp:BoundField DataField="StakeHolderName" HeaderText="Case Partner" />  
                <asp:BoundField DataField="SkillPartnerName" HeaderText="Skill Partner" />  
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="UserID"  DataNavigateUrlFormatString ="Edit.aspx?ID={0}"
                HeaderText="" />  
                <asp:HyperLinkField Text="Reset Password" DataNavigateUrlFields="UserID"  DataNavigateUrlFormatString ="ResetPassword.aspx?ID={0}"
                HeaderText="" />                   
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandArgument='<%# Eval("UserID") %>'
                            CommandName="cmdDelete" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>  
            </Columns>
            </asp:GridView>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
