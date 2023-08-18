<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" MasterPageFile="~/BO_MasterPage.Master" CodeBehind="BO_AdoptionApproval.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Adoption.BO_AdoptionApproval1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3 ">Adoption Approval</h2>
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


    <div style="float: right; margin-top: 2em; margin-bottom: 2em; height: 150px;">
        <asp:LinkButton ID="btnApprove" runat="server" Text="Approve" Style="float: right; margin-right: 2.5em;" CssClass="btn btn-primary ms-3" OnClick="btnApprove_Click" Enabled="false"></asp:LinkButton>
        <asp:LinkButton ID="btnReject" runat="server" Text="Reject" Style="float: right;" CssClass="btn btn-primary" OnClick="btnReject_Click" Enabled="false"></asp:LinkButton>
        <%--<asp:Button ID="btnApprove" runat="server" Text="Approve" Style="float: right; margin-right: 2.5em;" CssClass="btn btn-primary ms-3" OnClick="btnApprove_Click" Enabled="false" />--%>
        <%--<asp:Button ID="btnReject" runat="server" Text="Reject" Style="float: right;" CssClass="btn btn-primary" OnClick="btnReject_Click" Enabled="false" />--%>
        <asp:DropDownList ID="ddl_RejectReason" runat="server" CssClass="form-control border" Height="2em" Style="clear: both; float: right; width: 230px; margin-top: 1.5em; margin-bottom: 3em;" Visible="false" AutoPostBack="True" OnSelectedIndexChanged="ddl_RejectReason_SelectedIndexChanged">
            <asp:ListItem Text="-- Reject Reason --" Value="" Enabled="True" />
            <asp:ListItem Text="Underage" Value="Underage" />
            <asp:ListItem Text="Too many people / children in a household" Value="Too many people / children in a household" />
            <asp:ListItem Text="Long working hours" Value="Long working hours" />
            <asp:ListItem Text="House size too small" Value="House size too small" />
            <asp:ListItem Text="Application information is not completed" Value="Application information is not completed" />
            <asp:ListItem Text="Other" Value="Other" />
        </asp:DropDownList>

    </div>
    <script>
        function onlyAdmin(url) {
            Swal.fire({
                position: 'center',
                icon: 'error',
                title: 'Oops',
                text: "You are unauthorized to view the page",
                showConfirmButton: true,
            }).then(function () {
                location.href = url;
            });
        }
        function fail(msg, url) {
            Swal.fire({
                position: 'center',
                icon: 'error',
                title: 'Oops',
                text: msg,
                showConfirmButton: true,
            }).then(function () {
                location.href = url;
            });
        }
    </script>
</asp:Content>