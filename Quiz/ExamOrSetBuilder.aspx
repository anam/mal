<%@ Page Title="Quiz Builder" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="ExamOrSetBuilder.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="Quiz_AdminDisplayQuiz_QuizBuilder" %>

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
    <%--<script type="text/javascript" src="../Scripts/jquery-1.4.1.js"></script>--%>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $("h1").click(function () {
                $(this).next('div').slideToggle("slow");
            });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <div class="content-box">
        <div class="header">
            <h3>
                Quiz Builder</h3>
        </div>
        <div class="inner-content">
            <dl>
                <dt style="display:none;">Exam Name :</dt>
                <dd style="display:none;">
                    <asp:TextBox ID="txtExamName" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtExamName"
                        ErrorMessage="Exam Name required." Text="*" Display="Dynamic" ValidationGroup="requiredField"></asp:RequiredFieldValidator>
                </dd>
                <dt style="display:none;">Exam Duration :</dt>
                <dd style="display:none;">
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
                <dt>
                    <asp:Label ID="Label2" runat="server" Text="Chapter: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlChapters" runat="server">
                    </asp:DropDownList>
                    <%--<asp:DropDownList ID="ddlChapters" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlChapterID_SelectedIndexChanged">
                    </asp:DropDownList>--%>
                    <%--<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="false" OnSelectedIndexChanged="ddlChapterID_SelectedIndexChanged">
                    </asp:DropDownList>--%>
                </dd>
                <dt>
                    <asp:Label ID="Label1" runat="server" Text="Exam/Set: ">
                    </asp:Label>
                </dt>
                <dd>
                <asp:DropDownList ID="ddlExamID" runat="server" >
                    </asp:DropDownList>
                    <%--<asp:DropDownList ID="ddlExamID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlExamID_SelectedIndexChanged">
                    </asp:DropDownList>--%>
                    <%--<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="false" OnSelectedIndexChanged="ddlChapterID_SelectedIndexChanged">
                    </asp:DropDownList>--%>
                </dd>
                <dt></dt>
                <dd>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="requiredField"
                        ShowMessageBox="true" ShowSummary="false" />
                    <%--<asp:CheckBox ID="cbIsRetake" runat="server" Text="Retake" />--%></dd>
                    <dt></dt>
                <dd>
                    <asp:Button ID="btnLoadData" runat="server" Text="Load Questions" 
                        onclick="btnLoadData_Click" />
                    <asp:Button ID="btnGenerateQuestion" runat="server" Text="load" Visible="false"
                        onclick="btnGenerateQuestion_Click" />
                        <table >
                            <tr>
                                <td style="border:1px solid Black;"></td>
                                <td style="border:1px solid Black;">true/False</td>
                                <td style="border:1px solid Black;">Dr/Cr</td>
                                <td style="border:1px solid Black;">Fill in the Blanks</td>
                                <td style="border:1px solid Black;">MCQ</td>
                            </tr>
                            <tr style="display:none;">
                                <td style="border:1px solid Black;">Not in Set</td>
                                <td style="border:1px solid Black;">
                                    <asp:Label ID="lblTrueFalseNoNotInSet" runat="server" Text="0"></asp:Label>
                                </td>
                                <td style="border:1px solid Black;">
                                    <asp:Label ID="lblDrCrNoNotInSet" runat="server" Text="0"></asp:Label>
                                </td>
                                <td style="border:1px solid Black;">
                                    <asp:Label ID="lblFillIntheBlanksNoNotInSet" runat="server" Text="0"></asp:Label>
                                </td>
                                <td style="border:1px solid Black;">
                                    <asp:Label ID="lblMCQNoNotInSet" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="border:1px solid Black;">In the Set</td>
                                <td style="border:1px solid Black;">
                                    <asp:Label ID="lblTrueFalseNoInSet" runat="server" Text="0"></asp:Label>
                                </td>
                                <td style="border:1px solid Black;">
                                    <asp:Label ID="lblDrCrNoInSet" runat="server" Text="0"></asp:Label>
                                </td>
                                <td style="border:1px solid Black;">
                                    <asp:Label ID="lblFillIntheBlanksNoInSet" runat="server" Text="0"></asp:Label>
                                </td>
                                <td style="border:1px solid Black;">
                                    <asp:Label ID="lblMCQNoInSet" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                        </table>
                </dd>
            </dl>
        </div>
        <div class="inner-content" style="display:none;">
            <asp:GridView ID="gvQuestionDistribution" Visible="false" runat="server" CssClass="gridCss" AutoGenerateColumns="false"
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
            <dl >
                <dt></dt>
                <dd>
                    <asp:Button ID="btnGenerateQuiz" runat="server" Visible="true" Text="Generate Quiz" OnClick="btnGenerateQuiz_Click" />&nbsp;&nbsp;
                    
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
                        AutoGenerateColumns="false" CssClass="gridCss"><%-- OnRowDataBound="gvQuiz_nc_TrueFalse_RowDataBound">--%>
                        <Columns>
                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAdded" runat="server" />
                                    <br />
                                     <a href='AdminQuiz_TrueFalse.aspx?ID=<%#Eval("TrueFalseID") %>' target="_blank">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"/> </a>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%#Eval("IsTrue") %>' Text="True?"/>
                                    <%--<asp:Label ID="lblAnswer" Visible="false" runat="server" Text='<%#Eval("IsTrue") %>'></asp:Label>
                                    <asp:RadioButtonList ID="radIsAnswer" runat="server" RepeatDirection="Horizontal"
                                        Enabled="false">
                                        <asp:ListItem>True</asp:ListItem>
                                        <asp:ListItem>False</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:PlaceHolder>
             <asp:PlaceHolder ID="phTrueFalseSet" runat="server" Visible="false">
                <div class="questionGroup">
                    <h1>
                        True / False Questions ::(In the select Exam/Set)
                    </h1>
                    <asp:GridView ID="gvTrueFalseSet" Width="650" class="gridCss" runat="server"
                        AutoGenerateColumns="false" CssClass="gridCss"><%-- OnRowDataBound="gvQuiz_nc_TrueFalse_RowDataBound">--%>
                        <Columns>
                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                        CommandArgument='<%#Eval("TrueFalseID") %>' ToolTip="1" OnClick="lbDeleteTrueFalse_Click" AlternateText="Delete"
                                        ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                        <br />
                                     <a href='AdminQuiz_TrueFalse.aspx?ID=<%#Eval("TrueFalseID") %>' target="_blank">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"/> </a>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%#Eval("IsTrue") %>' Text="True?"/>
                                    <%--<asp:Label ID="lblAnswer" Visible="false" runat="server" Text='<%#Eval("IsTrue") %>'></asp:Label>
                                    <asp:RadioButtonList ID="radIsAnswer" runat="server" RepeatDirection="Horizontal"
                                        Enabled="false">
                                        <asp:ListItem>True</asp:ListItem>
                                        <asp:ListItem>False</asp:ListItem>
                                    </asp:RadioButtonList>--%>
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
                        CssClass="gridCss"><%-- OnRowDataBound="gvQuiz_nc_gvDrCr_RowDataBound">--%>
                        <Columns>
                        <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAdded" runat="server" />
                                    <br />
                                     <a href='AdminQuiz_TrueFalse.aspx?ID=<%#Eval("TrueFalseID") %>' target="_blank">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"/> </a>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%#Eval("IsTrue") %>' Text="Debit?"/>
                                    <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%#Eval("IsFalse") %>' Text="Credit?"/>
                                    <%--<asp:Label ID="lblAnswer" Visible="false" runat="server" Text='<%#Eval("IsTrue") %>'></asp:Label>
                                    
                                    <asp:RadioButtonList ID="radIsAnswer" runat="server" RepeatDirection="Horizontal"
                                        Enabled="false">
                                        <asp:ListItem Value="True">Dr</asp:ListItem>
                                        <asp:ListItem Value="False">Cr</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phDrCrInExam" runat="server" Visible="false">
                <div class="questionGroup">
                    <h1>
                        Dr/ Cr Questions ::(In the select Exam/Set)
                    </h1>
                    <asp:GridView ID="gvDrCrInExam" Width="650" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="gridCss"><%-- OnRowDataBound="gvQuiz_nc_gvDrCr_RowDataBound">--%>
                        <Columns>
                        <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                        CommandArgument='<%#Eval("TrueFalseID") %>' OnClick="lbDeleteTrueFalse_Click" ToolTip="2" AlternateText="Delete"
                                        ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                        <br />
                                     <a href='AdminQuiz_TrueFalse.aspx?ID=<%#Eval("TrueFalseID") %>' target="_blank">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"/> </a>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                                    <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%#Eval("IsTrue") %>' Text="Debit?"/>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%#Eval("IsFalse") %>' Text="Credit?"/>
                                    <%--<asp:Label ID="lblAnswer" Visible="false" runat="server" Text='<%#Eval("IsTrue") %>'></asp:Label>
                                    
                                    <asp:RadioButtonList ID="radIsAnswer" runat="server" RepeatDirection="Horizontal"
                                        Enabled="false">
                                        <asp:ListItem Value="True">Dr</asp:ListItem>
                                        <asp:ListItem Value="False">Cr</asp:ListItem>
                                    </asp:RadioButtonList>--%>
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
                        Width="650px" CssClass="gridCss" ><%--OnRowDataBound="gvQuiz_nc_FillInTheBlanks_RowDataBound">--%>
                        <Columns>
                        <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAdded" runat="server" />
                                    <br />
                                     <a href='AdminQuiz_FillInTheBlanks.aspx?ID=<%#Eval("FillInTheBlanksID") %>' target="_blank">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"/> </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fill In the Blanks Question">
                                <ItemTemplate>
                                    <asp:Label runat="server" Visible="false" ID="lblFillInTheBlanksID" Text='<%#Eval("FillInTheBlanksID") %>'></asp:Label>
                                    <h2 style="background-color: #E3E3E3; padding: 7px;">
                                        ( ::
                                        <asp:Label runat="server" ID="lblSerial" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'></asp:Label>
                                        :: )
                                        <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question") %>'></asp:Label></h2>
                                    <br />
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("AnswerString") %>'></asp:Label>
                                    <%--<asp:GridView ID="gvFillIntheBlanksDetails" runat="server" AutoGenerateColumns="false"
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
                                    </asp:GridView>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phFillInTheBlanksInExam" runat="server" Visible="false">
                <div class="questionGroup">
                    <h1>
                        Fill In The Blanks Questions ::(In the select Exam/Set)
                    </h1>
                    <asp:GridView ID="gvFillInTheBlanksInExam" class="gridCss" runat="server" AutoGenerateColumns="false"
                        Width="650px" CssClass="gridCss" ><%--OnRowDataBound="gvQuiz_nc_FillInTheBlanks_RowDataBound">--%>
                        <Columns>
                        <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                        CommandArgument='<%#Eval("FillInTheBlanksID") %>' OnClick="lbDeleteTrueFalse_Click" ToolTip="4" AlternateText="Delete"
                                        ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                     <br />
                                     <a href='AdminQuiz_FillInTheBlanks.aspx?ID=<%#Eval("FillInTheBlanksID") %>' target="_blank">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"/> </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fill In the Blanks Question">
                                <ItemTemplate>
                                    <asp:Label runat="server" Visible="false" ID="lblFillInTheBlanksID" Text='<%#Eval("FillInTheBlanksID") %>'></asp:Label>
                                    <h2 style="background-color: #E3E3E3; padding: 7px;">
                                        ( ::
                                        <asp:Label runat="server" ID="lblSerial" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'></asp:Label>
                                        :: )
                                        <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question") %>'></asp:Label></h2>
                                    <br />
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("AnswerString") %>'></asp:Label>
                                    <%--<asp:GridView ID="gvFillIntheBlanksDetails" runat="server" AutoGenerateColumns="false"
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
                                    </asp:GridView>--%>
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
                        ShowHeader="false" CssClass="gridCss" Width="650px"> <%--OnRowDataBound="gvQuiz_nc_MultipleQuestion_RowDataBound">--%>
                        <Columns>
                        <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAdded" runat="server" />
                                    <br />
                                     <a href='AdminQuiz_FillInTheBlanks.aspx?ID=<%#Eval("MultipleQustionID") %>' target="_blank">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"/> </a>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("AnswerString") %>'></asp:Label>
                                    <%--<asp:GridView ID="gvMultipleQUestionsAnswer" runat="server" AutoGenerateColumns="false"
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
                                    </asp:GridView>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phMCQInExam" runat="server" Visible="false">
                <div class="questionGroup">
                    <h1>
                        Multiple Choice Questions ::(In the select Exam/Set)
                    </h1>
                    <asp:GridView ID="gvMCQInExam" class="gridCss" runat="server" AutoGenerateColumns="false"
                        ShowHeader="false" CssClass="gridCss" Width="650px"><%-- OnRowDataBound="gvQuiz_nc_MultipleQuestion_RowDataBound">--%>
                        <Columns>
                        
                        <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                        CommandArgument='<%#Eval("MultipleQustionID") %>' OnClick="lbDeleteTrueFalse_Click" ToolTip="3" AlternateText="Delete"
                                        ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                         <br />
                                     <a href='AdminQuiz_MultipleQuestion.aspx?ID=<%#Eval("MultipleQustionID") %>' target="_blank">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"/> </a>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("AnswerString") %>'></asp:Label>
                                    <%--<asp:GridView ID="gvMultipleQUestionsAnswer" runat="server" AutoGenerateColumns="false"
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
                                    </asp:GridView>--%>
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
                        <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAdded" runat="server" />
                                     
                                </ItemTemplate>
                            </asp:TemplateField>
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
            <dl style="display:none;">
                <dt>&nbsp;</dt>
                <dd>
                    <asp:CheckBox ID="chkAllUnchedQuestions" runat="server" Text="All Unchecked Questions"/></dd>
                <dt>&nbsp;</dt>
                <dd><asp:Button ID="btnSave" runat="server" Visible="false" Text="Save" OnClick="btnSave_Click"  /></dd>
            </dl>
            
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
