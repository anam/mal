<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendantSheetAttendedReportPerStudent.aspx.cs" Inherits="Student_AttendantSheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .gridCss
        {
            width: 98%;
            margin: 0px auto;
            background: #FFFFFF;
            padding: 5px;
            text-align: left;
            border: 1px solid #000;
            margin: 20px 0px 20px 0px;
        }
    </style>
    <script type="text/javascript">
        var win = null;
        function printIt(printThis) {
            win = window.open();
            self.focus();
            win.document.open();
            win.document.write('<' + 'html' + '><' + 'head' + '><' + 'style' + '>');
            win.document.write('body, td { font-family: Verdana; font-size: 10pt;}');
            win.document.write('<' + '/' + 'style' + '><' + '/' + 'head' + '><' + 'body' + '>');
            win.document.write(printThis);
            win.document.write('<' + '/' + 'body' + '><' + '/' + 'html' + '>');
            win.document.close();
            win.print();
            win.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 1000px; margin: 0px auto">
        <asp:LinkButton ID="lnkPrint" Text="Print" runat="server" OnClientClick="javascript:printIt(document.getElementById('printme').innerHTML);"></asp:LinkButton>
        <div id="printme" runat="server">
            <div style="width: 100%; float: left; margin-bottom: 30px">
                <div style="width: 25%; float: left; text-align: right; margin-top: 15px">
                    <asp:Image ID="imgLogo" ImageUrl="~/Accounting/LOGO/cuc_mainLogo.png" runat="server"
                        Width="40px" Height="50px" />
                </div>
                <div style="width: 50%; float: left; margin-left: 15px">
                    <h1 style="text-align: left">
                        Chartered University College</h1>
                </div>
            </div>
            
            
                <asp:Label ID="lblStudentAttendence" runat="server" Text=""></asp:Label>                
            
            <div style="width: 100%; float: left; margin-bottom: 30px;display:none;">
                <div style="width: 97.5%; float: left; border: solid 1px #000; height: 60px; margin-bottom: 15px;
                    padding-left: 10px">
                    Covered syllabus areas:
                </div>
                <div style="width: 98%; float: left; margin-top:50px">
                    <span style="float: left">Lecturer's Signature...........</span> <span style="float: right">
                        Admin Signature...........</span>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
