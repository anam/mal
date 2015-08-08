<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminDisplayQuiz_ExamStudent.aspx.cs" Inherits="AdminDisplayQuiz_ExamStudent" Title="Quiz_ExamStudent Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Tabular DataQuiz_ExamStudent</h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvQuiz_ExamStudent" class="gridCss" runat="server" AutoGenerateColumns="false"  CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
	 	 	<Columns>
<%--<asp:TemplateField HeaderText="Exam Student">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExamStudentID" runat="server" Text='<%#Eval("ExamStudentID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
<asp:TemplateField HeaderText="Exam Student Name">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExamStudentName" runat="server" Text='<%#Eval("ExamStudentName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<%--<asp:TemplateField HeaderText="Student">
 	 <ItemTemplate>
 	 <asp:Label ID="lblStudentID" runat="server" Text='<%#Eval("StudentID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
<asp:TemplateField HeaderText="Class">
 	 <ItemTemplate>
 	 <asp:Label ID="lblClassID" runat="server" Text='<%#Eval("ClassName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Subject">
 	 <ItemTemplate>
 	 <asp:Label ID="lblSubjectID" runat="server" Text='<%#Eval("SubjectName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Exam">
 	 <ItemTemplate>
 	 <asp:Label ID="lblSTDExamDetailsID" runat="server" Text='<%#Eval("ExamDetailsName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Quiz">
 	 <ItemTemplate>
 	 <asp:Label ID="lblQuizExamID" runat="server" Text='<%#Eval("ExamName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
    <asp:TemplateField HeaderText="Quiz">
 	 <ItemTemplate>
 	         <a href='../Quiz/ExamPage.aspx?ExamStudentID=<%#Eval("ExamStudentID") %>&ExamDetailsID=<%#Eval("STDExamDetailsID") %>&ExamID=<%#Eval("QuizExamID") %>&StudentID=<%#Eval("StudentID") %>'>Start Exam</a>
  		</ItemTemplate>
 	</asp:TemplateField>
<%--<asp:TemplateField HeaderText="Extra Field 1">
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
 	</asp:TemplateField>--%>
<%--<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("ExamStudentID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("ExamStudentID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
 	  />
  		</ItemTemplate>
 	</asp:TemplateField>--%>
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

