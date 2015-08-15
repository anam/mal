<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CBEExamTransactionSummary.aspx.cs" Inherits="Fees_CBEExamTransactionSummary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .head{width:300px;border:1px solid black;}
        .date{width:95px;border:1px solid black;}
        .amount{width:75px;border:1px solid black;text-align:right}
        .header{border:1px solid black;text-align:center;background-color:#F2F2F2}
 </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    <div style="width: 960px; position: relative; margin: 0 auto;">
        <%--<asp:LinkButton ID="lnkPrint" Text="Print" runat="server" OnClientClick="javascript:printIt(document.getElementById('printme').innerHTML);"></asp:LinkButton>--%>
        <div style="width: 960px; margin: 0 auto; overflow: hidden; border: 1px solid black;
            padding: 10px 0;" id="printme">
    <div class="logo" style="width: 30%; text-align:right; height: 2%; float:left; left: 10px; top: 15px;">
                <asp:Image ID="image" runat="server" ImageUrl="~/Accounting/LOGO/cuc_mainLogo.png"  Height="20px" />
            </div>
            <div style="width:70%; float:left; ">
                <h1 style="width: 90%; line-height: 0px; font-size: 15px; text-align: left; padding-left:20px; font-weight: bold;">
                Malvern International Academy<span style="padding-left:50px;font-size:10px">Private &amp; Confidential</span></h1>
            </div>
            <br />
            <p style="text-align: justify;font-size: 10px; padding-left: 270px; ">
                <b>Address:</b>House # 51,Road # 10/A(Near Sat Masjid Road), Dhanmondi,Dhaka-1209,
                Bangladesh<br />
                <b>Campas-2:</b>House # 352/B (Old) 21/B(New),Road # 27 (Old) 16 (New) Dhanmondi,Dhaka-1209<br />
                <b>Phone:</b> +88 028151564,8141601,<b>Mob:</b> +88 01720553272-73,74,75,76,77,78
                <b>Web:</b>www.cucedu.com</p>
            <h4 style="width: 100%; line-height: 24px; font-size: 20px; text-align: center;margin:0px;">
              Transaction Report of CBE Exam Fees Date:<asp:Label ID="lblDate" runat="server" Text=""></asp:Label></h4><br />
        <asp:Label ID="lblHtml" runat="server" Text=""></asp:Label>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
