<%@ Page Title="Quiz Builder" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="AdminDisplayQuiz_QuizBuilder.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="Quiz_AdminDisplayQuiz_QuizBuilder" %>

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
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.js"></script>
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
                Quiz Builder</h3>
        </div>
        <div class="inner-content">
            <dl>
                <dt>Exam Name :</dt>
                <dd>
                    <asp:TextBox ID="txtExamName" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtExamName"
                        ErrorMessage="Exam Name required." Text="*" Display="Dynamic" ValidationGroup="requiredField"></asp:RequiredFieldValidator>
                </dd>
                <dt>Exam Duration :</dt>
                <dd>
                    Hour :&nbsp;<asp:DropDownList ID="ddlExamHour" runat="server" Width="50">
                    </asp:DropDownList>
                    &nbsp;:&nbsp;
                    <asp:DropDownList ID="ddlExamMin" runat="server" Width="50">
                    </asp:DropDownList>
                </dd>
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
                            <asp:DropDownList ID="ddlChapters" runat="server">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hfChapterID" runat="server" Value='<%#Eval("Chapter") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="True/False">
                        <ItemTemplate>
                            <asp:TextBox ID="txtTrueFalse" runat="server" Width="50" Text='<%#Eval("TrueFalse") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dr/Cr">
                        <ItemTemplate>
                            <asp:TextBox ID="txtDrCr" runat="server" Width="50" Text='<%#Eval("DrCr") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fill In The Blanks">
                        <ItemTemplate>
                            <asp:TextBox ID="txtFillInTheBlank" Width="50" runat="server" Text='<%#Eval("FillInTheBlank") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MCQ">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMCQ" Width="50" runat="server" Text='<%#Eval("MCQ") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Comprehension">
                        <ItemTemplate>
                            <asp:TextBox ID="txtComprehension" runat="server" Width="50" Text='<%#Eval("Comprehension") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
            <asp:LinkButton ID="btnAddMore" runat="server" Text="Add More" OnClick="btnAddMore_Click"></asp:LinkButton>
            <dl>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnGenerateQuiz" runat="server" Text="Generate Quiz" OnClick="btnGenerateQuiz_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CausesValidation="true"
                        ValidationGroup="requiredField" />
                </dd>
            </dl>
        </div>
        <div class="inner-content">
            <asp:PlaceHolder ID="phTrueFalse" runat="server" Visible="false">
                <div class="questionGroup">
                    <h1>
                        True / False Questions ::
                    </h1>
                    <asp:GridView ID="gvQuiz_nc_TrueFalse" Width="650" class="gridCss" runat="server"
                        AutoGenerateColumns="false" CssClass="gridCss" OnRowDataBound="gvQuiz_nc_TrueFalse_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Serial">
                                <ItemTemplate>
                                    <asp:Label ID="lblTrueFalseID" runat="server" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'></asp:Label>
                                    <asp:HiddenField ID="hfTrueFalseID" runat="server" Value='<%#Eval("TrueFalseID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Question Title">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuestionTitle" runat="server" Text='<%#Eval("QuestionTitle") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="True / False">
                                <ItemTemplate>
                                    <asp:Label ID="lblAnswer" Visible="false" runat="server" Text='<%#Eval("IsTrue") %>'></asp:Label>
                                    <asp:RadioButtonList ID="radIsAnswer" runat="server" RepeatDirection="Horizontal"
                                        Enabled="false">
                                        <asp:ListItem>True</asp:ListItem>
                                        <asp:ListItem>False</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phDrCr" runat="server" Visible="false">
                <div class="questionGroup">
                    <h1>
                        Dr/ Cr Questions ::
                    </h1>
                    <asp:GridView ID="gvQuiz_nc_gvDrCr" Width="650" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="gridCss" OnRowDataBound="gvQuiz_nc_gvDrCr_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Serial">
                                <ItemTemplate>
                                    <asp:Label ID="lblTrueFalseID" runat="server" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'></asp:Label>
                                    <asp:HiddenField ID="hfDrCrID" runat="server" Value='<%#Eval("TrueFalseID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Question Title">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuestionTitle" runat="server" Text='<%#Eval("QuestionTitle") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dr / Cr">
                                <ItemTemplate>
                                    <asp:Label ID="lblAnswer" Visible="false" runat="server" Text='<%#Eval("IsTrue") %>'></asp:Label>
                                    <asp:RadioButtonList ID="radIsAnswer" runat="server" RepeatDirection="Horizontal"
                                        Enabled="false">
                                        <asp:ListItem Value="True">Dr</asp:ListItem>
                                        <asp:ListItem Value="False">Cr</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phFillInTheBlanks" runat="server" Visible="false">
                <div class="questionGroup">
                    <h1>
                        Fill In The Blanks Questions ::
                    </h1>
                    <asp:GridView ID="gvQuiz_nc_FillInTheBlanks" class="gridCss" runat="server" AutoGenerateColumns="false"
                        Width="650px" CssClass="gridCss" OnRowDataBound="gvQuiz_nc_FillInTheBlanks_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Fill In the Blanks Question">
                                <ItemTemplate>
                                    <asp:Label runat="server" Visible="false" ID="lblFillInTheBlanksID" Text='<%#Eval("FillInTheBlanksID") %>'></asp:Label>
                                    <h2 style="background-color: #E3E3E3; padding: 7px;">
                                        ( ::
                                        <asp:Label runat="server" ID="lblSerial" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'></asp:Label>
                                        :: )
                                        <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question") %>'></asp:Label></h2>
                                    <br />
                                    <asp:GridView ID="gvFillIntheBlanksDetails" runat="server" AutoGenerateColumns="false"
                                        Width="600" BorderStyle="Solid" BorderColor="Black" BorderWidth="1px" ShowHeader="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Multiple Question Details">
                                                <ItemTemplate>
                                                    <b>( <i>
                                                        <asp:Label runat="server" ID="lblSerial" Text='<%#((GridViewRow) Container).RowIndex+1  %>'></asp:Label>
                                                    </i>)</b>
                                                    <asp:TextBox runat="server" class="txt" ID="txtAnswer" Enabled="false"
                                                        Text='<%#Eval("Answer") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phMCQ" runat="server" Visible="false">
                <div class="questionGroup">
                    <h1>
                        Multiple Choice Questions ::
                    </h1>
                    <asp:GridView ID="gvQuiz_nc_MultipleQuestion" class="gridCss" runat="server" AutoGenerateColumns="false"
                        ShowHeader="false" CssClass="gridCss" Width="650px" OnRowDataBound="gvQuiz_nc_MultipleQuestion_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Multiple Question Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblMultipleQustionID" Visible="false" runat="server" Text='<%#Eval("MultipleQustionID") %>'></asp:Label>
                                    <h2 style="background-color: #d3d3d3; padding: 7px;">
                                        ( ::
                                        <asp:Label runat="server" ID="lblSerial" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'></asp:Label>
                                        :: )
                                        <asp:Label ID="lblMultipleQuestionName" runat="server" Text='<%#Eval("MultipleQuestionName") %>'>
                                        </asp:Label></h2>
                                    </div>
                                    <br />
                                    <asp:GridView ID="gvMultipleQUestionsAnswer" runat="server" AutoGenerateColumns="false"
                                        Width="600" BorderStyle="Solid" BorderColor="Black" OnRowDataBound="gvMultipleQUestionsAnswer_RowDataBound"
                                        BorderWidth="1px" ShowHeader="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Multiple Question Details">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAnswerValue" Visible="false" runat="server" Text='<%#Eval("IsAnswer") %>'>
                                                    </asp:Label>
                                                    <asp:CheckBox ID="cbTrueFalse" runat="server" Enabled="false" Checked='<%#Eval("IsAnswer") %>' />
                                                    <b>( <i>
                                                        <asp:Label runat="server" ID="lblSerial" Text='<%# ((GridViewRow) Container).RowIndex+1  %>'></asp:Label>
                                                    </i>)
                                                        <asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("QuestionTitle") %>'> </asp:Label></b>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phComprehension" runat="server" Visible="false">
                <div class="questionGroup">
                    <h1>
                        Comprehension ::
                    </h1>
                    <asp:GridView ID="gvQuiz_Comprehension" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="gridCss" OnRowDataBound="gvQuiz_Comprehension_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Comprehension Article" HeaderStyle-Width="600px">
                                <ItemTemplate>
                                    <asp:Label ID="lblComprehensionID" Visible="false" runat="server" Text='<%#Eval("ComprehensionID") %>'></asp:Label>
                                    <asp:Label ID="lblComprehension" runat="server" Text='<%#Eval("Comprehension") %>'></asp:Label>
                                    <div class="questionGroup">
                                        <h1>
                                            True / False Questions ::
                                        </h1>
                                        <asp:GridView ID="gvQuiz_TrueFalse" Width="650" class="gridCss" runat="server" AutoGenerateColumns="false"
                                            CssClass="gridCss" OnRowDataBound="gvQuiz_TrueFalse_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Serial">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTrueFalseID" runat="server" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Question Title">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuestionTitle" runat="server" Text='<%#Eval("QuestionTitle") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="True / False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAnswer" Visible="false" runat="server" Text='<%#Eval("IsTrue") %>'></asp:Label>
                                                        <asp:RadioButtonList ID="radIsAnswer" runat="server" RepeatDirection="Horizontal"
                                                            Enabled="false">
                                                            <asp:ListItem>True</asp:ListItem>
                                                            <asp:ListItem>False</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div class="questionGroup">
                                        <h1>
                                            Dr/ Cr Questions ::
                                        </h1>
                                        <asp:GridView ID="gvQuiz_gvDrCr" Width="650" class="gridCss" runat="server" AutoGenerateColumns="false"
                                            CssClass="gridCss" OnRowDataBound="gvQuiz_gvDrCr_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Serial">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTrueFalseID" runat="server" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Question Title">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuestionTitle" runat="server" Text='<%#Eval("QuestionTitle") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Dr / Cr">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAnswer" Visible="false" runat="server" Text='<%#Eval("IsTrue") %>'></asp:Label>
                                                        <asp:RadioButtonList ID="radIsAnswer" runat="server" RepeatDirection="Horizontal"
                                                            Enabled="false">
                                                            <asp:ListItem Value="True">Dr</asp:ListItem>
                                                            <asp:ListItem Value="False">Cr</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div class="questionGroup">
                                        <h1>
                                            Fill In The Blanks Questions ::
                                        </h1>
                                        <asp:GridView ID="gvQuiz_FillInTheBlanks" class="gridCss" runat="server" AutoGenerateColumns="false"
                                            Width="650px" CssClass="gridCss" OnRowDataBound="gvQuiz_FillInTheBlanks_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Fill In the Blanks Question">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Visible="false" ID="lblFillInTheBlanksID" Text='<%#Eval("FillInTheBlanksID") %>'></asp:Label>
                                                        <h2 style="background-color: #E3E3E3; padding: 7px;">
                                                            ( ::
                                                            <asp:Label runat="server" ID="lblSerial" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'></asp:Label>
                                                            :: )
                                                            <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question") %>'></asp:Label></h2>
                                                        <br />
                                                        <asp:GridView ID="gvFillIntheBlanksDetails" runat="server" AutoGenerateColumns="false"
                                                            Width="600" BorderStyle="Solid" BorderColor="Black" BorderWidth="1px" ShowHeader="False">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Multiple Question Details">
                                                                    <ItemTemplate>
                                                                        <b>( <i>
                                                                            <asp:Label runat="server" ID="lblSerial" Text='<%#((GridViewRow) Container).RowIndex+1  %>'></asp:Label>
                                                                        </i>) </b>
                                                                        <asp:TextBox runat="server" class="txt large-input" ID="txtAnswer" Enabled="false"
                                                                            Text='<%#Eval("Answer") %>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div class="questionGroup">
                                        <h1>
                                            Multiple Choice Questions ::
                                        </h1>
                                        <asp:GridView ID="gvQuiz_MultipleQuestion" class="gridCss" runat="server" AutoGenerateColumns="false"
                                            ShowHeader="false" CssClass="gridCss" Width="650px" OnRowDataBound="gvQuiz_MultipleQuestion_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Multiple Question Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMultipleQustionID" Visible="false" runat="server" Text='<%#Eval("MultipleQustionID") %>'></asp:Label>
                                                        <h2 style="background-color: #d3d3d3; padding: 7px;">
                                                            ( ::
                                                            <asp:Label runat="server" ID="lblSerial" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'></asp:Label>
                                                            :: )
                                                            <asp:Label ID="lblMultipleQuestionName" runat="server" Text='<%#Eval("MultipleQuestionName") %>'>
                                                            </asp:Label></h2>
                                                        </div>
                                                        <br />
                                                        <asp:GridView ID="gvMultipleQUestionsAnswer" runat="server" AutoGenerateColumns="false"
                                                            Width="600" BorderStyle="Solid" BorderColor="Black" OnRowDataBound="gvMultipleQUestionsAnswer_RowDataBound"
                                                            BorderWidth="1px" ShowHeader="False">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Multiple Question Details">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAnswerValue" Visible="false" runat="server" Text='<%#Eval("IsAnswer") %>'>
                                                                        </asp:Label>
                                                                        <asp:CheckBox ID="cbTrueFalse" runat="server" Enabled="false" Checked='<%#Eval("IsAnswer") %>' />
                                                                        <b>( <i>
                                                                            <asp:Label runat="server" ID="lblSerial" Text='<%#((GridViewRow) Container).RowIndex+1  %>'></asp:Label>
                                                                        </i>)
                                                                            <asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("QuestionTitle") %>'> </asp:Label></b>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle Width="600px"></HeaderStyle>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#3366FF" BorderColor="#FF3300" Font-Bold="True" Font-Size="Larger"
                            ForeColor="White" />
                    </asp:GridView>
                </div>
            </asp:PlaceHolder>
        </div>
    </div>
</asp:Content>
