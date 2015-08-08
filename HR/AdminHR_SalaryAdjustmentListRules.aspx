<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminHR_SalaryAdjustmentListRules.aspx.cs" Inherits="AdminHR_SalaryAdjustmentListRules" Title="SalaryAdjustmentListRules Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateSalaryAdjustmentListRules</h3>
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
     <asp:Label ID="lblSalaryAdjustmentListID" runat="server" Text="Salary Adjustment List: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlSalaryAdjustmentListID" runat="server">
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

