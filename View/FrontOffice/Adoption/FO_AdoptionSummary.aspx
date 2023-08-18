<%@ Page Title="" Language="C#" MasterPageFile="~/FO_MasterPage.Master" AutoEventWireup="true" CodeBehind="FO_AdoptionSummary.aspx.cs" Inherits="AnimalAdoptionSystem.View.FrontOffice.Adoption.FO_AdoptionSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="fw-normal text-capitalize mt-5 mb-3 w-75 float-end">Adoptions</h3>
    <div class="float-end mt-2">
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-outline-dark btn-floating me-3" Font-Size="Medium" ToolTip="Back" NavigateUrl="/View/FrontOffice/Customer/FO_CustViewAcc.aspx"><i class="fas fa-arrow-left" data-mdb-toggle="tooltip" data-mdb-placement="right" title="Back"></i></asp:HyperLink>
    </div>
    <div class="row vw-100">
        <div class="container">
            <div class="row">
                <div class="col-3">
                    <!-- Tab navs -->
                    <div
                        class="nav flex-column nav-tabs text-center"
                        id="v-tabs-tab"
                        role="tablist"
                        aria-orientation="vertical">
                        <asp:Button
                            ID="btnPending"
                            runat="server"
                            Text="Pending Approval"
                            role="tab"
                            aria-controls="v-tabs-pending-approval"
                            aria-selected="false"
                            CssClass="nav-link text-capitalize" OnClick="btnPending_Click" />
                        <asp:Button
                            ID="btnApproved"
                            runat="server"
                            Text="Approved"
                            CssClass="nav-link text-capitalize" OnClick="btnApproved_Click" />
                        <asp:Button
                            ID="btnRejected"
                            runat="server"
                            Text="Rejected"
                            CssClass="nav-link text-capitalize" OnClick="btnRejected_Click" />
                        <asp:Button
                            ID="btnCanceled"
                            runat="server"
                            Text="Canceled"
                            CssClass="nav-link text-capitalize" OnClick="btnCanceled_Click" />
                    </div>
                    <!-- Tab navs -->
                </div>

                <div class="col-9">
                    <!-- Tab content -->
                    <asp:DataList ID="DataList1" runat="server" RepeatColumns="1" RepeatDirection="Vertical" HorizontalAlign="Center" CssClass="w-100">
                        <ItemTemplate>
                            <div class="card mt-2 mb-5">
                                <div class="card-header">
                                    <div class="d-inline">
                                        <label for="" class="text-uppercase">adoption no.</label>
                                        <asp:Label ID="lblAdoptionNo" runat="server" Text='<%#Eval("ADOPTIONNO")%>' CssClass="ml-5 fw-bold"></asp:Label>
                                    </div>
                                    <asp:HyperLink
                                        ID="HyperLink1"
                                        runat="server"
                                        CssClass="float-end link-primary"
                                        ToolTip="View Adoption Detail"
                                        NavigateUrl='<%# String.Format("FO_AdoptionView.aspx?adoptionId={0}", Eval("ADOPTIONID"))%>'>
                                        <i class="fas fa-angle-right fa-lg" data-mdb-toggle="tooltip" data-mdb-placement="top" title="More"></i>
                                    </asp:HyperLink>
                                </div>
                                <div class="card-body " id="v-tabs-all">
                                    <p class="card-text float-end">
                                        <label for="" class="text-capitalize">Applied date: </label>
                                        <asp:Label ID="lblCreatedDate" runat="server" Text='<%#Eval("CREATEDDATE")%>' CssClass="text-muted"></asp:Label>
                                    </p>
                                    <p class="card-text">
                                        <label for="" class="text-capitalize">Name: </label>
                                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("NAME")%>' CssClass="text-muted"></asp:Label>
                                    </p>

                                    <p class="card-text">
                                        <label for="" class="text-capitalize">Breed: </label>
                                        <asp:Label ID="lblBreed" runat="server" Text='<%#Eval("BREED")%>' CssClass="text-muted"></asp:Label>
                                    </p>
                                    <p class="card-text">
                                        <label for="" class="text-capitalize">Age: </label>
                                        <asp:Label ID="lblAge" runat="server" Text='<%#Eval("AGE")%>' CssClass="text-muted"></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
