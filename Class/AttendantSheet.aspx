<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendantSheet.aspx.cs" Inherits="Student_AttendantSheet" %>

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
        .RemarkTextBosx
        {background-color:White;border:1px solid white;width: 200px;}
        body{margin:0;padding:0 0 0 50px;}
        
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
    <div style="width: 800px; margin: 0px auto">
        <asp:LinkButton ID="lnkPrint" Text="Print" Visible="false" runat="server" OnClientClick="javascript:printIt(document.getElementById('printme').innerHTML);"></asp:LinkButton>
        <div id="printme" runat="server">
            <div style=" width: 800px; float: left; margin-bottom: 0px">
               
                <div style="width: 180px; float: left; text-align: right; margin-top: 15px">
                    <asp:Image ID="imgLogo" ImageUrl="~/Accounting/LOGO/cuc_mainLogo.png" runat="server"
                        Width="40px" Height="50px" />
                </div>
                <div style="width: 550px; float:left ; margin-left: 15px">
                    <h1 style="text-align: left">
                        Malvern International Academy</h1>
                </div>
            </div>
            <div style=" width: 800px; float: left; margin-bottom: 0px">
                 <table cellpadding="0" cellspacing="0">
                    <tr><td style="width:125px;">Course</td><td><b>:&nbsp;</b></td><td style="width:420px;">
                        <asp:Label ID="lblCourse" Text="ACCA" runat="server"></asp:Label>
                    </td><td style="width:80px;">Date</td><td><b>:&nbsp;</b></td><td>
                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                    </td></tr>
                    <tr><td>Paper</td><td><b>:&nbsp;</b></td><td>
                        <asp:Label ID="lblPaper" Text="F1 (Accountent in Business)" runat="server"></asp:Label>
                    </td><td>Time in</td><td><b>:&nbsp;</b></td><td>
                        <asp:Label ID="lblTimeIn" runat="server"></asp:Label>
                    </td></tr>
                    <tr><td>Lecturer</td><td><b>:&nbsp;</b></td><td>
                        <asp:Label ID="lblLecturer" runat="server"></asp:Label>
                    </td><td>Time out</td><td><b>:&nbsp;</b></td><td>
                        <asp:Label ID="lblTimeOut" runat="server"></asp:Label>
                    </td></tr>
                    <tr><td>Lecture / Exam No</td><td><b>:&nbsp;</b></td><td>
                        <asp:Label ID="lblExamNo" runat="server"></asp:Label>
                    </td><td>Batch No</td><td><b>:&nbsp;</b></td><td>
                        <asp:Label ID="lblBatchNo" runat="server"></asp:Label>
                    </td></tr>
                    
                </table>
               
            </div>
            <div style=" float: left; margin-bottom: 0px">
                <asp:GridView ID="gvAttentdant" runat="server" CssClass="gridCss" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="SI No" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblSNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student's Name" HeaderStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblStudentName" Text='<%#Eval("StudentName")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID No." HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="Label1" Visible='<%#Eval("ExtraField2")%>' Text='<%#Eval("StudentCode")%>' runat="server"></asp:Label>
                                <asp:Label ID="lblStudentCode" Visible='<%#Eval("ExtraField1")%>'  ForeColor="Red" Font-Font-Bold="true"  Text='<%#Eval("StudentCode")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Signature" HeaderStyle-Width="125px" >
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox1" CssClass="RemarkTextBosx" runat="server" Text='<%#Eval("Remark")%>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div style="width: 800px; float: left; margin-bottom: 0px">
                <div style="width: 97.5%; float: left; border: solid 1px #000; height: 60px; margin-bottom: 10px;
                    padding-left: 10px">
                    Covered syllabus areas:
                </div>
                <div style="width: 98%; float: left; margin-top:20px">
                    <span style="float: left">Lecturer's Signature...........</span> <span style="float: right">
                        Admin Signature...........</span>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
