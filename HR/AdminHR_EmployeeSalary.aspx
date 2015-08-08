<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_EmployeeSalary.aspx.cs" Inherits="AdminHR_EmployeeSalary" Title="HR_EmployeeSalary Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Insert /UpdateHR_EmployeeSalary</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt><span id="empSalary"><span class="style11">*</span>Select Types</span></dt>
                <dd>
                    <asp:RadioButtonList ID="radIsGross" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Selected="True">Basic</asp:ListItem>
                        <asp:ListItem Value="False">Gross</asp:ListItem>
                    </asp:RadioButtonList>
                </dd>
                <dt>
                    <asp:Label ID="lblAmount" runat="server" Text="Amount: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtAmount" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
                </dd>
                <dt>*Select Rules </dt>
                <dd>
                    <asp:RadioButtonList ID="radSalaryRules" runat="server" RepeatDirection="Horizontal"
                        AutoPostBack="True" OnSelectedIndexChanged="radSalaryRules_SelectedIndexChanged">
                        <asp:ListItem Value="True" Selected="True">Custom</asp:ListItem>
                        <asp:ListItem Value="False">Package</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:DropDownList ID="ddlPackage" Visible="false" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlPackage_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
            </dl>
        </div>
        <div runat="server" id="divSalaryPackageRules" visible="false">
            <dl>
                <dt>&nbsp; *Rules Name : </dt>
                <dd>
                    <asp:DropDownList ID="ddlPackageRules" Visible="true" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="Button1" class="button button-blue" runat="server" Text="More Rules"
                        OnClick="btnAddMore_Click" />
                </dd>
            </dl>
        </div>
        <div runat="server" id="div1" visible="true">
            <dl>
                <dt></dt>
                <dd>
                    <asp:GridView ID="gridViewPackageAndPackageRules" Width="100%" class="gridCss" runat="server"
                        AutoGenerateColumns="false" CssClass="gridCss">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkPackageRulesID"  runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Package Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblPackageRulesID" runat="server" Text='<%#Eval("PackageRulesID") %>'
                                        Visible="false">
                                    </asp:Label>
                                    <asp:Label ID="lblPackageName" runat="server" Text='<%#Eval("PackageName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Package Rules Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblPackageRulesName" runat="server" Text='<%#Eval("PackageRulesName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rules Value">
                                <ItemTemplate>
                                    <asp:Label ID="lblRulesValue" runat="server" Text='<%#Eval("RulesValue") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rules Operator">
                                <ItemTemplate>
                                    <asp:Label ID="lblRulesOperator" runat="server" Text='<%#Eval("RulesOperator") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </dd>
            </dl>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                Salary Rules</h3>
        </div>
        <div class="inner-form">
            <asp:GridView ID="gvHR_PackageRules" Width="100%" class="gridCss" runat="server"
                AutoGenerateColumns="false" CssClass="gridCss">
                <Columns>
                    <asp:TemplateField HeaderText="Rules Name">
                        <ItemTemplate>
                            <asp:Label ID="lblPackageRulesID" runat="server" Text='<%#Eval("PackageRulesID") %>'
                                Visible="false">
                            </asp:Label>
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
                    <%--<asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </div>
        <div style="width: 100%; text-align: center">
            <asp:Button ID="Button2" class="button button-blue" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
