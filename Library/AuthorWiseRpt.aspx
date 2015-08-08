<%@ Page Title="Authorwise Book Report" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="AuthorWiseRpt.aspx.cs" Inherits="Library_AuthorWiseRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 315px;
        }
        .style2
        {
            width: 176px;
        }
        .style3
        {
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                List of Existing Authorwise Book Report</h3>
        </div>
        <div>
            <table style="width: 100%; height: 31px;">
                <tr>
                    <td class="style41">
                        &nbsp;
                    </td>
                    <td class="style40">
                        &nbsp;
                    </td>
                    <td class="style1" colspan="2">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblPrint" runat="server"></asp:Label>
                    </td>
                    <td class="style21" width="130px">
                        <asp:DropDownList ID="DDPrintOpt" runat="server" Font-Names="Tahoma" Style="font-size: 11px"
                            Width="130px">
                            <asp:ListItem Selected="True" Value="PDF">Adobe Acrobat (PDF)</asp:ListItem>
                            <asp:ListItem Value="HTML">HTML</asp:ListItem>
                            <asp:ListItem Value="WORD">MS Word</asp:ListItem>
                            <asp:ListItem Value="EXCEL">MS Excel</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style26" align="right">
                        &nbsp;
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkPrint" runat="server" CssClass="button" Font-Size="12px" Height="20px"
                            OnClick="lnkPrint_Click">PRINT</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="style41">
                        &nbsp;
                    </td>
                    <td class="style40" align="right">
                        AuthorName
                    </td>
                    <td class="style2">
                        <asp:DropDownList ID="ddlAuthorID" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="style3">
                        <asp:CheckBox ID="chkAllAuthor" runat="server" Text="All Author" />
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkBtnShow" runat="server" BackColor="#336600" ForeColor="White"
                            OnClick="lnkBtnShow_Click" Width="40px">Show</asp:LinkButton>
                    </td>
                    <td class="style21" width="130px" align="center">
                        &nbsp;
                        <asp:Label ID="lbljavascript" runat="server"></asp:Label>
                    </td>
                    <td class="style26" align="right">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <div class="inner-content">
                <asp:GridView ID="gvLIB_Book" class="gridCss" runat="server" AutoGenerateColumns="false"
                     CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                    <Columns>
                        <asp:TemplateField HeaderText="Book ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblBookID" Visible="false" runat="server" Text='<%#Eval("BookID") %>'>
 	                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Book Name">
                            <ItemTemplate>
                                <asp:Label ID="lblBookName" runat="server" Text='<%#Eval("BookName") %>'>
 	                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Subject">
                            <ItemTemplate>
                                <asp:Label ID="lblSubjectID" runat="server" Text='<%#Eval("SubjectName") %>'>
 	                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Author Name" HeaderStyle-Width="14%">
                            <ItemTemplate>
                                <asp:Label ID="lblAuthorID" runat="server" Text='<%#Eval("AuthorName") %>'>
 	                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Book ISBN">
                            <ItemTemplate>
                                <asp:Label ID="lblBookISBN" runat="server" Text='<%#Eval("BookISBN") %>'>
 	                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Publisher Name" HeaderStyle-Width="16%">
                            <ItemTemplate>
                                <asp:Label ID="lblPublisherID" runat="server" Text='<%#Eval("PublisherName") %>'>
 	                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pub. Year" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="lblPublishedYear" runat="server" Text='<%#Eval("PublishedYear") %>'>
 	                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <a style="text-decoration:underline;" href='BookIssue.aspx?BookID=<%#Eval("BookID") %>'>Issue</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
