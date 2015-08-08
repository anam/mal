<%@ Page Title="MOC Test" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="ExamTestPage.aspx.cs" Inherits="Quiz_ExamTestPage" %>

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
                MOC Test</h3>
        </div>
        <div class="inner-content">
            <dl>
                <dt>
                    <asp:Label ID="lblCourseID" runat="server" Text="Course: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlCourseID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourseID_SelectedIndexChanged">
                        <asp:ListItem Value="0">...Select Course...</asp:ListItem>
                        <asp:ListItem Value="1">math</asp:ListItem>
                        <asp:ListItem Value="2">english</asp:ListItem>
                        <asp:ListItem Value="3">science</asp:ListItem>
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblSubjectID" runat="server" Text="Subject: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlSubjectID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjectID_SelectedIndexChanged">
                        <asp:ListItem Value="0">...Select Subject...</asp:ListItem>
                        <asp:ListItem Value="1">subject  1</asp:ListItem>
                        <asp:ListItem Value="2">subject 2</asp:ListItem>
                        <asp:ListItem Value="3">subject 3</asp:ListItem>
                    </asp:DropDownList>
                </dd>
                <dt></dt>
                <dd>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="requiredField"
                        ShowMessageBox="true" ShowSummary="false" />
                    <%--<asp:CheckBox ID="cbIsRetake" runat="server" Text="Retake" />--%></dd>
            </dl>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvQuestionDistribution" runat="server" CssClass="gridCss" AutoGenerateColumns="false"
                OnInit="gvQuestionDistribution_Init" OnRowDataBound="gvQuestionDistribution_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Chapter">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlChapters" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlChapters_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hfChapterID" runat="server" Value='<%#Eval("Chapter") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="True/False">
                        <ItemTemplate>
                            <asp:TextBox ID="txtTrueFalse" runat="server" Width="50" Text='<%#Eval("TrueFalse") %>'></asp:TextBox><br />Max :
                            <asp:Label ID="lblAvailTrueFalse" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dr/Cr">
                        <ItemTemplate>
                            <asp:TextBox ID="txtDrCr" runat="server" Width="50" Text='<%#Eval("DrCr") %>'></asp:TextBox><br />Max :
                            <asp:Label ID="lblAvailDrCr" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fill In The Blanks">
                        <ItemTemplate>
                            <asp:TextBox ID="txtFillInTheBlank" Width="50" runat="server" Text='<%#Eval("FillInTheBlank") %>'></asp:TextBox><br />Max :
                            <asp:Label ID="lblAvailFillBlanks" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MCQ">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMCQ" Width="50" runat="server" Text='<%#Eval("MCQ") %>'></asp:TextBox><br />Max :
                            <asp:Label ID="lblAvailMCQ" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Comprehension">
                        <ItemTemplate>
                            <asp:TextBox ID="txtComprehension" runat="server" Width="50" Text='<%#Eval("Comprehension") %>'></asp:TextBox><br />Max :
                            <asp:Label ID="lblAvailComprehension" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
            <asp:LinkButton ID="btnAddMore" runat="server" Text="Add More" OnClick="btnAddMore_Click"></asp:LinkButton>
            <dl>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnGenerateQuiz" runat="server" Text="Generate Quiz" OnClick="btnGenerateQuiz_Click" />&nbsp;&nbsp;
                </dd>
            </dl>
        </div>
        <div class="inner-content">
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
