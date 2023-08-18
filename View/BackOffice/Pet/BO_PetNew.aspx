<%@ Page Title="" Language="C#" MasterPageFile="~/BO_MasterPage.Master" AutoEventWireup="true" CodeBehind="BO_PetNew.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Pet.BO_PetNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3 ">New Pet</h2>
    <hr />
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

                <asp:TextBox ID="petNameTxt" runat="server" CssClass="form-control border" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="petNameRequiredValidator"
                    runat="server"
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please enter Pet Name."
                    ControlToValidate="petNameTxt"
                    Display="Dynamic"
                    CssClass="text-danger">
                </asp:RequiredFieldValidator>
                
                <asp:RegularExpressionValidator 
                    ID="petNameRegularExpressionValidator"
                    runat="server"
                    ControlToValidate="petNameTxt" 
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please enter characters only."
                    Display="Dynamic"
                    ValidationExpression="^[A-Za-z\s]+$"
                    CssClass="text-danger">
                </asp:RegularExpressionValidator>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-12">
            <div class="form-group">
                <label class="form-label" for="descriptionTxt">Description</label>
                <asp:TextBox ID="descriptionTxt" runat="server" CssClass="form-control border" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="petDescRequiredFieldValidator"
                    runat="server"
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please enter Description."
                    ControlToValidate="descriptionTxt"
                    Display="Dynamic"
                    CssClass="text-danger">
                </asp:RequiredFieldValidator>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="petAgeTxt">Pet Age</label>
                <asp:DropDownList ID="ddlAge" runat="server" AppendDataBoundItems="true" CssClass="form-control border">
                    <asp:ListItem Text="" Value="" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator
                    ID="petAgeRequiredFieldValidator"
                    runat="server"
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please select Pet Age."
                    ControlToValidate="ddlAge"
                    Display="Dynamic"
                    CssClass="text-danger">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="petSizeTxt">Pet Size</label>
                <asp:DropDownList ID="ddlSize" runat="server" AppendDataBoundItems="true" CssClass="form-control border">
                    <asp:ListItem Text="" Value="" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator
                    ID="petSizeRequiredFieldValidator"
                    runat="server"
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please select Pet Size."
                    ControlToValidate="ddlSize"
                    Display="Dynamic"
                    CssClass="text-danger">
                </asp:RequiredFieldValidator>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="petBreedTxt">Pet Breed</label>
                <asp:TextBox ID="petBreedTxt" runat="server" CssClass="form-control border" MaxLength="200"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="petBreedRequiredFieldValidator"
                    runat="server"
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please enter Pet Breed."
                    ControlToValidate="petBreedTxt"
                    Display="Dynamic"
                    CssClass="text-danger">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator 
                    ID="petBreedRegularExpressionValidator"
                    runat="server"
                    ControlToValidate="petBreedTxt" 
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please enter characters only."
                    Display="Dynamic"
                    ValidationExpression="^[A-Za-z\s]+$"
                    CssClass="text-danger">
                </asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="petTypeTxt">Pet Type</label>
                <asp:TextBox ID="petTypeTxt" runat="server" CssClass="form-control border" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="petTypeRequiredFieldValidator"
                    runat="server"
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please enter Pet Type."
                    ControlToValidate="petTypeTxt"
                    Display="Dynamic"
                    CssClass="text-danger">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator 
                    ID="petTypeRegularExpressionValidator"
                    runat="server"
                    ControlToValidate="petTypeTxt" 
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please enter characters only."
                    Display="Dynamic"
                    ValidationExpression="^[A-Za-z\s]+$"
                    CssClass="text-danger">
                </asp:RegularExpressionValidator>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="petGender">Gender</label>
                <asp:DropDownList ID="petGender" runat="server" CssClass="form-control border">
                    <asp:ListItem Text="" Value="" />
                    <asp:ListItem Text="Male" Value="M" />
                    <asp:ListItem Text="Female" Value="F" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator
                    ID="petGenderRequiredFieldValidator"
                    runat="server"
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please select Gender."
                    ControlToValidate="petGender"
                    Display="Dynamic"
                    CssClass="text-danger">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="auditPeriodTxt">Audit Period</label>
                <asp:TextBox ID="auditPeriodTxt" runat="server" CssClass="form-control border" MaxLength="9999"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="auditRequiredFieldValidator"
                    runat="server"
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please enter Audit Period."
                    ControlToValidate="auditPeriodTxt"
                    Display="Dynamic"
                    CssClass="text-danger">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator 
                    ID="auditRegularExpressionValidator"
                    runat="server"
                    ControlToValidate="auditPeriodTxt" 
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please enter numbers only."
                    ValidationExpression="\d+"
                    Display="Dynamic"
                    CssClass="text-danger">
                </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator 
                    ID="auditValueRegularExpressionValidator"
                    runat="server"
                    ControlToValidate="auditPeriodTxt" 
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Audit period must more than 1."
                    ValidationExpression="\b0*([0-9]{1,9}|1[0-9]{9}|2(0[0-9]{8}|1([0-3][0-9]{7}|4([0-6][0-9]{6}|7([0-3][0-9]{5}|4([0-7][0-9]{4}|8([0-2][0-9]{3}|3([0-5][0-9]{2}|6([0-3][0-9]|4[0-7])))))))))\b"
                    Display="Dynamic"
                    CssClass="text-danger">
                </asp:RegularExpressionValidator>
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
                    <asp:TextBox ID="txtAdoptionTime" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>
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
                    <asp:FileUpload ID="petImageFile" runat="server" CssClass="form-control border" />
                    <asp:RequiredFieldValidator
                        ID="petImgRequiredFieldValidator"
                        runat="server"
                        ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please select Pet Image."
                        ControlToValidate="petImageFile"
                        Display="Dynamic"
                        CssClass="text-danger">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    </div>

    <div class="float-end mb-5">
        <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="btnCancel_Click" CausesValidation="false" />
        <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary ms-3" OnClick="btnSave_Click" />
    </div>

</asp:Content>
