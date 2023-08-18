<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BO_MasterPage.Master" CodeBehind="BO_AdoptionView.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Adoption.BO_AdoptionView2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3 ">View Adoption</h2>
    <hr />

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label cssclass="form-label" for="txtAdoptionNo">Adoption No</label>
                <asp:TextBox ID="txtAdoptionNo" runat="server" CssClass="form-control border" Enabled="False"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label cssclass="form-label" for="txtUsername">Requestor Username</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control border" Enabled="False"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label cssclass="form-label" for="txtStatus">Status</label>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control border" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label id="rejectLabel" runat="server" cssclass="form-label" for="txtRejectReason">Reject Reason</label>
                <asp:TextBox ID="txtRejectReason" runat="server" CssClass="form-control border" Enabled="False"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label cssclass="form-label" for="txtCustomerName">Customer Name</label>
                <asp:TextBox ID="txtCustomerName" runat="server" CssClass="form-control border" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label id="Label1" runat="server" cssclass="form-label" for="txtCustomerPhone">Customer Phone</label>
                <asp:TextBox ID="txtCustomerPhone" runat="server" CssClass="form-control border" Enabled="False"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="card-body overflow-auto">
        <div class="mb-3 w-auto p-3">
            <div class="card-header">
                <h4>Customer IC Image</h4>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <asp:Image ID="imgIC" runat="server" CssClass="" Style="width: 40vw; height: 54vh;" />

                </div>
                <div class="col-md-6 ps-5">
                    <div class="card-header">
                        <h4>Pet Detail</h4>
                    </div>
                    <div class="card-body">
                        <p class="card-text">
                            <small class="">
                                <label for="" class="text-capitalize text-muted">Pet No: </label>
                                <asp:Label ID="lblPetNo" runat="server"></asp:Label>
                            </small>
                        </p>
                        <p class="card-text">
                            <small class="">
                                <label for="" class="text-capitalize text-muted">Pet Name: </label>
                                <asp:Label ID="lblPetName" runat="server"></asp:Label>
                            </small>
                        </p>
                        <p class="card-text">
                            <small class="">
                                <label for="" class="text-capitalize text-muted">Type: </label>
                                <asp:Label ID="lblType" runat="server"></asp:Label>
                            </small>
                        </p>
                        <p class="card-text">
                            <small class="">
                                <label for="" class="text-capitalize text-muted">Breed: </label>
                                <asp:Label ID="lblBreed" runat="server"></asp:Label>
                            </small>
                        </p>
                        <p class="card-text">
                            <small class="">
                                <label for="" class="text-capitalize text-muted">Age: </label>
                                <asp:Label ID="lblAge" runat="server"></asp:Label>
                            </small>
                        </p>
                        <p class="card-text">
                            <small class="">
                                <label for="" class="text-capitalize text-muted">gender: </label>
                                <asp:Label ID="lblGender" runat="server"></asp:Label>
                            </small>
                        </p>
                        <p class="card-text">
                            <small class="">
                                <label for="" class="text-capitalize text-muted">Size: </label>
                                <asp:Label ID="lblSize" runat="server"></asp:Label>
                            </small>
                        </p>
                        <p class="card-text">
                            <small class="">
                                <label for="" class="text-capitalize text-muted">Description: </label>
                                <asp:Label ID="lblDesc" runat="server"></asp:Label>
                            </small>
                        </p>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
