<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MoneyReceipt.aspx.cs" Inherits="Student_MoneyReceipt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Money Receipt</title>
    <link rel="stylesheet" type="text/css" href="~/App_Themes/CoffeyGreen/css/grid.css" />
    <link rel="Stylesheet" type="text/css" href="App_Themes/CoffeyGreen/css/grid.css" />
</head>
<body>
    <form id="form1" runat="server">
    <table>
    <tr><td>

    <div style="width: 960px; position: relative; margin: 0 auto;">
        <div style="width: 100%; overflow: hidden; margin-bottom: 8px;padding-top:2px;">
            <div style="width: 60%; float: left;">
                <div class="logo" style="width: 20%; height: 2%; float: left;">
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Image ID="image" runat="server" ImageUrl="~/Accounting/LOGO/Logo_cuc.png" 
                        Height="38px" style="text-align: right" Width="18px" />
                </div>
                <p style="text-align: justify; float: left; width: 70%;  line-height: 25px">
                    <span style="font-size: 22px; font-weight: bold">Chartered University College</span><br />
                    <br />
                    <b></b>House# 51, Road# 10/A(Near Sat Masjid Road),
                    <br />
                    Dhanmondi R/A, Dhaka-1209, Bangladesh<br />
                </p>
            </div>
            <div style="float: left; width: 25%; height: 120px; margin-right: 10px; ">
                <table width="100%">
                    <tr>
                        <td colspan="2" style="padding-bottom:30px;">
                           <span style="border:1px solid black;padding:5px;font-weight:bold;">Student Copy</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phone:
                        </td>
                        <td>
                            <asp:Label ID="lblPhone" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email :
                        </td>
                        <td>
                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <table width="100%" style="margin-bottom:30px">
                <tr>
                    <td style="width:50px">
                        Date :
                    </td>
                    <td>
                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                    </td>
                    <td style="width:50px">
                        Bill To :
                    </td>
                    <td>
                        <asp:Label ID="lblBillTo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:100px">
                        ACCA Reg :
                    </td>
                    <td>
                        <asp:Label ID="lblRegNo" runat="server"></asp:Label>
                    </td>
                    <td style="width:120px">
                        Contact Number :
                    </td>
                    <td>
                        <asp:Label ID="lblContactNo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:50px">
                        Student ID
                    </td>
                    <td>
                        <asp:Label ID="lblStudentID" runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
            </table>
            <div style="width: 100%; float: left">
                <asp:GridView ID="gvCBEExamSubject" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="tabel_input"
                    OnRowDataBound="gvCBEExamSubject_OnRowDataBound">
                    <HeaderStyle CssClass="heading" />
                    <RowStyle CssClass="row" />
                    <AlternatingRowStyle CssClass="altrow" />
                    <Columns>
                        <asp:TemplateField HeaderText="Exam Date">
                            <ItemTemplate>
                                <asp:Label ID="lblAddedDate" runat="server" Text='<%#Eval("ExamDate","{0:dd MMM,yyyy}") %>'>
                                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Course Title">
                            <ItemTemplate>
                                <asp:Label ID="lblSubjectTitle" runat="server" Text='<%#Eval("SubjectTitle") %>'>
                                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Subject Name">
                            <ItemTemplate>
                                <asp:Label ID="lblSubjectCode" runat="server" Text='<%#Eval("SubjectCode") %>'>
                                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoice" runat="server">
                                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label ID="lblTaxOrPaperVariant" runat="server" Text='<%#Eval("FeesDescription") %>'>
                                            </asp:Label>
                            </ItemTemplate>
