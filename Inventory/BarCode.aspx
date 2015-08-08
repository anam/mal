<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true" CodeFile="BarCode.aspx.cs" Inherits="Inventory_BarCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <div class="content-box">
        <div class="header">
            <h3>
                 Bar Code</h3>
        </div>
        <div class="inner-form">
<table>
    <tr>
        <td>Code:</td>
        <td>
            <asp:TextBox ID="txtIDs" runat="server" Text="" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>OR<br />Range:</td>
        <td>
            Start<asp:TextBox ID="txtStart" runat="server" Text="" ></asp:TextBox>
            End<asp:TextBox ID="txtEnd" runat="server" Text="" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Button ID="btnBarCode" runat="server" Text="Generate BarCode" 
                onclick="btnBarCode_Click" />
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:LinkButton ID="lnkPrint" Text="Print" runat="server" OnClientClick="javascript:printIt(document.getElementById('printThis').innerHTML);"></asp:LinkButton>
                
            <br />
            <div id='printThis'>
                    <asp:Label ID="lblBarCode" runat="server"></asp:Label>
            </div>
        </td>
    </tr>
</table>
</div></div>
</asp:Content>

