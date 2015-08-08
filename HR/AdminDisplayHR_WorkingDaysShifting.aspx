<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayHR_WorkingDaysShifting.aspx.cs" Inherits="AdminDisplayHR_WorkingDaysShifting"
    Title="HR_WorkingDaysShifting Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Tabular DataHR_WorkingDaysShifting</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvHR_WorkingDaysShifting" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="gridCss">
                <Columns>
                    <asp:TemplateField HeaderText="Working Days" HeaderStyle-Width="58%">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkSaturday" Checked='<%#Eval("Saturday")%>' />
                            <asp:Label ID="lblSaturday" runat="server" Text="Saturday">
                            </asp:Label>
                            <asp:CheckBox runat="server" ID="chkSunday" Checked='<%#Eval("Sunday")%>' />
                            <asp:Label ID="lblSunday" runat="server" Text="Sunday">
                            </asp:Label>
                            <asp:CheckBox runat="server" ID="chkMonday" Checked='<%#Eval("Monday")%>' />
                            <asp:Label ID="lblMonday" runat="server" Text="Monday">
                            </asp:Label>
                            <asp:CheckBox runat="server" ID="chkTuesday" Checked='<%#Eval("Tuesday")%>' />
                            <asp:Label ID="lblTuesday" runat="server" Text="Tuesday">
                            </asp:Label>
                            <asp:CheckBox runat="server" ID="chkWednesday" Checked='<%#Eval("Wednesday")%>' />
                            <asp:Label ID="lblWednesday" runat="server" Text="Wednesday">
                            </asp:Label>
                            <asp:CheckBox runat="server" ID="chkThrusday" Checked='<%#Eval("Thrusday")%>' />
                            <asp:Label ID="lblThrusday" runat="server" Text="Thrusday">
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shift Start Time" HeaderStyle-Width="70px">
                        <ItemTemplate>
                            <asp:Label ID="lblShiftStartTime" runat="server" Text='<%#Eval("ShiftStartTime","{0:T}") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shift End Time" HeaderStyle-Width="70px">
                        <ItemTemplate>
                            <asp:Label ID="lblShiftEndTime" runat="server" Text='<%#Eval("ShiftEndTime","{0:T}") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("WorkingDaysID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument='<%#Eval("WorkingDaysID") %>'
                                OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
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
</asp:Content>
