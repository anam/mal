<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminUSER_RoleWiseAccess.aspx.cs" Inherits="AdminUSER_RoleWiseAccess"
    Title="USER_RoleWiseAccess Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box" style="overflow: hidden;">
        <div class="header">
            <h3>
                RoleWise Page Access</h3>
        </div>
        <div style="width: 25%; float: left; margin: 1%;">
            <center>
                Available Modules</center>
            <asp:ListBox ID="lbxModules" runat="server" Width="180" Height="200" Style="padding: 5px;"
                AutoPostBack="true" OnSelectedIndexChanged="lbxModules_SelectedIndexChanged">
            </asp:ListBox>
        </div>
        <div style="width: 70%; float: left; margin: 1%;">
            <dl>
                <dt>
                    <asp:Label ID="lblRoleID" runat="server" Text="Role: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlRoleID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRoleID_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
            </dl>
            <%--<asp:UpdatePanel ID="upPageAccess" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlRoleID" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="lbxModules" EventName="SelectedIndexChanged" />
                    <asp:PostBackTrigger ControlID="btnSubmit" />
                </Triggers>
                <ContentTemplate>--%>
                    <asp:GridView ID="gvPagesAndAccess" runat="server" CssClass="tabel_input" AutoGenerateColumns="false"
                        Width="100%" GridLines="None" OnDataBound="gvPagesAndAccess_DataBound">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <center>
                                        <asp:CheckBox ID="cbAssigned" runat="server" />
                                        <asp:HiddenField ID="hfPageID" runat="server" Value='<%#Eval("PageID") %>' />
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Page Name" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="65%">
                                <ItemTemplate>
                                    <asp:Label ID="lblPageTitle" runat="server" Text='<%#Eval("PageTitle") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="30%" HeaderText="Operations">
                                <ItemTemplate>
                                    <asp:CheckBoxList ID="cblOperations" runat="server">
                                    </asp:CheckBoxList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <center>
                        <asp:Button ID="btnSubmit" class="button button-blue" runat="server" Text="Submit"
                            OnClick="btnSubmit_Click" /></center>
               <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </div>
</asp:Content>
