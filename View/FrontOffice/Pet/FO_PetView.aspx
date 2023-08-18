<%@ Page Title="" Language="C#" MasterPageFile="~/FO_MasterPage.Master" AutoEventWireup="true" CodeBehind="FO_PetView.aspx.cs" Inherits="AnimalAdoptionSystem.View.FrontOffice.Pet.FO_PetView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin-right: 283px;
        }

        .fixed-container {
            width: 1320px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-3 p-5 petBg">

        <div class="container justify-content-center">
            <div class="row">
                <div class="col-md-6 text-center bg-white p-0">
                    <asp:Image ID="pViewImg" runat="server" Height="300" Width="380" CssClass="img-fluid" Style="object-fit: scale-down" />
                </div>

                
                <div class="col-md-6 ps-5 pt-5" style="text-align: justify;">
                    <h3 ><asp:Label ID="pViewName" runat="server"></asp:Label></h3>
                    <hr class="mb-5"/>
                    <asp:Literal ID="pViewDesc" runat="server"></asp:Literal>
                </div>

            </div>
        </div>


        <div class="container justify-content-center rounded-3">
            <div class="row rounded-3">
                <div class="col-md-6 p-0 shadow-1">
                    <asp:DetailsView ID="DetailsView1" runat="server" Height="190px" Width="660px" AutoGenerateRows="False" CellPadding="4" CssClass="auto-style2" DataSourceID="SqlDataSource1" ForeColor="#465E65" GridLines="None" DataKeyNames="PETID" >
                        <AlternatingRowStyle BackColor="White" />
                        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FieldHeaderStyle BackColor="#E7C4B6 " Font-Bold="True" />
                        <Fields>
                            
                            <asp:BoundField DataField="NAME" HeaderText="Name" SortExpression="NAME" />
                            <asp:BoundField DataField="AGE" HeaderText="Age" SortExpression="AGE" />
                            <asp:BoundField DataField="SIZE" HeaderText="Size" SortExpression="SIZE" />
                            <asp:BoundField DataField="GENDER" HeaderText="Gender" ReadOnly="True" SortExpression="GENDER" />
                            <asp:BoundField DataField="BREED" HeaderText="Breed" SortExpression="BREED" />
                            <asp:BoundField DataField="TYPE" HeaderText="Type" SortExpression="TYPE" />
                            <asp:BoundField DataField="AUDITPERIOD" HeaderText="Audit Period" SortExpression="AUDITPERIOD" HeaderStyle-BorderStyle="NotSet" />
                        </Fields>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F5E9E4" />

                    </asp:DetailsView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [PETID], [NAME], [AGE], [SIZE],[BREED], [TYPE], [AUDITPERIOD], 
CASE
    WHEN [GENDER] = 'M' THEN 'Male'
WHEN [GENDER] = 'F' THEN 'Female'
END AS [GENDER]
FROM [PET] 
WHERE ([PETID] = @PETID)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="PETID" QueryStringField="petId" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>

                <div class="col-md-6 d-flex align-items-end">
                    <div class="container p-0">
                    <div class="row">
                        <div class="col-md-6 ps-5 pt-2">
                             <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-outline-dark btn-floating me-3" Font-Size="Medium" ToolTip="Back" NavigateUrl="javascript:history.back()"><i class="fas fa-arrow-left" data-mdb-toggle="tooltip" data-mdb-placement="right" title="Back"></i></asp:HyperLink>
                        </div>

                        <div class="col-md-6 d-flex justify-content-end">

                            <asp:HyperLink ID="adoptbtn" runat="server" CssClass="btn btn-primary btn-rounded py-3 px-5">Adopt</asp:HyperLink>

                        </div>
                    </div>
                    </div>

                  
                </div>

            </div>
        </div>

    </div>
</asp:Content>
