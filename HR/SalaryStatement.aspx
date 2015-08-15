<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalaryStatement.aspx.cs"
    Inherits="HR_SalaryStatement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Salary Statement</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 1000px; margin: 0 auto; overflow: hidden; border: 2px solid #000;">
        <div style="width: 100%; overflow: hidden; margin-bottom: 8px;">
            <div style="width: 70%; margin: 0px auto; height: 85px;">
                <p style="text-align: center; font-size: 20px">
                    Malvern International Academy
                    <br />
                    Salary Statement<br />
                    <span style="text-decoration:underline">For
                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                    </span>
                </p>
            </div>
        </div>
        <div style="width: 100%; overflow: hidden;">
            <%--<asp:Literal ID="ltExamSheet" runat="server"></asp:Literal>--%>
            <asp:Label ID="ltExamSheet" runat="server" Text="Label"></asp:Label>
        </div>
         <div style="width: 100%; overflow: hidden;">
            <span style="float:left; padding:20px">
            -----------<br />
            Prepared By
            </span>
            <span style="float:right; padding:20px">
                 -----------<br />
                 Approved By
            </span>
         </div>
    </div>
    </form>
</body>
</html>
