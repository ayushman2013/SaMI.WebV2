<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmploymentReports.aspx.cs" Inherits="SaMI.Web.Reports.EmploymentReports" %>
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
            
            <div class="filter-menu col-md-12">
                <asp:DropDownList ID="ddlCountry" runat = "server" CssClass="form-control" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlCountry_SelectedIndexChanged" ></asp:DropDownList>
            </div>
            
            <div class="col-md-12 filter-menu">
                <asp:DropDownList ID="ddlGender" runat = "server" CssClass="form-control" 
                    AutoPostBack="True" onselectedindexchanged="ddlGender_SelectedIndexChanged"></asp:DropDownList>
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
            <div class="filter-menu col-md-12">
                <asp:DropDownList ID="ddlEthnicity" runat = "server" CssClass="form-control" 
                    AutoPostBack="True" onselectedindexchanged="ddlEthnicity_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="filter-menu col-md-12">
                <asp:DropDownList ID="ddlCaste" runat = "server" 
                CssClass="form-control" AutoPostBack="True" 
                    onselectedindexchanged="ddlCaste_SelectedIndexChanged" ></asp:DropDownList>
            </div>
        </div>

        <div class="col-md-10 headerDivider-left">
            <h3>CASES</h3>
            <asp:GridView ID="gvEmployments" runat="server" ShowHeaderWhenEmpty="True"
                AllowPaging="True" OnPageIndexChanging = "gvEmployments_PageIndexChanging" PageSize="20"
                   AutoGenerateColumns="False" ShowHeader="True" CssClass="table table-hover table-condensed">            
                <Columns>
                    <asp:BoundField DataField="FullName" HeaderText="Name"/>                
                    <asp:BoundField DataField="DistrictName" HeaderText="District"  />
                    <asp:BoundField DataField="CompanyName" HeaderText="Company"  />
                     <asp:BoundField DataField="CountryName" HeaderText="Country"  />
                    <asp:BoundField DataField="EmploymentStartDate" HeaderText="Start Date"  />
                    <asp:BoundField DataField="WorkTypeDesc" HeaderText="Work Type"  />
                    <asp:BoundField DataField="PaymentRangeDesc" HeaderText="Income"  />
                    <asp:BoundField DataField="TrainingStatus" HeaderText="Training?"  />
                </Columns>            
            </asp:GridView>
        </div>
    </div>
</div>
</ContentTemplate>
</asp:UpdatePanel>

<script type="text/javascript">    GetSelected('employments');</script>
</asp:Content>
