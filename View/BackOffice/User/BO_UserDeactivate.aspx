<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BO_MasterPage.Master"  CodeBehind="BO_UserDeactivate.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.User.BO_UserDeactivate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3 ">Deactivate Staff / Admin</h2>
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
                <label CssClass="form-label" for="nameTxt">Name</label>
                
                <asp:TextBox ID="nameTxt" runat="server" CssClass="form-control border" style="background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;" ReadOnly="True"></asp:TextBox>
                
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label CssClass="form-label" for="usernameTxt">Username</label>
                
                <asp:TextBox ID="usernameTxt" runat="server" CssClass="form-control border" style="background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;" ReadOnly="True"></asp:TextBox>
                
             </div>
        </div>
    </div>

    
        <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label  CssClass="form-label" for="mailTxt">Mail </label>
            
            <asp:TextBox ID="mailTxt" runat="server" CssClass="form-control border" style="background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;" ReadOnly="True"></asp:TextBox>

            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label CssClass="form-label" for="phoneTxt">Phone</label>
                <asp:TextBox ID="phoneTxt" runat="server" CssClass="form-control border" Display="Dynamic" style="background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;" ReadOnly="True"></asp:TextBox>

               </div>
        </div>
    </div>

    
        <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label  CssClass="form-label"  for="positionDdl">Position 
           
                </label>
                 
                <asp:TextBox ID="positionTxt" runat="server" CssClass="form-control border" Display="Dynamic" style="background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;" ReadOnly="True"></asp:TextBox>

                </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label id="statusLabel" runat="server" CssClass="form-label" for="statusTxt" >Status 
                </label>
                <asp:TextBox ID="statusTxt" runat="server" CssClass="form-control border" Display="Dynamic" style="background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;" ReadOnly="True"></asp:TextBox>
             </div>
        </div>
    </div>

        <div class="float-end">
        <asp:LinkButton ID="btnDeactivate1" runat="server" Text="Deactivate" CssClass="btn btn-primary ms-3" OnClick="btnDeactivate_Click" ></asp:LinkButton>
            <asp:LinkButton ID="btnBack1" runat="server" Text="Back" CssClass="btn btn-primary ms-3"  OnClientClick="JavaScript:window.history.back(1); return false;" ></asp:LinkButton>
    </div>
  
    <div class="col-md-6">
        <div class="form-group">
            <asp:HiddenField id="hiddendUserId" runat="server" />
        </div>
    </div>

</asp:Content>


