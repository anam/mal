<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="FeesOthersShow.aspx.cs" Inherits="AdminDisplaySTD_Fees" Title="STD_Fees Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Tabular DataSTD_Fees</h3>
</div>
<div class="inner-content">
<dl>
    
    
    
    <dt>
     <asp:Label ID="lblStudentID" runat="server" Text="Student: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlStudentID" runat="server">
     </asp:DropDownList>
     </dd>
      <dt>
      <asp:Label ID="Label1" runat="server" Text="Paid ? ">
    </asp:Label>
     </dt>
    <dd>
        <asp:RadioButtonList ID="radIsPaid" runat="server" RepeatDirection="Vertical">
    <asp:ListItem Selected="True">True</asp:ListItem>
    <asp:ListItem>False</asp:ListItem>
    <asp:ListItem>All</asp:ListItem>
    </asp:RadioButtonList>
     </dd>
   
 <dt></dt>
 <dd>
<asp:Button ID="btnSearch" class="button button-blue" runat="server" Text="Search" OnClick="btnSearch_Click" />
 </dd>
 </dl>
</div>
</div>
<div class="content-box">
<div class="header">
<h3>Tabular DataSTD_Fees</h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvSTD_Fees" class="gridCss" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
	 	 	<Columns>
<asp:TemplateField HeaderText="Fees">
 	 <ItemTemplate>
 	 <asp:Label ID="lblFeesID" runat="server" Text='<%#Eval("FeesID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Fees Name">
 	 <ItemTemplate>
 	 <asp:Label ID="lblFeesName" runat="server" Text='<%#Eval("FeesName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Amount">
 	 <ItemTemplate>
 	 <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'>
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
<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("FeesID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("FeesID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
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

