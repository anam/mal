<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login Page</title>
    <link href="~/App_Themes/CoffeyGreen/css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="~/App_Themes/CoffeyGreen/css/superfish.css"
        media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="header" style="padding-bottom:0px;">
        <!-- Begin: header -->
        <div id="headerWrapper" style="width: 600px;">
            <div class="headerTop">
                <!-- Begin: headerTop -->
                <h1 class="logo">
                    <a style="color: #fff;" href="Default.aspx"></a></h1>
            </div>
        </div>
    </div>
    <div class="page">
        <div class="content-box" style="width:600px; margin:0 auto 40px auto; overflow: hidden;">
            <div class="header">
                <h3>
                    Login
                    <asp:Label ID="lblLoginSession" runat="server" Text=""></asp:Label>
                    </h3>
            </div>
            <div class="inner-form">
                <asp:Login ID="myLogin" runat="server" CreateUserText="" CreateUserUrl="" RememberMeSet="True"
                    TitleText="" UserNameLabelText="Username:" OnAuthenticate="myLogin_Authenticate"
                    OnLoginError="myLogin_LoginError" DestinationPageUrl="~/Default.aspx">
                    <LayoutTemplate>
                        <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0">
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="UserName" runat="server" CssClass="txt"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="myLogin">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="myLogin">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        
                                        <tr style="display:none;">
                                            <td colspan="2">
                                                <asp:CheckBox ID="RememberMe" runat="server" Checked="true" Text="Remember me next time." />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color: Red;">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="right">
                                                <asp:Button ID="LoginButton" runat="server" CssClass="button button-blue" CommandName="Login"
                                                    Text="Log In" ValidationGroup="myLogin" />
                                                <asp:Button ID="btnForgetPassword" runat="server" Text="Forgot Password" CssClass="button button-ash" PostBackUrl="~/ForgetPassword.aspx" />
                                            </td>
                                        </tr>
                                        <%--<tr>
                                    <td colspan="2">
                                        <asp:HyperLink ID="CreateUserLink" runat="server" 
                                            NavigateUrl="~/Membership/EnhancedCreateUserWizard.aspx">Not registered yet? 
                                        Create an account!</asp:HyperLink>
                                    </td>
                                </tr>--%>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                </asp:Login>
            </div>
        </div>
    </div>
    <div id="footer">
        <div id="footer-inner">
            <div class="footerTop">
                <asp:Literal ID="litFooterMenu" runat="server"></asp:Literal>
            </div>
            <div class="footerBot">
                <p>
                    Copyright &copy;2011 <a href="http://www.malverninternational.edu.my" target="_blank">Premier Soft</a>
                    &nbsp; <span style='display:none;'>Powered by: Premier Soft</a></p>
            </div>
        </div>
    </div>
    <!-- End Footer -->
    </form>
</body>
</html>
