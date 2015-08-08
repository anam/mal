<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="ExamResultPage.aspx.cs" Inherits="Quiz_ExamResultPage" %>

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
        <div class="inner-content">
            <asp:GridView ID="gvQuestions" runat="server" Visible="false" AutoGenerateColumns="false">
                <RowStyle HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField HeaderText="Question Serial">
                        <ItemTemplate>
                            <%#((GridViewRow)Container).RowIndex+1%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Question Type">
                        <ItemTemplate>
                            <%#Eval("QuestionType")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Question No">
                        <ItemTemplate>
                            <%#Eval("QuestionNo")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Question Parent ID">
                        <ItemTemplate>
                            <%#Eval("ComprehensionID")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Obtained Mark">
                        <ItemTemplate>
                            <%#Eval("ObtainedMark")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OutOfMark">
                        <ItemTemplate>
                            <%#Eval("OutOfMark")%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Answer">
                        <ItemTemplate>
                            <%#Eval("Answer")%></ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:PlaceHolder ID="phTrueFalse" runat="server">
                <div class="questionGroup">
                    <h1>
                        True / False Questions ::
                    </h1>
                    <asp:GridView ID="gvQuiz_TrueFalse" Width="650" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="gridCss" OnDataBound="gvQuiz_TrueFalse_DataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Serial">
                                <ItemTemplate>
                                    <asp:Image ID="imgResult" runat="server" Width="16" Height="16" />
                                    <%#Eval("Serial")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Question Title">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuestionTitle" runat="server" Text='<%#Eval("QuestionTitle") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="True / False">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hfTrueFalseAnswer" runat="server" Value='<%#Eval("IsTrue") %>' />
                                    <asp:HiddenField ID="hfUserAnswer" runat="server" Value='<%#Eval("stAnswer") %>' />
                                    <asp:RadioButtonList ID="rblTrueFalse" Enabled="false" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>True</asp:ListItem>
                                        <asp:ListItem>False</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblCorrectAnswer" runat="server" Visible="false" ForeColor="Red" Text='<%#Eval("IsTrue") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phDrCr" runat="server">
                <div class="questionGroup">
                    <h1>
                        Dr/ Cr Questions ::
                    </h1>
                    <asp:GridView ID="gvQuiz_gvDrCr" Width="650" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="gridCss" OnDataBound="gvQuiz_gvDrCr_DataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Serial">
                                <ItemTemplate>
                                    <asp:Image ID="imgResult" runat="server" Width="16" Height="16" />
                                    <%#Eval("Serial")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Question Title">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuestionTitle" runat="server" Text='<%#Eval("QuestionTitle") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dr / Cr">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hfDrCrAnswer" runat="server" Value='<%#Eval("IsTrue") %>' />
                                    <asp:HiddenField ID="hfUserAnswer" runat="server" Value='<%#Eval("stAnswer") %>' />
                                    <asp:RadioButtonList ID="rblDrCr" runat="server" Enabled="false" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="True">Dr</asp:ListItem>
                                        <asp:ListItem Value="False">Cr</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblCorrectAnswer" runat="server" Visible="false" ForeColor="Red" Text='<%#Eval("IsTrue") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phFillInTheBlanks" runat="server">
                <div class="questionGroup">
                    <h1>
                        Fill In The Blanks Questions ::
                    </h1>
                    <asp:GridView ID="gvQuiz_FillInTheBlanks" class="gridCss" runat="server" AutoGenerateColumns="false"
                        OnRowDataBound="gvQuiz_nc_FillInTheBlanks_RowDataBound" Width="650px" CssClass="gridCss"
                        ShowHeader="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Fill In the Blanks Question">
                                <ItemTemplate>
                                    <asp:Label runat="server" Visible="false" ID="lblFillInTheBlanksID" Text='<%#Eval("FillInTheBlanksID") %>'></asp:Label>
                                    <h2 style="background-color: #E3E3E3; padding: 7px;">
                                        ( ::
                                        <asp:Label runat="server" ID="lblSerial" Text='<%#Eval("Serial")%>'></asp:Label>
                                        :: )
                                        <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question") %>'></asp:Label></h2>
                                    <br />
                                    <%--<asp:Label ID="lblFilledAnswer" runat="server" Text='<%#Eval("stAnswer") %>'></asp:Label>--%>
                                    <asp:HiddenField ID="hfFilledAnswer" runat="server" Value='<%#Eval("stAnswer") %>' />
                                    <asp:GridView ID="gvFillIntheBlanksDetails" runat="server" AutoGenerateColumns="false"
                                        OnDataBound="gvFillIntheBlanksDetails_DataBound" Width="600" BorderStyle="Solid"
                                        BorderColor="Black" BorderWidth="1px" ShowHeader="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Multiple Question Details">
                                                <ItemTemplate>
                                                    <asp:Image ID="imgResult" runat="server" Width="16" Height="16" />
                                                    <b>( <i>
                                                        <asp:Label runat="server" ID="lblSerial" Text='<%#((GridViewRow) Container).RowIndex+1  %>'></asp:Label>
                                                    </i>) </b>
                                                    <asp:HiddenField ID="hfAnswer" runat="server" Value='<%#Eval("Answer") %>' />
                                                    <asp:TextBox runat="server" class="txt" ID="txtAnswer" Enabled="false"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCorrectAnswer" runat="server" Visible="false" ForeColor="Red" Text='<%#Eval("Answer") %>'></asp:Label>
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
            <asp:PlaceHolder ID="phMCQ" runat="server">
                <div class="questionGroup">
                    <h1>
                        Multiple Choice Questions ::
                    </h1>
                    <asp:GridView ID="gvQuiz_MultipleQuestion" class="gridCss" runat="server" AutoGenerateColumns="false"
                        OnRowDataBound="gvQuiz_nc_MultipleQuestion_RowDataBound" ShowHeader="false" CssClass="gridCss"
                        Width="650px">
                        <Columns>
                            <asp:TemplateField HeaderText="Multiple Question Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblMultipleQustionID" Visible="false" runat="server" Text='<%#Eval("MultipleQustionID") %>'></asp:Label>
                                    <h2 style="background-color: #d3d3d3; padding: 7px;">
                                        <asp:Image ID="imgResult" runat="server" Width="16" Height="16" />
                                        ( ::
                                        <asp:Label runat="server" ID="lblSerial" Text='<%#Eval("Serial")%>'></asp:Label>
                                        :: )
                                        <asp:Label ID="lblMultipleQuestionName" runat="server" Text='<%#Eval("MultipleQuestionName") %>'>
                                        </asp:Label></h2>
                                    </div>
                                    <br />
                                    <%--<asp:Label ID="lblMCQ_Answers" runat="server" Text='<%#Eval("stAnswer") %>'></asp:Label>--%>
                                    <asp:HiddenField ID="hfUserAnswers" runat="server" Value='<%#Eval("stAnswer") %>' />
                                    <asp:GridView ID="gvMultipleQUestionsAnswer" runat="server" AutoGenerateColumns="false"
                                        Width="600" BorderStyle="Solid" BorderColor="Black" OnDataBound="gvMultipleQUestionsAnswer_DataBound"
                                        BorderWidth="1px" ShowHeader="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Multiple Question Details">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hfIsAnswer" runat="server" Value='<%#Eval("IsAnswer") %>' />
                                                    <asp:CheckBox ID="cbTrueFalse" runat="server" Enabled="false" />
                                                    <b>( <i>
                                                        <asp:Label runat="server" ID="lblSerial" Text='<%#((GridViewRow) Container).RowIndex+1  %>'></asp:Label>
                                                    </i>)
                                                        <asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("QuestionTitle") %>'> </asp:Label></b>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCorrectAnswer" runat="server" Visible="false" ForeColor="Red" Text='<%#Eval("IsAnswer") %>'></asp:Label>
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
            <%--<asp:PlaceHolder ID="phComprehesion" runat="server">
                <div class="questionGroup">
                    <h1>
                        Comprehension ::
                    </h1>
                    <asp:GridView ID="gvQuiz_Comprehension" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="gridCss" OnRowDataBound="gvQuiz_Comprehension_RowDataBound" ShowHeader="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Comprehension Article" HeaderStyle-Width="600px">
                                <ItemTemplate>
                                    <h3 class="comTitle">
                                        Comprehension Article</h3>
                                    <asp:Label ID="lblComprehensionID" Visible="false" runat="server" Text='<%#Eval("ComprehensionID") %>'></asp:Label>
                                    <asp:Label ID="lblComprehension" runat="server" Text='<%#Eval("Comprehension") %>'></asp:Label>
                                    <div class="questionGroup">
                                        <h1>
                                            True / False Questions ::
                                        </h1>
                                        <asp:GridView ID="gvQuiz_com_TrueFalse" Width="650" class="gridCss" runat="server"
                                            AutoGenerateColumns="false" CssClass="gridCss">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Serial">
                                                    <ItemTemplate>
                                                        <asp:Image ID="imgResult" runat="server" Visible="false" Width="16" Height="16" />
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
                                                        <asp:HiddenField ID="hfTrueFalseAnswer" runat="server" Value='<%#Eval("IsTrue") %>' />
                                                        <asp:RadioButtonList ID="rblTrueFalse" runat="server" RepeatDirection="Horizontal">
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
                                        <asp:GridView ID="gvQuiz_com_gvDrCr" Width="650" class="gridCss" runat="server" AutoGenerateColumns="false"
                                            CssClass="gridCss">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Serial">
                                                    <ItemTemplate>
                                                        <asp:Image ID="imgResult" runat="server" Visible="false" Width="16" Height="16" />
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
                                                        <asp:HiddenField ID="hfDrCrAnswer" runat="server" Value='<%#Eval("IsTrue") %>' />
                                                        <asp:RadioButtonList ID="rblDrCr" runat="server" RepeatDirection="Horizontal">
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
                                        <asp:GridView ID="gvQuiz_com_FillInTheBlanks" class="gridCss" runat="server" AutoGenerateColumns="false"
                                            ShowHeader="false" Width="650px" CssClass="gridCss" OnRowDataBound="gvQuiz_FillInTheBlanks_RowDataBound">
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
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div class="questionGroup">
                                        <h1>
                                            Multiple Choice Questions ::
                                        </h1>
                                        <asp:GridView ID="gvQuiz_com_MultipleQuestion" class="gridCss" runat="server" AutoGenerateColumns="false"
                                            ShowHeader="false" CssClass="gridCss" Width="650px" OnRowDataBound="gvQuiz_MultipleQuestion_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Multiple Question Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMultipleQustionID" Visible="false" runat="server" Text='<%#Eval("MultipleQustionID") %>'></asp:Label>
                                                        <h2 style="background-color: #d3d3d3; padding: 7px;">
                                                            <asp:Image ID="imgResult" runat="server" Visible="false" Width="16" Height="16" />
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
            </asp:PlaceHolder>--%>
        </div>
    </div>
</asp:Content>
