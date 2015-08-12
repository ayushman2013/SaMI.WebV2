<%@ Page Title="" Language="C#" MasterPageFile="~/Trainings.Master" AutoEventWireup="true"
    CodeBehind="EmploymentRegular.aspx.cs" Inherits="SaMI.Web.Training.TrnReport.EmploymentRegular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#ctl00_TrainingBody_txtSearchText').on('keypress', function (e) {
                if (e.keyCode == 13 || e.keyCode == '13') {
                    e.preventDefault();
                    $('#ctl00_TrainingBody_btnSearch').trigger("click");
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TrainingBody" runat="server">

    <div class="col-lg-9">
        <div class="col-md-12 pull-left" style="margin-left: -5px; margin-top: 16px">
            <span class="col-md-3">
                <asp:DropDownList ID="ddlEthnicity" runat="server" CssClass="form-control" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlEthnicity_SelectedIndexChanged">
                </asp:DropDownList>
            </span><span class="col-md-3">
                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                </asp:DropDownList>
            </span><span class="col-md-3">
                <asp:DropDownList ID="ddlTrainingEvent" runat="server" CssClass="form-control" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlTrainingEvent_SelectedIndexChanged">
                </asp:DropDownList>
            </span><span class="col-md-3">
                <asp:Button ID="btnExportEmploymentRegular" runat="server" Text="Export" OnClick="btnExportEmploymentRegular_Click"
                    CssClass="btn btn-primary" />
            </span>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-3 pull-right" style="margin-top: 16px">
                    <div class="col-md-9">
                        <asp:TextBox ID="txtSearchText" runat="server" CssClass="form-control" placeholder="Name/EventId/Batch"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default"
                            OnClick="btnSearch_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="clearfix">
        &nbsp
    </div>
    <div class="clearfix">
        &nbsp
    </div>
    <div class="col-lg-12">
        <asp:CheckBoxList ID="chkOptions" runat="server" OnSelectedIndexChanged="chkOptions_CheckedChanged"
            AutoPostBack="true" RepeatDirection="Horizontal">
        </asp:CheckBoxList>
    </div>
    <h6 class="col-md-2 pull-right" style="margin-top: 10px">No. of Records:
                <asp:Label ID="lblNoOfRecords" runat="server"></asp:Label>
    </h6>
    <div class="col-lg-12" style="margin-top: 8px; margin-left: 0px; overflow:scroll"">
        <asp:Panel runat="server" ID="Panel1">
            <asp:GridView ID="gdvEmploymentRegularReport" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover"
                AllowPaging="true" PageSize="20" OnPageIndexChanging="gdvEmploymentRegularReport_PageIndexChanging"
                ShowHeader="true" ShowHeaderWhenEmpty="true" PagerStyle-CssClass="paging" GridLines="None">
                <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="<<" LastPageText=">>"
                    NextPageText="&gt;" PreviousPageText="<" />
                <Columns>
                    <asp:TemplateField HeaderText="S.N.">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1 %>.
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>
