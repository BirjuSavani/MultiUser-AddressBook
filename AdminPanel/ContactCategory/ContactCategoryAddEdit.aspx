<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <h2>Contact Category Add Page</h2>
    <br />

    <div class="row">
        <div class="col-md-12" style="color: red">
            <asp:Label runat="server" ID="lblMeassage" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left:35px">
            ContactCategoryName
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtContactCategoryName" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvContactCategory" runat="server" ControlToValidate="txtContactCategoryName" Display="Dynamic" ErrorMessage="Contact Category Name is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="ContactCategory">* Enter Contact Category Name</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-6">
            <asp:Button runat="server" ID="btnContactCategorySave" Text="Save" OnClick="btnContactCategorySave_Click" CssClass="btn btn-sm" ValidationGroup="ContactCategory" />
            <asp:Button runat="server" ID="btnCancle" Text="Cancle" CssClass="btn btn-danger btn-sm" OnClick="btnCancle_Click" />

        </div>
    </div>
    <br />

</asp:Content>

