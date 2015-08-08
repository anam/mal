<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminHR_SalaryTaxPackageRules.aspx.cs" Inherits="AdminHR_SalaryTaxPackageRules" Title="HR_SalaryTaxPackageRules Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateHR_SalaryTaxPackageRules</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblEmployeeID" runat="server" Text="Employee: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlEmployeeID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblSalaryTaxPackageID" runat="server" Text="Salary Tax Package: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlSalaryTaxPackageID" runat="server">
     </asp:DropDownList>
     </dd>
 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 </dd>
 </dl></div>
 </div>
 </asp:Content>

