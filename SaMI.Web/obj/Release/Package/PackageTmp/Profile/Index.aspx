<%@ Page Title="Registered Profiles" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SaMI.Web.Profile.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .hiddencol
        {
            display: none;
        }
    </style>
    <link rel="Stylesheet" href="../assets/css/gridview-pagination.css" />
    
    <script type="text/javascript" src="/Scripts/JScript.Includes.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#ctl00_MainContent_txtSearchText').on('keypress', function (e) {
                if (e.keyCode == 13 || e.keyCode == '13') {
                    e.preventDefault();
                    $('#ctl00_MainContent_btnSearch').trigger("click");
                }
            });
        });
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 20px;">
        <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="col-md-5">
                    <h1>
                        Profile List
                        <%--<button class="btn btn-default" onclick="$(location).attr('href','Add.aspx');return false;">
                            Add</button>--%>
                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_click" CssClass="btn btn-default" />
                    </h1>
                </div>
                <div class="container">
                    <div class="row">
                        <div class="col-md-3 pull-right" style="margin-top: 30px">
                            <div class="col-md-8">
                                <asp:TextBox ID="txtSearchText" runat="server" CssClass="form-control" placeholder="Search by Name"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default"
                                    OnClick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="row">
                        <div class="col-md-12 pull-right" style="margin-left: -5px;">
                            <span class="col-md-2">
                                <asp:DropDownList ID="ddlEthnicity" runat="server" CssClass="form-control" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlEthnicity_SelectedIndexChanged">
                                </asp:DropDownList>
                            </span>
                            <span class="col-md-2">
                                <asp:DropDownList ID="ddlValidRegions" runat="server" CssClass="form-control" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlValidRegions_SelectedIndexChanged">
                                </asp:DropDownList>
                            </span><span class="col-md-2">
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                </asp:DropDownList>
                            </span><span class="col-md-2">
                                <asp:DropDownList ID="ddlOrganization" runat="server" CssClass="form-control" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged">
                                    <asp:ListItem Text="[Organization]" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </span><span class="col-md-2">
                                <asp:DropDownList ID="ddlFollowUpStatus" runat="server" CssClass="form-control" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlFollowUpStatus_SelectedIndexChanged">
                                </asp:DropDownList>
                            </span><span class="col-md-2">
                                <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-control" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged">
                                </asp:DropDownList>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="clearfix">
                    &nbsp</div>
                <div class="clearfix">
                    &nbsp</div>
                <h6 class="col-md-2 pull-right" style="margin-top: -10px">
                    No. of Records:
                    <asp:Label ID="lblNoOfRecords" runat="server"></asp:Label>
                </h6>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                          <div class="col-md-12">
                    <asp:GridView ID="gvSaMIProfile" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                        ShowHeader="True" CssClass="table table-striped table-hover pagination" PagerStyle-CssClass="paging"
                        AllowPaging="True" OnRowCommand="gvSaMIProfile_RowCommand" PageSize="20" GridLines="None"
                        OnPageIndexChanging="gvSaMIProfile_PageIndexChanging">
                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="<<" LastPageText=">>"
                            NextPageText="&gt;" PreviousPageText="<" />
                        <Columns>
                            <asp:TemplateField>
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:BoundField DataField="SaMIProfileID" HeaderText="SaMIProfileID" ItemStyle-CssClass="hiddencol"
                                HeaderStyle-CssClass="hiddencol">
                                <HeaderStyle CssClass="hiddencol" />
                                <ItemStyle CssClass="hiddencol" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SaMIOrganizationID" HeaderText="SaMIOrganizationID" ItemStyle-CssClass="hiddencol"
                                HeaderStyle-CssClass="hiddencol">
                                <HeaderStyle CssClass="hiddencol" />
                                <ItemStyle CssClass="hiddencol" />
                            </asp:BoundField>
                            <asp:HyperLinkField HeaderText="Profile Number" DataTextField="SaMIProfileNumber"
                                ItemStyle-Width="10%" DataNavigateUrlFields="SaMIProfileID" DataNavigateUrlFormatString="View.aspx?ID={0}">
                                <ItemStyle Width="10%" />
                            </asp:HyperLinkField>
                            <asp:HyperLinkField HeaderText="Name" DataTextField="Name" DataNavigateUrlFields="SaMIProfileID"
                                DataNavigateUrlFormatString="View.aspx?ID={0}" />
                            <asp:BoundField DataField="VisitorPhone" HeaderText="Phone" />
                            <asp:BoundField DataField="DistrictName" HeaderText="District" />
                            <asp:BoundField DataField="FollowUpStatus" HeaderText="Follow-up" />
                            <asp:BoundField DataField="CreatedByName" HeaderText="Created By" />
                            <asp:BoundField DataField="CreatedDate" HeaderText="Date" />
                            <%-- <asp:BoundField DataField="ReferStatus" HeaderText="ReferStatus" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />--%>
                            <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="SaMIProfileID" Text="Edit"
                                DataNavigateUrlFormatString="Edit.aspx?ID={0}" />
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandArgument='<%# Eval("SaMIProfileID") %>' 
                                         Text="Delete"
                                        CommandName="cmdDelete" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="paging" />
                    </asp:GridView>
                </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
              
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
