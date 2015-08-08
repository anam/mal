<%@ Page Title="Inventory Settings" Language="C#" MasterPageFile="~/Site2Column.master"
    AutoEventWireup="true" CodeFile="InventorySettingsPage.aspx.cs" Inherits="Inventory_InventorySettingsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                Inventory Settings</h3>
        </div>
        <div class="inner-content">
            <table width="100%" class="gridCss">
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Inventory/AdminINV_IteamCategory.aspx"
                            Text="Add Category"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Inventory/AdminDisplayINV_IteamCategory.aspx"
                            Text="View Category"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Inventory/AdminINV_IteamSubCategory.aspx"
                            Text="Add Sub Category"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Inventory/AdminDisplayINV_IteamSubCategory.aspx"
                            Text="View Sub Category"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Inventory/AdminINV_Store.aspx"
                            Text="Add Store"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Inventory/AdminDisplayINV_Store.aspx"
                            Text="View Store"></asp:HyperLink>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Inventory/AdminINV_MRRInfoMaster.aspx"
                            Text="Add MRR Info Master"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Inventory/AdminDisplayINV_MRRInfoMaster.aspx"
                            Text="View MRR Info Master"></asp:HyperLink>
                    </td>
                </tr>--%>
                <%--<tr>
                    <td>
                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Inventory/AdminINV_IssueMaster.aspx"
                            Text="Add Issue Master"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Inventory/AdminDisplayINV_IssueMaster.aspx"
                            Text="View Issue Master"></asp:HyperLink>
                    </td>
                </tr>--%>
            </table>
        </div>
    </div>
</asp:Content>
