<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayLIB_Book.aspx.cs" Inherits="AdminDisplayLIB_Book" Title="List of Existing Library Books" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Search</h3>
        </div>
        <div class="inner-content">
            <dl>
                <dt>
                    <asp:Label ID="lblBookName" runat="server" Text="Book Name : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtBook" runat="server" Text ="" class="txt medium-input">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblSubject" runat="server" Text="Subject : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlSubjectID" runat="server" class="txt medium-input">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="Author" runat="server" Text="Author : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlAuthorID" runat="server" class="txt medium-input">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblPublisher" runat="server" Text="Publisher : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlPublisherID" runat="server" class="txt medium-input">
                    </asp:DropDownList>
                </dd>
                
                <dt>
                    <asp:Label ID="Label1" runat="server" Text="Book ISBN : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtBookISBN" runat="server" Text ="" class="txt medium-input">
                    </asp:TextBox>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnIssueSearch" class="button button-blue" runat="server" Text="Search"
                        OnClick="btnIssueSearch_Click" />
                </dd>
            </dl>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                List of Existing Library Books</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvLIB_Book" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <%--<asp:TemplateField HeaderText="Book" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblBookID" runat="server" Visible="false" Text='<%#Eval("BookID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Subject">
                        <ItemTemplate>
                            <asp:Label ID="lblSubjectID" runat="server" Text='<%#Eval("SubjectName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Publisher">
                        <ItemTemplate>
                            <asp:Label ID="lblPublisherID" runat="server" Text='<%#Eval("PublisherName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Author">
                        <ItemTemplate>
                            <asp:Label ID="lblAuthorID" runat="server" Text='<%#Eval("AuthorName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Book Name" HeaderStyle-Width="15%">
                        <ItemTemplate>
                            <asp:Label ID="lblBookName" runat="server" Text='<%#Eval("BookName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Book ISBN" HeaderStyle-Width="15%">
                        <ItemTemplate>
                            <asp:Label ID="lblBookISBN" runat="server" Text='<%#Eval("BookISBN") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Published Year" HeaderStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lblPublishedYear" runat="server" Text='<%#Eval("PublishedYear") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit /Delete" HeaderStyle-Width="13%">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("BookID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" CommandArgument='<%#Eval("BookID") %>'
                                OnClick="lbDelete_Click" AlternateText="Delete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <table>
                <tr>
                    <td style = "width:80%">
                   </td>
                    <%--<td style = "width:35%">
                    </td>--%>
                    <td style = "width:20%" align="right">
                        <asp:Label ID="lblTotalBook" runat="server" Text="" Font-Bold="true" Width="100%"></asp:Label>
                    </td>
                </tr>
            </table>
            
            <div id = "showPageDiv" runat ="server" class="paging">
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
                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
