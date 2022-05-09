<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="AdminPanel_Login_SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sign Up Page</title>
    <link href="../../Content/Css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../../Content/Css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Css/Cust.css" rel="stylesheet" />
    <script src="../../Content/Js/bootstrap.bundle.min.js"></script>
</head>
<body style="background-image: url('../../Content/Image/bg.jpg'); background-repeat: no-repeat; background-position: center">
    <form id="form1" runat="server">
        <%--<div class="container-fluid">
            <div class="row" style="padding-top: 40px">
                <div class="col-md-12">
                    <h1 style="text-align: center; font-size: 1.9rem; background-image: url('../../Content/Image/header.jpg'); color: white; padding: 5px">WELCOME</h1>
                    <br />
                    <br />
                </div>
            </div>--%>
            <section class="ftco-section">
                <div class="container">

                    <div class="row justify-content-center">
                        <div class="col-md-6 col-lg-4">
                            <div class="login-wrap p-0">
                                <h3 class="mb-4 text-center">Sign UP For New User</h3>
                                <form action="#" class="signin-form">
                                    <div class="form-group" style="transition: none">
                                        <asp:TextBox ID="txtUsernameSignup" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rvUserNameLigon" runat="server" ControlToValidate="txtUsernameSignup" Display="Dynamic" ErrorMessage="User Name is mandaory" ForeColor="bisque" SetFocusOnError="True" ValidationGroup="SignUp">* Enter User Name</asp:RequiredFieldValidator>

                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPasswordSignup" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>

                                        <span toggle="#password-field" class="fa fa-fw fa-eye field-icon toggle-password"></span>
                                        <asp:RequiredFieldValidator ID="rvPasswordLogin" runat="server" ControlToValidate="txtPasswordSignup" Display="Dynamic" ErrorMessage="Password is mandaory" ForeColor="bisque" SetFocusOnError="True" ValidationGroup="SignUp">* Enter Password</asp:RequiredFieldValidator>

                                    </div>
                                    <div class="form-group" style="transition: none">
                                        <asp:TextBox ID="txtMobileNumberSignup" runat="server" CssClass="form-control" placeholder="ContactNo"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rvMobileNumber" runat="server" ControlToValidate="txtMobileNumberSignup" Display="Dynamic" ErrorMessage="Mobile Number is mandaory" ForeColor="bisque" SetFocusOnError="True" ValidationGroup="SignUp">* Enter Mobile Number</asp:RequiredFieldValidator>

                                    </div>
                                    <div class="form-group" style="transition: none">
                                        <asp:TextBox ID="txtDisplayNameSignup" runat="server" CssClass="form-control" placeholder="Display Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rvDisplayName" runat="server" ControlToValidate="txtDisplayNameSignup" Display="Dynamic" ErrorMessage="Display Name is mandaory" ForeColor="bisque" SetFocusOnError="True" ValidationGroup="SignUp">* Enter Display Name</asp:RequiredFieldValidator>

                                    </div>
                                    <div class="form-group" style="transition: none">
                                        
                                        <asp:TextBox ID="txtEmailSignup" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rvEmailSignup" runat="server" ControlToValidate="txtEmailSignup" Display="Dynamic" ErrorMessage="Email is mandaory" ForeColor="bisque" SetFocusOnError="True" ValidationGroup="SignUp">* Enter Email</asp:RequiredFieldValidator>
                                        &nbsp;&nbsp;&nbsp;<asp:RegularExpressionValidator ID="rvEmail" runat="server" ErrorMessage="Email ID is incorrect" ControlToValidate="txtEmailSignup" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Invalid Email ID</asp:RegularExpressionValidator>

                                    </div>
                                    <div class="form-group">
                                        <asp:Button runat="server" ID="btnSignup" Text="Sign Up" class="form-control btn btn-primary submit px-3" OnClick="btnSignup_Click" ValidationGroup="SignUp" />

                                        <asp:Button runat="server" ID="btnCancle" Text="Cancel" class="form-control btn btn-danger submit px-3 " OnClick="btnCancle_Click" />

                                    </div>
                                    <div style="color: white">
                                        <asp:Label ID="lblMessageSignup" runat="server"></asp:Label>

                                    </div>

                                </form>
                                <p class="w-100 text-center" style="color: bisque">
                                    &mdash;A member?
                                        <asp:HyperLink ID="hlSignUp" runat="server" NavigateUrl="~/AdminPanel/Login/Login.aspx" ForeColor="White">Sign In</asp:HyperLink>
                                    &mdash;
                                </p>

                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </form>
</body>
</html>
