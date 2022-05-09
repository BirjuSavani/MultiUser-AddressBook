<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>State Add Edit Page</h2>
            <br />
        </div>
    </div>
    <div style="color: red">
        <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left:35px">
            Country
        </div>
        <div class="col-md-4">
            <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvddLCountry" runat="server" ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage=" Select State Name is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="State" InitialValue="-1">* Select Country Name</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left:35px">
            State Name
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtStateName" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvStateName" runat="server" ControlToValidate="txtStateName" Display="Dynamic" ErrorMessage="State Name is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="State">* Enter State Name</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left:35px">
            State Code
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtStateCode" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvStateCode" runat="server" ControlToValidate="txtStateCode" Display="Dynamic" ErrorMessage="State Code is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="State">* Enter State Code</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-6">
            <asp:Button runat="server" ID="btnStateSave" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-sm" ValidationGroup="State" />
            <asp:Button runat="server" ID="btnStateCancle" Text="Cancle" CssClass="btn btn-danger btn-sm" OnClick="btnStateCancle_Click" />

        </div>
    </div>
    <br />

    <br />
</asp:Content>

