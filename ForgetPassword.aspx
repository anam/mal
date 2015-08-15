<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="ForgetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Retrive Password</title>
    <link href="~/App_Themes/CoffeyGreen/css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="~/App_Themes/CoffeyGreen/css/superfish.css"
        media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="header" style="padding-bottom: 0px;">
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
        <div class="content-box" style="width: 600px; margin: 0 auto 40px auto; overflow: hidden;">
            <div class="header">
                <h3>
                    Login</h3>
            </div>
            <div class="inner-form">
                <asp:Panel ID="panForgetPassword" runat="server">
                    ID
                    <p>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="txt" />
                    </p>
                    <%--Answer--%>
                    <p style="display:none;">
                        <asp:TextBox ID="txtAnswer" runat="server" Text="a" CssClass="txt" Width="70%" />
                    </p>
                    <p>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button button-blue" OnClick="btnSubmit_OnClick" />
                    </p>
                </asp:Panel>
                <asp:Panel ID="panPassword" runat="server" Visible="false">
                    <br />
                    <br />
                    <%--Your Password is : --%><b>
                        <asp:Label ID="lblPassword" runat="server" />
                    </b>
                    <br />
                    <asp:LinkButton ID="lbtnContinue" runat="server" Text="Continue" PostBackUrl="~/LoginPage.aspx"></asp:LinkButton>
                </asp:Panel>
                <asp:Panel ID="panError" runat="server" Visible="false">
                    <br />
                    <br />
                    <br />
                    <p>
                        Your User name or Answer is not correct.</p>
                    <p>
                        <asp:Label ID="lblError" runat="server" /></p>
                </asp:Panel>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
