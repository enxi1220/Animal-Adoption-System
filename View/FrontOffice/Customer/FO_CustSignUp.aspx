<%@ Page Title="" Language="C#" MasterPageFile="~/FO_MasterPage.Master" AutoEventWireup="true" CodeBehind="FO_CustSignUp.aspx.cs" Inherits="AnimalAdoptionSystem.View.FrontOffice.FO_CustSignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container w-50 ">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/p3.png" CssClass="position-absolute top-0 m-md"/>

        <div class="container mt-md">
        
            <h5 class="display-5 mb-0">Join Us</h5>
            <hr class="my-0 border border-3 text-dark mb-5" style="width: 66px;" />

                <div class="row g-3" >
                    <!----- Name ----->
                    <div class="col-md-6">
                        <div class="form-outline">
                            <asp:TextBox ID="custRegName" runat="server" CssClass="form-control" MaxLength="150"></asp:TextBox>
                            <label for="custRegName" class="form-label">Full Name</label>
                        </div>
                         <asp:RequiredFieldValidator ID="regNameRequiredValidator" runat="server" ErrorMessage="<i class='fas fa-exclamation-circle me-1'></i> Please enter your name." ControlToValidate="custRegName" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regNameRegularExpressionValidator" runat="server" ErrorMessage="<i class='fas fa-times me-1'></i> Only alphabet and ' / symbols are allowed." ControlTovalidate="custRegName" Display="Dynamic" ValidationExpression="^[A-Za-z \'\/]+$" CssClass="text-danger"></asp:RegularExpressionValidator>
                    </div>
                    <!----- Username ----->
                    <div class="col-md-6">
                        <div class="form-outline">
                            <asp:TextBox ID="custRegUsername" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                            <label for="custRegUsername" class="form-label">Username</label>
                        </div>
                        <asp:RequiredFieldValidator ID="regUsernameRequiredFieldValidator" runat="server" ErrorMessage="<i class='fas fa-exclamation-circle me-1'></i> Please enter your username." ControlToValidate="custRegUsername" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="ChkUsernameTakenCustomValidator" runat="server" ErrorMessage="<i class='fas fa-times me-1'></i> Username taken. Please try again." ControlToValidate="custRegUsername" OnServerValidate="ChkUsernameTakenCustomValidator_ServerValidate" CssClass="text-danger"></asp:CustomValidator>
                    </div>
                    <!----- Register-Email ----->
                    <div class="col-md-6 mt-2">
                        <div class="form-outline">
                            <asp:TextBox ID="custRegMail" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            <label class="form-label" for="custRegMail">Email</label>
                        </div>
                        <asp:RequiredFieldValidator ID="regMailRequiredFieldValidator" runat="server" ErrorMessage="<i class='fas fa-exclamation-circle me-1'></i> Please enter your email." ControlToValidate="custRegMail" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regMailRegularExpressionValidator" runat="server" ErrorMessage="<i class='fas fa-times me-1'></i> Invalid email format. Please try again." ControlTovalidate="custRegMail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="text-danger"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="ChkMailTakenCustomValidator" runat="server" ErrorMessage="<i class='fas fa-times me-1'></i> Email regitered. Please try again." ControlToValidate="custRegMail" OnServerValidate="ChkMailTakenCustomValidator_ServerValidate" CssClass="text-danger"></asp:CustomValidator>
                    </div>

                    <!----- Phone ----->
                    <div class="col-md-6 mt-2">
                        <div class="form-outline">
                            <asp:TextBox ID="custRegPhone" runat="server" CssClass="form-control" MaxLength="12"></asp:TextBox>

                            <%--<input type="tel" id="custRegPhone" class="form-control " />--%>
                            <label class="form-label" for="custRegPhone">Phone</label>
                        </div>
                        <asp:RequiredFieldValidator ID="RegPhoneRequiredFieldValidator" runat="server" ErrorMessage="<i class='fas fa-exclamation-circle me-1'></i> Please enter your phone." ControlToValidate="custRegPhone" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegPhoneRegularExpressionValidator" runat="server" ErrorMessage="<i class='fas fa-times me-1'></i> Phone format: e.g. 012-3456789" ControlTovalidate="custRegPhone" ValidationExpression="\d{3}-\d{7,8}" CssClass="text-danger"></asp:RegularExpressionValidator>

                    </div>

                    <!----- Password ----->
                    <div class="col-md-6 mt-2">
                        <div class="form-outline">
                            <asp:TextBox ID="custRegPwd" runat="server" TextMode="Password" CssClass="form-control" MaxLength="30"></asp:TextBox>
                            <label class="form-label" for="custRegPwd">Password</label>
                        </div>
                        <asp:RequiredFieldValidator ID="RegPwdRequiredFieldValidator" runat="server" ErrorMessage="<i class='fas fa-exclamation-circle me-1'></i> Please enter your password." ControlToValidate="custRegPwd" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegPwdRegularExpressionValidator" runat="server" ErrorMessage="<i class='fas fa-times me-1'></i> Password must at least 8, at most 30 characters." ControlTovalidate="custRegPwd" ValidationExpression="\w{8,30}" CssClass="text-danger"></asp:RegularExpressionValidator>

                    </div>
                    
                    <!----- Confirm Password ----->
                    <div class="col-md-6 mt-2">
                        <div class="form-outline">
                            <asp:TextBox ID="custRegConfirmPass" runat="server" TextMode="Password" CssClass="form-control" MaxLength="30"></asp:TextBox>
                            <%--<input type="password" id="custRegConfrimPass" class="form-control " data-mdb-showcounter="true" maxlength="30" />--%>
                            <label class="form-label" for="custRegConfirmPass">Confirm Password</label>
                            
                        </div>
                        <asp:RequiredFieldValidator ID="regConfirmPassRequiredFieldValidator" runat="server" ErrorMessage="<i class='fas fa-exclamation-circle me-1'></i> Please confirm your password." ControlToValidate="custRegConfirmPass" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="regConPassCompareValidator" runat="server" ErrorMessage="<i class='fas fa-times me-1'></i> Confirm password not mathced with password." CssClass="text-danger" ControlToCompare="custRegPwd" ControlToValidate="custRegConfirmPass"></asp:CompareValidator>
                      </div>
                    <!-------- Separate Line -------->
                    <section class="border-top border-2 mt-3 mb-2"></section>

                    <!----- Profile ----->
                    <div class="col-md-6 mt-2 border-end border-2">
                        <div class="row">
                            <div class="col-6 d-flex justify-content-start">
                            <asp:Button ID="custRegImgBtn" runat="server" Text="Profile (Optional)" CssClass="btn-outline-primary rounded px-2" Style="background-color: #FFFBF6; font-size: 15px;" OnClientClick="fileUpload(); return false;" CausesValidation="false" />
                            </div>
                               <div class="col-6 d-flex justify-content-end pe-4">
                            <asp:Image ID="regImgPre" runat="server" CssClass="rounded-circle" Style="border: 0.5px solid lightgrey; width: 50px; height: 50px; object-fit: cover;"/>  
                                <asp:FileUpload ID="custRegImg" runat="server" CssClass="form-control" onchange="ShowPreview(this)" Style="display: none;"/>
                            </div>
                        </div>
                    </div>
                    <!----- Register-Button ----->
                    <div class="col-md-6 mt-2">
                        <div class="d-flex justify-content-end align-items-center">
                            <asp:LinkButton ID="regBtn" runat="server" CssClass="btn btn-primary btn-rounded py-3 px-4" OnClick="regBtn_Click" ControlToValidate="custRegConfirmPass">Register</asp:LinkButton>
                        </div>
                        
                       
                    </div>
                </div>

        </div>
    </div>
    <script type="text/javascript">
        function ShowPreview(input) {  
            if (input.files && input.files[0]) {  
                var ImageDir = new FileReader();  
                ImageDir.onload = function(e) {  

                    $('#<%= regImgPre.ClientID %>').attr('src', e.target.result);
                }  
                ImageDir.readAsDataURL(input.files[0]);  
            }  
        }

        function fileUpload() {  
            $('#<%= custRegImg.ClientID %>').click();
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
