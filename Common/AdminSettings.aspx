<%@ Page Title="Admin Settings" Language="C#" MasterPageFile="~/Site2Column.master"
    AutoEventWireup="true" CodeFile="AdminSettings.aspx.cs" Inherits="AdminSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                Admin Settings</h3>
        </div>
        <div class="inner-content">
            <table width="100%" class="gridCss">
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Common/AdminCOMN_City.aspx"
                            Text="Add City"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Common/AdminDisplayCOMN_City.aspx"
                            Text="View City"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Common/AdminCOMN_Country.aspx"
                            Text="Add Country"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Common/AdminDisplayCOMN_Country.aspx"
                            Text="View Country"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Common/AdminCOMN_Campus.aspx"
                            Text="Add Campus"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Common/AdminDisplayCOMN_Campus.aspx"
                            Text="View Campus"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Class/AdminSTD_Room.aspx"
                            Text="Add Room"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_Room.aspx"
                            Text="View Room"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Common/AdminCOMN_ReaultSystem.aspx"
                            Text="Add Result System"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Common/AdminDisplayCOMN_ReaultSystem.aspx"
                            Text="View Result System"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Common/AdminCOMN_RowStatus.aspx"
                            Text="Add Row Status"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Common/AdminDisplayCOMN_RowStatus.aspx"
                            Text="View Row Status"></asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
