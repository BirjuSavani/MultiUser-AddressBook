<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h2>Country Add Page</h2>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12" style="color: red;">
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4" style="padding-left:35px">
                Country Name 
            </div>
            <div class="col-md-4">

                <asp:TextBox runat="server" ID="txtCountryName" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:RequiredFieldValidator ID="rvCountryName" runat="server" ControlToValidate="txtCountryName" Display="Dynamic" ErrorMessage="Country Name is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Country">* Enter Country Name</asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4" style="padding-left:35px">
                Country Code 
            </div>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="txtCountryCode" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:RequiredFieldValidator ID="rvCountryCode" runat="server" ControlToValidate="txtCountryCode" Display="Dynamic" ErrorMessage="Country Code is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Country">* Enter Country Code</asp:RequiredFieldValidator>

            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-6">
                <asp:Button runat="server" ID="btnCountrySave" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-sm" ValidationGroup="Country" />
                <asp:Button runat="server" ID="btnCancle" Text="Cancle" CssClass="btn btn-danger btn-sm" OnClick="btnCancle_Click" />

            </div>
        </div>

    </div>
</asp:Content>

