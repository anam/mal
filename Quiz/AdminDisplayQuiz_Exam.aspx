<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminDisplayQuiz_Exam.aspx.cs" Inherits="AdminDisplayQuiz_Exam" Title="Quiz_Exam Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>All Exam</h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvQuiz_Exam" class="gridCss" runat="server" AutoGenerateColumns="false" CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
	 	 	<Columns>
<%--<asp:TemplateField HeaderText="Exam">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExamID" runat="server" Text='<%#Eval("ExamID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
<asp:TemplateField HeaderText="Exam Name">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExamName" runat="server" Text='<%#Eval("ExamName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Course">
 	 <ItemTemplate>
 	 <asp:Label ID="lblCourseID" runat="server" Text='<%#Eval("CourseName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Subject">
 	 <ItemTemplate>
 	 <asp:Label ID="lblSubjectID" runat="server" Text='<%#Eval("SubjectName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<%--<asp:TemplateField HeaderText="Chapter">
 	 <ItemTemplate>
 	 <asp:Label ID="lblChapterID" runat="server" Text='<%#Eval("ChapterName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
<asp:TemplateField HeaderText="Exam Time Duration">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExamTimeDuration" runat="server" Text='<%#Eval("ExamTimeDuration") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<%--<asp:TemplateField HeaderText="Exam Start Time">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExamStartTime" runat="server" Text='<%#Eval("ExamStartTime") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Is Retake">
 	 <ItemTemplate>
 	 <asp:Label ID="lblIsRetake" runat="server" Text='<%#Eval("IsRetake") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Is Active">
 	 <ItemTemplate>
 	 <asp:Label ID="lblIsActive" runat="server" Text='<%#Eval("IsActive") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("ExamID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <%--<asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("ExamID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
 	  />--%>
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

