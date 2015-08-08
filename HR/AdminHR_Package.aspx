<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_Package.aspx.cs" Inherits="AdminHR_Package" Title="Salary Package" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Salary Package</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblPackageName" runat="server" Text="Package Name: "> </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtPackageName" class="txt large-input" runat="server" Text=""> </asp:TextBox>
                </dd>
            </dl>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
               Salary Package Rules</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <table width="100%">
                <tr>
                    <td>
                    <asp:Label ID="lblPackageRulesID" runat="server" Visible = "false" Text=""> </asp:Label>
                        <asp:Label ID="lblPackageRulesName" runat="server" Text="Rules Name: "> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPackageRulesName" class="txt large-input" runat="server" Text=""> </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblRulesValue" runat="server" Text="Value: "> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRulesValue" class="txt large-input" runat="server" Text=""> </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblRulesOperator" runat="server" Text="Formula: "> </asp:Label>
                    </td>
                    <td>
                        <%--<asp:TextBox ID="txtRulesOperator" class="txt large-input" runat="server" Text=""> </asp:TextBox>--%>
                        <asp:DropDownList ID="ddlRulesOperator" class="txt large-input" runat="server">
                            <asp:ListItem Selected="True" Text="%" Value="%" />
                            <asp:ListItem Text="=" Value="=" />
                            <asp:ListItem Text="+" Value="+" />
                            <asp:ListItem Text="-" Value="-" />
                            <asp:ListItem Text="*" Value="*" />
                            <asp:ListItem Text="/" Value="/" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="Button1" class="button button-blue" runat="server" Text="Add More"
                            OnClick="btnAddMore_Click" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvHR_PackageRules" Width="100%" class="gridCss" runat="server"
                AutoGenerateColumns="false" CssClass="gridCss">
                <Columns>
                <asp:TemplateField HeaderText="Package Rules ID" Visible = "false">
                        <ItemTemplate>
                            <asp:Label ID="lblPackageRulesID" runat="server" Visible = "false" Text='<%#Eval("PackageRulesID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rules Name">
                        <ItemTemplate>
                            <asp:Label ID="lblPackageRulesName" runat="server" Text='<%#Eval("PackageRulesName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Value">
                        <ItemTemplate>
                            <asp:Label ID="lblRulesValue" runat="server" Text='<%#Eval("RulesValue") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Formula">
                        <ItemTemplate>
                            <asp:Label ID="lblRulesOperator" runat="server" Text='<%#Eval("RulesOperator") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                        <asp:ImageButton runat="server" ID="lbSelect" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div style="width:100%; overflow:hidden; padding-bottom:10px;">
        <div style="width:20%; margin:0 auto; overflow:hidden;">
        <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Save Package"
            OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
            </div></div>
    </div>
</asp:Content>
