<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="ReportPerAccount.aspx.cs" Inherits="AdminACC_Voucher" Title="ACC_Voucher Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<style type="text/css">

.TextAlign{text-align:right;}

</style>
<script type="text/javascript">
    var win = null;
    function printIt(printThis) {
        win = window.open();
        self.focus();
        win.document.open();
        win.document.write('<' + 'html' + '><' + 'head' + '><' + 'style' + '>');
        win.document.write('body, td { font-family: Verdana; font-size: 10pt;}');
        win.document.write('<' + '/' + 'style' + '><' + '/' + 'head' + '><' + 'body' + '>');
        win.document.write(printThis);
        win.document.write('<' + '/' + 'body' + '><' + '/' + 'html' + '>');
        win.document.close();
        win.print();
        win.close();
    }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpReport" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Transaction Search</h3>
                </div>
                <div class="inner-form">
                    <!-- error and information messages -->
                    <dl>
                        <dt>
                            <asp:Label ID="lblBasicAccountID" runat="server" Text="Basic Account: ">
                     </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlBasicAccountID" runat="server" OnSelectedIndexChanged="ddlBasicAccountID_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblSubBasicAccountID" runat="server" Text="Sub Basic Account: ">
                    </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlSubBasicAccountID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubBasicAccountID_SelectedIndexChanged">
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblAccountID" runat="server" Text="Account : ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlAccountID" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlAccountID_SelectedIndexChanged">
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
                            &nbsp;
                            <asp:TextBox ID="txtStudentCode" runat="server" CssClass="txt small-input" Visible="false"
                                OnTextChanged="txtStudentCode_OnTextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:TextBox ID="txtNewCompany" class="txt small-input" Visible="false" runat="server"
                                Text=""></asp:TextBox>
                            <asp:ImageButton ID="ibtnRefresh" runat="server" Visible="false" ImageUrl="~/App_Themes/CoffeyGreen/images/Refresh.gif"
                                OnClick="ibtnRefresh_Click" />
                            <asp:Button ID="btnVarify" Text="Verify ID" runat="server" class="button button-blue"
                                OnClick="btnVarify_OnClick" Visible="false"/>
                        </dd>
                        <dt>
                            <asp:Label ID="lblHeadID1" runat="server" Text="Account Head: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            &nbsp;<asp:Label ID="lblHeadName" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hfHeadID" runat="server" Value="0" />
                            <asp:Label ID="lblHeadID" runat="server" Text="Account Head: ">
                            </asp:Label>
                        </dd>
                        <dt>Date</dt>
                        <dd>
                            <asp:TextBox ID="txtDateFrom" runat="server" Width="80"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtDateFrom">
                            </ajaxToolkit:CalendarExtender>
                            &nbsp;&nbsp;To&nbsp;&nbsp;
                            <asp:TextBox ID="txtDateTo" runat="server" Width="80"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender2" runat="server" TargetControlID="txtDateTo">
                            </ajaxToolkit:CalendarExtender>
                        </dd>
                        <dt></dt>
                        <dd>
                            <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Show" OnClick="btnAdd_Click" />
                            <asp:Label ID="lblUser" runat="server"></asp:Label>
                        </dd>
                    </dl>
                </div>
            </div>
            <div class="content-box">
                 <div class="header">
                    <h3>
                       List Of Transaction</h3>
                </div>
                <div class="inner-form">
                <asp:LinkButton ID="lnkPrint" Text="Print" runat="server" OnClientClick="javascript:printIt(document.getElementById('printThis').innerHTML);"></asp:LinkButton>
                <br /> 
                <div id='printThis'>
                    <asp:Label ID="lblJournal" runat="server"></asp:Label>
                </div>
                <%--<asp:GridView ID="gvJournal" runat="server" AutoGenerateColumns="false" CssClass="tabel_input"
                    OnRowDataBound="gvJournal_RowDataBound" ShowFooter="true">
                    <HeaderStyle CssClass="heading" />
                    <RowStyle CssClass="row" />
                    <AlternatingRowStyle CssClass="altrow" />
                    <FooterStyle ForeColor="Blue" Font-Bold="true" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%#(((GridViewRow)Container).RowIndex+1).ToString("000000") %>
                                <asp:HiddenField ID="hfRowHeadID" runat="server" Value='<%#Eval("HeadID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Account Head">
                            <ItemTemplate>
                                <asp:Label ID="lblAccountHead" runat="server" Text='<%#Eval("HeadName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="lblDate" runat="server" Text='<%#Eval("AddedDate", "{0:dd MMM yyyy}") %>'></asp:Label></ItemTemplate>
                            <FooterTemplate>
                                Total :<br /><br />
                                Balance Total: </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Debit"  ItemStyle-CssClass="TextAlign" HeaderStyle-CssClass="TextAlign" FooterStyle-CssClass="TextAlign">
                            <ItemTemplate>
                                <asp:Label ID="lblDebit" runat="server" Text='<%#Eval("Debit", "{0:0.00}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalDebit" runat="server"></asp:Label>
                                <br /><br />
                                <asp:Label ID="lblBalanceDebit" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Credit" ItemStyle-CssClass="TextAlign" HeaderStyle-CssClass="TextAlign" FooterStyle-CssClass="TextAlign">
                            <ItemTemplate>
                                <asp:Label ID="lblCredit" runat="server" Text='<%#Eval("Credit", "{0:0.00}") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalCredit" runat="server"></asp:Label>
                                <br /><br />
                                <asp:Label ID="lblBalanceCredit" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="color: Red; font-size: 15px">
                            Transaction is not available.
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>--%>
            </div>
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
