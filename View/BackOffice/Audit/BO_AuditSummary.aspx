<%@ Page Title="" Language="C#" MasterPageFile="~/BO_MasterPage.Master" AutoEventWireup="true" CodeBehind="BO_AuditSummary.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Audit.BO_AuditSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3 ">Audit Summary</h2>
    <hr />
    <div class="mb-3">
        <div class="input-group float-start w-75 mb-3">
            <div class="form-group">
                <asp:TextBox ID="searchTxt" runat="server" placeholder="Search by Audit No" OnTextChanged="searchTxt_TextChanged" CssClass="form-control border"></asp:TextBox>
            </div>
            <button type="button" class="btn btn-primary" onserverclick="searchEv" runat="server">
                <i class="fas fa-search"></i>
            </button>
        </div>
        <div class=" w-25 float-end mb-3">
            <asp:HyperLink ID="HyperLink1" runat="server" ToolTip="New" NavigateUrl="BO_AuditNew.aspx" CssClass="btn btn-floating btn-primary float-end" Text="<i class='fa fa-plus' style='padding-top: 12px'></i>"></asp:HyperLink>
        </div>
    </div>
    <div style="height: 490px; width: 100%; border: 1px solid none; overflow: auto; white-space: nowrap;">
        <asp:GridView ID="GridView1" runat="server"
            CssClass="table table-striped w-100"
            AutoGenerateColumns="False"
            EmptyDataText="No record found."
            DataKeyNames="AUDITID"
            AllowSorting="True"
            >
            <AlternatingRowStyle CssClass="bg-light" />
            <Columns>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" ToolTip="View" Text="<i class='fa fa-eye' style='padding-top: 12px'></i>" CssClass="btn btn-floating btn-primary" NavigateUrl='<%# Eval("AUDITID", "BO_AuditView.aspx?auditId={0}") %>'></asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" ToolTip="Edit" Text="<i class='fa fa-pen' style='padding-top: 12px'></i>" CssClass="btn btn-floating btn-primary" NavigateUrl='<%# Eval("AUDITID", "BO_AuditEdit.aspx?auditId={0}") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField
                    DataField="AUDITNO"
                    HeaderText="Audit No."
                    SortExpression="AUDITNO" />
                <asp:BoundField
                    DataField="PETNO"
                    HeaderText="Pet No."
                    SortExpression="PETNO" />
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
                <asp:BoundField
                    DataField="UPDATEDBY"
                    HeaderText="Updated By"
                    SortExpression="UPDATEDBY" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
