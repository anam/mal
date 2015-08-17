<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teacher.aspx.cs" Inherits="Teacher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 960px; position: relative; margin: 0 auto; overflow: hidden; border: 1px solid black;
        padding: 10px 0;">
        <div class="logo" style="width: 1%; height: 2%; position: absolute; left: 92px; top: 15px;">
            <asp:Image ID="image" runat="server" ImageUrl="~/LOGO/Logo_cuc.png" />
        </div>
        <h1 style="width: 100%; line-height: 24px; font-size: 50px; text-align: center; font-weight: bold;">
            Malvern International Academy</h1>
        <p style="text-align: justify; padding-left: 170px;">
            <b>Address:</b>50000 Kuala Lumpur, Malaysia
            Bangladesh<br />
            
            <b>Phone:</b> (603) – 2032 3001
            <b>Web:</b>www.malverninternational.edu.my</p>
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
                                    <asp:Label ID="lbltag" runat="server" Text="6301"></asp:Label>
                                </td>
                                <td style="width: 250px; text-align: left; border: 1px solid black;">
                                    <label style="font-weight: bold; font-size: 12px;">
                                        Date:</label>
                                    <asp:Label ID="lblDate" runat="server" Text="29 Nov,2011"></asp:Label>
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
                                        Department:</label>
                                    <asp:Label ID="lblclass" runat="server" Text="Biology"></asp:Label>
                                </td>
                                <td style="width: 250px; text-align: left; border: 1px solid black;">
                                    <label style="font-weight: bold; font-size: 12px;">
                                        ID No.</label>
                                    <asp:Label ID="lblID" runat="server" Text="01245679"></asp:Label>
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
                                    <asp:Label ID="lblName" runat="server" Text="Prof. Md.Abu Hena"></asp:Label>
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
                                    <asp:Label ID="lblAddress" runat="server" Text="23/C,Sector-04,Uttara, Dhaka-1236.  Cell:01682177483"></asp:Label>
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
                                    <label style="font-weight: bolder; font-size: 12px;">
                                        Particulars:</label>
                                </td>
                                <td style="width: 250px; text-align: center; border: 1px solid black;">
                                    <label style="font-weight: bolder; font-size: 12px;">
                                        Amount</label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <%--<tr style="width: 960px;">
                    <td style="width: 960px;">
                        <table>
                            <tr>
                                <td style="width: 710px; text-align: left; border: 1px solid black;">
                                    <asp:Label ID="lblfees" runat="server" Text="Admission & Tuition fees Previously Received Money"></asp:Label>
                                </td>
                                <td style="width: 250px; text-align: center; border: 1px solid black;">
                                    <asp:Label ID="lblamount1" runat="server" Text="190,000.00"></asp:Label><br />
                                    <asp:Label ID="lblamount2" runat="server" Text="(-)40,000.00"></asp:Label><br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>--%>
                <tr style="width: 960px;">
                    <td style="width: 960px;">
                        <table>
                            <tr>
                                <td style="width: 460px; text-align: left; border: 1px solid black;">
                                    <asp:Label ID="lblReceivedMoney" runat="server" Text="Salary"></asp:Label>
                                </td>
                                <td style="width: 250px; border: 1px solid black; text-align: right;">
                                    <asp:Label ID="lblTotal" runat="server" Text="Total="></asp:Label><br />
                                    <asp:Label ID="lblPaid" runat="server" Text="Paid="></asp:Label><br />
                                    <asp:Label ID="lblDue" runat="server" Text="Due="></asp:Label><br />
                                </td>
                                <td style="width: 250px; text-align: center; border: 1px solid black;">
                                    <asp:Label ID="lblTotalAmount" runat="server" Text="150,000.00"></asp:Label><br />
                                    <asp:Label ID="lblPaidAmount" runat="server" Text="25,000.00"></asp:Label><br />
                                    <asp:Label ID="lblDueAmount" runat="server" Text="125,000.00"></asp:Label><br />
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
                                    <asp:Label ID="lblTaka" runat="server" Text="Twenty Five Thousand Only"></asp:Label>
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
                                        Fifth Instaliment-:</label>
                                    <asp:Label ID="lblInstallment" runat="server" Text="-Date-"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="width: 960px;">
                    <td style="width: 960px;">
                        <table style="padding-top: 70px;">
                            <tr>
                                <td style="width: 320px; text-align: center;">
                                    <asp:Label ID="lblStdSign" runat="server" Text="Teacher's Signeture"></asp:Label>
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
                    <td style="width: 960px; padding-top: 25px;">
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
    </form>
</body>
</html>
