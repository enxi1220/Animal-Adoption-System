<%@ Page Title="" Language="C#" MasterPageFile="~/BO_MasterPage.Master" AutoEventWireup="true" CodeBehind="BO_EuthanasiaSummary.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Euthanasia.BO_EuthanasiaSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="margin-top:0.5em;">Euthanasia Summary</h2>
    <hr />
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
            height:40px;
            border-radius: 0.25rem;
        }

        div.search button {
            float: left;
            width: 20%;
            height:40px;
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

        a.plus{
            float: right;
            width:41px;
            height:50px;
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

    <!--
    <div class="search" action="/action_page.php" style="max-width: 400px;  float:left; margin-top: 2em; margin-bottom: 2em;">
        <asp:TextBox ID="searchTxt1" runat="server" placeholder="Search by Euthanasia No" OnTextChanged="searchTxt_TextChanged" ></asp:TextBox>
        <button type="button" onserverclick="searchEv" runat="server"><i class="fa fa-search"></i></button>
    </div>
    -->

    
    
    <div class="input-group float-start w-75 mb-3" style="margin-top:2em;">
            <div class="form-group ms-3">
                <asp:TextBox ID="searchTxt" runat="server" placeholder="Search by Euthanasia No" OnTextChanged="searchTxt_TextChanged" style="border: 1px solid #e0e0e0; padding: 6px;"></asp:TextBox>    
            </div>
            <button type="button" class="btn btn-primary" onserverclick="searchEv" runat="server">
                <i class="fas fa-search"></i>
            </button>
        </div>

    <div class=" w-25 float-end" style="margin-top: 2em; ">
            <asp:HyperLink ID="HyperLink" runat="server" NavigateUrl="BO_EuthanasiaNew.aspx" Text="<i class='fa fa-plus' style='padding-top: 12px'></i>" CssClass="btn btn-primary btn-floating float-end "></asp:HyperLink>
        </div>
   
    <div style="width:100%; border:1px solid grey; overflow:auto; white-space:nowrap;">
        <asp:GridView ID="GridView2" runat="server" emptyDataText="No records found!" CssClass="table table-striped w-100"  CellPadding="10" HorizontalAlign="Center"  Width="98%" style="text-align: center;" AutoGenerateColumns="False">
            <AlternatingRowStyle CssClass="bg-light" />
            <Columns>
               
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                    <asp:HyperLink ID="HyperLink2" runat="server" ToolTip="View" Text="<i class='fa fa-eye' style='padding-top: 12px'></i>" CssClass="btn btn-floating btn-primary" NavigateUrl='<%# Eval("EUTHANASIAID", "BO_EuthanasiaView.aspx?euthanasiaId={0}") %>'></asp:HyperLink>
                    <asp:HyperLink ID="HyperLink3" runat="server" ToolTip="Edit" Text="<i class='fa fa-pen' style='padding-top: 12px'></i>" CssClass="btn btn-floating btn-primary" NavigateUrl='<%# Eval("EUTHANASIAID", "BO_EuthanasiaEdit.aspx?euthanasiaId={0}") %>'></asp:HyperLink>
                    </ItemTemplate>

                </asp:TemplateField>
            
            <asp:BoundField DataField="EUTHANASIANO" HeaderText="Euthanasia No" SortExpression="EUTHANASIANO" />
                <asp:BoundField DataField="PETID" HeaderText="Pet ID" SortExpression="PETID" />
                <asp:BoundField DataField="DESC" HeaderText="Description" SortExpression="DESC" />
                <asp:BoundField DataField="DOSE" HeaderText="Dose" SortExpression="DOSE" />
                <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM" />
                <asp:BoundField DataField="MEDICINE" HeaderText="Medicine" SortExpression="MEDICINE" />
                <asp:BoundField DataField="STATUS" HeaderText="Status" SortExpression="STATUS" />
            <asp:BoundField DataField="EXECUTIONDATE" HeaderText="Execution Date" SortExpression="EXECUTIONDATE" />
                <asp:BoundField DataField="CREATEDDATE" HeaderText="Created Date" SortExpression="CREATEDDATE" />
                <asp:BoundField DataField="CREATEDBY" HeaderText="Created By" SortExpression="CREATEDBY" />
                <asp:BoundField DataField="UPDATEDDATE" HeaderText="Updated Date" SortExpression="UPDATEDDATE" />
            <asp:BoundField DataField="UPDATEDBY" HeaderText="Updated By" SortExpression="UPDATEDBY" />
       </Columns>
        
        </asp:GridView>
    </div>

</asp:Content>
