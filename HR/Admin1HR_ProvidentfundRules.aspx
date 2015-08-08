<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2ColumnHR.master"
    CodeFile="Admin1HR_ProvidentfundRules.aspx.cs" Inherits="Admin1HR_ProvidentfundRules"
    Title="Provident Fund Rules" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Provident Fund Rules</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblValue" runat="server" Text="Provident Fund Value : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtValue" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbValue" runat="server" FilterMode="ValidChars"
                        ValidChars="0123456789." TargetControlID="txtValue">
                    </ajaxToolkit:FilteredTextBoxExtender>
                    <label id="lblPercent">
                        For 10% value is 0.10</label>
                </dd>
                <dt></dt>
                <dd>
                    <asp:RadioButton ID="radIsGrossPortion" class="txt large-input" runat="server" Text="Is Gross Portion">
                    </asp:RadioButton>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
                </dd>
            </dl>
        </div>
        <%--<div class="inner-content">
            <div>
            </div>
            <asp:GridView ID="gvHR_ProvidentfundRules" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <asp:TemplateField HeaderText="Provident Fund Value">
                        <ItemTemplate>
                            <asp:Label ID="lblValue" runat="server" Text='<%#Eval("Value") %>'>
 	                        </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Is Gross Portion">
                        <ItemTemplate>
                            <asp:Label ID="lblIsGrossPortion" runat="server" Text='<%#Eval("IsGrossPortion") %>'>
 	                        </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit /Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("ProvidentfundRulesID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                CommandArgument='<%#Eval("ProvidentfundRulesID") %>' OnClick="lbDelete_Click"
                                AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
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
        </div>--%>
    </div>
</asp:Content>
