<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminACC_CUCCheck.aspx.cs" Inherits="AdminACC_CUCCheck" Title="ACC_CUCCheck Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateACC_CUCCheck</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblCUCCheckName" runat="server" Text="CUC Check Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtCUCCheckName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblCUCCheckNo" runat="server" Text="CUC Check No: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtCUCCheckNo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblBankAccountID" runat="server" Text="Bank Account: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlBankAccountID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblCheckDate" runat="server" Text="Check Date: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtCheckDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblPaytoHeadID" runat="server" Text="Payto Head: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlPaytoHeadID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblJournalID" runat="server" Text="Journal: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlJournalID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblAmount" runat="server" Text="Amount: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtAmount" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExtraField1" runat="server" Text="Extra Field 1: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExtraField1" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExtraField2" runat="server" Text="Extra Field 2: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExtraField2" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExtraField3" runat="server" Text="Extra Field 3: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExtraField3" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExtraField4" runat="server" Text="Extra Field 4: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExtraField4" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExtraField5" runat="server" Text="Extra Field 5: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExtraField5" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblRowStatusID" runat="server" Text="Row Status: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlRowStatusID" runat="server">
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

