<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_Login_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Login Page</title>
    <link href="../../Content/Css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../../Content/Css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Content/Js/bootstrap.bundle.min.js"></script>
    <link href="../../Content/Css/Cust.css" rel="stylesheet" />
    <style type="text/css">
        .table-secondary {
            width: 485px;
        }
    </style>
</head>
<body class="img js-fullheight" style="background-position: center; background-image: url('../../Content/Image/bg.jpg'); background-repeat: no-repeat;">
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row" style="padding-top: 40px">
                <div class="col-md-12">
                    <h1 style="text-align: center; font-size: 1.9rem; background-image: url('../../Content/Image/header.jpg'); color: white; padding: 5px">WELCOME</h1>
                    <br />
                    <br />
                </div>
            </div>
            <section class="ftco-section">
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-md-6 col-lg-4">
                            <div class="login-wrap p-0">
                                <h3 class="mb-4 text-center">Have an account?</h3>
                                <form action="#" class="signin-form">
                                    <div class="form-group" style="transition: none">
                                        <asp:TextBox ID="txtUserNameLogin" runat="server" CssClass="form-control " placeholder="Username"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rvUserNameLigon" runat="server" ControlToValidate="txtUserNameLogin" Display="Dynamic" ErrorMessage="User Name is mandaory" ForeColor="bisque" SetFocusOnError="True" ValidationGroup="login">* Enter User Name</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPasswordLogin" runat="server" CssClass="form-control" Type="password" placeholder="Password"></asp:TextBox>

                                        <%-- <input id="password-field" type="password" class="form-control" placeholder="Password" required>--%>
                                        <span toggle="#password-field" class="fa fa-fw fa-eye field-icon toggle-password"></span>
                                        <asp:RequiredFieldValidator ID="rvPasswordLogin" runat="server" ControlToValidate="txtPasswordLogin" Display="Dynamic" ErrorMessage="Password is mandaory" ForeColor="bisque" SetFocusOnError="True" ValidationGroup="login">* Enter Password</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <%--<button type="submit" class="form-control btn btn-primary submit px-3">Sign In</button>--%>
                                        <asp:Button runat="server" ID="btnLogin" Text="Login" class="form-control btn btn-primary submit px-3" OnClick="btnLogin_Click" ValidationGroup="login" />
                                    </div>
                                    <div style="color: white">
                                        <asp:Label ID="lblMessageLogin" runat="server"></asp:Label>
                                    </div>
                                </form>
                                <p class="w-100 text-center" style="color: bisque">
                                    &mdash;Not a member?
                                    <asp:HyperLink ID="hlSignUp" runat="server" NavigateUrl="~/AdminPanel/Login/SignUp.aspx" ForeColor="White">Sign Up</asp:HyperLink>
                                    &mdash;
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
    </form>
</body>
</html>
