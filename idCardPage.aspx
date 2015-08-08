<%@ Page Language="C#" AutoEventWireup="true" CodeFile="idCardPage.aspx.cs" Inherits="idCardPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IdCardPage</title>
    <link href="App_Themes/CoffeyGreen/css/style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="idCardPage">
        <asp:Repeater ID="rptIdcard" runat="server" OnItemDataBound="rptIdcard_OnItemDataBound">
            <ItemTemplate>
                <div class="idCardForm">
                    <div class="topPart">
                        <div class="imageBox">
                            <asp:Image runat="server" Height="100px" CssClass="imageEmployee" ImageUrl="" Width="95px"
                                ID="imgEmployee" />
                        </div>
                    </div>
                    <div class="bottomPart">
                        <asp:Label ID="lblPhoto" runat="server" Visible="false" Text='<%#Eval("Photo") %>'
                            CssClass="labelText"></asp:Label>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("EmployeeNo") %>' CssClass="labelText"></asp:Label>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("EmployeeName") %>' CssClass="labelText"></asp:Label>
                        <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("DesignationName") %>'
                            CssClass="labelText"></asp:Label>
                        <div style="margin-top: 5px;">
                            <div class="idContentRow">
                                <label class="lblDepartment">
                                    Department:</label>
                                <asp:Label ID="lblDepartmentName" runat="server" CssClass="deptName" Text='<%#Eval("DepartmentName") %>'></asp:Label>
                            </div>
                            <div class="idContentRow">
                                <label class="lblDepartment">
                                    Join Date:</label>
                                <asp:Label ID="Label1" runat="server" CssClass="deptName" Text='<%#Eval("JoiningDate","{0:dd MMM yyy}") %>'></asp:Label>
                            </div>
                            <div class="idContentRow">
                                <label class="lblDepartment">
                                    Contact No:</label>
                                <asp:Label ID="Label2" runat="server" CssClass="deptName" Text='<%#Eval("MobileNo") %>'></asp:Label>
                            </div>
                            <div class="idContentRow">
                                <label class="lblDepartment">
                                    Blood Group:</label>
                                <asp:Label ID="Label3" runat="server" CssClass="deptName" Text='<%#Eval("BloodGroupName") %>'></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
