<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminDisplaySTD_FeesMaster.aspx.cs" Inherits="AdminDisplaySTD_FeesMaster" Title="STD_FeesMaster Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Tabular DataSTD_FeesMaster</h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvSTD_FeesMaster" class="gridCss" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
	 	 	<Columns>
<asp:TemplateField HeaderText="Fees Master">
 	 <ItemTemplate>
 	 <asp:Label ID="lblFeesMasterID" runat="server" Text='<%#Eval("FeesMasterID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Fees Master Name">
 	 <ItemTemplate>
 	 <asp:Label ID="lblFeesMasterName" runat="server" Text='<%#Eval("FeesMasterName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Total Payment">
 	 <ItemTemplate>
 	 <asp:Label ID="lblTotalPayment" runat="server" Text='<%#Eval("TotalPayment") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Discount">
 	 <ItemTemplate>
 	 <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Total Payment Needto Pay">
 	 <ItemTemplate>
 	 <asp:Label ID="lblTotalPaymentNeedtoPay" runat="server" Text='<%#Eval("TotalPaymentNeedtoPay") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Fees Type">
 	 <ItemTemplate>
 	 <asp:Label ID="lblFeesTypeID" runat="server" Text='<%#Eval("FeesTypeID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Submission Date">
 	 <ItemTemplate>
 	 <asp:Label ID="lblSubmissionDate" runat="server" Text='<%#Eval("SubmissionDate") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Submited Date">
 	 <ItemTemplate>
 	 <asp:Label ID="lblSubmitedDate" runat="server" Text='<%#Eval("SubmitedDate") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Student">
 	 <ItemTemplate>
 	 <asp:Label ID="lblStudentID" runat="server" Text='<%#Eval("StudentID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Course">
 	 <ItemTemplate>
 	 <asp:Label ID="lblCourseID" runat="server" Text='<%#Eval("CourseID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks">
 	 <ItemTemplate>
 	 <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("Remarks") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Is Paid">
 	 <ItemTemplate>
 	 <asp:Label ID="lblIsPaid" runat="server" Text='<%#Eval("IsPaid") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Payment Status">
 	 <ItemTemplate>
 	 <asp:Label ID="lblPaymentStatusID" runat="server" Text='<%#Eval("PaymentStatusID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Extra Field 1">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExtraField1" runat="server" Text='<%#Eval("ExtraField1") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Extra Field 2">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExtraField2" runat="server" Text='<%#Eval("ExtraField2") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Extra Field 3">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExtraField3" runat="server" Text='<%#Eval("ExtraField3") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Extra Field 4">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExtraField4" runat="server" Text='<%#Eval("ExtraField4") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Extra Field 5">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExtraField5" runat="server" Text='<%#Eval("ExtraField5") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Update Date">
 	 <ItemTemplate>
 	 <asp:Label ID="lblUpdateDate" runat="server" Text='<%#Eval("UpdateDate") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Row Status">
 	 <ItemTemplate>
 	 <asp:Label ID="lblRowStatusID" runat="server" Text='<%#Eval("RowStatusID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("FeesMasterID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("FeesMasterID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
 	  />
  		</ItemTemplate>
 	</asp:TemplateField>
	 	 	</Columns>
	 	 </asp:GridView>
	<div class="paging">
	<div class="viewpageinfo">
	<%--View 1 -10 of 13--%>
	Show
	</div>
	<asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
	 <asp:ListItem Text="10" Value="10" />
	<asp:ListItem Text="25" Value="25" />
	<asp:ListItem Text="50" Value="50" />
	 </asp:DropDownList>
	<div class="pagelist">
	 <asp:Repeater ID="rptPager" runat="server">
	<ItemTemplate>
	<asp:LinkButton ID="lnkPage" runat="server" Text = '<%#Eval("Text") %>' CommandArgument = '<%# Eval("Value") %>' Enabled = '<%# Eval("Enabled") %>' OnClick = "Page_Changed"></asp:LinkButton>
	</ItemTemplate>
	</asp:Repeater>
	</div>
	</div>
</div>
</div>
 </asp:Content>

