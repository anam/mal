<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminACC_JournalHistory.aspx.cs" Inherits="AdminACC_JournalHistory" Title="ACC_JournalHistory Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateACC_JournalHistory</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblHeadID" runat="server" Text="Head: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlHeadID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblDebit" runat="server" Text="Debit: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtDebit" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblCredit" runat="server" Text="Credit: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtCredit" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblJournalMasterID" runat="server" Text="Journal Master: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlJournalMasterID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblJournalVoucherNo" runat="server" Text="Journal Voucher No: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtJournalVoucherNo" class="txt large-input" runat="server" Text="">
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
    <dt>
     <asp:Label ID="lblHistoryDate" runat="server" Text="History Date: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtHistoryDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblHistoryBy" runat="server" Text="History By: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtHistoryBy" class="txt large-input" runat="server" Text="">
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

