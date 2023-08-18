<%@ Page Title="" Language="C#" MasterPageFile="~/BO_MasterPage.Master" AutoEventWireup="true" CodeBehind="BO_UserEdit.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Customer.BO_CustomerSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView 
        ID="BO_UserEdit" 
        runat="server" 
        CellPadding="10" 
        AllowSorting="True" 
        AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" 
        DataKeyNames="USERID" 
        Width="1300px" 
        CssClass="m-3" AllowPaging="True">
        <AlternatingRowStyle CssClass="bg-light" />
        <Columns>
            
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField 
                DataField="USERID" 
                HeaderText="USERID" 
                SortExpression="USERID" InsertVisible="False" ReadOnly="True" />
            <asp:BoundField 
                DataField="USERNAME" 
                HeaderText="USERNAME" 
                SortExpression="USERNAME" />
            <asp:BoundField 
                DataField="STATUS" 
                HeaderText="STATUS" 
                SortExpression="STATUS" />
            <asp:BoundField 
                DataField="NAME" 
                HeaderText="NAME" 
                SortExpression="NAME" />
            <asp:BoundField 
                DataField="PHONE" 
                HeaderText="PHONE" 
                SortExpression="PHONE" />
            <asp:BoundField 
                DataField="MAIL" 
                HeaderText="MAIL" 
                SortExpression="MAIL" 
                
            />
            <asp:BoundField 
                DataField="USERGROUPNAME" 
                HeaderText="USERGROUPNAME" 
                SortExpression="USERGROUPNAME" />
        </Columns>

        <HeaderStyle CssClass="border-bottom"></HeaderStyle>
    </asp:GridView>
    <br />
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [USER] WHERE [USERID] = @USERID" InsertCommand="INSERT INTO [USER] ([USERNAME], [STATUS], [NAME], [PHONE], [MAIL], [USERGROUPNAME]) VALUES (@USERNAME, @STATUS, @NAME, @PHONE, @MAIL, @USERGROUPNAME)" SelectCommand="SELECT [USERID], [USERNAME], [STATUS], [NAME], [PHONE], [MAIL], [USERGROUPNAME] FROM [USER]" UpdateCommand="UPDATE [USER] SET [USERNAME] = @USERNAME, [STATUS] = @STATUS, [NAME] = @NAME, [PHONE] = @PHONE, [MAIL] = @MAIL, [USERGROUPNAME] = @USERGROUPNAME WHERE [USERID] = @USERID">
    <DeleteParameters>
        <asp:Parameter Name="USERID" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="USERNAME" Type="String" />
        <asp:Parameter Name="STATUS" Type="String" />
        <asp:Parameter Name="NAME" Type="String" />
        <asp:Parameter Name="PHONE" Type="String" />
        <asp:Parameter Name="MAIL" Type="String" />
        <asp:Parameter Name="USERGROUPNAME" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="USERNAME" Type="String" />
        <asp:Parameter Name="STATUS" Type="String" />
        <asp:Parameter Name="NAME" Type="String" />
        <asp:Parameter Name="PHONE" Type="String" />
        <asp:Parameter Name="MAIL" Type="String" />
        <asp:Parameter Name="USERGROUPNAME" Type="String" />
        <asp:Parameter Name="USERID" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
</asp:Content>
