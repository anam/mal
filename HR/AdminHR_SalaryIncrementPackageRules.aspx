<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminHR_SalaryIncrementPackageRules.aspx.cs" Inherits="AdminHR_SalaryIncrementPackageRules" Title="HR_SalaryIncrementPackageRules Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateHR_SalaryIncrementPackageRules</h3>
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
     <asp:Label ID="lblSalaryIncrementPackageID" runat="server" Text="Salary Increment Package: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlSalaryIncrementPackageID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblYear" runat="server" Text="Year: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtYear" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblMonth" runat="server" Text="Month: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtMonth" class="txt large-input" runat="server" Text="">
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

