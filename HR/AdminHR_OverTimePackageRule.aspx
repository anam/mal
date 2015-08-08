<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminHR_OverTimePackageRule.aspx.cs" Inherits="AdminHR_OverTimePackageRule" Title="HR_OverTimePackageRule Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateHR_OverTimePackageRule</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblOverTimePackageID" runat="server" Text="Over Time Package: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlOverTimePackageID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblOverTimeRuleName" runat="server" Text="Over Time Rule Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtOverTimeRuleName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblOverTimeRuleValue" runat="server" Text="Over Time Rule Value: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtOverTimeRuleValue" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblOverTimeRuleOperator" runat="server" Text="Over Time Rule Operator: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtOverTimeRuleOperator" class="txt large-input" runat="server" Text="">
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

