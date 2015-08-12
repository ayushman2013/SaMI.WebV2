<%@ Page Title="" Language="C#" MasterPageFile="~/Trainings.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SaMI.Web.Training.RecTrainee.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TrainingBody" runat="server">
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-12" style="margin-top: 5px">
                <h4 class="col-lg-2">Referred By ICC</h4>
                <div class="col-md-4">
                    <asp:TextBox ID="txtSearchText" runat="server" CssClass="form-control" placeholder="Search by Name"></asp:TextBox>
                </div>
                <div class="col-lg-1 pull-left">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default"
                        OnClick="btnSearch_Click" />
                </div>

                <div class="col-lg-2 pull-right" style="margin-top: 10px;">
                    <asp:Label ID="label" runat="server" Text="Total Records "></asp:Label>
                    <asp:Label ID="lblDataCount" runat="server"></asp:Label>
                </div>

            </div>
        </div>

        <div class="col-md-12" style="margin-top: 15px">
            <asp:GridView ID="gvRecruitmentList" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                ShowHeader="True" CssClass="table table-striped table-hover" AllowPaging="True" PagerStyle-CssClass="paging"
                PageSize="20" GridLines="None" OnPageIndexChanging="gvRecruitmentList_PageIndexChanging">

                <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="<<" LastPageText=">>"
                    NextPageText="&gt;" PreviousPageText="<" />

                <Columns>
                    <asp:BoundField DataField="SaMIOrganizationName" HeaderText="ICC" />
                    <asp:HyperLinkField HeaderText="Profile Number" DataTextField="SaMIProfileNumber"
                        DataNavigateUrlFields="SaMIProfileID" DataNavigateUrlFormatString="/Training/Add.aspx?ICCID={0}" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="EthnicityName" HeaderText="Ethnicity" />
                    <asp:BoundField DataField="VisitorPhone" HeaderText="Phone" />
                    <asp:BoundField DataField="DistrictName" HeaderText="District" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
