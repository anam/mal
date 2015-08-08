<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowJournal.aspx.cs" Inherits="Accounting_ShowJournal" %>

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
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 1000px; margin: 0px auto">
        <asp:GridView ID="gvACC_Journal" class="gridCss" runat="server" AutoGenerateColumns="false"
            CssClass="gridCss" ShowFooter="true" OnRowDataBound="gvACC_Journal_OnRowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Header Name" HeaderStyle-Width="35%">
                    <ItemTemplate>
                        <asp:Label ID="lblHeadID" runat="server" Text='<%#Eval("HeadName") %>'></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Debit" HeaderStyle-Width="15%">
                    <ItemTemplate>
                        <asp:Label ID="lblDebit" runat="server" Text='<%#Eval("Debit") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        Total Debit =
                        <asp:Label ID="lblTotalDebit" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Credit" HeaderStyle-Width="15%">
                    <ItemTemplate>
                        
                        <asp:Label ID="lblCredit" runat="server" Text='<%#Eval("Credit") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        Total Credit = 
                        <asp:Label ID="lblTotalCredit" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
