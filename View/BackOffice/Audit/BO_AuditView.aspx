<%@ Page Title="" Language="C#" MasterPageFile="~/BO_MasterPage.Master" AutoEventWireup="true" CodeBehind="BO_AuditView.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Audit.BO_AuditView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3 ">View Audit</h2>
    <hr />
    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="auditNoTxt">Audit No</label>
                <asp:TextBox ID="txtAuditNo" runat="server" CssClass="form-control border" ReadOnly="True" ></asp:TextBox>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="petNotxt">Pet No</label>
                <asp:TextBox ID="txtPetNo" runat="server" CssClass="form-control border" ReadOnly="True" ></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="doseTxt">Booking Time</label>
                <asp:TextBox ID="txtBookingTime" runat="server" CssClass="form-control border" TextMode="DateTime" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <div class="form-group">
                    <label class="form-label" for="doseTxt">Starting Time</label>
                    <asp:TextBox ID="txtStartingTime" runat="server" CssClass="form-control border" TextMode="DateTime" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-12">
            <div class="form-group">
                <label class="form-label" for="descriptionTxt">Description</label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control border" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="medicineTxt" >Condtion</label>
                <asp:TextBox ID="txtCondition" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="doseTxt">Completion Time</label>
                    <asp:TextBox ID="txtCompletionTime" runat="server" CssClass="form-control border" TextMode="DateTime" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6 ">
            <div class="form-group">
                <label class="form-label" for="statusTxt">Status</label>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="float-end">
        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary ms-3" OnClientClick="JavaScript:window.history.back(1); return false;" />
    </div>
</asp:Content>
