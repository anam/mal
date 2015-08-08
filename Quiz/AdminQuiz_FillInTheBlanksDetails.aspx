<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminQuiz_FillInTheBlanksDetails.aspx.cs" Inherits="AdminQuiz_FillInTheBlanksDetails"
    Title="Quiz_FillInTheBlanksDetails Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Insert /UpdateQuiz_FillInTheBlanksDetails</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblFillInTheBlanksID" runat="server" Text="Fill In The Blanks: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlFillInTheBlanksID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblQuestionSl" runat="server" Text="Question Sl: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtQuestionSl" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblAnswer" runat="server" Text="Answer: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtAnswer" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
                </dd>
            </dl>
        </div>
    </div>
</asp:Content>
