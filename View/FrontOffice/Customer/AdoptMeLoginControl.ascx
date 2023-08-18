<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdoptMeLoginControl.ascx.cs" Inherits="AnimalAdoptionSystem.View.FrontOffice.Customer.AdoptMeLoginControl" %>

<div class="row gx-3 justify-content-center">
    <div class="col-md-6 text-center">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/pet1.png" />
    </div>


    <div class="col-md-4 ">
        <h5 class="display-5 mb-0 mt-5">Login</h5>
        <hr class="my-0 border border-3 text-dark" style="width: 66px;" />
        <!----- Email ----->
        <div class="form-outline mt-5">
            <asp:TextBox ID="loginUsername" runat="server" CssClass="form-control"></asp:TextBox>
            <label class="form-label" for="loginUsername">Username</label>
        </div>
        <asp:RequiredFieldValidator ID="UsernameRequiredValidator" runat="server" ErrorMessage="<i class='fas fa-exclamation-circle me-1'></i> Please enter your username." ControlToValidate="loginUsername" Display="Dynamic" CssClass="text-danger" ValidationGroup="loginValidationGrp"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="UsernameCustomValidator" runat="server" ControlToValidate="loginUsername" Display="Dynamic" EnableTheming="True" ErrorMessage="<i class='fas fa-times me-1'></i> Accout cannot be found." OnServerValidate="LoginUsername_ServerValidate" CssClass="text-danger" ValidationGroup="loginValidationGrp"></asp:CustomValidator>

        <!----- Password ----->
        <div class="form-outline mt-4">
            <asp:TextBox ID="loginPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            <label class="form-label" for="loginPass">Password</label>
        </div>
        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ErrorMessage="<i class='fas fa-exclamation-circle me-1'></i> Please enter your password." ControlToValidate="loginPass" Display="Dynamic" CssClass="text-danger" ValidationGroup="loginValidationGrp"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="PasswordCustomValidator" runat="server" ControlToValidate="loginPass" Display="Dynamic" EnableTheming="True" ErrorMessage="<i class='fas fa-times me-1'></i> Password incorrect." OnServerValidate="PasswordCustomValidator_ServerValidate" CssClass="text-danger" ValidationGroup="loginValidationGrp"></asp:CustomValidator>
        <!----- Actions ----->
        <div class="row my-4">
            <div class="col-md-6 d-flex justify-content-start">
                <!--- Remember-Me --->
                <div class="form-check mb-3 mb-md-0 ps-1">
                    <asp:CheckBox ID="rmbMeChkBox" runat="server" /><label class="form-check-label ms-2" for="loginCheck">Remember me </label>
                </div>
            </div>
            <!----- Forgot-Pass ----->
            <div class="col-md-6 d-flex justify-content-end">
                <!-- Simple link -->
                <asp:HyperLink ID="forgotPassLink" runat="server" NavigateUrl="FO_PwdRecovery.aspx" CssClass="text-muted">Forgot Password?</asp:HyperLink>

            </div>
        </div>
        <!----- Login-Button ----->
        <div class="col-md-3 m-auto mt-3 mb-3">
            <asp:LinkButton ID="loginBtn" runat="server" CssClass="btn btn-primary btn-block btn-rounded py-3" OnClick="loginBtn_Click" ValidationGroup="loginValidationGrp">Log In</asp:LinkButton>

        </div>
        <!----- Register ----->
        <div class="text-center">
            <p>
                Not a member?
                <asp:HyperLink ID="regLink" runat="server" NavigateUrl="~/View/FrontOffice/Customer/FO_CustSignUp.aspx" CssClass="text-muted">Register</asp:HyperLink>
        </div>

    </div>
</div>

<script type="text/javascript">

    function checkLogin() {
        Swal.fire({
            position: 'center',
            icon: 'error',
            title: 'Oops...',
            text: "Please login first!",
            showConfirmButton: true,
        });
    }

    function loginSuccess(username, url) {
        Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Hello!',
            text: username,
            showConfirmButton: true,
        }).then(function () {
            location.href = url;
        });
    }

    function accDeactivated() {
        Swal.fire({
            position: 'center',
            icon: 'error',
            title: 'Sorry',
            text: "Your account has been deactivated.",
            showConfirmButton: true,
        });
    }

    function exceptionFound(msg) {
        Swal.fire({
            position: 'center',
            icon: 'error',
            title: 'Oops',
            text: msg,
            showConfirmButton: true,
        });
    }



</script>
