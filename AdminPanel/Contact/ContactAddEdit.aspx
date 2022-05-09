<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>Contact Add Page</h2>
            <br />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12" style="color: red">
            <asp:Label runat="server" ID="lblMeassage" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left: 35px">
            Country
        </div>
        <div class="col-md-4">
            <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvCountryList" runat="server" ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="Country Name is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="contact" InitialValue="-1">* Select Country Name</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left: 35px">
            State
        </div>
        <div class="col-md-4">
            <asp:DropDownList runat="server" ID="ddlState" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvStateList" runat="server" ControlToValidate="ddlState" Display="Dynamic" ErrorMessage="State Name is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="contact" InitialValue="-1">* Select State Name</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left: 35px">
            City
        </div>
        <div class="col-md-4">
            <asp:DropDownList runat="server" ID="ddlCity" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvCityList" runat="server" ControlToValidate="ddlCity" Display="Dynamic" ErrorMessage="City Name is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="contact" InitialValue="-1">* Select City Name</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left: 35px">
            ContactCategory
        </div>
        <div class="col-md-4">
            <asp:CheckBoxList ID="cblContactCategory" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
            <%--<asp:DropDownList runat="server" ID="ddlContactCategory" CssClass="form-control"></asp:DropDownList>--%>
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblContectCategoryMassage" runat="server" ForeColor="Red" Visible="false"></asp:Label>

            <%--<asp:RequiredFieldValidator ID="rvContactCategoryList" runat="server" ControlToValidate="cblContactCategory" Display="Dynamic" ErrorMessage="Contact Category Name is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="contact" InitialValue="-1">* Select Contact Category Name</asp:RequiredFieldValidator>
            --%>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left: 35px">
            Contact Name
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtContactName" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvContactName" runat="server" ControlToValidate="txtContactName" Display="Dynamic" ErrorMessage="Contact Name is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="contact">* Enter Contact Name</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left: 35px">
            Contact Number
        </div>
        <div class="col-md-4">
            <%--<asp:RegularExpressionValidator ID="revContactNumber" runat="server" ControlToValidate="txtContactNumber" Display="Dynamic" ErrorMessage="Enter The Valide Mobile Number" ForeColor="Red" ValidationExpression="/((\+*)((0[ -]*)*|((91 )*))((\d{12})+|(\d{10})+))|\d{5}([- ]*)\d{6}/"></asp:RegularExpressionValidator>--%>
            <asp:TextBox runat="server" ID="txtContactNumber" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvContactNumber" runat="server" ControlToValidate="txtContactNumber" Display="Dynamic" ErrorMessage="Contact nuumber is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="contact">* Enter Contact Number</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left: 35px">
            Whatsapp Number
        </div>
        <div class="col-md-4">

            <asp:TextBox runat="server" ID="txtWhatsappNumber" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvWhatsappNumber" runat="server" ControlToValidate="txtWhatsappNumber" Display="Dynamic" ErrorMessage="Whatsapp Number is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="contact">* Enter Whatsapp Number</asp:RequiredFieldValidator>
            <%--<asp:RegularExpressionValidator ID="revWhatsAppNo" runat="server" ControlToValidate="txtWhatsappNumber" Display="Dynamic" ErrorMessage="Kindly Enter The Whatsapp Number" ForeColor="Red" ValidationExpression="/((\+*)((0[ -]*)*|((91 )*))((\d{12})+|(\d{10})+))|\d{5}([- ]*)\d{6}/"></asp:RegularExpressionValidator>--%>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left: 35px">
            BirthDate
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtBirthDate" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvBirthDate" runat="server" ControlToValidate="txtBirthDate" Display="Dynamic" ErrorMessage="Bith Date is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="contact">* Enter Birth-Date</asp:RequiredFieldValidator>

        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left: 35px">
            Email
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="contact">* Enter Email</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email ID is incorrect" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Invalid Email ID</asp:RegularExpressionValidator>

        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left: 35px">
            Blood Group
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtBloodGroup" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvBloodGroup" runat="server" ControlToValidate="txtBloodGroup" Display="Dynamic" ErrorMessage="Blood Group is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="contact">* Enter Blood Group</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left: 35px">
            Age
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtAge" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvAge" runat="server" ControlToValidate="txtAge" Display="Dynamic" ErrorMessage="Age is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="contact">* Enter Age</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left: 35px">
            Address
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvAddress" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Address is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="contact">* Enter Address</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4" style="padding-left: 35px">
            Select a photo to upload
        </div>
        <div class="col-md-4">
            <asp:FileUpload ID="fuFile" runat="server" />
        </div>
        <div class="col-md-4">
            <asp:RequiredFieldValidator ID="rvFileUplode" runat="server" ControlToValidate="fuFile" Display="Dynamic" ErrorMessage="File Uplode is mandaory" ForeColor="Red" SetFocusOnError="True" ValidationGroup="contact">* Enter File</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-6">
            <asp:Button runat="server" ID="btnContactCategorySave" Text="Save" OnClick="btnContactCategorySave_Click" CssClass="btn btn-sm" ValidationGroup="contact" />
            <asp:Button runat="server" ID="btnCancle" Text="Cancle" CssClass="btn btn-danger btn-sm" OnClick="btnCancle_Click" />
        </div>
    </div>
    <br />

</asp:Content>

