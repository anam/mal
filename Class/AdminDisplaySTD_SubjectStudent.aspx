<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminDisplaySTD_SubjectStudent.aspx.cs" Inherits="AdminDisplaySTD_SubjectStudent" Title="STD_SubjectStudent Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Process Student Class Enrollment</h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvSTD_SubjectStudent" class="gridCss" runat="server" AutoGenerateColumns="false" CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
	 	 	<Columns>
<%--<asp:TemplateField HeaderText="Subject Student">
 	 <ItemTemplate>
 	 <asp:Label ID="lblSubjectStudentID" runat="server" Text='<%#Eval("SubjectStudentID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>

<asp:TemplateField HeaderText="Student">
 	 <ItemTemplate>
 	 <asp:Label ID="lblStudentID" runat="server" Text='<%#Eval("StudentCode") %>'>
 	 </asp:Label>&nbsp;-&nbsp;
     <asp:Label ID="Label1" runat="server" Text='<%#Eval("StudentName") %>'>
 	 </asp:Label>
     <br />
        <asp:Label ID="lblProcessMessage" runat="server" Text='<%#Eval("msg") %>'></asp:Label>
     
  		</ItemTemplate>
 	</asp:TemplateField>
    <asp:TemplateField HeaderText="Course">
 	 <ItemTemplate>
 	 <asp:Label ID="lblCourse" runat="server" Text='<%#Eval("CourseName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Subject">
 	 <ItemTemplate>
 	 <asp:Label ID="lblSubjectID" runat="server" Text='<%#Eval("SubjectName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
    <asp:TemplateField HeaderText="Class">
 	 <ItemTemplate>
 	 <asp:Label ID="lblClassID" runat="server" Text='<%#Eval("ClassName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<%--<asp:TemplateField HeaderText="Date">
 	 <ItemTemplate>
 	 <asp:Label ID="lblUpdateDate" runat="server" Text='<%#Eval("CreateDate") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
    <asp:TemplateField HeaderText="Date">
 	 <ItemTemplate>
 	 <asp:Label ID="lblUpdateDate" runat="server" Text='<%#Eval("AddedDate","{0:dd MMM yyyy}") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Denay">
 	 <ItemTemplate>
 	 <%--<asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("SubjectStudentID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />--%>
     
 	 <asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("SubjectStudentID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
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

