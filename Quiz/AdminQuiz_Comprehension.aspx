<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminQuiz_Comprehension.aspx.cs" Inherits="AdminQuiz_Comprehension"
    Title="Quiz Comprehension" EnableEventValidation="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script language="javascript" type="text/javascript">
        function ValidateFCK(source, args) {

            var fckBody = FCKeditorAPI.GetInstance('<%=fckDesc.ClientID %>');
            args.IsValid = fckBody.GetXHTML(true) != "";
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Quiz Comprehension</h3>
        </div>
        <div class="inner-form">
            <dl>
                <asp:UpdatePanel ID="upDropDowns" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlCourseID" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSubjectID" EventName="SelectedIndexChanged" />
                    </Triggers>
                    <ContentTemplate>
                        <dt>
                            <asp:Label ID="lblCourseID" runat="server" Text="Course: ">
                            </asp:Label>
                            <asp:RequiredFieldValidator ID="requiredField1" runat="server" ControlToValidate="ddlCourseID"
                                InitialValue="0" Text="*" ErrorMessage="Please Select a Course." Display="Dynamic"
                                ValidationGroup="required"></asp:RequiredFieldValidator>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlCourseID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourseID_SelectedIndexChanged">
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblSubjectID" runat="server" Text="Subject: ">
                            </asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSubjectID"
                                InitialValue="0" Text="*" ErrorMessage="Please Select a Subject." Display="Dynamic"
                                ValidationGroup="required"></asp:RequiredFieldValidator>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlSubjectID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjectID_SelectedIndexChanged">
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblChapterID" runat="server" Text="Chapter: ">
                            </asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlChapterID"
                                InitialValue="0" Text="*" ErrorMessage="Please Select a Chapter." Display="Dynamic"
                                ValidationGroup="required"></asp:RequiredFieldValidator>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlChapterID" runat="server">
                            </asp:DropDownList>
                        </dd>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <dt>
                    <asp:Label ID="lblComprehension" runat="server" Text="Comprehension: ">
                    </asp:Label>
                    <asp:CustomValidator runat="server" ErrorMessage="Please Enter a Comprehension Text."
                        ID="CustValDesc" ControlToValidate="fckDesc" Text="*" ClientValidationFunction="ValidateFCK"
                        ValidateEmptyText="true" ValidationGroup="required"></asp:CustomValidator>
                </dt>
                <dd>
                    <FCKeditorV2:FCKeditor ID="fckDesc" runat="server" BasePath="~/fckeditor/" Height="350px">
                    </FCKeditorV2:FCKeditor>
                </dd>
            </dl>
            <asp:UpdatePanel ID="upTrueFalseQuestions" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div runat="server" id="divTrueFalse" style="border: 2px solid #E6E6E6; padding: 10px;
                        margin-top: 20px;">
                        <div runat="server" id="divInsertTrueFalse">
                            <h1>
                                True False Question ::
                            </h1>
                            <table width="700px">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTrueFalseQuestionTitle" runat="server" Text="Question Description :  ">
                                        </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTrueFalseQuestionTitle" class="txt large-input" runat="server"
                                            TextMode="MultiLine" Text="">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="radTrueFalse" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem>True</asp:ListItem>
                                            <asp:ListItem>False</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAdd" class="button button-ash" runat="server" Text="Add  More"
                                            OnClick="btnTrueFalseAddMore_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div runat="server" id="divGridTrueFalse">
                            <asp:GridView ID="gvQuiz_TrueFalse" Width="700" class="gridCss" runat="server" AutoGenerateColumns="false"
                                CssClass="gridCss" OnRowDataBound="gvQuiz_TrueFalse_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Serial">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTrueFalseID" runat="server" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'>
                                            </asp:Label>
                                            <asp:HiddenField ID="hfTureFalseID" runat="server" Value='<%#Eval("TrueFalseID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Question Title">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtQuestionTitle" runat="server" class="txt large-input" Width="400"
                                                Text='<%#Eval("QuestionTitle") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="True / False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAnswer" Visible="false" runat="server" Text='<%#Eval("IsTrue") %>'>
                                            </asp:Label>
                                            <asp:RadioButtonList ID="radIsAnswer" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem>True</asp:ListItem>
                                                <asp:ListItem>False</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                                CommandArgument='<%# ((GridViewRow) Container).RowIndex%>' OnClick="lbDeleteTruFalse_Click"
                                                AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="upDrCrQuestions" runat="server">
                <ContentTemplate>
                    <div runat="server" id="divDrCr" style="border: 2px solid #E6E6E6; padding: 10px;
                        margin-top: 20px; margin-top: 20px;">
                        <div runat="server" id="divInsertDrCr">
                            <p>
                            </p>
                            <h1>
                                Dr / Cr Question ::
                            </h1>
                            <table width="700px">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Question Description :  ">
                                        </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDrCrQuestion" class="txt large-input" runat="server" TextMode="MultiLine"
                                            Text="">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="radDrCr" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem>True</asp:ListItem>
                                            <asp:ListItem>False</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" class="button button-ash" runat="server" Text="Add  More"
                                            OnClick="btnDrCrAddMore_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div runat="server" id="divGridDrCr">
                            <asp:GridView ID="gvQuiz_gvDrCr" Width="700" class="gridCss" runat="server" AutoGenerateColumns="false"
                                CssClass="gridCss" OnRowDataBound="gvQuiz_gvDrCr_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Serial">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrCrID" runat="server" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'>
                                            </asp:Label>
                                            <asp:HiddenField ID="hfDrCrID" runat="server" Value='<%#Eval("TrueFalseID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Question Title">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtQuestionTitle" runat="server" class="txt large-input" Width="400"
                                                Text='<%#Eval("QuestionTitle") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dr / Cr">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAnswer" Visible="false" runat="server" Text='<%#Eval("IsTrue") %>'>
                                            </asp:Label>
                                            <asp:RadioButtonList ID="radIsAnswer" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="True">Dr</asp:ListItem>
                                                <asp:ListItem Value="False">Cr</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                                CommandArgument='<%# ((GridViewRow) Container).RowIndex%>' OnClick="lbDeleteDrCr_Click"
                                                AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="upFillInTheBlanks" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div runat="server" id="divFillInTheBlanks" style="border: 2px solid #E6E6E6; padding: 10px;
                        margin-top: 20px;">
                        <div runat="server" id="divInsertFillInTheBlanks">
                            <h1>
                                Fill In The Blanks ::
                            </h1>
                        </div>
                        <div runat="server" id="divGridFillInTheBlanks">
                            <asp:GridView ID="gvQuiz_FillInTheBlanks" class="gridCss" runat="server" AutoGenerateColumns="false"
                                ShowHeader="false" Width="650px" CssClass="gridCss" 
                                OnRowDataBound="gvQuiz_FillInTheBlanks_RowDataBound">
                               
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <table width="85%">
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblFillInTheBlanksQuestion" Text="Question"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtFilInTheBlanksQuestion" TextMode="MultiLine" class="txt textarea"
                                                            runat="server" Text='<%#Eval("Question") %>' Height="62px" Width="522px"></asp:TextBox>
                                                        <asp:HiddenField ID="hfFillInTheBlankID" runat="server" Value='<%#Eval("FillInTheBlanksID") %>' />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Answer
                                                    </td>
                                                    <td>
                                                        <asp:GridView ID="gvQuiz_FillInTheBlanksDetails" Width="400" class="gridCss" runat="server"
                                                            AutoGenerateColumns="false" CssClass="gridCss" OnRowDataBound="gvQuiz_FillInTheBlanksQuestionDetails_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Serial">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSerial" runat="server" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'>
                                                                        </asp:Label>
                                                                        <asp:HiddenField ID="hfFillInTheBlankDtlID" runat="server" Value='<%#Eval("FillInTheBlanksDetailsID") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Answer">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtAnswer" class="txt large-input" Text='<%#Eval("Answer") %>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton runat="server" ID="btnDeleteFillInTheBlankDetails" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                                            OnClientClick="return confirm('Are you sure to delete?');" OnClick="btnDeleteFillInTheBlankDetails_Click"
                                                                            AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnMoreFillInTheBlanksDetails" class="button button-blue" runat="server"
                                                            Text="Add More" OnClick="btnMoreFillInTheBlanksDetails_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="btnDeletefillInTheBlank" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                OnClientClick="return confirm('Are you sure to delete?');" OnClick="btnDeletefillInTheBlank_Click"
                                                AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <asp:Button runat="server" ID="btnMoreFillInTheBlanksQuestion" class="button  button-ash"
                            Text="More Question" OnClick="btnMoreFillInTheBlanksQuestion_Click" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="upMultipleQuestion" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div runat="server" id="divMultipleQuestion" style="border: 2px solid #E6E6E6; padding: 10px;
                        margin-top: 20px;">
                        <h1>
                            Multiple Question ::
                        </h1>
                        <div runat="server" id="divInsertMultipleQuestion">
                            <asp:GridView ID="gvQuiz_MultipleQuestion" Width="650" class="gridCss" runat="server"
                                AutoGenerateColumns="false" ShowHeader="false" CssClass="gridCss" OnRowDataBound="gvQuiz_MultipleQuestion_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <table style="width: 85%;">
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtMultipleQuestionName" TextMode="MultiLine" class="txt textarea"
                                                            Text='<%#Eval("MultipleQuestionName") %>' runat="server" Width="578px"></asp:TextBox>
                                                        <asp:HiddenField ID="hfMultipleQuestionID" runat="server" Value='<%#Eval("MultipleQustionID") %>' />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvQuiz_MultipleQuestionDetails" Width="420" class="gridCss" runat="server"
                                                            AutoGenerateColumns="false" CssClass="gridCss" OnRowDataBound="gvQuiz_MultipleQuestionDetails_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Serial">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSerial" runat="server" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'>
                                                                        </asp:Label>
                                                                        <asp:HiddenField ID="hfMultipleQuestionDetailsID" runat="server" Value='<%#Eval("MultipleQuestionDetailsID") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Question Title">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtQuestionTitle" runat="server" class="txt large-input" Text='<%#Eval("QuestionTitle") %>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="True/False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAnswer" Visible="false" runat="server" Text='<%#Eval("IsAnswer") %>'>
                                                                        </asp:Label>
                                                                        <asp:RadioButtonList ID="radIsAnswer" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem>True</asp:ListItem>
                                                                            <asp:ListItem>False</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton runat="server" ID="btnDelete" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                                            OnClick="btnDeleteMultipleQuestionDetails_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnMoreMultipleQuestionAns" class="button button-blue" runat="server"
                                                            Text="Add More" OnClick="btnMoreMultipleQuestionAns_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="btnDeleteMultipleQuestion" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                OnClientClick="return confirm('Are you sure to delete?');" OnClick="btnDeleteMultipleQuestion_Click"
                                                AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <asp:Button runat="server" ID="btnMoreMultipleQuestions" class="button  button-ash"
                            Text="More Question" OnClick="btnMoreMultipleQuestions_Click" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <dl>
                <dt>
                    <asp:ValidationSummary ID="summary1" runat="server" ShowMessageBox="true" ShowSummary="false"
                        ValidationGroup="required" />
                <dd>
                    <asp:Button ID="btnSaveComprehention" class="button button-orange" runat="server"
                        ValidationGroup="required" CausesValidation="true" Text="Save Comprehention Data"
                        OnClick="btnSaveComprehention_Click" />
                </dd>
            </dl>
        </div>
    </div>
</asp:Content>
