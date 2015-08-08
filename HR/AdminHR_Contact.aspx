<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminHR_Contact.aspx.cs" Inherits="AdminHR_Contact" Title="HR_Contact Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateHR_Contact</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
 
    <dt>
     <asp:Label ID="lblCurrentAddress" runat="server" Text="Current Address: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtCurrentAddress" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblPermanentAddress" runat="server" Text="Permanent Address: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtPermanentAddress" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblTelephone" runat="server" Text="Telephone: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtTelephone" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblMobile" runat="server" Text="Mobile: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtMobile" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblEmail" runat="server" Text="Email: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtEmail" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 </dd>
 </dl></div>
 </div>
 </asp:Content>

