<%@ Page Title="" Language="C#" MasterPageFile="~/FO_MasterPage.Master" AutoEventWireup="true" CodeBehind="FO_AdoptionNew.aspx.cs" Inherits="AnimalAdoptionSystem.View.FrontOffice.Adoption.FO_AdoptionNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row w-100 p-5">
        <%--pet--%>
        <div class="card ms-3 mt-2 " style="width: 19vw;">
            <asp:Image ID="imgPet" runat="server" />
            <div class="card-body">
                <h5 class="card-title">
                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label></h5>
                <p class="card-text">
                    <small class="">
                        <label for="lblBreed" class="text-capitalize text-muted">Breed: </label>
                        <asp:Label ID="lblBreed" runat="server"></asp:Label>
                    </small>
                </p>
                <p class="card-text">
                    <small class="">
                        <label for="lblAge" class="text-capitalize text-muted">Age: </label>
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
                        <label for="lblSize" class="text-capitalize text-muted">Size: </label>
                        <asp:Label ID="lblSize" runat="server"></asp:Label>
                    </small>
                </p>
            </div>
        </div>
        <%--form--%>
        <div class="col ms-5">
            <h3 class=" text-capitalize mt-4 mb-3">New Adoption</h3>
            <small class="text-muted">Please leave your information</small>
            <hr />
            <div class="row">
                <div class="col">
                    <label for="txtCustomerName" class="form-label">Customer Name<asp:Label ID="lblNotice" runat="server" Text="(same as IC)" CssClass="text-muted"></asp:Label></label>
                    <span class="text-danger">*</span>
                    <asp:TextBox ID="txtCustomerName" runat="server" CssClass="form-control" ToolTip="Name in IC" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="customerNameRequiredValidator"
                        runat="server"
                        ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please enter your name."
                        ControlToValidate="txtCustomerName"
                        Display="Dynamic"
                        CssClass="text-danger">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="col">
                    <label for="txtCustomerPhone" class="form-label">Customer Phone</label>
                    <span class="text-danger">*</span>
                    <asp:TextBox ID="txtCustomerPhone" runat="server" CssClass="form-control" placeholder="01x-xxx xxxx" MaxLength="12"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="customerPhoneRequiredValidator"
                        runat="server"
                        ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please enter your phone number."
                        ControlToValidate="txtCustomerPhone"
                        Display="Dynamic"
                        CssClass="text-danger">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator
                        ID="customerPhoneRegularExpressionValidator"
                        runat="server"
                        ErrorMessage="<i class='fas fa-times me-2'></i> Invalid phone format. Please try again."
                        ControlToValidate="txtCustomerPhone"
                        ValidationExpression="\d{3}-?\d{3,4}\s?\d{4}"
                        CssClass="text-danger"></asp:RegularExpressionValidator>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col">
                    <label for="imgIC" class="form-label">IC Image</label>
                    <span class="text-danger">*</span>
                    <asp:FileUpload ID="imgIC" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator
                        ID="imgICRequiredFieldValidator"
                        runat="server"
                        ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please submit your IC Image."
                        ControlToValidate="imgIC"
                        Display="Dynamic"
                        CssClass="text-danger">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="col">
                </div>
            </div>

            <div class="float-end">
                <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary ms-3" OnClick="btnCancel_Click" CausesValidation="false" />
                <asp:LinkButton ID="btnSave" runat="server" Text="Adopt" CssClass="btn btn-primary ms-3" OnClick="btnSave_Click"></asp:LinkButton>
            </div>
        </div>
    </div>
    <script type="text/javascript">
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
