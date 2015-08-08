<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminQuiz_FillInTheBlanks.aspx.cs" Inherits="AdminQuiz_FillInTheBlanks"
    Title="Fill In The Blanks" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
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
                Fill In The Blanks</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <asp:UpdatePanel ID="upDropDowns" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlCourseID" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSubjectID" EventName="SelectedIndexChanged" />
                        <asp:PostBackTrigger ControlID="txtAnswer" />
                    </Triggers>
                    <ContentTemplate>
                        <dt>
                            <asp:Label ID="lblCourseID" runat="server" Text="Course: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlCourseID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourseID_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="requiredField1" runat="server" ControlToValidate="ddlCourseID"
                                InitialValue="0" Text="*" ErrorMessage="Please Select a Course." Display="Dynamic"
                                ValidationGroup="required"></asp:RequiredFieldValidator>
                        </dd>
                        <dt>
                            <asp:Label ID="lblSubjectID" runat="server" Text="Subject: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlSubjectID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjectID_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSubjectID"
                                InitialValue="0" Text="*" ErrorMessage="Please Select a Subject." Display="Dynamic"
                                ValidationGroup="required"></asp:RequiredFieldValidator>
                        </dd>
                        <dt>
                            <asp:Label ID="lblChapterID" runat="server" Text="Chapter: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlChapterID" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlChapterID"
                                InitialValue="0" Text="*" ErrorMessage="Please Select a Chapter." Display="Dynamic"
                                ValidationGroup="required"></asp:RequiredFieldValidator>
                        </dd>
                        <dt>
                            <asp:Label ID="lblExamOrSet" runat="server" Text="Exam/Set: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlExamID" runat="server">
                            </asp:DropDownList>
                            <asp:GridView ID="gvExam" runat="server" AutoGenerateColumns="true">
                            </asp:GridView>
                        </dd>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <dt>
                    <asp:Label ID="lblQuestion" runat="server" Text="Question: ">
                    </asp:Label>
                    <asp:CustomValidator runat="server" ErrorMessage="Please Enter a question title."
                        ID="CustValDesc" ControlToValidate="fckDesc" Text="*" ClientValidationFunction="ValidateFCK"
                        ValidateEmptyText="true" ValidationGroup="required"></asp:CustomValidator>
                </dt>
                <dd>
                    <%--<asp:TextBox ID="txtQuestion" TextMode="MultiLine" class="txt textarea" runat="server"
                        Text="" Height="62px" Width="522px"></asp:TextBox>--%>
                    <FCKeditorV2:FCKeditor ID="fckDesc" runat="server" BasePath="~/fckeditor/" Height="350px">
                    </FCKeditorV2:FCKeditor>
                </dd>
            </dl>
            <div style="width: 750px; margin: 0 auto;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table width="700px">
                            <tr>
                                <td>
                                    Fill In the blanks Answer
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAnswer" class="txt large-input" runat="server">
                                    </asp:TextBox>
                                    <br />
                                    N.B: ( Type in Small Latter .)
                                </td>
                                <td>
                                    <asp:Button ID="btnAddMore" class="button button-blue" runat="server" Text="Add More"
                                        OnClick="btnAddMore_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <asp:UpdatePanel ID="upFillInTheBlanks" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAddMore" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <asp:GridView ID="gvQuiz_FillInTheBlanksQuestionDetails" Width="750" class="gridCss"
                        runat="server" AutoGenerateColumns="false" CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Serial">
                                <ItemTemplate>
                                    <asp:Label ID="lblSerial" runat="server" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'></asp:Label>
                                    <asp:HiddenField ID="hfFitbDtlID" runat="server" Value='<%#Eval("FillInTheBlanksDetailsID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Answer">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="txtAnswer" class="txt large-input" Text='<%#Eval("Answer") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="lbDelete_Click"
                                        AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSave" class="button button-blue" runat="server" Text="Save" OnClick="btnSave_Click"
                CausesValidation="true" ValidationGroup="required" />
                <div ID="btnUpdate" runat="server" >
                    <asp:Button ID="btnUpdateButton" class="button button-blue" runat="server" Text="Update"
                    ValidationGroup="required" CausesValidation="true" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete"  OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                        class="button button-blue" onclick="btnDelete_Click" />
                    <asp:DropDownList ID="ddlAllExam" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="btnAssignQuestionToExam" runat="server" 
                        Text="Assign Question To Exam"  OnClientClick="return confirm('Are You Sure, You Want To assign this question to the selected Set?')"
                        class="button button-blue" onclick="btnAssignQuestionToExam_Click"  />
                </div>
            <asp:ValidationSummary ID="summary1" runat="server" ShowMessageBox="true" ShowSummary="false"
                ValidationGroup="required" />
        </div>
    </div>
</asp:Content>
