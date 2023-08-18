<%@ Page Title="" Language="C#" MasterPageFile="~/BO_MasterPage.Master" AutoEventWireup="true" CodeBehind="BO_CustomerView.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Customer.BO_CustomerView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3 ">View  Customer</h2>
    <hr />
    <asp:DetailsView ID="BO_dvCust" runat="server" CssClass="w-100"
        AutoGenerateRows="False" DataSourceID="CustomerGet" GridLines="None" AlternatingRowStyle-CssClass="bg-light" CellPadding="10">
        <AlternatingRowStyle CssClass="bg-light"></AlternatingRowStyle>
        <Fields>

            <asp:ImageField DataImageUrlField="IMAGE" HeaderText="Image" ReadOnly="True" ControlStyle-Height="300" ControlStyle-Width="360">
                <ControlStyle Height="300px" Width="360px" CssClass="img-fluid"></ControlStyle>
            </asp:ImageField>
            <asp:BoundField DataField="USERNAME" runat="server" HeaderText="Username" SortExpression="USERNAME" ReadOnly="True" />
            <asp:BoundField DataField="NAME" HeaderText="Name" SortExpression="NAME" ReadOnly="True" />
            <asp:BoundField DataField="PHONE" HeaderText="Phone" SortExpression="PHONE" ReadOnly="True" />
            <asp:BoundField DataField="MAIL" HeaderText="Mail" SortExpression="MAIL" ReadOnly="True" />
            <asp:BoundField DataField="STATUS" HeaderText="Status" ReadOnly="True" />

        </Fields>
        <HeaderStyle CssClass="border-bottom" />
        <HeaderTemplate runat="server">
            
        </HeaderTemplate>
        <RowStyle Font-Bold="True" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="CustomerGet" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [USERNAME], [STATUS], [NAME], [PHONE], [MAIL], [IMAGE] FROM [CUSTOMER] WHERE ([CUSTOMERID] = @CUSTOMERID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="CUSTOMERID" QueryStringField="customerId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
