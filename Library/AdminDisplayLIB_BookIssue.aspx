<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayLIB_BookIssue.aspx.cs" Inherits="AdminDisplayLIB_BookIssue"
    Title="List of Existing Issued Library Book" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Search</h3>
        </div>
        <div class="inner-content">
            <dl>
                <dt>
                    <asp:Label ID="lblBookID" runat="server" Text="Book: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlBookID" runat="server" class="txt medium-input">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblIssueTo" runat="server" Text="Student or Teacher ID: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtIssueTo" runat="server" Text="" class="txt medium-input">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblIssueDate" runat="server" Text="Issue Date To : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtIssueToDate" runat="server" Text="" class="txt small-input">
                    </asp:TextBox>
                    <ajaxToolkit:CalendarExtender  Format="dd MMM yyyy" ID="calIssueDate" runat="server" 
                        TargetControlID="txtIssueToDate">
                    </ajaxToolkit:CalendarExtender>
                    <%--</dd>
                <dt>--%>
                    <asp:Label ID="Label1" runat="server" Text="From : ">
                    </asp:Label>
                    <%--</dt>
                <dd>--%>
                    <asp:TextBox ID="txtIssueFromDate" runat="server" Text="" class="txt small-input">
                    </asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server" 
                        TargetControlID="txtIssueFromDate">
                    </ajaxToolkit:CalendarExtender>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnIssueSearch" class="button button-blue" runat="server" Text="Search"
                        OnClick="btnIssueSearch_Click" />
                </dd>
            </dl>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                List of Existing Issued Book</h3>
        </div>
        <div style="vertical-align: middle; font-family: Times New Roman;">
            <asp:Label ID="txtMassage" runat="server" ForeColor="#009900"></asp:Label>
        </div>
        <div class="inner-content">
            <div style="width: 100%; overflow: hidden;">
                <asp:GridView ID="gvLIB_BookIssue" runat="server" AutoGenerateColumns="false" CssClass="tabel_input">
                    <HeaderStyle CssClass="heading" />
                    <RowStyle CssClass="row" />
                    <AlternatingRowStyle CssClass="altrow" />
                    <Columns>
                        <%--<asp:TemplateField HeaderText="Book Issue">
                        <ItemTemplate>
                            <asp:Label ID="lblBookIssueID" runat="server" Text='<%#Eval("BookIssueID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                        <%-- HeaderStyle-Width="15%"--%>
                        <asp:TemplateField HeaderText="Book Name">
                            <ItemTemplate>
                                <asp:Label ID="lblBookID" runat="server" Text='<%#Eval("BookName") %>'>
 	 </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- HeaderStyle-Width="10%"--%>
                        <asp:TemplateField HeaderText="Issued To">
                            <ItemTemplate>
                                <asp:Label ID="lblIssedToID" runat="server" Text='<%#Eval("IssedToID") %>'>
 	 </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is Student">
                            <ItemTemplate>
                                <asp:Label ID="lblIsStudent" runat="server" Text='<%#Eval("IsStudent")%>'>
 	 </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--HeaderStyle-Width="15%"--%>
                        <asp:TemplateField HeaderText="Issue Date">
                            <ItemTemplate>
                                <asp:Label ID="lblIssueDate" runat="server" Text='<%#Eval("IssueDate", "{0:dd-MMM-yyyy}") %>'>
 	 </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--HeaderStyle-Width="15%"--%>
                        <asp:TemplateField HeaderText="Return Date">
                            <ItemTemplate>
                                <asp:Label ID="lblReturnDate" runat="server" Text='<%#Eval("ReturnDate", "{0:dd-MMM-yyyy}") %>'>
 	 </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Received">
                            <ItemTemplate>
                                <%--                    <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("BookIssueID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />--%>
                                <asp:LinkButton ID="lbDelete" runat="server" Font-Underline="true" ForeColor="Green"
                                    Text="Received" CommandArgument='<%#Eval("BookIssueID") %>' OnClick="lbDelete_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div id="showPageDiv" runat="server" class="paging">
                <div class="viewpageinfo">
                    <%--View 1 -10 of 13--%>
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
    </div>
</asp:Content>
