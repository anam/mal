<%@ Page Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true" 
CodeFile="AdminItemBarcodeInsertUpdate.aspx.cs" Inherits="AdminItemBarcodeInsertUpdate" Title="ItemBarcode Insert/Update By Admin" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                List of all printed</h3>
        </div>
        <div class="inner-content">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblSubCategoryID" runat="server" Text="SubCategoryID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSubCategory" runat="server" Text="SubCategoryID: ">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblNoOfItem" runat="server" Text="NoOfItem: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNoOfItem" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblBarcodeText" runat="server" Text="BarcodeText: ">
                    </asp:Label>
                <asp:ImageButton ID="ImageButton1" runat="server"  OnClientClick="javascript:printIt(document.getElementById('printThis').innerHTML);" ImageUrl="../App_Themes/CoffeyGreen/images/print.jpg"/>
	
                 <%--<asp:LinkButton ID="lnkPrint" Text="Print" runat="server" OnClientClick="javascript:printIt(document.getElementById('printThis').innerHTML);"></asp:LinkButton>--%>
             
                    <div id='printThis'>
                    <asp:Label ID="txtBarcodeText" runat="server" Text="Label"></asp:Label> 
                    </div>
                </td>
            </tr>
            <%--<tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                        OnClick="btnUpdate_Click" />
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                </td>
            </tr>--%>
        </table>
    </div>
    </div>
</asp:Content>
