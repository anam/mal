<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminINV_IssueMaster.aspx.cs" Inherits="AdminINV_IssueMaster" Title="INV_IssueMaster Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Issue_Master</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblIssueMasterName" runat="server" Text="Issue Master Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtIssueMasterName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblCampusID" runat="server" Text="Campus: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlCampusID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblStoreID" runat="server" Text="Store: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlStoreID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblProductionCode" runat="server" Text="Production Code: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtProductionCode" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
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
     <asp:Label ID="lblIssueDate" runat="server" Text="Date: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtIssueDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
 
 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 </dd>
 </dl></div></div>
 </asp:Content>

