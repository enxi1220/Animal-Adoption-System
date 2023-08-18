<%@ Page Title="" Language="C#" MasterPageFile="~/BO_MasterPage.Master" AutoEventWireup="true" CodeBehind="BO_UserEdit.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.User.BO_UserEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <h2 class="mt-3 ">Edit Staff / Admin</h2>
    <hr />

    
    <style>

        .txtbox{
            min-height: auto;
            padding: 0.33em 0.75em;
            transition: all .2s linear;
            opacity: 1;
            border: 1px solid #e0e0e0 !important;
            display: block;
            width: 100%;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.6;
            color: #4f4f4f;
            appearance: none;
            border-radius: 0.25rem;
            margin: 0;
            font-family: inherit;
            box-sizing: border-box;
            margin-top: 0.5rem;
            margin-bottom: 1.5rem;
        }
        .label{
            color: rgba(0,0,0,.6);
            display: inline-block;
            box-sizing: border-box;
            padding:5em;
            margin:5em;
        }
    </style>



    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label CssClass="form-label" for="nameTxt">Name</label><asp:RequiredFieldValidator ID="nameRFV" runat="server" style="margin-bottom:0.5em;" ControlToValidate="nameTxt" ErrorMessage="Please enter name" ForeColor="Red" Display="Dynamic" ValidationGroup="vg">*</asp:RequiredFieldValidator>  
                <asp:RegularExpressionValidator ID="nameValidator" runat="server" ControlToValidate="nameTxt" ValidationExpression="^[A-Za-z\s]+$" Display="Dynamic" ErrorMessage="Please enter a proper name eg. John Doe" ForeColor="Red" ValidationGroup="vg">*</asp:RegularExpressionValidator>
                <asp:TextBox ID="nameTxt" runat="server" CssClass="form-control border"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label CssClass="form-label" for="phoneTxt">Phone</label><asp:RegularExpressionValidator ID="phoneValidator" runat="server" ControlToValidate="phoneTxt" ValidationExpression="[01][0-9]{8,9}" Display="Dynamic" ForeColor="Red"  ErrorMessage="Please enter a proper phone no eg. 0123456789" ValidationGroup="vg">*</asp:RegularExpressionValidator>                <asp:RequiredFieldValidator ID="phoneRFV" runat="server" style="margin-bottom:0.5em;" ControlToValidate="phoneTxt" ErrorMessage="Please enter phone no" ForeColor="Red" Display="Dynamic" ValidationGroup="vg">*</asp:RequiredFieldValidator>  
                <asp:TextBox ID="phoneTxt" runat="server" CssClass="form-control border" Display="Dynamic"></asp:TextBox>
            </div>
        </div>
     </div>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label  CssClass="form-label" for="mailTxt">Mail </label>
            <asp:RegularExpressionValidator ID="mailValidator" runat="server" ControlToValidate="mailTxt" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ErrorMessage="Please enter a proper email eg. abc@gmail.com" ForeColor="Red" ValidationGroup="vg">*</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="mailRFV" runat="server" style="margin-bottom:0.5em;" ControlToValidate="mailTxt" ErrorMessage="Please enter mail" ForeColor="Red" Display="Dynamic" ValidationGroup="vg">*</asp:RequiredFieldValidator>  
            <asp:TextBox ID="mailTxt" runat="server" CssClass="form-control border"></asp:TextBox>
            </div>
        </div>
     
        <div class="col-md-6">
            <div class="form-group">
                <label  CssClass="form-label"  for="positionDdl">Position <asp:RequiredFieldValidator ID="rfvPosition" runat="server" style="margin-bottom:0.5em;" ControlToValidate="positionDdl" ErrorMessage="Please select a position" ForeColor="Red" Display="Dynamic" ValidationGroup="vg">*</asp:RequiredFieldValidator>  
           
                </label><br />
                 <asp:DropDownList ID="positionDdl" runat="server" CssClass="form-control border"  Height="2.5em" AutoPostBack="True" >
                    <asp:ListItem Text="Admin" Value="Admin" />
                    <asp:ListItem Text="Staff" Value="Staff" />
                </asp:DropDownList>

            </div>
        </div>
     
    </div>


    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage=""  ValidationGroup="vg" OnServerValidate="customValidator_ServerValidate" Display="Dynamic" ForeColor="white" style="visibility: hidden;"></asp:CustomValidator>
                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage=""  ValidationGroup="vg" OnServerValidate="customValidator2_ServerValidate" Display="Dynamic" ForeColor="white" style="visibility: hidden;"></asp:CustomValidator>
                <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage=""  ValidationGroup="vg" OnServerValidate="customValidator3_ServerValidate" Display="Dynamic" ForeColor="white" style="visibility: hidden;"></asp:CustomValidator>
                <asp:CustomValidator ID="mailLengthValidator" runat="server" ErrorMessage=""  ValidationGroup="vg" OnServerValidate="customValidator5_ServerValidate" Display="Dynamic" ForeColor="white" style="visibility: hidden;"></asp:CustomValidator>
                <asp:CustomValidator ID="nameLengthValidator" runat="server" ErrorMessage=""  ValidationGroup="vg" OnServerValidate="nameLengthValidator_ServerValidate" Display="Dynamic" ForeColor="white" style="visibility: hidden;"></asp:CustomValidator>

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="vg"/>  
             </div>
        </div>
    </div>


    <div style="float:right; margin-top:3em;margin-bottom:3em;">
        <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary"  CausesValidation="False" OnClick="btnCancel_Click" ></asp:LinkButton>
        <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary ms-3" ValidationGroup="vg" OnClick="btnSave_Click"></asp:LinkButton>
    </div>

</asp:Content>
