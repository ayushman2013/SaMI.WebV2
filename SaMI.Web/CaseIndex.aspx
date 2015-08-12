<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CaseIndex.aspx.cs" Inherits="SaMI.Web.CaseIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="container">
    <div class="col-md-10 pull-right">
            
            <div class="col-md-2">
                <asp:DropDownList ID="ddlDistrict" runat = "server" CssClass="form-control" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlStatus" runat = "server" CssClass="form-control" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlStatus_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlCompensation" runat = "server" CssClass="form-control" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlCompensation_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlGender" runat = "server" CssClass="form-control" 
                    AutoPostBack="True" onselectedindexchanged="ddlGender_SelectedIndexChanged"></asp:DropDownList>
            </div>
            
            <div class="col-md-2">
                <asp:DropDownList ID="ddlVDC" runat = "server" CssClass="form-control" 
            AutoPostBack="True" onselectedindexchanged="ddlVDC_SelectedIndexChanged"></asp:DropDownList>
            </div>
            
        </div>

    <div class="row">        
        <div class="col-md-12">
            <h3>CASES</h3>
            <asp:GridView ID="gvSaMICases" runat="server" ShowHeaderWhenEmpty="True"
               AllowPaging="True" OnPageIndexChanging = "gvSaMICases_PageIndexChanging" PageSize="20"
                   AutoGenerateColumns="False" ShowHeader="True" CssClass="table table-hover table-condensed" GridLines="None">            
                <Columns>
                    <asp:HyperLinkField HeaderText = "Client" DataTextField="FullName" DataNavigateUrlFields="CaseProfileID"  DataNavigateUrlFormatString ="Profile/View.aspx?ID={0}"
             /> 
                    <asp:BoundField DataField="FullName" HeaderText="Client"/>                
                    <asp:BoundField DataField="DistrictName" HeaderText="District"  />
                    <asp:BoundField DataField="NameOfOpponent" HeaderText="Oponent"  />
                     <asp:BoundField DataField="ProblemFaced" HeaderText="Problem Faced"  />
                    <asp:BoundField DataField="CaseTypeDesc" HeaderText="Nature of Case"  />
                    <asp:BoundField DataField="CaseFollowUpDetail" HeaderText="Service provided"  />
                    <asp:BoundField DataField="CaseRegisteredDate" HeaderText="Registered Date"  />
                    <asp:BoundField DataField="CaseRegistrarName" HeaderText="Registered At"  />
                    <asp:BoundField DataField="CaseNumber" HeaderText="CaseNumber"/>   
                    <asp:BoundField DataField="StatusDetail" HeaderText="Status"/>   
                    <asp:BoundField DataField="CompenstationDetail" HeaderText="Compensation"/> 
                    <asp:HyperLinkField HeaderText = "Update" Text="Update" DataNavigateUrlFields="CaseProfileID"  DataNavigateUrlFormatString ="Profile/Edit.aspx?ID={0}"
             /> 
                </Columns>            
            </asp:GridView>
        </div>
    </div>
</div>
</ContentTemplate>
</asp:UpdatePanel>



</asp:Content>
