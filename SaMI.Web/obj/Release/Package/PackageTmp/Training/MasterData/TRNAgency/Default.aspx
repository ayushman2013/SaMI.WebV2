<%@ Page Title="" Language="C#" MasterPageFile="~/Trainings.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SaMI.Web.Training.MasterData.TRNAgency.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ValidateInput() {
            if (($('#ctl00_TrainingBody_txtTrainingAgency').val() == '') && ($('#ctl00_TrainingBody_txtAddress').val() == '')
            && ($('#ctl00_TrainingBody_txtPhone').val() == '') && ($('#ctl00_TrainingBody_txtContactPerson').val() == '')
        )
                return false;
            else
                return true;
        }

        function Reset() {
            $('#ctl00_TrainingBody_txtTrainingAgency').val('');
            $('#ctl00_TrainingBody_txtAddress').val('');
            $('#ctl00_TrainingBody_txtPhone').val('');
            $('#ctl00_TrainingBody_txtContactPerson').val('');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TrainingBody" runat="server">
    <div class="col-lg-12 panel-group" id="accordion">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion" data-target="#addTrainingAgency">Add Training Agency</button>
                    <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion" data-target="#listTrainingAgency">Training Agency List</button>
                </h4>
            </div>

            <div id="addTrainingAgency" class="panel-collapse collapse <% if (collapse == 0) { Response.Write(valueIn); } %>">
                <table>
                    <tr>
                        <td>
                            <label>
                                Training Agency</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTrainingAgency" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                Address</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                Phone</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                Contact Person</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactPerson" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                            <%--<asp:Label ID="lblMessage" runat="server"></asp:Label>--%>
                        </td>
                        <td>
                            <asp:Button runat="server" Text="Save" ID="btnSave" CssClass="btn btn-default" OnClick="btnSave_Click"
                                OnClientClick="return ValidateInput();" />
                            <input type="button" value="Reset" onclick="Reset();" class="btn btn-default" />
                        </td>
                    </tr>
                </table>
                <div>
                    <br />
                </div>
            </div>

            <div id="listTrainingAgency" class="panel-collapse collapse <% if (collapse == 1) { Response.Write(valueIn); } %>">
                <div>
                    <br />
                </div>
                <asp:GridView ID="gvTrainingAgency" OnRowCommand="gvTrainingAgency_RowCommand" AutoGenerateColumns="false"
                    runat="server" CssClass="table table-striped table-hover">
                    <Columns>

                        <asp:BoundField DataField="TrainingAgency" HeaderText="Training Agency" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" />
                        <asp:BoundField DataField="ContactPerson" HeaderText="Contact Person" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditLinkButton" runat="server" CommandArgument='<%# Eval("ID") %>'
                                    CommandName="cmdEdit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandArgument='<%# Eval("ID") %>'
                                    CommandName="cmdDelete" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
