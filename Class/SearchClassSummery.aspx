<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="SearchClassSummery.aspx.cs" Inherits="Class_SearchClassSummery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .txtCss
        {
            width: 120px;
            height: 28px;
            border: solid 1px #ccc;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="upClassSummery" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        View Class Summery</h3>
                </div>
                <div class="inner-content" style="width: 98%">
                    <table width="100%">
                        <tr>
                            <td style="width: 90px">
                                Student Code:
                            </td>
                            <td>
                                <asp:TextBox ID="txtStudentCode" runat="server" CssClass="txtCss" Width="120px"></asp:TextBox>
                            </td>
                            <td>
                                From Date:
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtCss"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajcal" runat="server" TargetControlID="txtFromDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>
                                To Date:
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="txtCss"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server"
                                    TargetControlID="txtToDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>
                                <asp:Button ID="btnSeach" runat="server" class="button button-blue" Text="Search"
                                    OnClick="btnSeach_OnClick" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="inner-content">
                    <asp:GridView ID="gvSTD_ClassSummery" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblStudentName" runat="server" Text='<%#Eval("StudentName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Teacher Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblTeacherName" runat="server" Text='<%#Eval("EmployeeName") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NoOfClass">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoOfClass" runat="server" Text='<%#Eval("NoOfClass") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NoOfPresent">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoOfPresent" runat="server" Text='<%#Eval("NoOfPresent") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NoOfAbsent">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoAbsent" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ClassSummery">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkClassSummery" Text="Summery" ToolTip='<%#Eval("StudentID") %>'
                                        CommandArgument='<%#Eval("ClassSubjectID") %>' runat="server" OnClick="lnkClassSummery_OnClick"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                     
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
