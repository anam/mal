<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminINV_Iteam.aspx.cs" Inherits="AdminINV_Iteam" Title="Inventory Item" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="content-box">
        <div class="header">
            <h3>
                 Inventory Item</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblCampusID" runat="server" Text="Store: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlCampusID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt style="display:none;">
                    <asp:Label ID="lblIteamCode" runat="server" Text="Item Code: ">
    </asp:Label>
                </dt>
                <dd style="display:none;">
                    <asp:TextBox ID="txtIteamCode" class="txt large-input" runat="server" Text="In Store">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblDescription" runat="server" Text="Description: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" class="txt textarea" runat="server"
                        Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblIteamCategoryID" runat="server" Text="Item Category: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlIteamCategoryID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIteamCategoryID_SelectedIndexChanged">
                    </asp:DropDownList>New Category:<asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="Label1" runat="server" Text="Sub Category: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlIteamSubCategoryID" runat="server">
                    </asp:DropDownList>New Sub Category:<asp:TextBox ID="txtSubCategory" runat="server"></asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="Label2" runat="server" Text="Quantiry: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtNoOfItems" class="txt large-input" runat="server" Text="1">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblPrice" runat="server" Text="Purchase Price: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtPrice" class="txt large-input" runat="server" Text="1">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblQuantity" runat="server" Text="Sale price: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtQuantity" class="txt large-input" runat="server" Text="1">
    </asp:TextBox>
                </dd>
                <dt style="display:none;">
                    <asp:Label ID="lblUnit" runat="server" Text="Unit: ">
    </asp:Label>
                </dt>
                <dd style="display:none;">
                    <asp:TextBox ID="txtUnit" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
                </dd>
            </dl>
            <br />
            <asp:LinkButton ID="lnkPrint" Text="Print" runat="server" OnClientClick="javascript:printIt(document.getElementById('printThis').innerHTML);"></asp:LinkButton>
                
            <br />
            <div id='printThis'>
                    <asp:Label ID="lblBarCode" runat="server"></asp:Label>
                </div>

        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
