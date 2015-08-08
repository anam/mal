<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminHR_PackageRules.aspx.cs" Inherits="AdminHR_PackageRules" Title="HR_PackageRules Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateHR_PackageRules</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblPackageRulesName" runat="server" Text="Package Rules Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtPackageRulesName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblRulesValue" runat="server" Text="Rules Value: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtRulesValue" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblRulesOperator" runat="server" Text="Rules Operator: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtRulesOperator" class="txt large-input" runat="server" Text="">
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

