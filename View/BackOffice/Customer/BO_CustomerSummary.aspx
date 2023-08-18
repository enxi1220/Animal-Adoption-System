<%@ Page Title="" Language="C#" MasterPageFile="~/BO_MasterPage.Master" AutoEventWireup="true" CodeBehind="BO_CustomerSummary.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Customer.BO_CustomerSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3 ">Customer Summary</h2>
    <hr />
    <div class="mb-3">
        <div class="input-group float-start w-75 mb-3">
            <div class="form-group">
                <asp:TextBox ID="searchTxt" runat="server" placeholder="Search by Username" OnTextChanged="searchTxt_TextChanged" CssClass="form-control border"></asp:TextBox>
            </div>
            <button type="button" class="btn btn-primary" onserverclick="searchEv" runat="server">
                <i class="fas fa-search"></i>
            </button>
        </div>
    </div>
    <div style="height: 490px; width: 100%; border: 1px solid none; overflow: auto; white-space: nowrap;">
    <asp:GridView
        ID="BO_gvCust"
        runat="server"
        CellPadding="10"
        AllowSorting="True"
        AutoGenerateColumns="False"
        EmptyDataText="No record found."
        DataKeyNames="CUSTOMERID"
        CssClass="table table-striped w-100">
        <AlternatingRowStyle CssClass="bg-light" />
        <Columns>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" ToolTip="View" Text="<i class='fa fa-eye' style='padding-top: 12px'></i>" CssClass="btn btn-floating btn-primary" NavigateUrl='<%# Eval("CUSTOMERID", "BO_CustomerView.aspx?customerId={0}") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>

                <asp:BoundField
                    DataField="USERNAME"
                    HeaderText="Username"
                    SortExpression="USERNAME" />
                <asp:BoundField
                    DataField="NAME"
                    HeaderText="Name"
                    SortExpression="NAME" />
                <asp:BoundField
                    DataField="STATUS"
                    HeaderText="Status"
                    SortExpression="STATUS" />
                <asp:BoundField
                    DataField="MAIL"
                    HeaderText="Mail"
                    SortExpression="MAIL" />
                <asp:BoundField
                    DataField="CREATEDDATE"
                    HeaderText="Created Date"
                    SortExpression="CREATEDDATE" />
                <asp:BoundField
                    DataField="CREATEDBY"
                    HeaderText="Created By"
                    SortExpression="CREATEDBY" />
                <asp:BoundField
                    DataField="UPDATEDDATE"
                    HeaderText="Updated Date"
                    SortExpression="UPDATEDDATE" />
                <asp:BoundField
                    DataField="UPDATEDBY"
                    HeaderText="Updated By"
                    SortExpression="UPDATEDBY" />
            </Columns>

            <HeaderStyle CssClass="border-bottom"></HeaderStyle>
        </asp:GridView>
        <asp:SqlDataSource ID="CustomerGetFull" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [USERNAME], [NAME], [STATUS], [MAIL], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY], [CUSTOMERID] FROM [CUSTOMER]"></asp:SqlDataSource>
    </div>
</asp:Content>
