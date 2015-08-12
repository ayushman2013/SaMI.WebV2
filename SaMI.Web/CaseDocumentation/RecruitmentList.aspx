<%@ Page Title="" Language="C#" MasterPageFile="~/CaseMaster.Master" AutoEventWireup="true" CodeBehind="RecruitmentList.aspx.cs" Inherits="SaMI.Web.CaseDocumentation.RecruitmentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link rel="stylesheet" href="/assets/css/gridview-pagination.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div class="col-md-12">
        <h4>
            Referred By ICC</h4>
    </div>
     <div class="container">
        <div class="row">
            <div class="col-md-12" style="margin-top: 16px">
                <div class="col-md-3">
                    <asp:TextBox ID="txtSearchText" runat="server" CssClass="form-control" placeholder="Search by Name"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default"
                        OnClick="btnSearch_Click" />
                </div>
                <div class="col-lg-6" style="margin-left: 1000px">
                    <asp:Label ID="label" runat="server" Text="Total Records "></asp:Label>
                    <asp:Label ID="lblDataCount" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-12" style="margin-top: 20px">
        <asp:GridView ID="gvRecruitmentList" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
            ShowHeader="True" CssClass="table table-striped table-hover" AllowPaging="True" PagerStyle-CssClass="paging"
            PageSize="20" GridLines="None" OnPageIndexChanging="gvRecruitmentList_PageIndexChanging">
             <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="<<" LastPageText=">>"
                            NextPageText="&gt;" PreviousPageText="<" />
            <Columns>
                <asp:HyperLinkField HeaderText="Profile Number" DataTextField="SaMIProfileNumber"
                    DataNavigateUrlFields="SaMIProfileID" DataNavigateUrlFormatString="/CaseDocumentation/Add.aspx?ICCID={0}" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="MiddleName" HeaderText="Middle Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="DistrictName" HeaderText="District" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
