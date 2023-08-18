<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BO_MasterPage.Master" CodeBehind="BO_EuthanasiaEdit.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Euthanasia.BO_EuthanasiaEdit1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="margin-top:0.5em;">Edit Euthanasia</h2>
    <hr />

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="ddl_PetNo">Euthanasia No</label>
                <asp:TextBox ID="petNoTxt" runat="server"  CssClass="form-control border"  style="background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;" ReadOnly="True"></asp:TextBox>

            </div>
        </div>
    </div>
        
    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="ddl_Desc">Description</label>
                <asp:DropDownList ID="ddl_Desc" runat="server" CssClass="form-control border" Height="2.5em">
                    <asp:ListItem Text="Terminal illness, e.g. cancer or rabies" Value="Terminal illness, e.g. cancer or rabies" />
                    <asp:ListItem Text="Behavioral problems e.g. aggression" Value="Behavioral problems e.g. aggression" />
                    <asp:ListItem Text="Old age and deterioration" Value="Old age and deterioration" />
                    <asp:ListItem Text="Lack of home or caretaker or resources for feeding" Value="Lack of home or caretaker or resources for feeding" />
                    <asp:ListItem Text="Research and testing purpose" Value="Research and testing purpose" />
                    <asp:ListItem Text="Other" Value="Other" />
                </asp:DropDownList>
                  <asp:TextBox ID="txtOtherDesc" runat="server" Visible="false" CssClass="textbox" ></asp:TextBox>
                  <asp:RequiredFieldValidator ID="rfv_ddl_Desc" runat="server" style="margin-bottom:0.5em;" ControlToValidate="ddl_Desc" ErrorMessage="Please select a DESCRIPTION" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>  
          
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="ddl_med">Medicine</label>
                <asp:DropDownList ID="ddl_med" runat="server" CssClass="form-control border" Height="2.5em">
                      <asp:ListItem Text="Pentobarbital Sodium" Value="Pentobarbital Sodium" />
                        <asp:ListItem Text="Phenytoin Sodium" Value="Phenytoin Sodium" />
                        <asp:ListItem Text="Rhodamine B" Value="Rhodamine B" />
                        <asp:ListItem Text="Bluish-red fluorescent dye" Value="Bluish-red fluorescent dye" />
                        <asp:ListItem Text="Benzyl Alcohol" Value="Benzyl Alcohol" />
                        <asp:ListItem Text="IV Injection" Value="IV Injection" />
                        <asp:ListItem Text="Seizure Medication" Value="Seizure Medication" />
                        <asp:ListItem Text="Sedative" Value="Sedative" />
                        <asp:ListItem Text="Other" Value="Other" />
                  </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="rfv_ddl_med" runat="server"  style="margin-bottom:0.5em;" ControlToValidate="ddl_med" ErrorMessage="Please select a MEDICINE" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>  

            </div>
        </div>
    </div>
                  
    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="txt_Dose">Dose</label>
                 <asp:TextBox ID="txt_Dose" CssClass="form-control border" runat="server" ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="rfv_txt_Dose" runat="server" ControlToValidate="txt_Dose" ErrorMessage="Please enter the DOSE of the drug used" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>  
                  <asp:RangeValidator ID="rv_txt_Dose" runat="server"  style="margin-bottom:0.5em;" ControlToValidate="txt_Dose" ErrorMessage="Please enter proper DOSE quantity" ForeColor="Red" MaximumValue="10000.00" MinimumValue="0.1" SetFocusOnError="True" Type="Double"></asp:RangeValidator>
              
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="ddl_Uom">UOM (Unit of Measurement)</label>
                <asp:DropDownList ID="ddl_Uom" runat="server" CssClass="form-control border" Height="2.5em">
                      <asp:ListItem Text="g" Value="g" />
                        <asp:ListItem Text="mg" Value="mg" />
                        <asp:ListItem Text="ml" Value="ml" />
                        <asp:ListItem Text="cc" Value="cc" />
                  </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="rfv_ddl_Uom" runat="server" style="margin-bottom:0.5em;" ControlToValidate="ddl_Uom" ErrorMessage="Please select a UNIT OF MEASUREMENT (UOM)" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>  

            </div>
        </div>
    </div>
                 
     <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="ddl_Status">Status</label>
                <asp:DropDownList ID="ddl_Status" runat="server" CssClass="form-control border" Height="2.5em">
                    <asp:ListItem Text="Pending" Value="Pending" />
                    <asp:ListItem Text="Ready" Value="Ready" />
                    <asp:ListItem Text="Completed" Value="Completed" />
                    <asp:ListItem Text="Cancelled" Value="Cancelled" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_ddl_Status" runat="server"  style="margin-bottom:0.5em;" ControlToValidate="ddl_Status" ErrorMessage="Please select a STATUS" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>  

            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="auditNoTxt">Execution Date</label>
                <asp:TextBox ID="txt_ExeDate" class="datepicker" CssClass="form-control border" runat="server" TextMode="Date" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_txt_ExeDate" runat="server" style="margin-bottom:0.5em;" ControlToValidate="txt_ExeDate" ErrorMessage="Please select EXECUTION DATE" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>  
              
            </div>
        </div>
    </div>


    <div style="float:right; margin-top:3em; margin-bottom:3em;">
        <asp:LinkButton ID="Button1" runat="server" Text="Cancel" CssClass="btn btn-primary" CausesValidation="False" OnClick="Button1_Click" ></asp:LinkButton>
        <asp:LinkButton ID="Button2" runat="server" Text="Save" CssClass="btn btn-primary ms-3" OnClick="Button2_Click" ></asp:LinkButton>
    </div>
    
    <div class="col-md-6">
        <div class="form-group">
            <asp:HiddenField id="hiddendPetId" runat="server" />
        </div>
    </div>

    </asp:Content>