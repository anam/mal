<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayQuiz_Comprehension.aspx.cs" Inherits="AdminDisplayQuiz_Comprehension"
    Title="List of Existing Quiz_Comprehension" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                List of Existing Quiz_Comprehension</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvQuiz_Comprehension" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="gridCss" OnRowDataBound="gvQuiz_Comprehension_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Comprehension Article" HeaderStyle-Width="600px">
                        <ItemTemplate>
                            <asp:Label ID="lblComprehensionID" Visible="false" runat="server" Text='<%#Eval("ComprehensionID") %>'></asp:Label>
                            <asp:Label ID="lblComprehension" runat="server" Text='<%#Eval("Comprehension") %>'></asp:Label>
                            <div style="padding: 10px; border: 3px solid #e3e3e3; margin-top: 20px;">
                                <p>
                                    <h1 style="padding: 10px; border: 1px solid #e3e3e3; text-decoration: underline;
                                        background-color: #e7e7e7;">
                                        Multiple Questions ::
                                    </h1>
                                </p>
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
                                                                <b>( <i>
                                                                    <asp:Label runat="server" ID="lblSerial" Text='<%# ((GridViewRow) Container).RowIndex+1  %>'></asp:Label>
                                                                </i>)
                                                                    <asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("QuestionTitle") %>'> </asp:Label></b>
                                                                <hr />
                                                                <asp:RadioButtonList ID="radIsAnswer" Enabled="false" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem>True</asp:ListItem>
                                                                    <asp:ListItem>False</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div style="padding: 10px; border: 3px solid #e3e3e3; margin-top: 20px;">
                                <p>
                                    <h1 style="padding: 10px; border: 1px solid #e3e3e3; text-decoration: underline;">
                                        True / False Questions ::
                                    </h1>
                                </p>
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
                                                <asp:RadioButtonList ID="radIsAnswer" runat="server" RepeatDirection="Horizontal" Enabled="false">
                                                    <asp:ListItem>True</asp:ListItem>
                                                    <asp:ListItem>False</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div style="padding: 10px; border: 3px solid #e3e3e3; margin-top: 20px;">
                                <p>
                                    <h1 style="padding: 10px; border: 1px solid #e3e3e3; text-decoration: underline;
                                        background-color: #e7e7e7;">
                                        Dr/ Cr Questions ::
                                    </h1>
                                </p>
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
                                                <asp:RadioButtonList ID="radIsAnswer" runat="server" RepeatDirection="Horizontal" Enabled="false">
                                                    <asp:ListItem Value="True">Dr</asp:ListItem>
                                                    <asp:ListItem Value="False">Cr</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div style="padding: 10px; border: 3px solid #e3e3e3; margin-top: 20px;">
                                <p>
                                    <h1 style="padding: 10px; border: 1px solid #e3e3e3; text-decoration: underline;
                                        background-color: #e7e7e7;">
                                        Fill In The Blanks Questions ::
                                    </h1>
                                </p>
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
                                                                </i>)
                                                                    <asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("Answer") %>'>
                                                                    </asp:Label></b>                                                              
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <p>
                            </p>
                        </ItemTemplate>
                        <HeaderStyle Width="600px"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("ComprehensionID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" CommandArgument='<%#Eval("ComprehensionID") %>'
                                OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" OnClientClick="return confirm('Are you sure?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#3366FF" BorderColor="#FF3300" Font-Bold="True" Font-Size="Larger"
                    ForeColor="White" />
            </asp:GridView>
            <div class="paging">
                <div class="viewpageinfo">
                    Show
                </div>
                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="25" Value="25" />
                    <asp:ListItem Text="50" Value="50" />
                </asp:DropDownList>
                <div class="pagelist">
                    <asp:Repeater ID="rptPager" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
