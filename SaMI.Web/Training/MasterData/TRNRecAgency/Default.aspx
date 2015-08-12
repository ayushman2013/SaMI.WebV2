<%@ Page Title="" Language="C#" MasterPageFile="~/Trainings.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SaMI.Web.Training.MasterData.TRNRecAgency.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ValidateInput() {
            if ($('#ctl00_TrainingBody_txtRecruitmentAgency').val() == '')
                return false;
            else
                return true;
        }

        function Reset() {
            $('#ctl00_TrainingBody_txtRecruitmentAgency').val('');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TrainingBody" runat="server">
   
 <div class="col-lg-12 panel-group" id="accordion"> 
    <div class="panel panel-default">
            <div class="panel-heading">
            <h4 class="panel-title">                     
                <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion" data-target="#addRecruitmentAgency">Add New Recruitment Agency</button>
                <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion"  data-target="#listRecruitmentAgency">Recruitment Agency List</button>
            </h4>
        </div>
        
        <div id="addRecruitmentAgency" class="panel-collapse collapse <% if (collapse == 0) { Response.Write(valueIn); } %>">
        <div class="col-lg-6">
            <table>
                <tr>
                    <td>
                        <label>
                            Recruitment Agency</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRecruitmentAgency" runat="server" CssClass="form-control"></asp:TextBox>
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
    </div>
        
        <div id="listRecruitmentAgency" class="panel-collapse collapse <% if (collapse == 1) { Response.Write(valueIn); } %>">
        <asp:GridView ID="gvRecAgency" OnRowCommand="gvRecAgency_RowCommand" AutoGenerateColumns="false"
            runat="server" CssClass="table table-striped table-hover">
            <Columns>
                <asp:BoundField DataField="RecruitmentAgency" HeaderText="Recruitment Agency" />
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
