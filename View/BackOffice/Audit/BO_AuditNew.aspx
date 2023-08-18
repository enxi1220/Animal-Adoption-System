<%@ Page Title="" Language="C#" MasterPageFile="~/BO_MasterPage.Master" AutoEventWireup="true" CodeBehind="BO_AuditNew.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Audit.BO_AuditNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3 ">New Audit</h2>
    <hr />
    <div class="row mb-4">
        <div class="col-md-6">
            <div class="">
                <label class="form-label" for="auditNoTxt">Audit No</label>
                <asp:TextBox ID="txtAuditNo" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="petNotxt">Pet No</label>
                <span class="text-danger">*</span>
                <asp:DropDownList ID="ddlPetNo" runat="server" AppendDataBoundItems="true" CssClass="form-control border">
                    <asp:ListItem Text="" Value="" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator
                    ID="petNoRequiredValidator"
                    runat="server"
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Please select a pet."
                    ControlToValidate="ddlPetNo"
                    Display="Dynamic"
                    CssClass="text-danger">
                </asp:RequiredFieldValidator>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="doseTxt">Booking Time</label>
                <asp:TextBox ID="dtBookingTime" CssClass="form-control border" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="bookingTimeRequiredFieldValidator"
                    runat="server"
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Booking time is required."
                    ControlToValidate="dtBookingTime"
                    Display="Dynamic"
                    CssClass="text-danger"
                    Enabled="False">
                </asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="form-group">
                    <label class="form-label" for="startTimeTxt">Starting Time</label>
                    <asp:TextBox ID="dtStartingTime" CssClass="form-control border" runat="server" TextMode="DateTimeLocal" OnTextChanged="dtStartingTime_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="startingTimeRequiredFieldValidator"
                        runat="server"
                        ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Starting time is required."
                        ControlToValidate="dtStartingTime"
                        Display="Dynamic"
                        CssClass="text-danger"
                        Enabled="False">
                    </asp:RequiredFieldValidator>
                    <asp:CompareValidator
                        ID="startingTimeCompareValidator"
                        runat="server"
                        ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i>Starting time must be later than booking time."
                        Operator="GreaterThanEqual"
                        CssClass="text-danger"
                        ControlToCompare="dtBookingTime"
                        ControlToValidate="dtStartingTime">
                    </asp:CompareValidator>
                </div>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-12">
            <div class="form-group">
                <label class="form-label" for="descriptionTxt">Description</label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control border" TextMode="MultiLine" MaxLength="200"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="medicineTxt">Condition</label>
                <asp:DropDownList ID="ddlCondition" runat="server" AppendDataBoundItems="true" CssClass="form-control border">
                    <asp:ListItem Text="" Value="" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator
                    ID="conditionRequiredFieldValidator"
                    runat="server"
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i> Condition is required."
                    ControlToValidate="ddlCondition"
                    Display="Dynamic"
                    CssClass="text-danger" 
                    Enabled="False">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="completionTimeTxt">Completion Time</label>
                <asp:TextBox ID="dtCompletionTime" CssClass="form-control border" runat="server" TextMode="DateTimeLocal" OnTextChanged="dtCompletionTime_TextChanged"></asp:TextBox>
                <asp:CompareValidator
                    ID="completionTimeCompareValidator"
                    runat="server"
                    ErrorMessage="<i class='fas fa-exclamation-circle me-2'></i>Completion time must be later than starting time."
                    Operator="GreaterThan"
                    CssClass="text-danger"
                    ControlToCompare="dtStartingTime"
                    ControlToValidate="dtCompletionTime">
                </asp:CompareValidator>
            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6 ">
            <div class="form-group">
                <label class="form-label" for="statusTxt">Status</label>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="float-end">
        <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClientClick="JavaScript:window.history.back(1); return false;"/>
        <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary ms-3" OnClick="btnSave_Click" />
        
    </div>
</asp:Content>
