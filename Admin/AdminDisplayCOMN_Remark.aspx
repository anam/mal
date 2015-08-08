<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminDisplayCOMN_Remark.aspx.cs" Inherits="AdminDisplayCOMN_Remark" Title="Report History" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Report History</h3>
</div>
<div class="inner-content">

    ID:<asp:TextBox ID="txtID" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" 
        onclick="btnSearch_Click" />
	 	<asp:GridView ID="gvCOMN_Remark" class="gridCss" runat="server" AutoGenerateColumns="false" CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
	 	 	<Columns>
<%--<asp:TemplateField HeaderText="Remark">
 	 <ItemTemplate>
 	 <asp:Label ID="lblRemarkID" runat="server" Text='<%#Eval("RemarkID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
<asp:TemplateField HeaderText="Report">
 	 <ItemTemplate>
 	 <asp:Label ID="lblRemarkName" Font-Bold="true" runat="server" Text='<%#Eval("RemarkName") %>'>
 	 </asp:Label>
  		<%--</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Remark">
 	 <ItemTemplate>--%>
     <br />
 	 <asp:Label ID="lblRemark" runat="server" Text='<%#Eval("Remark") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Remark Date">
 	 <ItemTemplate>
 	 <asp:Label ID="lblRemarkDate" runat="server" Text='<%#Eval("RemarkDate","{0:dd MMM yyyy}") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Who Reported">
 	 <ItemTemplate>
 	 <asp:Label ID="lblWhoReported" runat="server" Text='<%#Eval("WhoReported") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Who Did">
 	 <ItemTemplate>
 	 <asp:Label ID="lblWhoDid" runat="server" Text='<%#Eval("WhoDid") %>'>
 	 </asp:Label>
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
<asp:TemplateField HeaderText="Row Status">
 	 <ItemTemplate>
 	 <asp:Label ID="lblRowStatusID" runat="server" Text='<%#Eval("RowStatusID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("RemarkID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("RemarkID") %>' OnClick="lbDelete_Click"   OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
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

