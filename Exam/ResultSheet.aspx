<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResultSheet.aspx.cs" Inherits="Exam_ResultSheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 1000px; margin: 0 auto; overflow: hidden; border: 2px solid #000;">
        <div style="width: 100%; overflow: hidden; margin-bottom: 8px;">
            <div style="width: 70%; float: left;">
                <table style="width:100%">
                    <tr>
                        <td  style="border:solid 1px #ccc">
                            <label>
                                CAT</label>
                        </td>
                        <td style="border:solid 1px #ccc; text-align:center">
                            <label>Student Progress Report (<asp:Label ID="lblExamName" runat="server"></asp:Label>)</label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border:solid 1px #ccc">
                            <label>
                                Course:</label>
                        </td>
                        <td style="border:solid 1px #ccc">
                            <asp:Label ID="lblCourse" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border:solid 1px #ccc">
                            <label>
                                Class:</label>
                        </td>
                        <td style="border:solid 1px #ccc">
                            <asp:Label ID="lblClass" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border:solid 1px #ccc">
                            <label>
                                Month:</label>
                        </td>
                        <td style="border:solid 1px #ccc">
                            <asp:Label ID="lblMonth" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border:solid 1px #ccc">
                            <label>
                                Teacher:</label>
                        </td>

                        <td style="border:solid 1px #ccc">
                            <asp:Label ID="lblTeacher" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                </table>
            </div>
            <div style="float: right; width: 15%; height: 120px; margin-right: 10px;">
                <asp:Image ID="imgLogo" runat="server" Height="120px" ImageUrl="~/Accounting/LOGO/Logo_cuc.png" />
            </div>
        </div>
        <div style="width: 100%; overflow: hidden;">
            <asp:Literal id="ltExamSheet" runat="server"></asp:Literal>
        </div>
    </div>
    </form>
</body>
</html>
