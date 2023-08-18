<%@ Page Title="" Language="C#" MasterPageFile="~/FO_MasterPage.Master" AutoEventWireup="true" CodeBehind="FO_CustViewAcc.aspx.cs" Inherits="AnimalAdoptionSystem.View.FrontOffice.Customer.FO_CustomerView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../../../Css/FrontOffice/FO_CustomerView.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid px-5 pt-5" id="custViewAccContainer" runat="server">
        <div class="row d-flex justify-content-center h-100">
            <div class="col-3">
                <!-- Tab side navs -->
                <div class="nav flex-column nav-tabs rounded me-3" id="nav-tabs" role="tablist" aria-orientation="vertical">
                    <asp:HyperLink ID="viewAccLink" NavigateUrl="FO_CustViewAcc.aspx" runat="server" CssClass="nav-link active ripple text-capitalize" data-mdb-ripple-color="info"><i class="fas fa-user pe-3"></i>Profile Overview</asp:HyperLink>

                    <asp:HyperLink ID="editPassLink" NavigateUrl="FO_CustEditPwd.aspx" runat="server" CssClass="nav-link ripple text-capitalize" data-mdb-ripple-color="info"><i class="fas fa-user-lock pe-3"></i>Change Password</asp:HyperLink>

                    <asp:HyperLink ID="delAccLink" NavigateUrl="FO_CustDelAcc.aspx" runat="server" CssClass="nav-link ripple text-capitalize" data-mdb-ripple-color="info"><i class="fas fa-user-times pe-3"></i>Delete Account</asp:HyperLink>

                    <asp:HyperLink ID="adoptHistoryLink" NavigateUrl="../Adoption/FO_AdoptionSummary.aspx" runat="server" CssClass="nav-link ripple text-capitalize" data-mdb-ripple-color="info"><i class="fas fa-paw pe-3"></i>Adoption History</asp:HyperLink>

                </div>
            </div>


            <div class="col col-lg-9">
                <div class="card shadow">
                    <div class="rounded-top d-flex justify-content-between align-items-end" style="background-color: var(--black); height: 190px;">
                        <div class="ms-5 d-flex flex-column" style="width: 150px;">

                            <asp:Image ID="custProImg" runat="server" CssClass="img-fluid img-thumbnail pImgSty" Style="object-fit: cover;" />
                        </div>
                        <div style="position: absolute; left: 13em;">
                            <h5>
                                <asp:Literal ID="custUsername" runat="server"></asp:Literal></h5>

                            <p>
                                <span>Joined since </span>:
                                <asp:Literal ID="custJoinedDate" runat="server"></asp:Literal>
                            </p>

                        </div>

                        <div class="d-flex text-center pe-3 py-1 mb-2" id="acc-activity" style="color: var(--eunry)">

                            <div class="me-5 ps-3">
                                <p class="mb-1 h5">
                                    <asp:Literal ID="adoptedPetCount" runat="server"></asp:Literal><i class="fas fa-paw ps-3"></i>
                                </p>
                                <p class="small text-muted mb-0">Adopted Pets </p>
                            </div>
                        </div>
                    </div>
                    <!-- ------------------------------top ------------------------------ -->

                    <div class="card-body px-5 py-4 text-black tab-content">

                        <div class="user-detail-container p-3 mt-3" id="viewAccDiv" runat="server">

                            <div class="row">

                                <div class="col-6">
                                    <div class="d-flex justify-content-start align-items-center">
                                        <h3 class="lead mt-2 mb-0">Account Overview</h3>
                                    </div>
                                </div>

                                <div class="col-6">
                                    <div class="d-flex justify-content-end align-items-center">
                                        <asp:LinkButton ID="editAccBtn" runat="server" CssClass="btn btn-outline-primary btn-floating" OnClick="editAccBtn_Click"><i class="fas fa-user-edit ps-1" style="font-size:19px;" data-mdb-toggle="tooltip" data-mdb-placement="top" title="Edit Account"></i></asp:LinkButton>

                                    </div>
                                </div>

                            </div>

                            <hr class="mt-2" />
                            <div class="col">
                                <p>
                                    <span>Name </span>:
                                    <asp:Literal ID="custName" runat="server"></asp:Literal>
                                </p>
                                <p>
                                    <span>Email </span>:
                                    <asp:Literal ID="custMail" runat="server"></asp:Literal>
                                </p>
                                <p>
                                    <span>Contact </span>:
                                    <asp:Literal ID="custPhone" runat="server"></asp:Literal>
                                </p>
                            </div>


                        </div>

                        <!-- ------------------------------ Customer Edit ------------------------------ -->
                        <div class="bg-light px-3 py-3 my-3" id="editAccDiv" runat="server">
                            <h3 class="lead">Edit Account</h3>
                            <hr class="mt-0 mb-3" />
                            <div class="container mt-3 px-2">

                                <div class="row g-3" validationgroup="editProfile">
                                    <!----- Name ----->
                                    <div class="col-md-6">
                                        <div class="form-outline">
                                            <asp:TextBox ID="custEditName" runat="server" CssClass="form-control"></asp:TextBox>
                                            <label for="custEditName" class="form-label">Full Name</label>
                                        </div>
                                        <asp:RequiredFieldValidator ID="editNameRequiredValidator" runat="server" ErrorMessage="<i class='fas fa-exclamation-circle me-1'></i> Please enter your name." ControlToValidate="custEditName" Display="Dynamic" CssClass="text-danger" ValidationGroup="editAccValidationGrp"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="editNameRegularExpressionValidator" runat="server" ErrorMessage="<i class='fas fa-times me-1'></i> Only alphabet and ' / symbols are allowed." ControlToValidate="custEditName" Display="Dynamic" ValidationExpression="^[A-Za-z \'\/]+$" CssClass="text-danger" ValidationGroup="editAccValidationGrp"></asp:RegularExpressionValidator>
                                    </div>
                                    <!----- Phone ----->
                                    <div class="col-md-6">
                                        <div class="form-outline">
                                            <asp:TextBox ID="custEditPhone" runat="server" CssClass="form-control"></asp:TextBox>
                                            <label class="form-label" for="custEditPhone">Phone</label>
                                        </div>
                                        <asp:RequiredFieldValidator ID="editPhoneRequiredValidator" runat="server" ErrorMessage="<i class='fas fa-exclamation-circle me-1'></i> Please enter your phone." ControlToValidate="custEditPhone" Display="Dynamic" CssClass="text-danger" ValidationGroup="editAccValidationGrp"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="editPhoneRegularExpressionValidator" runat="server" ErrorMessage="<i class='fas fa-times me-1'></i> Phone format: e.g. 012-3456789" ControlToValidate="custEditPhone" Display="Dynamic" ValidationExpression="\d{3}-\d{7,8}" CssClass="text-danger" ValidationGroup="editAccValidationGrp"></asp:RegularExpressionValidator>
                                    </div>
                                    <!----- Change-Email ----->
                                    <div class="col-md-6">
                                        <div class="form-outline">
                                            <asp:TextBox ID="custEditMail" runat="server" CssClass="form-control"></asp:TextBox>
                                            <label class="form-label" for="custEditMail">Email</label>
                                        </div>
                                        <asp:RequiredFieldValidator ID="editMailRequiredFieldValidator" runat="server" ErrorMessage="<i class='fas fa-exclamation-circle me-1'></i> Please enter your email." ControlToValidate="custEditMail" Display="Dynamic" CssClass="text-danger" ValidationGroup="editAccValidationGrp"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="editMailRegularExpressionValidator" runat="server" ErrorMessage="<i class='fas fa-times me-1'></i> Invalid email format. Please try again." ControlToValidate="custEditMail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="text-danger" ValidationGroup="editAccValidationGrp"></asp:RegularExpressionValidator>
                                        <asp:CustomValidator ID="ChkRegisteredMailCustomValidator" runat="server" ErrorMessage="<i class='fas fa-times me-1'></i> Email you are trying to change belongs to other user. Please change another one." ControlToValidate="custEditMail" OnServerValidate="ChkRegisteredMail_ServerValidate" CssClass="text-danger" ValidationGroup="editAccValidationGrp"></asp:CustomValidator>
                                    </div>
                                    <!----- Profile ----->
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-6 d-flex justify-content-start">
                                                <asp:Button ID="custEditImgBtn" runat="server" Text="Profile (Optional)" CssClass="btn-outline-primary rounded px-2" Style="background-color: #FFFBF6; font-size: 15px; height: 38px;" OnClientClick="fileUpload(); return false;" CausesValidation="false" />
                                            </div>
                                            <div class="col-6 d-flex justify-content-end pe-4">
                                                <asp:Image ID="custEditImgPre" runat="server" CssClass="rounded-circle" Style="border: 0.5px solid lightgrey; width: 50px; height: 50px; object-fit: cover;" />
                                                <asp:FileUpload ID="custEditImg" runat="server" CssClass="form-control" onchange="ShowPreview(this)" Style="display: none;" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6 mt-0">
                                        <div class="d-flex justify-content-start align-items-center mt-3">
                                            <asp:LinkButton ID="editAccCancelBtn" runat="server" CssClass="btn btn-outline-primary btn-rounded py-3" OnClick="editAccCancelBtn_Click">Cancel</asp:LinkButton>

                                        </div>
                                    </div>

                                    <div class="col-md-6 mt-0">
                                        <div class="d-flex justify-content-end align-items-center mt-3">
                                            <asp:LinkButton ID="editAccSaveBtn" runat="server" CssClass="btn btn-primary btn-rounded py-3" ValidationGroup="editAccValidationGrp" OnClick="editAccSaveBtn_Click">Save Changes</asp:LinkButton>

                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ShowPreview(input) {
            if (input.files && input.files[0]) {
                var ImageDir = new FileReader();
                ImageDir.onload = function (e) {
                    $('#<%= custEditImgPre.ClientID %>').attr('src', e.target.result);
                }
                ImageDir.readAsDataURL(input.files[0]);
            }
        }

        function fileUpload() {
            $('#<%= custEditImg.ClientID %>').click();
        }

        function editAccsuccessful(url) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Successful',
                text: "Account edited!",
                showConfirmButton: true,
            }).then(function () {
                location.href = url;
            });
        }

        function onlyCustomer(url) {
            Swal.fire({
                position: 'center',
                icon: 'error',
                title: 'Oops',
                text: "Only customers are allowed to view profile.",
                showConfirmButton: true,
            }).then(function () {
                location.href = url;
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
</asp:Content>
