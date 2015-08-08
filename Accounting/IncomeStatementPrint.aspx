<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IncomeStatementPrint.aspx.cs" Inherits="Accounting_" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Income Statement</title>
    <style type="text/css">
    td{text-align:right;border:1px solid black;}
    .Account_Head{text-align:left;}
    .SubBasicAccount{text-align:left;background-color:#777777; font-size:20px;}
    .SubTotal{text-align:left;background-color:#CCCCCC;font-weight:bold;}
    .breakBorder{background-color:Black;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblIncomeStatement" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
