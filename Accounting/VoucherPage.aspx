<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VoucherPage.aspx.cs" Inherits="Accounting_VoucherPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Voucher</title>
    <style type="text/css">
        .gridCss
        {
            width: 98%;
            margin: 0px auto;
            padding: 5px;
            text-align: left;
            border: 1px solid #000;
            margin: 20px 0px 20px 0px;
        }
        .bodyCss
        {
            text-align: center;
            font-family: Arial, sans-serif;
            font-size: 12px;
            background-color: #CF9 ;
        }
        .hCss
        {
            width:788px;
	        height:24px;
	        background:#F99;
	        border:1px solid #000;
	        text-align:center;
	        padding-left:10px;
        }
        .rCss
        {
            font-size:11px;
	        line-height:24px;
	        color:#1f1f1f;
	        font-family:Tahoma, Geneva, sans-serif;
	        text-transform:uppercase;
	        border:1px solid #000;	
	        padding-left:10px;      
        }
        .ICss
        {
              text-align:right;
              font-size:11px;
        }
        .fCss
        {
            text-align:right;
        }
        .hLCss
        {
            text-align:left;
            padding-left:10px;
        }
        .rLCss
        {
            text-align:left;
            padding-left:10px;
        }
    </style>
    <link href="../App_Themes/CoffeyGreen/css/Voucher.css" rel="Stylesheet" type="text/css" />
</head>
<body class="bodyCss">
    <form id="form1" runat="server">
    <div style="border:1px solid Black;">
    <div id="header" style="background-color:#660066">
        <!-- Begin: header -->
        <div style="width: 25%; float: left; text-align: right; margin-top: 15px">
            <asp:Image ID="imgLogo" ImageUrl="~/Accounting/LOGO/cuc_mainLogo.png" runat="server"/>
        </div>
        <div style="width: 50%; float: left; margin-left: 15px; padding-top:30px">
            <h1 style="text-align: left; color:#fff;">
                Malvern International Academy</h1>
        </div>
    </div>
    <!-- End: header -->
    <div id="mainpage">
        <!-- Begin: mainpage -->
        <div class="mainpage_top">
            <!-- Begin: mainpage_top -->
            <div class="mainpageTop_left">
                <!-- Begin: mainpageTop_left -->
                <h2>
                     <asp:Label ID="lblVoucher" runat="server"></asp:Label> Voucher</h2>
                <h3>
                    <asp:Label ID="lblVoucherName" runat="server"></asp:Label> <asp:Label ID="lblPurpose" runat="server"></asp:Label>A/C</h3>
                <h3>
                    Paid to 
                    <asp:Label ID="lblPayTo" runat="server" Text="Label"></asp:Label></h3>
            </div>
            <!-- End: mainpageTop_left -->
            <div class="mainpageTop_right">
                <!-- Begin: mainpageTop_right -->
                <h5>
                    Voucher No :&nbsp;<asp:Label ID="lblVoucherNo" runat="server"></asp:Label></h5>
                <h5>
                    Date : <asp:Label ID="lblDate" runat="server"></asp:Label></h5>
                <h5 style="display:none;">
                    Code no : ..............</h5>
            </div>
            <!-- End: mainpageTop_right -->
        </div>
        <!-- End: mainpage_top -->
        <div class="mainpage_mid">
            <!-- Begin: mainpage_mid -->
            <div class="rowB_table">
                <!-- Begin : rowB_table -->
                <asp:GridView ID="gvACC_Journal" class="gridCss" runat="server" AutoGenerateColumns="false"
                    CssClass="tableCss" ShowFooter="true" OnRowDataBound="gvACC_Journal_OnRowDataBound">
                    <HeaderStyle CssClass="hCss" />
                    <RowStyle CssClass="rCss" />                  
                    <Columns>
                        <asp:TemplateField HeaderText="Purposes" HeaderStyle-Width="35%" FooterStyle-CssClass="fCss"  HeaderStyle-CssClass="hLCss">
                            <ItemTemplate>
                                <p style="padding-left:10px">
                                    <asp:Label ID="lblHeadID" runat="server" Text='<%#Eval("HeadName") %>'></asp:Label>
                                </p>
                            </ItemTemplate>
                            <FooterTemplate>
                              <span style="font-size:18px">Total&nbsp;</span>                                 
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Taka" HeaderStyle-Width="5%" ItemStyle-CssClass="ICss" FooterStyle-CssClass="ICss">
                            <ItemTemplate>
                                <asp:Label ID="lblDebit" runat="server" Text='<%#Eval("Debit") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>                               
                                <asp:Label ID="lblTotalDebit" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Ps" HeaderStyle-Width="1%" ItemStyle-CssClass="ICss" FooterStyle-CssClass="ICss">
                            <ItemTemplate>
                                <asp:Label ID="lblPs" runat="server"></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>                               
                                <asp:Label ID="lblTotalPs" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div class="table_footer">
                    <h6>
                        Tk. In Word :&nbsp; <asp:Label ID="lblTake" runat="server" Font-Size="15px"></asp:Label></h6>
                </div>
            </div>
            <!-- End : rowB_table -->
        </div>
        <!-- End: mainpage_mid -->
        <div class="mainpage_bottom">
            <!-- Begin: mainpage_bottom -->
        </div>
        <!-- End: mainpage_bottom -->
    </div>
    <!-- End: mainpage -->
    <div id="footer_Inner">
        <!-- Begin: footer_Inner -->
        <h4>
            Received by</h4>
        <h4>
            Prepared by</h4>
        <h5>
            Authorized by</h5>
    </div>
    <!-- End: footer_Inner -->
    </div>
    </form>
</body>
</html>
