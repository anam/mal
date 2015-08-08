<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListOfAllEmployeePrint.aspx.cs" Inherits="HR_ListOfAllEmployeePrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        td{padding:0 5px;font-size:10px;}
        
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3 align="center">List of All Employee in CUC</h3>
    <asp:GridView align="center" ID="gvListOfAllEmployee" runat="server" AutoGenerateColumns="true"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="SI No" HeaderStyle-Width="3%">
                            <ItemTemplate>
                                <asp:Label ID="lblSNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView>
    </div>
    </form>
</body>
</html>
