<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Home Page</title>
    <link href="~/App_Themes/CoffeyGreen/css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="~/App_Themes/CoffeyGreen/css/superfish.css"
        media="screen" />
    <script type="text/javascript" src="js/jquery-1.4.1.js"></script>
    <script type="text/javascript">
        //        $(document).ready(function () {
        //            $("").click(function () {
        //                $(this).next('div').slideToggle("slow");
        //            });
        //        });

        function showPanel() {
            //alert(elem.value);
            $("div#changePassword").slideToggle("slow");
        }

        function successMessage() {
            alert('Your Password is changed successfully.');
            $("div#changePassword").slideToggle("slow");
        }
        function errorMessage() {
            alert('Your Old Password does not match.');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="header" style="padding-bottom: 0px;">
        <!-- Begin: header -->
        <div id="headerWrapper" style="width: 800px;">
            <div class="headerTop">
                <!-- Begin: headerTop -->
                <h1 class="logo">
                    <a style="color: #fff;" href="Default.aspx"></a></h1>
                <div class="headerRight">
                    <asp:LoginView ID="loginView" runat="server">
                        <LoggedInTemplate>
                            <div class="myaccount">
                                <span class="accSymbol"></span>
                                <asp:LoginName ID="memberLoginName" runat="server" FormatString="  {0}" Font-Size="13px"
                                    Font-Bold="true" ForeColor="#8AB507" />
                            </div>
                            <div class="post">
                                <span style="float: right; padding-left: 10px; padding-right: 10px; padding-top: 10px;
                                    text-transform: uppercase;">&nbsp;
                                    <asp:LoginStatus ID="memberLoginStatus" runat="server" LogoutText="Log out" LogoutAction="Redirect"
                                        Font-Size="13px" Font-Bold="true" ForeColor="#FD5400" LogoutPageUrl="~/Default.aspx" />
                                </span>
                            </div>
                        </LoggedInTemplate>
                    </asp:LoginView>
                </div>
            </div>
        </div>
    </div>
    <div class="page">
        <div class="content-box" style="width: 800px; margin: 0 auto 40px auto; overflow: hidden;">
            <div class="header">
                <h3>
                    Home Page</h3>
            </div>
            <div class="inner-form" style="background-color: #DF5F5F; overflow: hidden;">
                <div class="mainNav" style="background-color: #DF5F5F;">
                    <asp:Literal ID="litModules" runat="server"></asp:Literal>
                </div>
                <a href="javascript:showPanel();"><span style="color: White;">Change Password</span></a>
            </div>
            <div id="changePassword" class="inner-form" style="display:none;">
                <asp:Panel ID="panChangePassword" runat="server" DefaultButton="">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblOldPassword" runat="server" Text="Old Password :" AssociatedControlID="txtOldPassword"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="requiredFieldValidator1" ControlToValidate="txtOldPassword"
                                    Display="Dynamic" runat="server" Text="*" ErrorMessage="OldPassword is required."
                                    ValidationGroup="required"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblNewPassword" runat="server" Text="New Password" AssociatedControlID="txtNewPassword"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="requiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword"
                                    Display="Dynamic" Text="*" ErrorMessage="New Password is required." ValidationGroup="required"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblConfirmPassword" runat="server" Text="Retype New Password :" AssociatedControlID="txtConfirmPassword"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="requiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword"
                                    Display="Dynamic" Text="*" ErrorMessage="Confirm Password is required." ValidationGroup="required"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtConfirmPassword"
                                    ControlToCompare="txtNewPassword" Display="Dynamic" Text="*" ErrorMessage="New Password and Confirm Password must be same."
                                    ValidationGroup="required"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ValidationSummary ID="summary1" runat="server" ValidationGroup="required" ShowMessageBox="true"
                                    ShowSummary="false" />
                            </td>
                            <td>
                                <br />
                                <asp:Button ID="btnChnagePassword" runat="server" CssClass="button button-blue" Text="Change Password"
                                    OnClick="btnChnagePassword_Click" ValidationGroup="required" CausesValidation="true" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </div>
    </div>
    <div id="footer">
        <div id="footer-inner">
            <%--<div class="footerTop">
                <asp:Literal ID="litFooterMenu" runat="server"></asp:Literal>
            </div>--%>
            <div class="footerBot">
                <p>
                    Copyright &copy;2011 <a href="http://www.malverninternational.edu.my" target="_blank">Premier Soft</a>
                    &nbsp; <span style='display:none;'>Powered by: Premier Soft</a></p>

                    <asp:HiddenField ID="hfUserName" runat="server" />
                        <asp:HiddenField ID="hfPassword" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
