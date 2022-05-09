<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>City Add Page</h2>
            <br />
        </div>
    </div>
    <div class="row">
        <div class="Col-md-12" style="color: red">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
        </div>
        <br />
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left:35px">
            State
        </div>
        <div class="col-md-4">
            <asp:DropDownList runat="server" ID="ddlState" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvddlist" runat="server" ControlToValidate="ddlState" Display="Dynamic" ErrorMessage="Select State is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="City" InitialValue="-1">* Select State Name</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left:35px">
            City Name
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtCityName" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvCityName" runat="server" ControlToValidate="txtCityName" Display="Dynamic" ErrorMessage="City Name is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="City">* Enter City Name</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left:35px">
            City Code
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtCityCode" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvCityCode" runat="server" ControlToValidate="txtCityCode" Display="Dynamic" ErrorMessage="City Code is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="City">* Enter City Code</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left:35px">
            City Pin Code
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtCityPinCode" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rcCityPinCode" runat="server" ControlToValidate="txtCityPinCode" Display="Dynamic" ErrorMessage="City Pin Code is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="City">* Enter Pin Code</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-6">
            <asp:Button runat="server" ID="btnStateSave" Text="Save"  OnClick="btnStateSave_Click" CssClass="btn btn-sm" ValidationGroup="City" />
            <asp:Button runat="server" ID="btnCancle" Text="Cancle" CssClass="btn btn-danger btn-sm" OnClick="btnCancle_Click" />
        </div>
    </div>


</asp:Content>

