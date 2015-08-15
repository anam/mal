<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MoneyReceipt.aspx.cs" Inherits="MoneyReceipt" Title="Money Receipt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <div style="width: 960px; position: relative; margin: 0 auto;">
        <%--<asp:LinkButton ID="lnkPrint" Text="Print" runat="server" OnClientClick="javascript:printIt(document.getElementById('printme').innerHTML);"></asp:LinkButton>--%>
        <div style="width: 960px; position: relative; margin: 0 auto; overflow: hidden; border: 1px solid black;
            padding: 10px 0;" id="printme">
            <div class="logo" style="width: 1%; height: 2%; position: absolute; left: 92px; top: 15px;">
                <asp:Image ID="image" runat="server" ImageUrl="~/Accounting/LOGO/Logo_cuc.png" />
            </div>
            <h1 style="width: 100%; line-height: 24px; font-size: 50px; text-align: center; font-weight: bold;">
                Malvern International Academy</h1>
            <p style="text-align: justify; padding-left: 170px;">
                <b>Address:</b>House # 51,Road # 10/A(Near Sat Masjid Road), Dhanmondi,Dhaka-1209,
                Bangladesh<br />
                <b>Campas-2:</b>House # 352/B (Old) 21/B(New),Road # 27 (Old) 16 (New) Dhanmondi,Dhaka-1209<br />
                <b>Phone:</b> +88 028151564,8141601,<b>Mob:</b> +88 01720553272-73,74,75,76,77,78
                <b>Web:</b>www.cucedu.com</p>
            <h4 style="width: 100%; line-height: 24px; font-size: 20px; text-align: center;">
                Money Receipt</h4>
            <h2 style="width: 95%; margin: 0 auto; text-align: right; line-height: 16px; font-size: 12px;
                padding-bottom: 20px;">
                Private &amp; Confidential</h2>
            <div style="width: 960px; overflow: hidden;">
                <table style="width: 960px;">
                    <tr style="width: 960px;">
                        <td style="width: 960px;">
                            <table>
                                <tr>
                                    <td style="width: 710px; text-align: left; border: 1px solid black;">
                                        <label style="font-weight: bold; font-size: 12px;">
                                            No.</label>
                                        <asp:Label ID="lbltag" runat="server" Text="5470"></asp:Label>
                                    </td>
                                    <td style="width: 250px; text-align: left; border: 1px solid black;">
                                        <label style="font-weight: bold; font-size: 12px;">
                                            Date:</label>
                                        <asp:Label ID="lblDate" runat="server" Text="29 nov,2011"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="width: 960px;">
                        <td style="width: 960px;">
                            <table>
                                <tr>
                                    <td style="width: 710px; text-align: left; border: 1px solid black;">
                                        <label style="font-weight: bold; font-size: 12px;">
                                            Program:</label>
                                        <asp:Label ID="lblclass" runat="server" Text="CAT & ACCA Qualification"></asp:Label>
                                    </td>
                                    <td style="width: 250px; text-align: left; border: 1px solid black;">
                                        <label style="font-weight: bold; font-size: 12px;">
                                            ID No.</label>
                                        <asp:Label ID="lblID" runat="server" Text="115113021"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="width: 960px;">
                        <td style="width: 960px; border: 1px solid black;">
                            <table>
                                <tr>
                                    <td style="width: 960px; text-align: left;">
                                        <label style="font-weight: bold; font-size: 12px;">
                                            Name:</label>
                                        <asp:Label ID="lblName" runat="server" Text="Mostafa Kamal Noman"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="width: 960px;">
                        <td style="width: 960px; border: 1px solid black;">
                            <table>
                                <tr>
                                    <td style="width: 960px; text-align: left;">
                                        <label style="font-weight: bold; font-size: 12px;">
                                            Address:</label>
                                        <asp:Label ID="lblAddress" runat="server" Text="100, Donia, KobarstanRoad, Dhaka-1236.  Cell:01682177483"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="width: 960px;">
                        <td style="width: 960px;">
                            <table>
                                <tr>
                                    <td style="width: 710px; text-align: center; border: 1px solid black;">
                                        <label style="font-weight: bolder; font-size: 20px;">
                                            Particulars:</label>
                                    </td>
                                    <td style="width: 250px; text-align: center; border: 1px solid black;">
                                        <label style="font-weight: bolder; font-size: 20px;">
                                            Amount</label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="width: 960px;">
                        <td style="width: 960px;">
                            <table>
                                <tr>
                                    <td style="width: 710px; text-align: left; border: 1px solid black;">
                                        <asp:Label ID="lblfees" runat="server" Text="Admission & Tuition fees"></asp:Label>
                                        (<asp:Label ID="lblTotalPay" runat="server"></asp:Label>)
                                    </td>
                                    <td style="width: 250px; text-align: right; border: 1px solid black;">
                                        <asp:Label ID="lblAdmissionFees" runat="server" Text="190,000.00"></asp:Label><br />
                                       <%-- <asp:Label ID="lblamount2" runat="server" Text="(-)40,000.00"></asp:Label><br />--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="width: 960px;">
                        <td style="width: 960px;">
                            <table>
                                <tr>
                                    <td style="width: 710px; text-align: left; border: 1px solid black;">
                                        <asp:Label ID="Label1" runat="server" Text="Previously Received Money"></asp:Label>
                                        <asp:Label ID="lblPrev" runat="server"></asp:Label>
                                    </td>
                                    <td style="width: 250px; text-align: right; border: 1px solid black;">
                                        <asp:Label ID="lblPrevioulyReceiveMoney" runat="server" Text="190,000.00"></asp:Label><br />
                                       <%--<asp:Label ID="lblamount2" runat="server" Text="(-)40,000.00"></asp:Label><br />--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="width: 960px;">
                        <td style="width: 960px;">
                            <table>
                                <tr>
                                    <td style="width: 460px; text-align: left; border: 1px solid black;">
                                        <asp:Label ID="lblReceivedMoney" runat="server" Text="Received Money For Course Fee"></asp:Label>
                                        
                                    </td>
                                    <td style="width: 250px; border: 1px solid black; text-align: right;">
                                        <asp:Label ID="lblTotal" runat="server" Text="Total="></asp:Label><br />
                                         <asp:Label ID="lblPaid" runat="server" Text="Paid="></asp:Label><br /><hr />
                                          <asp:Label ID="lblDue" runat="server" Text="Due="></asp:Label><br />
                                    </td>
                                    <td style="width: 250px; text-align: center; border: 1px solid black; text-align: right;">
                                        <asp:Label ID="lblTotalAmount" runat="server" Text="150,000.00"></asp:Label><br />
                                        <asp:Label ID="lblPaidAmount" runat="server" Text=""></asp:Label><br /><hr />
                                          <asp:Label ID="lblDueAmount" runat="server" Text="Due="></asp:Label><br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="width: 960px;">
                        <td style="width: 960px; border: 1px solid black;">
                            <table>
                                <tr>
                                    <td style="width: 960px; text-align: left;">
                                        <label style="font-weight: bold; font-size: 12px;">
                                            Taka(In Word):</label>
                                        <asp:Label ID="lblTaka" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                     <tr style="width: 960px; "  ID="trPaymentStatus" runat="server">
                        <td style="width: 960px; border: 1px solid black;">
                            <label style="font-weight: bold; font-size: 20px;">
                                            Payment Status</label>
                        </td>
                    </tr>
                    <tr style="width: 960px; " ID="trInstallment" runat="server">
                        <td style="width: 960px; border: 1px solid black;">
                            <asp:Label ID="ltInstallment" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <%--<tr style="width: 960px;">
                        <td style="width: 960px; border: 1px solid black;">
                            <table>
                                <tr>
                                    <td style="width: 960px; text-align: left;">
                                        <label style="font-weight: bold; font-size: 12px;">
                                            Fifth Instaliment-:</label>
                                        <asp:Label ID="lblInstallment" runat="server" Text="-Date-"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>--%>
                    <tr style="width: 960px;">
                        <td style="width: 960px;">
                            <table style="padding-top: 130px;">
                                <tr>
                                    <td style="width: 320px; text-align: center;">
                                        <asp:Label ID="Label2" runat="server" Text="___________________"></asp:Label>
                                    </td>
                                    <td style="width: 320px; text-align: center;">
                                        <asp:Label ID="Label3" runat="server" Text="___________________"></asp:Label>
                                    </td>
                                    <td style="width: 320px; text-align: center;">
                                        <asp:Label ID="Label4" runat="server" Text="___________________"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 320px; text-align: center;">
                                        <asp:Label ID="lblStdSign" runat="server" Text="Student's Signeture"></asp:Label>
                                    </td>
                                    <td style="width: 320px; text-align: center;">
                                        <asp:Label ID="lblAuthorSign" runat="server" Text="Authorization Sign"></asp:Label>
                                    </td>
                                    <td style="width: 320px; text-align: center;">
                                        <asp:Label ID="lblReceiverSign" runat="server" Text="Receiver's Sign"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="width: 960px;">
                        <td style="width: 960px; padding-top: 50px;">
                            <table>
                                <tr>
                                    <td style="width: 960px; text-align: center;">
                                        <label style="font-weight: bolder; font-size: 12px;">
                                            N.B:</label>
                                        <asp:Label ID="lblNB" runat="server" Text="Any Fee May Change Without Notice And 
                                    Any Fee Paid By The Students Will Not Be Returnable."></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                
            </div>
        </div>
    </div>
    
    </form>
</body>
</html>
