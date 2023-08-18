<%@ Page Title="" Language="C#" MasterPageFile="~/FO_MasterPage.Master" AutoEventWireup="true" CodeBehind="FO_PetSummary.aspx.cs" Inherits="AnimalAdoptionSystem.View.FrontOffice.Pet.FO_PetSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 138px;
        }

        .auto-style1 {
            width: 250px;
        }

        .auto-style13 {
            width: 250px;
        }
    </style>
    <link href="../../../Css/pet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  

    <ul class="nav nav-pills justify-content-center ">
        <li class="nav-item" role="presentation">
            <asp:Button
                ID="allPetBtn"
                runat="server"
                Text="all"
                CssClass="nav-link btn btn-primary" OnClick="allPetBtn_Click" />
        </li>
        <li class="nav-item" role="presentation">
            <asp:Button
                ID="kidPetBtn"
                runat="server"
                Text="kid"
                CausesValidation="false"
                AutoPostBack="false"
                CssClass="nav-link" OnClick="kidPetBtn_Click" />
        </li>
        <li class="nav-item" role="presentation">
            <asp:Button
                ID="adultPetBtn"
                runat="server"
                Text="adult"
                CausesValidation="false"
                AutoPostBack="false"
                CssClass="nav-link" OnClick="adultPetBtn_Click" />
        </li>
        <li class="nav-item" role="presentation">
            <asp:Button
                ID="smallPetBtn"
                runat="server"
                Text="small size"
                CausesValidation="false"
                AutoPostBack="false"
                CssClass="nav-link" OnClick="smallPetBtn_Click" />
        </li>
        <li class="nav-item" role="presentation">
            <asp:Button
                ID="bigPetBtn"
                runat="server"
                Text="big size"
                CausesValidation="false"
                AutoPostBack="false"
                CssClass="nav-link" OnClick="bigPetBtn_Click" />
        </li>
    </ul>



    <div class="container mt-3 mb-3 pb-0 rounded-5 shadow-lg p-3 mb-5" style="background-color: #f8f4ed">


        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" Width="1038px" HorizontalAlign="Center" CellPadding="60">
            <ItemTemplate>
                <table class="w-100 mb-3">
                    <tr>
                        <td>
                            <div class="text-center bg-white rounded-top" style="height: 38vh; width: 19vw;">
                                <div class="d-flex justify-content-center align-item-center">
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image")%>' CssClass="img-fluid" style="height: 38vh; width: 19vw; object-fit: scale-down;"/>
                                </div>
                            </div>
                            <div class=" bg-white rounded-bottom pt-3" style="width: 19vw;">
                                <table style="margin-left: 19px;">
                                    <tr>
                                        <td class="auto-style13">Name:</td>
                                        <td class="auto-style1">
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style13">Age:</td>
                                        <td class="auto-style1">
                                            <asp:Label ID="lblAge" runat="server" Text='<%#Eval("Age")%>'></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style13">Size:</td>
                                        <td class="auto-style1">
                                            <asp:Label ID="lblBreed" runat="server" Text='<%#Eval("Size")%>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">Gender:</td>
                                        <td class="auto-style1">
                                            <asp:Label class="badge rounded-pill badge-primary" ID="lblGender" runat="server" Text='<%# string.Equals(Eval("Gender").ToString(),"f",StringComparison.OrdinalIgnoreCase)?"Female" : "Male" %>'></asp:Label></td>
                                        <td class="auto-style3">
                                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-outline-dark btn-floating ms-3" Font-Size="Medium" ToolTip="Back" NavigateUrl='<%# String.Format("~/View/FrontOffice/Pet/FO_PetView.aspx?petId={0}", Eval("PetId"))%>'><i class="fas fa-info" data-mdb-toggle="tooltip" data-mdb-placement="top" title="More"></i></asp:HyperLink>
                                    </tr>
                                </table>
                            </div>
                        </td>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>

</asp:Content>

