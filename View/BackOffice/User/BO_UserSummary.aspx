<%@ Page Title="" Language="C#" MasterPageFile="~/BO_MasterPage.Master" AutoEventWireup="true" CodeBehind="BO_UserSummary.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.User.BO_UserSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3 ">Staff / Admin Summary</h2>
    <hr />
    <div class="mb-3">
        <div class="input-group float-start w-75 mb-3">
            <div class="form-group">
                <asp:TextBox ID="searchTxt" runat="server" placeholder="Search" OnTextChanged="searchTxt_TextChanged" Style="border: 1px solid #e0e0e0; padding: 6px;"></asp:TextBox>
            </div>
            <button type="button" class="btn btn-primary" onserverclick="searchEv" runat="server">
                <i class="fas fa-search"></i>
            </button>

        </div>
        <div class=" w-25 float-end">
            <asp:HyperLink ID="myHyperLink" runat="server" Text="<i class='fa fa-plus' style='padding-top: 12px'></i>" NavigateUrl="BO_UserNew.aspx" CssClass="btn btn-floating btn-primary float-end"></asp:HyperLink>
        </div>
    </div>
    <div style="height: 490px; width: 100%; border: 1px solid none; overflow: auto; white-space: nowrap;">

        <asp:GridView
            ID="BO_gvUser"
            runat="server"
            Style="text-align: center;"
            AutoGenerateColumns="False"
            DataKeyNames="USERID"
            EmptyDataText="No records found!"
            CellPadding="10" HorizontalAlign="Center" Width="98%" CssClass="table table-striped w-100"
            OnRowDataBound="OnRowDataBound">
            <AlternatingRowStyle CssClass="bg-light" />
            <Columns>

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:HyperLink ID="viewHyperLink" runat="server" ToolTip="View" Text="<i class='fa fa-eye' style='padding-top: 12px'></i>" CssClass="btn btn-floating btn-primary" NavigateUrl='<%# Eval("USERID", "BO_UserView.aspx?userId={0}") %>'></asp:HyperLink>
                        <asp:HyperLink ID="editHyperLink" runat="server" ToolTip="Edit" Text="<i class='fa fa-pen' style='padding-top: 12px'></i>" CssClass="btn btn-floating btn-primary" NavigateUrl='<%# Eval("USERID", "BO_UserEdit.aspx?userId={0}") %>'></asp:HyperLink>
                        <asp:HyperLink ID="activateHyperLink" runat="server" ToolTip="Activate" Text="<i class='fa fa-check' style='padding-top: 12px'></i>" CssClass="btn btn-floating btn-primary" NavigateUrl='<%# Eval("USERID", "BO_UserActivate.aspx?userId={0}") %>'></asp:HyperLink>
                        <asp:HyperLink ID="deactivateHyperLink" runat="server" ToolTip="Deactivate" Text="<i class='fa fa-times' style='padding-top: 12px'></i>" CssClass="btn btn-floating btn-primary" NavigateUrl='<%# Eval("USERID", "BO_UserDeactivate.aspx?userId={0}") %>'></asp:HyperLink>

                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="NAME" HeaderText="Name" SortExpression="NAME" />
                <asp:BoundField DataField="USERNAME" HeaderText="Username" SortExpression="USERNAME" />
                <asp:BoundField DataField="PHONE" HeaderText="Phone" SortExpression="PHONE" />
                <asp:BoundField DataField="STATUS" HeaderText="Status" SortExpression="STATUS" />
                <asp:BoundField DataField="USERGROUPNAME" HeaderText="Usergroup" SortExpression="USERGROUPNAME" />
                <asp:BoundField DataField="MAIL" HeaderText="Mail" SortExpression="MAIL" />
                <asp:BoundField DataField="CREATEDDATE" HeaderText="Created Date" SortExpression="CREATEDDATE" />
                <asp:BoundField DataField="CREATEDBY" HeaderText="Created By" SortExpression="CREATEDBY" />
                <asp:BoundField DataField="UPDATEDDATE" HeaderText="Updated Date" SortExpression="UPDATEDDATE" />
                <asp:BoundField DataField="UPDATEDBY" HeaderText="Updated By" SortExpression="UPDATEDBY" />
            </Columns>

        </asp:GridView>
    </div>

    <script type="text/javascript">

        function unauthorized(url) {
            Swal.fire({
                position: 'center',
                icon: 'error',
                title: 'Sorry',
                text: "You have no access to this page.",
                showConfirmButton: true,
            }).then(function () {
                location.href = url;
            });
        }

    </script>

</asp:Content>
