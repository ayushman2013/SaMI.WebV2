<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="SaMI.Web.DashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" src="assets/js/JScriptLoad.js"></script>

<div style="margin-top: 200px">
        <div class="clearfix">
        </div>
        <div class="col-lg-12">
            <div class="col-lg-4" style="margin-left:60px">
                <asp:Button ID="btnICC" runat="server" CssClass="btn btn-default" Text="Information and Counselling Services" OnClick="btnICC_Click"
                OnClientClick="return Load();" />
            </div>
            <div class="col-lg-3">
                <asp:Button ID="btnSkillandEmployment" runat="server" CssClass="btn btn-default"
                    Text="Skill and Employment" OnClick="btnSkillandEmployment_Click" OnClientClick="return Load();"/>
            </div>
            <div class="col-lg-4">
                <asp:Button ID="btnFreeLegalAidClinic" runat="server" CssClass="btn btn-default"
                    Text="Free Legal Aid Clinic"  OnClick="btnFreeLegalAidClinic_Click" OnClientClick="return Load();"/>
            </div>
        </div>
    </div>

    <div class="modal fade" id="divLoading" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    <div id="divProgressBarText">
                        <img src="../images/loading.gif" alt="" style="margin-right: 10px;" />
                        <strong>Loading Please Wait.........</strong>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);

        function BeginRequestHandler(sender, args) {
           
        }

        function EndRequestHandler(sender, args) {
            $('#divLoading').modal('hide')
        }
    </script>

</asp:Content>
