<%@ Page Language="C#" MasterPageFile="~/BO_MasterPage.Master" AutoEventWireup="true" CodeBehind="BO_EuthanasiaNew.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Euthanasia.BO_EuthanasiaNew2__01" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="margin-top:0.5em;">New Euthanasia</h2>
    <hr />

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="euthNo">Euthanasia No</label>
                <asp:TextBox ID="euthNo" runat="server" CssClass="form-control border" ReadOnly="True"></asp:TextBox>

            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="ddl_PetNo">Pet No</label>
                <asp:DropDownList ID="ddl_PetNo" runat="server"  emptyDataText="No records found!" CssClass="form-control border" Height="2.5em" AutoPostBack="True" OnSelectedIndexChanged="ddl_PetNo_SelectedIndexChanged"></asp:DropDownList>

                  <asp:RequiredFieldValidator ID="rfv_ddl_PetNo" runat="server" style="margin-bottom:0.5em;" ControlToValidate="ddl_PetNo" ErrorMessage="Please select a PET NO" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>  

            </div>
        </div>
    </div>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">

                <asp:DetailsView ID="PetDetailsView" style="margin-bottom:2em;" runat="server" Height="50px" Width="1035px" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None"  AutoGenerateRows="False" HeaderText="PET DETAILS">
                          <AlternatingRowStyle BackColor="PaleGoldenrod" />
                          <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                          <Fields>
                              <asp:ImageField DataImageUrlField="IMAGE" SortExpression="IMAGE">
                              </asp:ImageField>
                               <asp:BoundField DataField="PETNO" HeaderText="PETNO" SortExpression="PETID" />
                                <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                                <asp:BoundField DataField="AGE" HeaderText="AGE" SortExpression="AGE" />
                                <asp:BoundField DataField="SIZE" HeaderText="SIZE" SortExpression="SIZE" />
                                <asp:BoundField DataField="BREED" HeaderText="BREED" SortExpression="BREED" />
                                <asp:BoundField DataField="TYPE" HeaderText="TYPE" SortExpression="TYPE" />
                                <asp:BoundField DataField="DESC" HeaderText="DESC" SortExpression="DESC" />
            
                          </Fields>
                          <FooterStyle BackColor="Tan" />
                          <HeaderStyle BackColor="Tan" Font-Bold="True" />
                          <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                      </asp:DetailsView>
            </div>
        </div>
    </div>
        
    <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="ddl_Desc">Description</label>
                <asp:DropDownList ID="ddl_Desc" runat="server" CssClass="form-control border" Height="2.5em">
                    <asp:ListItem Text="-- Select Description --" Value="" Enabled="True" />
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
                       <asp:ListItem Text="-- Select Medicine --" Value="" Enabled="True" /> 
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
                   <asp:RequiredFieldValidator ID="rfv_txt_Dose" runat="server" ControlToValidate="txt_Dose" ErrorMessage="Please select the DOSE of the drug used" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>  
                  <asp:RangeValidator ID="rv_txt_Dose" runat="server"  style="margin-bottom:0.5em;" ControlToValidate="txt_Dose" ErrorMessage="Please enter proper DOSE quantity" ForeColor="Red" MaximumValue="10000" MinimumValue="0.1" SetFocusOnError="True" Type="Double"></asp:RangeValidator>
              
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="ddl_Uom">UOM (Unit of Measurement)</label>
                <asp:DropDownList ID="ddl_Uom" runat="server" CssClass="form-control border" Height="2.5em">
                       <asp:ListItem Text="-- Select Unit Of Measurement (UOM) --" Value="" Enabled="True" />  
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
                    <asp:ListItem Text="-- Select Status --" Value="" Enabled="True" />  
                    <asp:ListItem Text="Pending" Value="Pending" />
                    <asp:ListItem Text="Ready" Value="Ready" />
                    <asp:ListItem Text="Completed" Value="Completed" />
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


    <div style="float:right; margin-top:3em; margin-bottom:2em;">
        <asp:LinkButton ID="btnCancel9" runat="server" Text="Cancel" CssClass="btn btn-primary" CausesValidation="False" OnClick="btnCancel_Click"></asp:LinkButton>
        <asp:LinkButton ID="btnSave9" runat="server" Text="Save" CssClass="btn btn-primary ms-3"  OnClick="btnSave_Click"></asp:LinkButton>
    </div>

</asp:Content>
