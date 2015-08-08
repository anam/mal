<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayQuiz_FillInTheBlanks.aspx.cs" Inherits="AdminDisplayQuiz_FillInTheBlanks"
    Title="List of Existing Fill In The Blanks" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            
            
   
    <div class="content-box">
        <div class="header">
            <h3>
                List of Existing Fill In The Blanks</h3>
        </div>
        <div class="inner-content">
                    <dl>
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
                            <asp:DropDownList ID="ddlChapterID" runat="server" AutoPostBack="true"
                                onselectedindexchanged="ddlChapterID_SelectedIndexChanged">
                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlChapterID"
                                InitialValue="0" Text="*" ErrorMessage="Please Select a Chapter." Display="Dynamic"
                                ValidationGroup="required"></asp:RequiredFieldValidator>
                        </dd>
                        <dt>
                            Answer Text:
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtAnswerText" runat="server" AutoPostBack="True" 
                                ontextchanged="txtAnswerText_TextChanged"></asp:TextBox>
                            <asp:Button ID="Button1" runat="server" Text="Search" />
                        </dd>
           </dl>

            <asp:GridView ID="gvQuiz_FillInTheBlanks" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="gridCss" onrowdatabound="gvQuiz_FillInTheBlanks_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Fill In the Blanks Question">
                        <ItemTemplate>
                          <asp:Label runat="server" Visible="false" ID="lblFillInTheBlanksID" Text='<%#Eval("FillInTheBlanksID") %>'></asp:Label>
                            <h2 style="background-color: #E3E3E3; padding: 7px;">
                                ( ::
                                <asp:Label runat="server" ID="lblSerial" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'></asp:Label>
                                :: )
                                <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question") %>'></asp:Label></h2><br />
                            <asp:GridView ID="gvFillIntheBlanksDetails" runat="server" AutoGenerateColumns="false"
                                BorderStyle="Solid" BorderColor="Black" 
                                BorderWidth="1px" ShowHeader="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Multiple Question Details">
                                        <ItemTemplate>
                                     
                                            <b>
                                              ( <i><asp:Label runat="server" ID="lblSerial" Text='<%#((GridViewRow) Container).RowIndex+1  %>'></asp:Label> </i> ) 
                                                <asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("Answer") %>'>
                                                </asp:Label></b>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("FillInTheBlanksID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("FillInTheBlanksID") %>' OnClientClick="return confirm('Are you sure to delete?');"
                                OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
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

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
