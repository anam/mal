<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminINV_Sale.aspx.cs" Inherits="AdminINV_Sale" Title="INV_Sale Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Add/Update Sale</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblCampusID" runat="server" Text="Campus: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlCampusID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblInvoiceNo" runat="server" Text="Invoice No: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtInvoiceNo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblIteamID" runat="server" Text="Iteam: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlIteamID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblQuantity" runat="server" Text="Quantity: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtQuantity" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblWarrenty" runat="server" Text="Warrenty: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtWarrenty" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblUnitPrice" runat="server" Text="Unit Price: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtUnitPrice" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblSaleDate" runat="server" Text="Sale Date: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtSaleDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblRemark" runat="server" Text="Remark: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtRemark" TextMode="MultiLine" class="txt textarea" runat="server" Text="">
    </asp:TextBox>
     </dd>

 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 </dd>
 </dl></div></div>
 </asp:Content>

