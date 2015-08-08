<%@ Page Title="Class Settings" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="ClassSettingPage.aspx.cs" Inherits="Class_ClassSettingPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                Class Settings</h3>
        </div>
        <div class="inner-content">
            <table width="100%" class="gridCss">
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Class/AdminSTD_Course.aspx"
                            Text="Add Course"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_Course.aspx"
                            Text="View Course"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Class/AdminSTD_Subject.aspx"
                            Text="Add Subject"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_Subject.aspx"
                            Text="View Subject"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Class/AdminSTD_ClassType.aspx"
                            Text="Add Class Type"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_ClassType.aspx"
                            Text="View Class Type"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/Class/AdminSTD_ClassStatus.aspx"
                            Text="Add Class Status"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_ClassStatus.aspx"
                            Text="View Class Status"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Class/AdminSTD_ClassDay.aspx"
                            Text="Add Class Day"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_ClassDay.aspx"
                            Text="View Class Day"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Class/AdminSTD_ClassTime.aspx"
                            Text="Add Class Time"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_ClassTime.aspx"
                            Text="View Class Time"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Class/AdminSTD_Room.aspx"
                            Text="Add Room"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_Room.aspx"
                            Text="View Room"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Class/AdminSTD_Routine.aspx"
                            Text="Add Routine"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_Routine.aspx"
                            Text="View Routine"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Class/AdminSTD_RoutineTime.aspx"
                            Text="Add Routine Time"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_RoutineTime.aspx"
                            Text="View Routine Time"></asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
