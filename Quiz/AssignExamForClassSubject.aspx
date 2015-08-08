<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AssignExamForClassSubject.aspx.cs" Inherits="AdminSTD_Exam" Title="Insert /Update Exam" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Insert /Update Exam</h3>
                </div>
                <div class="inner-form">
                    <!-- error and information messages -->
                    <dl>
                        <dt>
                            <asp:Label ID="lblClassID" runat="server" Text="Class: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlClassID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClassID_OnSelectedIndexChanged">
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblSubject" runat="server" Text="Subject: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlSubjectID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubjectID_SelectedIndexChanged">
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblExamTypeID" runat="server" Text="Class Exam: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlSTDExamID" runat="server">
                            </asp:DropDownList>
                            <br />
                            <asp:CheckBox ID="chkAllStudentSameExam" runat="server" Text="All Student Same Exam / Set"
                                AutoPostBack="True" OnCheckedChanged="chkAllStudentSameExam_CheckedChanged" />
                        </dd>
                        <dt>
                            <asp:Label ID="lblQuizExam" runat="server" Text="Quiz Exam/Set: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlQuizExamID" runat="server">
                            </asp:DropDownList>
                            <asp:GridView ID="gvStudents" runat="server" OnRowDataBound="gvStudents_RowDataBound"
                                AutoGenerateColumns="false" CssClass="tabel_input">
                                <HeaderStyle CssClass="heading" />
                                <RowStyle CssClass="row" />
                                <AlternatingRowStyle CssClass="altrow" />
                                <Columns>
                                    <%--<asp:TemplateField HeaderText="Photo" Visible="false">
                                <ItemTemplate>
                                    <asp:Image ID="imgPhoto" ImageUrl='<%#Eval("PPSizePhoto")%>' runat="server" Height="100px" Width="100px" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Serial">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex +1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <%# Eval("StudentName")  %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <%# Eval("StudentCode")  %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quiz Exam/Set">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlStudentQuizExamID" runat="server">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hfStudentID" Value='<%# Eval("StudentID")  %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </dd>
                        <dt></dt>
                        <dd>
                            <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                                OnClick="btnUpdate_Click" Visible="false" />
                        </dd>
                    </dl>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
