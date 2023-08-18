<%@ Page Title="" Language="C#" MasterPageFile="~/FO_MasterPage.Master" AutoEventWireup="true" CodeBehind="FO_PwdRecovery.aspx.cs" Inherits="AnimalAdoptionSystem.View.FrontOffice.Customer.FO_PwdRecovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container w-50 mt-5 p-5 rounded-2" style="background-color: #f1e2db">

        <h3>Reset Password</h3>
        <hr class="mt-0 mb-4" />

        <div id="getOtpDiv" runat="server" style="height: 130px">
            <asp:Label ID="getOtpLbl" runat="server" Text="Enter the email you registered with us to get OTP."></asp:Label>
            <div class="form-outline mt-3">
                <asp:TextBox ID="getOTPMail" runat="server" CssClass="form-control"></asp:TextBox>
                <label class="form-label" for="getOTPMail">Email</label>
            </div>
            <asp:RequiredFieldValidator ID="getOTPMailRequiredValidator" runat="server" ErrorMessage="<i class='fas fa-exclamation-circle mx-1'></i> Please enter email that you used to registered." ControlToValidate="getOTPMail" Display="Dynamic" CssClass="text-danger" ValidationGroup="pwdResetValidationGrp"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="getOTPMailRegularExpressionValidator" runat="server" ErrorMessage="<i class='fas fa-times mx-1'></i> Invalid email format. Please try again." ControlToValidate="getOTPMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="text-danger" ValidationGroup="pwdResetValidationGrp" Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:CustomValidator ID="getOTPMailCustomValidator" runat="server" ControlToValidate="getOTPMail" Display="Dynamic" EnableTheming="True" ErrorMessage="<i class='fas fa-times'></i> Email cannot be found. Please try again." OnServerValidate="getOTPMailCustomValidator_ServerValidate" CssClass="text-danger" ValidationGroup="pwdResetValidationGrp"></asp:CustomValidator>
            <asp:Label ID="emailSentMsgLbl" runat="server" CssClass="text-success"><i class="fas fa-check mx-1"></i> OTP has been send to your email. Please check your email.</asp:Label>
            <asp:Label ID="emailSentErrMsgLbl" runat="server" CssClass="text-danger"><i class='fas fa-times mx-1'></i> You have requested an OTP. Please enter OTP received. </asp:Label>

        </div>

        <%--step 2--%>
        <div id="validateOtpDiv" runat="server" style="height: 130px">
            <asp:Label ID="validateOtpLbl" runat="server" Text="Enter the OTP you received in your email"></asp:Label>
            <div class="form-outline mt-3">
                <asp:TextBox ID="otpReceived" runat="server" CssClass="form-control"></asp:TextBox>
                <label class="form-label" for="otpReceived">OTP</label>
            </div>
            <asp:RequiredFieldValidator ID="otpReceivedRequiredFieldValidator" runat="server" ErrorMessage="<i class='fas fa-exclamation-circle mx-1'></i> Please enter OTP you have received." ControlToValidate="otpReceived" Display="Dynamic" CssClass="text-danger" ValidationGroup="pwdResetValidationGrp"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="otpReceivedRegularExpressionValidator" runat="server" ErrorMessage="<i class='fas fa-times mx-1'></i> Only 6 digits allowed. (no alphabet) " ControlToValidate="otpReceived" ValidationExpression="\d{6}" CssClass="text-danger" ValidationGroup="pwdResetValidationGrp" Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:CustomValidator ID="verifyOTPCustomValidator" runat="server" ControlToValidate="otpReceived" Display="Dynamic" EnableTheming="True" ErrorMessage="<i class='fas fa-times mx-1'></i> Wrong OTP. Please try again." OnServerValidate="verifyOTPCustomValidator_ServerValidate" CssClass="text-danger" ValidationGroup="pwdResetValidationGrp"></asp:CustomValidator>
            <asp:Label ID="validateOTPMsgLbl" runat="server" CssClass="text-success"><i class="fas fa-check mx-1"></i> OTP verified! You may now reset your password.</asp:Label>
            <asp:Label ID="validateOTPErrMsgLbl" runat="server" CssClass="text-danger"><i class='fas fa-times mx-1'></i> OTP already verified! Click continue to reset password.</asp:Label>
        </div>

        <%--step 3--%>
        <div id="resetPwdDiv" runat="server" style="height: 130px">
            <asp:Label ID="resetPwdLbl" runat="server" Text="Enter a new password to reset your password."></asp:Label>
            <div class="form-outline mt-3">
                <asp:TextBox ID="resetPwd" runat="server" TextMode="Password" CssClass="form-control" MaxLength="30"></asp:TextBox>
                <label class="form-label" for="resetPwd">New password</label>
            </div>
            <asp:RequiredFieldValidator ID="resetPwdRequiredFieldValidator" runat="server" ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please enter email that you used to registered." ControlToValidate="resetPwd" Display="Dynamic" CssClass="text-danger" ValidationGroup="pwdResetValidationGrp"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="resetPwdRegularExpressionValidator" runat="server" ErrorMessage="<i class='fas fa-times'></i> Password must at least 8, at most 30 characters." ControlToValidate="resetPwd" ValidationExpression="\w{8,30}" Display="Dynamic" CssClass="text-danger" ValidationGroup="pwdResetValidationGrp"></asp:RegularExpressionValidator>
            <asp:Label ID="resetPwdMsgLbl" runat="server" CssClass="text-success"><i class="fas fa-check mx-1"></i> You may now login with the new password! Click login now to login.</asp:Label>
            <asp:Label ID="resetPwdErrMsgLbl" runat="server" CssClass="text-danger"><i class='fas fa-times mx-1'></i> You have just reset your password! </asp:Label>

        </div>

        <div class="d-flex justify-content-end align-items-center mt-3 ">
            <asp:Image ID="pwdResetImg" runat="server" ImageUrl="~/Images/pwdRecoveryImg.png" Style="z-index: 1;" />
        </div>

        <div class="d-flex justify-content-end align-items-center mt-2">
            <asp:LinkButton ID="getOtpBtn" runat="server" CssClass="btn btn-primary btn-rounded py-3 px-4 position-absolute" Style="font-size: 15px;" ValidationGroup="pwdResetValidationGrp" OnClientClick="emailSending()" OnClick="getOTP_Click">Get OTP</asp:LinkButton>
            <asp:LinkButton ID="enterOTPBtn" runat="server" CssClass="btn btn-primary btn-rounded py-3 px-4 position-absolute" Style="font-size: 13px;" ValidationGroup="pwdResetValidationGrp" OnClick="enterOTPBtn_Click">Enter OTP</asp:LinkButton>
            <asp:LinkButton ID="validateOTPBtn" runat="server" CssClass="btn btn-primary btn-rounded py-3 px-4 position-absolute" Style="font-size: 13px;" ValidationGroup="pwdResetValidationGrp" OnClick="validateOTPBtn_Click">Validate</asp:LinkButton>
            <asp:LinkButton ID="verifiedOTPBtn" runat="server" CssClass="btn btn-primary btn-rounded py-3 px-4 position-absolute" Style="font-size: 13px;" ValidationGroup="pwdResetValidationGrp" OnClick="verifiedOTPBtn_Click">Continue</asp:LinkButton>
            <asp:LinkButton ID="resetPwdBtn" runat="server" CssClass="btn btn-primary btn-rounded py-3 px-4 position-absolute" Style="font-size: 13px;" ValidationGroup="pwdResetValidationGrp" OnClick="resetPwdBtn_Click">Reset</asp:LinkButton>
            <asp:LinkButton ID="loginWithNewPwdBtn" runat="server" CssClass="btn btn-primary btn-rounded py-3 px-4 position-absolute" Style="font-size: 13px;" OnClick="loginWithNewPwdBtn_Click">Login now</asp:LinkButton>
        </div>

        <div class="d-flex justify-content-start align-items-center mt-2">
            <asp:LinkButton ID="pwdResetCancelBtn" runat="server" CssClass="btn btn-outline-primary btn-rounded py-3 px-4 position-absolute" Style="font-size: 13px;" OnClientClick=" return false;" OnClick="loginWithNewPwdBtn_Click">Cancel</asp:LinkButton>
        </div>

    </div>
    <script type="text/javascript">
        function emailSending() {
            setTimeout(
                function () {
                    if (typeof (Page_ClientValidate) == 'function') {
                        Page_ClientValidate();
                    }
                    if (Page_IsValid) {

                        Swal.fire({
                            position: 'center',
                            icon: 'info',
                            title: 'Loading....',
                            text: "Email sending...Please wait for awhile.",
                            showConfirmButton: false,
                        });
                    }
                }, 500);

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
</asp:Content>
