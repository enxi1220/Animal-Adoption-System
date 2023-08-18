<%@ Page Title="" Language="C#" MasterPageFile="~/BO_MasterPage.Master" AutoEventWireup="true" CodeBehind="BO_PetDeactivate.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Pet.BO_PetDeactivate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3 ">Deactivate Pet</h2>
    <hr />
    <div class="container p-3 pt-0">
    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="petNoTxt">Pet No</label>
                <asp:TextBox ID="petNoTxt" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="petNameTxt">Pet Name</label>
                <asp:TextBox ID="petNameTxt" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-12">
            <div class="form-group">
                <label class="form-label" for="descriptionTxt">Description</label>
                <asp:TextBox ID="descriptionTxt" runat="server" CssClass="form-control border" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="petAgeTxt">Pet Age</label>
                <asp:TextBox ID="petAgeTxt" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="petSizeTxt">Pet Size</label>
                <asp:TextBox ID="petSizeTxt" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="petBreedTxt">Pet Breed</label>
                <asp:TextBox ID="petBreedTxt" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="petTypeTxt">Pet Type</label>
                <asp:TextBox ID="petTypeTxt" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="petGender">Gender</label>
                <asp:TextBox ID="petGender" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="auditPeriodTxt">Audit Period</label>
                <asp:TextBox ID="auditPeriodTxt" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="ownerTxt">Owner</label>
                <asp:TextBox ID="ownerTxt" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <div class="form-group">
                    <label class="form-label" for="adoptionTimeTxt">Adoption Time</label>
                    <asp:TextBox ID="adoptionTimeTxt" runat="server" CssClass="form-control border" TextMode="DateTime" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6 ">
            <div class="form-group">
                <label class="form-label" for="statusTxt">Status</label>
                <asp:TextBox ID="statusTxt" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="form-group">
                    <label class="form-label" for="petImageFile">Pet Image</label>
                    <asp:Image ID="petImg" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <div class="float-end mb-5">
        <asp:LinkButton ID="btnBack" runat="server" Text="Cancel" CssClass="btn btn-primary ms-3" OnClick="btnBack_Click" />
        <asp:LinkButton ID="btnDeactivate" runat="server" Text="Deactivate" CssClass="btn btn-primary" OnClick="btnDeactivate_Click" />
        
    </div>
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
    </script>
</asp:Content>
