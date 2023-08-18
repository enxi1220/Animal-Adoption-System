<%@ Page Title="" Language="C#" MasterPageFile="~/FO_MasterPage.Master" AutoEventWireup="true" CodeBehind="FO_CustSignIn.aspx.cs" Inherits="AnimalAdoptionSystem.View.FrontOffice.FO_CustSignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Css/FrontOffice/Customer/FO_CustSignIn.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%@ Register TagPrefix="UserControl" 
            TagName="UserLogin"
            Src="AdoptMeLoginControl.ascx" %>

    <div class="container mt-5 pt-3">
           <UserControl:UserLogin runat="server" />
    </div>
   
</asp:Content>
