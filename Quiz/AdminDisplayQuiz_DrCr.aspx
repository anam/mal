<%@ Page Title="List of Existing Dr/Cr Quiz" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="AdminDisplayQuiz_DrCr.aspx.cs" Inherits="Quiz_AdminDisplayQuiz_DrCr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
<link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                List of Existing Dr/Cr Quiz</h3>
        </div>
        <div class="inner-content">
            <dl>
                <dt>
                    <asp:Label ID="lblCourseID" runat="server" Text="Course: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlCourseID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourseID_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblSubjectID" runat="server" Text="Subject: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlSubjectID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjectID_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblChapterID" runat="server" Text="Chapter: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlChapterID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlChapterID_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
            </dl>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvQuiz_TrueFalse" class="gridCss" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvQuiz_TrueFalse_RowDataBound"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row"/>
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <asp:TemplateField HeaderText="Serial">
                        <ItemTemplate>
                            <asp:Label ID="lblTrueFalseID" runat="server" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Question Type">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfComprehensionID" runat="server" Value='<%#Eval("ComprehensionID") %>' />
                            <asp:Label ID="lblQuestionType" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Course">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfCourseID" runat="server" Value='<%#Eval("CourseID") %>' />
                            <asp:Label ID="lblCourseName" runat="server">
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Subject">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfSubjectID" runat="server" Value='<%#Eval("SubjectID") %>' />
                            <asp:Label ID="lblSubjectName" runat="server">
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Chapter">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfChapterID" runat="server" Value='<%#Eval("ChapterID") %>' />
                            <asp:Label ID="lblChapterName" runat="server">
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Question Title">
                        <ItemTemplate>
                            <asp:Label ID="lblQuestionTitle" runat="server" Text='<%#Eval("QuestionTitle") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Is Dr Cr">
                        <ItemTemplate>
                            <asp:Label ID="lblIsDrCr" runat="server" Text='<%#Eval("IsDrCr") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Dr/Cr">
                        <ItemTemplate>
                            <asp:Label ID="lblIsTrue" runat="server"><%#(bool)Eval("IsTrue")==true?"Dr":"Cr" %>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("TrueFalseID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" CommandArgument='<%#Eval("TrueFalseID") %>' OnClientClick="return confirm('Are you sure to delete?');"
                                OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
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
                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
