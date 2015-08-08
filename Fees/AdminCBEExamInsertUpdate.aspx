<%@ Page Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="AdminCBEExamInsertUpdate.aspx.cs" Inherits="AdminCBEExamInsertUpdate"
    Title="CBEExam Insert/Update By Admin" %>

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
    <asp:UpdatePanel ID="upCBEExam" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        CBE Exam Entry Form</h3>
                </div>
                <div class="inner-form">
                    <div style="width: 100%; float: left; margin-bottom: 50px">
                        <div style="width: 30%; float: left;">
                            <table width="100%">
                                <tr>
                                    <td>
                                        Are you CUC Student?
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdListCuc" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                            OnSelectedIndexChanged="rdListCuc_OnSelectedIndexChanged">
                                            <asp:ListItem Value="0">Yes &nbsp;</asp:ListItem>
                                            <asp:ListItem Value="1" Selected="True">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="width: 40%; float: left">
                            <asp:Panel ID="pnCucStudent" runat="server" Visible="false">
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            Student Code:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStudentCode" runat="server" CssClass="txtCss" Width="100px"></asp:TextBox>
                                            <asp:Button ID="btnOK" runat="server" Text="Load Information" CssClass="button button-blue" OnClick="btnOk_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </div>
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="lblCandidateName" runat="server" Text="Candidate Name: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCandidateName" runat="server" Text="" CssClass="txtCss">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDOB" runat="server" Text="DOB: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDOB" runat="server" Text="" CssClass="txtCss">
                    </asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="afcalDOB" runat="server" TargetControlID="txtDOB"
                                    Format="dd MMM, yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblGender" runat="server" Text="Gender: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="txtCss">
                                    <asp:ListItem Value="0">Male</asp:ListItem>
                                    <asp:ListItem Value="1">Female</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td style="width:150px; ">
                                Is Register With ACCA:
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbList" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                    OnSelectedIndexChanged="rbList_OnSelectedIndexChanged">
                                    <asp:ListItem Value="0" Selected="True">True</asp:ListItem>
                                    <asp:ListItem Value="1">False</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <asp:Panel ID="pnReg" runat="server" >
                            <tr>
                                <td>
                                    <asp:Label ID="lblRegiNo" runat="server" Text="ACCA Registration No: ">
                    </asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRegiNo" runat="server" Text="" CssClass="txtCss">
                    </asp:TextBox>
                                </td>
                            </tr>
                        </asp:Panel>
                        <tr>
                            <td>
                                <asp:Label ID="lblInstituteName" runat="server" Text="InstituteName: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtInstituteName" runat="server" Text="" CssClass="txtCss">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTel" runat="server" Text="Tel: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTel" runat="server" Text="" CssClass="txtCss">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMobile" runat="server" Text="Mobile: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobile" runat="server" Text="" CssClass="txtCss">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblEmail" runat="server" Text="Email: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" Text="" CssClass="txtCss">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFeesDescription" runat="server" Text="FeesDescription: ">
                    </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFeesDescription" runat="server" Text="" CssClass="txtCss">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-top: 50px; padding-bottom: 30px">
                                <table width="100%">
                                    <tr>
                                        <td colspan="6">
                                            <div class="header">
                                                <h3>
                                                    Subject Details</h3>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 7px; padding-top: 10px">
                                            Course Title:
                                        </td>
                                        <td style="padding-left: 7px; padding-top: 10px">
                                            <asp:TextBox ID="txtSubjectTitle" runat="server" CssClass="txtCss" Width="100px"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 7px; padding-top: 10px">
                                            Subject Name
                                        </td>
                                        <td style="padding-left: 7px; padding-top: 10px">
                                            <asp:TextBox ID="txtSubjectCode" runat="server" CssClass="txtCss" Width="100px"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 7px; padding-top: 10px">
                                            Tax / Paper Variant :
                                        </td>
                                        <td style="padding-left: 7px; padding-top: 10px">
                                            <asp:DropDownList ID="ddlTPV" runat="server" CssClass="txtCss" Width="100px">
                                                <asp:ListItem Value="0">INT</asp:ListItem>
                                                <asp:ListItem Value="1">UK</asp:ListItem>
                                                <asp:ListItem Value="2">NONE</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 7px; padding-top: 10px">
                                            Fees :
                                        </td>
                                        <td style="padding-left: 7px; padding-top: 10px">
                                            <asp:TextBox ID="txtFees" runat="server" CssClass="txtCss" Width="100px"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="fte" runat="server" TargetControlID="txtFees"
                                                FilterType="Numbers">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td style="padding-left: 7px; padding-top: 10px">
                                            Exam Date :
                                        </td>
                                        <td style="padding-left: 7px; padding-top: 10px">
                                            <asp:TextBox ID="txtExamDate" runat="server" CssClass="txtCss" Width="100px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="ajcal" runat="server" TargetControlID="txtExamDate"
                                                Format="dd MMM, yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td style="padding-left: 7px; padding-top: 10px;" colspan="2">
                                            <asp:Button ID="btnAddSubjectDetaisl" Text="Add" runat="server" CssClass="button button-blue"
                                                OnClick="btnAddSubjectDetaisl_OnClick" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <asp:GridView ID="gvCBEExamSubject" runat="server" AutoGenerateColumns="false" CssClass="tabel_input"
                                                OnRowDataBound="gvCBEExamSubject_OnRowDataBound">
                                                <HeaderStyle CssClass="heading" />
                                                <RowStyle CssClass="row" />
                                                <AlternatingRowStyle CssClass="altrow" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Course Title">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSubjectTitle" runat="server" Text='<%#Eval("SubjectTitle") %>'>
                                                        </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Subject Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCode" runat="server" Text='<%#Eval("SubjectCode") %>'>
                                                        </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fees">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFees" runat="server" Text='<%#Eval("Fees") %>'>
                                                        </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tax / Paper Variant">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTax" runat="server" Text='<%#Eval("TaxOrPaperVariant") %>'>
                                                        </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Exam Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblExamDate" runat="server" Text='<%#Eval("ExamDate","{0:dd MMM,yyyy}") %>'>
                                                        </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ID="lbDeleteExamSubject" CommandArgument='<%#Eval("CBEExamSubjectID") %>'
                                                                OnClick="lbDeleteExamSubject_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnAdd" runat="server" Text="Save" CssClass="button button-blue"
                                    OnClick="btnAdd_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button button-blue"
                                    OnClick="btnUpdate_Click" Visible="false" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="button button-blue"
                                    OnClick="btnClear_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
