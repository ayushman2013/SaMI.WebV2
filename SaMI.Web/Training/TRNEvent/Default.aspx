<%@ Page Title="" Language="C#" MasterPageFile="~/Trainings.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SaMI.Web.Training.TRNEvent.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ctl00_TrainingBody_txtStartDate').datepicker();
            $('#ctl00_TrainingBody_txtEndDate').datepicker();
        });

        function ValidateInput() {
            if ($('#ctl00_TrainingBody_ddlTrainingAgency').val() == '0' && ($('#ctl00_TrainingBody_txtBatch').val() == '') && ($('#ctl00_TrainingBody_ddlTradeName').val() == '0')
            && ($('#ctl00_TrainingBody_txtStartDate').val() == '') && ($('#ctl00_TrainingBody_txtEndDate').val() == '')
        )
                return false;
            else
                return true;
        }

        function Reset() {
            $('#ctl00_TrainingBody_ddlTrainingAgency').val() == '0';
            $('#ctl00_TrainingBody_txtBatch').val('');
            $('#ctl00_TrainingBody_txtEventID').val('');
            $('#ctl00_TrainingBody_ddlTradeName').val() == '0';
            $('#ctl00_TrainingBody_txtStartDate').val('');
            $('#ctl00_TrainingBody_txtEndDate').val('');
            $("#ctl00_TrainingBody_chkCostSharing").prop("checked", false);
            $("#ctl00_TrainingBody_chkRegular").prop("checked", false);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TrainingBody" runat="server">


    <div class="col-lg-12 panel-group" id="accordion">

        <div class="panel panel-default">
            <div class="panel-heading">

                <div class="panel-title">
                    <div class="col-lg-2 left">
                        <button type="button" class="btn btn-default" style="margin-top:17px" data-toggle="collapse" data-parent="#accordion" data-target="#eventAdd">Add</button>&nbsp;&nbsp;
                        <button type="button" class="btn btn-default" style="margin-top:17px" data-toggle="collapse" data-parent="#accordion" data-target="#eventList">List</button>
                    </div>
                    <div class="col-lg-10 right">
                        <table>
                            <tr>
                                <td class="col-lg-3">

                                    <asp:DropDownList ID="ddlSearchByTrainingAgency" CssClass="form-control" Style="margin-top:15px"  runat="server" AutoPostBack="True"
                                         OnSelectedIndexChanged="ddlSearchByTrainingAgency_SelectedIndexChanged">
                                    </asp:DropDownList>


                                </td>
                                <td class="col-lg-3">
                                    <asp:DropDownList ID="ddlSearchByTradeName" CssClass="form-control" runat="server" Style="margin-top:15px" AutoPostBack="True" OnSelectedIndexChanged="ddlSearchByTradeName_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                                <td class="col-lg-3">
                                    <asp:RequiredFieldValidator runat="server" ID="SearchID" Font-Size="Smaller" ControlToValidate="txtSearchByEventID" ErrorMessage="Please Enter Event ID"
                                        ToolTip="Event ID"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtSearchByEventID" placeholder="Enter Event ID" CssClass="form-control" runat="server"></asp:TextBox>
                                    
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-default" CausesValidation="true" Style="margin-top:7px" Text="Search" OnClick="btnSearch_Click" /></td>
                                <td class="col-lg-3" style="font-size:14px;">
                                    <asp:Label ID="lblMale" runat="server"></asp:Label> &nbsp; &nbsp; &nbsp;
                                    <asp:Label ID="lblFemale" runat="server"></asp:Label> &nbsp; &nbsp; &nbsp;
                                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>

                      

                    </div>

                </div>
                <div class="clearfix"></div>
            </div>

          </div>
            <div id="eventAdd" class="panel-collapse collapse">
                <div class="col-lg-6">
                    <table class="tab-content">
                        <tr>
                            <td>
                                <label>
                                    Training Agency</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTrainingAgency" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Batch</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBatch" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Event ID</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEventID" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Trade Name</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTradeName" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Start Date</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    End Date</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td>
                                <span>
                                    <asp:CheckBox ID="chkCostSharing" Text="Cost Sharing" runat="server"></asp:CheckBox>
                                </span>&nbsp;&nbsp;&nbsp; <span>
                                    <asp:CheckBox ID="chkRegular" Text=" Regular" runat="server"></asp:CheckBox>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:Button runat="server" Text="Save" ID="btnSave" CssClass="btn btn-default" OnClick="btnSave_Click"
                                    OnClientClick="return ValidateInput();" />
                                &nbsp;&nbsp;
                        <input type="button" value="Reset" onclick="Reset();" class="btn btn-default" />
                            </td>
                        </tr>
                    </table>
                    <div>
                        <br />
                    </div>
                </div>
            </div>

            <div class="col-lg-12 panel-collapse collapse in" id="eventList">
                <div>
                    <br />
                </div>
                <asp:GridView ID="gvTrainingEvent" OnRowCommand="gvTraining_RowCommand" AutoGenerateColumns="false"
                    runat="server" CssClass="table table-striped table-hover">
                    <Columns>
                        <asp:BoundField DataField="TrainingAgency" HeaderText="Training Agency" />
                        <asp:BoundField DataField="Batch" HeaderText="Batch" />
                        <asp:BoundField DataField="EventID" HeaderText="Event ID" />
                        <asp:BoundField DataField="TradeName" HeaderText="Trade Name" />
                        <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:dd-MMM-yyyy}" />
                        <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:dd-MMM-yyyy}" />
                        <asp:BoundField DataField="CostSharing" HeaderText="Cost Sharing" />
                        <asp:BoundField DataField="Regular" HeaderText="Regular" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="EditLinkButton" runat="server" CommandArgument='<%# Eval("ID") %>' Text="Edit" CausesValidation="false"
                                    CommandName="cmdEdit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="AddLinkButton" runat="server" CommandArgument='<%# Eval("ID") %>' CausesValidation="false"
                                    CommandName="cmdAdd" CssClass="glyphicon glyphicon-plus"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandArgument='<%# Eval("ID") %>' Text="Delete" CausesValidation="false"
                                    CommandName="cmdDelete" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
</asp:Content>
