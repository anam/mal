<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListOfAllEmployeeBonusPrint.aspx.cs" Inherits="HR_ListOfAllEmployeePrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List of Bounus of All Employee in CUC</title>
    <style type="text/css">
        td{padding:0 5px;font-size:12px;}
        th{padding:0 5px;font-size:12px;font-weight:bold;}
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3 align="center">List of Bounus of All Employee in CUC</h3>
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
                        <br />
                        <br />
        <span align="right" style="width:100%;text-align:right;"><b>Total Amount: </b><asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>/= tk</span>
    </div>
    </form>
</body>
</html>
