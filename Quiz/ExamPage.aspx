<%@ Page Title="Exam" Language="C#" MasterPageFile="~/Site2ColumnQuiz1.master" AutoEventWireup="true"
    CodeFile="ExamPage.aspx.cs" Inherits="Quiz_ExamPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
<style type="text/css">
        .questionGroup
        {
            padding: 10px;
            border: 3px solid #e3e3e3;
            margin-top: 20px;
        }
        .questionGroup h1
        {
            padding: 10px;
            border: 1px solid #e3e3e3;
            text-decoration: underline;
            background-color: #e7e7e7;
        }
        .questionGroup h1:hover
        {
            cursor: pointer;
            background-color: Silver;
        }
    </style>
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("h1").click(function () {
                $(this).next('div').slideToggle("slow");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                Exam</h3>
        </div>
        <div class="inner-content" id="divExam" runat="server">
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
                    <asp:Label ID="lblSubjectID" runat="server" Text="Subject: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlSubjectID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjectID_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblChapterID" runat="server" Text="Chapter: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlChapterID" runat="server" ></asp:DropDownList><%--AutoPostBack="true" OnSelectedIndexChanged="ddlChapterID_SelectedIndexChanged">--%>
                    
                </dd>
                <dt>Exam Name :</dt>
                <dd>
                    <asp:DropDownList ID="ddlExamNames" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlExamNames_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
            </dl>
        </div>
        <div class="inner-content">
            <dl>
                <dt>Exam Duration :</dt>
                <dd>
                    <asp:UpdatePanel ID="upTimer" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="lblExamHour" runat="server" Text="0:00:00"></asp:Label>
                            <asp:Timer ID="clkExamTime" runat="server" Interval="1000" Enabled="false" OnTick="clkExamTime_Tick">
                            </asp:Timer>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </dd>
                <dt></dt>
                <dd>
                    <asp:CheckBox ID="cbIsRetake" runat="server" Text="Retake" Visible="false" /></dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnStart" runat="server" Text="Start Exam" OnClick="btnStart_Click" /></dd>
            </dl>
            <asp:PlaceHolder ID="phExamHeader" runat="server" Visible="false">
                <h2 class="examName">
                    <asp:Label ID="lblExamName" runat="server"></asp:Label></h2>
            </asp:PlaceHolder>
            
            <div style="width: 70%; margin: 10px auto;">
                <asp:UpdatePanel ID="upQuestions" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlQuestionNo" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnPrevious" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnNext" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:PlaceHolder ID="phComprehension" runat="server" Visible="false">
                            <h3 style="text-align: center;">
                                Read the following paragraph and answer the following Questions</h3>
                            <div style="width: 90%; padding: 10px; border: 1px solid Gray;">
                                <asp:Label ID="lblComprehensionPara" runat="server"></asp:Label>
                            </div>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="phTrueFalse" runat="server" Visible="false">
                            <dl>
                                <dt>Question No#<asp:Label ID="lblQuestionNo1" runat="server"></asp:Label></dt>
                                <dd>
                                    Select One (Either true or false)</dd>
                                <dt>Question :</dt>
                                <dd>
                                    <asp:Label ID="lblTrueFalseQuestionTitle" runat="server"></asp:Label></dd>
                                <dt>Answer :<asp:HiddenField ID="hfTrueFalse" runat="server" Value="" />
                                </dt>
                                <dd>
                                    <asp:RadioButtonList ID="rblTrueFalse" runat="server" RepeatDirection="Horizontal"
                                        Width="200">
                                        <asp:ListItem Value="True">True</asp:ListItem>
                                        <asp:ListItem Value="False">False</asp:ListItem>
                                    </asp:RadioButtonList>
                                </dd>
                            </dl>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="phDrCr" runat="server" Visible="false">
                            <dl>
                                <dt>Question No#<asp:Label ID="lblQuestionNo2" runat="server"></asp:Label></dt>
                                <dd>
                                    Select One (Either Dr or Cr)</dd>
                                <dt>Question :</dt>
                                <dd>
                                    <asp:Label ID="lblDrCrQuestionTitle" runat="server"></asp:Label></dd>
                                <dt>Answer :<asp:HiddenField ID="hfDrCr" runat="server" Value="" />
                                </dt>
                                <dd>
                                    <asp:RadioButtonList ID="rblDrCr" runat="server" RepeatDirection="Horizontal" Width="200">
                                        <asp:ListItem Value="True">Dr</asp:ListItem>
                                        <asp:ListItem Value="False">Cr</asp:ListItem>
                                    </asp:RadioButtonList>
                                </dd>
                            </dl>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="phMCQ" runat="server" Visible="false">
                            <dl>
                                <dt>Question No#<asp:Label ID="lblMCQNo" runat="server"></asp:Label></dt>
                                <dd>
                                    Choose the right answer(s)</dd>
                                <dt>Question :</dt>
                                <dd>
                                    <asp:Label ID="lblMcqTitle" runat="server"></asp:Label></dd>
                                <dt>Answer :</dt>
                                <dd>
                                    <asp:GridView ID="gvMultipleQUestionsAnswer" runat="server" AutoGenerateColumns="false"
                                        Width="100%" OnRowDataBound="gvMultipleQUestionsAnswer_RowDataBound" ShowHeader="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Multiple Question Details">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hfIsAnswer" runat="server" Value='<%#Eval("IsAnswer") %>' />
                                                    <asp:CheckBox ID="cbTrueFalse" runat="server" />
                                                    <b>( <i>
                                                        <asp:Label runat="server" ID="lblSerial" Text='<%#((GridViewRow) Container).RowIndex+1  %>'></asp:Label>
                                                    </i>)
                                                        <asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("QuestionTitle") %>'> </asp:Label></b>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </dd>
                            </dl>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="phFillInTheBlanks" runat="server" Visible="false">
                            <dl>
                                <dt>Question No#<asp:Label ID="lblFillInTheBlankNo" runat="server"></asp:Label></dt>
                                <dd>
                                    Choose the right answer(s)</dd>
                                <dt>Question :</dt>
                                <dd>
                                    <asp:Label ID="lblfillInTheBlankTitle" runat="server"></asp:Label></dd>
                                <dt>Answer :</dt>
                                <dd>
                                    <asp:GridView ID="gvFillIntheBlanksDetails" runat="server" AutoGenerateColumns="false"
                                        Width="100%" ShowHeader="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Multiple Question Details">
                                                <ItemTemplate>
                                                    <asp:Image ID="imgResult" runat="server" Visible="false" Width="16" Height="16" />
                                                    <b>( <i>
                                                        <asp:Label runat="server" ID="lblSerial" Text='<%#((GridViewRow) Container).RowIndex+1  %>'></asp:Label>
                                                    </i>) </b>
                                                    <asp:HiddenField ID="hfAnswer" runat="server" Value='<%#Eval("Answer") %>' />
                                                    <asp:TextBox runat="server" class="txt" ID="txtAnswer"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </dd>
                            </dl>
                        </asp:PlaceHolder>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:PlaceHolder ID="phActions" runat="server" Visible="false">
                    <asp:Button ID="btnPrevious" runat="server" Text="<< Previous" OnClick="btnPrevious_Click"
                        CssClass="button button-blue" />&nbsp;&nbsp;
                    <asp:Button ID="btnNext" runat="server" Text="Next >>" OnClick="btnNext_Click" CssClass="button button-blue" />&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlQuestionNo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlQuestionNo_SelectedIndexChanged">
                    </asp:DropDownList>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="phResult" runat="server" Visible="false">
                    <dl>
                        <dt>Total Question :</dt>
                        <dd>
                            <asp:Label ID="lblTotalQuestion" runat="server"></asp:Label></dd>
                        <dt>Correct Answer :</dt>
                        <dd>
                            <asp:Label ID="lblCorrectAnswer" runat="server"></asp:Label></dd>
                        <dt>Accuracy</dt>
                        <dd>
                            <asp:Label ID="lblAccuracy" runat="server"></asp:Label></dd>
                        <dt></dt>
                        <dd><asp:HyperLink ID="hlResultDetails" runat="server" Text="View Details" Target="_blank" NavigateUrl="~/Quiz/ExamResultPage.aspx"></asp:HyperLink></dd>
                    </dl>

                </asp:PlaceHolder>
            </div>
            <center>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Visible="false" CssClass="button button-orange"
                    OnClick="btnSubmit_Click" OnClientClick="return confirm('Do you really want to submit?');" />
            </center>
        </div>
    </div>
</asp:Content>
