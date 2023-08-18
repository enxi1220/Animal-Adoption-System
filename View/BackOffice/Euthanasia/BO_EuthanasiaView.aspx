<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/BO_MasterPage.Master" CodeBehind="BO_EuthanasiaView.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Euthanasia.BO_EuthanasiaView1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="margin-top:0.5em;">View Euthanasia</h2>
    <hr />
    
        <div class="row mb-4">

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="euthNoTxt">Euthanasia No</label>
                <asp:TextBox ID="euthNoTxt" runat="server" CssClass="form-control border" style="background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
    </div>

    
        <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="descTxt">Description</label>
                <asp:TextBox ID="descTxt" runat="server"  CssClass="form-control border"  style="background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;" ReadOnly="True"></asp:TextBox>                   
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="medTxt">Medicine</label>
                <asp:TextBox ID="medTxt" runat="server"  CssClass="form-control border"  style="background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block;  font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;" ReadOnly="True"></asp:TextBox>                   
            </div>
        </div>
    </div>

    
        <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="doseTxt">Dose</label>
                <asp:TextBox ID="doseTxt" runat="server"  CssClass="form-control border"  style="background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;" ReadOnly="True"></asp:TextBox>                   
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="uomTxt">UOM (Unit of Measurement)</label>
                <asp:TextBox ID="uomTxt" runat="server"  CssClass="form-control border"  style="background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block;  font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;" ReadOnly="True"></asp:TextBox>                   
            </div>
        </div>
    </div>
        
        <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="statusTxt">Status</label>
                <asp:TextBox ID="statusTxt" runat="server"  CssClass="form-control border"  style="background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;" ReadOnly="True"></asp:TextBox>                   
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="form-label" for="exeDateTxt">Execution Date</label>
                <asp:TextBox ID="exeDateTxt" runat="server"  CssClass="form-control border"  style="background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;" ReadOnly="True"></asp:TextBox>                   
            </div>
        </div>
    </div>

            <div class="row mb-4">
        <div class="col-md-6">
            <div class="form-group">
                <asp:DetailsView ID="PetDetailsView" style="margin-bottom:2em; " runat="server" Height="50px" Width="1035px" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None"  AutoGenerateRows="False" HeaderText="Pet Details">
                          <AlternatingRowStyle BackColor="PaleGoldenrod" />
                          <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                          <Fields>
                              <asp:ImageField DataImageUrlField="IMAGE" SortExpression="IMAGE">
                              </asp:ImageField>
                                <asp:BoundField DataField="PETNO" HeaderText="Pet No" SortExpression="PETNO" />
                                <asp:BoundField DataField="NAME" HeaderText="Name" SortExpression="NAME" />
                                <asp:BoundField DataField="AGE" HeaderText="Age" SortExpression="AGE" />
                                <asp:BoundField DataField="SIZE" HeaderText="Size" SortExpression="SIZE" />
                                <asp:BoundField DataField="GENDER" HeaderText="Gender" SortExpression="GENDER" />
                                <asp:BoundField DataField="BREED" HeaderText="Breed" SortExpression="BREED" />
                                <asp:BoundField DataField="TYPE" HeaderText="Type" SortExpression="TYPE" />
                                <asp:BoundField DataField="DESC" HeaderText="Desc" SortExpression="DESC" />


                               
                          </Fields>
                          <FooterStyle BackColor="Tan" />
                          <HeaderStyle BackColor="Tan" Font-Bold="True" />
                          <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                      </asp:DetailsView>
            </div>
        </div>
    </div>
    
    <div style="float:right; margin-left:96em; margin-bottom:3em;">
        <asp:LinkButton ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary ms-3"  OnClientClick="JavaScript:window.history.back(1); return false;" ></asp:LinkButton>
    </div>
    
    </asp:Content>
