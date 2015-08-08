<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminQuiz_TrueFalse.aspx.cs" Inherits="AdminQuiz_TrueFalse" Title="True/False Quiz" %>

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
                True/False Quiz<%--<asp:Label ID="lblUserID" runat="server"></asp:Label>--%></h3>
        </div>
        <div class="inner-form">
            <asp:UpdatePanel ID="upTrueFalseEntry" runat="server" ChildrenAsTriggers="false"
                UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlCourseID" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddlSubjectID" EventName="SelectedIndexChanged" />
                </Triggers>
                <ContentTemplate>
                    <dl>
                        <dt>
                            <asp:Label ID="lblIsDrCr" runat="server" Text="True/False Or Dr/Cr">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:RadioButtonList ID="radIsDrCr" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="False" Selected="True">True or False</asp:ListItem>
                                <asp:ListItem Value="True">Dr / Cr</asp:ListItem>
                            </asp:RadioButtonList>
                        </dd>
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
                    </dl>
                </ContentTemplate>
            </asp:UpdatePanel>
            <dl>
                <dt>
                    <asp:Label ID="lblQuestionTitle" runat="server" Text="Question Description :  ">
                    </asp:Label>
                    <asp:CustomValidator runat="server" ErrorMessage="Please Enter a question title."
                        ID="CustValDesc" ControlToValidate="fckDesc" Text="*" ClientValidationFunction="ValidateFCK"
                        ValidateEmptyText="true" ValidationGroup="required"></asp:CustomValidator>
                </dt>
                <dd>
                    <FCKeditorV2:FCKeditor ID="fckDesc" runat="server" BasePath="~/fckeditor/" Height="350px">
                    </FCKeditorV2:FCKeditor>
                </dd>
                <dt>&nbsp; </dt>
                <dd>
                    <asp:RadioButtonList ID="radIsTrue" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>True</asp:ListItem>
                        <asp:ListItem>False</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="radIsTrue"
                        InitialValue="" Text="*" ErrorMessage="Please Select True or False." Display="Dynamic"
                        ValidationGroup="required"></asp:RequiredFieldValidator>
                </dd>
                <dt>
                    <asp:ValidationSummary ID="summary1" runat="server" ShowMessageBox="true" ShowSummary="false"
                        ValidationGroup="required" />
                </dt><dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click"
                        ValidationGroup="required" CausesValidation="true" />
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
                </dd>
            </dl>
        </div>
    </div>
</asp:Content>
