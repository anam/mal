<%@ Page Title="Student Settings" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="StudentSettingsPage.aspx.cs" Inherits="Student_StudentSettingsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                Student Settings</h3>
        </div>
        <div class="inner-content">
            <table width="100%" class="gridCss">
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Student/AdminSTD_Batch.aspx"
                            Text="Add Batch"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Student/AdminDisplaySTD_Batch.aspx"
                            Text="View Batch"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Student/AdminSTD_BoardUniversity.aspx"
                            Text="Add Board/University"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Student/AdminDisplaySTD_BoardUniversity.aspx"
                            Text="View Board/University"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Student/AdminSTD_ContactType.aspx"
                            Text="Add Contact Type"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Student/AdminDisplaySTD_ContactType.aspx"
                            Text="View Contact Type"></asp:HyperLink>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Class/AdminSTD_Course.aspx"
                            Text="Add Course"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_Course.aspx"
                            Text="View Course"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Class/AdminSTD_Subject.aspx"
                            Text="Add Subject"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_Subject.aspx"
                            Text="View Subject"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Class/AdminSTD_ClassType.aspx"
                            Text="Add Class Type"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_ClassType.aspx"
                            Text="View Class Type"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink151" runat="server" NavigateUrl="~/Class/AdminSTD_ClassStatus.aspx"
                            Text="Add Class Status"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink161" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_ClassStatus.aspx"
                            Text="View Class Status"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Class/AdminSTD_ClassDay.aspx"
                            Text="Add Class Day"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_ClassDay.aspx"
                            Text="View Class Day"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink11115" runat="server" NavigateUrl="~/Class/AdminSTD_ClassTime.aspx"
                            Text="Add Class Time"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_ClassTime.aspx"
                            Text="View Class Time"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--<asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/Class/AdminSTD_ClassTimeGroup.aspx"
                            Text="Add Class Time Set"></asp:HyperLink>--%>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_ClassTimeGroup.aspx"
                            Text="View Class Time Set/Group"></asp:HyperLink>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1117" runat="server" NavigateUrl="~/Class/AdminSTD_Room.aspx"
                            Text="Add Room"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1118" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_Room.aspx"
                            Text="View Room"></asp:HyperLink>
                    </td>
                </tr>--%>
                <%--<tr>
                    <td>
                        <asp:HyperLink ID="HyperLink11117" runat="server" NavigateUrl="~/Class/AdminSTD_Routine.aspx"
                            Text="Add Routine"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink111118" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_Routine.aspx"
                            Text="View Routine"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="~/Class/AdminSTD_RoutineTime.aspx"
                            Text="Add Routine Time"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink20" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_RoutineTime.aspx"
                            Text="View Routine Time"></asp:HyperLink>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1445" runat="server" NavigateUrl="~/Common/AdminCOMN_City.aspx"
                            Text="Add City"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1447" runat="server" NavigateUrl="~/Common/AdminDisplayCOMN_City.aspx"
                            Text="View City"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1448" runat="server" NavigateUrl="~/Common/AdminCOMN_Country.aspx"
                            Text="Add Country"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1449" runat="server" NavigateUrl="~/Common/AdminDisplayCOMN_Country.aspx"
                            Text="View Country"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink2440" runat="server" NavigateUrl="~/Common/AdminCOMN_Campus.aspx"
                            Text="Add Campus"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink4421" runat="server" NavigateUrl="~/Common/AdminDisplayCOMN_Campus.aspx"
                            Text="View Campus"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink4422" runat="server" NavigateUrl="~/Class/AdminSTD_Room.aspx"
                            Text="Add Room"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink2553" runat="server" NavigateUrl="~/Class/AdminDisplaySTD_Room.aspx"
                            Text="View Room"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink2554" runat="server" NavigateUrl="~/Common/AdminCOMN_ReaultSystem.aspx"
                            Text="Add Result System"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink2555" runat="server" NavigateUrl="~/Common/AdminDisplayCOMN_ReaultSystem.aspx"
                            Text="View Result System"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink2556" runat="server" NavigateUrl="~/Common/AdminCOMN_RowStatus.aspx"
                            Text="Add Row Status"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink2557" runat="server" NavigateUrl="~/Common/AdminDisplayCOMN_RowStatus.aspx"
                            Text="View Row Status"></asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
