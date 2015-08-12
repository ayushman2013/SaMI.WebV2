<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CaseReports.aspx.cs" Inherits="SaMI.Web.Reports.CaseReports" %>
<%@ Register src="ReportHeader.ascx" tagname="RH" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/jscript" src="js/JScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<uc1:RH ID="ReportHeader1" runat="server" />
<asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="container">

    <div class="row">
        <div class="col-md-2">
            <div class="tdtitle col-md-12"><h3>Filters</h3></div>
            
            <div class="col-md-12 filter-menu">
                <asp:DropDownList ID="ddlStatus" runat = "server" CssClass="form-control" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlStatus_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-md-12 filter-menu">
                <asp:DropDownList ID="ddlCompensation" runat = "server" CssClass="form-control" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlCompensation_SelectedIndexChanged"></asp:DropDownList>
            </div>
           
            <div class="filter-menu col-md-12">
                <asp:DropDownList ID="ddlDistrict" runat = "server" CssClass="form-control" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="filter-menu col-md-12">
                <asp:DropDownList ID="ddlVDC" runat = "server" CssClass="form-control" 
            AutoPostBack="True" onselectedindexchanged="ddlVDC_SelectedIndexChanged"></asp:DropDownList>
            </div>
            
        </div>
        <div class="col-md-10 headerDivider-left">
            <h3>CASES</h3>
            <asp:GridView ID="gvSaMICases" runat="server" ShowHeaderWhenEmpty="True"
               AllowPaging="True" OnPageIndexChanging = "gvSaMICases_PageIndexChanging" PageSize="20"
                   AutoGenerateColumns="False" ShowHeader="True" CssClass="table table-hover table-condensed">            
                <Columns>
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
                </Columns>            
            </asp:GridView>
        </div>
    </div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript">    GetSelected('cases');</script>
</asp:Content>
