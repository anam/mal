<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataUpload.aspx.cs" Inherits="DataUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="uplFile" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />

       <asp:Button ID="btnAddStudent" runat="server" Text="Add Student" OnClick="btnAddStudent_Click" />
       <asp:Label ID="lblError" runat="server"></asp:Label>
       <asp:Button ID="btnPayment" runat="server" Text="Add TotalPayment" OnClick="btnPayment_OnClick" />

       <asp:Button ID="btnRejectedDate" runat="server" Text="Add RejectedDate" OnClick="btnRejectedDate_OnClick" />
    </div>
    </form>
</body>
</html>
