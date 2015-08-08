<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminSTD_FeesMaster.aspx.cs" Inherits="AdminSTD_FeesMaster" Title="STD_FeesMaster Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateSTD_FeesMaster</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblFeesMasterName" runat="server" Text="Fees Master Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtFeesMasterName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblTotalPayment" runat="server" Text="Total Payment: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtTotalPayment" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblDiscount" runat="server" Text="Discount: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtDiscount" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblTotalPaymentNeedtoPay" runat="server" Text="Total Payment Needto Pay: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtTotalPaymentNeedtoPay" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblFeesTypeID" runat="server" Text="Fees Type: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlFeesTypeID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblSubmissionDate" runat="server" Text="Submission Date: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtSubmissionDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblSubmitedDate" runat="server" Text="Submited Date: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtSubmitedDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblStudentID" runat="server" Text="Student: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlStudentID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblCourseID" runat="server" Text="Course: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlCourseID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblRemarks" runat="server" Text="Remarks: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtRemarks" TextMode="MultiLine" class="txt textarea" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblIsPaid" runat="server" Text="Is Paid: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:RadioButtonList ID="radIsPaid" runat="server" 
    RepeatDirection="Horizontal">
    <asp:ListItem>True</asp:ListItem>
    <asp:ListItem>False</asp:ListItem>
    </asp:RadioButtonList>
     </dd>
    <dt>
     <asp:Label ID="lblPaymentStatusID" runat="server" Text="Payment Status: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlPaymentStatusID" runat="server">
     </asp:DropDownList>
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

