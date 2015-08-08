<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminDisplaySTD_ComprehensionQuestion.aspx.cs" Inherits="AdminDisplaySTD_ComprehensionQuestion" Title="STD_ComprehensionQuestion Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Show Comprehension Questions</h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvSTD_ComprehensionQuestion" class="gridCss" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
	 	 	<Columns>
<asp:TemplateField HeaderText="Comprehension Question">
 	 <ItemTemplate>
 	 <asp:Label ID="lblComprehensionQuestionID" runat="server" Text='<%#Eval("ComprehensionQuestionID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Question">
 	 <ItemTemplate>
 	 <asp:Label ID="lblQuestionID" runat="server" Text='<%#Eval("QuestionID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Comprehension">
 	 <ItemTemplate>
 	 <asp:Label ID="lblComprehensionID" runat="server" Text='<%#Eval("ComprehensionID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Updated By">
 	 <ItemTemplate>
 	 <asp:Label ID="lblUpdatedBy" runat="server" Text='<%#Eval("UpdatedBy") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Update Date">
 	 <ItemTemplate>
 	 <asp:Label ID="lblUpdateDate" runat="server" Text='<%#Eval("UpdateDate") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("ComprehensionQuestionID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument='<%#Eval("ComprehensionQuestionID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
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
</div>
 </asp:Content>

