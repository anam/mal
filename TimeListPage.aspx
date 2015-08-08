<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TimeListPage.aspx.cs" Inherits="TimeListPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
        <img alt="" src="" /><img alt="" src="App_Themes/CoffeyGreen/images/Confusion.png" title=''/>
        <asp:Image ID="Image1" runat="server" ToolTip=""/>
    </div>
    </form>
</body>
</html>
