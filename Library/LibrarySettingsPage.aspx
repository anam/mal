<%@ Page Title="Library Settings" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="LibrarySettingsPage.aspx.cs" Inherits="Library_LibrarySettingsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                Library Settings</h3>
        </div>
        <div class="inner-content">
            <table width="100%" class="gridCss">
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Library/AdminLIB_Author.aspx"
                            Text="Add Author"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Library/AdminDisplayLIB_Author.aspx"
                            Text="View Author"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Library/AdminLIB_Publisher.aspx"
                            Text="Add Publisher"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Library/AdminDisplayLIB_Publisher.aspx"
                            Text="View Publisher"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Library/AdminLIB_Category.aspx"
                            Text="Add Category"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Library/AdminDisplayLIB_Category.aspx"
                            Text="View Category"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Library/AdminLIB_SubCategory.aspx"
                            Text="Add Sub Category"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Library/AdminDisplayLIB_SubCategory.aspx"
                            Text="View Sub Category"></asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
