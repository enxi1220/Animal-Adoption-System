<%@ Page Title="" Language="C#" MasterPageFile="~/FO_MasterPage.Master" AutoEventWireup="true" CodeBehind="FO_AdoptionView.aspx.cs" Inherits="AnimalAdoptionSystem.View.FrontOffice.Adoption.FO_AdoptionView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" vh-100">
        <div class="card-header">
            <div class="d-inline fs-5">
                <label for="" class="text-uppercase">adoption no. </label>
                <asp:Label ID="lblAdoptionNo" runat="server" Text="" CssClass="ml-5 fw-bold"></asp:Label>
                <div class="float-end">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-outline-dark btn-floating me-3" Font-Size="Medium" ToolTip="Back" NavigateUrl="javascript:history.back()"><i class="fas fa-arrow-left" data-mdb-toggle="tooltip" data-mdb-placement="right" title="Back"></i></asp:HyperLink>
                </div>
            </div>
        </div>
        <div class="card-body overflow-auto">
            <!-- loop-->
            <div class="mb-3 w-auto p-3">
                <div class="row">
                    <div class="col-md-6 text-center">
                        <asp:Image ID="imgPet" runat="server" CssClass=""  Style="width: 40vw; height: 54vh; object-fit: scale-down" />

                    </div>

                    <div class="col-md-6">
                        <div class="card-body">
                            <h5 class="card-title text-capitalize fw-bold">
                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                            </h5>
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
                            <p class="card-text">
                                <small class="">
                                    <asp:Label ID="labelRejctReason" runat="server" Text="Label" CssClass="text-capitalize text-muted">
                                        Reason of rejection</asp:Label>
                                    <asp:Label ID="lblRejctReason" runat="server"></asp:Label>
                                </small>
                            </p>
                            <p class="card-text">
                                <small class="">
                                    <label for="" class="text-capitalize text-muted">Adoption Status: </label>
                                    <asp:Label class="badge rounded-pill badge-primary " ID="lblStatus" runat="server"></asp:Label>
                                </small>
                            </p>
                        </div>
                    </div>
                    <div class="d-grid gap-2 d-md-flex justify-content-md-end mr-5">
                        <asp:Button ID="btnCancel" runat="server" Text="cancel adoption" OnClick="btnCancel_Click" CssClass="btn btn-primary" />
                    </div>

                </div>
            </div>

            <!-- loop-->
        </div>
    </div>
</asp:Content>
