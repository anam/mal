<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplaySTD_ClassSubjectEmployee.aspx.cs" Inherits="AdminDisplaySTD_ClassSubjectEmployee"
    Title="List Of Existing Class Subject Employee" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                List Of Existing Class Subject Employee</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvSTD_ClassSubjectEmployee" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="gridCss">
                <Columns>
                    <asp:TemplateField HeaderText="Class Subject Employee">
                        <ItemTemplate>
                            <asp:Label ID="lblClassSubjectEmployeeID" runat="server" Text='<%#Eval("ClassSubjectEmployeeID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Class Subject Employee Name">
                        <ItemTemplate>
                            <asp:Label ID="lblClassSubjectEmployeeName" runat="server" Text='<%#Eval("ClassSubjectEmployeeName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Employee">
                        <ItemTemplate>
                            <asp:Label ID="lblEmployeeID" runat="server" Text='<%#Eval("EmployeeID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Class Subject">
                        <ItemTemplate>
                            <asp:Label ID="lblClassSubjectID" runat="server" Text='<%#Eval("ClassSubjectID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Updated By">
                        <ItemTemplate>
                            <asp:Label ID="lblUpdatedBy" runat="server" Text='<%#Eval("UpdatedBy") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Update Date">
                        <ItemTemplate>
                            <asp:Label ID="lblUpdateDate" runat="server" Text='<%#Eval("UpdateDate") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("ClassSubjectEmployeeID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                CommandArgument='<%#Eval("ClassSubjectEmployeeID") %>' OnClick="lbDelete_Click"
                                AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="paging">
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
