<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="JournalDoubleEntry.aspx.cs" Inherits="AdminACC_Voucher" Title="Journal Double Entry" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        
    <div class="content-box">
        <div class="header">
            <h3 >
                Transaction Entry</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="Label2" runat="server" Text=" "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlDebitOrCredit" runat="server" Visible="false">
                        <asp:ListItem Value="Dr">Debit</asp:ListItem>
                        <asp:ListItem Value="Cr">Credit</asp:ListItem>
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblVoucherNo" runat="server" Text="Amount: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtAmount" class="txt small-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblAccountID" runat="server" Text="Account : ">
         </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlAccountID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblUserTypeID" runat="server" Text="User Type: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlUserTypeID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserTypeID_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="Label1" runat="server" Text="User: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlAccountingUser" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAccountingUser_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:HiddenField ID="hfStudentID" runat="server" />
                    <asp:TextBox ID="txtStudentCode" runat="server" CssClass="txt small-input" Visible="false"
                        OnTextChanged="txtStudentCode_OnTextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:TextBox ID="txtNewCompany" class="txt small-input" Visible="false" runat="server"
                        Text=""></asp:TextBox>
                    <asp:ImageButton ID="ibtnRefresh" runat="server" Visible="false" ImageUrl="~/App_Themes/CoffeyGreen/images/Refresh.gif"
                        OnClick="ibtnRefresh_Click" />
                        <asp:Button ID="btnVarify" Text="Verify ID" runat="server" class="button button-blue" OnClick="btnVarify_OnClick" />
                </dd>
                <dt>
                    <asp:Label ID="lblHeadID" runat="server" Text="Account Head: ">
    </asp:Label>
                </dt>
                <dd>
                    &nbsp;<asp:Label ID="lblHeadName" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="hfHeadID" runat="server" />
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
                    <asp:Label ID="lblUser" runat="server"></asp:Label>
                </dd>
            </dl>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                Money Entry</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="Label3" runat="server" Text=" ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlDebitOrCreditMoney" runat="server" Visible="false">
                        <asp:ListItem Value="Dr">Debit</asp:ListItem>
                        <asp:ListItem Value="Cr">Credit</asp:ListItem>
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="Label4" runat="server" Text="Amount: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtAmountMoney" class="txt small-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="Label5" runat="server" Text="Account : ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlAccountForMoney" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="Label6" runat="server" Text="User Type: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlUserTypeIDMoney" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserTypeIDMoney_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="Label7" runat="server" Text="User: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlAccountingUserMoney" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlAccountingUserMoney_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtNewCompanyMoney" class="txt small-input" Visible="false" runat="server"
                        Text="">
    </asp:TextBox>
                    <asp:TextBox ID="txtStudentCodeMoney" runat="server" CssClass="txt small-input" Visible="false"
                        OnTextChanged="txtStudentCodeMoney_OnTextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:ImageButton ID="ibtnRefreshMoney" runat="server" Visible="false" ImageUrl="~/App_Themes/CoffeyGreen/images/Refresh.gif"
                        OnClick="ibtnRefreshMoney_Click" />
                        <asp:Button ID="btnMoneyVerify" Text="Verify ID" runat="server" class="button button-blue" OnClick="btnMoneyVerify_OnClick" />
                </dd>
                <dt>
                    <asp:Label ID="Label8" runat="server" Text="Account Head: ">
    </asp:Label>
                </dt>
                <dd>
                    &nbsp;<asp:Label ID="lblHeadNameMoney" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="hfHeadIDMoney" runat="server" />
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnMoneyAdd" class="button button-blue" runat="server" Text="Add"
                        OnClick="btnMoney_Click" />
                    <asp:Button ID="btnMoneyUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
                    <asp:Label ID="lblUserMoney" runat="server"></asp:Label>
                </dd>
            </dl>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                Journal Double Entry</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvACC_Journal" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="gridCss">
                <Columns>
                    <asp:TemplateField HeaderText="Head">
                        <ItemTemplate>
                            <asp:Label ID="lblHeadID" runat="server" Text='<%#Eval("HeadName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Debit">
                        <ItemTemplate>
                            <asp:Label ID="lblDebit" runat="server" Text='<%#Eval("Debit") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Credit">
                        <ItemTemplate>
                            <asp:Label ID="lblCredit" runat="server" Text='<%#Eval("Credit") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("JournalID") %>'
                                AlternateText="Edit" OnClick="lbSelectJournal_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument='<%#Eval("JournalID") %>'
                                OnClick="lbDeleteJournal_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfJournalID" runat="server" />
            <asp:HiddenField ID="hfIsMoney" runat="server" />
            Debit
            <asp:Label ID="lblDebit" runat="server" Text="0"></asp:Label>
            <br />
            Credit
            <asp:Label ID="lblCredit" runat="server" Text="0"></asp:Label>
            <br />
            <asp:Label ID="lblJournalEntry" runat="server" Text="Debit and credit amount need to be equal"></asp:Label>
            <br />
            <asp:Button ID="btnJournalEntry" class="button button-blue" runat="server" Text="Submit"
                Visible="false" OnClick="btnJournalEntry_Click" />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
