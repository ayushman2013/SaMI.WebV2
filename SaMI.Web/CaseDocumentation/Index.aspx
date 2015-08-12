<%@ Page Title="" Language="C#" MasterPageFile="~/CaseMaster.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="SaMI.Web.CaseDocumentation.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link rel="stylesheet" href="/assets/css/gridview-pagination.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="col-md-5">
                    <h1>
                        Cases
                        <button class="btn btn-default" onclick="$(location).attr('href','Add.aspx');return false;">
                            Add</button>
                    </h1>
                </div>
                <div class="col-md-10 pull-right">
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <%-- <div class="col-md-3">
                <asp:DropDownList ID="ddlCompensation" runat = "server" CssClass="form-control" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlCompensation_SelectedIndexChanged"></asp:DropDownList>
            </div>--%>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlGender_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlVDC" runat="server" CssClass="form-control" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlVDC_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                
                <div class="row">
                    <div class="col-md-12" style="margin-top: 20px">
                        <%--<h3>CASES</h3>--%>
                        <div class="clearfix">
                        </div>
                        <asp:GridView ID="gvSaMICases" runat="server"
                            AutoGenerateColumns="False" CssClass="table table-hover table-condensed" ShowHeaderWhenEmpty="True"
                            ShowHeader="True" AllowPaging="True" PageSize="20" GridLines="None" PagerStyle-CssClass="paging" OnPageIndexChanging="gvSaMICases_PageIndexChanging">
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="<<" LastPageText=">>"
                                NextPageText=">" PreviousPageText="<" />
                            <Columns>
                                <asp:HyperLinkField HeaderText="Client" DataTextField="FullName" DataNavigateUrlFields="CaseProfileID"
                                    DataNavigateUrlFormatString="View.aspx?ID={0}" />
                                <asp:BoundField DataField="DistrictName" HeaderText="District" />
                                <asp:BoundField DataField="NameOfOpponent" HeaderText="Oponent" />
                                <asp:BoundField DataField="ProblemFaced" HeaderText="Problem Faced" />
                                <asp:BoundField DataField="CaseTypeDesc" HeaderText="Nature of Case" />
                                <asp:BoundField DataField="CaseFollowUpDetail" HeaderText="Service provided" />
                                <asp:BoundField DataField="CaseRegisteredDate" HeaderText="Registered Date" />
                                <asp:BoundField DataField="CaseRegistrarName" HeaderText="Registered At" />
                                <asp:BoundField DataField="CaseNumber" HeaderText="Case Number" />
                                <asp:BoundField DataField="StatusDetail" HeaderText="Status" />
                                <%-- <asp:BoundField DataField="CompenstationDetail" HeaderText="Compensation"/> --%>
                                <asp:HyperLinkField HeaderText="Update" Text="Update" DataNavigateUrlFields="CaseProfileID"
                                    DataNavigateUrlFormatString="Edit.aspx?ID={0}" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            
       </div>
                 </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
