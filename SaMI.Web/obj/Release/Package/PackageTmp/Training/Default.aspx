<%@ Page Title="" Language="C#" MasterPageFile="~/Trainings.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SaMI.Web.Training.Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $('#ctl00_TrainingBody_txtSearchText').bind('keypress', function (e) {
            if (e.keyCode == 13) {
                $('#ctl00_TrainingBody_btnSearch').focus();
                $('#ctl00_TrainingBody_btnSearch').click();
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TrainingBody" runat="server">
  
            <div class="col-md-12" style="margin-top: -10px">
                <span class="col-md-3">
                <h2>Trainee List</h2>
                
                </span>
                <span class="col-md-3" style="margin-left:460px; margin-top:20px">
                            <asp:TextBox ID="txtSearchText" runat="server" CssClass="form-control" placeholder="EventId/Batch/Name/Ethnicity/District/Trade"></asp:TextBox>
                        </span><span class="col-md-1" style="margin-top:20px">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default"
                                OnClick="btnSearch_Click" /></span>
            </div>
            <div class="clearfix"> &nbsp;</div>
            <div class="container">
                <div class="row">
                    <div class="col-md-12 pull-right">
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
                            <asp:DropDownList ID="ddlTrainingEvent" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlTrainingEvent_SelectedIndexChanged">
                            </asp:DropDownList>
                        </span><span class="col-md-2">
                            <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged">
                            </asp:DropDownList>
                        </span><span class="col-md-2">
                        <asp:Button ID="btnExportEmploymentRegular" runat="server" Text="Export" OnClick="btnExportEmploymentRegular_Click"
                    CssClass="btn btn-primary" />
                        </span>
                    </div>
                </div>
            </div>
            <div class="clearfix">
                &nbsp</div>
            <div class="clearfix">
                &nbsp</div>
            <h6 class="col-md-2 pull-right" style="margin-top: 10px">
                No. of Records:
                <asp:Label ID="lblNoOfRecords" runat="server"></asp:Label>
            </h6>
            <div class="col-md-12">
                <asp:GridView ID="gvTraineeProfile" runat="server" AutoGenerateColumns="False" OnRowCommand="gvTraineeProfile_RowCommand"
                    CssClass="table table-striped table-hover" ShowHeaderWhenEmpty="True" ShowHeader="True"
                    AllowPaging="True" PageSize="20" GridLines="None" PagerStyle-CssClass="paging"
                    OnPageIndexChanging="gvTraineeProfile_PageIndexChanging">
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="<<" LastPageText=">>"
                        NextPageText="&gt;" PreviousPageText="<" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.N.">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField HeaderText="Name" DataTextField="Name" DataNavigateUrlFields="ID"
                            DataNavigateUrlFormatString="View.aspx?ID={0}" />
                        <asp:BoundField DataField="TrainingAgency" HeaderText="Training Agency" />
                        <asp:BoundField DataField="EventID" HeaderText="Event ID" />
                        <asp:BoundField DataField="Batch" HeaderText="Batch" />
                        <asp:BoundField DataField="EthnicityName" HeaderText="Ethnicity" />
                        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                        <asp:BoundField DataField="DistrictName" HeaderText="District" />
                        <asp:BoundField DataField="FullName" HeaderText="Created By" />
                        
                        <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" DataFormatString="{0:dd-MMM-yyyy}" />
                        <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="Edit.aspx?ID={0}" 
                            Text="Edit"/>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandArgument='<%# Eval("ID") %>'  Text="Delete"
                                    CommandName="cmdDelete" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
