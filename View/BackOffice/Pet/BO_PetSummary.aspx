<%@ Page Title="" Language="C#" MasterPageFile="~/BO_MasterPage.Master" AutoEventWireup="true" CodeBehind="BO_PetSummary.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Pet.BO_PetSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3 ">Pet Summary</h2>
    <hr />
    <div class="mb-3">
        <div class="input-group float-start w-75 mb-3">
            <div class="form-group">
                <asp:TextBox ID="search" runat="server" placeHolder="Search by Pet No" OnTextChanged="searchPet_TextChanged"  CssClass="form-control border"></asp:TextBox>
            </div>
            <button type="button" class="btn btn-primary" onserverclick="searchPet" runat="server">
                <i class="fas fa-search"></i>
            </button>
        </div>
        <div class=" w-25 float-end mb-3">
            <asp:HyperLink ID="HyperLink6" runat="server" ToolTip="New" NavigateUrl="BO_PetNew.aspx" CssClass="btn btn-floating btn-primary float-end" Text="<i class='fa fa-plus' style='padding-top: 12px'></i>"></asp:HyperLink>
            <%--<asp:HyperLink ID="HyperLink1" runat="server" Text="<i class='fa fa-plus' style='padding-top: 12px'></i>" NavigateUrl="BO_PetNew.aspx" CssClass="btn btn-floating btn-primary float-end"></asp:HyperLink>--%>
        </div>
    </div>
    <div style="height: 490px; width: 100%; border: 1px solid none; overflow: auto; white-space: nowrap;">
        <asp:GridView ID="GridView1" runat="server"
            CssClass="table table-striped w-100"
            AutoGenerateColumns="False"
            EmptyDataText="No record found."
            DataKeyNames="PETID"
            AllowSorting="True">
            <AlternatingRowStyle CssClass="bg-light" />
            <Columns>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" ToolTip="View" Text="<i class='fa fa-eye' style='padding-top: 12px'></i>" CssClass="btn btn btn-floating btn-primary" NavigateUrl='<%# Eval("PETID", "BO_PetView.aspx?petId={0}") %>'></asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" ToolTip="Edit" Text="<i class='fa fa-pen' style='padding-top: 12px'></i>" CssClass="btn btn btn-floating btn-primary" NavigateUrl='<%# Eval("PETID", "BO_PetEdit.aspx?petId={0}") %>'></asp:HyperLink>
                        <asp:HyperLink ID="HyperLink4" runat="server" ToolTip="Activate" Text="<i class='fa fa-check' style='padding-top: 12px'></i>" CssClass="btn btn btn-floating btn-primary" NavigateUrl='<%# Eval("PETID", "BO_PetActivate.aspx?petId={0}") %>'></asp:HyperLink>
                        <asp:HyperLink ID="HyperLink5" runat="server" ToolTip="Deactivate" Text="<i class='fa fa-times' style='padding-top: 12px'></i>" CssClass="btn btn btn-floating btn-primary" NavigateUrl='<%# Eval("PETID", "BO_PetDeactivate.aspx?petId={0}") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField
                    DataField="PETNO"
                    HeaderText="Pet No."
                    SortExpression="PETNO" />
                <asp:BoundField
                    DataField="NAME"
                    HeaderText="Name"
                    SortExpression="NAME" />
                <asp:BoundField
                    DataField="BREED"
                    HeaderText="Breed"
                    SortExpression="BREED" />
                <asp:BoundField
                    DataField="STATUS"
                    HeaderText="Status"
                    SortExpression="STATUS" />
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
                <asp:BoundField DataField="UPDATEDBY"
                    HeaderText="Updated By"
                    SortExpression="UPDATEDBY" />
            </Columns>
        </asp:GridView>
    </div>
    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [PETID], [PETNO], [BREED], [NAME], [STATUS], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY] FROM [PET]"></asp:SqlDataSource>--%>
</asp:Content>
