<%@ Page Title="" Language="C#" MasterPageFile="~/FO_MasterPage.Master" AutoEventWireup="true" CodeBehind="FO_CustDelAcc.aspx.cs" Inherits="AnimalAdoptionSystem.View.FrontOffice.Customer.FO_CustDelAcc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Css/FrontOffice/FO_CustomerView.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid px-5 pt-5" id="custDelAccContainer" runat="server">
        <div class="row d-flex justify-content-center h-100">
            <div class="col-3">
                <!-- Tab side navs -->
                <div class="nav flex-column nav-tabs rounded me-3" id="nav-tabs" role="tablist" aria-orientation="vertical">
                    <asp:HyperLink ID="viewAccLink" NavigateUrl="FO_CustViewAcc.aspx" runat="server" CssClass="nav-link ripple text-capitalize" data-mdb-ripple-color="info"><i class="fas fa-user pe-3"></i>Profile Overview</asp:HyperLink>

                    <asp:HyperLink ID="editPassLink" NavigateUrl="FO_CustEditPwd.aspx" runat="server" CssClass="nav-link ripple text-capitalize" data-mdb-ripple-color="info"><i class="fas fa-user-lock pe-3"></i>Change Password</asp:HyperLink>

                    <asp:HyperLink ID="delAccLink" NavigateUrl="FO_CustDelAcc.aspx" runat="server" CssClass="nav-link active ripple text-capitalize" data-mdb-ripple-color="info"><i class="fas fa-user-times pe-3"></i>Delete Account</asp:HyperLink>

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


                    <!-- ----------------------------- Delete Account ----------------------------- -->
                    <div class="card-body px-5 py-4 text-black tab-content">

                        <div class="bg-light p-3 mt-3 " id="delAccDiv" runat="server">

                            <h3 class="lead">Delete Account</h3>
                            <hr class="mt-0" />
                            <p>Once you have confirm delete this account it will be permanently and you won't be able to login with account anymore.</p>

                            <div style="height: 66px;">
                                <div class="form-outline my-3">
                                    <asp:TextBox ID="delAccChkPwd" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <label class="form-label" for="delAccChkPwd">Enter your password to confirm</label>

                                </div>
                                <asp:RequiredFieldValidator ID="delAccChkPwdRequiredValidator" runat="server" ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please enter your current password." ControlToValidate="delAccChkPwd" Display="Dynamic" CssClass="text-danger" ValidationGroup="delAccValidation"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="delAccChkPwdCustomValidator" runat="server" ControlToValidate="delAccChkPwd" Display="Dynamic" EnableTheming="True" ErrorMessage="<i class='fas fa-times'></i> Password incorrect. Please try again." OnServerValidate="delAccChkPwd_ServerValidate" CssClass="text-danger" ValidationGroup="delAccValidation"></asp:CustomValidator>
                            </div>

                            <div class="d-flex justify-content-end align-items-center mt-3">
                                <asp:LinkButton ID="delAccBtn" runat="server" CssClass="btn btn-primary btn-rounded py-3" OnClick="delAccBtn_Click" ValidationGroup="delAccValidation">Delete</asp:LinkButton>
                            </div>


                        </div>

                        <div class="bg-light p-3 mt-3 " id="confirmDelAccDiv" runat="server">

                            <h3 class="lead">ARE YOU SURE?</h3>
                            <hr class="mt-0" />
                            <p>We're sorry if our service didn't satisfy you. Please think carefully before you click "YES"...</p>



                            <div class="d-flex justify-content-end align-items-center mt-3">

                                <asp:LinkButton ID="cancelDelAccBtn" runat="server" CssClass="btn btn-outline-primary btn-rounded py-3 me-3" OnClick="cancelDelAccBtn_Click">No</asp:LinkButton>
                                <asp:LinkButton ID="confirmDelAccBtn" runat="server" CssClass="btn btn-primary btn-rounded py-3" OnClick="confirmDelAccBtn_Click">Yes</asp:LinkButton>

                            </div>

                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function delAccSuccessful(url) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Successful',
                text: "Account deleted...Thanks for experience with us.",
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
                text: "Only customers are allowed here.",
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