<FooterTemplate>
                                <span style="font-size:15px; font-weight:bold">
                                <asp:Label ID="lblTotal" Text=" Total" runat="server"></asp:Label>
                                </span>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount IN £"  Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblAmountIN" runat="server">
                        </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Conversation Rate"  Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblConversationRate" runat="server">
                        </asp:Label>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TOTAL">
                            <ItemTemplate>
                                <asp:Label ID="lblFees" runat="server" Text='<%#Eval("Fees","{0:0.00}") %>'>
                                            </asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblSumTotal" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div style="width:100%; float:left">
                <h2>
                    Terms & Conditions : 
                </h2>
                <ul style="list-style:none; float:left; margin:0px">
                    <li>1. All paid amount is completely non refundable. </li>
                    <li>2. All responsibilities regarding conduct exam are reserved by British Council, Bangladesh. Chartered University College Administration would not be responsible for Changing exam dates, time even venue.</li>
                    <li>3. British Council may change exam date even 1 day prior to the exam. So candidates must get prepared well.</li>
                    <li>4. Candidates must bring their ACCA registration card, calculator & other belongings.</li>
                </ul>
                <p>
                    &nbsp;<br /><br /></p>
                   
                <p>
        ____________________&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        _______________________
                    <br />Student &#39;s Signature&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Offical Seal &amp; Signature</p>
            </div>
        </div>
    </div>

    </td></tr>
    <tr><td  style="border-top:1px solid white;">
    
    <div style="width: 960px; position: relative; margin: 0 auto;margin-top: 70px;">
        <div style="width: 100%; overflow: hidden; margin-bottom: 8px; padding-top:3px;height: 181px;">
            <div style="width: 60%; float: left;">
               <div class="logo" style="width: 20%; height: 2%; float: left;">
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Image ID="image1" runat="server" ImageUrl="~/Accounting/LOGO/Logo_cuc.png" 
                        Height="38px" style="text-align: right" Width="18px" />
                </div>
                <p style="text-align: justify; float: left; width: 70%; line-height: 25px">
                    <span style="font-size: 22px; font-weight: bold">Chartered University College</span><br />
                    <br />
                    <b></b>House# 51, Road# 10/A(Near Sat Masjid Road),
                    <br />
                    Dhanmondi R/A, Dhaka-1209, Bangladesh<br />
                </p>
            </div>
            <div style="float: left; width: 25%; height: 120px; margin-right: 10px; ">
                <table width="100%">
                    <tr>
                        <td colspan="2" style="padding-bottom:30px;">
                           <span style="border:1px solid black;padding:5px;font-weight:bold;">Office Copy</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phone:
                        </td>
                        <td>
                            <asp:Label ID="lblPhone1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email :
                        </td>
                        <td>
                            <asp:Label ID="lblEmail1" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="width: 960px; overflow: hidden;">
            <table width="100%" style="margin-bottom:30px">
                <tr>
                    <td style="width:50px">
                        Date :
                    </td>
                    <td>
                        <asp:Label ID="lblDate1" runat="server"></asp:Label>
                    </td>
                    <td style="width:50px">
                        Bill To :
                    </td>
                    <td>
                        <asp:Label ID="lblBillTo1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:100px">
                        ACCA Reg :
                    </td>
                    <td>
                        <asp:Label ID="lblACCAReg" runat="server"></asp:Label>
                    </td>
                    <td style="width:120px">
                        Contact Number :
                    </td>
                    <td>
                        <asp:Label ID="lblContactNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:50px">
                        Student ID
                    </td>
                    <td>
                        <asp:Label ID="lblStudentID1" runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
            </table>
            <div style="width: 100%; float: left">
                <asp:GridView ID="gvCBEExamSubject1" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="tabel_input"
                    OnRowDataBound="gvCBEExamSubject_OnRowDataBound">
                    <HeaderStyle CssClass="heading" />
                    <RowStyle CssClass="row" />
                    <AlternatingRowStyle CssClass="altrow" />
                    <Columns>
                       <asp:TemplateField HeaderText="Exam Date">
                            <ItemTemplate>
                                <asp:Label ID="lblAddedDate" runat="server" Text='<%#Eval("ExamDate","{0:dd MMM,yyyy}") %>'>
                                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Course Title">
                            <ItemTemplate>
                                <asp:Label ID="lblSubjectTitle" runat="server" Text='<%#Eval("SubjectTitle") %>'>
                                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoice" runat="server">
                                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label ID="lblTaxOrPaperVariant" runat="server" Text='<%#Eval("FeesDescription") %>'>
                                            </asp:Label>
                            </ItemTemplate>
<FooterTemplate>
                                <span style="font-size:15px; font-weight:bold">
                                <asp:Label ID="lblTotal" Text=" Total" runat="server"></asp:Label>
                                </span>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount IN £"  Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblAmountIN" runat="server">
                        </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Conversation Rate"  Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblConversationRate" runat="server">
                        </asp:Label>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TOTAL">
                            <ItemTemplate>
                                <asp:Label ID="lblFees" runat="server" Text='<%#Eval("Fees","{0:0.00}") %>'>
                                            </asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblSumTotal" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div style="width:100%; float:left">
                <h2>Terms & Conditions : </h2>
                <ul style="list-style:none; float:left; margin:0px">
                    <li>1. All paid amount is completely non refundable. </li>
                    <li>2. All responsibilities regarding conduct exam are reserved by British Council, Bangladesh. Chartered University College Administration would not be responsible for Changing exam dates, time even venue.</li>
                    <li>3. British Council may change exam date even 1 day prior to the exam. So candidates must get prepared well.</li>
                    <li>4. Candidates must bring their ACCA registration card, calculator & other belongings.</li>
                </ul>
               <p>
                    &nbsp;<br /><br /></p>
                <p>
        ____________________&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        _______________________
        <br />
        Student &#39;s Signature&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Offical Seal &amp; Signature</p>
            </div>
        </div>
    </div>
    
    </td></tr>
    </table>
    
    
    
    </form>
    
    </body>
</html>
