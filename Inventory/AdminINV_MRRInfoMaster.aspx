<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminINV_MRRInfoMaster.aspx.cs" Inherits="AdminINV_MRRInfoMaster" Title="INV_MRRInfoMaster Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>MRRInfo_Master</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblMRRInfoMasterName" runat="server" Text="MRR Info Master Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtMRRInfoMasterName" class="txt large-input" runat="server" Text="">
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
     <asp:Label ID="lblMRRCode" runat="server" Text="MRR Code: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtMRRCode" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblMRRDate" runat="server" Text="MRR Date: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtMRRDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblStoreID" runat="server" Text="Store: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlStoreID" runat="server">
     </asp:DropDownList>
     </dd>
 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 </dd>
 </dl></div></div>
 </asp:Content>

