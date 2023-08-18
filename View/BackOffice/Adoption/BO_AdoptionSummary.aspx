<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BO_MasterPage.Master" CodeBehind="BO_AdoptionSummary.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Adoption.BO_AdoptionSummary1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="margin-top: 0.5em;">Adoption Summary</h2>
    <hr />
    <%--search--%>
    <style>
        * {
            box-sizing: border-box;
        }


        div.search input[type=text] {
            padding: 10px;
            font-size: 17px;
            border: 1px solid #e0e0e0;
            float: left;
            width: 80%;
            height: 50px;
            border-radius: 0.25rem;
        }

        div.search button {
            float: left;
            width: 20%;
            height: 50px;
            padding: 10px;
            background-color: #be98aa;
            color: white;
            font-size: 17px;
            border: 0.125rem solid transparent;
            border-left: none;
            cursor: pointer;
            border-radius: 0.25rem;
            transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
            box-shadow: 0 2px 5px 0 rgb(0 0 0 / 20%), 0 2px 10px 0 rgb(0 0 0 / 10%);
        }

        a.plus {
            float: right;
            width: 41px;
            height: 50px;
            padding: 10px;
            background-color: #be98aa;
            color: white;
            font-size: 17px;
            border: 0.125rem solid transparent;
            border-left: none;
            cursor: pointer;
            border-radius: 0.25rem;
            transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
            box-shadow: 0 2px 5px 0 rgb(0 0 0 / 20%), 0 2px 10px 0 rgb(0 0 0 / 10%);
        }

        div.search button:hover, a.plus:hover {
            color: black;
            background: #f8f4ed;
        }

        div.search::after, a.plus::after {
            content: "";
            clear: both;
            display: table;
        }
    </style>

    <div class="input-group float-start w-75 mb-3" style="margin-top: 2em;">
        <div class="form-group ms-3">
            <asp:TextBox ID="searchTxt" runat="server" placeholder="Search by Adoption No" OnTextChanged="searchTxt_TextChanged" Style="border: 1px solid #e0e0e0; padding: 6px;"></asp:TextBox>
        </div>
        <button type="button" class="btn btn-primary" onserverclick="searchEv" runat="server">
            <i class="fas fa-search"></i>
        </button>
    </div>

    <div style="height: 490px; width: 100%; border: 1px solid none; overflow: auto; white-space: nowrap;">
        <asp:GridView ID="adoptionGV" 
            CssClass="table table-striped w-100" 
            runat="server" 
            EmptyDataText="No record found." 
            CellPadding="10" 
            HorizontalAlign="Center" 
            AutoGenerateColumns="False">
            <AlternatingRowStyle CssClass="bg-light" />

            <Columns>

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <h5>
                            <asp:HyperLink ID="HyperLink2" runat="server" ToolTip="View" Text="<i class='fa fa-eye' style='padding-top: 12px'></i>" CssClass="btn btn-floating btn-primary" NavigateUrl='<%# Eval("ADOPTIONID", "BO_AdoptionView.aspx?adoptionId={0}") %>'></asp:HyperLink>
                            <asp:HyperLink ID="HyperLink3" runat="server" ToolTip="Edit" Text="<i class='fa fa-pen' style='padding-top: 12px'></i>" CssClass="btn btn-floating btn-primary" NavigateUrl='<%# Eval("ADOPTIONID", "BO_AdoptionApproval.aspx?adoptionId={0}") %>'></asp:HyperLink>
                        </h5>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField
                    DataField="ADOPTIONNO"
                    HeaderText="Adoption No"
                    SortExpression="ADOPTIONNO" />
                <asp:BoundField
                    DataField="PETNO"
                    HeaderText="Pet No."
                    SortExpression="PETNO" />
                <asp:BoundField
                    DataField="USERNAME"
                    HeaderText="Username"
                    SortExpression="USERNAME" />
                <asp:BoundField
                    DataField="STATUS"
                    HeaderText="Status"
                    SortExpression="STATUS" />
                <asp:BoundField
                    DataField="REASONOFREJECTION"
                    HeaderText="Reject Reason"
                    SortExpression="REASONOFREJECTION" />
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

