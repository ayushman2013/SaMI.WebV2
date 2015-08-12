<%@ Page Title="" Language="C#" MasterPageFile="~/Trainings.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SaMI.Web.Training.MasterData.TRNEmpType.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function ValidateInput() {
            if (($('#ctl00_TrainingBody_txtEmploymentType').val() == ''))
                return false;
            else
                return true;
        }

        function Reset() {
            $('#ctl00_TrainingBody_txtEmploymentType').val('');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TrainingBody" runat="server">

    <div class="col-lg-12 panel-group" id="accordion">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion" data-target="#addEmploymentType">Add Employment Type</button>
                    <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion" data-target="#listEmploymentType">Employment Type List</button>
                </h4>
            </div>
            <div id="addEmploymentType" class="panel-collapse collapse <% if (collapse == 0) { Response.Write(valueIn); } %>">
                <table>
                    <tr>
                        <td>
                            <label>
                                Employment Type</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmploymentType" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:Button runat="server" Text="Save" ID="btnSave" CssClass="btn btn-default" OnClick="btnSave_Click"
                                OnClientClick="return ValidateInput();" />
                            <input type="button" value="Reset" onclick="Reset();" class="btn btn-default" />
                        </td>
                    </tr>
                </table>
                 <div><br /></div>
            </div>

            <div id="listEmploymentType" class="panel-collapse collapse <% if (collapse==1) { Response.Write(valueIn); } %>">
                <div>
                    <br />
                </div>
                <asp:GridView ID="gvEmploymentType" OnRowCommand="gvEmploymentType_RowCommand" AutoGenerateColumns="false"
                    runat="server" CssClass="table table-striped table-hover">
                    <Columns>
                        <asp:BoundField DataField="EmploymentType" HeaderText="Employment Type" />
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
