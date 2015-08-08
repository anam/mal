<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="ExamResultPerStudent.aspx.cs" Inherits="Exam_ExamResultPerStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .tableCss
        {
            text-align: left;
        }
        .txtCss
        {
            width: 300px;
            margin: 2px 0;
            padding: 2px;
            border: 1px solid #ccc;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="upPerformance" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Student Result Sheet</h3>
                </div>
                <div class="inner-content">
                    <table id="tblSudentCode" runat="server">
                        <tr>
                            <td style="width: 80px">
                                Stuent Code:
                            </td>
                            <td style="width: 125px">
                                <asp:TextBox ID="txtStudentCode" runat="server" CssClass="txtCss" Width="120px">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnOk" Text="Search" runat="server" CssClass="button button-blue" OnClick="btnOk_OnClick" />
                            </td>
                        </tr>
                    </table>
                    <div style="width: 100%; margin: 0px auto; overflow: scroll">
                        <asp:GridView ID="gvSTD_ExamDetails" class="gridCss" runat="server" AutoGenerateColumns="false"
                            CssClass="tabel_input">
                            <HeaderStyle CssClass="heading" />
                            <RowStyle CssClass="row" />
                            <AlternatingRowStyle CssClass="altrow" />
                            <Columns>
                                <asp:TemplateField HeaderText="Exam">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExamID" runat="server" Text='<%#Eval("ExamName") %>'>
 	 </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Marks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalMarks" runat="server" Text='<%#Eval("TotalMark") %>'>
 	 </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Obtain Mark">
                                    <ItemTemplate>
                                        <asp:Label ID="lblObtainMark" runat="server" Text='<%#Eval("ObtainedMark") %>'>
 	 </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Result">
                                    <ItemTemplate>
                                        <a href='../Exam/ResultSheet.aspx?examID=<%#Eval("ExamID")%>&StudentID=<%#Eval("StudentID")%>' target="_blank">Result Sheet</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
